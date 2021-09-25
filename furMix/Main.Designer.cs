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
            this.ContentListContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteContext = new System.Windows.Forms.ToolStripMenuItem();
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
            this.NetBtn = new System.Windows.Forms.Button();
            this.NetTimer = new System.Windows.Forms.Timer(this.components);
            this.TipBack = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TipTitle = new System.Windows.Forms.Label();
            this.TipText = new System.Windows.Forms.Label();
            this.FileContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NetworkBtn = new System.Windows.Forms.Button();
            this.ClientNum = new System.Windows.Forms.Label();
            this.LivePic = new System.Windows.Forms.PictureBox();
            this.EnableBtn = new System.Windows.Forms.Button();
            this.recBtn = new System.Windows.Forms.Button();
            this.recTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new furMix.Controls.MenuButton();
            this.volumeLevel = new furMix.Controls.VolumeLevel();
            this.recTimeTxt = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).BeginInit();
            this.ContentListContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timelinePrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timelineShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.FileContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LivePic)).BeginInit();
            this.SuspendLayout();
            // 
            // cutbtn
            // 
            resources.ApplyResources(this.cutbtn, "cutbtn");
            this.cutbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cutbtn.ForeColor = System.Drawing.Color.White;
            this.cutbtn.Name = "cutbtn";
            this.cutbtn.UseVisualStyleBackColor = false;
            this.cutbtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // fullbtn
            // 
            resources.ApplyResources(this.fullbtn, "fullbtn");
            this.fullbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.fullbtn.ForeColor = System.Drawing.Color.White;
            this.fullbtn.Name = "fullbtn";
            this.fullbtn.UseVisualStyleBackColor = false;
            this.fullbtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // playbtn
            // 
            resources.ApplyResources(this.playbtn, "playbtn");
            this.playbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.playbtn.ForeColor = System.Drawing.Color.White;
            this.playbtn.Name = "playbtn";
            this.playbtn.UseVisualStyleBackColor = false;
            this.playbtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // infobtn
            // 
            resources.ApplyResources(this.infobtn, "infobtn");
            this.infobtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.infobtn.ForeColor = System.Drawing.Color.White;
            this.infobtn.Name = "infobtn";
            this.infobtn.UseVisualStyleBackColor = false;
            this.infobtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // fadebtn
            // 
            resources.ApplyResources(this.fadebtn, "fadebtn");
            this.fadebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.fadebtn.ForeColor = System.Drawing.Color.White;
            this.fadebtn.Name = "fadebtn";
            this.fadebtn.UseVisualStyleBackColor = false;
            this.fadebtn.Click += new System.EventHandler(this.button7_Click);
            // 
            // Preview
            // 
            resources.ApplyResources(this.Preview, "Preview");
            this.Preview.Name = "Preview";
            this.Preview.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Preview.OcxState")));
            this.Preview.OpenStateChange += new AxWMPLib._WMPOCXEvents_OpenStateChangeEventHandler(this.Preview_OpenStateChange);
            // 
            // listView1
            // 
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.listView1.ContextMenuStrip = this.ContentListContext;
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.HideSelection = false;
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // ContentListContext
            // 
            this.ContentListContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteContext});
            this.ContentListContext.Name = "ContentListContext";
            resources.ApplyResources(this.ContentListContext, "ContentListContext");
            this.ContentListContext.Opening += new System.ComponentModel.CancelEventHandler(this.ContentListContext_Opening);
            // 
            // DeleteContext
            // 
            this.DeleteContext.Name = "DeleteContext";
            resources.ApplyResources(this.DeleteContext, "DeleteContext");
            this.DeleteContext.Click += new System.EventHandler(this.DeleteContext_Click);
            // 
            // mutebtn
            // 
            resources.ApplyResources(this.mutebtn, "mutebtn");
            this.mutebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.mutebtn.ForeColor = System.Drawing.Color.White;
            this.mutebtn.Name = "mutebtn";
            this.mutebtn.UseVisualStyleBackColor = false;
            this.mutebtn.Click += new System.EventHandler(this.button8_Click);
            // 
            // loopbtn
            // 
            resources.ApplyResources(this.loopbtn, "loopbtn");
            this.loopbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.loopbtn.ForeColor = System.Drawing.Color.White;
            this.loopbtn.Name = "loopbtn";
            this.loopbtn.UseVisualStyleBackColor = false;
            this.loopbtn.Click += new System.EventHandler(this.loopbtn_Click);
            // 
            // VerTxt
            // 
            resources.ApplyResources(this.VerTxt, "VerTxt");
            this.VerTxt.BackColor = System.Drawing.Color.Transparent;
            this.VerTxt.ForeColor = System.Drawing.Color.White;
            this.VerTxt.Name = "VerTxt";
            // 
            // playbtnprev
            // 
            this.playbtnprev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            resources.ApplyResources(this.playbtnprev, "playbtnprev");
            this.playbtnprev.ForeColor = System.Drawing.Color.White;
            this.playbtnprev.Name = "playbtnprev";
            this.playbtnprev.UseVisualStyleBackColor = false;
            this.playbtnprev.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // timelinePrev
            // 
            resources.ApplyResources(this.timelinePrev, "timelinePrev");
            this.timelinePrev.Name = "timelinePrev";
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
            resources.ApplyResources(this.PreviewTime, "PreviewTime");
            this.PreviewTime.ForeColor = System.Drawing.Color.White;
            this.PreviewTime.Name = "PreviewTime";
            // 
            // timelineShow
            // 
            resources.ApplyResources(this.timelineShow, "timelineShow");
            this.timelineShow.Name = "timelineShow";
            this.timelineShow.TickStyle = System.Windows.Forms.TickStyle.None;
            this.timelineShow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.timelineShow_MouseDown);
            this.timelineShow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.timelineShow_MouseUp);
            // 
            // timeShow
            // 
            resources.ApplyResources(this.timeShow, "timeShow");
            this.timeShow.ForeColor = System.Drawing.Color.White;
            this.timeShow.Name = "timeShow";
            // 
            // showTimer
            // 
            this.showTimer.Tick += new System.EventHandler(this.showTimer_Tick);
            // 
            // SetBtn
            // 
            resources.ApplyResources(this.SetBtn, "SetBtn");
            this.SetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.SetBtn.ForeColor = System.Drawing.Color.White;
            this.SetBtn.Name = "SetBtn";
            this.SetBtn.UseVisualStyleBackColor = false;
            this.SetBtn.Click += new System.EventHandler(this.SetBtn_Click);
            // 
            // NetBtn
            // 
            resources.ApplyResources(this.NetBtn, "NetBtn");
            this.NetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.NetBtn.ForeColor = System.Drawing.Color.White;
            this.NetBtn.Name = "NetBtn";
            this.NetBtn.UseVisualStyleBackColor = false;
            this.NetBtn.Click += new System.EventHandler(this.NetBtn_Click);
            // 
            // NetTimer
            // 
            this.NetTimer.Interval = 1000;
            this.NetTimer.Tick += new System.EventHandler(this.NetTimer_Tick);
            // 
            // TipBack
            // 
            this.TipBack.BackColor = System.Drawing.Color.Transparent;
            this.TipBack.Image = global::furMix.Properties.Resources.MessagePopup;
            resources.ApplyResources(this.TipBack, "TipBack");
            this.TipBack.Name = "TipBack";
            this.TipBack.TabStop = false;
            this.TipBack.Click += new System.EventHandler(this.TipBack_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // TipTitle
            // 
            resources.ApplyResources(this.TipTitle, "TipTitle");
            this.TipTitle.BackColor = System.Drawing.Color.White;
            this.TipTitle.Name = "TipTitle";
            this.TipTitle.Click += new System.EventHandler(this.TipTitle_Click);
            // 
            // TipText
            // 
            this.TipText.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.TipText, "TipText");
            this.TipText.Name = "TipText";
            this.TipText.Click += new System.EventHandler(this.TipText_Click);
            // 
            // FileContext
            // 
            this.FileContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.FileContext.Name = "FileContext";
            resources.ApplyResources(this.FileContext, "FileContext");
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // NetworkBtn
            // 
            resources.ApplyResources(this.NetworkBtn, "NetworkBtn");
            this.NetworkBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.NetworkBtn.ForeColor = System.Drawing.Color.White;
            this.NetworkBtn.Name = "NetworkBtn";
            this.NetworkBtn.UseVisualStyleBackColor = false;
            this.NetworkBtn.Click += new System.EventHandler(this.NetworkBtn_Click);
            // 
            // ClientNum
            // 
            resources.ApplyResources(this.ClientNum, "ClientNum");
            this.ClientNum.ForeColor = System.Drawing.Color.White;
            this.ClientNum.Name = "ClientNum";
            // 
            // LivePic
            // 
            resources.ApplyResources(this.LivePic, "LivePic");
            this.LivePic.BackColor = System.Drawing.Color.Black;
            this.LivePic.Name = "LivePic";
            this.LivePic.TabStop = false;
            // 
            // EnableBtn
            // 
            resources.ApplyResources(this.EnableBtn, "EnableBtn");
            this.EnableBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.EnableBtn.ForeColor = System.Drawing.Color.White;
            this.EnableBtn.Name = "EnableBtn";
            this.EnableBtn.UseVisualStyleBackColor = false;
            this.EnableBtn.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // recBtn
            // 
            resources.ApplyResources(this.recBtn, "recBtn");
            this.recBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.recBtn.ForeColor = System.Drawing.Color.White;
            this.recBtn.Name = "recBtn";
            this.recBtn.UseVisualStyleBackColor = false;
            this.recBtn.Click += new System.EventHandler(this.recBtn_Click);
            // 
            // recTimer
            // 
            this.recTimer.Interval = 1000;
            this.recTimer.Tick += new System.EventHandler(this.recTimer_Tick);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Menu = this.FileContext;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // volumeLevel
            // 
            resources.ApplyResources(this.volumeLevel, "volumeLevel");
            this.volumeLevel.BackColor = System.Drawing.Color.Transparent;
            this.volumeLevel.LeftCh = 0;
            this.volumeLevel.Name = "volumeLevel";
            this.volumeLevel.RightCh = 0;
            this.volumeLevel.DoubleClick += new System.EventHandler(this.volumeLevel_DoubleClick);
            // 
            // recTimeTxt
            // 
            resources.ApplyResources(this.recTimeTxt, "recTimeTxt");
            this.recTimeTxt.ForeColor = System.Drawing.Color.White;
            this.recTimeTxt.Name = "recTimeTxt";
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.recTimeTxt);
            this.Controls.Add(this.recBtn);
            this.Controls.Add(this.EnableBtn);
            this.Controls.Add(this.LivePic);
            this.Controls.Add(this.ClientNum);
            this.Controls.Add(this.NetworkBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.volumeLevel);
            this.Controls.Add(this.SetBtn);
            this.Controls.Add(this.timeShow);
            this.Controls.Add(this.timelineShow);
            this.Controls.Add(this.PreviewTime);
            this.Controls.Add(this.timelinePrev);
            this.Controls.Add(this.playbtnprev);
            this.Controls.Add(this.VerTxt);
            this.Controls.Add(this.loopbtn);
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
            this.Name = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Preview)).EndInit();
            this.ContentListContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timelinePrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timelineShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.FileContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LivePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cutbtn;
        private System.Windows.Forms.Button fullbtn;
        private System.Windows.Forms.Timer timer1;
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
        private System.Windows.Forms.PictureBox TipBack;
        private System.Windows.Forms.Label TipTitle;
        private System.Windows.Forms.Label TipText;
        private System.Windows.Forms.ContextMenuStrip ContentListContext;
        private System.Windows.Forms.ToolStripMenuItem DeleteContext;
        private furMix.Controls.MenuButton button1;
        private System.Windows.Forms.ContextMenuStrip FileContext;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Button NetworkBtn;
        private System.Windows.Forms.Label ClientNum;
        private System.Windows.Forms.PictureBox LivePic;
        private System.Windows.Forms.Button EnableBtn;
        private System.Windows.Forms.Button recBtn;
        private System.Windows.Forms.Timer recTimer;
        private System.Windows.Forms.Label recTimeTxt;
    }
}

