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
    /// Managed ListView Items collection.
    /// </summary>
    public class MLVItemsCollection : IList<MLVItem>
    {
        /// <summary>
        /// Managed ListView Items collection.
        /// </summary>
        /// <param name="owner">The owner panel</param>
        public MLVItemsCollection(MLVPanel owner)
        {
            items = new List<MLVItem>();
            this.owner = owner;
        }

        private List<MLVItem> items;
        private MLVPanel owner;
        /// <summary>
        /// Get or set a Managed ListView Item.
        /// </summary>
        /// <param name="index">The index of the item</param>
        /// <returns>The Managed ListView Item if found at given index otherwise null.</returns>
        public MLVItem this[int index]
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
        internal MLVItem this[string oid]
        {

            get
            {
                return items.Find(
                      delegate (MLVItem it)
                      {
                          return it.OID == oid;
                      }
                  );
            }
        }
        /// <summary>
        /// Get the items count in the collection.
        /// </summary>
        public int Count
        { get { return items.Count; } }
        /// <summary>
        /// Get if this collection is read only or not.
        /// </summary>
        public bool IsReadOnly
        { get { return false; } }
        /// <summary>
        /// Add a Managed ListView Item into the collection.
        /// </summary>
        /// <param name="item">The Managed ListView Item to add.</param>
        public void Add(MLVItem item)
        {
            items.Add(item);
            item.Index = items.Count - 1;
            if (owner != null)
                owner.OnItemAdded(item);
        }
        /// <summary>
        /// Clear all the items from the collection.
        /// </summary>
        public void Clear()
        {
            items.Clear();
            if (owner != null)
                owner.OnItemsClear();
        }
        /// <summary>
        /// Get if a Managed ListView Item is contained within the collection.
        /// </summary>
        /// <param name="item">The Managed ListView Item to look for</param>
        /// <returns>True if the item is contained in the collection otherwise false.</returns>
        public bool Contains(MLVItem item)
        {
            return items.Contains(item);
        }
        /// <summary>
        /// Copy the items within the collection into an array
        /// </summary>
        /// <param name="array">The array to copy the items into</param>
        /// <param name="arrayIndex">The index where to start copying at.</param>
        public void CopyTo(MLVItem[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<MLVItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        /// <summary>
        /// Get the index of an item within the collection.
        /// </summary>
        /// <param name="item">The Managed ListView Item to look for.</param>
        /// <returns>The index of the item if found otherwise -1</returns>
        public int IndexOf(MLVItem item)
        {
            return items.IndexOf(item);
        }
        /// <summary>
        /// Insert a Managed ListView Item into the collection at given index
        /// </summary>
        /// <param name="index">The index within the collection where to insert the item at.</param>
        /// <param name="item">The Managed ListView Item to insert</param>
        public void Insert(int index, MLVItem item)
        {
            items.Insert(index, item);
            item.Index = items.IndexOf(item);
            if (owner != null)
                owner.OnItemInserted(item, index);
        }
        /// <summary>
        /// Remove a Managed ListView Item from the collection
        /// </summary>
        /// <param name="item">The Managed ListView Item to remove</param>
        /// <returns>True if the item remove successfully otherwise false.</returns>
        public bool Remove(MLVItem item)
        {
            if (owner != null)
                owner.OnItemRemove(item, items.IndexOf(item));
            return items.Remove(item);
        }
        /// <summary>
        /// Remove a Managed ListView Item at given index
        /// </summary>
        /// <param name="index">The index where to remove the item at.</param>
        public void RemoveAt(int index)
        {
            if (owner != null)
                owner.OnItemRemove(items[index], index);
            items.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
