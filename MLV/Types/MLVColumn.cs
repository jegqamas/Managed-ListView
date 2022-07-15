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
    /// Managed ListView Column.
    /// </summary>
    public class MLVColumn : IMLVElement
    {
        /// <summary>
        /// Managed ListView Column.
        /// </summary>
        /// <param name="id">The column id.</param>
        public MLVColumn(string id)
            : base(id)
        {
            Width = 75;
        }
        /// <summary>
        /// Managed ListView Column.
        /// </summary>
        /// <param name="id">The column id.</param>
        /// <param name="text">The column text to show to user.</param>
        public MLVColumn(string id, string text)
         : base(id)
        {
            Width = 75;
            Text = text;
        }
        /// <summary>
        /// Managed ListView Column.
        /// </summary>
        /// <param name="id">The column id.</param>
        /// <param name="text">The column text to show to user.</param>
        /// <param name="width">The column width in pixels.</param>
        public MLVColumn(string id, string text, int width)
         : base(id)
        {
            Width = width;
            Text = text;
        }
        /// <summary>
        /// Get or set the width of this column
        /// </summary>
        public int Width
        { get; set; }
        /// <summary>
        /// Get or set the text, the name that will be shown for the user, of this column.
        /// </summary>
        public string Text
        { get; set; }
    }
}
