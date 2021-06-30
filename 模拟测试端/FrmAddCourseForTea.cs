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
    public partial class FrmAddCourseForTea : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public string teaId;
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        SqlDataReader dr;

        public FrmAddCourseForTea()
        {
            InitializeComponent();
        }

        private void FrmAddCourseForTea_Load(object sender, EventArgs e)
        {
            canAddCourse();
            alreadyAddCourse();
        }

        private void canAddCourse()
        {
            try
            {
                string strSelect = "select c.id 课程号,c.name 课程名 from course_teacher ct right join course c on ct.teacherId=@teacharId and ct.courseId=c.id where ct.courseId is null";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(strSelect, con);
                cmd.Parameters.AddWithValue("@teacharId", teaId);
                dr = cmd.ExecuteReader();
                dt = new DataTable();
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

        private void alreadyAddCourse()
        {
            try
            {
                string strSelect = "select c.id 课程号,c.name 课程名 from course_teacher ct right join course c on ct.teacherId=@teacharId and ct.courseId=c.id where ct.courseId is not null";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(strSelect, con);
                cmd.Parameters.AddWithValue("@teacharId", teaId);
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                this.dataGridView2.DataSource = dt.DefaultView;
            }
            finally
            {
                dt.Clone();
                dr.Close();
                cmd.Clone();
                con.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;
            string courseId = this.dataGridView1.Rows[index].Cells["课程号"].Value.ToString();
            try
            {
                string strInsert = "insert into course_teacher(teacherId,courseId) values(@teacherId,@courseId)";
                cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = strInsert;
                cmd.Parameters.AddWithValue("@teacherId", teaId);
                cmd.Parameters.AddWithValue("@courseId", courseId);
                cmd.ExecuteNonQuery();
                FrmAddCourseForTea_Load(sender, e);
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView2.CurrentRow.Index;
            string courseId = this.dataGridView2.Rows[index].Cells["课程号"].Value.ToString();
            try
            {
                string strInsert = "delete from course_teacher where courseId=@courseId and teacherId=@teacherId";
                cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = strInsert;
                cmd.Parameters.AddWithValue("@courseId", courseId);
                cmd.Parameters.AddWithValue("@teacherId", teaId);
                cmd.ExecuteNonQuery();
                FrmAddCourseForTea_Load(sender, e);
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
