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
    public partial class FrmStudentInfo : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        private string studentId = "";
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        SqlDataReader dr;
        public FrmStudentInfo()
        {
            InitializeComponent();
        }

        private void FrmStudentInfo_Load(object sender, EventArgs e)
        {
            selectStudent();
            selectClass();
        }

        private void selectStudent()
        {
            try
            {
                string strSelect = "select s.id,s.num 学号,s.name 姓名,c.name 班级 from student s,class c where s.classId=c.id;";
                con = new SqlConnection(conStr);
                dt = new DataTable();
                da = new SqlDataAdapter(strSelect, con);
                da.Fill(dt);
                this.dataGridView1.DataSource = dt.DefaultView;
            }
            finally
            {
                dt.Clone();
                con.Close();
            }
        }
        private void selectClass()
        {
            try
            {
                string strSelect = "select * from class";
                con = new SqlConnection(conStr);
                con.Open();
                da = new SqlDataAdapter(strSelect, con);
                ds = new DataSet();
                da.Fill(ds, "class");
                this.cboClass.DataSource = ds.Tables["class"];
                this.cboClass.DisplayMember = "name";
                this.cboClass.ValueMember = "id";
            }
            finally
            {
                ds.Clone();
                con.Close();
            }
        }

        private void fillControls()
        {
            int index = this.dataGridView1.CurrentRow.Index;
            this.txtNum.Text = this.dataGridView1.Rows[index].Cells["学号"].Value.ToString();
            this.txtName.Text = this.dataGridView1.Rows[index].Cells["姓名"].Value.ToString();
            this.cboClass.Text = this.dataGridView1.Rows[index].Cells["班级"].Value.ToString();
            studentId = this.dataGridView1.Rows[index].Cells["id"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtNum.Text == "" || this.txtName.Text == "")
            {
                MessageBox.Show("添加信息不完整！");
                return;
            }
            try
            {
                string strInsert = "insert into student(classId,num,name,password) values(@classId,@num,@name,@password);";
                cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = strInsert;
                DataRowView drv = (DataRowView)this.cboClass.SelectedItem;
                string strClassId = drv.Row["id"].ToString();
                cmd.Parameters.AddWithValue("@classId", strClassId);
                cmd.Parameters.AddWithValue("@num", this.txtNum.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@name", this.txtName.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@password", this.txtNum.Text.Trim().ToString());
                cmd.ExecuteNonQuery();
                selectStudent();
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (studentId == "")
            {
                MessageBox.Show("请选择要更新的项目");
                return;
            }
            if (this.txtNum.Text == "" || this.txtName.Text == "")
            {
                MessageBox.Show("添加信息不完整！");
                return;
            }
            try
            {
                string strUpdate = "update student set classId=@classId,num=@num,name=@name,password=@password where id=@id";
                cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = strUpdate;
                DataRowView drv = (DataRowView)this.cboClass.SelectedItem;
                string strClassId = drv.Row["id"].ToString();
                cmd.Parameters.AddWithValue("@classId", strClassId);
                cmd.Parameters.AddWithValue("@num", this.txtNum.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@name", this.txtName.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@password", this.txtNum.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@id", studentId);
                cmd.ExecuteNonQuery();
                selectStudent();
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            fillControls();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (studentId == "")
            {
                MessageBox.Show("请选择要删除的信息！");
                return;
            }
            if (MessageBox.Show("确定删除本条记录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    string strDel = "delete from student where id=@id";
                    cmd = con.CreateCommand();
                    con.Open();
                    cmd.CommandText = strDel;
                    cmd.Parameters.AddWithValue("@id", studentId);
                    cmd.ExecuteNonQuery();
                    selectStudent();
                }
                finally
                {
                    cmd.Clone();
                    con.Close();
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.txtNum.Text == "" && this.txtName.Text == "" && this.cboClass.Text == "")
            {
                MessageBox.Show("请输入要查询的信息");
                return;
            }
            StringBuilder strSelect = new StringBuilder();
            strSelect.Append("select s.id,s.num 学号,s.name 姓名,c.name 班级 from student s,class c where s.classId=c.id");
            if (this.txtNum.Text != "")
            {
                strSelect.Append(" and s.num like @num");
            }
            if (this.txtName.Text != "")
            {
                strSelect.Append(" and s.name like @name");
            }
            if (this.cboClass.Text != "")
            {
                strSelect.Append(" and s.classId like @classId");
            }
            try
            {

                cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = strSelect.ToString();
                cmd.Parameters.AddWithValue("@num", this.txtNum.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@name", this.txtName.Text.Trim().ToString());
                DataRowView drv = (DataRowView)this.cboClass.SelectedItem;
                cmd.Parameters.AddWithValue("@classId", drv.Row["id"].ToString());
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                this.dataGridView1.DataSource = dt.DefaultView;
                
            }
            finally
            {
                dt.Clone();
                dr.Close();
                con.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            selectStudent();
        }
    }
}
