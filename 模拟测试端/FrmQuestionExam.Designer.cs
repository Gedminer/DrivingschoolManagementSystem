namespace 驾校
{
    partial class FrmQuestionExam
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.选择题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.填空题ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.提交试卷ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择题ToolStripMenuItem,
            this.填空题ToolStripMenuItem,
            this.提交试卷ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1042, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 选择题ToolStripMenuItem
            // 
            this.选择题ToolStripMenuItem.Name = "选择题ToolStripMenuItem";
            this.选择题ToolStripMenuItem.Size = new System.Drawing.Size(68, 26);
            this.选择题ToolStripMenuItem.Text = "选择题";
            this.选择题ToolStripMenuItem.Click += new System.EventHandler(this.选择题ToolStripMenuItem_Click);
            // 
            // 填空题ToolStripMenuItem
            // 
            this.填空题ToolStripMenuItem.Name = "填空题ToolStripMenuItem";
            this.填空题ToolStripMenuItem.Size = new System.Drawing.Size(68, 26);
            this.填空题ToolStripMenuItem.Text = "填空题";
            this.填空题ToolStripMenuItem.Click += new System.EventHandler(this.填空题ToolStripMenuItem_Click);
            // 
            // 提交试卷ToolStripMenuItem
            // 
            this.提交试卷ToolStripMenuItem.Name = "提交试卷ToolStripMenuItem";
            this.提交试卷ToolStripMenuItem.Size = new System.Drawing.Size(83, 26);
            this.提交试卷ToolStripMenuItem.Text = "提交试卷";
            this.提交试卷ToolStripMenuItem.Click += new System.EventHandler(this.提交试卷ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 523);
            this.panel1.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 527);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1042, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(167, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // FrmQuestionExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 553);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmQuestionExam";
            this.Text = "FrmQuestionExam";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmQuestionExam_FormClosing);
            this.Load += new System.EventHandler(this.FrmQuestionExam_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选择题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 填空题ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 提交试卷ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}