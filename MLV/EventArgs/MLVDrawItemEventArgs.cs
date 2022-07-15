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
using System.Drawing;

namespace MLV
{
    /// <summary>
    /// Event args can be used for draw item/child item events.
    /// </summary>
    public class MLVDrawItemEventArgs : EventArgs
    {
        /// <summary>
        /// Event args can be used for draw item/child item events.
        /// </summary>
        /// <param name="index">The index of the item/child item/sub item.</param>
        /// <param name="textToDraw">The text to draw.</param>
        /// <param name="imageToDraw">The image to draw.</param>
        /// <param name="useCustomTextColor">Indicates if the control should use a custom color specified by CustomTextColor instead of MLV control ItemTextColor.</param>
        /// <param name="customTextColor">The color to use for the item text instead of MLV control ItemTextColor.</param>
        public MLVDrawItemEventArgs(int index, string textToDraw, Image imageToDraw, bool useCustomTextColor, Color customTextColor)
        {
            Index = index;
            TextToDraw = textToDraw;
            ImageToDraw = imageToDraw;
            UseCustomTextColor = useCustomTextColor;
            CustomTextColor = customTextColor;
            IsChildItem = false;
        }
        /// <summary>
        /// Get or set the text to draw.
        /// </summary>
        public string TextToDraw { get; set; }
        /// <summary>
        /// Get or set if the control should use a custom color specified by CustomTextColor instead of MLV control ItemTextColor.
        /// </summary>
        public bool UseCustomTextColor { get; set; }
        /// <summary>
        /// Get or set the color to use for the item text instead of MLV control ItemTextColor.
        /// </summary>
        public Color CustomTextColor { get; set; }
        /// <summary>
        /// Get or set the image to draw.
        /// </summary>
        public Image ImageToDraw { get; set; }
        /// <summary>
        /// Get or set if the control should use default item properties (cancel the user draw and use TextImage mode).
        /// </summary>
        public bool UseDefaults { get; set; }
        /// <summary>
        /// Get the index of the item/child item/sub item.
        /// </summary>
        public int Index { get; protected set; }
        /// <summary>
        /// Get if this event is for a ChildItem.
        /// </summary>
        public bool IsChildItem { get; internal set; }
    }
}
