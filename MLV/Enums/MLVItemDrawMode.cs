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
    /// Determines the draw mode of an item, a child item or a sub item.
    /// </summary>
    public enum MLVItemDrawMode
    {
        /// <summary>
        /// Only render the text of the item/child item/sub item.
        /// </summary>
        Text = 0,
        /// <summary>
        /// Only render the image of the item/child item/sub item.
        /// </summary>
        Image = 1,
        /// <summary>
        /// Render the text and the image of the item/child item/sub item.
        /// </summary>
        TextImage = 2,
        /// <summary>
        /// Render the text and the image of the item/child item/sub item, depending on user settings (draw event event will be raised, to determine the text and the image).
        /// </summary>
        User = 4
    }
}
