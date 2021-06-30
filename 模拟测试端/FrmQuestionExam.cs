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
    public partial class FrmQuestionExam : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr, dr2;
        public string questionId;
        public string stuId;
        public string questionStuId;
        private double duration = 1;
        private int closeIdentity = 0;
        DateTime dt;

        public FrmQuestionExam()
        {
            InitializeComponent();
        }

        private void FrmQuestionExam_Load(object sender, EventArgs e)
        {
            createQuestion();
            dt = DateTime.Now;
            dt = dt.AddMinutes(duration);
        }

        public void createQuestion()
        {
            string selectSigleChoice = "insert into question_student(questionId,score,studentId) values(@questionId,@score,@studentId);SELECT @@Identity;";
            con = new SqlConnection(conStr);
            con.Open();
            cmd = new SqlCommand(selectSigleChoice, con);
            cmd.Parameters.AddWithValue("@questionId", questionId);
            cmd.Parameters.AddWithValue("@score", "0");
            cmd.Parameters.AddWithValue("@studentId", stuId);
            questionStuId = cmd.ExecuteScalar().ToString();
        }

        private void 选择题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQuestionExamSigleChoice frmQuestionExamSigleChoice = new FrmQuestionExamSigleChoice();
            frmQuestionExamSigleChoice.TopLevel = false;
            frmQuestionExamSigleChoice.questionId = questionId;
            frmQuestionExamSigleChoice.stuId = stuId;
            frmQuestionExamSigleChoice.questionStuId = questionStuId;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frmQuestionExamSigleChoice);
            frmQuestionExamSigleChoice.Show();
        }

        private void 填空题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQuestionExamCompletion frmQuestionExamCompletion = new FrmQuestionExamCompletion();
            frmQuestionExamCompletion.TopLevel = false;
            frmQuestionExamCompletion.questionId = questionId;
            frmQuestionExamCompletion.stuId = stuId;
            frmQuestionExamCompletion.questionStuId = questionStuId;
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(frmQuestionExamCompletion);
            frmQuestionExamCompletion.Show();
        }

        private void 提交试卷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "确定提交试卷吗？", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                send();
            }
        }

        private void send()
        {
            timer1.Stop();
            double score = alculateScoreSigleChoice();
            score += alculateScoreCompletion();
            try
            {
                string updateScore = "update question_student set score=@score where id=@questionStuId;";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(updateScore, con);
                cmd.Parameters.AddWithValue("@score", score);
                cmd.Parameters.AddWithValue("@questionStuId", questionStuId);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
                cmd.Clone();
            }
            closeIdentity = 1;
            this.Close();
        }

        private double alculateScoreSigleChoice()
        {
            double score = 0;
            string selectStu_sigleChoice = "select * from questionStu_sigleChoice where questionStuId=@questionStuId;";
            con = new SqlConnection(conStr);
            con.Open();
            cmd = new SqlCommand(selectStu_sigleChoice, con);
            cmd.Parameters.AddWithValue("@questionStuId", questionStuId);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string selectSigleChoice = "select * from sigleChoice where id=@id;";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(selectSigleChoice, con);
                int id = int.Parse(dr["sigleChoiceId"].ToString());
                cmd.Parameters.AddWithValue("@id", dr["sigleChoiceId"].ToString());
                dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    int answer = int.Parse(dr["answer"].ToString());
                    int valid = int.Parse(dr2["valid"].ToString());
                    if (answer.Equals(valid))
                    {
                        score += double.Parse(dr2["score"].ToString());
                    }
                }
            }
            return score;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = dt.Subtract(DateTime.Now);
            toolStripStatusLabel1.Text = "距离考试结束还剩余：" + ts.Minutes + "分钟 " + ts.Seconds + "秒";
            if (ts.TotalSeconds < 0)
            {
                send();
                MessageBox.Show("考试时间到！！以为你提交试卷。");
            }
        }

        private void FrmQuestionExam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeIdentity.Equals(0))
            {
                DialogResult TS = MessageBox.Show("退出前请提交试卷！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                e.Cancel = true;
            }

        }

        private double alculateScoreCompletion()
        {
            double score = 0;
            string selectStu_completion = "select * from questionStu_completion where questionStuId=@questionStuId;";
            con = new SqlConnection(conStr);
            con.Open();
            cmd = new SqlCommand(selectStu_completion, con);
            cmd.Parameters.AddWithValue("@questionStuId", questionStuId);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string selectSigleChoice = "select * from completion where id=@id;";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(selectSigleChoice, con);
                int id = int.Parse(dr["completionId"].ToString());
                cmd.Parameters.AddWithValue("@id", dr["completionId"].ToString());
                dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    int answer = int.Parse(dr["answer"].ToString());
                    int valid = int.Parse(dr2["valid"].ToString());
                    if (answer.Equals(valid))
                    {
                        score += double.Parse(dr2["score"].ToString());
                    }
                }
            }
            return score;
        }
    }
}
