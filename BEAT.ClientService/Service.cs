using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace BEAT.ClientService
{
    /// <summary>
    /// Service
    /// </summary>
    public partial class Service : ServiceBase
    {
        #region Variables

        //10.40.144.54
        //string rsyncServerAddress = "10.40.4.16";
        string rsyncServerAddress = "10.40.144.54";
        string rsyncProductFilePath = "/cygdrive/c/BuildSynchronizer/";
        string logFilePath = "C:\\BuildSynchronizer";
        string logRedirectPath = "C:\\BuildSynchronizer";
        string localFilePath = "C:\\BuildSynchronizer\\";
        string productName = "Illustrator";
        string productCode;

        string configFileName;
        string configFilePath;
        string previousConfigFilePath;
        string diffConfigFilePath;
        string refConfigFilePath;

        #endregion

        #region Service Start

        /// <summary>
        /// Service
        /// </summary>
        public Service()
        {
            InitializeComponent();
            OnStart(new string[] { " " });
        }

        ///// <summary>
        ///// OnStop
        ///// </summary>
        //protected override void OnStop()
        //{
        //}

        /// <summary>
        /// OnStart
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            OpenRSyncConfigurationFile();
            DownloadConfigFile();
            CompareConfigFiles();
            DownloadBuilds();
        }

        #endregion

        #region Private Functions

        /// <summary>
        /// DownloadBuilds
        /// </summary>
        private void DownloadBuilds()
        {
            string[] diffConfigFileLines = File.ReadAllLines(diffConfigFilePath);
            refConfigFilePath = localFilePath + productName + "\\" + String.Format("ref_cfg_{0}.txt", productName);
            string[] refConfigFileLines = null;

            if (File.Exists(refConfigFilePath))
                refConfigFileLines = File.ReadAllLines(refConfigFilePath);

            if (diffConfigFileLines.Length > 0)
            {
                DataTable dtBuilds = new DataTable();
                dtBuilds.Columns.Add("Platform");
                dtBuilds.Columns.Add("Locale");
                dtBuilds.Columns.Add("Format");
                dtBuilds.Columns.Add("BuildNo");
                dtBuilds.Columns.Add("BuildLocation");

                foreach (string line in diffConfigFileLines)
                {
                    string[] buildInfo = line.Split(new string[] { "\t" }, StringSplitOptions.None);

                    DataRow dr = dtBuilds.NewRow();
                    dr[0] = buildInfo[0];
                    dr[1] = buildInfo[1];
                    dr[2] = buildInfo[2];
                    dr[3] = buildInfo[3];
                    dr[4] = buildInfo[4];
                    dtBuilds.Rows.Add(dr);
                }

                DataView dvBuilds = new DataView(dtBuilds);
                dvBuilds.RowFilter = "Platform = 'win32' AND Locale = 'en_US' AND Format = 'RIBS Installer'";

                dtBuilds = dvBuilds.ToTable();

                DataTable dtBuild = dvBuilds.ToTable(true, "Platform", "Locale", "Format");
                dtBuild.Columns.Add("BuildNo");
                dtBuild.Columns.Add("BuildLocation");

                foreach (DataRow drBuild in dtBuild.Rows)
                {
                    DataRow[] row = dtBuilds.Select(String.Format("Platform = '{0}' AND Locale = '{1}' AND Format = '{2}'", drBuild[0], drBuild[1], drBuild[2]));

                    drBuild[3] = row[row.Length - 1][3];
                    drBuild[4] = row[row.Length - 1][4];
                }

                foreach (DataRow drBuild in dtBuild.Rows)
                {
                    WritetoLogs("\n Platform: " + drBuild[0]);
                    WritetoLogs("\n Locale: " + drBuild[1]);
                    WritetoLogs("\n Format: " + drBuild[2]);
                    WritetoLogs("\n BuildNo: " + drBuild[3]);
                    WritetoLogs("\n BuildLocation: " + drBuild[4]);

                    if (!Directory.Exists(drBuild[4].ToString()))
                        Directory.CreateDirectory(localFilePath + productName + "\\" + drBuild[0].ToString() + "\\" + drBuild[1].ToString() + "\\" + drBuild[2].ToString());

                    string reference1 = "";
                    string reference2 = "";

                    if (refConfigFileLines != null)
                    {
                        foreach (string refLine in refConfigFileLines)
                        {
                            if (refLine.Contains(drBuild[0].ToString()) && refLine.Contains(drBuild[2].ToString()))
                                reference1 = refLine.Split(new string[] { "\t" }, StringSplitOptions.None)[3];
                            if (refLine.Contains("en_US") && refLine.Contains(drBuild[0].ToString()) && refLine.Contains(drBuild[2].ToString()))
                                reference2 = refLine.Split(new string[] { "\t" }, StringSplitOptions.None)[3];
                        }
                    }

                    if (reference1 == "")
                    {
                        reference1 = reference2;
                        reference2 = "";
                    }

                    string remoteBuildDir = productCode + "/" + drBuild[0].ToString() + "/" + drBuild[1].ToString() + "/" + drBuild[2] + "/" + drBuild[3].ToString();
                    string rSyncBuildPath = rsyncProductFilePath + productName + "/" + drBuild[0].ToString() + "/" + drBuild[1].ToString() + "/" + drBuild[2].ToString();
                    string command = String.Format("rsync -rtvz --delete --sparse --stats --progress --copy-dest=\"{0}\" {1}::\"{2}\" \"{3}\"", reference1, rsyncServerAddress, remoteBuildDir, rSyncBuildPath);
                    ExecuteSystemCommandSync(command);
                }
            }
        }

        /// <summary>
        /// CompareConfigFiles
        /// </summary>
        private void CompareConfigFiles()
        {
            previousConfigFilePath = localFilePath + productName + "\\" + String.Format("pre_cfg_{0}.txt", productName);
            diffConfigFilePath = localFilePath + productName + "\\" + String.Format("diff_cfg_{0}.txt", productName);

            if (File.Exists(diffConfigFilePath))
                File.Delete(diffConfigFilePath);

            if (File.Exists(previousConfigFilePath))
                File.Delete(previousConfigFilePath);

            if (File.Exists(previousConfigFilePath))
            {
                string[] configFileLines = File.ReadAllLines(configFilePath);
                string[] prevConfigFileLines = File.ReadAllLines(previousConfigFilePath);

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(diffConfigFilePath))
                {
                    foreach (string line in configFileLines)
                        if (!prevConfigFileLines.Contains(line))
                            file.WriteLine(line);
                }

                File.Delete(previousConfigFilePath);
            }
            else
            {
                File.Copy(configFilePath, diffConfigFilePath);
            }

            File.Move(configFilePath, previousConfigFilePath);
        }

        /// <summary>
        /// DownloadConfigFile
        /// </summary>
        private void DownloadConfigFile()
        {
            logFilePath = localFilePath + "\\" + productName + "\\Beat.log";
            logRedirectPath = " >> " + logFilePath + " 2>&1";
            configFileName = String.Format("cfg_{0}.txt", productName);
            configFilePath = localFilePath + productName + "\\" + configFileName;

            if (File.Exists(configFilePath))
                File.Delete(configFilePath);

            string productFilePath = String.Format(rsyncProductFilePath + "{0}/", productName);
            System.IO.File.WriteAllText(logFilePath, "Product:" + productName + "\n");
            string command = String.Format("rsync -rtvz --sparse --stats --progress {0}::\"{1}/{2}\" \"{3}\"", rsyncServerAddress, productCode, configFileName, productFilePath, logRedirectPath);
            ExecuteSystemCommandSync(command);
        }

        /// <summary>
        /// OpenRSyncConfigurationFile
        /// </summary>
        private void OpenRSyncConfigurationFile()
        {
            string[] lines = File.ReadAllLines(String.Format("\\\\{0}\\system\\rsync.cfn", rsyncServerAddress));

            foreach (string line in lines)
            {
                string[] productInfo = line.Split(new string[] { "::::" }, StringSplitOptions.None);

                if (productInfo[0] == productName)
                {
                    productCode = productInfo[1];
                    break;
                }
            }
        }

        /// <summary>
        /// MakeStringEnum
        /// </summary>
        /// <param name="arrayList"></param>
        /// <returns></returns>
        private IEnumerator<string> MakeStringEnum(ArrayList arrayList)
        {
            foreach (string str in arrayList)
            {
                yield return str;
            }
        }

        /// <summary>
        /// ExecuteSystemCommand
        /// </summary>
        /// <param name="arrayList"></param>
        /// <returns></returns>
        private void ExecuteSystemCommandSync(string command)
        {
            WritetoLogs("****");
            WritetoLogs("Command: " + command + "\n");
            command = command + logRedirectPath;
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

            // The following commands are needed to redirect the standard output.
            // This means that it will be redirected to the Process.StandardOutput StreamReader.
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            // Do not create the black window.
            procStartInfo.CreateNoWindow = true;
            // Now we create a process, assign its ProcessStartInfo and start it
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            // Get the output into a string
            //Console.ReadLine();
            string result = proc.StandardOutput.ReadToEnd();
            Console.WriteLine("\n\nExitCode: " + proc.ExitCode.ToString());
            // Display the command output.
            //Console.WriteLine(result);
            WritetoLogs("****");
        }

        ///// <summary>
        ///// Execute the command Asynchronously.
        ///// </summary>
        ///// <param name="command">string command.</param>
        //public void ExecuteSystemCommandAsync(string command)
        //{
        //    try
        //    {
        //        //Asynchronously start the Thread to process the Execute command request.
        //        Thread objThread = new Thread(new ParameterizedThreadStart(ExecuteSystemCommandSync));
        //        //Make the thread as background thread.
        //        objThread.IsBackground = true;
        //        //Set the Priority of the thread.
        //        objThread.Priority = ThreadPriority.AboveNormal;
        //        //Start the thread.
        //        objThread.Start(command);
        //    }
        //    catch (ThreadStartException objException)
        //    {
        //        // Log the exception
        //    }
        //    catch (ThreadAbortException objException)
        //    {
        //        // Log the exception
        //    }
        //    catch (Exception objException)
        //    {
        //        // Log the exception
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        private void WritetoLogs(string text)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(logFilePath, true))
                file.WriteLine(text);
        }
        #endregion
    }
}
