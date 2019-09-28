using System;

namespace otherCtrs
{
    public class PagerArgs : EventArgs
    {
        private int pageSize;
        /// <summary>
        /// 每页显示数据条数
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        private int currentPageIndex;
        /// <summary>
        /// 当前页号
        /// </summary>
        public int CurrentPageIndex
        {
            get { return currentPageIndex; }
            set { currentPageIndex = value; }
        }

        public PagerArgs() { }

        public PagerArgs(int pageSize, int currentPageIndex)
        {
            this.pageSize = pageSize;
            this.currentPageIndex = currentPageIndex;
        }
    }
}