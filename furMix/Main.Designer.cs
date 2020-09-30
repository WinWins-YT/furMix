namespace furMix
{
    partial class Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.cutbtn = new System.Windows.Forms.Button();
            this.fullbtn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.playbtn = new System.Windows.Forms.Button();
            this.infobtn = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.fadebtn = new System.Windows.Forms.Button();
            this.Preview = new AxWMPLib.AxWindowsMediaPlayer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.mutebtn = new System.Windows.Forms.Button();
            this.loopbtn = new System.Windows.Forms.Button();
            this.VerTxt = new System.Windows.Forms.Label();
            this.playbtnprev = new System.Windows.Forms.Button();
            this.timelinePrev = new System.Windows.Forms.TrackBar();
            this.previewTimer = new System.Windows.Forms.Timer(this.components);
            this.PreviewTime = new System.Windows.Forms.Label();
            this.timelineShow = new System.Windows.Forms.TrackBar();
            this.timeShow = new System.Windows.Forms.Label();
            this.showTimer = new System.Windows.Forms.Timer(this.components);
            this.SetBtn = new System.Windows.Forms.Button();
            this.picture = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NetBtn = new System.Windows.Forms.Button();
            this.NetTimer = new System.Windows.Forms.Timer(this.components);
            this.volumeLevel = new furMix.Controls.VolumeLevel();
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timelinePrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timelineShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cutbtn
            // 
            this.cutbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cutbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cutbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cutbtn.ForeColor = System.Drawing.Color.White;
            this.cutbtn.Location = new System.Drawing.Point(580, 96);
            this.cutbtn.Name = "cutbtn";
            this.cutbtn.Size = new System.Drawing.Size(75, 23);
            this.cutbtn.TabIndex = 1;
            this.cutbtn.Text = "Cut";
            this.cutbtn.UseVisualStyleBackColor = false;
            this.cutbtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // fullbtn
            // 
            this.fullbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fullbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.fullbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fullbtn.ForeColor = System.Drawing.Color.White;
            this.fullbtn.Location = new System.Drawing.Point(580, 12);
            this.fullbtn.Name = "fullbtn";
            this.fullbtn.Size = new System.Drawing.Size(75, 23);
            this.fullbtn.TabIndex = 3;
            this.fullbtn.Text = "Fullscreen";
            this.fullbtn.UseVisualStyleBackColor = false;
            this.fullbtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // playbtn
            // 
            this.playbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.playbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.playbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playbtn.ForeColor = System.Drawing.Color.White;
            this.playbtn.Location = new System.Drawing.Point(1031, 274);
            this.playbtn.Name = "playbtn";
            this.playbtn.Size = new System.Drawing.Size(55, 36);
            this.playbtn.TabIndex = 8;
            this.playbtn.Text = "Play";
            this.playbtn.UseVisualStyleBackColor = false;
            this.playbtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // infobtn
            // 
            this.infobtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.infobtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.infobtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infobtn.ForeColor = System.Drawing.Color.White;
            this.infobtn.Location = new System.Drawing.Point(1011, 502);
            this.infobtn.Name = "infobtn";
            this.infobtn.Size = new System.Drawing.Size(75, 31);
            this.infobtn.TabIndex = 10;
            this.infobtn.Text = "Info";
            this.infobtn.UseVisualStyleBackColor = false;
            this.infobtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(12, 502);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 31);
            this.button6.TabIndex = 11;
            this.button6.Text = "Add input";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // fadebtn
            // 
            this.fadebtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.fadebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.fadebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fadebtn.ForeColor = System.Drawing.Color.White;
            this.fadebtn.Location = new System.Drawing.Point(580, 125);
            this.fadebtn.Name = "fadebtn";
            this.fadebtn.Size = new System.Drawing.Size(75, 23);
            this.fadebtn.TabIndex = 12;
            this.fadebtn.Text = "Fade";
            this.fadebtn.UseVisualStyleBackColor = false;
            this.fadebtn.Click += new System.EventHandler(this.button7_Click);
            // 
            // Preview
            // 
            this.Preview.Enabled = true;
            this.Preview.Location = new System.Drawing.Point(12, 12);
            this.Preview.Name = "Preview";
            this.Preview.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Preview.OcxState")));
            this.Preview.Size = new System.Drawing.Size(472, 256);
            this.Preview.TabIndex = 6;
            this.Preview.OpenStateChange += new AxWMPLib._WMPOCXEvents_OpenStateChangeEventHandler(this.Preview_OpenStateChange);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 335);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1074, 157);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // mutebtn
            // 
            this.mutebtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mutebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.mutebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mutebtn.ForeColor = System.Drawing.Color.White;
            this.mutebtn.Location = new System.Drawing.Point(721, 274);
            this.mutebtn.Name = "mutebtn";
            this.mutebtn.Size = new System.Drawing.Size(54, 36);
            this.mutebtn.TabIndex = 14;
            this.mutebtn.Text = "Mute";
            this.mutebtn.UseVisualStyleBackColor = false;
            this.mutebtn.Click += new System.EventHandler(this.button8_Click);
            // 
            // loopbtn
            // 
            this.loopbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loopbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.loopbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loopbtn.ForeColor = System.Drawing.Color.White;
            this.loopbtn.Location = new System.Drawing.Point(661, 274);
            this.loopbtn.Name = "loopbtn";
            this.loopbtn.Size = new System.Drawing.Size(51, 36);
            this.loopbtn.TabIndex = 15;
            this.loopbtn.Text = "Loop";
            this.loopbtn.UseVisualStyleBackColor = false;
            this.loopbtn.Click += new System.EventHandler(this.loopbtn_Click);
            // 
            // VerTxt
            // 
            this.VerTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.VerTxt.BackColor = System.Drawing.Color.Transparent;
            this.VerTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerTxt.ForeColor = System.Drawing.Color.White;
            this.VerTxt.Location = new System.Drawing.Point(681, 505);
            this.VerTxt.Name = "VerTxt";
            this.VerTxt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.VerTxt.Size = new System.Drawing.Size(243, 26);
            this.VerTxt.TabIndex = 17;
            this.VerTxt.Text = "furMix 2020. Build 0.4.630. Beta 1.\r\nFor testing purposes only.";
            this.VerTxt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // playbtnprev
            // 
            this.playbtnprev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.playbtnprev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playbtnprev.ForeColor = System.Drawing.Color.White;
            this.playbtnprev.Location = new System.Drawing.Point(12, 274);
            this.playbtnprev.Name = "playbtnprev";
            this.playbtnprev.Size = new System.Drawing.Size(55, 36);
            this.playbtnprev.TabIndex = 19;
            this.playbtnprev.Text = "Play";
            this.playbtnprev.UseVisualStyleBackColor = false;
            this.playbtnprev.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // timelinePrev
            // 
            this.timelinePrev.Location = new System.Drawing.Point(74, 275);
            this.timelinePrev.Name = "timelinePrev";
            this.timelinePrev.Size = new System.Drawing.Size(323, 45);
            this.timelinePrev.TabIndex = 20;
            this.timelinePrev.TickStyle = System.Windows.Forms.TickStyle.None;
            this.timelinePrev.MouseDown += new System.Windows.Forms.MouseEventHandler(this.timelinePrev_MouseDown);
            this.timelinePrev.MouseUp += new System.Windows.Forms.MouseEventHandler(this.timelinePrev_MouseUp);
            // 
            // previewTimer
            // 
            this.previewTimer.Tick += new System.EventHandler(this.previewTimer_Tick);
            // 
            // PreviewTime
            // 
            this.PreviewTime.AutoSize = true;
            this.PreviewTime.ForeColor = System.Drawing.Color.White;
            this.PreviewTime.Location = new System.Drawing.Point(404, 275);
            this.PreviewTime.Name = "PreviewTime";
            this.PreviewTime.Size = new System.Drawing.Size(0, 13);
            this.PreviewTime.TabIndex = 21;
            // 
            // timelineShow
            // 
            this.timelineShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timelineShow.Location = new System.Drawing.Point(780, 274);
            this.timelineShow.Name = "timelineShow";
            this.timelineShow.Size = new System.Drawing.Size(167, 45);
            this.timelineShow.TabIndex = 22;
            this.timelineShow.TickStyle = System.Windows.Forms.TickStyle.None;
            this.timelineShow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.timelineShow_MouseDown);
            this.timelineShow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.timelineShow_MouseUp);
            // 
            // timeShow
            // 
            this.timeShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeShow.AutoSize = true;
            this.timeShow.ForeColor = System.Drawing.Color.White;
            this.timeShow.Location = new System.Drawing.Point(953, 286);
            this.timeShow.Name = "timeShow";
            this.timeShow.Size = new System.Drawing.Size(0, 13);
            this.timeShow.TabIndex = 23;
            // 
            // showTimer
            // 
            this.showTimer.Tick += new System.EventHandler(this.showTimer_Tick);
            // 
            // SetBtn
            // 
            this.SetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.SetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetBtn.ForeColor = System.Drawing.Color.White;
            this.SetBtn.Location = new System.Drawing.Point(930, 502);
            this.SetBtn.Name = "SetBtn";
            this.SetBtn.Size = new System.Drawing.Size(75, 31);
            this.SetBtn.TabIndex = 24;
            this.SetBtn.Text = "Settings";
            this.SetBtn.UseVisualStyleBackColor = false;
            this.SetBtn.Click += new System.EventHandler(this.SetBtn_Click);
            // 
            // picture
            // 
            this.picture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picture.BackColor = System.Drawing.Color.Black;
            this.picture.Location = new System.Drawing.Point(661, 12);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(425, 256);
            this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture.TabIndex = 5;
            this.picture.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(472, 256);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // NetBtn
            // 
            this.NetBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.NetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NetBtn.ForeColor = System.Drawing.Color.White;
            this.NetBtn.Location = new System.Drawing.Point(580, 41);
            this.NetBtn.Name = "NetBtn";
            this.NetBtn.Size = new System.Drawing.Size(75, 23);
            this.NetBtn.TabIndex = 25;
            this.NetBtn.Text = "Network";
            this.NetBtn.UseVisualStyleBackColor = false;
            this.NetBtn.Click += new System.EventHandler(this.NetBtn_Click);
            // 
            // NetTimer
            // 
            this.NetTimer.Interval = 30;
            this.NetTimer.Tick += new System.EventHandler(this.NetTimer_Tick);
            // 
            // volumeLevel
            // 
            this.volumeLevel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.volumeLevel.BackColor = System.Drawing.Color.Transparent;
            this.volumeLevel.LeftCh = 0;
            this.volumeLevel.Location = new System.Drawing.Point(489, 12);
            this.volumeLevel.Name = "volumeLevel";
            this.volumeLevel.RightCh = 0;
            this.volumeLevel.Size = new System.Drawing.Size(85, 317);
            this.volumeLevel.TabIndex = 26;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1098, 545);
            this.Controls.Add(this.volumeLevel);
            this.Controls.Add(this.SetBtn);
            this.Controls.Add(this.timeShow);
            this.Controls.Add(this.timelineShow);
            this.Controls.Add(this.PreviewTime);
            this.Controls.Add(this.timelinePrev);
            this.Controls.Add(this.playbtnprev);
            this.Controls.Add(this.VerTxt);
            this.Controls.Add(this.loopbtn);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.fadebtn);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.infobtn);
            this.Controls.Add(this.playbtn);
            this.Controls.Add(this.Preview);
            this.Controls.Add(this.fullbtn);
            this.Controls.Add(this.cutbtn);
            this.Controls.Add(this.mutebtn);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1114, 584);
            this.Name = "Main";
            this.Text = "furMix";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timelinePrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timelineShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cutbtn;
        private System.Windows.Forms.Button fullbtn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picture;
        private AxWMPLib.AxWindowsMediaPlayer Preview;
        private System.Windows.Forms.Button playbtn;
        private System.Windows.Forms.Button infobtn;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button fadebtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button mutebtn;
        private System.Windows.Forms.Button loopbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label VerTxt;
        private System.Windows.Forms.Button playbtnprev;
        private System.Windows.Forms.TrackBar timelinePrev;
        private System.Windows.Forms.Timer previewTimer;
        private System.Windows.Forms.Label PreviewTime;
        private System.Windows.Forms.TrackBar timelineShow;
        private System.Windows.Forms.Label timeShow;
        private System.Windows.Forms.Timer showTimer;
        private System.Windows.Forms.Button SetBtn;
        private System.Windows.Forms.Button NetBtn;
        private System.Windows.Forms.Timer NetTimer;
        private Controls.VolumeLevel volumeLevel;
    }
}

