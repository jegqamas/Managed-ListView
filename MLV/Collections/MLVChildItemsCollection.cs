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
using System.Collections;
using System.Collections.Generic;

namespace MLV
{
    /// <summary>
    /// Managed Listview child items collection
    /// </summary>
    public class MLVChildItemsCollection : IList<MLVChildItem>
    {
        /// <summary>
        /// Managed Listview child items collection
        /// </summary>
        /// <param name="owner">The owner Managed Listview item.</param>
        public MLVChildItemsCollection(MLVItem owner)
        {
            items = new List<MLVChildItem>();
            this.owner = owner;
        }

        private List<MLVChildItem> items;
        private MLVItem owner;
        /// <summary>
        /// Get or set a child item within this collection
        /// </summary>
        /// <param name="index">The child item index</param>
        /// <returns>The child item if fount at given index otherwise null.</returns>
        public MLVChildItem this[int index]
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
        internal MLVChildItem this[string oid]
        {

            get
            {
                return items.Find(
                      delegate (MLVChildItem it)
                      {
                          return it.OID == oid;
                      }
                  );
            }
        }
        /// <summary>
        /// Get the collection items count
        /// </summary>
        public int Count
        { get { return items.Count; } }
        /// <summary>
        /// Get if this collection is read only or not.
        /// </summary>
        public bool IsReadOnly
        { get { return false; } }
        /// <summary>
        /// Add a Managed Listview child item into this collection
        /// </summary>
        /// <param name="item">The Managed Listview child item to add.</param>
        public void Add(MLVChildItem item)
        {
            items.Add(item);
            item.Index = items.Count - 1;
            if (owner != null)
            {
                item.SetParent(owner);
                owner.OnChildItemAdded(item);
            }
        }
        /// <summary>
        /// Clear the collection
        /// </summary>
        public void Clear()
        {
            items.Clear();
            if (owner != null)
            {
                owner.OnChildItemsClear();
            }
        }
        /// <summary>
        /// Get if a Managed Listview child item is contained in this collection
        /// </summary>
        /// <param name="item">The Managed Listview child item to look for.</param>
        /// <returns>True if the child item is contained in the collection otherwise false.</returns>
        public bool Contains(MLVChildItem item)
        {
            return items.Contains(item);
        }
        /// <summary>
        /// Copy the items of this collection into an array
        /// </summary>
        /// <param name="array">The array to copy the items into.</param>
        /// <param name="arrayIndex">The index where to start copying at.</param>
        public void CopyTo(MLVChildItem[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<MLVChildItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        /// <summary>
        /// Get the index of a child item within the collection
        /// </summary>
        /// <param name="item">The Managed Listview child item to get the index for</param>
        /// <returns>The index of the given item if found otherwise -1</returns>
        public int IndexOf(MLVChildItem item)
        {
            return items.IndexOf(item);
        }
        /// <summary>
        /// Insert a child item into the collection
        /// </summary>
        /// <param name="index">The index within the collection where to insert the child item at.</param>
        /// <param name="item">The Managed Listview child item to insert.</param>
        public void Insert(int index, MLVChildItem item)
        {
            items.Insert(index, item);
            item.Index = items.IndexOf(item);
            if (owner != null)
            {
                item.SetParent(owner);
                owner.OnChildItemInserted(item, index);
            }
        }
        /// <summary>
        /// Remove a child item from the collection
        /// </summary>
        /// <param name="item">The Managed Listview child item to remove</param>
        /// <returns>True if the removing completed successfully otherwise false.</returns>
        public bool Remove(MLVChildItem item)
        {
            if (owner != null)
                owner.OnChildItemRemove(item, items.IndexOf(item));
            return items.Remove(item);
        }
        /// <summary>
        /// Remove a Managed Listview child item from the collection at given index.
        /// </summary>
        /// <param name="index">The index where to remove the child item at.</param>
        public void RemoveAt(int index)
        {
            if (owner != null)
                owner.OnChildItemRemove(items[index], index);
            items.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
