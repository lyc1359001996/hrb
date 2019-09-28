namespace otherCtrs
{
    partial class pageCtrl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDownPage = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpPage = new DevExpress.XtraEditors.SimpleButton();
            this.pageMes = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNowPage = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtNowPage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDownPage
            // 
            this.btnDownPage.Location = new System.Drawing.Point(54, 0);
            this.btnDownPage.Name = "btnDownPage";
            this.btnDownPage.Size = new System.Drawing.Size(47, 23);
            this.btnDownPage.TabIndex = 0;
            this.btnDownPage.Text = "下一页";
            this.btnDownPage.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnUpPage
            // 
            this.btnUpPage.Location = new System.Drawing.Point(3, 0);
            this.btnUpPage.Name = "btnUpPage";
            this.btnUpPage.Size = new System.Drawing.Size(47, 23);
            this.btnUpPage.TabIndex = 1;
            this.btnUpPage.Text = "上一页";
            this.btnUpPage.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // pageMes
            // 
            this.pageMes.Location = new System.Drawing.Point(240, 4);
            this.pageMes.Name = "pageMes";
            this.pageMes.Size = new System.Drawing.Size(189, 14);
            this.pageMes.TabIndex = 0;
            this.pageMes.Text = "共{0}条记录，每页{1}条，共{2}页";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(186, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(12, 14);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "页";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(121, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 14);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "跳转";
            // 
            // txtNowPage
            // 
            this.txtNowPage.Location = new System.Drawing.Point(148, 1);
            this.txtNowPage.Name = "txtNowPage";
            this.txtNowPage.Size = new System.Drawing.Size(36, 20);
            this.txtNowPage.TabIndex = 9;
            this.txtNowPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNowPage_KeyDown);
            this.txtNowPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNowPage_KeyPress);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(200, 0);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(23, 23);
            this.simpleButton3.TabIndex = 8;
            this.simpleButton3.Text = "Go";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // pageCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtNowPage);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.pageMes);
            this.Controls.Add(this.btnUpPage);
            this.Controls.Add(this.btnDownPage);
            this.Name = "pageCtrl";
            this.Size = new System.Drawing.Size(460, 23);
            ((System.ComponentModel.ISupportInitialize)(this.txtNowPage.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnDownPage;
        private DevExpress.XtraEditors.SimpleButton btnUpPage;
        private DevExpress.XtraEditors.LabelControl pageMes;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNowPage;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
    }
}
