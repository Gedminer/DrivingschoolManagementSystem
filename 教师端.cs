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
    public partial class 教师端 : Form
    {
        public 教师端()
        {
            InitializeComponent();
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

        private void button7_Click(object sender, EventArgs e)
        {
            录入成绩 lvRuChengJi = new 录入成绩();
            lvRuChengJi.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            开设课程 kaiSheKeCheng = new 开设课程();
            kaiSheKeCheng.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            添加教练 tianJiaJiaoLian = new 添加教练();
            tianJiaJiaoLian.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            设置自学测试题 sheZhiZiXueCeShiTi = new 设置自学测试题();
            sheZhiZiXueCeShiTi.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            不及格学员 buJiGeChaXun = new 不及格学员();
            buJiGeChaXun.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            查看签到 chaKanQianDao = new 查看签到();
            chaKanQianDao.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin=new FrmLogin();
            frmLogin.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            查询课程 chaXunKeCheng = new 查询课程();
            chaXunKeCheng.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
