using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 驾校
{
    public partial class FrmQuestion : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        SqlDataReader dr;

        public FrmQuestion()
        {
            InitializeComponent();
        }

        private void FrmQuestion_Load(object sender, EventArgs e)
        {
            selectQuestion();
            selectCourse();
            selectClass();
        }

        private void selectQuestion()
        {
            try
            {
                string selectSigleChoice = "select q.id 编号,q.name 试卷名称,cou.name 所属课程,cla.name 班级名称 from question q,class_course_question ccq,course cou,class cla where q.id=ccq.questionId and cou.id=ccq.courseId and cla.id=ccq.classId;";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(selectSigleChoice, con);
                dt = new DataTable();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                this.dataGridView1.DataSource = dt.DefaultView;
            }
            finally
            {
                dt.Clone();
                dr.Close();
                cmd.Clone();
                con.Close();
            }
        }

        private void selectCourse()
        {
            try
            {
                string selectCourse = "select * from course;";
                cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = selectCourse;
                dt = new DataTable();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                this.cboCourse.DisplayMember = "name";
                this.cboCourse.ValueMember = "id";
                this.cboCourse.DataSource = dt;
            }
            finally
            {
                dt.Clone();
                dr.Close();
                cmd.Clone();
                con.Close();
            }
        }

        private void selectClass()
        {
            try
            {
                string selectCourse = "select * from class;";
                cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = selectCourse;
                dt = new DataTable();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                this.cboClass.DisplayMember = "name";
                this.cboClass.ValueMember = "id";
                this.cboClass.DataSource = dt;
            }
            finally
            {
                dt.Clone();
                dr.Close();
                cmd.Clone();
                con.Close();
            }
        }

        private void fillCourse()
        {
            int index = this.dataGridView1.CurrentRow.Index;
            this.txtName.Text = this.dataGridView1.Rows[index].Cells["试卷名称"].Value.ToString();
            this.cboCourse.Text = this.dataGridView1.Rows[index].Cells["所属课程"].Value.ToString();
            this.cboClass.Text = this.dataGridView1.Rows[index].Cells["班级名称"].Value.ToString();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            fillCourse();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)this.cboCourse.SelectedItem;
            string strCourseId = drv.Row["id"].ToString();
            drv = (DataRowView)this.cboClass.SelectedItem;
            string strClassId = drv.Row["id"].ToString();
            if (this.txtName.Text == "")
            {
                MessageBox.Show("添加信息不完整！");
                return;
            }
            try
            {
                string strInsertQ = "insert into question(name) values(@name);SELECT @@Identity;";
                string strInsertCCQ = "insert into class_course_question(classId,courseId,questionId) values(@classId,@courseId,@questionId)";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(strInsertQ, con);
                cmd.Parameters.AddWithValue("@name", this.txtName.Text.Trim().ToString());
                string questionId = cmd.ExecuteScalar().ToString();
                cmd.CommandText = strInsertCCQ;
                cmd.Parameters.AddWithValue("@classId", strClassId);
                cmd.Parameters.AddWithValue("@courseId", strCourseId);
                cmd.Parameters.AddWithValue("@questionId", questionId);
                cmd.ExecuteNonQuery();
                FrmQuestionItems frmQuestionItems = new FrmQuestionItems();
                frmQuestionItems.courseId = strCourseId;
                frmQuestionItems.questionId = questionId;
                frmQuestionItems.ShowDialog();
                if (frmQuestionItems.DialogResult==DialogResult.OK)
                {
                    selectQuestion();
                }
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;
            string questionId = this.dataGridView1.Rows[index].Cells["编号"].Value.ToString();
            DataRowView drv = (DataRowView)this.cboCourse.SelectedItem;
            string courseId = drv.Row["id"].ToString();
            FrmQuestionItems frmQuestionItems = new FrmQuestionItems();
            frmQuestionItems.courseId = courseId;
            frmQuestionItems.questionId = questionId;
            frmQuestionItems.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;
            string questionId = this.dataGridView1.Rows[index].Cells["编号"].Value.ToString();
            try
            {
                string strDelQuestion = "delete from question where id=@questionId;";
                cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = strDelQuestion;
                cmd.Parameters.AddWithValue("@questionId", questionId);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }
            selectQuestion();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
