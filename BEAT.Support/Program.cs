using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Windows.Forms;
using System.Collections;

namespace BEAT.Support
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        private static string binariesListPath;
        private static string xmlPath;
        private static string rootPath;
        private static string localDirectory;
        private static DataTable dtBranchLocations;
        private static ArrayList dynamicColumns = new ArrayList();

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            //if (args.Length == 3)
            //{

            //}
            //else
            //    Console.WriteLine("\n\tInvalid Number of Arguments");

            xmlPath = @"C:\Saurav\Projects\BEAT\BEAT.Support\SampleFile\BinariesPath.xml";
            localDirectory = @"C:\Saurav\Rakesh\";

            binariesListPath = localDirectory + "\\BinariesList.csv";

            GetAllFilesBlueprints(xmlPath);
            GetBlueprints();
        }

        /// <summary>
        /// GetBlueprints
        /// </summary>
        /// <returns></returns>
        private static string GetBlueprints()
        {

            //DataTable dtXmlData = XMLDataTable(dataXml);

            return "";
        }

        /// <summary>
        /// GetBranchesFolderLocations
        /// </summary>
        private static void GetAllFilesBlueprints(string dataXml)
        {
            DataTable dtTempFolderStructure = XMLDataTable(dataXml);
            dtBranchLocations = GetFolderLocations(dtTempFolderStructure);

            DataTable dtExistingData = new DataTable();
            dtExistingData.Columns.Add("ServerPath");
            dtExistingData.Columns.Add("LocalDirectoryPath");
            dtExistingData.Columns.Add("BPPath");

            ReadDatafromCSV(dtExistingData, binariesListPath);

            foreach (DataRow drBranchLocation in dtBranchLocations.Rows)
            {
                DataRow[] drCol = dtExistingData.Select("ServerPath ='" + drBranchLocation[1].ToString() + "'");
                if (drCol.Length == 0)
                {
                    string bpPath = drBranchLocation[2].ToString() + "\\bp.csv";

                    if (!Directory.Exists(drBranchLocation[2].ToString()))
                        Directory.CreateDirectory(drBranchLocation[2].ToString());

                    if (GenerateBP(drBranchLocation[1].ToString(), bpPath))
                    {
                        ArrayList dynamicParameters = new ArrayList();

                        for (int counter = 4; counter < dtBranchLocations.Columns.Count; counter++)
                            dynamicParameters.Add(drBranchLocation[counter].ToString());

                        using (StreamWriter sw = File.AppendText(binariesListPath))
                        {
                            WriteToFile(sw, dynamicParameters, drBranchLocation[3].ToString(), drBranchLocation[1].ToString(), drBranchLocation[2].ToString(), bpPath);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// GenerateBP
        /// </summary>
        /// <param name="p"></param>
        private static bool GenerateBP(string folderLocation, string bpPath)
        {
            string command = String.Format("java -jar {0}\\FileMapper.jar {1} {2}", Application.StartupPath.ToString(), folderLocation, bpPath);
            if (ExecuteSystemCommandSync(command) == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// ExecuteSystemCommand
        /// </summary>
        /// <param name="arrayList"></param>
        /// <returns></returns>
        private static int ExecuteSystemCommandSync(string command)
        {
            //WritetoLogs("****");
            Console.WriteLine("Command: " + command + "\n");
            //command = command + logRedirectPath;
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

            // The following commands are needed to redirect the standard output.
            // This means that it will be redirected to the Process.StandardOutput StreamReader.
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            // Do not create the black window.
            procStartInfo.CreateNoWindow = false;
            // Now we create a process, assign its ProcessStartInfo and start it
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            // Get the output into a string
            //Console.ReadLine();
            string result = proc.StandardOutput.ReadToEnd();
            Console.WriteLine("\n\nExitCode: " + proc.ExitCode.ToString());
            // Display the command output.
            Console.WriteLine(result);
            //WritetoLogs("****");

            return proc.ExitCode;
        }

        /// <summary>
        /// ReadDatafromCSV
        /// </summary>
        public static void ReadDatafromCSV(DataTable dtTable, string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] separator = new string[] { "," };
                        string[] splitline = line.Split(separator, StringSplitOptions.None);
                        if (line.Trim() != "")
                        {
                            DataRow dr = dtTable.NewRow();
                            dr[0] = splitline[3];
                            dr[1] = splitline[4];
                            dr[2] = splitline[5];
                            dtTable.Rows.Add(dr);
                        }
                    }
                }
                dtTable.Rows.RemoveAt(0);
            }
            else
            {
                using (StreamWriter sw = File.CreateText(filePath))
                    WriteToFile(sw, dynamicColumns, "Last Written Date", "Server Path", "Local Directory Path", "BP Path");
            }

        }

        /// <summary>
        /// WriteToFile
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="serverPath"></param>
        /// <param name="localDirectoryPath"></param>
        /// <param name="bpPath"></param>
        private static void WriteToFile(StreamWriter sw, ArrayList dynamicData, string date, string serverPath, string localDirectoryPath, string bpPath)
        {
            try
            {
                StringBuilder str = new StringBuilder();

                if (dynamicData != null)
                    foreach (string data in dynamicData)
                        str.Append(data + ",");

                str.Append(string.Format("{0},{1},{2},{3}", date, serverPath, localDirectoryPath, bpPath));

                sw.WriteLine(str.ToString());
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// XMLDataTable
        /// </summary>
        /// <param name="dataXml"></param>
        /// <param name="BuildNo"></param>
        /// <returns></returns>
        private static DataTable GetFolderLocations(DataTable dtTempFolderStructure)
        {
            DataTable dtData = new DataTable();
            dtData.Columns.Add("ParentServerPath");
            dtData.Columns.Add("ServerPath");
            dtData.Columns.Add("LocalPath");
            dtData.Columns.Add("LastWritten");

            ArrayList newDataColumns = new ArrayList();

            foreach (DataRow drFolderStructure in dtTempFolderStructure.Rows)
            {
                string[] pathSplit = drFolderStructure[0].ToString().Split(new string[] { "DYNAMIC" }, StringSplitOptions.None);
                string root = pathSplit[0];
                rootPath = root;

                dynamicColumns.Clear();
                for (int counter = 1; counter < dtTempFolderStructure.Columns.Count; counter++)
                    if (!dynamicColumns.Contains(drFolderStructure[counter].ToString()))
                        dynamicColumns.Add(drFolderStructure[counter].ToString());

                foreach (string str in dynamicColumns)
                    if (!newDataColumns.Contains(str))
                    {
                        newDataColumns.Add(str);
                        dtData.Columns.Add(str);
                    }

                ArrayList dynamicParameters = new ArrayList();
                DirectoryTraversal(root, null, pathSplit, dtData, dynamicParameters, 1);
            }
            return dtData;
        }

        /// <summary>
        /// DirectoryTraversal
        /// </summary>
        /// <param name="root"></param>
        /// <param name="pathSplit"></param>
        /// <param name="dtData"></param>
        /// <returns></returns>
        private static void DirectoryTraversal(string parent, DirectoryInfo subDirectory, string[] pathSplit, DataTable dtData, ArrayList dynamicParameters, int level)
        {
            string root;

            if (subDirectory == null)
                root = pathSplit[0];
            else
                root = subDirectory.FullName + pathSplit[level - 1];

            if (pathSplit.Length == level)
            {
                DataRow dr = dtData.NewRow();
                dr[0] = parent;
                dr[1] = root;
                dr[2] = root.Replace(rootPath, localDirectory);

                DirectoryInfo dir = new DirectoryInfo(root);
                dr[3] = dir.LastWriteTime;

                for (int i = 0; i < dynamicParameters.Count; i++)
                    dr[dynamicColumns[i].ToString()] = dynamicParameters[i];

                dtData.Rows.Add(dr);
            }
            else if (Directory.Exists(root))
            {
                DirectoryInfo dir = new DirectoryInfo(root);
                foreach (DirectoryInfo directoryInfo in dir.GetDirectories())
                {
                    dynamicParameters.Add(directoryInfo.Name);
                    DirectoryTraversal(root, directoryInfo, pathSplit, dtData, dynamicParameters, level + 1);
                }
            }

            if (dynamicParameters.Count > 0)
                dynamicParameters.RemoveAt(dynamicParameters.Count - 1);
        }

        /// <summary>
        /// XMLDataTable
        /// </summary>
        /// <param name="dataXml"></param>
        /// <param name="BuildNo"></param>
        /// <returns></returns>
        private static DataTable XMLDataTable(string dataXml)
        {
            string serverPath = "";

            DataTable dtTempXmlPath = new DataTable();
            dtTempXmlPath.Columns.Add("Path");

            DataTable dtData = new DataTable();
            dtData.Columns.Add("Path");

            ArrayList dynamicParameters = new ArrayList();

            int nodesAdded = 0;
            XmlTextReader xtReader = new XmlTextReader(dataXml);

            while (xtReader.Read())
            {
                switch (xtReader.NodeType)
                {
                    case XmlNodeType.Element:
                        nodesAdded++;

                        DataRow dr = dtTempXmlPath.NewRow();
                        if (xtReader.Name.ToUpper() == "SERVER")
                            serverPath = xtReader["Path"];
                        else
                        {
                            dr[0] = xtReader.Name;
                            dtTempXmlPath.Rows.Add(dr);
                            if (xtReader.Name == "DYNAMIC")
                                dynamicParameters.Add(xtReader["Name"]);
                        }

                        break;

                    ////Display the end of the element.
                    case XmlNodeType.EndElement:

                        if (nodesAdded > 0)
                        {
                            StringBuilder path = new StringBuilder();
                            foreach (DataRow drPathRow in dtTempXmlPath.Rows)
                                path.Append("\\" + drPathRow[0]);

                            DataRow drDataRow = dtData.NewRow();
                            drDataRow[0] = (serverPath + "\\" + path.ToString().Substring(1, path.ToString().Length - 1)).ToUpper();

                            for (int counter = 0; counter < dynamicParameters.Count; counter++)
                            {
                                if (dtData.Columns.Count <= counter + 1)
                                    dtData.Columns.Add("Dynamic" + counter + 1);

                                drDataRow[counter + 1] = dynamicParameters[counter];
                            }
                            dtData.Rows.Add(drDataRow);
                        }
                        nodesAdded = 0;

                        //if (dtData.Rows.Count > 0 && xtReader.Name.ToString() == (dtData.Rows[dtData.Rows.Count - 1][0]).ToString())
                        //    dtData.Rows.RemoveAt(dtData.Rows.Count - 1);

                        if (dtTempXmlPath.Rows.Count > 0)
                            dtTempXmlPath.Rows.RemoveAt(dtTempXmlPath.Rows.Count - 1);

                        if (xtReader.Name == "DYNAMIC")
                            dynamicParameters.RemoveAt(dynamicParameters.Count - 1);

                        break;
                    default:
                        break;
                }

            }


            return dtData;
        }
    }
}
