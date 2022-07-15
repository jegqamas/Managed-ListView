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
using System.Drawing;
namespace MLV
{
    class SubItemObject
    {
        public SubItemObject()
        {
            Text = "";
            ID = "";
            ParentOID = "";

            Mode = MLVItemDrawMode.Text;

            IsRatingSubItem = false;
            Rating = -1;

            UseCustomTextColor = false;
            CustomTextColor = Color.Black;
        }
        public string Text;
        public string ID;
        public MLVItemDrawMode Mode;
        public string ParentOID;

        /// <summary>
        /// Only for rating sub item
        /// </summary>
        public int Rating;
        /// <summary>
        /// Indicates if this object is for rating subitem or not.
        /// </summary>
        public bool IsRatingSubItem;
        /// <summary>
        /// Indicates if this object should use a custom color for text specified by CustomTextColor instead of ItemTextColor of the MLV control.
        /// </summary>
        public bool UseCustomTextColor;
        /// <summary>
        /// The custom color to use for this object text instead of ItemTextColor of the MLV control.
        /// </summary>
        public Color CustomTextColor;
    }
}
