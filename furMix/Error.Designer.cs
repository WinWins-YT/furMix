namespace furMix
{
    partial class Error
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Error));
            this.ErrorVideo = new AxWMPLib.AxWindowsMediaPlayer();
            this.button1 = new System.Windows.Forms.Button();
            this.ErrorInfo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorVideo
            // 
            this.ErrorVideo.Enabled = true;
            this.ErrorVideo.Location = new System.Drawing.Point(0, -1);
            this.ErrorVideo.Name = "ErrorVideo";
            this.ErrorVideo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ErrorVideo.OcxState")));
            this.ErrorVideo.Size = new System.Drawing.Size(466, 240);
            this.ErrorVideo.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(377, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ErrorInfo
            // 
            this.ErrorInfo.BackColor = System.Drawing.Color.Black;
            this.ErrorInfo.ForeColor = System.Drawing.Color.White;
            this.ErrorInfo.Location = new System.Drawing.Point(12, 245);
            this.ErrorInfo.Multiline = true;
            this.ErrorInfo.Name = "ErrorInfo";
            this.ErrorInfo.ReadOnly = true;
            this.ErrorInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ErrorInfo.Size = new System.Drawing.Size(440, 93);
            this.ErrorInfo.TabIndex = 2;
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(464, 388);
            this.Controls.Add(this.ErrorInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ErrorVideo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Error";
            this.Text = "Error";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Error_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer ErrorVideo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ErrorInfo;
    }
}