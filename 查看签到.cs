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
    public partial class 查看签到 : Form
    {
        public 查看签到()
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
            cmd.CommandText = "select*from clockInView where 打卡次数>9";

            //用cmd的函数执行语句，返回SqlDataReader类型的结果dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
            SqlDataReader dr = cmd.ExecuteReader();
            //用dr的read函数，每执行一次，返回一个包含下一行数据的集合dr
            while (dr.Read())
            {
                //构建一个ListView的数据，存入数据库数据，以便添加到listView1的行数据中
                ListViewItem lt = new ListViewItem();
                //将数据库数据转变成ListView类型的一行数据
                lt.Text = dr["打卡次数"].ToString();
                lt.SubItems.Add(dr["日期"].ToString());
                lt.SubItems.Add(dr["姓名"].ToString());
                lt.SubItems.Add(dr["性别"].ToString());
                lt.SubItems.Add(dr["联系电话"].ToString());
                lt.SubItems.Add(dr["学号"].ToString());
                //将lt数据添加到listView1控件中
                listView1.Items.Add(lt);
            }

            con.Close();
        }
    }
}
