using System;

namespace otherCtrs
{
    public class PagerArgs : EventArgs
    {
        private int pageSize;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        private int currentPageIndex;
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