using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 驾校
{
    public partial class FrmStudent : Form
    {
        public string stuId;

        public FrmStudent()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "当前时间为：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 首页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStuStart frmStuStart = new FrmStuStart();
            frmStuStart.TopLevel = false;
            frmStuStart.stuId = this.stuId;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frmStuStart);
            frmStuStart.Show();
        }

        private void 历史成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStuGrade frmStuGrade = new FrmStuGrade();
            frmStuGrade.TopLevel = false;
            frmStuGrade.stuId = this.stuId;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frmStuGrade);
            frmStuGrade.Show();
        }

        private void FrmStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
