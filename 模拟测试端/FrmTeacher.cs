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
    public partial class FrmTeacher : Form
    {
        public string teaId;

        public FrmTeacher()
        {
            InitializeComponent();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 教师信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTeacherInfo frmTeacherInfo = new FrmTeacherInfo();
            frmTeacherInfo.teaId = this.teaId;
            frmTeacherInfo.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frmTeacherInfo);
            frmTeacherInfo.Show();
        }

        private void 班级信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClass frmClass = new FrmClass();
            frmClass.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frmClass);
            frmClass.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "当前时间为：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void 学生信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStudentInfo frmStudentInfo = new FrmStudentInfo();
            frmStudentInfo.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frmStudentInfo);
            frmStudentInfo.Show();
        }

        private void 创建新课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCourse frmCourse = new FrmCourse();
            frmCourse.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frmCourse);
            frmCourse.Show();
        }

        private void 任职课程管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddCourseForTea frmAddCourseForTea = new FrmAddCourseForTea();
            frmAddCourseForTea.teaId = this.teaId;
            frmAddCourseForTea.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frmAddCourseForTea);
            frmAddCourseForTea.Show();
        }

        private void FrmTeacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            退出ToolStripMenuItem_Click(sender, e);
        }

        private void 单项选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSigleChoice frmSigleChoice = new FrmSigleChoice();
            frmSigleChoice.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frmSigleChoice);
            frmSigleChoice.Show();
        }

        private void 填空题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompletion frmCompletion = new FrmCompletion();
            frmCompletion.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frmCompletion);
            frmCompletion.Show();
        }

        private void 试卷信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQuestion frmQuestion = new FrmQuestion();
            frmQuestion.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frmQuestion);
            frmQuestion.Show();
        }

        private void 查看成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTeaGrade frmTeaGrade = new FrmTeaGrade();
            frmTeaGrade.TopLevel = false;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frmTeaGrade);
            frmTeaGrade.Show();
        }
    }
}
