using Common.Utilities;
using DXApplication2.BLL;
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
using thsoft_core;

namespace DXApplication2.UL
{
    public partial class UpdPwd : Form
    {
        B_User user = new B_User();
        ControlHelp control = new ControlHelp();
        IniFile ini = new IniFile(@"config\set.ini");
        public UpdPwd()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            control.checkpwd(textEdit1,textEdit2,textEdit3,ini.IniReadValue("mySqlCon2", "username"));
        }
    }
}
