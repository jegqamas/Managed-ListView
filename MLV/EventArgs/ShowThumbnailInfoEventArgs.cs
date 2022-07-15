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
    /// Event args can be used for thumbnails info events.
    /// </summary>
    public class ShowThumbnailInfoEventArgs : EventArgs
    {
        /// <summary>
        /// Event args can be used for thumbnails info events.
        /// </summary>
        /// <param name="text">The info text to show.</param>
        public ShowThumbnailInfoEventArgs(string text)
        {
            TextToShow = text;
            Rating = -1;
        }
        /// <summary>
        /// Event args can be used for thumbnails info events.
        /// </summary>
        /// <param name="text">The info text to show.</param>
        /// <param name="rating">The info rating. Set to -1 to disable rating, values accepted 0-5</param>
        public ShowThumbnailInfoEventArgs(string text, int rating)
        {
            TextToShow = text;
            Rating = rating;
        }
        /// <summary>
        /// The info text to show.
        /// </summary>
        public string TextToShow { get; set; }
        /// <summary>
        /// The rating to show. Set to -1 to disable rating, values accepted 0-5
        /// </summary>
        public int Rating { get; set; }
        /// <summary>
        /// Get or set if the info show should be canceled.
        /// </summary>
        public bool Cancel { get; set; }
    }
}
