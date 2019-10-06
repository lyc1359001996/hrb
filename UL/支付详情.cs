using DXApplication2.Properties;
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
    public partial class 支付详情 : Form
    {
        IniFile ini = new IniFile(@"config\set.ini");
        public 支付详情()
        {
            InitializeComponent();
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "McSkin";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void 支付详情_Load(object sender, EventArgs e)
        {
            var status = ini.IniReadValue("mySqlCon4", "status");
            var payTime = ini.IniReadValue("mySqlCon4", "payTime");
            var createTime = ini.IniReadValue("mySqlCon4", "createTime");
            var orderOn = ini.IniReadValue("mySqlCon4", "orderOn");
            var orderAmount = ini.IniReadValue("mySqlCon4", "orderAmount");
            var discountAmount = ini.IniReadValue("mySqlCon4", "discountAmount");
            var realPayAmount = ini.IniReadValue("mySqlCon4", "realPayAmount");
            var mathod = ini.IniReadValue("mySqlCon4", "mathod");
            if (status.Equals("1")) { Console.WriteLine(11111); labelControl10.Text = "支付成功"; } else if(status.Equals("2")){ labelControl10.Text = "已撤销"; } else if (status.Equals("3")) { labelControl10.Text = "已退款"; } else if (status.Equals("2")) { labelControl10.Text = "已撤销"; } else if (status.Equals("3")) { labelControl10.Text = "已退款"; } else if (status.Equals("4")) { labelControl10.Text = "支付失败"; } else if (status.Equals("5")) { labelControl10.Text = "部分退款"; } else if (status.Equals("6")) { labelControl10.Text = "已关闭"; } else if (status.Equals("7")) { labelControl10.Text = "未支付"; }
            labelControl9.Text = "PC";
            labelControl8.Text = payTime;
            labelControl7.Text = createTime;
            labelControl6.Text = orderOn;
            labelControl12.Text = orderAmount;
            labelControl11.Text = discountAmount;
            labelControl16.Text = realPayAmount+"元";
            if (mathod.Equals("1")) { panelControl2.ContentImage = Resources.zhifubao_3x; }else { panelControl2.ContentImage = Resources.weixin_3x; }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
