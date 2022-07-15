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
    /// Managed ListView columns collection.
    /// </summary>
    public class MLVColumnsCollection : IList<MLVColumn>
    {
        /// <summary>
        /// Managed ListView columns collection.
        /// </summary>
        /// <param name="owner">THe owner panel.</param>
        public MLVColumnsCollection(MLVPanel owner)
        {
            columns = new List<MLVColumn>();
            this.owner = owner;
        }

        private List<MLVColumn> columns;
        private MLVPanel owner;
        /// <summary>
        /// Get or set a column at given index.
        /// </summary>
        /// <param name="index">The index of the column within the collection.</param>
        /// <returns>The column if found otherwise null.</returns>
        public MLVColumn this[int index]
        {
            get
            {
                return columns[index];
            }
            set
            {
                columns[index] = value;
            }
        }
        /// <summary>
        /// Get the count of the columns in the collection.
        /// </summary>
        public int Count
        { get { return columns.Count; } }
        /// <summary>
        /// Get if the collection is read only or not.
        /// </summary>
        public bool IsReadOnly
        { get { return false; } }
        /// <summary>
        /// Add a column into the collection.
        /// </summary>
        /// <param name="item">The column to add.</param>
        public void Add(MLVColumn item)
        {
            columns.Add(item);
            if (owner != null)
                owner.OnColumnAdded(item);
        }
        /// <summary>
        /// Clear all columns in the collection.
        /// </summary>
        public void Clear()
        {
            columns.Clear();
            if (owner != null)
                owner.OnColumnsClear();
        }
        /// <summary>
        /// Get if a column is contained within the collection or not.
        /// </summary>
        /// <param name="item">The column to search for.</param>
        /// <returns>True if the column is contained in the collection otherwise false.</returns>
        public bool Contains(MLVColumn item)
        {
            return columns.Contains(item);
        }
        /// <summary>
        /// Copy the columns in the collection into an array.
        /// </summary>
        /// <param name="array">The array to copy the columns into.</param>
        /// <param name="arrayIndex">The index where to start the copy at</param>
        public void CopyTo(MLVColumn[] array, int arrayIndex)
        {
            columns.CopyTo(array, arrayIndex);
        }
        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<MLVColumn> GetEnumerator()
        {
            return columns.GetEnumerator();
        }
        /// <summary>
        /// Get the index of a column within the collection.
        /// </summary>
        /// <param name="item">The column to look for.</param>
        /// <returns>The column index within the collection if found otherwise -1</returns>
        public int IndexOf(MLVColumn item)
        {
            return columns.IndexOf(item);
        }
        /// <summary>
        /// Insert a column at given index
        /// </summary>
        /// <param name="index">The index where to insert the column at</param>
        /// <param name="item">The column to insert</param>
        public void Insert(int index, MLVColumn item)
        {
            columns.Insert(index, item);
            if (owner != null)
                owner.OnColumnInserted(item, index);
        }
        /// <summary>
        /// Remove a column from the collection
        /// </summary>
        /// <param name="item">The column to remove</param>
        /// <returns>True if the column removed successfully otherwise false.</returns>
        public bool Remove(MLVColumn item)
        {
            if (owner != null)
                owner.OnColumnRemove(item, columns.IndexOf(item));
            return columns.Remove(item);
        }
        /// <summary>
        /// Remove a column from the collection at specified index.
        /// </summary>
        /// <param name="index">The index of the column to remove.</param>
        public void RemoveAt(int index)
        {
            if (owner != null)
                owner.OnColumnRemove(columns[index], index);
            columns.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return columns.GetEnumerator();
        }
    }
}
