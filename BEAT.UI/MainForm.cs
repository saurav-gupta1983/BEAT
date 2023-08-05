using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using BEAT.UI.Forms;

namespace BEAT.UI
{
    /// <summary>
    /// MainForm
    /// </summary>
    public partial class MainForm : Form
    {
        #region Private Variables

        private string appStartUpPath;
        private string machineName;
        private string machineIPAddress;
        private string machineLocation;
        private string configXMLPath = @"\Config";
        private string configXMLFileName = "BEATConfig.xml";

        #endregion

        #region Page Load Events

        /// <summary>
        /// MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// MainForm_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            appStartUpPath = Application.StartupPath.ToString();
            machineName = Environment.MachineName;
            machineIPAddress = GetMachineIPAddress();
            machineLocation = GetMachineCountryLocation();

            if (!Directory.Exists(appStartUpPath + configXMLPath))
                Directory.CreateDirectory(appStartUpPath + configXMLPath);
        }

        #endregion

        #region Menu Items Click

        /// <summary>
        /// aboutUsToolStripMenuItem1_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutUsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutUsForm form = new AboutUsForm();
            form.MdiParent = this;
            form.Show();
        }

        /// <summary>
        /// ApplicationLaunchToolStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void applicationLaunchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// BinariesStripMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BinariesStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadBuildForm form = new DownloadBuildForm();
            form.MdiParent = this;
            form.Show();
        }

        #endregion

        #region Private Functions

        /// <summary>
        /// GetMachineIPAddress
        /// </summary>
        /// <returns></returns>
        private string GetMachineIPAddress()
        {
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;

            return addr[addr.Length - 1].ToString();
        }

        /// <summary>
        /// GetMachineCountryLocation
        /// </summary>
        /// <returns></returns>
        private string GetMachineCountryLocation()
        {
            return System.Globalization.RegionInfo.CurrentRegion.DisplayName;
        }


        #endregion
    }
}
