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
    public partial class 客户端选择 : Form
    {
        public 客户端选择()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                //二级页面 erJiYieMian = new 二级页面();
                //erJiYieMian.ShowDialog();
                学生端 xueShengDuan = new 学生端();
                xueShengDuan.Show();
            }
            else if (radioButton2.Checked)
            {
                教师端 jiaoShiDuan = new 教师端();
                jiaoShiDuan.Show();
            }
        }
    }
}
