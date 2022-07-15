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
using System.Drawing;

namespace MLV
{
    class ItemLineObject
    {
        public ItemLineObject()
        {
            Text = "";
            OID = "";
            IsChild = false;
            Index = -1;
            ParentItemIndex = -1;
            ParentItemOID = "";
            Mode = MLVItemDrawMode.Text;
            SubItemsObjects = new List<SubItemObject>();
            HasChildren = false;
            Collabsed = false;
            Selected = false;
            UseCustomTextColor = false;
            CustomTextColor = Color.Black;
        }
        /// <summary>
        /// The item text to draw
        /// </summary>
        public string Text;
        /// <summary>
        /// The object item id
        /// </summary>
        public string OID;
        /// <summary>
        /// Indicates if this item is a child item or not
        /// </summary>
        public bool IsChild;
        /// <summary>
        /// The item index within the Items collection, or the child index within item childitems collection if IsCHild is set.
        /// </summary>
        public int Index;
        /// <summary>
        /// If IsChild is set, this is the parent item index within the Items collection.
        /// </summary>
        public int ParentItemIndex;
        /// <summary>
        /// If IsChild is set, this is the parent item id within the Items collection.
        /// </summary>
        public string ParentItemOID;
        /// <summary>
        /// Get the sub item objects. The objects here must be arranged as same as the columns order.
        /// </summary>
        public List<SubItemObject> SubItemsObjects;
        /// <summary>
        /// The item/child item draw mode.
        /// </summary>
        public MLVItemDrawMode Mode;

        /// <summary>
        /// Indicates if the item is selected or not.
        /// </summary>
        public bool Selected;
        /// <summary>
        /// Indicates if this item has child items or not. (IsChild must not be set)
        /// </summary>
        public bool HasChildren;
        /// <summary>
        /// Indicates if the item collabsed (HasChildren must be set and IsChild must not be set)
        /// </summary>
        public bool Collabsed;
        /// <summary>
        /// Used with thumbnails mode to draw the image.
        /// </summary>
        public Rectangle ImageRectangle;
        /// <summary>
        /// Used with thumbnails mode to draw the text.
        /// </summary>
        public Rectangle TextRectangle;
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
