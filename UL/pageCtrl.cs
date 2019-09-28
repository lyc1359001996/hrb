using System;
using System.Windows.Forms;

namespace otherCtrs
{
    public delegate void PageChangedHandler(object sender, PagerArgs e);
    // public delegate void PageSizeChangedHandler(object sender, PagerArgs e);
    /// <summary>
    public partial class pageCtrl : UserControl
    {
        private int nowPage = 1;
        private int pageSize = 10;      //每页显示数据条数
        private int currentPageIndex;   //当前页号
        private int recordCount;        //总的记录数
        private int pageCount;          //共计页数

        public int PageSize
        {
            get
            {
                return pageSize;
            }

            set
            {
                pageSize = value;
            }
        }

        public int CurrentPageIndex
        {
            get
            {
                return currentPageIndex;
            }

            set
            {
                currentPageIndex = value;
            }
        }

        public int RecordCount
        {
            get
            {
                return recordCount;
            }

            set
            {
                recordCount = value;
            }
        }

        public int PageCount
        {
            get
            {
                return pageCount;
            }

            set
            {
                pageCount = value;
            }
        }
        /// 页号改变委托
        /// </summary>
        public event PageChangedHandler PageChanged;

        /// <summary>
        /// 每页显示条数改变委托
        /// </summary>
        //public event PageSizeChangedHandler PageSizeChanged;
        public void Init(int pageSize, int recordCount, int pageCount, int currentPageIndex)
        {
            this.pageSize = pageSize;
            this.recordCount = recordCount;
            this.pageCount = pageCount;
            this.currentPageIndex = currentPageIndex;
            init();
        }
        private void init()
        {
            pageSize = 10;
            pageCount = ((recordCount / pageSize) + (recordCount % pageSize > 0 ? 1 : 0));
            string msg = "共{0}条记录，每页{1}条，共{2}页";
            pageMes.Text = string.Format(msg, recordCount, pageSize, pageCount);

            if (currentPageIndex > pageCount && pageCount > 0)
            {
                currentPageIndex = pageCount;
                if (PageChanged != null)
                    PageChanged(this, new PagerArgs(this.pageSize, this.currentPageIndex));
            }
            txtNowPage.Text = nowPage.ToString();
            changeUIVisiable();
        }
        private void changeUIVisiable()
        {
            this.btnUpPage.Enabled = currentPageIndex <= 1 ? false : true;
            this.btnDownPage.Enabled = currentPageIndex < pageCount ? true : false;
        }
        public pageCtrl()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            nowPage = nowPage + 1;
            this.currentPageIndex++;
            if (PageChanged != null)
                PageChanged(this, new PagerArgs(this.pageSize, this.currentPageIndex));
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            nowPage = nowPage - 1;
            this.currentPageIndex--;
            if (PageChanged != null)
                PageChanged(this, new PagerArgs(this.pageSize, this.currentPageIndex));
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            currentPageIndex = int.Parse(txtNowPage.Text);
            nowPage = currentPageIndex;
            if (PageChanged != null)
                PageChanged(this, new PagerArgs(this.pageSize, this.currentPageIndex));
        }

        private void txtNowPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > '9' || e.KeyChar < '0')//如果输入的内容不是数字
            {
                e.Handled = true;
                if (Convert.ToInt32(e.KeyChar) == 8)
                {
                    e.Handled = false;
                }
            }
        }

        private void txtNowPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNowPage.Text == "" || int.Parse(txtNowPage.Text) == 0)
                {
                    txtNowPage.Text = "1";
                }
                if (int.Parse(txtNowPage.Text) > pageCount)
                {
                    txtNowPage.Text = pageCount.ToString();
                }
                simpleButton3_Click(sender, e);
                txtNowPage.SelectAll();
            }
        }
    }
}
