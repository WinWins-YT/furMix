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
            this.VideoChk = new System.Windows.Forms.CheckBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.devlist = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.scrlist = new System.Windows.Forms.ComboBox();
            this.NetLabel = new System.Windows.Forms.Label();
            this.NetPortTxt = new System.Windows.Forms.TextBox();
            this.WebPortTxt = new System.Windows.Forms.TextBox();
            this.WebPortLabel = new System.Windows.Forms.Label();
            this.WebAPIPortTxt = new System.Windows.Forms.TextBox();
            this.WebAPIPortLabel = new System.Windows.Forms.Label();
            this.WebInterfaceChk = new System.Windows.Forms.CheckBox();
            this.UpdateCheck = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VideoChk
            // 
            this.VideoChk.AutoSize = true;
            this.VideoChk.Location = new System.Drawing.Point(17, 16);
            this.VideoChk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VideoChk.Name = "VideoChk";
            this.VideoChk.Size = new System.Drawing.Size(141, 20);
            this.VideoChk.TabIndex = 0;
            this.VideoChk.Text = "Turn off video error";
            this.VideoChk.UseVisualStyleBackColor = true;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBtn.Location = new System.Drawing.Point(353, 242);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(120, 28);
            this.SaveBtn.TabIndex = 1;
            this.SaveBtn.Text = "Save and Exit";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Playback device:";
            // 
            // devlist
            // 
            this.devlist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.devlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devlist.FormattingEnabled = true;
            this.devlist.Location = new System.Drawing.Point(159, 48);
            this.devlist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.devlist.Name = "devlist";
            this.devlist.Size = new System.Drawing.Size(313, 24);
            this.devlist.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Screen to show:";
            // 
            // scrlist
            // 
            this.scrlist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrlist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scrlist.FormattingEnabled = true;
            this.scrlist.Location = new System.Drawing.Point(159, 81);
            this.scrlist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scrlist.Name = "scrlist";
            this.scrlist.Size = new System.Drawing.Size(313, 24);
            this.scrlist.TabIndex = 5;
            // 
            // NetLabel
            // 
            this.NetLabel.AutoSize = true;
            this.NetLabel.Location = new System.Drawing.Point(16, 118);
            this.NetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NetLabel.Name = "NetLabel";
            this.NetLabel.Size = new System.Drawing.Size(88, 16);
            this.NetLabel.TabIndex = 6;
            this.NetLabel.Text = "Browser port: ";
            this.NetLabel.Visible = false;
            // 
            // NetPortTxt
            // 
            this.NetPortTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NetPortTxt.Location = new System.Drawing.Point(159, 114);
            this.NetPortTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NetPortTxt.Name = "NetPortTxt";
            this.NetPortTxt.Size = new System.Drawing.Size(313, 22);
            this.NetPortTxt.TabIndex = 7;
            this.NetPortTxt.Visible = false;
            // 
            // WebPortTxt
            // 
            this.WebPortTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebPortTxt.Location = new System.Drawing.Point(159, 174);
            this.WebPortTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WebPortTxt.Name = "WebPortTxt";
            this.WebPortTxt.Size = new System.Drawing.Size(313, 22);
            this.WebPortTxt.TabIndex = 9;
            this.WebPortTxt.Visible = false;
            // 
            // WebPortLabel
            // 
            this.WebPortLabel.AutoSize = true;
            this.WebPortLabel.Location = new System.Drawing.Point(16, 177);
            this.WebPortLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WebPortLabel.Name = "WebPortLabel";
            this.WebPortLabel.Size = new System.Drawing.Size(122, 16);
            this.WebPortLabel.TabIndex = 8;
            this.WebPortLabel.Text = "Web interface port: ";
            this.WebPortLabel.Visible = false;
            // 
            // WebAPIPortTxt
            // 
            this.WebAPIPortTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebAPIPortTxt.Location = new System.Drawing.Point(159, 206);
            this.WebAPIPortTxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WebAPIPortTxt.Name = "WebAPIPortTxt";
            this.WebAPIPortTxt.Size = new System.Drawing.Size(313, 22);
            this.WebAPIPortTxt.TabIndex = 11;
            this.WebAPIPortTxt.Visible = false;
            // 
            // WebAPIPortLabel
            // 
            this.WebAPIPortLabel.AutoSize = true;
            this.WebAPIPortLabel.Location = new System.Drawing.Point(16, 209);
            this.WebAPIPortLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WebAPIPortLabel.Name = "WebAPIPortLabel";
            this.WebAPIPortLabel.Size = new System.Drawing.Size(92, 16);
            this.WebAPIPortLabel.TabIndex = 10;
            this.WebAPIPortLabel.Text = "Web API port: ";
            this.WebAPIPortLabel.Visible = false;
            // 
            // WebInterfaceChk
            // 
            this.WebInterfaceChk.AutoSize = true;
            this.WebInterfaceChk.Location = new System.Drawing.Point(20, 146);
            this.WebInterfaceChk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WebInterfaceChk.Name = "WebInterfaceChk";
            this.WebInterfaceChk.Size = new System.Drawing.Size(154, 20);
            this.WebInterfaceChk.TabIndex = 12;
            this.WebInterfaceChk.Text = "Enable web interface";
            this.WebInterfaceChk.UseVisualStyleBackColor = true;
            this.WebInterfaceChk.Visible = false;
            // 
            // UpdateCheck
            // 
            this.UpdateCheck.AutoSize = true;
            this.UpdateCheck.Location = new System.Drawing.Point(180, 16);
            this.UpdateCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.UpdateCheck.Name = "UpdateCheck";
            this.UpdateCheck.Size = new System.Drawing.Size(194, 20);
            this.UpdateCheck.TabIndex = 13;
            this.UpdateCheck.Text = "Check for updates at startup";
            this.UpdateCheck.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 28);
            this.button1.TabIndex = 14;
            this.button1.Text = "Open Web ports";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 286);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UpdateCheck);
            this.Controls.Add(this.WebInterfaceChk);
            this.Controls.Add(this.WebAPIPortTxt);
            this.Controls.Add(this.WebAPIPortLabel);
            this.Controls.Add(this.WebPortTxt);
            this.Controls.Add(this.WebPortLabel);
            this.Controls.Add(this.NetPortTxt);
            this.Controls.Add(this.NetLabel);
            this.Controls.Add(this.scrlist);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.devlist);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.VideoChk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Settings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox VideoChk;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox devlist;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox scrlist;
        private System.Windows.Forms.Label NetLabel;
        private System.Windows.Forms.TextBox NetPortTxt;
        private System.Windows.Forms.TextBox WebPortTxt;
        private System.Windows.Forms.Label WebPortLabel;
        private System.Windows.Forms.TextBox WebAPIPortTxt;
        private System.Windows.Forms.Label WebAPIPortLabel;
        private System.Windows.Forms.CheckBox WebInterfaceChk;
        private System.Windows.Forms.CheckBox UpdateCheck;
        private System.Windows.Forms.Button button1;
    }
}