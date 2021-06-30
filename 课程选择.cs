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
    public partial class 课程选择 : Form
    {
        public 课程选择()
        {
            InitializeComponent();
        }

        private void 课程选择_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“testDataSet5._class”中。您可以根据需要移动或删除它。
            this.classTableAdapter.Fill(this.testDataSet5._class);

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
                string sql = "insert into changeClass(课程,科目,时间,学号) values('{0}','{1}','{2}','{3}')";
                //填充SQL语句
                sql = string.Format(sql, comboBox1 .Text ,comboBox2 .Text ,comboBox3 .Text ,textBox1 .Text );
                //创建SqlCommand对象
                SqlCommand cmd = new SqlCommand(sql, conn);
                //执行SQL语句
                int returnvalue = cmd.ExecuteNonQuery();
                //判断SQL语句是否执行成功
                if (returnvalue != -1)
                {
                    MessageBox.Show("选课成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("选课失败！" + ex.Message);
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
        }
    }
}
