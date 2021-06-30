using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 驾校
{
    public partial class 驾校管理系统 : Form
    {
        public 驾校管理系统()
        {
            InitializeComponent();
        }

        private void 驾校管理系统_Load(object sender, EventArgs e)
        {

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12 || e.KeyCode == Keys.F12)
            {
                //Form1 newForm = new Form1();
                //newForm.ShowDialog();
                //form.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)//"登录"按钮的单击事件
        {
            //编写数据库连接串
            string connStr = "Data Source=.;Initial Catalog=test;User ID=123;Password=123";
            //创建SQLConnection的实例
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                string sql = "Select count(*) from userinfo where name='{0}' and password='{1}'";
                //填充SQL语句
                sql = string.Format(sql, textBox1.Text, textBox2.Text);
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                //执行SQL语句
                int returnvalue = (int)cmd.ExecuteScalar();
                //判断SQL语句是否执行成功
                if (returnvalue != 0)
                {
                    MessageBox.Show("登录成功！");
                    客户端选择 keHuDuanXuanZe = new 客户端选择();
                    keHuDuanXuanZe.Show();
                }
                else
                {
                    MessageBox.Show("登录失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            注册界面 zhuCeJieMian = new 注册界面();
            zhuCeJieMian.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //编写数据库连接串
            string connStr = "Data source=.;Initial Catalog=test;User ID=123;Password=123";
            //创建SqlConnection的实例
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                MessageBox.Show("数据库连接成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }

        private void 驾校管理系统_Load_1(object sender, EventArgs e)
        {

        }
    }
}
