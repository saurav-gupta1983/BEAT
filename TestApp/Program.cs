using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    /// <summary>
    /// Program
    /// </summary>
    class Program
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string rsyncServerAddress = "10.40.4.16";
            string productName = "Illustrator";
            string productCode = "ILS";

            string configFileName = String.Format("cfg_{0}.txt", productName);
            string productFilePath = String.Format("/cygdrive/c/BuildSynchronizer/{0}/", productName);

            string command = String.Format("rsync -rtvz --sparse --stats --progress {0}::\"{1}/{2}\" \"{3}\"", rsyncServerAddress, productCode, configFileName, productFilePath);

            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

            // The following commands are needed to redirect the standard output.
            // This means that it will be redirected to the Process.StandardOutput StreamReader.
            procStartInfo.RedirectStandardError = true;
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            // Do not create the black window.
            procStartInfo.CreateNoWindow = false;
            // Now we create a process, assign its ProcessStartInfo and start it
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            // Get the output into a string
            string result = proc.StandardOutput.ReadToEnd();
            // Display the command output.
            Console.WriteLine("\nResult: " + result);
            Console.WriteLine("\n\nExitCode: " + proc.ExitCode.ToString());
            Console.WriteLine("\nStartTime: " + proc.StartTime.ToString());
            Console.WriteLine("\nExitTime: " + proc.ExitTime.ToString());
            Console.WriteLine("\nErrorOutput: " + proc.StandardError.ReadToEnd());
            Console.WriteLine("\nTotalProcessorTime: " + proc.TotalProcessorTime.ToString());
            Console.WriteLine("\nUserProcessorTime: " + proc.UserProcessorTime.ToString());
            Console.ReadLine();
        }
    }
}
