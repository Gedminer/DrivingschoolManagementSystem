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
    public partial class FrmQuestionItems : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        public string courseId;
        public string classId;
        public string questionName;
        public string questionId;
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        SqlDataReader dr;

        public FrmQuestionItems()
        {
            InitializeComponent();
        }

        private void FrmQuestionItems_Load(object sender, EventArgs e)
        {
            this.cboType.SelectedIndex = 0;
            canAddSigleChoice();
            alreadyAddSigleChoice();
        }

        private void canAddSigleChoice()
        {
            try
            {
                string selectSigleChoice = "select * from sigleChoice where id not in(select qs.sigleChoiceId from question_sigleChoice qs where qs.questionId=@questionId) and sigleChoice.courseId=@courseId;";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(selectSigleChoice, con);
                cmd.Parameters.AddWithValue("@questionId", questionId);
                cmd.Parameters.AddWithValue("@courseId", courseId);
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

        private void canAddCompletion()
        {
            try
            {
                string selectCompletion = "select * from completion where id not in(select qc.completionId from question_completion qc where qc.questionId=@questionId) and completion.courseId=@courseId;";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(selectCompletion, con);
                cmd.Parameters.AddWithValue("@questionId", questionId);
                cmd.Parameters.AddWithValue("@courseId", courseId);
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

        private void alreadyAddSigleChoice()
        {
            try
            {
                string strSelect = "select * from sigleChoice where id in(select qs.sigleChoiceId from question_sigleChoice qs where qs.questionId=@questionId);";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(strSelect, con);
                cmd.Parameters.AddWithValue("@questionId", questionId);
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

        private void alreadyAddCompletion()
        {
            try
            {
                string strSelect = "select * from completion where id in(select qc.completionId from question_completion qc where qc.questionId=@questionId);";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(strSelect, con);
                cmd.Parameters.AddWithValue("@questionId", questionId);
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

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboType.SelectedIndex.Equals(0))
            {
                canAddSigleChoice();
                alreadyAddSigleChoice();
            }
            else
            {
                canAddCompletion();
                alreadyAddCompletion();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;
            string itemId = this.dataGridView1.Rows[index].Cells["id"].Value.ToString();
            //加入题目
            try
            {
                string strInsertSigleChoice = "insert into question_sigleChoice(questionId,sigleChoiceId) values(@questionId,@sigleChoiceId);";
                string strInsertCompletion = "insert into question_completion(questionId,completionId) values(@questionId,@completionId);";
                cmd = con.CreateCommand();
                con.Open();
                if (this.cboType.SelectedIndex.Equals(0))
                {
                    cmd.CommandText = strInsertSigleChoice;
                    cmd.Parameters.AddWithValue("@sigleChoiceId", itemId);
                }
                else
                {
                    cmd.CommandText = strInsertCompletion;
                    cmd.Parameters.AddWithValue("@completionId", itemId);
                }
                cmd.Parameters.AddWithValue("@questionId", questionId);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }

            if (this.cboType.SelectedIndex.Equals(0))
            {
                canAddSigleChoice();
                alreadyAddSigleChoice();
            }
            else
            {
                canAddCompletion();
                alreadyAddCompletion();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView2.CurrentRow.Index;
            string itemId = this.dataGridView2.Rows[index].Cells["id"].Value.ToString();
            try
            {
                string strDelSigleChoice = "delete from question_sigleChoice where sigleChoiceId=@sigleChoiceId and questionId=@questionId;";
                string strDelCompletion = "delete from question_completion where completionId=@completionId and questionId=@questionId;";
                cmd = con.CreateCommand();
                con.Open();
                if (this.cboType.SelectedIndex.Equals(0))
                {
                    cmd.CommandText = strDelSigleChoice;
                    cmd.Parameters.AddWithValue("@sigleChoiceId", itemId);
                }
                else
                {
                    cmd.CommandText = strDelCompletion;
                    cmd.Parameters.AddWithValue("@completionId", itemId);
                }
                cmd.Parameters.AddWithValue("@questionId", questionId);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }
            if (this.cboType.SelectedIndex.Equals(0))
            {
                canAddSigleChoice();
                alreadyAddSigleChoice();
            }
            else
            {
                canAddCompletion();
                alreadyAddCompletion();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmQuestionItems_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
