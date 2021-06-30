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
    public partial class FrmTeaGrade : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        private SqlConnection con;
        private SqlCommand cmd;
        private DataTable dt;
        public FrmTeaGrade()
        {
            InitializeComponent();
        }

        private void FrmTeaGrade_Load(object sender, EventArgs e)
        {
            showGrade();
        }

        private void showGrade()
        {
            try
            {
                string strSelect = "select c.name 班级,s.name 姓名,q.name 试卷名称,qs.score 分数 from question_student qs,question q,student s,class c where qs.questionId=q.id and qs.studentId=s.id and s.classId=c.id;";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(strSelect, con);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                this.dataGridView1.DataSource = dt.DefaultView;
            }
            finally
            {
                dt.Clone();
                con.Close();
            }
        }
    }
}
