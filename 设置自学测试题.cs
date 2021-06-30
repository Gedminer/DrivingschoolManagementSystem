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
    public partial class 设置自学测试题 : Form
    {
        public 设置自学测试题()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                string sql = "insert into questions(题干,选项A,选项B,选项C,选项D,答案) values('{0}','{1}','{2}','{3}','{4}','{5}')";
                //填充SQL语句
                sql = string.Format(sql, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
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

        private void 设置自学测试题_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“testDataSet9.questions”中。您可以根据需要移动或删除它。
            this.questionsTableAdapter.Fill(this.testDataSet9.questions);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            设置自学测试题 sheZhiZiXueCeShiTi = new 设置自学测试题();
            sheZhiZiXueCeShiTi.Show();
        }
    }
}
