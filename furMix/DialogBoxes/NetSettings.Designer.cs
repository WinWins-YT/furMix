namespace furMix
{
    partial class NetSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.PortTxt = new System.Windows.Forms.TextBox();
            this.IPTxt = new System.Windows.Forms.Label();
            this.PassTxt = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // PortTxt
            // 
            this.PortTxt.Location = new System.Drawing.Point(50, 33);
            this.PortTxt.Name = "PortTxt";
            this.PortTxt.Size = new System.Drawing.Size(64, 20);
            this.PortTxt.TabIndex = 1;
            // 
            // IPTxt
            // 
            this.IPTxt.AutoSize = true;
            this.IPTxt.Location = new System.Drawing.Point(15, 13);
            this.IPTxt.Name = "IPTxt";
            this.IPTxt.Size = new System.Drawing.Size(20, 13);
            this.IPTxt.TabIndex = 2;
            this.IPTxt.Text = "IP:";
            // 
            // PassTxt
            // 
            this.PassTxt.AutoSize = true;
            this.PassTxt.Location = new System.Drawing.Point(15, 60);
            this.PassTxt.Name = "PassTxt";
            this.PassTxt.Size = new System.Drawing.Size(56, 13);
            this.PassTxt.TabIndex = 3;
            this.PassTxt.Text = "Password:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NetSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 115);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PassTxt);
            this.Controls.Add(this.IPTxt);
            this.Controls.Add(this.PortTxt);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "NetSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Network settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PortTxt;
        private System.Windows.Forms.Label IPTxt;
        private System.Windows.Forms.Label PassTxt;
        private System.Windows.Forms.Button button1;
    }
}