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
    public partial class 驾校管理系统主界面 : Form
    {
        public 驾校管理系统主界面()
        {
            InitializeComponent();
        }

        //public string xueHao;//老方式，不好

        private void button1_Click(object sender, EventArgs e)
        {

            GlobalData.passData = textBox1.Text;//保存传递的字符串

           // From myForm = new Form2();//构建B窗体的一个实例
            //myForm.ShowDialog();//显示B窗体

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

                    string sql01 = "Select count(*) from userinfo where name='{0}' and password='{1}' and purview='1'";
                    //填充SQL语句
                    sql01 = string.Format(sql01, textBox1.Text, textBox2.Text);
                    //创建SqlCommand对象
                    SqlCommand cmd01 = new SqlCommand(sql01, conn);
                    //执行SQL语句
                    int returnvalue01 = (int)cmd01.ExecuteScalar();
                    //判断SQL语句是否执行成功
                    if (returnvalue01 != 0)
                    {
                        MessageBox.Show("教师端登录成功！");

                        教师端 jiaoShiDuan = new 教师端();
                        jiaoShiDuan.Show();
                    }
                    else
                    {
                        MessageBox.Show("学生端登录成功！");
                        学生端 xueShengDuan = new 学生端();
                        xueShengDuan.Show();
                    }


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


        /*
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
    }*/

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("firefox.exe", "file:///C:/Users/qq187/Desktop/%E8%B5%84%E6%BA%90/201710089/html/index.html");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("firefox.exe", "file:///C:/Users/qq187/Desktop/%E8%B5%84%E6%BA%90/201710089/html/index.html");
        }

        private void 驾校管理系统主界面_Load(object sender, EventArgs e)
        {
            skinEngine1.SkinFile = System.Environment.CurrentDirectory + "\\mp10.ssk";
            skinEngine1.DisableTag = 9999;
        }
    }
}
