namespace 驾校
{
    partial class FrmTeacher
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.教师信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.班级管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.班级信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.学生信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.课程管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建新课程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.任职课程管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.试卷管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.题目信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单项选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.填空题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.试卷信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.查看成绩ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.班级管理ToolStripMenuItem,
            this.课程管理ToolStripMenuItem,
            this.试卷管理ToolStripMenuItem,
            this.查看成绩ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1042, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.教师信息ToolStripMenuItem,
            this.toolStripSeparator1,
            this.退出ToolStripMenuItem});
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.开始ToolStripMenuItem.Text = "开始";
            // 
            // 教师信息ToolStripMenuItem
            // 
            this.教师信息ToolStripMenuItem.Name = "教师信息ToolStripMenuItem";
            this.教师信息ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.教师信息ToolStripMenuItem.Text = "教师信息";
            this.教师信息ToolStripMenuItem.Click += new System.EventHandler(this.教师信息ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 班级管理ToolStripMenuItem
            // 
            this.班级管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.班级信息管理ToolStripMenuItem,
            this.toolStripSeparator2,
            this.学生信息管理ToolStripMenuItem});
            this.班级管理ToolStripMenuItem.Name = "班级管理ToolStripMenuItem";
            this.班级管理ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.班级管理ToolStripMenuItem.Text = "班级管理";
            // 
            // 班级信息管理ToolStripMenuItem
            // 
            this.班级信息管理ToolStripMenuItem.Name = "班级信息管理ToolStripMenuItem";
            this.班级信息管理ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.班级信息管理ToolStripMenuItem.Text = "班级信息管理";
            this.班级信息管理ToolStripMenuItem.Click += new System.EventHandler(this.班级信息管理ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
            // 
            // 学生信息管理ToolStripMenuItem
            // 
            this.学生信息管理ToolStripMenuItem.Name = "学生信息管理ToolStripMenuItem";
            this.学生信息管理ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.学生信息管理ToolStripMenuItem.Text = "学生信息管理";
            this.学生信息管理ToolStripMenuItem.Click += new System.EventHandler(this.学生信息管理ToolStripMenuItem_Click);
            // 
            // 课程管理ToolStripMenuItem
            // 
            this.课程管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建新课程ToolStripMenuItem,
            this.toolStripSeparator3,
            this.任职课程管理ToolStripMenuItem});
            this.课程管理ToolStripMenuItem.Name = "课程管理ToolStripMenuItem";
            this.课程管理ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.课程管理ToolStripMenuItem.Text = "课程管理";
            // 
            // 创建新课程ToolStripMenuItem
            // 
            this.创建新课程ToolStripMenuItem.Name = "创建新课程ToolStripMenuItem";
            this.创建新课程ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.创建新课程ToolStripMenuItem.Text = "课程信息管理";
            this.创建新课程ToolStripMenuItem.Click += new System.EventHandler(this.创建新课程ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(171, 6);
            // 
            // 任职课程管理ToolStripMenuItem
            // 
            this.任职课程管理ToolStripMenuItem.Name = "任职课程管理ToolStripMenuItem";
            this.任职课程管理ToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.任职课程管理ToolStripMenuItem.Text = "任职课程管理";
            this.任职课程管理ToolStripMenuItem.Click += new System.EventHandler(this.任职课程管理ToolStripMenuItem_Click);
            // 
            // 试卷管理ToolStripMenuItem
            // 
            this.试卷管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.题目信息管理ToolStripMenuItem,
            this.toolStripSeparator4,
            this.试卷信息管理ToolStripMenuItem});
            this.试卷管理ToolStripMenuItem.Name = "试卷管理ToolStripMenuItem";
            this.试卷管理ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.试卷管理ToolStripMenuItem.Text = "试卷管理";
            // 
            // 题目信息管理ToolStripMenuItem
            // 
            this.题目信息管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.单项选择ToolStripMenuItem,
            this.填空题ToolStripMenuItem});
            this.题目信息管理ToolStripMenuItem.Name = "题目信息管理ToolStripMenuItem";
            this.题目信息管理ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.题目信息管理ToolStripMenuItem.Text = "题目信息管理";
            // 
            // 单项选择ToolStripMenuItem
            // 
            this.单项选择ToolStripMenuItem.Name = "单项选择ToolStripMenuItem";
            this.单项选择ToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.单项选择ToolStripMenuItem.Text = "选择题";
            this.单项选择ToolStripMenuItem.Click += new System.EventHandler(this.单项选择ToolStripMenuItem_Click);
            // 
            // 填空题ToolStripMenuItem
            // 
            this.填空题ToolStripMenuItem.Name = "填空题ToolStripMenuItem";
            this.填空题ToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.填空题ToolStripMenuItem.Text = "填空题";
            this.填空题ToolStripMenuItem.Click += new System.EventHandler(this.填空题ToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(178, 6);
            // 
            // 试卷信息管理ToolStripMenuItem
            // 
            this.试卷信息管理ToolStripMenuItem.Name = "试卷信息管理ToolStripMenuItem";
            this.试卷信息管理ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.试卷信息管理ToolStripMenuItem.Text = "试卷信息管理";
            this.试卷信息管理ToolStripMenuItem.Click += new System.EventHandler(this.试卷信息管理ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 500);
            this.panel1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 528);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1042, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(167, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // 查看成绩ToolStripMenuItem
            // 
            this.查看成绩ToolStripMenuItem.Name = "查看成绩ToolStripMenuItem";
            this.查看成绩ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.查看成绩ToolStripMenuItem.Text = "查看成绩";
            this.查看成绩ToolStripMenuItem.Click += new System.EventHandler(this.查看成绩ToolStripMenuItem_Click);
            // 
            // FrmTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 553);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmTeacher";
            this.Text = "教师端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTeacher_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 教师信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 班级管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 课程管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 试卷管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 班级信息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 学生信息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建新课程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 任职课程管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 题目信息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 试卷信息管理ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 单项选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 填空题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看成绩ToolStripMenuItem;
    }
}

