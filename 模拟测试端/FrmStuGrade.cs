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
    public partial class FrmStuGrade : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public string stuId;
        private SqlConnection con;
        private SqlCommand cmd;
        private DataTable dt;

        public FrmStuGrade()
        {
            InitializeComponent();
        }

        private void FrmStuGrade_Load(object sender, EventArgs e)
        {
            showGrade();
        }

        private void showGrade()
        {
            try
            {
                string strSelect = "select qs.score 分数,q.name 试卷名称 from question_student qs,question q where qs.questionId=q.id and qs.studentId=@studentId;";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(strSelect, con);
                cmd.Parameters.AddWithValue("@studentId", stuId);
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
