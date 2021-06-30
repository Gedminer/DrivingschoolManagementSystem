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
    public partial class 录入成绩 : Form
    {
        public 录入成绩()
        {
            InitializeComponent();
        }

        private void 录入成绩_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“testDataSet7.students”中。您可以根据需要移动或删除它。
            this.studentsTableAdapter1.Fill(this.testDataSet7.students);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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

                /*旧的，错误的
                string sql = "insert into students(成绩) values('{0}')";
                */

                string sql = "update students set 成绩={0} where 学号='{1}' ";
                //填充SQL语句
                sql = string.Format(sql, textBox1.Text, textBox2.Text);
         
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                //执行SQL语句
                int returnvalue = cmd.ExecuteNonQuery();
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("录入成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("录入失败！" + ex.Message);
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
            this.Close();
            录入成绩 luRuChengJi = new 录入成绩();
            luRuChengJi.Show();
        }
    }
}
//用的testDataset7