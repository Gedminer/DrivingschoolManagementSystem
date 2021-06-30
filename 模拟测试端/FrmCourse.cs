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
    public partial class FrmCourse : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        private string courseId = "";
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;
        public FrmCourse()
        {
            InitializeComponent();
        }

        private void FrmCourse_Load(object sender, EventArgs e)
        {
            selectCourse();
        }

        private void selectCourse()
        {
            try
            {
                string strSelect = "select * from course";
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

        private bool isSameRecord()
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (this.txtName.Text.ToString().Equals(dr["name"].ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        private void fillTxtCourse()
        {
            int index = this.dataGridView1.CurrentRow.Index;
            this.txtName.Text = this.dataGridView1.Rows[index].Cells["name"].Value.ToString();
            courseId = this.dataGridView1.Rows[index].Cells["id"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text == "")
            {
                MessageBox.Show("添加信息不完整！");
                return;
            }
            if (isSameRecord())
            {
                MessageBox.Show("课程名称重复！");
                return;
            }
            try
            {
                string strInsert = "insert into course(name) values(@name)";
                cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = strInsert;
                cmd.Parameters.AddWithValue("@name", this.txtName.Text.Trim().ToString());
                cmd.ExecuteNonQuery();
                selectCourse();
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (courseId == "")
            {
                MessageBox.Show("请选择要更新的项目");
                return;
            }
            if (this.txtName.Text == "")
            {
                MessageBox.Show("添加信息不完整！");
                return;
            }
            if (isSameRecord())
            {
                MessageBox.Show("课程名称重复");
                return;
            }
            try
            {
                string strUpdate = "update course set name=@name where id=@id";
                cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = strUpdate;
                cmd.Parameters.AddWithValue("@name", this.txtName.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@id", courseId);
                cmd.ExecuteNonQuery();
                selectCourse();
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            fillTxtCourse();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text == "")
            {
                MessageBox.Show("请选择要删除的信息！");
                return;
            }
            if (MessageBox.Show("确定删除本条记录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                try
                {
                    string strDel = "delete from course where id=@id";
                    cmd = con.CreateCommand();
                    con.Open();
                    cmd.CommandText = strDel;
                    cmd.Parameters.AddWithValue("@id", courseId);
                    cmd.ExecuteNonQuery();
                    selectCourse();
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
