using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 驾校
{
    public partial class 注册界面 : Form
    {
        public 注册界面()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pwd = textBox2.Text;
            string repwd = textBox3.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("用户名不能为空！");
                return;
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            else if (!textBox2.Text.Equals(textBox3.Text))
            {
                MessageBox.Show("两次输入的密码不一致！");
                return;
            }
            //将用户名和密码传递到主窗体中
            注册信息   zhuCeJeiMian = new 注册信息 (name, pwd);
            zhuCeJeiMian .Show();
        }
    }
}
