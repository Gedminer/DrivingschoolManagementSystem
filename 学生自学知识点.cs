﻿using System;
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
    public partial class 学生自学知识点 : Form
    {
        public 学生自学知识点()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string temp = label1.Text;
            label1.Text = label2.Text;
            label2.Text = temp;
        }
    }
}
