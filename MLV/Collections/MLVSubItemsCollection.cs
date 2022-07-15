/* This file is part of MLV "Managed ListView" project.
   A custom control which provide advanced list view.

   Copyright © Alaa Ibrahim Hadid 2013 - 2017

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System.Collections.Generic;
using System.Collections;

namespace MLV
{
    /// <summary>
    /// Managed ListView sub items collection
    /// </summary>
    public class MLVSubItemsCollection : IList<MLVSubItem>
    {
        /// <summary>
        /// Managed ListView sub items collection
        /// </summary>
        /// <param name="owner">The owner item/child item</param>
        public MLVSubItemsCollection(IMLVElement owner)
        {
            items = new List<MLVSubItem>();
            this.owner = owner;
        }

        private List<MLVSubItem> items;
        private IMLVElement owner;
        /// <summary>
        /// Get a sub item at given index
        /// </summary>
        /// <param name="index">The index of the sub item</param>
        /// <returns>The sub item if found otherwise null.</returns>
        public MLVSubItem this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }
        /// <summary>
        /// Get a sub item using column id (sub item id = column id)
        /// </summary>
        /// <param name="id">The column id/sub item id</param>
        /// <returns>The sub item if found otherwise null</returns>
        public MLVSubItem this[string id]
        {

            get
            {
                return items.Find(
                      delegate (MLVSubItem it)
                      {
                          return it.ID == id;
                      }
                  );
            }
        }
        /// <summary>
        /// Get the sub items count in the collection
        /// </summary>
        public int Count
        { get { return items.Count; } }
        /// <summary>
        /// Get if the collection is read only or not.
        /// </summary>
        public bool IsReadOnly
        { get { return false; } }
        /// <summary>
        /// Add a sub item into the collection
        /// </summary>
        /// <param name="item">The sub item to add</param>
        public void Add(MLVSubItem item)
        {
            items.Add(item);
            item.Index = items.Count - 1;
            if (owner != null)
            {
                if (owner is MLVItem)
                    ((MLVItem)owner).OnSubItemAdded(item);
                else if (owner is MLVChildItem)
                    ((MLVChildItem)owner).OnSubItemAdded(item);
            }
        }
        /// <summary>
        /// Clear the sub items collection
        /// </summary>
        public void Clear()
        {
            items.Clear();
            if (owner != null)
            {
                if (owner is MLVItem)
                    ((MLVItem)owner).OnSubItemsClear();
                else if (owner is MLVChildItem)
                    ((MLVChildItem)owner).OnSubItemsClear();
            }
        }
        /// <summary>
        /// Get if a sub item is contained in the collection
        /// </summary>
        /// <param name="item">The sub item to look for</param>
        /// <returns>True if the sub item is contained in the collection otherwise false.</returns>
        public bool Contains(MLVSubItem item)
        {
            return items.Contains(item);
        }
        /// <summary>
        /// Copy the collection into an array
        /// </summary>
        /// <param name="array">The array to copy into</param>
        /// <param name="arrayIndex">The index where to start copying at</param>
        public void CopyTo(MLVSubItem[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<MLVSubItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        /// <summary>
        /// Get the index of a sub item within the collection.
        /// </summary>
        /// <param name="item">The sub item to look for</param>
        /// <returns>The index of the sub item if found otherwise -1</returns>
        public int IndexOf(MLVSubItem item)
        {
            return items.IndexOf(item);
        }
        /// <summary>
        /// Insert a sub item at given index
        /// </summary>
        /// <param name="index">The index where to insert the sub item at</param>
        /// <param name="item">The sub item to insert</param>
        public void Insert(int index, MLVSubItem item)
        {
            items.Insert(index, item);
            item.Index = items.IndexOf(item);
            if (owner != null)
            {
                if (owner is MLVItem)
                    ((MLVItem)owner).OnSubItemInserted(item, index);
                else if (owner is MLVChildItem)
                    ((MLVChildItem)owner).OnSubItemInserted(item, index);
            }
        }
        /// <summary>
        /// Remove a sub item from the collection
        /// </summary>
        /// <param name="item">The sub item to remove</param>
        /// <returns>True if the item removed successfully otherwise false.</returns>
        public bool Remove(MLVSubItem item)
        {
            if (owner != null)
            {
                if (owner is MLVItem)
                    ((MLVItem)owner).OnSubItemRemove(item, items.IndexOf(item));
                else if (owner is MLVChildItem)
                    ((MLVChildItem)owner).OnSubItemRemove(item, items.IndexOf(item));
            }
            return items.Remove(item);
        }
        /// <summary>
        /// Remove a sub item from the collection at specified index
        /// </summary>
        /// <param name="index">The index of the item to remove at</param>
        public void RemoveAt(int index)
        {
            if (owner != null)
            {
                if (owner is MLVItem)
                    ((MLVItem)owner).OnSubItemRemove(items[index], index);
                else if (owner is MLVChildItem)
                    ((MLVChildItem)owner).OnSubItemRemove(items[index], index);
            }
            items.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
