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
    /// Event args can be used for tooltip show events.
    /// </summary>
    public class ShowTooltipEventArgs : EventArgs
    {
        /// <summary>
        /// Event args can be used for tooltip show events.
        /// </summary>
        /// <param name="textToShow">The tooltip text to show.</param>
        public ShowTooltipEventArgs(string textToShow)
        {
            TextToShow = textToShow;
            Point = new System.Drawing.Point();
        }
        /// <summary>
        /// Event args can be used for tooltip show events.
        /// </summary>
        /// <param name="textToShow">The tooltip text to show.</param>
        /// <param name="point">The location of the tooltip</param>
        public ShowTooltipEventArgs(string textToShow, Point point)
        {
            TextToShow = textToShow;
            Point = point;
        }
        /// <summary>
        /// Get the tooltip text to show.
        /// </summary>
        public string TextToShow { get; set; }
        /// <summary>
        /// Get the location of the tooltip
        /// </summary>
        public Point Point { get; set; }
        /// <summary>
        /// Get or set if the tooltip show should be canceled or not.
        /// </summary>
        public bool Cancel { get; set; }
    }
}
