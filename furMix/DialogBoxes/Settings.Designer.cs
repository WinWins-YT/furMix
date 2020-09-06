namespace furMix
{
    partial class Settings
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
            this.CasinoChk = new System.Windows.Forms.CheckBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.devlist = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CasinoChk
            // 
            this.CasinoChk.AutoSize = true;
            this.CasinoChk.Location = new System.Drawing.Point(13, 13);
            this.CasinoChk.Name = "CasinoChk";
            this.CasinoChk.Size = new System.Drawing.Size(121, 17);
            this.CasinoChk.TabIndex = 0;
            this.CasinoChk.Text = "Turn off casino error";
            this.CasinoChk.UseVisualStyleBackColor = true;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(212, 66);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(90, 23);
            this.SaveBtn.TabIndex = 1;
            this.SaveBtn.Text = "Save and Exit";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Playback device:";
            // 
            // devlist
            // 
            this.devlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devlist.FormattingEnabled = true;
            this.devlist.Location = new System.Drawing.Point(105, 39);
            this.devlist.Name = "devlist";
            this.devlist.Size = new System.Drawing.Size(197, 21);
            this.devlist.TabIndex = 3;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 97);
            this.Controls.Add(this.devlist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.CasinoChk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CasinoChk;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox devlist;
    }
}