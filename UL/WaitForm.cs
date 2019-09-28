using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication16
{
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();
           this.TopMost = true;
            this.ShowInTaskbar = false;
          

        }

        private void WaitForm_Load(object sender, EventArgs e)
        {
            //this.pictureBox1.SendToBack();//将背景图片放到最下面
            //this.panel1.BackColor = Color.Transparent;//将Panel设为透明
            //this.panel1.Parent = this.pictureBox1;//将panel父控件设为背景图片控件
            //  this.panel1.BringToFront();//将panel放在前面
            this.TransparencyKey = BackColor;
           
        }
        public string SetText(string text)
        {
            return label1.Text=text;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
