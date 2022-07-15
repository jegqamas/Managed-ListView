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
using System;

namespace MLV
{
    /// <summary>
    /// EventArgs for rating changed events.
    /// </summary>
    public class RatingChangedEventArgs : EventArgs
    {
        /// <summary>
        /// EventArgs for rating changed events.
        /// </summary>
        /// <param name="id">The column id</param>
        /// <param name="parentIndex">Parent item index, if this subitem belongs to a child item, this will be the index of the parent item of that child item.</param>
        /// <param name="parentChildIndex">Parent child item if this subitem belongs to a child item</param>
        /// <param name="newRating">The new rating value.</param>
        /// <param name="oldRating">The old rating value.</param>
        public RatingChangedEventArgs(string id, int parentIndex, int parentChildIndex, int newRating, int oldRating)
        {
            ColumnID = id;
            ParentItemIndex = parentIndex;
            ParentChildItemIndex = parentChildIndex;
            NewRating = newRating;
            OldRating = oldRating;
            Cancel = false;
        }
        /// <summary>
        /// Get the subitem id (The column id).
        /// </summary>
        public string ColumnID { get; private set; }
        /// <summary>
        /// Get parent item index, if this subitem belongs to a child item, this will be the index of the parent item of that child item.
        /// </summary>
        public int ParentItemIndex { get; private set; }
        /// <summary>
        /// Get parent child item if this subitem belongs to a child item.
        /// </summary>
        public int ParentChildItemIndex { get; private set; }
        /// <summary>
        /// The new rating value. (rating can be 1-5, other values means no rating)
        /// </summary>
        public int NewRating { get; private set; }
        /// <summary>
        /// The old rating value. (rating can be 1-5, other values means no rating)
        /// </summary>
        public int OldRating { get; private set; }
        /// <summary>
        /// Get or set if the rating change should be canceled or not.
        /// </summary>
        public bool Cancel { get; set; }
    }
}
