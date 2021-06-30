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
using System.Data.OleDb;

namespace 驾校
{
    public partial class FrmSigleChoice : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        SqlDataReader dr;
        public FrmSigleChoice()
        {
            InitializeComponent();
        }

        private void FrmSigleChoice_Load(object sender, EventArgs e)
        {
            this.cboValid.SelectedIndex = 0;
            selectSigleChoice();
            selectCourse();
        }

        private void selectSigleChoice()
        {
            try
            {
                string selectSigleChoice = "select sc.id 编号,c.name 课程名,sc.topic 题目内容,sc.item1 A选项,sc.item2 B选项,sc.item3 C选项,sc.item4 D选项,sc.valid 正确选项,sc.score 分值 from sigleChoice sc,course c where sc.courseId=c.id;";
                con = new SqlConnection(conStr);
                con.Open();
                cmd = new SqlCommand(selectSigleChoice, con);
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
            this.txtItem1.Text = this.dataGridView1.Rows[index].Cells["A选项"].Value.ToString();
            this.txtItem2.Text = this.dataGridView1.Rows[index].Cells["B选项"].Value.ToString();
            this.txtItem3.Text = this.dataGridView1.Rows[index].Cells["C选项"].Value.ToString();
            this.txtItem4.Text = this.dataGridView1.Rows[index].Cells["D选项"].Value.ToString();
            this.cboValid.SelectedIndex = int.Parse(this.dataGridView1.Rows[index].Cells["正确选项"].Value.ToString()) - 1;
            this.txtScore.Text = this.dataGridView1.Rows[index].Cells["分值"].Value.ToString();
            this.cboCourse.Text = this.dataGridView1.Rows[index].Cells["课程名"].Value.ToString();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            fillCourse();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtTopic.Text == "" || this.txtItem1.Text == "" || this.txtItem2.Text == "" || this.txtItem3.Text == "" || this.txtItem4.Text == "" || this.txtScore.Text == "")
            {
                MessageBox.Show("添加信息不完整！");
                return;
            }
            try
            {
                string strInsert = "insert into sigleChoice(courseId,topic,item1,item2,item3,item4,valid,score) values(@courseId,@topic,@item1,@item2,@item3,@item4,@valid,@score)";
                cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = strInsert;
                cmd.Parameters.AddWithValue("@courseId", this.cboCourse.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@topic", this.txtTopic.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@item1", this.txtItem1.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@item2", this.txtItem2.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@item3", this.txtItem3.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@item4", this.txtItem4.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@valid", this.cboValid.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@score", this.txtScore.Text.Trim().ToString());
                cmd.ExecuteNonQuery();
                selectSigleChoice();
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtTopic.Text == "" || this.txtItem1.Text == "" || this.txtItem2.Text == "" || this.txtItem3.Text == "" || this.txtItem4.Text == "" || this.txtScore.Text == "")
            {
                MessageBox.Show("添加信息不完整！");
                return;
            }
            try
            {
                string strUpdate = "update sigleChoice set courseId=@courseId,topic=@topic,item1=@item1,item2=@item2,item3=@item3,item4=@item4,valid=@valid,score=@score where id=@id";
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = strUpdate;
                cmd.Parameters.AddWithValue("@courseId", this.cboCourse.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@topic", this.txtTopic.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@item1", this.txtItem1.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@item2", this.txtItem2.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@item3", this.txtItem3.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@item4", this.txtItem4.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@valid", this.cboValid.SelectedIndex + 1);
                cmd.Parameters.AddWithValue("@score", this.txtScore.Text.Trim().ToString());
                int index = this.dataGridView1.CurrentRow.Index;
                cmd.Parameters.AddWithValue("@id", this.dataGridView1.Rows[index].Cells["编号"].Value.ToString());
                cmd.ExecuteNonQuery();
                selectSigleChoice();
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
                    string strDel = "delete from sigleChoice where id=@id";
                    cmd = con.CreateCommand();
                    con.Open();
                    cmd.CommandText = strDel;
                    cmd.Parameters.AddWithValue("@id", num);
                    cmd.ExecuteNonQuery();
                    selectSigleChoice();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName.ToString();
                insertToData(fileName);
                selectSigleChoice();
            }
        }

        private DataTable xsldata(string filepath)
        {
            //string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;IMEX=1'";
            string strCon = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
            string strConn = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'", filepath);
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            System.Data.DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //获取Excel的第一个Sheet名称
            string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString().Trim();
            //查询sheet中的数据
            string strSql = "select * from [" + sheetName + "]";

            //string strCom = "SELECT * FROM [Sheet1]";
            OleDbCommand cmd = new OleDbCommand(strSql, conn);
            //OleDbDataAdapter myCommand = new OleDbDataAdapter(strSql, conn);
            OleDbDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            conn.Close();
            return dt;
        }

        private void insertToData(string fileName)
        {
            string strInsert = "insert into sigleChoice(courseId,topic,item1,item2,item3,item4,valid,score) values(@courseId,@topic,@item1,@item2,@item3,@item4,@valid,@score)";
            string filepath = fileName;
            cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = strInsert;
            try
            {
                DataTable dt = new DataTable();
                dt = xsldata(filepath);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@courseId", dt.Rows[i][0].ToString().Trim());
                    cmd.Parameters.AddWithValue("@topic", dt.Rows[i][1].ToString());
                    cmd.Parameters.AddWithValue("@item1", dt.Rows[i][2].ToString());
                    cmd.Parameters.AddWithValue("@item2", dt.Rows[i][3].ToString());
                    cmd.Parameters.AddWithValue("@item3", dt.Rows[i][4].ToString());
                    cmd.Parameters.AddWithValue("@item4", dt.Rows[i][5].ToString());
                    cmd.Parameters.AddWithValue("@valid", dt.Rows[i][6].ToString());
                    cmd.Parameters.AddWithValue("@score", dt.Rows[i][7].ToString().Trim());
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }
        }
    }
}
