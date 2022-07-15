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
namespace MLV
{
    /// <summary>
    /// Managed ListView Rating SubItem.
    /// </summary>
    public class MLVRatingSubItem : MLVSubItem
    {
        /// <summary>
        /// Managed ListView Rating SubItem.
        /// </summary>
        /// <param name="id">The column id</param>
        public MLVRatingSubItem(string id) : base(id)
        {
            rating = -1;
        }
        /// <summary>
        /// Managed ListView Rating SubItem.
        /// </summary>
        /// <param name="id">The column id</param>
        /// <param name="rating">Rating value. (rating can be 1-5, other values means no rating)</param>
        public MLVRatingSubItem(string id, int rating) : base(id)
        {
            this.rating = rating;
        }
        /// <summary>
        /// Managed ListView Rating SubItem.
        /// </summary>
        /// <param name="id">The column id</param>
        /// <param name="parent">The parent item/child item</param>
        public MLVRatingSubItem(string id, IMLVElement parent) : base(id, parent)
        {
            rating = -1;
        }
        /// <summary>
        /// Managed ListView Rating SubItem.
        /// </summary>
        /// <param name="id">The column id</param>
        /// <param name="parent">The parent item/child item</param>
        /// <param name="rating">Rating value. (rating can be 1-5, other values means no rating)</param>
        public MLVRatingSubItem(string id, IMLVElement parent, int rating) : base(id, parent)
        {
            this.rating = rating;
        }

        private int rating;

        /// <summary>
        /// Rating value. (rating can be 1-5, other values means no rating)
        /// </summary>
        public int Rating
        {
            get { return rating; }
            set
            {
                if (rating != value)
                {
                    rating = value;
                    if (parent != null)
                    {
                        if (parent is MLVItem)
                            ((MLVItem)parent).OnRatingSubItemRatingChanged(this);
                        else if (parent is MLVChildItem)
                            ((MLVChildItem)parent).OnRatingSubItemRatingChanged(this);
                    }
                }
            }
        }
    }
}
