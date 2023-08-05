namespace BEAT.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adobeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownloadStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BinariesStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationLaunchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adobeToolStripMenuItem,
            this.aboutUsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(901, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adobeToolStripMenuItem
            // 
            this.adobeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DownloadStripMenuItem,
            this.applicationLaunchToolStripMenuItem});
            this.adobeToolStripMenuItem.Name = "adobeToolStripMenuItem";
            this.adobeToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.adobeToolStripMenuItem.Text = "Support Tools";
            // 
            // DownloadStripMenuItem
            // 
            this.DownloadStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BinariesStripMenuItem});
            this.DownloadStripMenuItem.Name = "DownloadStripMenuItem";
            this.DownloadStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.DownloadStripMenuItem.Text = "Download";
            // 
            // BinariesStripMenuItem
            // 
            this.BinariesStripMenuItem.Name = "BinariesStripMenuItem";
            this.BinariesStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.BinariesStripMenuItem.Text = "Binaries";
            this.BinariesStripMenuItem.Click += new System.EventHandler(this.BinariesStripMenuItem_Click);
            // 
            // applicationLaunchToolStripMenuItem
            // 
            this.applicationLaunchToolStripMenuItem.Name = "applicationLaunchToolStripMenuItem";
            this.applicationLaunchToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.applicationLaunchToolStripMenuItem.Text = "Application launch";
            this.applicationLaunchToolStripMenuItem.Click += new System.EventHandler(this.applicationLaunchToolStripMenuItem_Click);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutUsToolStripMenuItem1,
            this.updatesToolStripMenuItem});
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.aboutUsToolStripMenuItem.Text = "About Us";
            // 
            // aboutUsToolStripMenuItem1
            // 
            this.aboutUsToolStripMenuItem1.Name = "aboutUsToolStripMenuItem1";
            this.aboutUsToolStripMenuItem1.Size = new System.Drawing.Size(123, 22);
            this.aboutUsToolStripMenuItem1.Text = "About Us";
            this.aboutUsToolStripMenuItem1.Click += new System.EventHandler(this.aboutUsToolStripMenuItem1_Click);
            // 
            // updatesToolStripMenuItem
            // 
            this.updatesToolStripMenuItem.Name = "updatesToolStripMenuItem";
            this.updatesToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.updatesToolStripMenuItem.Text = "Updates";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 597);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "BEAT - Download Builds";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adobeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DownloadStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BinariesStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem applicationLaunchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatesToolStripMenuItem;
    }
}