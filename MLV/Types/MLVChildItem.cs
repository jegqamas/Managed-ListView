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
    /// Managed ListView Child Item.
    /// </summary>
    public class MLVChildItem : IMLVElement
    {
        /// <summary>
        /// Managed ListView Child Item.
        /// </summary>
        public MLVChildItem() : base()
        {
            subitems = new MLVSubItemsCollection(this);
            text = "";
            drawMode = MLVItemDrawMode.Text;
            imageIndex = -1;
        }
        /// <summary>
        /// Managed ListView Child Item.
        /// </summary>
        /// <param name="text">The child item text.</param>
        public MLVChildItem(string text) : base()
        {
            subitems = new MLVSubItemsCollection(this);
            this.text = text;
            drawMode = MLVItemDrawMode.Text;
            imageIndex = -1;
        }
        /// <summary>
        /// Managed ListView Child Item.
        /// </summary>
        /// <param name="text">The child item text.</param>
        /// <param name="imageIndex">The image index to use for this child item.</param>
        public MLVChildItem(string text, int imageIndex) : base()
        {
            subitems = new MLVSubItemsCollection(this);
            this.text = text;
            drawMode = MLVItemDrawMode.Text;
            this.imageIndex = imageIndex;
        }
        /// <summary>
        /// Managed ListView Child Item.
        /// </summary>
        /// <param name="text">The child item text.</param>
        /// <param name="imageIndex">The image index to use for this child item.</param>
        /// <param name="drawMode">The draw mode to use for this child item</param>
        public MLVChildItem(string text, int imageIndex, MLVItemDrawMode drawMode) : base()
        {
            subitems = new MLVSubItemsCollection(this);
            this.text = text;
            this.drawMode = drawMode;
            this.imageIndex = imageIndex;
        }
        /// <summary>
        ///  Managed ListView Child Item.
        /// </summary>
        /// <param name="parent">The parent  Managed ListView Item.</param>
        public MLVChildItem(MLVItem parent) : base()
        {
            subitems = new MLVSubItemsCollection(this);
            this.parent = parent;
            text = "";
            drawMode = MLVItemDrawMode.Text;
            imageIndex = -1;
        }
        /// <summary>
        ///  Managed ListView Child Item.
        /// </summary>
        /// <param name="parent">The parent  Managed ListView Item.</param>
        /// <param name="text">The child item text.</param>
        public MLVChildItem(MLVItem parent, string text) : base()
        {
            subitems = new MLVSubItemsCollection(this);
            this.parent = parent;
            this.text = text;
            drawMode = MLVItemDrawMode.Text;
            imageIndex = -1;
        }
        /// <summary>
        ///  Managed ListView Child Item.
        /// </summary>
        /// <param name="parent">The parent  Managed ListView Item.</param>
        /// <param name="text">The child item text.</param>
        /// <param name="imageIndex">The image index to use for this child item.</param>
        public MLVChildItem(MLVItem parent, string text, int imageIndex) : base()
        {
            subitems = new MLVSubItemsCollection(this);
            this.parent = parent;
            this.text = text;
            drawMode = MLVItemDrawMode.Text;
            this.imageIndex = imageIndex;
        }
        /// <summary>
        ///  Managed ListView Child Item.
        /// </summary>
        /// <param name="parent">The parent  Managed ListView Item.</param>
        /// <param name="text">The child item text.</param>
        /// <param name="imageIndex">The image index to use for this child item.</param>
        /// <param name="drawMode">The draw mode to use for this child item</param>
        public MLVChildItem(MLVItem parent, string text, int imageIndex, MLVItemDrawMode drawMode) : base()
        {
            subitems = new MLVSubItemsCollection(this);
            this.parent = parent;
            this.text = text;
            this.drawMode = drawMode;
            this.imageIndex = imageIndex;
        }

        private MLVItem parent;
        private MLVSubItemsCollection subitems;
        private MLVItemDrawMode drawMode;
        private string text;
        private int imageIndex;
        private bool selected;
        private bool useCustomTextColor;
        private Color customTextColor;

        /// <summary>
        /// Get the sub items collection
        /// </summary>
        public MLVSubItemsCollection SubItems
        {
            get { return subitems; }
        }
        /// <summary>
        /// Get or set the text, the name that will be shown for the user, of this item (not used in details mode).
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
                        parent.OnChildItemTextChanged(this);
                    }
                }
            }
        }
        /// <summary>
        /// Get or set the draw mode of the child item. (On Details mode: only Image will be rendered whatever the mode selected 
        /// except for the User draw mode. In the User draw mode, only image will be used as well).
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
                        parent.OnChildItemDrawModeChanged(this);
                    }
                }
            }
        }
        /// <summary>
        /// Get the child item index within the child items collection of the parent item.
        /// </summary>
        public int Index
        {
            get; internal set;
        }
        /// <summary>
        /// Get the parent item
        /// </summary>
        public MLVItem Parent
        { get { return parent; } }
        /// <summary>
        /// Get or set the image index of this child item.
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
                        parent.OnChildItemImageIndexChanged(this);
                    }
                }
            }
        }
        /// <summary>
        /// Get or set if this child item is selected or not.
        /// </summary>
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (selected != value)
                {
                    selected = value;
                    if (parent != null)
                        parent.OnChildItemSelectionChanged(this);
                }
            }
        }
        /// <summary>
        /// Get or set if this child item should use a custom color specified by CustomTextColor instead of the MLV control ItemTextColor.
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
                        parent.OnChildItemUseCustomTextColorChanged(this);
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
                        parent.OnChildItemCustomTextColorChanged(this);
                    }
                }
            }
        }

        /// <summary>
        /// Get a sub item using id.
        /// </summary>
        /// <param name="id">The id of the sub item. This id should match the column id.</param>
        /// <returns>The sub item if found otherwise null.</returns>
        public MLVSubItem GetSubItem(string id)
        {
            foreach (MLVSubItem sub in subitems)
            {
                if (sub.ID == id)
                    return sub;
            }
            return null;
        }
        /*Neccessary internal helper methods*/
        internal void SetParent(MLVItem item)
        {
            if (parent != item)
                parent = item;
        }
        internal void OnSubItemAdded(MLVSubItem item)
        {
            item.SetParent(this);
            if (parent != null)
                parent.NotifyPanelOnSubItemAdded(item);
        }
        internal void OnSubItemInserted(MLVSubItem item, int index)
        {
            item.SetParent(this);
            if (parent != null)
                parent.NotifyPanelOnSubItemInserted(item, index);
        }
        internal void OnSubItemRemove(MLVSubItem item, int index)
        {
            if (parent != null)
                parent.NotifyPanelOnSubItemRemove(item, index);
        }
        internal void OnSubItemsClear()
        {
            if (parent != null)
                parent.NotifyPanelOnSubItemsClear(this);
        }
        internal void OnSubItemDrawModeChanged(MLVSubItem item)
        {
            if (parent != null)
                parent.NotifyPanelOnSubItemDrawModeChanged(item);
        }
        internal void OnSubItemTextChanged(MLVSubItem item)
        {
            if (parent != null)
                parent.NotifyPanelOnSubItemTextChanged(item);
        }
        internal void OnSubItemImageIndexChanged(MLVSubItem item)
        {
            if (parent != null)
                parent.NotifyPanelOnSubItemImageIndexChanged(item);
        }
        internal void OnRatingSubItemRatingChanged(MLVRatingSubItem item)
        {
            if (parent != null)
                parent.NotifyPanelOnRatingSubItemRatingChanged(item);
        }
        internal void OnSubItemUseCustomTextColorChanged(MLVSubItem item)
        {
            if (parent != null)
                parent.NotifyPanelOnSubItemUseCustomTextColorChanged(item);
        }
        internal void OnSubItemCustomTextColorChanged(MLVSubItem item)
        {
            if (parent != null)
                parent.NotifyPanelOnSubItemCustomTextColorChanged(item);
        }
    }
}
