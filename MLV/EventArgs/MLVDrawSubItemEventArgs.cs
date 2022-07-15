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
    /// <summary>
    /// Event args for draw sub item events.
    /// </summary>
    public class MLVDrawSubItemEventArgs : MLVDrawItemEventArgs
    {
        /// <summary>
        /// Event args for draw sub item events.
        /// </summary>
        /// <param name="index">The index of the sub item.</param>
        /// <param name="columnID">The id of the column (column id = sub item id)</param>
        /// <param name="textToDraw">The text to draw.</param>
        /// <param name="imageToDraw">The image to draw.</param>
        /// <param name="useCustomTextColor">Indicates if the control should use a custom color specified by CustomTextColor instead of MLV control ItemTextColor.</param>
        /// <param name="customTextColor">The color to use for the sub item text instead of MLV control ItemTextColor.</param>
        public MLVDrawSubItemEventArgs(int index, string columnID, string textToDraw, Image imageToDraw, bool useCustomTextColor, Color customTextColor) : base(index, textToDraw, imageToDraw, useCustomTextColor, customTextColor)
        {
            ID = columnID;
        }
        /// <summary>
        /// Get the id of the column (column id = sub item id)
        /// </summary>
        public string ID { get; private set; }
    }
}
