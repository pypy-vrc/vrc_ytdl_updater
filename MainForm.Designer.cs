namespace VRC_YTDL_Updater
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.LocalVersion = new System.Windows.Forms.Label();
            this.RemoteVersion = new System.Windows.Forms.Label();
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DownloadStatus = new System.Windows.Forms.Label();
            this.pypy = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LocalVersion
            // 
            this.LocalVersion.AutoSize = true;
            this.LocalVersion.Location = new System.Drawing.Point(120, 12);
            this.LocalVersion.Name = "LocalVersion";
            this.LocalVersion.Size = new System.Drawing.Size(11, 12);
            this.LocalVersion.TabIndex = 0;
            this.LocalVersion.Text = "-";
            // 
            // RemoteVersion
            // 
            this.RemoteVersion.AutoSize = true;
            this.RemoteVersion.Location = new System.Drawing.Point(120, 36);
            this.RemoteVersion.Name = "RemoteVersion";
            this.RemoteVersion.Size = new System.Drawing.Size(11, 12);
            this.RemoteVersion.TabIndex = 1;
            this.RemoteVersion.Text = "-";
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Location = new System.Drawing.Point(14, 62);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(358, 23);
            this.DownloadProgressBar.TabIndex = 3;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Enabled = false;
            this.UpdateButton.Location = new System.Drawing.Point(297, 126);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 4;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DownloadStatus
            // 
            this.DownloadStatus.AutoSize = true;
            this.DownloadStatus.Location = new System.Drawing.Point(12, 91);
            this.DownloadStatus.Name = "DownloadStatus";
            this.DownloadStatus.Size = new System.Drawing.Size(41, 12);
            this.DownloadStatus.TabIndex = 5;
            this.DownloadStatus.Text = "Ready";
            // 
            // pypy
            // 
            this.pypy.AutoSize = true;
            this.pypy.Location = new System.Drawing.Point(12, 132);
            this.pypy.Name = "pypy";
            this.pypy.Size = new System.Drawing.Size(265, 12);
            this.pypy.TabIndex = 6;
            this.pypy.TabStop = true;
            this.pypy.Text = "https://github.com/pypy-vrc/vrc_ytdl_updater";
            this.pypy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.pypy_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "Latest Version";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Installed Version";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pypy);
            this.Controls.Add(this.DownloadStatus);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.DownloadProgressBar);
            this.Controls.Add(this.RemoteVersion);
            this.Controls.Add(this.LocalVersion);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VRChat youtube-dl updater (v0.0.1)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LocalVersion;
        private System.Windows.Forms.Label RemoteVersion;
        private System.Windows.Forms.ProgressBar DownloadProgressBar;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Label DownloadStatus;
        private System.Windows.Forms.LinkLabel pypy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

