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
    /// Managed ListView Item.
    /// </summary>
    public class MLVItem : IMLVElement
    {
        /// <summary>
        /// Managed ListView Item.
        /// </summary>
        public MLVItem() : base()
        {
            children = new MLVChildItemsCollection(this);
            subitems = new MLVSubItemsCollection(this);
            text = "";
            drawMode = MLVItemDrawMode.Text;
            Index = -1;
            imageIndex = -1;
            collabsed = true;
        }
        /// <summary>
        /// Managed ListView Item.
        /// </summary>
        /// <param name="text">The item text.</param>
        public MLVItem(string text) : base()
        {
            children = new MLVChildItemsCollection(this);
            subitems = new MLVSubItemsCollection(this);
            this.text = text;
            drawMode = MLVItemDrawMode.Text;
            Index = -1;
            imageIndex = -1;
            collabsed = true;
        }
        /// <summary>
        /// Managed ListView Item.
        /// </summary>
        /// <param name="text">The item text.</param>
        /// <param name="imageIndex">The item image index.</param>
        public MLVItem(string text, int imageIndex) : base()
        {
            children = new MLVChildItemsCollection(this);
            subitems = new MLVSubItemsCollection(this);
            this.text = text;
            drawMode = MLVItemDrawMode.Text;
            Index = -1;
            this.imageIndex = imageIndex;
            collabsed = true;
        }
        /// <summary>
        /// Managed ListView Item.
        /// </summary>
        /// <param name="text">The item text.</param>
        /// <param name="imageIndex">The item image index.</param>
        /// <param name="drawMode">The item draw mode.</param>
        public MLVItem(string text, int imageIndex, MLVItemDrawMode drawMode) : base()
        {
            children = new MLVChildItemsCollection(this);
            subitems = new MLVSubItemsCollection(this);
            this.text = text;
            this.drawMode = drawMode;
            Index = -1;
            imageIndex = -1;
            this.imageIndex = imageIndex;
            collabsed = true;
        }

        private MLVPanel owner;
        private MLVChildItemsCollection children;
        private MLVSubItemsCollection subitems;
        private MLVItemDrawMode drawMode;
        private string text;
        private int imageIndex;
        private bool collabsed;
        private bool selected;
        private bool useCustomTextColor;
        private Color customTextColor;

        // Properties
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
                    if (owner != null)
                    {
                        owner.OnItemTextChanged(this);
                    }
                }
            }
        }
        /// <summary>
        /// Get the item index within the items collection.
        /// </summary>
        public int Index
        {
            get; internal set;
        }
        /// <summary>
        /// Get the child items collection. (USED ONLY ON DETAILS MODE).
        /// </summary>
        public MLVChildItemsCollection ChildItems
        {
            get { return children; }
        }
        /// <summary>
        /// Get the sub items collection.
        /// </summary>
        public MLVSubItemsCollection SubItems
        {
            get { return subitems; }
        }
        /// <summary>
        /// Get or set the draw mode of the item. (On Details mode: only Image will be rendered whatever the mode selected 
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
                    if (owner != null)
                    {
                        owner.OnItemDrawModeChanged(this);
                    }
                }
            }
        }
        /// <summary>
        /// Get or set the image index within the ItemsImageList of this item.
        /// </summary>
        public int ImageIndex
        {
            get { return imageIndex; }
            set
            {
                if (imageIndex != value)
                {
                    imageIndex = value;
                    if (owner != null)
                    {
                        owner.OnItemImageIndexChanged(this);
                    }
                }
            }
        }
        /// <summary>
        /// Get if this item have child items (CALCULATED)
        /// </summary>
        public bool HasChildItems
        {
            get
            {
                if (children != null)
                    return children.Count > 0;
                return false;
            }
        }
        /// <summary>
        /// Get or set if the child items are collabsed or not (child items visible or not).
        /// </summary>
        public bool ChildItemsCollabsed
        {
            get { return collabsed; }
            set
            {
                if (collabsed != value)
                {
                    collabsed = value;
                    if (owner != null)
                        owner.OnItemCollabseChanged(this);
                }
            }
        }
        /// <summary>
        /// Get or set if this item is selected or not.
        /// </summary>
        public bool Selected
        {
            get { return selected; }
            set
            {
                if (selected != value)
                {
                    selected = value;
                    if (owner != null)
                        owner.OnItemSelectionChanged(this);
                }
            }
        }
        /// <summary>
        /// Get or set if this item should use a custom color specified by CustomTextColor instead of the MLV control ItemTextColor.
        /// </summary>
        public bool UseCustomTextColor
        {
            get { return useCustomTextColor; }
            set
            {
                if (useCustomTextColor != value)
                {
                    useCustomTextColor = value;
                    if (owner != null)
                    {
                        owner.OnItemUseCustomTextColorChanged(this);
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
                    if (owner != null)
                    {
                        owner.OnItemCustomTextColorChanged(this);
                    }
                }
            }
        }
        // Methods
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
        internal void SetOwner(MLVPanel owner)
        {
            this.owner = owner;
        }
        internal void OnChildItemAdded(MLVChildItem item)
        {
            if (owner != null)
            {
                item.SetParent(this);
                owner.OnChildItemAdded(item);
            }
        }
        internal void OnChildItemInserted(MLVChildItem item, int index)
        {
            if (owner != null)
            {
                item.SetParent(this);
                owner.OnChildItemInserted(item, index);
            }
        }
        internal void OnChildItemRemove(MLVChildItem item, int index)
        {
            if (owner != null)
                owner.OnChildItemRemove(item, index);
        }
        internal void OnChildItemsClear()
        {
            if (owner != null)
                owner.OnChildItemsClear(this);
        }
        internal void OnChildItemDrawModeChanged(MLVChildItem item)
        {
            if (owner != null)
                owner.OnChildItemDrawModeChanged(item);
        }
        internal void OnChildItemTextChanged(MLVChildItem item)
        {
            if (owner != null)
                owner.OnChildItemTextChanged(item);
        }
        internal void OnChildItemImageIndexChanged(MLVChildItem item)
        {
            if (owner != null)
                owner.OnChildItemImageIndexChanged(item);
        }
        internal void OnChildItemSelectionChanged(MLVChildItem item)
        {
            if (owner != null)
                owner.OnChildItemSelectionChanged(item);
        }
        internal void OnChildItemUseCustomTextColorChanged(MLVChildItem item)
        {
            if (owner != null)
                owner.OnChildItemUseCustomTextColorChanged(item);
        }
        internal void OnChildItemCustomTextColorChanged(MLVChildItem item)
        {
            if (owner != null)
                owner.OnChildItemCustomTextColorChanged(item);
        }
        internal void OnSubItemAdded(MLVSubItem item)
        {
            item.SetParent(this);
            NotifyPanelOnSubItemAdded(item);
        }
        internal void OnSubItemInserted(MLVSubItem item, int index)
        {
            item.SetParent(this);
            NotifyPanelOnSubItemInserted(item, index);
        }
        internal void OnSubItemRemove(MLVSubItem item, int index)
        {
            NotifyPanelOnSubItemRemove(item, index);
        }
        internal void OnSubItemsClear()
        {
            NotifyPanelOnSubItemsClear(this);
        }
        internal void OnSubItemDrawModeChanged(MLVSubItem item)
        {
            NotifyPanelOnSubItemDrawModeChanged(item);
        }
        internal void OnSubItemTextChanged(MLVSubItem item)
        {
            NotifyPanelOnSubItemTextChanged(item);
        }
        internal void OnSubItemImageIndexChanged(MLVSubItem item)
        {
            NotifyPanelOnSubItemImageIndexChanged(item);
        }
        internal void OnSubItemUseCustomTextColorChanged(MLVSubItem item)
        {
            NotifyPanelOnSubItemUseCustomTextColorChanged(item);
        }
        internal void OnSubItemCustomTextColorChanged(MLVSubItem item)
        {
            NotifyPanelOnSubItemCustomTextColorChanged(item);
        }
        internal void OnRatingSubItemRatingChanged(MLVRatingSubItem item)
        {
            NotifyPanelOnRatingSubItemRatingChanged(item);
        }
        internal void NotifyPanelOnSubItemAdded(MLVSubItem item)
        {
            if (owner != null)
            {
                owner.OnSubItemAdded(item);
            }
        }
        internal void NotifyPanelOnSubItemInserted(MLVSubItem item, int index)
        {
            if (owner != null)
            {
                owner.OnSubItemInserted(item, index);
            }
        }
        internal void NotifyPanelOnSubItemRemove(MLVSubItem item, int index)
        {
            if (owner != null)
            {
                owner.OnSubItemRemove(item, index);
            }
        }
        internal void NotifyPanelOnSubItemsClear(IMLVElement parentItem)
        {
            if (owner != null)
            {
                owner.OnSubItemsClear(parentItem);
            }
        }
        internal void NotifyPanelOnSubItemDrawModeChanged(MLVSubItem item)
        {
            if (owner != null)
            {
                owner.OnSubItemDrawModeChanged(item);
            }
        }
        internal void NotifyPanelOnSubItemTextChanged(MLVSubItem item)
        {
            if (owner != null)
            {
                owner.OnSubItemTextChanged(item);
            }
        }
        internal void NotifyPanelOnSubItemImageIndexChanged(MLVSubItem item)
        {
            if (owner != null)
            {
                owner.OnSubItemImageIndexChanged(item);
            }
        }
        internal void NotifyPanelOnRatingSubItemRatingChanged(MLVRatingSubItem item)
        {
            if (owner != null)
            {
                owner.OnRatingSubItemRatingChanged(item);
            }
        }
        internal void NotifyPanelOnSubItemUseCustomTextColorChanged(MLVSubItem item)
        {
            if (owner != null)
            {
                owner.OnSubItemUseCustomTextColorChanged(item);
            }
        }
        internal void NotifyPanelOnSubItemCustomTextColorChanged(MLVSubItem item)
        {
            if (owner != null)
            {
                owner.OnSubItemCustomTextColorChanged(item);
            }
        }
    }
}
