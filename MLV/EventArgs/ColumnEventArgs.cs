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
    /// Event Args for column events.
    /// </summary>
    public class ColumnEventArgs : EventArgs
    {
        /// <summary>
        /// Event Args for column events.
        /// </summary>
        /// <param name="index">The column index</param>
        /// <param name="id">The column id</param>
        public ColumnEventArgs(int index, string id)
        {
            ColumnIndex = index;
            ColumnID = id;
        }
        /// <summary>
        /// Get the column index.
        /// </summary>
        public int ColumnIndex { get; private set; }
        /// <summary>
        /// Get the column id.
        /// </summary>
        public string ColumnID { get; private set; }
    }
}
