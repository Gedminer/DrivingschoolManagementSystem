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
    public partial class FrmStuStart : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public string stuId;
        public string classId;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;

        public FrmStuStart()
        {
            InitializeComponent();
        }

        private void FrmStuStart_Load(object sender, EventArgs e)
        {
            try
            {
                string strSelect = "select * from student where id=@id";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(strSelect, con);
                cmd.Parameters.AddWithValue("@id", stuId);
                dr = cmd.ExecuteReader();
                dr.Read();
                this.lblName.Text = dr["name"].ToString();
                this.lblNum.Text = dr["num"].ToString();
                classId = dr["classId"].ToString();
            }
            finally
            {
                dr.Close();
                cmd.Clone();
                con.Close();
            }
            try
            {
                string strSelect = "select * from class where id=@id";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(strSelect, con);
                cmd.Parameters.AddWithValue("@id", classId);
                dr = cmd.ExecuteReader();
                dr.Read();
                this.lblClass.Text = dr["name"].ToString();
            }
            finally
            {
                dr.Close();
                cmd.Clone();
                con.Close();
            }
            refreshGridView();
        }

        private void refreshGridView()
        {
            try
            {
                string strSelect = "select q.id 试卷编号,q.name 试卷名称 from class_course_question ccq,question q where ccq.questionId=q.id and ccq.classId=@classId and q.id not in(select qs.questionId from question_student qs where qs.studentId=@studentId)";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(strSelect, con);
                cmd.Parameters.AddWithValue("@classId", classId);
                cmd.Parameters.AddWithValue("@studentId", stuId);
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                this.dataGridView1.DataSource = dt.DefaultView;
            }
            finally
            {
                dr.Close();
                cmd.Clone();
                con.Close();
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;
            string questionId = this.dataGridView1.Rows[index].Cells["试卷编号"].Value.ToString();
            string questionName = this.dataGridView1.Rows[index].Cells["试卷名称"].Value.ToString();
            DialogResult result = MessageBox.Show(this, "确定是否开始：试卷编号 " + questionId + "，试卷名称 " + questionName + "。这场考试吗？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                FrmQuestionExam frmQuestionExam = new FrmQuestionExam();
                frmQuestionExam.questionId = questionId;
                frmQuestionExam.stuId = stuId;
                frmQuestionExam.ShowDialog();
            }
            refreshGridView();
        }
    }
}
