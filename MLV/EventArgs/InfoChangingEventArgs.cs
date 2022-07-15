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
    /// Event args for info changing events.
    /// </summary>
    public class InfoChangingEventArgs : EventArgs
    {
        /// <summary>
        /// Event args for info changing events.
        /// </summary>
        /// <param name="oldValue">The old value that the info will be changed from.</param>
        /// <param name="newValue">The new value that the info will be changed into.</param>
        public InfoChangingEventArgs(object oldValue, object newValue)
        {
            NewValue = newValue;
            OldValue = oldValue;
        }
        /// <summary>
        /// Get the new value that the info will be changed into.
        /// </summary>
        public object NewValue { get; private set; }
        /// <summary>
        /// Get the old value that the info will be changed from.
        /// </summary>
        public object OldValue { get; private set; }
        /// <summary>
        /// Get or set if the info changing should be canceled.
        /// </summary>
        public bool Cancel { get; set; }
    }
}
