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
    public partial class 查看课程时间 : Form
    {
        public 查看课程时间()
        {
            InitializeComponent();
        }

        private void 查询_Click(object sender, EventArgs e)
        {

        }

        private void 查看课程时间_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“testDataSet4._class”中。您可以根据需要移动或删除它。
            this.classTableAdapter1.Fill(this.testDataSet4._class);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
