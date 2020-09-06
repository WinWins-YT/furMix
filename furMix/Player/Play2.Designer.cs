namespace furMix
{
    partial class Play2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Play2));
            this.Video = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.Video)).BeginInit();
            this.SuspendLayout();
            // 
            // Video
            // 
            this.Video.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Video.Enabled = true;
            this.Video.Location = new System.Drawing.Point(0, 0);
            this.Video.Name = "Video";
            this.Video.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Video.OcxState")));
            this.Video.Size = new System.Drawing.Size(643, 462);
            this.Video.TabIndex = 0;
            // 
            // Play2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(643, 462);
            this.Controls.Add(this.Video);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Play2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Play2";
            ((System.ComponentModel.ISupportInitialize)(this.Video)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public AxWMPLib.AxWindowsMediaPlayer Video;
    }
}