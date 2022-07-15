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
    /// Managed ListView Sub Item.
    /// </summary>
    public class MLVSubItem : IMLVElement
    {
        /// <summary>
        /// Managed ListView Sub Item.
        /// </summary>
        /// <param name="id">The column id</param>
        public MLVSubItem(string id) : base(id)
        {
            text = "";
            drawMode = MLVItemDrawMode.Text;
            imageIndex = -1;
            useCustomTextColor = false;
            customTextColor = Color.Black;
        }
        /// <summary>
        /// Managed ListView Sub Item.
        /// </summary>
        /// <param name="id">The column id</param>
        /// <param name="text">The sub item text</param>
        public MLVSubItem(string id, string text) : base(id)
        {
            this.text = text;
            drawMode = MLVItemDrawMode.Text;
            imageIndex = -1;
            useCustomTextColor = false;
            customTextColor = Color.Black;
        }
        /// <summary>
        /// Managed ListView Sub Item.
        /// </summary>
        /// <param name="id">The column id</param>
        /// <param name="text">The sub item text</param>
        /// <param name="imageIndex">The image index for this sub item.</param>
        public MLVSubItem(string id, string text, int imageIndex) : base(id)
        {
            this.text = text;
            drawMode = MLVItemDrawMode.Text;
            this.imageIndex = imageIndex;
            useCustomTextColor = false;
            customTextColor = Color.Black;
        }
        /// <summary>
        /// Managed ListView Sub Item.
        /// </summary>
        /// <param name="id">The column id</param>
        /// <param name="text">The sub item text</param>
        /// <param name="imageIndex">The image index for this sub item.</param>
        /// <param name="drawMode">The draw mode for this sub item.</param>
        public MLVSubItem(string id, string text, int imageIndex, MLVItemDrawMode drawMode) : base(id)
        {
            this.text = text;
            this.drawMode = drawMode;
            this.imageIndex = imageIndex;
            useCustomTextColor = false;
            customTextColor = Color.Black;
        }
        /// <summary>
        /// Managed ListView Sub Item.
        /// </summary>
        /// <param name="id">The column id</param>
        /// <param name="parent">The parent item/child item.</param>
        public MLVSubItem(string id, IMLVElement parent) : base(id)
        {
            this.parent = parent;
            text = "";
            drawMode = MLVItemDrawMode.Text;
            imageIndex = -1;
            useCustomTextColor = false;
            customTextColor = Color.Black;
        }
        /// <summary>
        /// Managed ListView Sub Item.
        /// </summary>
        /// <param name="id">The column id</param>
        /// <param name="parent">The parent item/child item.</param>
        /// <param name="text">The sub item text</param>
        public MLVSubItem(string id, IMLVElement parent, string text) : base(id)
        {
            this.parent = parent;
            this.text = text;
            drawMode = MLVItemDrawMode.Text;
            imageIndex = -1;
            useCustomTextColor = false;
            customTextColor = Color.Black;
        }
        /// <summary>
        /// Managed ListView Sub Item.
        /// </summary>
        /// <param name="id">The column id</param>
        /// <param name="parent">The parent item/child item.</param>
        /// <param name="text">The sub item text</param>
        /// <param name="imageIndex">The image index for this sub item.</param>
        public MLVSubItem(string id, IMLVElement parent, string text, int imageIndex) : base(id)
        {
            this.parent = parent;
            this.text = text;
            drawMode = MLVItemDrawMode.Text;
            this.imageIndex = imageIndex;
            useCustomTextColor = false;
            customTextColor = Color.Black;
        }
        /// <summary>
        /// Managed ListView Sub Item.
        /// </summary>
        /// <param name="id">The column id</param>
        /// <param name="parent">The parent item/child item.</param>
        /// <param name="text">The sub item text</param>
        /// <param name="imageIndex">The image index for this sub item.</param>
        /// <param name="drawMode">The draw mode for this sub item.</param>
        public MLVSubItem(string id, IMLVElement parent, string text, int imageIndex, MLVItemDrawMode drawMode) : base(id)
        {
            this.parent = parent;
            this.text = text;
            this.drawMode = drawMode;
            this.imageIndex = imageIndex;
            useCustomTextColor = false;
            customTextColor = Color.Black;
        }

        /// <summary>
        /// The parent item/child item.
        /// </summary>
        protected IMLVElement parent;
        private MLVItemDrawMode drawMode;
        private string text;
        private int imageIndex;
        private bool useCustomTextColor;
        private Color customTextColor;

        /// <summary>
        /// Get or set the text, the name that will be shown for the user, of this sub item.
        /// </summary>
        public string Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    if (parent != null)
                    {
                        if (parent is MLVItem)
                            ((MLVItem)parent).OnSubItemTextChanged(this);
                        else if (parent is MLVChildItem)
                            ((MLVChildItem)parent).OnSubItemTextChanged(this);
                    }
                }
            }
        }
        /// <summary>
        /// Get or set the image index of this sub item.
        /// </summary>
        public int ImageIndex
        {
            get { return imageIndex; }
            set
            {
                if (imageIndex != value)
                {
                    imageIndex = value;
                    if (parent != null)
                    {
                        if (parent is MLVItem)
                            ((MLVItem)parent).OnSubItemImageIndexChanged(this);
                        else if (parent is MLVChildItem)
                            ((MLVChildItem)parent).OnSubItemImageIndexChanged(this);
                    }
                }
            }
        }
        /// <summary>
        /// Get or set if this sub item should use a custom color specified by CustomTextColor instead of the MLV control ItemTextColor.
        /// </summary>
        public bool UseCustomTextColor
        {
            get { return useCustomTextColor; }
            set
            {
                if (useCustomTextColor != value)
                {
                    useCustomTextColor = value;
                    if (parent != null)
                    {
                        if (parent is MLVItem)
                            ((MLVItem)parent).OnSubItemUseCustomTextColorChanged(this);
                        else if (parent is MLVChildItem)
                            ((MLVChildItem)parent).OnSubItemUseCustomTextColorChanged(this);
                    }
                }
            }
        }
        /// <summary>
        /// Get or set the custom color that should be used instead of MLV control ItemTextColor (UseCustomTextColor must be set).
        /// </summary>
        public Color CustomTextColor
        {
            get { return customTextColor; }
            set
            {
                if (customTextColor != value)
                {
                    customTextColor = value;
                    if (parent != null)
                    {
                        if (parent is MLVItem)
                            ((MLVItem)parent).OnSubItemCustomTextColorChanged(this);
                        else if (parent is MLVChildItem)
                            ((MLVChildItem)parent).OnSubItemCustomTextColorChanged(this);
                    }
                }
            }
        }
        /// <summary>
        /// Get or set the draw mode of the sub item
        /// </summary>
        public MLVItemDrawMode DrawMode
        {
            get { return drawMode; }
            set
            {
                if (drawMode != value)
                {
                    drawMode = value;
                    if (parent != null)
                    {
                        if (parent is MLVItem)
                            ((MLVItem)parent).OnSubItemDrawModeChanged(this);
                        else if (parent is MLVChildItem)
                            ((MLVChildItem)parent).OnSubItemDrawModeChanged(this);
                    }
                }
            }
        }
        /// <summary>
        /// Get the sub item index within the parent item/child item subitems collection.
        /// </summary>
        public int Index
        {
            get; internal set;
        }
        /// <summary>
        /// Get the parent item/child item of this subitem. The parent either MLVItem or MLVChildItem.
        /// </summary>
        public IMLVElement Parent
        {
            get { return parent; }
        }

        internal void SetParent(IMLVElement item)
        {
            if (parent != item)
                parent = item;
        }
    }
}
