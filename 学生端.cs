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
    public partial class 学生端 : Form
    {
        public 学生端()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            查看课程时间 chaKanShiJian = new 查看课程时间();
            chaKanShiJian.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            查询成绩 chaXunChengJi = new 查询成绩();
            chaXunChengJi.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            课程选择 keChengXuanZe = new 课程选择();
            keChengXuanZe.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            教练评价 jiaoLianPingJia = new 教练评价();
            jiaoLianPingJia.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            学生自学系统 xueShengZiXueXiTong = new 学生自学系统();
            xueShengZiXueXiTong.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //打卡签到 daKaQianDao = new 打卡签到();
            //daKaQianDao.Show();
            打卡签到 daKaQianDao = new 打卡签到();
            //this.Hide();

            daKaQianDao.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Camera camera = new Camera();
            //camera.Show();
            Face face = new Face();
            face.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
        }

        private void 学生端_Load(object sender, EventArgs e)
        {
            //skinEngine1.SkinFile = System.Environment.CurrentDirectory + "\\SteelBlue.ssk";
        }

        private void c证知识点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C证知识点 cZhengZiShiDian = new C证知识点();
            cZhengZiShiDian.Show();
        }

        private void b证知识点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            B证知识点 BZhengZiShiDian = new B证知识点();
            BZhengZiShiDian.Show();
        }

        private void a证知识点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A证知识点 AZhengZiShiDian = new A证知识点();
            AZhengZiShiDian.Show();
        }
    }
}
