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
    public partial class FrmTeacherInfo : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        private string strSelect = "select * from teacher where id=@id";
        public string teaId;
        public FrmTeacherInfo()
        {
            InitializeComponent();
        }

        private void FrmTeacherInfo_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand selectCmd = new SqlCommand(strSelect, con);
            selectCmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = teaId;
            SqlDataReader dr = selectCmd.ExecuteReader();
            dr.Read();
            this.lblName.Text = dr["name"].ToString();
            this.lblNum.Text = dr["num"].ToString();
            dr.Close();
            selectCmd.Clone();
            strSelect = "select course.name from course,course_teacher where course.id=course_teacher.courseId and course_teacher.teacherId=@teacharId";
            selectCmd.CommandText = strSelect;
            selectCmd.Parameters.Add("@teacharId", System.Data.SqlDbType.Int).Value = teaId;
            dr = selectCmd.ExecuteReader();
            if (dr.Read())
            {
                this.lblCourse.Text = dr["name"].ToString() + "\n";
            }
            while (dr.Read())
            {
                this.lblCourse.Text += dr["name"].ToString() + "\n";
            }
            dr.Close();
            selectCmd.Clone();
            con.Close();
        }
    }
}
