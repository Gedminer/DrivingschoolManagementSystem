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
    public partial class FrmQuestionExamCompletion : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        public string questionId;
        public string stuId;
        public string questionStuId;
        private string completionId;
        private int index = 0;
        private string  answer;
        public FrmQuestionExamCompletion()
        {
            InitializeComponent();
        }

        private void FrmQuestionExamCompletion_Load(object sender, EventArgs e)
        {
            selectCompletion();
            showCompletion();
        }

        public void selectCompletion()
        {
            string selectCompletion = "select * from question_completion qc,completion c where qc.completionId=c.id and qc.questionId=@questionId;";
            con = new SqlConnection(conStr);
            con.Open();
            cmd = new SqlCommand(selectCompletion, con);
            cmd.Parameters.AddWithValue("@questionId", questionId);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            for (int i = 1; i <= dt.Rows.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = "第" + i + "题";
                lvwSigleChoice.Items.Add(lvi);
            }
            label5.Text = "本题目共" + dt.Rows.Count + "道题目";
        }

        public void showCompletion()
        {
            if (dt.Rows.Count > 0)
            {
                completionId = dt.Rows[index]["completionId"].ToString();
                label2.Text = dt.Rows[index]["topic"].ToString();
                textBox1.Text = "";
                label4.Text = "当前为" + (1 + index) + "道题目";
                lvwSigleChoice.SelectedItems.Clear();
                lvwSigleChoice.Items[index].Selected = true;
                lvwSigleChoice.Select();
            }
            else
            {
                label4.Hide();
            }
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            index++;
            if (index < dt.Rows.Count)
            {
                showCompletion();
                this.btnPreviousQuestion.Show();
            }
            if (index == dt.Rows.Count - 1)
            {
                this.btnNextQuestion.Hide();
            }
        }

        private void btnPreviousQuestion_Click(object sender, EventArgs e)
        {
            index--;
            if (index > -1)
            {
                showCompletion();
                this.btnNextQuestion.Show();
            }
            if (index == 0)
            {
                this.btnPreviousQuestion.Hide();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (havaItem())
            {
                sendItemUpdate(textBox1.Text.Trim().ToString());
            }
            else
            {
                sendItemInsert(textBox1.Text.Trim().ToString());
            }
        }

        private Boolean havaItem()
        {
            string insert = "select * from questionStu_completion where questionStuId=@questionStuId and completionId=@completionId;";
            con = new SqlConnection(conStr);
            con.Open();
            cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@questionStuId", questionStuId);
            cmd.Parameters.AddWithValue("@completionId", completionId);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                answer = dr["answer"].ToString();
                return true;
            }
            return false;
        }

        private void sendItemInsert(string  i)
        {
            string insert = "insert into questionStu_completion(questionStuId, completionId, answer) values(@questionStuId, @completionId, @answer); ";
            con = new SqlConnection(conStr);
            con.Open();
            cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@questionStuId", questionStuId);
            cmd.Parameters.AddWithValue("@completionId", completionId);
            cmd.Parameters.AddWithValue("@answer", i);
            cmd.ExecuteNonQuery();
        }

        private void sendItemUpdate(string i)
        {
            string insert = "update questionStu_completion set answer=@answer where questionStuId=@questionStuId and completionId=@completionId; ";
            con = new SqlConnection(conStr);
            con.Open();
            cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@questionStuId", questionStuId);
            cmd.Parameters.AddWithValue("@completionId", completionId);
            cmd.Parameters.AddWithValue("@answer", i);
            cmd.ExecuteNonQuery();
        }
    }
}
