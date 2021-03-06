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
    public partial class 查询成绩 : Form
    {
        public 查询成绩()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //编写数据库连接串
            string connStr = "Data Source=.;Initial Catalog=test;User ID=123;Password=123";
            //创建 SqlConnection的实例
            SqlConnection conn = null;
            //定义SqlDataReader类的对象
            SqlDataReader dr = null;
            try
            {
                conn = new SqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                string sql = "select 姓名,成绩 from students where 学号='{0}'";
                //填充SQL语句
                sql = string.Format(sql, textBox1.Text);
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                //执行Sql语句
                dr = cmd.ExecuteReader();
                //判断SQL语句是否执行成功
                if (dr.Read())
                {
                    //读取指定用户名对应的用户编号和密码
                    string msg = "姓名：" + dr[0] + " 成绩：" + dr[1];
                    //将msg的值显示在标签上
                    label2.Text = msg;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败！" + ex.Message);
            }
            finally
            {
                if (dr != null)
                {
                    //判断dr不为空，关闭SqlDataReader对象
                    dr.Close();
                }
                if (conn != null)
                {
                    //关闭数据库连接
                    conn.Close();
                }
            }
        }
    }
}
