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
    public partial class 打卡签到 : Form
    {
        public 打卡签到()
        {
            InitializeComponent();
        }

        public 驾校管理系统主界面 jiaXiaoGuanLiZhuJieMian;

        public 打卡签到(驾校管理系统主界面 daKaQianDao)
        {
            InitializeComponent();

            this.jiaXiaoGuanLiZhuJieMian = daKaQianDao;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == String.Empty)
            {
                MessageBox.Show("数据错误：请输入正确学号");
                return;
            }
            else
            {
                string todayDate;
                todayDate = DateTime.Now.ToString("yyyyMMdd");
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
                    string sql = "select 日期 from clockIn where 学号='{0}'";
                    //填充SQL语句
                    sql = string.Format(sql, textBox1.Text);
                    //创建SqlCommand对象
                    SqlCommand cmd0 = new SqlCommand(sql, conn);
                    //执行Sql语句
                    dr = cmd0.ExecuteReader();
                    //判断SQL语句是否执行成功
                    if (dr.Read())
                    {
                        //读取指定用户名对应的用户编号和密码
                        string msg = (string)dr[0];
                        //string msg = "姓名：" + dr[0] + " 成绩：" + dr[1];
                        //将msg的值显示在标签上
                        label1.Text = msg;
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



                label3.Text = todayDate.ToString();
                label1.Text = label1.Text.ToString();
                //编写数据库连接串
                string connStr01 = "Data Source=.;Initial Catalog=test;User ID=123;Password=123";
                //创建 SqlConnection的实例
                SqlConnection conn01 = null;
                //定义SqlDataReader类的对象
                SqlDataReader dr00 = null;
                try
                {
                    conn01 = new SqlConnection(connStr01);
                    //打开数据库连接
                    conn01.Open();
                    string sql01 = "select datediff(day,'{0}','{1}')";
                    //填充SQL语句
                    sql01 = string.Format(sql01, label1.Text, label3.Text);
                    //创建SqlCommand对象
                    textBox2.Text = sql01;
                    SqlCommand cmd01 = new SqlCommand(sql01, conn01);
                    //执行Sql语句
                    dr00 = cmd01.ExecuteReader();
                    //判断SQL语句是否执行成功
                    if (dr00.Read())
                    {
                        //读取指定用户名对应的用户编号和密码
                        string msg01 = (string)dr00[0];
                        //string msg = "姓名：" + dr[0] + " 成绩：" + dr[1];
                        //将msg的值显示在标签上
                        label2.Text = msg01;
                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show("查询失败！" + ex.Message);
                }
                finally
                {
                    if (dr00 != null)
                    {
                        //判断dr不为空，关闭SqlDataReader对象
                        dr00.Close();
                    }
                    if (conn01 != null)
                    {
                        //关闭数据库连接
                        conn01.Close();
                    }
                }


                this.listView1.Items.Clear();//只移除所有的项。
                                             ////构建表头
                listView1.Columns.Add("编号");
                //listView1.Columns.Add("用户名");
                //listView1.Columns.Add("密码");
                //创建数据库连接类的对象
                SqlConnection con = new SqlConnection("server=.;database=test;user=123;pwd=123");
                con.Open();
                //执行con对象的函数，返回一个SqlCommand类型的对象
                SqlCommand cmd = con.CreateCommand();
                //把输入的数据拼接成sql语句，并交给cmd对象
                cmd.CommandText = "" + textBox2.Text + "";

                //用cmd的函数执行语句，返回SqlDataReader类型的结果dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
                SqlDataReader dr01 = cmd.ExecuteReader();
                //用dr的read函数，每执行一次，返回一个包含下一行数据的集合dr
                try
                {
                    if (dr01.Read())
                    {
                        //读取指定用户名对应的用户编号和密码
                        string msg = dr01[0].ToString();
                        //将msg的值显示在标签上
                        label4.Text = msg;
                    }
                }
                catch (Exception ex03)

                {
                    MessageBox.Show("查询失败！" + ex03.Message);
                }
                string s = "0";
                int a1 = int.Parse(s);
                int a2;
                int.TryParse(s, out a2);
                int a3 = Convert.ToInt32(s);

                string r = label4.Text;
                int la1 = int.Parse(label4.Text);
                int la2;
                int.TryParse(r, out la2);
                int la3 = Convert.ToInt32(r);
                con.Close();
                if (la3 == a3)
                {
                    MessageBox.Show("今天已签到不能再签！");
                }
                else
                {
                    if (la3 < a3)
                    {
                        MessageBox.Show("数据错误，请联系驾校！");
                    }
                    else
                    {
                        string connStr02 = "Data Source=.;Initial Catalog=test;User ID=123;Password=123";
                        //创建 SqlConnection的实例
                        SqlConnection conn02 = null;
                        //定义SqlDataReader类的对象
                        SqlDataReader dr02 = null;
                        try
                        {
                            todayDate = DateTime.Now.ToString("yyyyMMdd");
                            conn02 = new SqlConnection(connStr02);
                            //打开数据库连接
                            conn02.Open();
                            string sql02 = "update clockIn set 打卡次数=打卡次数+1 ,日期={0} where 学号='{1}'";
                            //填充SQL语句
                            sql02 = string.Format(sql02, todayDate, textBox1.Text);
                            //创建SqlCommand对象
                            textBox2.Text = sql02;
                            SqlCommand cmd02 = new SqlCommand(sql02, conn02);
                            //执行Sql语句
                            dr02 = cmd02.ExecuteReader();
                            //判断SQL语句是否执行成功
                            if (dr02.Read())
                            {
                                MessageBox.Show("打卡成功！");
                                ////读取指定用户名对应的用户编号和密码
                                //string msg01 = (string)dr01[0];
                                ////string msg = "姓名：" + dr[0] + " 成绩：" + dr[1];
                                ////将msg的值显示在标签上
                                //label2.Text = msg01;
                            }
                        }
                        catch (Exception ex02)
                        {
                            // MessageBox.Show("查询失败！" + ex.Message);
                            MessageBox.Show("打卡成功！" + ex02.Message);
                        }
                        finally
                        {
                            if (dr02 != null)
                            {
                                //判断dr不为空，关闭SqlDataReader对象
                                MessageBox.Show("打卡成功！");
                                dr01.Close();
                            }
                            if (conn01 != null)
                            {
                                MessageBox.Show("打卡成功！");
                                //关闭数据库连接
                                conn01.Close();
                            }
                        }
                    }
                }

                con.Close();

            }
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
                string sql = "select 打卡次数 from clockIn where 学号='{0}'";
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
                    string msgChaXun = "打卡次数：" + dr[0];
                    //将msg的值显示在标签上
                    label6.Text = msgChaXun;
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

        private void 打卡签到_Load(object sender, EventArgs e)
        {
            //textBox1.Text = this.jiaXiaoGuanLiZhuJieMian.xueHao.ToString();
            textBox1.Text = GlobalData.passData;//从GlobalData中读取数据
        }
    }
}
