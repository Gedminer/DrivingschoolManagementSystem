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
    public partial class 开设课程 : Form
    {
        public 开设课程()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void 开设课程_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("C证普通班");//窗体加载事件，为组合框添加值
            comboBox1.Items.Add("C证VIP班");
            comboBox1.Items.Add("B证普通班");
            comboBox1.Items.Add("B证VIP班");
            comboBox1.Items.Add("A证普通班");
            comboBox1.Items.Add("A证VIP班");
            comboBox2.Items.Add("科目一");
            comboBox2.Items.Add("科目二");
            comboBox2.Items.Add("科目三");
            comboBox2.Items.Add("科目四");
            comboBox3.Items.Add("1号车");
            comboBox3.Items.Add("2号车");
            comboBox3.Items.Add("3号车");
            comboBox3.Items.Add("4号车");
            comboBox3.Items.Add("5号车");
            comboBox3.Items.Add("6号车");
            comboBox3.Items.Add("7号车");
            comboBox3.Items.Add("8号车");
            monthCalendar1.Hide();//隐藏日历控件
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //显示日历控件
            monthCalendar1.Show();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //将选择的日期显示在文本框中
            textBox1.Text = monthCalendar1.SelectionStart.ToShortDateString();
            //隐藏日历控件
            monthCalendar1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //编写数据库连接串
            string connStr = "Data Source=.;Initial Catalog=test;User ID=123;Password=123";
            //创建 SqlConnection的实例
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                //打开数据库连接
                conn.Open();
                //执行SQL语句
                string sql = "insert into class(班级,日期,科目,车辆) values('{0}','{1}','{2}','{3}')";
                //填充SQL语句
                sql = string.Format(sql, comboBox1 .Text ,textBox1 .Text ,comboBox2.Text ,comboBox3.Text);
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                //执行SQL语句
                int returnvalue = cmd.ExecuteNonQuery();
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("创建成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("创建失败！" + ex.Message);
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
    }
}
