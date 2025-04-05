using System.Collections;
using System.Windows.Forms;
namespace ADAL_Video.Forms
{
    public class ListViewColumnSorter : IComparer
    {
        private int ColumnToSort;
        private SortOrder OrderOfSort;
        private CaseInsensitiveComparer ObjectCompare;

        public ListViewColumnSorter()
        {
            ColumnToSort = 0;
            OrderOfSort = SortOrder.None;
            ObjectCompare = new CaseInsensitiveComparer();
        }
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            if (ColumnToSort == 2)
            {
                int returnVal;

                try
                {

                    System.DateTime firstDate =
                            System.DateTime.Parse(((ListViewItem)x).SubItems[ColumnToSort].Text);
                    System.DateTime secondDate =
                            System.DateTime.Parse(((ListViewItem)y).SubItems[ColumnToSort].Text);
                    // Compare the two dates.
                    returnVal = System.DateTime.Compare(firstDate, secondDate);
                }

                catch
                {

                    returnVal = System.String.Compare(((ListViewItem)x).SubItems[ColumnToSort].Text,
                                ((ListViewItem)y).SubItems[ColumnToSort].Text);
                }

                if (OrderOfSort == SortOrder.Descending)
                    returnVal *= -1;
                return returnVal;
            }
            else
            {
                int compareResult;
                ListViewItem listviewX, listviewY;

                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;

                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

                if (OrderOfSort == SortOrder.Ascending)
                {
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    return (-compareResult);
                }
                else
                {
                    return 0;
                }
            }
        }
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }
}