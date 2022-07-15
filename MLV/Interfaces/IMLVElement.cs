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
    /// Managed ListView element
    /// </summary>
    public abstract class IMLVElement
    {
        /// <summary>
        /// Managed ListView element
        /// </summary>
        public IMLVElement()
        {
            ID = "";
            Name = "";
        }
        /// <summary>
        /// Managed ListView element
        /// </summary>
        /// <param name="id">The element id</param>
        public IMLVElement(string id)
        {
            ID = id;
            Name = "";
        }
        /// <summary>
        /// Managed ListView element
        /// </summary>
        /// <param name="id">The element id</param>
        /// <param name="name">The element name</param>
        public IMLVElement(string id, string name)
        {
            ID = id;
            Name = name;
        }
        /// <summary>
        /// Get or set the name of this element.
        /// </summary>
        public string Name
        { get; set; }
        /// <summary>
        /// Get or set the id of this element.
        /// </summary>
        public string ID
        { get; set; }
        /// <summary>
        /// Get or set tag object, which can be used to store temperoray data.
        /// </summary>
        public object Tag
        { get; set; }
        /// <summary>
        /// Get or set the object id for this item.
        /// </summary>
        internal string OID
        {
            get; set;
        }
    }
}
