using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace 驾校
{
    public partial class FrmClass : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        private string classId = "";
        SqlConnection con;
        DataTable dt;
        SqlDataAdapter da;
        SqlCommand cmd;

        public FrmClass()
        {
            InitializeComponent();
        }

        private void FrmClass_Load(object sender, EventArgs e)
        {

            selectClass();
        }
        private void selectClass()
        {
            try
            {
                string strSelect = "select * from class";
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
                if (this.txtClass.Text.ToString().Equals(dr["name"].ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        private void fillTxtClass()
        {
            int index = this.dataGridView1.CurrentRow.Index;
            this.txtClass.Text = this.dataGridView1.Rows[index].Cells["name"].Value.ToString();
            classId = this.dataGridView1.Rows[index].Cells["id"].Value.ToString();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            fillTxtClass();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.txtClass.Text == "")
            {
                MessageBox.Show("添加信息不完整！");
                return;
            }
            if (isSameRecord())
            {
                MessageBox.Show("班级名称重复");
                return;
            }
            try
            {
                string strInsert = "insert into class(name) values(@name)";
                cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = strInsert;
                cmd.Parameters.AddWithValue("@name", this.txtClass.Text.Trim().ToString());
                cmd.ExecuteNonQuery();
                selectClass();
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (classId == "")
            {
                MessageBox.Show("请选择要更新的项目");
                return;
            }
            if (this.txtClass.Text == "")
            {
                MessageBox.Show("添加信息不完整！");
                return;
            }
            if (isSameRecord())
            {
                MessageBox.Show("班级名称重复");
                return;
            }
            try
            {
                string strUpdate = "update class set name=@name where id=@id";
                SqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = strUpdate;
                cmd.Parameters.AddWithValue("@name", this.txtClass.Text.Trim().ToString());
                cmd.Parameters.AddWithValue("@id", classId);
                cmd.ExecuteNonQuery();
                selectClass();
            }
            finally
            {
                cmd.Clone();
                con.Close();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.txtClass.Text == "")
            {
                MessageBox.Show("请选择要删除的信息！");
                return;
            }
            if (MessageBox.Show("确定删除本条记录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                try
                {
                    string strDel = "delete from class where id=@id";
                    cmd = con.CreateCommand();
                    con.Open();
                    cmd.CommandText = strDel;
                    cmd.Parameters.AddWithValue("@id", classId);
                    cmd.ExecuteNonQuery();
                    selectClass();
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
