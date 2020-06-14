namespace furMix
{
    partial class AddInput
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Video = new System.Windows.Forms.TabPage();
            this.LastList = new System.Windows.Forms.ListBox();
            this.BrowBtn = new System.Windows.Forms.Button();
            this.filepathTxt = new System.Windows.Forms.TextBox();
            this.Photo = new System.Windows.Forms.TabPage();
            this.LastList1 = new System.Windows.Forms.ListBox();
            this.BrowBtn1 = new System.Windows.Forms.Button();
            this.filepathTxt1 = new System.Windows.Forms.TextBox();
            this.Color = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ColorBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OKbtn = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.FileVideo = new System.Windows.Forms.OpenFileDialog();
            this.FilePhoto = new System.Windows.Forms.OpenFileDialog();
            this.ClearBtn1 = new System.Windows.Forms.Button();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Video.SuspendLayout();
            this.Photo.SuspendLayout();
            this.Color.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Video);
            this.tabControl1.Controls.Add(this.Photo);
            this.tabControl1.Controls.Add(this.Color);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(453, 236);
            this.tabControl1.TabIndex = 0;
            // 
            // Video
            // 
            this.Video.Controls.Add(this.ClearBtn);
            this.Video.Controls.Add(this.LastList);
            this.Video.Controls.Add(this.BrowBtn);
            this.Video.Controls.Add(this.filepathTxt);
            this.Video.Location = new System.Drawing.Point(4, 22);
            this.Video.Name = "Video";
            this.Video.Padding = new System.Windows.Forms.Padding(3);
            this.Video.Size = new System.Drawing.Size(445, 210);
            this.Video.TabIndex = 0;
            this.Video.Text = "Video";
            this.Video.UseVisualStyleBackColor = true;
            // 
            // LastList
            // 
            this.LastList.FormattingEnabled = true;
            this.LastList.Location = new System.Drawing.Point(6, 32);
            this.LastList.Name = "LastList";
            this.LastList.Size = new System.Drawing.Size(433, 147);
            this.LastList.TabIndex = 2;
            this.LastList.SelectedIndexChanged += new System.EventHandler(this.LastList_SelectedIndexChanged);
            // 
            // BrowBtn
            // 
            this.BrowBtn.Location = new System.Drawing.Point(364, 4);
            this.BrowBtn.Name = "BrowBtn";
            this.BrowBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowBtn.TabIndex = 1;
            this.BrowBtn.Text = "Browse...";
            this.BrowBtn.UseVisualStyleBackColor = true;
            this.BrowBtn.Click += new System.EventHandler(this.BrowBtn_Click);
            // 
            // filepathTxt
            // 
            this.filepathTxt.Location = new System.Drawing.Point(6, 6);
            this.filepathTxt.Name = "filepathTxt";
            this.filepathTxt.Size = new System.Drawing.Size(352, 20);
            this.filepathTxt.TabIndex = 0;
            // 
            // Photo
            // 
            this.Photo.Controls.Add(this.ClearBtn1);
            this.Photo.Controls.Add(this.LastList1);
            this.Photo.Controls.Add(this.BrowBtn1);
            this.Photo.Controls.Add(this.filepathTxt1);
            this.Photo.Location = new System.Drawing.Point(4, 22);
            this.Photo.Name = "Photo";
            this.Photo.Padding = new System.Windows.Forms.Padding(3);
            this.Photo.Size = new System.Drawing.Size(445, 210);
            this.Photo.TabIndex = 1;
            this.Photo.Text = "Photo";
            this.Photo.UseVisualStyleBackColor = true;
            // 
            // LastList1
            // 
            this.LastList1.FormattingEnabled = true;
            this.LastList1.Location = new System.Drawing.Point(6, 33);
            this.LastList1.Name = "LastList1";
            this.LastList1.Size = new System.Drawing.Size(433, 147);
            this.LastList1.TabIndex = 5;
            this.LastList1.SelectedIndexChanged += new System.EventHandler(this.LastList1_SelectedIndexChanged);
            // 
            // BrowBtn1
            // 
            this.BrowBtn1.Location = new System.Drawing.Point(364, 5);
            this.BrowBtn1.Name = "BrowBtn1";
            this.BrowBtn1.Size = new System.Drawing.Size(75, 23);
            this.BrowBtn1.TabIndex = 4;
            this.BrowBtn1.Text = "Browse...";
            this.BrowBtn1.UseVisualStyleBackColor = true;
            this.BrowBtn1.Click += new System.EventHandler(this.BrowBtn1_Click);
            // 
            // filepathTxt1
            // 
            this.filepathTxt1.Location = new System.Drawing.Point(6, 7);
            this.filepathTxt1.Name = "filepathTxt1";
            this.filepathTxt1.Size = new System.Drawing.Size(352, 20);
            this.filepathTxt1.TabIndex = 3;
            // 
            // Color
            // 
            this.Color.Controls.Add(this.pictureBox1);
            this.Color.Controls.Add(this.ColorBtn);
            this.Color.Controls.Add(this.label1);
            this.Color.Location = new System.Drawing.Point(4, 22);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(445, 210);
            this.Color.TabIndex = 2;
            this.Color.Text = "Color";
            this.Color.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(75, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 35);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // ColorBtn
            // 
            this.ColorBtn.Image = global::furMix.Properties.Resources.ColorBtn;
            this.ColorBtn.Location = new System.Drawing.Point(122, 5);
            this.ColorBtn.Name = "ColorBtn";
            this.ColorBtn.Size = new System.Drawing.Size(44, 41);
            this.ColorBtn.TabIndex = 1;
            this.ColorBtn.UseVisualStyleBackColor = true;
            this.ColorBtn.Click += new System.EventHandler(this.ColorBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select color:";
            // 
            // OKbtn
            // 
            this.OKbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.OKbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKbtn.ForeColor = System.Drawing.Color.White;
            this.OKbtn.Location = new System.Drawing.Point(391, 254);
            this.OKbtn.Name = "OKbtn";
            this.OKbtn.Size = new System.Drawing.Size(75, 31);
            this.OKbtn.TabIndex = 1;
            this.OKbtn.Text = "OK";
            this.OKbtn.UseVisualStyleBackColor = false;
            this.OKbtn.Click += new System.EventHandler(this.OKbtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.ForeColor = System.Drawing.Color.White;
            this.CancelBtn.Location = new System.Drawing.Point(307, 254);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(78, 31);
            this.CancelBtn.TabIndex = 2;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // FileVideo
            // 
            this.FileVideo.Filter = "Video files|*.avi;*.mp4";
            // 
            // FilePhoto
            // 
            this.FilePhoto.Filter = "Photo|*.jpg;*.png;*.bmp";
            // 
            // ClearBtn1
            // 
            this.ClearBtn1.Location = new System.Drawing.Point(364, 184);
            this.ClearBtn1.Name = "ClearBtn1";
            this.ClearBtn1.Size = new System.Drawing.Size(75, 23);
            this.ClearBtn1.TabIndex = 6;
            this.ClearBtn1.Text = "Clear";
            this.ClearBtn1.UseVisualStyleBackColor = true;
            this.ClearBtn1.Click += new System.EventHandler(this.ClearBtn1_Click);
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(364, 184);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearBtn.TabIndex = 3;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // AddInput
            // 
            this.AcceptButton = this.OKbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(472, 290);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.OKbtn);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddInput";
            this.Text = "Add Input";
            this.tabControl1.ResumeLayout(false);
            this.Video.ResumeLayout(false);
            this.Video.PerformLayout();
            this.Photo.ResumeLayout(false);
            this.Photo.PerformLayout();
            this.Color.ResumeLayout(false);
            this.Color.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Video;
        private System.Windows.Forms.TabPage Photo;
        private System.Windows.Forms.Button OKbtn;
        private System.Windows.Forms.ListBox LastList;
        private System.Windows.Forms.Button BrowBtn;
        private System.Windows.Forms.TextBox filepathTxt;
        private System.Windows.Forms.ListBox LastList1;
        private System.Windows.Forms.Button BrowBtn1;
        private System.Windows.Forms.TextBox filepathTxt1;
        private System.Windows.Forms.TabPage Color;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ColorBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.OpenFileDialog FileVideo;
        private System.Windows.Forms.OpenFileDialog FilePhoto;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Button ClearBtn1;
    }
}