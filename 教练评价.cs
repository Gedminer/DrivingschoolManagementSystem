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
    public partial class 教练评价 : Form
    {
        public 教练评价()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (radioButton1.Checked)
            {
                msg = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                msg = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                msg = radioButton3.Text;
            }
            else if (radioButton4.Checked)
            {
                msg = radioButton4.Text;
            }
            else if (radioButton5.Checked)
            {
                msg = radioButton5.Text;
            }
            MessageBox.Show("您选择的评价是：" + msg, "提示");
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
                string sql = "insert into teacher(姓名,评价) values('{0}','{1}')";
                //填充SQL语句
                sql = string.Format(sql, comboBox1.Text , msg );
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

        private void 教练评价_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“testDataSet6.teacher”中。您可以根据需要移动或删除它。
            this.teacherTableAdapter.Fill(this.testDataSet6.teacher);

        }
    }
}
