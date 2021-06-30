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
    public partial class FrmCompletion : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        SqlDataReader dr;
        public FrmCompletion()
        {
            InitializeComponent();
        }

        private void FrmCompletion_Load(object sender, EventArgs e)
        {
            selectCompletion();
            selectCourse();
        }

        private void selectCompletion()
        {
            try
            {
                string selectCompletion = "select com.id 编号,cou.name 课程名,com.topic 题目内容,com.valid 正确值,com.score 分值 from completion com,course cou where com.courseId=cou.id;";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(selectCompletion, con);
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

        private void fillCourse()
        {
            int index = this.dataGridView1.CurrentRow.Index;
            this.txtTopic.Text = this.dataGridView1.Rows[index].Cells["题目内容"].Value.ToString();
            this.txtValid.Text = this.dataGridView1.Rows[index].Cells["正确值"].Value.ToString();
            this.txtScore.Text = this.dataGridView1.Rows[index].Cells["分值"].Value.ToString();
            this.cboCourse.Text = this.dataGridView1.Rows[index].Cells["课程名"].Value.ToString();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            fillCourse();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtTopic.Text == "" || this.txtValid.Text == "" || this.txtScore.Text == "")
            {
                MessageBox.Show("添加信息不完整！");
                return;
            }
            try
            {
                string strInsert = "insert into completion(courseId,topic,valid,score) values(@courseId,@topic,@valid,@score)";
                cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = strInsert;
                cmd.Parameters.AddWithValue("@courseId", this.cboCourse.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@topic", this.txtTopic.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@valid", this.txtValid.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@score", this.txtScore.Text.Trim().ToString());
                cmd.ExecuteNonQuery();
                selectCompletion();
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtTopic.Text == "" || this.txtValid.Text == "" || this.txtScore.Text == "")
            {
                MessageBox.Show("添加信息不完整！");
                return;
            }
            try
            {
                string strUpdate = "update completion set courseId=@courseId,topic=@topic,valid=@valid,score=@score where id=@id";
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = strUpdate;
                cmd.Parameters.AddWithValue("@courseId", this.cboCourse.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@topic", this.txtTopic.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@valid", this.txtValid.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@score", this.txtScore.Text.Trim().ToString());
                int index = this.dataGridView1.CurrentRow.Index;
                cmd.Parameters.AddWithValue("@id", this.dataGridView1.Rows[index].Cells["编号"].Value.ToString());
                cmd.ExecuteNonQuery();
                selectCompletion();
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;
            string num = this.dataGridView1.Rows[index].Cells["编号"].Value.ToString();
            if (num.Equals(""))
            {
                MessageBox.Show("请选择要删除的信息！");
                return;
            }
            if (MessageBox.Show("确定删除本条记录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string strDel = "delete from completion where id=@id";
                    cmd = con.CreateCommand();
                    con.Open();
                    cmd.CommandText = strDel;
                    cmd.Parameters.AddWithValue("@id", num);
                    cmd.ExecuteNonQuery();
                    selectCompletion();
                }
                catch (Exception)
                {
                    MessageBox.Show("不能删除此题目，该题目已经被使用！");
                }
                finally
                {
                    cmd.Clone();
                    con.Close();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
