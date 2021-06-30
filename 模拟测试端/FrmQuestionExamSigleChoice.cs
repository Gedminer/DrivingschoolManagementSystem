using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 驾校
{
    public partial class FrmQuestionExamSigleChoice : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        public string questionId;
        public string stuId;
        public string questionStuId;
        private string sigleChoiceId;
        private int index = 0;
        private int answer;

        public FrmQuestionExamSigleChoice()
        {
            InitializeComponent();
        }

        private void FrmQuestionExam_Load(object sender, EventArgs e)
        {
            selectSigleChoice();
            showSigleChoice();
        }

        public void selectSigleChoice()
        {
            string selectSigleChoice = "select * from question_sigleChoice qs,sigleChoice s where qs.sigleChoiceId=s.id and qs.questionId=@questionId;";
            con = new SqlConnection(conStr);
            con.Open();
            cmd = new SqlCommand(selectSigleChoice, con);
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
            label3.Text = "本题目共" + dt.Rows.Count + "道题目";
        }

        public void showSigleChoice()
        {
            if (dt.Rows.Count > 0)
            {
                sigleChoiceId = dt.Rows[index]["sigleChoiceId"].ToString();
                label2.Text = dt.Rows[index]["topic"].ToString();
                radioButton1.Text = dt.Rows[index]["item1"].ToString();
                radioButton2.Text = dt.Rows[index]["item2"].ToString();
                radioButton3.Text = dt.Rows[index]["item3"].ToString();
                radioButton4.Text = dt.Rows[index]["item4"].ToString();
                radioButton5.Checked = true;
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
                showSigleChoice();
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
                showSigleChoice();
                this.btnNextQuestion.Show();
            }
            if (index == 0)
            {
                this.btnPreviousQuestion.Hide();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            send(1);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            send(2);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            send(3);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            send(4);
        }
        private void send(int i)
        {
            if (havaItem())
            {
                sendItemUpdate(i);
            }
            else
            {
                sendItemInsert(i);
            }
        }

        private void sendItemInsert(int i)
        {
            string insert = "insert into questionStu_sigleChoice(questionStuId, sigleChoiceId, answer) values(@questionStuId, @sigleChoiceId, @answer); ";
            con = new SqlConnection(conStr);
            con.Open();
            cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@questionStuId", questionStuId);
            cmd.Parameters.AddWithValue("@sigleChoiceId", sigleChoiceId);
            cmd.Parameters.AddWithValue("@answer", i);
            cmd.ExecuteNonQuery();
        }

        private void sendItemUpdate(int i)
        {
            string insert = "update questionStu_sigleChoice set answer=@answer where questionStuId=@questionStuId and sigleChoiceId=@sigleChoiceId; ";
            con = new SqlConnection(conStr);
            con.Open();
            cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@questionStuId", questionStuId);
            cmd.Parameters.AddWithValue("@sigleChoiceId", sigleChoiceId);
            cmd.Parameters.AddWithValue("@answer", i);
            cmd.ExecuteNonQuery();
        }

        

        private Boolean havaItem()
        {
            string insert = "select * from questionStu_sigleChoice where questionStuId=@questionStuId and sigleChoiceId=@sigleChoiceId;";
            con = new SqlConnection(conStr);
            con.Open();
            cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@questionStuId", questionStuId);
            cmd.Parameters.AddWithValue("@sigleChoiceId", sigleChoiceId);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                answer = int.Parse(dr["answer"].ToString());
                return true;
            }
            return false;
        }
    }
}
