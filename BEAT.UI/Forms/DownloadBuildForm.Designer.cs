namespace BEAT.UI.Forms
{
    partial class DownloadBuildForm
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
            this.textBoxBuildDownloadPath = new System.Windows.Forms.TextBox();
            this.labelBuildDownloadPath = new System.Windows.Forms.Label();
            this.buttonDownloadBuild = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBoxFtpUserName = new System.Windows.Forms.TextBox();
            this.labelFtpUserName = new System.Windows.Forms.Label();
            this.buttonBPDiffBrowse = new System.Windows.Forms.Button();
            this.textBoxLocalDirectoryPath = new System.Windows.Forms.TextBox();
            this.labelLocalDirectoryPath = new System.Windows.Forms.Label();
            this.textBoxftpPassword = new System.Windows.Forms.TextBox();
            this.labelFTPPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxBuildDownloadPath
            // 
            this.textBoxBuildDownloadPath.Location = new System.Drawing.Point(199, 23);
            this.textBoxBuildDownloadPath.Name = "textBoxBuildDownloadPath";
            this.textBoxBuildDownloadPath.Size = new System.Drawing.Size(478, 20);
            this.textBoxBuildDownloadPath.TabIndex = 6;
            this.textBoxBuildDownloadPath.Text = "C:\\Saurav\\Rakesh";
            // 
            // labelBuildDownloadPath
            // 
            this.labelBuildDownloadPath.AutoSize = true;
            this.labelBuildDownloadPath.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuildDownloadPath.Location = new System.Drawing.Point(12, 23);
            this.labelBuildDownloadPath.Name = "labelBuildDownloadPath";
            this.labelBuildDownloadPath.Size = new System.Drawing.Size(154, 19);
            this.labelBuildDownloadPath.TabIndex = 5;
            this.labelBuildDownloadPath.Text = "Build Download Path";
            // 
            // buttonDownloadBuild
            // 
            this.buttonDownloadBuild.Location = new System.Drawing.Point(255, 213);
            this.buttonDownloadBuild.Name = "buttonDownloadBuild";
            this.buttonDownloadBuild.Size = new System.Drawing.Size(206, 23);
            this.buttonDownloadBuild.TabIndex = 11;
            this.buttonDownloadBuild.Text = "Start Download";
            this.buttonDownloadBuild.UseVisualStyleBackColor = true;
            this.buttonDownloadBuild.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // textBoxFtpUserName
            // 
            this.textBoxFtpUserName.Location = new System.Drawing.Point(199, 56);
            this.textBoxFtpUserName.Name = "textBoxFtpUserName";
            this.textBoxFtpUserName.Size = new System.Drawing.Size(478, 20);
            this.textBoxFtpUserName.TabIndex = 14;
            // 
            // labelFtpUserName
            // 
            this.labelFtpUserName.AutoSize = true;
            this.labelFtpUserName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFtpUserName.Location = new System.Drawing.Point(12, 56);
            this.labelFtpUserName.Name = "labelFtpUserName";
            this.labelFtpUserName.Size = new System.Drawing.Size(111, 19);
            this.labelFtpUserName.TabIndex = 13;
            this.labelFtpUserName.Text = "FTP User Name";
            // 
            // buttonBPDiffBrowse
            // 
            this.buttonBPDiffBrowse.Location = new System.Drawing.Point(696, 154);
            this.buttonBPDiffBrowse.Name = "buttonBPDiffBrowse";
            this.buttonBPDiffBrowse.Size = new System.Drawing.Size(51, 23);
            this.buttonBPDiffBrowse.TabIndex = 18;
            this.buttonBPDiffBrowse.Text = "Browse";
            this.buttonBPDiffBrowse.UseVisualStyleBackColor = true;
            this.buttonBPDiffBrowse.Click += new System.EventHandler(this.buttonBPDiffBrowse_Click);
            // 
            // textBoxLocalDirectoryPath
            // 
            this.textBoxLocalDirectoryPath.Location = new System.Drawing.Point(199, 154);
            this.textBoxLocalDirectoryPath.Name = "textBoxLocalDirectoryPath";
            this.textBoxLocalDirectoryPath.Size = new System.Drawing.Size(478, 20);
            this.textBoxLocalDirectoryPath.TabIndex = 17;
            // 
            // labelLocalDirectoryPath
            // 
            this.labelLocalDirectoryPath.AutoSize = true;
            this.labelLocalDirectoryPath.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocalDirectoryPath.Location = new System.Drawing.Point(12, 154);
            this.labelLocalDirectoryPath.Name = "labelLocalDirectoryPath";
            this.labelLocalDirectoryPath.Size = new System.Drawing.Size(148, 19);
            this.labelLocalDirectoryPath.TabIndex = 16;
            this.labelLocalDirectoryPath.Text = "Local Directory Path";
            // 
            // textBoxftpPassword
            // 
            this.textBoxftpPassword.Location = new System.Drawing.Point(199, 91);
            this.textBoxftpPassword.Name = "textBoxftpPassword";
            this.textBoxftpPassword.Size = new System.Drawing.Size(478, 20);
            this.textBoxftpPassword.TabIndex = 20;
            this.textBoxftpPassword.UseSystemPasswordChar = true;
            this.textBoxftpPassword.WordWrap = false;
            // 
            // labelFTPPassword
            // 
            this.labelFTPPassword.AutoSize = true;
            this.labelFTPPassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFTPPassword.Location = new System.Drawing.Point(12, 91);
            this.labelFTPPassword.Name = "labelFTPPassword";
            this.labelFTPPassword.Size = new System.Drawing.Size(102, 19);
            this.labelFTPPassword.TabIndex = 19;
            this.labelFTPPassword.Text = "FTP Password";
            // 
            // DownloadBuildForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 262);
            this.Controls.Add(this.textBoxftpPassword);
            this.Controls.Add(this.labelFTPPassword);
            this.Controls.Add(this.buttonBPDiffBrowse);
            this.Controls.Add(this.textBoxLocalDirectoryPath);
            this.Controls.Add(this.labelLocalDirectoryPath);
            this.Controls.Add(this.textBoxFtpUserName);
            this.Controls.Add(this.labelFtpUserName);
            this.Controls.Add(this.buttonDownloadBuild);
            this.Controls.Add(this.textBoxBuildDownloadPath);
            this.Controls.Add(this.labelBuildDownloadPath);
            this.Name = "DownloadBuildForm";
            this.Text = "Download Builds - AMT Enabled Binaries";
            this.Load += new System.EventHandler(this.DownloadBuildForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxBuildDownloadPath;
        private System.Windows.Forms.Label labelBuildDownloadPath;
        private System.Windows.Forms.Button buttonDownloadBuild;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox textBoxFtpUserName;
        private System.Windows.Forms.Label labelFtpUserName;
        private System.Windows.Forms.Button buttonBPDiffBrowse;
        private System.Windows.Forms.TextBox textBoxLocalDirectoryPath;
        private System.Windows.Forms.Label labelLocalDirectoryPath;
        private System.Windows.Forms.TextBox textBoxftpPassword;
        private System.Windows.Forms.Label labelFTPPassword;
    }
}