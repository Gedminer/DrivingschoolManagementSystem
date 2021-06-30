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
    public partial class 二级页面 : Form
    {
        public 二级页面()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            查看课程时间 chaKanShiJian = new 查看课程时间();
            chaKanShiJian.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            查看课程时间 chaKanShiJian = new 查看课程时间();
            chaKanShiJian.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            添加学员 tianJiaXueYuan = new 添加学员();
            tianJiaXueYuan.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
