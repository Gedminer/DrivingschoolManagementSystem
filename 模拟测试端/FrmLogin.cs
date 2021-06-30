using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 驾校
{
    public partial class FrmLogin : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private string str_ValidateCode;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strNum = this.txtName.Text.Trim().ToString();
            string strPwd = this.txtPwd.Text.Trim().ToString();
            string strValidateCode = this.txtValidateCode.Text.Trim().ToString();
            string strSelect;
            if (this.str_ValidateCode != strValidateCode)
            {
                MessageBox.Show("验证失败");
                return;
            }
            try
            {
                con = new SqlConnection(conStr);
                con.Open();
                if (this.cboType.SelectedIndex.Equals(0))
                {
                    strSelect = "select * from student where num=@num and password=@password";
                }
                else
                {
                    strSelect = "select * from teacher where num=@num and password=@password";
                }
                cmd = new SqlCommand(strSelect, con);
                cmd.Parameters.Add("@num", System.Data.SqlDbType.VarChar).Value = strNum;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = strPwd;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (this.cboType.SelectedIndex.Equals(0))
                    {
                        this.Hide();
                        FrmStudent frmStudent = new FrmStudent();
                        frmStudent.stuId = dr["id"].ToString();
                        frmStudent.Show();
                    }
                    else
                    {
                        this.Hide();
                        FrmTeacher frmTeacher = new FrmTeacher();
                        frmTeacher.teaId = dr["id"].ToString();
                        frmTeacher.Show();
                    }
                }
                else
                {
                    MessageBox.Show("登录失败，用户名或密码错误！", "错误");
                    this.txtName.Text = "";
                    this.txtPwd.Text = "";
                    refreshValidateCode();
                }
            }
            finally
            {
                dr.Close();
                cmd.Clone();
                con.Close();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.cboType.SelectedIndex = 0;
            refreshValidateCode();
        }

        private void refreshValidateCode()
        {
            this.str_ValidateCode = GetRandomNumberString(4);
            CreateImage(this.str_ValidateCode);
        }

        private string GetRandomNumberString(int int_NumberLength)
        {
            string str_Number = string.Empty;
            Random theRandomNumber = new Random();
            for (int int_index = 0; int_index < int_NumberLength; int_index++)
            {
                str_Number += theRandomNumber.Next(10).ToString();
            }
            return str_Number;
        }

        private Color GetRandomColor()
        {
            Random RandomNum_First = new Random((int)DateTime.Now.Ticks);
            System.Threading.Thread.Sleep(30);
            Random RandomNum_Sencond = new Random((int)DateTime.Now.Ticks);
            System.Threading.Thread.Sleep(30);
            Random RandomNum_Three = new Random((int)DateTime.Now.Ticks);
            int int_Red = RandomNum_First.Next(256);
            int int_Green = RandomNum_Sencond.Next(256);
            int int_Blue = RandomNum_Three.Next(256);
            return Color.FromArgb(int_Red, int_Green, int_Blue);
        }

        private void CreateImage(string str_validateCode)
        {
            int int_ImageWidth = str_validateCode.Length * 13;
            Random newRandom = new Random();
            Bitmap theBitmap = new Bitmap(int_ImageWidth, 20);
            Graphics theGraphics = Graphics.FromImage(theBitmap);
            theGraphics.Clear(Color.White);
            theGraphics.DrawRectangle(new Pen(Color.LightGray, 1), 0, 0, int_ImageWidth - 1, 19);
            Font theFont = new Font("Arial", 10);
            for (int int_index = 0; int_index < str_validateCode.Length; int_index++)
            {
                string str_char = str_validateCode.Substring(int_index, 1);
                Brush newBrush = new SolidBrush(GetRandomColor());
                Point thePos = new Point(int_index * 13 + 1 + newRandom.Next(3), 1 + newRandom.Next(3));
                theGraphics.DrawString(str_char, theFont, newBrush, thePos);
            }
            this.pictureBox1.Image = theBitmap;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            refreshValidateCode();
        }

        private void txtValidateCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
