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
    public partial class 不及格学员 : Form
    {
        public 不及格学员()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();//只移除所有的项。
            ////构建表头
            //listView1.Columns.Add("编号");
            //listView1.Columns.Add("用户名");
            //listView1.Columns.Add("密码");
            //创建数据库连接类的对象
            SqlConnection con = new SqlConnection("server=.;database=test;user=123;pwd=123");
            con.Open();
            //执行con对象的函数，返回一个SqlCommand类型的对象
            SqlCommand cmd = con.CreateCommand();
            //把输入的数据拼接成sql语句，并交给cmd对象
            cmd.CommandText = "select*from students where 成绩<80";

            //用cmd的函数执行语句，返回SqlDataReader类型的结果dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
            SqlDataReader dr = cmd.ExecuteReader();
            //用dr的read函数，每执行一次，返回一个包含下一行数据的集合dr
            while (dr.Read())
            {
                //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                ListViewItem lt = new ListViewItem();
                //将数据库数据转变成ListView类型的一行数据
                lt.Text = dr["姓名"].ToString();
                lt.SubItems.Add(dr["性别"].ToString());
                lt.SubItems.Add(dr["联系电话"].ToString());
                lt.SubItems.Add(dr["学号"].ToString());
                lt.SubItems.Add(dr["成绩"].ToString());
                //将lt数据添加到listView1控件中
                listView1.Items.Add(lt);
            }

            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
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
                string sql = "update students set 成绩=0 where 成绩<80";
                //填充SQL语句
              
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                //执行Sql语句
                dr = cmd.ExecuteReader();
                //判断SQL语句是否执行成功
                if (dr.Read())
                {
                    MessageBox.Show("清除成功！");
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

