namespace DXApplication2.UL
{
    partial class 悬浮
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(悬浮));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.BackColor2 = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 30F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelControl1.Appearance.Image = global::DXApplication2.Properties.Resources.icon_drag_money_pop;
            this.labelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl1.LineLocation = DevExpress.XtraEditors.LineLocation.Right;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(2, 1);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(224, 56);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "      0";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            this.labelControl1.DoubleClick += new System.EventHandler(this.labelControl1_DoubleClick);
            this.labelControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelControl1_MouseDown);
            this.labelControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelControl1_MouseMove);
            this.labelControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelControl1_MouseUp);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.BackColor2 = System.Drawing.Color.White;
            this.labelControl2.Appearance.BorderColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Image = global::DXApplication2.Properties.Resources.zbg2;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.labelControl2.LineLocation = DevExpress.XtraEditors.LineLocation.Right;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(2, 1);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(68, 56);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Click += new System.EventHandler(this.labelControl2_Click);
            this.labelControl2.DoubleClick += new System.EventHandler(this.labelControl2_DoubleClick);
            this.labelControl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelControl2_MouseDown);
            this.labelControl2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelControl2_MouseMove);
            this.labelControl2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelControl2_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // 悬浮
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 60);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1300, 200);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "悬浮";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.Text = "悬浮";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.悬浮_Click);
            this.DoubleClick += new System.EventHandler(this.悬浮_DoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Timer timer1;
    }
}