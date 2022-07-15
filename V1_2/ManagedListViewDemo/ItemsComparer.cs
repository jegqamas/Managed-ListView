using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLV;
namespace ManagedListViewDemo
{
    /// <summary>
    /// The items comparer class
    /// </summary>
    class ItemsComparer : IComparer<ManagedListViewItem>
    {
        /// <summary>
        /// The items comparer class for comparing Managed ListView items via column id.
        /// </summary>
        /// <param name="AtoZ">True= A to Z sort, False=Z to A sort</param>
        /// <param name="subitemId">The column id of the subitem.</param>
        public ItemsComparer(bool AtoZ, string subitemId)
        {
            this.AtoZ = AtoZ;
            this.subitemId = subitemId;
        }
       
        private bool AtoZ = true;
        private string subitemId = "";

        /// <summary>
        /// Compare 2 items debending on subitem
        /// </summary>
        /// <param name="x">The first item</param>
        /// <param name="y">The second item</param>
        /// <returns>Compare result.</returns>
        public int Compare(ManagedListViewItem x, ManagedListViewItem y)
        {
            if (x.GetSubItemByID(subitemId) != null && y.GetSubItemByID(subitemId) != null)
            {
                if (AtoZ)
                    return (StringComparer.Create(System.Threading.Thread.CurrentThread.CurrentCulture, false)).Compare(x.GetSubItemByID(subitemId).Text, y.GetSubItemByID(subitemId).Text);
                else
                    return (-1 * (StringComparer.Create(System.Threading.Thread.CurrentThread.CurrentCulture, false)).Compare(x.GetSubItemByID(subitemId).Text, y.GetSubItemByID(subitemId).Text));
            }
            return -1;
        }
    }
}
