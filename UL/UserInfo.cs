using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using thsoft_core;

namespace DXApplication2.UL
{
    public partial class UserInfo : Form
    {
        IniFile ini = new IniFile(@"config\set.ini");
        public UserInfo()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {
            labelControl2.Text = ini.IniReadValue("mySqlCon3", "username");
            labelControl1.Text = ini.IniReadValue("mySqlCon3", "storeName");
        }
    }
}
