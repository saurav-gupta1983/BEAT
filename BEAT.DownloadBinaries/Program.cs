using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Collections;

namespace BEAT.DownloadBinaries
{
    /// <summary>
    /// Program
    /// </summary>
    class Program
    {
        #region Variables

        private static string ftpServer;
        private static string ftpUserName;
        private static string ftpPassword;

        private static string downloadPath;
        private static string localDirectory;
        private static string downloadedFilesPath;
        private static DataTable dtBranchLocations;
        private static ArrayList dynamicColumns = new ArrayList();

        #endregion

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //if (args.Length == 4)
            //{

            //}
            //else
            //    Console.WriteLine("\n\tInvalid Number of Arguments");

            ftpServer = @"C:\Saurav\Rakesh\";
            ftpUserName = "sauragup";
            ftpPassword = "01Sep$2012";
            localDirectory = @"C:\Saurav\New\";

            downloadPath = ftpServer + @"BinariesList.csv";
            downloadedFilesPath = localDirectory + "BinariesList.csv";

            SelectDownloadedFilesList();

        }

        /// <summary>
        /// SelectDownloadedFilesList
        /// </summary>
        private static void SelectDownloadedFilesList()
        {
            DataTable dtServerData = ReadDatafromCSV(downloadPath);
            DataTable dtClientData = ReadDatafromCSV(downloadedFilesPath);


        }

        /// <summary>
        /// GetDownloadedFilesList
        /// </summary>
        private static DataTable GetDownloadedFilesList()
        {
            using (StreamWriter sw = File.CreateText(downloadedFilesPath))
                WriteToFile(sw, dynamicColumns, "Last Written Date", "Server Path", "Local Directory Path", "BP Path");
        }

        /// <summary>
        /// ReadDatafromCSV
        /// </summary>
        public static DataTable ReadDatafromCSV(string filePath)
        {
            DataTable dtData = new DataTable();
            dtData.Columns.Add("Feature");
            dtData.Columns.Add("Build#");
            dtData.Columns.Add("Date");
            dtData.Columns.Add("ServerPath");
            dtData.Columns.Add("LocalDirectoryPath");
            dtData.Columns.Add("BPPath");

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
                            DataRow dr = dtData.NewRow();
                            dr[0] = splitline[0];
                            dr[1] = splitline[1];
                            dr[2] = splitline[2];
                            dr[3] = splitline[3];
                            dr[4] = splitline[4];
                            dr[5] = splitline[5];
                            dtData.Rows.Add(dr);
                        }
                    }
                }
                dtData.Rows.RemoveAt(0);
            }

            return dtData;
        }

        /// <summary>
        /// WriteToFile
        /// </summary>
        /// <param name="sw"></param>
        /// <param name="drData"></param>
        private static void WriteToFile(StreamWriter sw, DataRow drData)
        {
            try
            {
                StringBuilder str = new StringBuilder();

                str.Append(drData[0]);
                for (int counter = 1; counter < drData.ItemArray.Length; counter++)
                    str.Append("," + drData[counter]);

                sw.WriteLine(str.ToString());
            }
            catch (Exception)
            {
            }
        }


    }
}
