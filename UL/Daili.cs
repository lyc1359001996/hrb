using DXApplication2.HELP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication2.UL
{
    public partial class Daili : Form
    {
        Internet Internet = new Internet();
        public Daili()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (comboBoxEdit1.SelectedIndex==0)
            {
                if (Internet.yanzhen(textEdit1.Text, int.Parse(textEdit2.Text)))
                {
                    Internet.SetIEProxy(textEdit1+":"+textEdit2.Text);
                }
                else
                {
                    MessageBox.Show("代理IP格式不正确", "提示", MessageBoxButtons.OK);
                }
            }else
            {
                Internet.SetIEProxy(string.Empty);
            }
        }
    }
}
