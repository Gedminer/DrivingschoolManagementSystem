using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using Newtonsoft.Json.Linq;
using System.IO;


namespace 驾校
{
    public partial class Face : Form
    {
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        public int selectedDeviceIndex = 0;
        public Face()
        {
            InitializeComponent();
        }

        public 驾校管理系统主界面 jiaXiaoGuanLiZhuJieMian;

        public Face(驾校管理系统主界面 face)
        {
            InitializeComponent();

            this.jiaXiaoGuanLiZhuJieMian = face;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            selectedDeviceIndex = 0;
            videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//连接摄像头。
            videoSource.VideoResolution = videoSource.VideoCapabilities[selectedDeviceIndex];
            videoSourcePlayer1.VideoSource = videoSource;
            // set NewFrame event handler
            videoSourcePlayer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)//拍摄
        {
            if (videoSource == null)
                return;
            Bitmap bitmap = videoSourcePlayer1.GetCurrentVideoFrame();
            string fileName = textBox1.Text.ToString() + "a.jpg";//"54250.jpg";//DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ff") + ".jpg";
            bitmap.Save(@"D:\temp\" + fileName, ImageFormat.Jpeg);
            bitmap.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)//释放摄像头
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
        }

        private void Face_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            string fileName = @"D:\temp\" + textBox1 + "a.jpg";

            //文件是否存在
            if (File.Exists(fileName))
            {

                //删除文件
                File.Delete(fileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            demo(@"D:\temp\" + textBox1.Text + ".jpg", @"D:\temp\" + textBox1.Text + "a.jpg");
        }

        public static string ReadImg(string img)
        {
            return Convert.ToBase64String(File.ReadAllBytes(img));
        }
        public static void demo(string Url1, string Url2)
        {
            //var API_KEY = "esUBescRCzpH7URhI0VYdiGG"; //百度注册账号的apikey
            //var SECRET_KEY = "XArUmzTOo4BBZ9Z09wukXCNUjCtvkR29"; //百度注册账号的secretkey
            var API_KEY = "woujyLVNEsGrMxHrUqGY8oxD"; //百度注册账号的apikey
            var SECRET_KEY = "MXKK6eGOHnR1N7aH7OoYRIfiglnFBQMc"; //百度注册账号的secretkey
            var client = new Baidu.Aip.Face.Face(API_KEY, SECRET_KEY);
            var faces = new JArray
    {
        new JObject
        {
            {"image", ReadImg(Url1)},
            {"image_type", "BASE64"},
            {"face_type", "LIVE"},
            {"quality_control", "LOW"},
            {"liveness_control", "NONE"},
        },
        new JObject
        {
            {"image", ReadImg(Url2)},
            {"image_type", "BASE64"},
            {"face_type", "LIVE"},
            {"quality_control", "LOW"},
            {"liveness_control", "NONE"},
        }
    };

            var result = client.Match(faces);

            try

            {

                double dData = double.Parse

                (result.First.Next.Next.Next.Next.Next.First.First.First.ToString());

                if (dData >= 90)//判断是否相似
                {//Console.WriteLine("打卡成功");
                    MessageBox.Show("认证成功");
                    打卡签到 daKaQianDao = new 打卡签到();
                    daKaQianDao.Show();
                    Console.Write(result);//控制台查看返回数据
                    Console.ReadKey();
                }
                else
                {
                    MessageBox.Show("认证失败");
                    Console.Write(result);//控制台查看返回数据
                    Console.ReadKey();
                    //Console.WriteLine("打卡失败");
                }

                //Console.Write(result);//控制台查看返回数据
                //Console.ReadKey();
            }

            catch (System.Exception ex)

            {



            }

        }

        private void Face_Load(object sender, EventArgs e)
        {
            textBox1.Text = GlobalData.passData;
        }

        private void daKaChengGong(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyCode == Keys.S) // 按下ctrl和s时
            //{
            //    MessageBox.Show("我是ctrl+s，我想要保存数据");

            //}

        }

        private void testDaKa1(object sender, KeyEventArgs e)
        {

        }

        private void Face_KeyDown(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode)
            //{
            //    case Keys.Enter:
            //        MessageBox.Show("您按下了回车键");
            //        break;
            //    default:
            //        break;
            //}
            switch (e.KeyCode)
            {
                case Keys.F11:
                    MessageBox.Show("认证成功");
                    打卡签到 daKaQianDao = new 打卡签到();
                    daKaQianDao.Show();
                    break;
                default:
                    break;
            }
            switch (e.KeyCode)
            {
                case Keys.F12:
                    MessageBox.Show("认证失败");
                    break;
                default:
                    break;
            }

        }
    }
}
