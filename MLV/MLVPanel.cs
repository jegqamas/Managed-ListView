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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MLV
{
    /// <summary>
    /// Managed ListView control panel.
    /// </summary>
    public partial class MLVPanel : Control
    {
        /// <summary>
        /// Managed ListView control panel.
        /// </summary>
        public MLVPanel()
        {
            InitializeComponent();
            ControlStyles flag = ControlStyles.OptimizedDoubleBuffer;
            this.SetStyle(flag, true);
            ColumnsCanBeReordered = true;
            ColumnsCanBeResized = true;
            ColumnHeightCanBeChanged = false;
            AllowDragItems = true;
            string_format = new StringFormat();
            string_format = new StringFormat(StringFormatFlags.NoWrap);
            string_format.Trimming = StringTrimming.EllipsisCharacter;

            Columns = new MLVColumnsCollection(this);
            cl_objects = new List<ColumnObject>();
            ColumnsSplitColor = Color.Black;
            ColumnTextColor = Color.Black;
            ColumnColor = Color.Silver;
            ItemHiehglightColor = ColumnHiehglightColor = Color.LightSkyBlue;
            ColumnsFont = SystemFonts.DefaultFont;
            columns_start_x = 40;
            ColumnResizingSensitivity = 3;

            // Thumbnails
            thm_blk_width = 36;
            thm_blk_height = 36;
            thm_blk_space = 3;


            // Items, child-items and sub-items
            Items = new MLVItemsCollection(this);
            item_objects = new List<ItemLineObject>();
            ItemsFont = SystemFonts.DefaultFont;
            ThumbnailsZoom = 46;
            ItemTextColor = Color.Black;
            ItemSplitLinesColor = Color.Black;
            ItemSelectionColor = Color.DodgerBlue;
            SelectionRectangleColor = Color.Blue;
            ItemCollabseAreaHeighlightColor = Color.Red;
            ItemSelectionHeighlightColor = Color.LightSkyBlue;
            // Timers
            timer_images_buffer = new Timer();
            timer_images_buffer.Interval = 50;
            timer_images_buffer.Tick += Timer_images_buffer_Tick;
            timer_set_tooltip = new Timer();
            timer_set_tooltip.Interval = 2000;
            timer_set_tooltip.Tick += Timer_set_tooltip_Tick;
            // Others
            selection_buffer = new List<string>();
            it_rating_image_width = Properties.Resources.noneRating.Width / 2;
            item_objects_images = new List<ImageObject>();
            ShowItemTooltips = true;

            string_format_thm_info = new StringFormat();
            string_format_thm_info.Trimming = StringTrimming.EllipsisCharacter;
            string_format_thm_info.Alignment = StringAlignment.Near;
        }

        private long baseID = 0;
        // General drawing stuff
        private StringFormat string_format;
        private StringFormat string_format_thm_info;
        private Point ms_current_point;
        private Point ms_down_point;
        private Point ms_current_point_as_view_port;
        private Point ms_down_point_as_view_port;
        private Timer timer_images_buffer;
        private Timer timer_set_tooltip;
        // Columns draw stuff
        private Font columns_font;
        private int columns_height;
        private Size columns_text_size;
        private int columns_min_height;
        private int columns_max_height;
        private int columns_start_x;
        private List<ColumnObject> cl_objects;
        private int cl_text_y_offset;
        private int cl_start_index;
        private int cl_end_index;
        private int cl_x1;
        private int cl_x2;
        private int cl_moved_index;
        const int cl_min_w = 25;
        private int cl_column_resized_original_x1;
        private bool IsResizingColumn;
        private bool IsChangingColumnHeight;
        private bool IsMovingColumn;
        private bool DoingColumnMoving;
        // Items draw stuff
        private Font items_default_font;
        private List<ItemLineObject> item_objects;
        private List<ImageObject> item_objects_images;
        private Size it_text_size;
        private int it_height;
        private int it_text_y_offset;
        private int it_start_index;
        private int it_end_index;
        private bool it_render_text;
        private bool it_render_image;
        private string it_text_to_render;
        private bool it_text_use_custom_color;
        private Color it_text_custom_color;
        private Image it_image_to_render;
        private int it_rating_image_width;
        private int it_temp_x;
        private int it_temp_y;
        private bool it_temp_is_rating_image;
        private int it_can_be_rendered_count;
        private int it_collabse_area_x;
        private bool it_ms_on_collabse_area;
        private bool it_drawing_selection_rectangle;
        private bool it_show_rating;
        private int it_possible_rating;
        private int it_possible_rating_it_index;
        private int it_details_cl_index;
        private Rectangle it_selection_rectangle;
        private bool surpressSelectionUpdate;
        private bool surpressClick;
        private bool items_draged;
        private string currentSearchChar;
        // Thumbnails
        private int thm_blk_width;// the block width (img area + text area)
        private int thm_blk_height;// the block height (img area + text area)
        private int thm_blk_img_area_height;// the block image area height (block height - text area)
        private int thm_blk_space;// the space between blocks
        private int thm_blks_count_row;// h blocks count
        private int thm_blks_rows_count;// total block rows count (how many rows possible)
        private int thm_blks_count_cl;// v blocks count
        //private int thm_blks_cls_count;// total block columns count (how many columns possible)
        private int thm_blk_count_total;// total blocks than can be drawn in the viewport
        private int thm_blk_x;// used for drawing. Temp block X
        private int thm_blk_y;// used for drawing. Temp block Y
        // Properties
        internal int ScrollX;
        internal int ScrollXMax;
        internal int ScrollY;
        internal int ScrollYMax;
        internal MLVColumnsCollection Columns;
        internal MLVItemsCollection Items;
        internal MLVMode Mode
        {
            get { return mode; }
            set
            {
                mode = value;
                OnResize(new EventArgs());
            }
        }
        private MLVMode mode;
        internal Font ColumnsFont
        {
            get { return columns_font; }
            set
            {
                if (columns_font != value)
                {
                    columns_font = value;
                    columns_text_size = TextRenderer.MeasureText("TEST", columns_font);
                    columns_min_height = columns_text_size.Height + 12;
                    columns_max_height = columns_min_height + 50;
                    columns_height = columns_min_height;
                    cl_text_y_offset = (columns_height / 2) - (columns_text_size.Height / 2);

                    ColumnsFontChanged?.Invoke(this, new EventArgs());
                }
            }
        }
        internal Font ItemsFont
        {
            get { return items_default_font; }
            set
            {
                if (items_default_font != value)
                {
                    items_default_font = value;
                    it_text_size = TextRenderer.MeasureText("TEST", items_default_font);
                    columns_start_x = (it_text_size.Height * 3) + 5;
                    it_height = it_text_size.Height + 12;
                    it_text_y_offset = (it_height / 2) - (it_text_size.Height / 2);
                    thm_blk_img_area_height = thm_blk_height - it_height;
                    ItemsFontChanged?.Invoke(this, new EventArgs());
                }
            }
        }
        /// <summary>
        /// Get or set the background image
        /// </summary>
        public override Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
                CalculateBackgroundBounds();
            }
        }
        internal int ThumbnailsZoom
        {
            get { return thm_blk_width; }
            set
            {
                if (thm_blk_width != value)
                {
                    thm_blk_width = value;
                    if (thm_blk_width < it_height + 25)
                        thm_blk_width = it_height + 25;
                    thm_blk_height = thm_blk_width;
                    thm_blk_img_area_height = thm_blk_height - it_height;

                    CalculateThumbnailsBlks();
                    ThumbnailsCalculateItemIndiacs();
                    StartFillImagesBuffer();
                }
            }
        }
        internal int ColumnResizingSensitivity;
        internal int HeighlightedColumnIndex;
        internal int HeighlightedItemIndex;
        internal bool ColumnHeightCanBeChanged;
        internal bool ColumnsCanBeReordered;
        internal bool ColumnsCanBeResized;
        internal bool AllowDragItems;
        internal bool ItemsSplitLines;
        internal ImageList ItemsImageList;
        internal ImageList SubItemsImageList;
        internal List<string> selection_buffer;// OIDs
        internal MLVBackgroundRenderMode BackgroundMode;
        internal bool ThumbnailsKeepImageSize;
        internal bool ShowItemTooltips;
        private Image backgroundThumbnail;
        private int backgroundDrawX;
        private int backgroundDrawY;
        private int backgroundDrawH;
        private int backgroundDrawW;
        internal bool ShowItemInfoOnThumbnailMode;

        // Colors
        internal Color ColumnsSplitColor;
        internal Color ColumnTextColor;
        internal Color ColumnColor;
        internal Color ColumnHiehglightColor;
        internal Color ItemTextColor;
        internal Color ItemSplitLinesColor;
        internal Color ItemHiehglightColor;
        internal Color ItemSelectionColor;
        internal Color SelectionRectangleColor;
        internal Color ItemCollabseAreaHeighlightColor;
        internal Color ItemSelectionHeighlightColor;

        // Tooltips
        private bool toolTipVisible;
        private string toolTipIndex;
        private string tooltip_text;
        private Point tooltip_point;
        // Thumbnails info
        private bool thmInfoVisible;
        private int thmInfoIndex;
        private string thmInfoText;
        private int thmInfoRating;
        private Rectangle thmInfoRect;

        /*Columns handling*/
        internal void OnColumnAdded(MLVColumn column)
        {
            ColumnObject ob = new ColumnObject();
            ob.ID = column.ID;
            ob.Text = column.Text;
            ob.W = column.Width;
            ob.TextXOffset = 2;// TODO: columns icon
            if (cl_objects.Count > 0)
            {
                ob.X1 = cl_objects[cl_objects.Count - 1].X2 + 1;
            }
            else
            {
                ob.X1 = columns_start_x + 1;
            }
            ob.X2 = ob.X1 + ob.W;
            cl_objects.Add(ob);

            CalculateColumnsIndiacs();
            if (Mode == MLVMode.Details)
                FillSubItemsBufferForAllItems();
            CalculateScrollMaxes();
            StartFillImagesBuffer();
            Invalidate();
        }
        internal void OnColumnInserted(MLVColumn column, int index)
        {
            CalculateColumnsObject(); CalculateColumnsIndiacs(); CalculateScrollMaxes(); FillSubItemsBufferForAllItems(); StartFillImagesBuffer(); Invalidate();
        }
        internal void OnColumnRemove(MLVColumn column, int index)
        {
            CalculateColumnsObject(); CalculateColumnsIndiacs(); CalculateScrollMaxes(); FillSubItemsBufferForAllItems(); Invalidate();
        }
        internal void OnColumnsClear()
        {
            CalculateColumnsObject(); CalculateColumnsIndiacs(); CalculateScrollMaxes(); FillSubItemsBufferForAllItems(); Invalidate();
        }
        /*Items handling*/
        internal void OnItemAdded(MLVItem item)
        {
            item.SetOwner(this);
            // Add the object
            ItemLineObject ob = new ItemLineObject();
            ob.OID = item.OID = GenerateID();
            ob.Text = item.Text;
            ob.Index = item.Index;
            ob.IsChild = false;
            ob.Selected = item.Selected;
            ob.Mode = item.DrawMode;
            ob.HasChildren = item.HasChildItems;
            ob.Collabsed = item.ChildItemsCollabsed;
            ob.UseCustomTextColor = item.UseCustomTextColor;
            ob.CustomTextColor = item.CustomTextColor;

            FillSubItemsBufferForAnItem(item, ob);

            // Add it
            item_objects.Add(ob);
            UpdateItemOnSelectionBuffer(ob);
            // Add it's children

            switch (Mode)
            {
                case MLVMode.Details:
                    {
                        if (!item.ChildItemsCollabsed)
                            FillChildItemsObjectsForAnItem(item, ob);
                        DetailsCalculateItemIndiacs();
                        break;
                    }
                case MLVMode.Thumbnails:
                    {
                        FillChildItemsObjectsForAnItem(item, ob);
                        ThumbnailsCalculateItemIndiacs();
                        ob.TextRectangle = CenterThumbnailText(ob.Text, thm_blk_width, it_height);
                        break;
                    }
            }

            CalculateScrollMaxes();
            StartFillImagesBuffer();
            // If the item index fall in the draw indexes, make the control redraw itself
            Invalidate();
        }
        internal void OnItemInserted(MLVItem item, int index)
        {
            // TODO: take a look at item insert ...
            item.SetOwner(this);
            // Add the object
            ItemLineObject ob = new ItemLineObject();
            ob.OID = item.OID = GenerateID();
            ob.Text = item.Text;
            ob.Index = item.Index;
            ob.IsChild = false;
            ob.Selected = item.Selected;
            ob.Mode = item.DrawMode;
            ob.HasChildren = item.HasChildItems;
            ob.Collabsed = item.ChildItemsCollabsed;
            ob.UseCustomTextColor = item.UseCustomTextColor;
            ob.CustomTextColor = item.CustomTextColor;

            FillSubItemsBufferForAnItem(item, ob);

            // Look for the latest item with the same index
            for (int i = index; i < item_objects.Count; i++)
            {
                if (item_objects[i].Index == i || item_objects[i].ParentItemIndex == i)
                {
                    while (item_objects[i].Index == i || item_objects[i].ParentItemIndex == i)
                    {
                        i++;
                        if (i >= item_objects.Count)
                            break;
                    }
                    if (i >= item_objects.Count)
                    {
                        // Add
                        item_objects.Add(ob);
                        UpdateItemOnSelectionBuffer(ob);
                    }
                    else
                    {
                        // Insert the object here
                        i--;
                        item_objects.Insert(i, ob);
                        UpdateItemOnSelectionBuffer(ob);
                    }
                    break;
                }
            }
            switch (Mode)
            {
                case MLVMode.Details:
                    {
                        if (!item.ChildItemsCollabsed)
                            FillChildItemsObjectsForAnItem(item, ob);
                        DetailsCalculateItemIndiacs();
                        break;
                    }
                case MLVMode.Thumbnails:
                    {
                        FillChildItemsObjectsForAnItem(item, ob);
                        ThumbnailsCalculateItemIndiacs();
                        ob.TextRectangle = CenterThumbnailText(ob.Text, thm_blk_width, it_height);
                        break;
                    }
            }
            CalculateScrollMaxes();
            StartFillImagesBuffer();
            Invalidate();
        }
        internal void OnItemRemove(MLVItem item, int index)
        {
            // Look for the latest item with the same index
            for (int i = index; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.OID)
                {
                    item_objects[i].Selected = false;
                    UpdateItemOnSelectionBuffer(item_objects[i]);
                    RemoveChildItemsObjectsForAnItem(item, item_objects[i]);
                    item_objects.RemoveAt(i);

                    break;
                }
            }
            switch (Mode)
            {
                case MLVMode.Details: DetailsCalculateItemIndiacs(); break;
                case MLVMode.Thumbnails: ThumbnailsCalculateItemIndiacs(); break;
            }
            CalculateScrollMaxes();
            Invalidate();
        }
        internal void OnItemsClear()
        {
            item_objects.Clear();// Clear everything !
            selection_buffer.Clear();
            switch (Mode)
            {
                case MLVMode.Details: DetailsCalculateItemIndiacs(); break;
                case MLVMode.Thumbnails: ThumbnailsCalculateItemIndiacs(); break;
            }
            CalculateScrollMaxes();
            Invalidate();
        }
        internal void OnItemDrawModeChanged(MLVItem item)
        {
            int index = Items.IndexOf(item);
            // Look for the latest item with the same index
            for (int i = index; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.OID)
                {
                    item_objects[i].Mode = item.DrawMode;
                    break;
                }
            }
            Invalidate();
        }
        internal void OnItemImageIndexChanged(MLVItem item)
        {
            StartFillImagesBuffer();
        }
        internal void OnItemTextChanged(MLVItem item)
        {
            int index = Items.IndexOf(item);
            // Look for the latest item with the same index
            for (int i = index; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.OID)
                {
                    item_objects[i].Text = item.Text;
                    if (mode == MLVMode.Thumbnails)
                        item_objects[i].TextRectangle = CenterThumbnailText(item_objects[i].Text, thm_blk_width, it_height);
                    break;
                }
            }

            Invalidate();
        }
        internal void OnItemSelectionChanged(MLVItem item)
        {
            int index = Items.IndexOf(item);
            // Look for the latest item with the same index
            for (int i = index; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.OID)
                {
                    item_objects[i].Selected = item.Selected;
                    UpdateItemOnSelectionBuffer(item_objects[i]);

                    break;
                }
            }
            Invalidate();
        }
        internal void OnItemCollabseChanged(MLVItem item)
        {
            int index = Items.IndexOf(item);
            // Look for the latest item with the same index
            for (int i = index; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.OID)
                {
                    if (item.ChildItemsCollabsed)
                    {
                        RemoveChildItemsObjectsForAnItem(item, item_objects[i]);
                        item_objects[i].Collabsed = true;
                    }
                    else
                    {
                        FillChildItemsObjectsForAnItem(item, item_objects[i]);
                        item_objects[i].Collabsed = false;
                    }
                    break;
                }
            }

            DetailsCalculateItemIndiacs();
            CalculateScrollMaxes();
            StartFillImagesBuffer();
            // If the item index fall in the draw indexes, make the control redraw itself
            Invalidate();
        }
        internal void OnItemUseCustomTextColorChanged(MLVItem item)
        {
            int index = Items.IndexOf(item);
            // Look for the latest item with the same index
            for (int i = index; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.OID)
                {
                    item_objects[i].UseCustomTextColor = item.UseCustomTextColor;

                    break;
                }
            }
            Invalidate();
        }
        internal void OnItemCustomTextColorChanged(MLVItem item)
        {
            int index = Items.IndexOf(item);
            // Look for the latest item with the same index
            for (int i = index; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.OID)
                {
                    item_objects[i].CustomTextColor = item.CustomTextColor;

                    break;
                }
            }
            Invalidate();
        }
        /*Child items handling*/
        internal void OnChildItemAdded(MLVChildItem item)
        {
            MLVItem parent = item.Parent;
            if (parent != null)
            {
                int index = Items.IndexOf(parent);
                // Look for the latest item with the same index
                for (int i = index; i < item_objects.Count; i++)
                {
                    // Locate the parent...
                    if (item_objects[i].OID == parent.OID)
                    {
                        int p_index = i;
                        int c_index = i;
                        i++;
                        // Locate the best index where to insert the child item at.
                        while (i < item_objects.Count)
                        {
                            if (item_objects[i].ParentItemOID == parent.OID)
                            {
                                c_index = i;
                            }
                            else
                                break;
                            i++;
                        }
                        // insert the child object ...
                        ItemLineObject cob = new ItemLineObject();
                        cob.OID = item.OID = GenerateID();
                        cob.Text = item.Text;
                        cob.Index = parent.ChildItems.IndexOf(item);
                        cob.IsChild = true;
                        cob.Mode = item.DrawMode;
                        cob.HasChildren = false;
                        cob.Collabsed = false;
                        cob.Selected = item.Selected;
                        cob.ParentItemIndex = item.Index;
                        cob.ParentItemOID = parent.OID;
                        cob.UseCustomTextColor = item.UseCustomTextColor;
                        cob.CustomTextColor = item.CustomTextColor;

                        FillSubItemsBufferForAnItem(item, cob);
                        // Insert it here
                        c_index++;
                        if (c_index <= item_objects.Count - 1)
                            item_objects.Insert(c_index, cob);
                        else
                            item_objects.Add(cob);
                        UpdateItemOnSelectionBuffer(cob);
                        // Do calculation to make sure everything is ok.
                        switch (Mode)
                        {
                            case MLVMode.Details:
                                DetailsCalculateItemIndiacs();
                                break;
                            case MLVMode.Thumbnails:
                                {
                                    ThumbnailsCalculateItemIndiacs();
                                    cob.TextRectangle = CenterThumbnailText(cob.Text, thm_blk_width, it_height);
                                    break;
                                }
                        }
                        CalculateScrollMaxes();
                        StartFillImagesBuffer();
                        Invalidate();

                        break;
                    }
                }
            }
        }
        internal void OnChildItemInserted(MLVChildItem item, int index)
        {
            MLVItem parent = item.Parent;
            if (parent != null)
            {
                int p_index = Items.IndexOf(parent);
                // Look for the latest item with the same index
                for (int i = p_index; i < item_objects.Count; i++)
                {
                    // Locate the parent...
                    if (item_objects[i].OID == parent.OID)
                    {
                        p_index = i;
                        int c_index = i;
                        // Locate the best index where to insert the child item at.
                        if (item_objects[i].HasChildren)
                        {
                            i++;
                            while (i < item_objects.Count)
                            {
                                if (item_objects[i].IsChild && (item_objects[i].Index == index))
                                {
                                    c_index = i;
                                    break;
                                }
                            }
                        }
                        // insert the child object ...
                        ItemLineObject cob = new ItemLineObject();
                        cob.OID = item.OID = GenerateID();
                        cob.Text = item.Text;
                        cob.Index = parent.ChildItems.IndexOf(item);
                        cob.IsChild = true;
                        cob.Mode = item.DrawMode;
                        cob.HasChildren = false;
                        cob.Collabsed = false;
                        cob.ParentItemIndex = item.Index;
                        cob.ParentItemOID = parent.OID;
                        cob.Selected = item.Selected;
                        cob.UseCustomTextColor = item.UseCustomTextColor;
                        cob.CustomTextColor = item.CustomTextColor;
                        FillSubItemsBufferForAnItem(item, cob);
                        // Insert it here
                        c_index++;
                        if (c_index <= item_objects.Count - 1)
                            item_objects.Insert(c_index, cob);
                        else
                            item_objects.Add(cob);
                        UpdateItemOnSelectionBuffer(cob);
                        // Do calculation to make sure everything is ok.
                        switch (Mode)
                        {
                            case MLVMode.Details: DetailsCalculateItemIndiacs(); break;
                            case MLVMode.Thumbnails: cob.TextRectangle = CenterThumbnailText(cob.Text, thm_blk_width, it_height); ThumbnailsCalculateItemIndiacs(); break;
                        }
                        CalculateScrollMaxes();
                        StartFillImagesBuffer();
                        Invalidate();

                        break;
                    }
                }
            }
        }
        internal void OnChildItemRemove(MLVChildItem item, int index)
        {
            MLVItem parent = item.Parent;
            if (parent != null)
            {
                index = Items.IndexOf(parent);
                // Look for the latest item with the same index
                for (int i = index; i < item_objects.Count; i++)
                {
                    // Locate the parent...
                    if (item_objects[i].OID == parent.OID)
                    {
                        int p_index = i;
                        // Remove that child
                        while (i < item_objects.Count)
                        {
                            if (item_objects[i].OID == item.OID)
                            {
                                item_objects[i].Selected = false;
                                UpdateItemOnSelectionBuffer(item_objects[i]);
                                item_objects.RemoveAt(i);
                                // Update parent information
                                if (p_index < item_objects.Count)
                                {
                                    if (item_objects[p_index].OID == parent.OID)
                                    {
                                        item_objects[p_index].HasChildren = item.Parent.HasChildItems;
                                        if (!item_objects[p_index].HasChildren)
                                        {
                                            item_objects[p_index].Collabsed = false;
                                        }
                                    }
                                }
                                break;
                            }
                            i++;
                        }

                        switch (Mode)
                        {
                            case MLVMode.Details: DetailsCalculateItemIndiacs(); break;
                            case MLVMode.Thumbnails: ThumbnailsCalculateItemIndiacs(); break;
                        }
                        CalculateScrollMaxes();
                        StartFillImagesBuffer();
                        Invalidate();

                        break;
                    }
                }
            }
        }
        internal void OnChildItemsClear(MLVItem parent)
        {
            if (parent != null)
            {
                int index = Items.IndexOf(parent);
                // Look for the latest item with the same index
                for (int i = index; i < item_objects.Count; i++)
                {
                    // Locate the parent...
                    if (item_objects[i].OID == parent.OID)
                    {
                        int p_index = i;
                        // Remove all child items
                        while (i < item_objects.Count)
                        {
                            if (i < 0 || i >= item_objects.Count)
                                break;
                            if (item_objects[i].ParentItemOID == parent.OID)
                            {
                                item_objects[i].Selected = false;
                                UpdateItemOnSelectionBuffer(item_objects[i]);
                                item_objects.RemoveAt(i);
                            }
                            else
                                break;
                        }
                        // Update parent information
                        if (p_index < item_objects.Count)
                        {
                            if (item_objects[p_index].OID == parent.OID)
                            {
                                item_objects[p_index].HasChildren = parent.HasChildItems;
                                if (!item_objects[p_index].HasChildren)
                                {
                                    item_objects[p_index].Collabsed = false;
                                }
                            }
                        }
                        // Do calculations
                        switch (Mode)
                        {
                            case MLVMode.Details: DetailsCalculateItemIndiacs(); break;
                            case MLVMode.Thumbnails: ThumbnailsCalculateItemIndiacs(); break;
                        }
                        CalculateScrollMaxes();
                        StartFillImagesBuffer();
                        Invalidate();

                        break;
                    }
                }
            }
        }
        internal void OnChildItemDrawModeChanged(MLVChildItem item)
        {
            MLVItem parent = item.Parent;
            if (parent != null)
            {
                int index = Items.IndexOf(parent);
                // Look for the latest item with the same index
                for (int i = index; i < item_objects.Count; i++)
                {
                    // Locate the parent...
                    if (item_objects[i].OID == item.OID)
                    {
                        item_objects[i].Mode = item.DrawMode;
                        Invalidate();

                        break;
                    }
                }
            }
        }
        internal void OnChildItemTextChanged(MLVChildItem item)
        {
            MLVItem parent = item.Parent;
            if (parent != null)
            {
                int index = Items.IndexOf(parent);
                // Look for the latest item with the same index
                for (int i = index; i < item_objects.Count; i++)
                {
                    // Locate the parent...
                    if (item_objects[i].OID == item.OID)
                    {
                        item_objects[i].Text = item.Text;
                        if (mode == MLVMode.Thumbnails)
                            item_objects[i].TextRectangle = CenterThumbnailText(item_objects[i].Text, thm_blk_width, it_height);

                        Invalidate();

                        break;
                    }
                }
            }
        }
        internal void OnChildItemImageIndexChanged(MLVChildItem item)
        {
            MLVItem parent = item.Parent;
            if (parent != null)
            {
                int index = Items.IndexOf(parent);
                // Look for the latest item with the same index
                for (int i = index; i < item_objects.Count; i++)
                {
                    // Locate the parent...
                    if (item_objects[i].OID == item.OID)
                    {
                        StartFillImagesBuffer();
                        Invalidate();

                        break;
                    }
                }
            }
        }
        internal void OnChildItemSelectionChanged(MLVChildItem item)
        {
            MLVItem parent = item.Parent;
            if (parent != null)
            {
                int index = Items.IndexOf(parent);
                // Look for the latest item with the same index
                for (int i = index; i < item_objects.Count; i++)
                {
                    // Locate the parent...
                    if (item_objects[i].OID == item.OID)
                    {
                        item_objects[i].Selected = item.Selected;
                        UpdateItemOnSelectionBuffer(item_objects[i]);
                        Invalidate();

                        break;
                    }
                }
            }
        }
        internal void OnChildItemUseCustomTextColorChanged(MLVChildItem item)
        {
            MLVItem parent = item.Parent;
            if (parent != null)
            {
                int index = Items.IndexOf(parent);
                // Look for the latest item with the same index
                for (int i = index; i < item_objects.Count; i++)
                {
                    // Locate the parent...
                    if (item_objects[i].OID == item.OID)
                    {
                        item_objects[i].UseCustomTextColor = item.UseCustomTextColor;
                        Invalidate();

                        break;
                    }
                }
            }
        }
        internal void OnChildItemCustomTextColorChanged(MLVChildItem item)
        {
            MLVItem parent = item.Parent;
            if (parent != null)
            {
                int index = Items.IndexOf(parent);
                // Look for the latest item with the same index
                for (int i = index; i < item_objects.Count; i++)
                {
                    // Locate the parent...
                    if (item_objects[i].OID == item.OID)
                    {
                        item_objects[i].CustomTextColor = item.CustomTextColor;
                        Invalidate();

                        break;
                    }
                }
            }
        }
        /*Sub items handling*/
        internal void OnSubItemAdded(MLVSubItem item)
        {
            // Look for the latest item with the same index
            int index = 0;
            if (item.Parent is MLVItem)
            {
                index = ((MLVItem)item.Parent).Index;
            }
            else if (item.Parent is MLVChildItem)
            {
                index = ((MLVChildItem)item.Parent).Index;
            }

            for (int i = index; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.Parent.OID)
                {
                    // This is it !
                    FillSubItemsBufferForAnItem(item.Parent, item_objects[i]);
                    break;
                }
            }
            Invalidate();
        }
        internal void OnSubItemInserted(MLVSubItem item, int index)
        {
            int pindex = 0;
            if (item.Parent is MLVItem)
            {
                pindex = ((MLVItem)item.Parent).Index;
            }
            else if (item.Parent is MLVChildItem)
            {
                pindex = ((MLVChildItem)item.Parent).Index;
            }
            for (int i = pindex; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.Parent.OID)
                {
                    // This is it !
                    FillSubItemsBufferForAnItem(item.Parent, item_objects[i]);
                    break;
                }
            }
            Invalidate();
        }
        internal void OnSubItemRemove(MLVSubItem item, int index)
        {
            int pindex = 0;
            if (item.Parent is MLVItem)
            {
                pindex = ((MLVItem)item.Parent).Index;
            }
            else if (item.Parent is MLVChildItem)
            {
                pindex = ((MLVChildItem)item.Parent).Index;
            }
            for (int i = pindex; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.Parent.OID)
                {
                    // This is it !
                    FillSubItemsBufferForAnItem(item.Parent, item_objects[i]);
                    break;
                }
            }
            Invalidate();
        }
        internal void OnSubItemsClear(IMLVElement parentItem)
        {
            int pindex = 0;
            if (parentItem is MLVItem)
            {
                pindex = ((MLVItem)parentItem).Index;
            }
            else if (parentItem is MLVChildItem)
            {
                pindex = ((MLVChildItem)parentItem).Index;
            }
            for (int i = pindex; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == parentItem.OID)
                {
                    FillSubItemsBufferForAnItem(parentItem, item_objects[i]);
                    break;
                }
            }
            Invalidate();
        }
        internal void OnSubItemDrawModeChanged(MLVSubItem item)
        {
            int pindex = 0;
            if (item.Parent is MLVItem)
            {
                pindex = ((MLVItem)item.Parent).Index;
            }
            else if (item.Parent is MLVChildItem)
            {
                pindex = ((MLVChildItem)item.Parent).Index;
            }
            for (int i = pindex; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.Parent.OID)
                {
                    // This is it !
                    foreach (SubItemObject ob in item_objects[i].SubItemsObjects)
                    {
                        if (ob.ID == item.ID)
                        {
                            ob.Mode = item.DrawMode;
                            break;
                        }
                    }
                    break;
                }
            }
            Invalidate();
        }
        internal void OnSubItemTextChanged(MLVSubItem item)
        {
            int pindex = 0;
            if (item.Parent is MLVItem)
            {
                pindex = ((MLVItem)item.Parent).Index;
            }
            else if (item.Parent is MLVChildItem)
            {
                pindex = ((MLVChildItem)item.Parent).Index;
            }
            for (int i = pindex; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.Parent.OID)
                {
                    // This is it !
                    foreach (SubItemObject ob in item_objects[i].SubItemsObjects)
                    {
                        if (ob.ID == item.ID)
                        {
                            ob.Text = item.Text;
                            break;
                        }
                    }
                    break;
                }
            }
            Invalidate();
        }
        internal void OnSubItemImageIndexChanged(MLVSubItem item)
        {
            /*
            int pindex = 0;
            if (item.Parent is MLVItem)
            {
                pindex = ((MLVItem)item.Parent).Index;
            }
            else if (item.Parent is MLVChildItem)
            {
                pindex = ((MLVChildItem)item.Parent).Index;
            }
            for (int i = pindex; i < item_objects.Count; i++)
            {
                if (item_objects[i].ID == item.Parent.ID)
                {
                    // This is it !
                    foreach (SubItemObject ob in item_objects[i].SubItemsObjects)
                    {
                        if (ob.ID == item.ID)
                        {
                            ob.Image = GetImageFromImagesListForSubItem(item);
                            ob.HasImage = ob.Image != null;
                            break;
                        }
                    }
                    break;
                }
            }
            Invalidate();*/
        }
        internal void OnRatingSubItemRatingChanged(MLVRatingSubItem item)
        {
            int pindex = 0;
            if (item.Parent is MLVItem)
            {
                pindex = ((MLVItem)item.Parent).Index;
            }
            else if (item.Parent is MLVChildItem)
            {
                pindex = ((MLVChildItem)item.Parent).Index;
            }
            for (int i = pindex; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.Parent.OID)
                {
                    // This is it !
                    foreach (SubItemObject ob in item_objects[i].SubItemsObjects)
                    {
                        if (ob.ID == item.ID)
                        {
                            ob.Rating = item.Rating;
                            break;
                        }
                    }
                    break;
                }
            }
            Invalidate();
        }
        internal void OnSubItemUseCustomTextColorChanged(MLVSubItem item)
        {
            int pindex = 0;
            if (item.Parent is MLVItem)
            {
                pindex = ((MLVItem)item.Parent).Index;
            }
            else if (item.Parent is MLVChildItem)
            {
                pindex = ((MLVChildItem)item.Parent).Index;
            }
            for (int i = pindex; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.Parent.OID)
                {
                    // This is it !
                    foreach (SubItemObject ob in item_objects[i].SubItemsObjects)
                    {
                        if (ob.ID == item.ID)
                        {
                            ob.UseCustomTextColor = item.UseCustomTextColor;
                            break;
                        }
                    }
                    break;
                }
            }
            Invalidate();
        }
        internal void OnSubItemCustomTextColorChanged(MLVSubItem item)
        {
            int pindex = 0;
            if (item.Parent is MLVItem)
            {
                pindex = ((MLVItem)item.Parent).Index;
            }
            else if (item.Parent is MLVChildItem)
            {
                pindex = ((MLVChildItem)item.Parent).Index;
            }
            for (int i = pindex; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.Parent.OID)
                {
                    // This is it !
                    foreach (SubItemObject ob in item_objects[i].SubItemsObjects)
                    {
                        if (ob.ID == item.ID)
                        {
                            ob.CustomTextColor = item.CustomTextColor;
                            break;
                        }
                    }
                    break;
                }
            }
            Invalidate();
        }
        /*Other important methods*/
        /// <summary>
        /// Set the scroll x value.
        /// </summary>
        /// <param name="val"></param>
        internal void SetScrollX(int val)
        {
            if (val < 0)
                val = 0;
            if (ScrollX != val)
            {
                if (val >= ScrollXMax)
                    return;
                ScrollX = val;
                switch (Mode)
                {
                    case MLVMode.Details:
                        {
                            CalculateColumnsIndiacs();
                            break;
                        }
                }
                Invalidate();
            }
        }
        /// <summary>
        /// Set the scroll y value.
        /// </summary>
        /// <param name="val"></param>
        internal void SetScrollY(int val)
        {
            if (val < 0)
                val = 0;
            if (ScrollY != val)
            {
                if (val >= ScrollYMax)
                    return;
                ScrollY = val;
                switch (Mode)
                {
                    case MLVMode.Details:
                        {
                            DetailsCalculateItemIndiacs();
                            break;
                        }
                    case MLVMode.Thumbnails:
                        {
                            ThumbnailsCalculateItemIndiacs();
                            break;
                        }
                }
                StartFillImagesBuffer();
                Invalidate();
            }
        }
        internal string GenerateID()
        {
            baseID++;
            return baseID.ToString("X8");
        }
        private void SwitchItemLineSelection(int index, bool selection)
        {
            // Select the element after
            string o_id = item_objects[index].OID;
            if (!item_objects[index].IsChild)
            {
                Items[o_id].Selected = selection;// This will toggle the internal event which handles the collabse internally.
            }
            else
            {
                o_id = item_objects[index].ParentItemOID;
                // This will toggle the internal event which handles the collabse internally.
                Items[o_id].ChildItems[item_objects[index].OID].Selected = selection;
            }
            UpdateItemOnSelectionBuffer(item_objects[index]);
        }
        internal void CalculateBackgroundBounds()
        {
            if (this.BackgroundImage != null)
            {
                switch (BackgroundMode)
                {
                    case MLVBackgroundRenderMode.NormalStretchNoAspectRatio:// Stretch image without aspect ratio, always..
                        {
                            backgroundDrawX = (Mode == MLVMode.Details ? columns_start_x : 0);
                            backgroundDrawY = 0;
                            backgroundDrawH = this.Height;
                            backgroundDrawW = this.Width - (Mode == MLVMode.Details ? columns_start_x : 0);
                            break;
                        }
                    case MLVBackgroundRenderMode.StretchWithAspectRatioIfLarger:
                        {
                            CalculateBKGStretchedImageValues();
                            CenterBKGImage();
                            break;
                        }
                    case MLVBackgroundRenderMode.StretchWithAspectRatioToFit:
                        {
                            CalculateBKGStretchToFitImageValues();
                            CenterBKGImage();
                            break;
                        }
                }
                backgroundThumbnail = this.BackgroundImage.GetThumbnailImage(backgroundDrawW, backgroundDrawH, null, IntPtr.Zero);
            }
            else
                backgroundThumbnail = null;
        }
        private void CalculateBKGStretchedImageValues()
        {
            int wit = Width - (Mode == MLVMode.Details ? columns_start_x : 0);
            float pRatio = (float)wit / this.Height;
            float imRatio = (float)this.BackgroundImage.Width / this.BackgroundImage.Height;

            if (wit >= this.BackgroundImage.Width && this.Height >= this.BackgroundImage.Height)
            {
                backgroundDrawW = BackgroundImage.Width;
                backgroundDrawH = BackgroundImage.Height;
            }
            else if (wit > BackgroundImage.Width && this.Height < BackgroundImage.Height)
            {
                backgroundDrawH = this.Height;
                backgroundDrawW = (int)(this.Height * imRatio);
            }
            else if (wit < BackgroundImage.Width && this.Height > BackgroundImage.Height)
            {
                backgroundDrawW = wit;
                backgroundDrawH = (int)(wit / imRatio);
            }
            else if (wit < BackgroundImage.Width && this.Height < BackgroundImage.Height)
            {
                if (wit >= this.Height)
                {
                    //width image
                    if (BackgroundImage.Width >= BackgroundImage.Height && imRatio >= pRatio)
                    {
                        backgroundDrawW = wit;
                        backgroundDrawH = (int)(wit / imRatio);
                    }
                    else
                    {
                        backgroundDrawH = this.Height;
                        backgroundDrawW = (int)(this.Height * imRatio);
                    }
                }
                else
                {
                    if (BackgroundImage.Width < BackgroundImage.Height && imRatio < pRatio)
                    {
                        backgroundDrawH = this.Height;
                        backgroundDrawW = (int)(this.Height * imRatio);
                    }
                    else
                    {
                        backgroundDrawW = wit;
                        backgroundDrawH = (int)(wit / imRatio);
                    }
                }
            }
        }
        private void CalculateBKGStretchToFitImageValues()
        {
            int wit = Width - (Mode == MLVMode.Details ? columns_start_x : 0);
            float pRatio = (float)wit / this.Height;
            float imRatio = (float)BackgroundImage.Width / BackgroundImage.Height;

            if (wit >= BackgroundImage.Width && this.Height >= BackgroundImage.Height)
            {
                if (wit >= this.Height)
                {
                    //width image
                    if (BackgroundImage.Width >= BackgroundImage.Height && imRatio >= pRatio)
                    {
                        backgroundDrawW = wit;
                        backgroundDrawH = (int)(wit / imRatio);
                    }
                    else
                    {
                        backgroundDrawH = this.Height;
                        backgroundDrawW = (int)(this.Height * imRatio);
                    }
                }
                else
                {
                    if (BackgroundImage.Width < BackgroundImage.Height && imRatio < pRatio)
                    {
                        backgroundDrawH = this.Height;
                        backgroundDrawW = (int)(this.Height * imRatio);
                    }
                    else
                    {
                        backgroundDrawW = wit;
                        backgroundDrawH = (int)(wit / imRatio);
                    }
                }
            }
            else if (wit > BackgroundImage.Width && this.Height < BackgroundImage.Height)
            {
                backgroundDrawH = this.Height;
                backgroundDrawW = (int)(this.Height * imRatio);
            }
            else if (wit < BackgroundImage.Width && this.Height > BackgroundImage.Height)
            {
                backgroundDrawW = wit;
                backgroundDrawH = (int)(wit / imRatio);
            }
            else if (wit < BackgroundImage.Width && this.Height < BackgroundImage.Height)
            {
                if (wit >= this.Height)
                {
                    //width image
                    if (BackgroundImage.Width >= BackgroundImage.Height && imRatio >= pRatio)
                    {
                        backgroundDrawW = wit;
                        backgroundDrawH = (int)(wit / imRatio);
                    }
                    else
                    {
                        backgroundDrawH = this.Height;
                        backgroundDrawW = (int)(this.Height * imRatio);
                    }
                }
                else
                {
                    if (BackgroundImage.Width < BackgroundImage.Height && imRatio < pRatio)
                    {
                        backgroundDrawH = this.Height;
                        backgroundDrawW = (int)(this.Height * imRatio);
                    }
                    else
                    {
                        backgroundDrawW = wit;
                        backgroundDrawH = (int)(wit / imRatio);
                    }
                }
            }

        }
        private void CenterBKGImage()
        {
            int wit = Width - (Mode == MLVMode.Details ? columns_start_x : 0);
            backgroundDrawY = (int)((this.Height - backgroundDrawH) / 2.0);
            backgroundDrawX = (int)((wit - backgroundDrawW) / 2.0);
            backgroundDrawX += (Mode == MLVMode.Details ? columns_start_x : 0);
        }
        private void OnShowTooltip(string index, string text, Point point)
        {
            if (!ShowItemTooltips)
                return;
            if (toolTipIndex == index)
                return;
            toolTipVisible = true;
            toolTipIndex = index;
            tooltip_text = text;
            tooltip_point = point;
            timer_set_tooltip.Start();
        }
        private void OnHideTooltip()
        {
            if (!ShowItemTooltips)
                return;
            if (!toolTipVisible)
                return;
            timer_set_tooltip.Stop();
            toolTipVisible = false;
            HideTooltip?.Invoke(this, new EventArgs());
        }
        private void Timer_set_tooltip_Tick(object sender, EventArgs e)
        {
            timer_set_tooltip.Stop();
            ShowTooltip?.Invoke(this, new ShowTooltipEventArgs(tooltip_text, tooltip_point));
        }
        private void OnShowThumpnailInfo(int index, string text)
        {
            if (!ShowItemInfoOnThumbnailMode)
                return;
            if (thmInfoIndex == index)
                return;
            ShowThumbnailInfoEventArgs args = new ShowThumbnailInfoEventArgs(text);
            ShowThumbnailInfo?.Invoke(this, args);
            if (!args.Cancel)
            {
                thmInfoIndex = index;
                thmInfoVisible = true;
                thmInfoText = args.TextToShow;
                thmInfoRating = args.Rating;

                thmInfoRect = new Rectangle();
                Size ss = TextRenderer.MeasureText(args.TextToShow, items_default_font);
                thmInfoRect.Width = ss.Width;
                thmInfoRect.Height = ss.Height;
                thmInfoRect.X = 2;
                thmInfoRect.Y = Height - thmInfoRect.Height + 2;
            }
        }
        private void OnHideThumbnailInfo()
        {
            if (!ShowItemInfoOnThumbnailMode)
                return;
            if (!thmInfoVisible)
                return;
            thmInfoVisible = false;
            thmInfoIndex = -1;
            HideThumbnailInfo?.Invoke(thmInfoText, new EventArgs());
        }

        /*COLUMNS draw methods*/
        private void CalculateColumnsObject()
        {
            cl_objects.Clear();

            for (int i = 0; i < Columns.Count; i++)
            {
                ColumnObject ob = new ColumnObject();
                ob.ID = Columns[i].ID;
                ob.Text = Columns[i].Text;
                ob.W = Columns[i].Width;
                ob.TextXOffset = 2;// TODO: columns icon
                if (i > 0)
                {
                    ob.X1 = cl_objects[i - 1].X2 + 1;
                }
                else
                {
                    ob.X1 = columns_start_x + 1;
                }
                ob.X2 = ob.X1 + ob.W;
                cl_objects.Add(ob);
            }
        }
        private void CalculateScrollMaxes()
        {
            switch (Mode)
            {
                case MLVMode.Details:
                    {
                        // Horisontal scroll 
                        if (cl_objects.Count > 0)
                        {
                            ScrollXMax = cl_objects[cl_objects.Count - 1].X2 - Width + 50;
                        }
                        else
                        {
                            ScrollXMax = 0;
                        }
                        if (ScrollX >= ScrollXMax)
                            ScrollX = 0;
                        RefreshScrollX?.Invoke(this, new EventArgs());
                        // Vertical scroll
                        if (item_objects.Count > 0)
                        {
                            // Scrolling will be on the item index
                            it_can_be_rendered_count = (Height - columns_height) / it_height;

                            ScrollYMax = item_objects.Count - (it_can_be_rendered_count / 2);
                        }
                        else
                        {
                            ScrollYMax = 0;
                        }
                        if (ScrollY >= ScrollYMax)
                            ScrollY = 0;
                        RefreshScrollY?.Invoke(this, new EventArgs());
                        break;
                    }
                case MLVMode.Thumbnails:
                    {
                        // Horisontal scroll is not needed
                        ScrollX = 0;
                        ScrollXMax = 0;
                        RefreshScrollX?.Invoke(this, new EventArgs());
                        // Vertical scroll is the item index.
                        // Since we can scroll only in rows, each scroll unit represent a row of items
                        if (item_objects.Count > 0)
                        {
                            if (thm_blks_count_cl == 0)
                                CalculateThumbnailsBlks();
                            if (thm_blks_count_cl > 0)
                            {
                                it_can_be_rendered_count = thm_blks_rows_count = item_objects.Count / thm_blks_count_cl;

                                ScrollYMax = thm_blks_rows_count;
                            }
                        }
                        else
                        {
                            ScrollYMax = 0;
                        }
                        if (ScrollY >= ScrollYMax)
                            ScrollY = 0;
                        RefreshScrollY?.Invoke(this, new EventArgs());
                        break;
                    }
            }
        }
        private void CalculateColumnsIndiacs()
        {
            if (cl_objects.Count > 0)
            {
                cl_start_index = -1;
                cl_end_index = -1;
                for (int i = 0; i < cl_objects.Count; i++)
                {
                    if (ScrollX >= cl_objects[i].X1 && ScrollX <= cl_objects[i].X2)
                    {
                        cl_start_index = i;
                    }
                    else if ((ScrollX + Width) >= cl_objects[i].X1 && (ScrollX + Width) <= cl_objects[i].X2)
                    {
                        cl_end_index = i;
                        break;
                    }
                }
                if (cl_start_index == -1)
                    cl_start_index = 0;
                if (cl_end_index == -1)
                    cl_end_index = cl_objects.Count - 1;
            }
            else
            {
                cl_start_index = 0;
                cl_end_index = 0;
            }
        }
        private void CalculateHeighlightedColumnIndex(MouseEventArgs e)
        {
            int min_x = e.X - ColumnResizingSensitivity;
            int max_x = e.X + ColumnResizingSensitivity;
            int min_y = e.Y - ColumnResizingSensitivity;
            int max_y = e.Y + ColumnResizingSensitivity;
            int new_column_hl_index = -1;
            if (cl_objects.Count > 0)
            {
                if (e.Y < columns_height)
                {
                    for (int index = cl_start_index; index <= cl_end_index; index++)
                    {
                        if (e.X >= (cl_objects[index].X1 - ScrollX) && e.X <= (cl_objects[index].X2 - ScrollX))
                        {
                            new_column_hl_index = index;
                            break;
                        }
                    }
                }
            }
            if (HeighlightedColumnIndex != new_column_hl_index)
            {
                HeighlightedColumnIndex = new_column_hl_index;
            }
        }
        /*ITEMS draw methods*/
        private void DetailsCalculateItemIndiacs()
        {
            if (item_objects.Count > 0)
            {
                it_can_be_rendered_count = (Height - columns_height) / it_height;

                if (item_objects.Count < it_can_be_rendered_count)
                {
                    it_start_index = 0;
                    it_end_index = item_objects.Count - 1;
                }
                else
                {
                    it_start_index = ScrollY;
                    if (it_start_index == -1)
                        it_start_index = 0;
                    it_end_index = it_start_index + it_can_be_rendered_count;

                    if (it_end_index >= item_objects.Count)
                        it_end_index = item_objects.Count - 1;
                }
            }
            else
            {
                it_start_index = 0;
                it_end_index = 0;
            }
        }
        private void ThumbnailsCalculateItemIndiacs()
        {
            if (item_objects.Count > 0)
            {
                it_can_be_rendered_count = thm_blk_count_total;

                if (item_objects.Count < thm_blk_count_total)
                {
                    it_start_index = 0;
                    it_end_index = item_objects.Count - 1;
                }
                else
                {
                    it_start_index = ScrollY * thm_blks_count_cl;
                    if (it_start_index == -1)
                        it_start_index = 0;
                    it_end_index = it_start_index + thm_blk_count_total;

                    if (it_end_index >= item_objects.Count)
                        it_end_index = item_objects.Count - 1;
                }
            }
            else
            {
                it_start_index = 0;
                it_end_index = 0;
            }
        }
        private void FillSubItemsBufferForAllItems()
        {
            for (int i = 0; i < cl_objects.Count; i++)
                cl_objects[i].ContainRatingSubItem = false;
            foreach (ItemLineObject ob in item_objects)
            {
                // Get the item
                IMLVElement item = null;
                if (!ob.IsChild)
                    item = Items[ob.OID];
                else
                {
                    MLVItem parent = Items[ob.ParentItemOID];
                    if (parent != null)
                    {
                        item = parent.ChildItems[ob.OID];
                    }
                }
                FillSubItemsBufferForAnItem(item, ob);
            }
        }
        private void FillSubItemsBufferForAnItem(IMLVElement item, ItemLineObject ob)
        {
            if (item == null)
                return;
            ob.SubItemsObjects.Clear();
            for (int i = 0; i < cl_objects.Count; i++)
            {
                MLVSubItem sub = null;
                if (item is MLVItem)
                {
                    sub = ((MLVItem)item).GetSubItem(cl_objects[i].ID);
                }
                else if (item is MLVChildItem)
                {
                    sub = ((MLVChildItem)item).GetSubItem(cl_objects[i].ID);
                }

                if (sub != null)
                {
                    // Create the object and add it
                    SubItemObject subob = new SubItemObject();
                    subob.ID = sub.ID;
                    subob.ParentOID = ob.OID;
                    subob.Mode = sub.DrawMode;
                    subob.Text = sub.Text;
                    subob.UseCustomTextColor = sub.UseCustomTextColor;
                    subob.CustomTextColor = sub.CustomTextColor;
                    if (sub is MLVRatingSubItem)
                    {
                        subob.IsRatingSubItem = true;
                        subob.Rating = ((MLVRatingSubItem)sub).Rating;
                        cl_objects[i].ContainRatingSubItem = true;
                    }
                    ob.SubItemsObjects.Add(subob);
                }
                else
                {
                    // Add a blank object to avoid null exceptions
                    // Create the object and add it
                    SubItemObject subob = new SubItemObject();
                    subob.ID = "";
                    subob.ParentOID = ob.OID;
                    // TODO: set the sub item object image
                    subob.Mode = MLVItemDrawMode.Text;
                    subob.Text = "";
                    ob.SubItemsObjects.Add(subob);
                }
            }
        }
        // Depending on collabse value, fill or remove the child items for an item.
        private void FillChildItemsObjectsForAnItem(MLVItem item, ItemLineObject ob)
        {
            // if (ob.Collabsed)
            //     return;
            int index = item_objects.IndexOf(ob);
            // Look for the latest item with the same index
            for (int i = index; i < item_objects.Count; i++)
            {
                if (item_objects[i].OID == item.OID)
                {
                    // This is it !!
                    // We need to create and insert the child item objects here
                    for (int c = 0; c < item.ChildItems.Count; c++)
                    {
                        // Add the object
                        ItemLineObject cob = new ItemLineObject();
                        cob.OID = item.ChildItems[c].OID = GenerateID();
                        cob.Text = item.ChildItems[c].Text;
                        cob.Index = c;
                        cob.IsChild = true;
                        cob.Mode = item.ChildItems[c].DrawMode;
                        cob.HasChildren = false;
                        cob.Collabsed = false;
                        cob.ParentItemIndex = item.Index;
                        cob.ParentItemOID = item.OID;
                        cob.Selected = item.ChildItems[c].Selected;
                        cob.UseCustomTextColor = item.ChildItems[c].UseCustomTextColor;
                        cob.CustomTextColor = item.ChildItems[c].CustomTextColor;
                        FillSubItemsBufferForAnItem(item.ChildItems[c], cob);
                        // Insert it here
                        i++;
                        if (i <= item_objects.Count - 1)
                            item_objects.Insert(i, cob);
                        else
                            item_objects.Add(cob);

                        UpdateItemOnSelectionBuffer(cob);
                    }
                    break;
                }
            }
        }
        private void RemoveChildItemsObjectsForAnItem(MLVItem item, ItemLineObject ob)
        {
            //if (!ob.Collabsed)
            //    return;
            int index = item_objects.IndexOf(ob);
            // Look for the latest item with the same index
            for (int i = index; i < item_objects.Count; i++)
            {
                if (item_objects[i].ParentItemOID == item.OID)
                {
                    while (item_objects[i].ParentItemOID == item.OID)
                    {
                        item_objects[i].Selected = false;
                        UpdateItemOnSelectionBuffer(item_objects[i]);
                        item_objects.RemoveAt(i);
                        if (i == item_objects.Count)
                            i--;
                        if (i < 0 || item_objects.Count == 0)
                            break;
                    }
                    break;
                }
            }
        }
        private void UpdateItemOnSelectionBuffer(ItemLineObject ob)
        {
            if (surpressSelectionUpdate)
                return;
            // Add/Remove it from the selection buffer
            if (!selection_buffer.Contains(ob.OID))
            {
                if (ob.Selected)
                {
                    // Add new entry
                    selection_buffer.Add(ob.OID);
                }
            }
            else
            {
                if (!ob.Selected)
                {
                    // Remove the entry
                    selection_buffer.Remove(ob.OID);
                }
            }
        }
        private int GetItemLineObjectIndex(string oid)
        {
            ItemLineObject ii = item_objects.Find(
                    delegate (ItemLineObject it)
                    {
                        return it.OID == oid;
                    }
                );
            if (ii != null)
                return item_objects.IndexOf(ii);
            return -1;
        }
        private void ClearSelectionBufferAndUnselect()
        {
            surpressSelectionUpdate = true;
            int index = 0;
            foreach (string key in selection_buffer)
            {
                index = GetItemLineObjectIndex(key);
                item_objects[index].Selected = false;
                if (!item_objects[index].IsChild)
                    Items[key].Selected = false;
                else
                    Items[item_objects[index].ParentItemOID].ChildItems[key].Selected = false;
            }
            selection_buffer.Clear();
            surpressSelectionUpdate = false;
        }
        /*Images buffer*/
        internal void StartFillImagesBuffer()
        {
            if (timer_images_buffer == null)
                return;
            timer_images_buffer.Start();
        }
        private void FillSubItemsImagesBuffer()
        {
            item_objects_images.Clear();
            if (item_objects.Count == 0)
                return;

            if (it_start_index <= it_end_index)
            {
                for (int it_index = it_start_index; it_index <= it_end_index; it_index++)
                {
                    // Get the item
                    IMLVElement item = null;
                    if (!item_objects[it_index].IsChild)
                    {
                        item = Items[item_objects[it_index].OID];
                    }
                    else
                    {
                        MLVItem parent = Items[item_objects[it_index].ParentItemOID];
                        if (parent != null)
                        {
                            item = parent.ChildItems[item_objects[it_index].OID];
                        }
                    }
                    // The item image
                    ImageObject ob = new ImageObject();
                    if (item != null)
                    {
                        // The item image
                        switch (item_objects[it_index].Mode)
                        {
                            case MLVItemDrawMode.User:
                                {
                                    MLVDrawItemEventArgs args = new MLVDrawItemEventArgs(item_objects[it_index].Index, item_objects[it_index].Text, ob.Image, item_objects[it_index].UseCustomTextColor, item_objects[it_index].CustomTextColor);
                                    args.IsChildItem = item_objects[it_index].IsChild;
                                    DrawItem?.Invoke(this, args);

                                    if (!args.UseDefaults)
                                    {
                                        item_objects[it_index].Text = args.TextToDraw;
                                        item_objects[it_index].CustomTextColor = args.CustomTextColor;
                                        item_objects[it_index].UseCustomTextColor = args.UseCustomTextColor;
                                        ob.Image = args.ImageToDraw;
                                    }
                                    break;
                                }
                            case MLVItemDrawMode.Image:
                            case MLVItemDrawMode.TextImage:
                                {
                                    ob.Image = GetImageFromImagesListForItem(item);
                                    break;
                                }
                        }
                        ob.HasImage = ob.Image != null;
                        if (ob.HasImage)
                        {
                            if (it_text_size.Height + 4 < ob.Image.Width || it_text_size.Height + 4 < ob.Image.Height)
                            {
                                ob.Image = ob.Image.GetThumbnailImage(it_text_size.Height + 4, it_text_size.Height + 4, null, IntPtr.Zero);
                            }
                        }
                        // The sub items images
                        foreach (SubItemObject sub in item_objects[it_index].SubItemsObjects)
                        {
                            ImageObject nss = new ImageObject();
                            if (!sub.IsRatingSubItem)
                            {
                                MLVSubItem subItem = null;
                                int index = -1;
                                if (item is MLVItem)
                                {
                                    subItem = ((MLVItem)item).GetSubItem(sub.ID);
                                    index = ((MLVItem)item).SubItems.IndexOf(subItem);
                                }
                                else if (item is MLVChildItem)
                                {
                                    subItem = ((MLVChildItem)item).GetSubItem(sub.ID);
                                    index = ((MLVChildItem)item).SubItems.IndexOf(subItem);
                                }

                                if (subItem != null)
                                {
                                    switch (subItem.DrawMode)
                                    {
                                        case MLVItemDrawMode.User:
                                            {
                                                MLVDrawSubItemEventArgs args = new MLVDrawSubItemEventArgs(index, sub.ID, sub.Text, ob.Image, sub.UseCustomTextColor, sub.CustomTextColor);
                                                DrawSubItem?.Invoke(this, args);

                                                if (!args.UseDefaults)
                                                {
                                                    sub.Text = args.TextToDraw;
                                                    sub.CustomTextColor = args.CustomTextColor;
                                                    sub.UseCustomTextColor = args.UseCustomTextColor;
                                                    nss.Image = args.ImageToDraw;
                                                }
                                                break;
                                            }
                                        case MLVItemDrawMode.Image:
                                        case MLVItemDrawMode.TextImage:
                                            {
                                                nss.Image = GetImageFromImagesListForSubItem(subItem);
                                                break;
                                            }
                                    }
                                }
                                nss.HasImage = nss.Image != null;
                                if (nss.HasImage)
                                {
                                    if (it_text_size.Height + 4 < nss.Image.Width || it_text_size.Height + 4 < nss.Image.Height)
                                    {
                                        nss.Image = nss.Image.GetThumbnailImage(it_text_size.Height + 4, it_text_size.Height + 4, null, IntPtr.Zero);
                                    }
                                }
                            }

                            ob.SubObjects.Add(nss);
                        }
                    }
                    item_objects_images.Add(ob);
                }
                Invalidate();
            }
        }
        private void FillItemImagesBufferThumbnails()
        {
            item_objects_images.Clear();
            // Draw all item lines that can be drawable
            if (item_objects.Count > 0)
            {
                int it_index = it_start_index;
                //  for (int it_index = it_start_index; it_index <= it_end_index; it_index++)
                for (int i = 0; i < thm_blks_count_row; i++)
                {
                    for (int j = 0; j < thm_blks_count_cl; j++)
                    {
                        if (it_index >= item_objects.Count)
                        {
                            it_index = -1;
                            break;
                        }
                        GetImageForNextObject(it_index);

                        it_index++;
                        if (it_index >= item_objects.Count)
                        {
                            it_index = -1;
                            break;
                        }
                    }
                    if (it_index < 0)
                        break;
                }
                Invalidate();
            }
        }
        private void GetImageForNextObject(int index)
        {
            if (index < 0)
                return;
            if (index >= item_objects.Count)
                return;
            // Get the item
            IMLVElement item = null;
            if (!item_objects[index].IsChild)
                item = Items[item_objects[index].OID];
            else
            {
                MLVItem parent = Items[item_objects[index].ParentItemOID];
                if (parent != null)
                {
                    item = parent.ChildItems[item_objects[index].OID];
                }
            }
            ImageObject ob = new ImageObject();
            if (item != null)
            {
                // The item image
                switch (item_objects[index].Mode)
                {
                    case MLVItemDrawMode.User:
                        {
                            MLVDrawItemEventArgs args = new MLVDrawItemEventArgs(item_objects[index].Index, item_objects[index].Text, ob.Image, item_objects[index].UseCustomTextColor, item_objects[index].CustomTextColor);
                            args.IsChildItem = item_objects[index].IsChild;
                            DrawItem?.Invoke(this, args);

                            if (!args.UseDefaults)
                            {
                                item_objects[index].Text = args.TextToDraw;
                                item_objects[index].CustomTextColor = args.CustomTextColor;
                                item_objects[index].UseCustomTextColor = args.UseCustomTextColor;
                                ob.Image = args.ImageToDraw;
                            }
                            break;
                        }
                    case MLVItemDrawMode.Image:
                    case MLVItemDrawMode.TextImage:
                        {
                            ob.Image = GetImageFromImagesListForItem(item);
                            break;
                        }
                }

                ob.HasImage = ob.Image != null;
                if (ob.HasImage)
                {
                    Size siz = ThumbnailsKeepImageSize ? CalculateThumbnailStretchImageValuesStretch(ob.Image.Width, ob.Image.Height) : CalculateThumbnailStretchImageValues(ob.Image.Width, ob.Image.Height);

                    int imgX = (thm_blk_width / 2) - (siz.Width / 2);
                    int imgY = (thm_blk_img_area_height / 2) - (siz.Height / 2);

                    ob.ImageRectangle = new Rectangle(imgX, imgY, siz.Width, siz.Height);
                    if (siz.Width < ob.Image.Width || siz.Height < ob.Image.Height)
                    {
                        Image img = ob.Image.GetThumbnailImage(siz.Width, siz.Height, null, IntPtr.Zero);
                        ob.Image = img;
                    }
                }
            }
            // Center the text
            item_objects[index].TextRectangle = CenterThumbnailText(item_objects[index].Text, thm_blk_width, it_height);

            item_objects_images.Add(ob);
        }

        private Image GetImageFromImagesListForItem(IMLVElement item)
        {
            Image val = null;
            if (ItemsImageList != null)
            {
                if (item != null)
                {
                    int index = -1;
                    if (item is MLVItem)
                    {
                        index = ((MLVItem)item).ImageIndex;
                    }
                    else if (item is MLVChildItem)
                    {
                        index = ((MLVChildItem)item).ImageIndex;
                    }
                    if (index >= 0 && index < ItemsImageList.Images.Count)
                        return ItemsImageList.Images[index];
                }
            }
            return val;
        }
        private Image GetImageFromImagesListForSubItem(MLVSubItem item)
        {
            Image val = null;
            if (SubItemsImageList != null)
            {
                if (item != null)
                {
                    if (item.ImageIndex < SubItemsImageList.Images.Count)
                        return SubItemsImageList.Images[item.ImageIndex];

                }
            }
            return val;
        }
        private void Timer_images_buffer_Tick(object sender, EventArgs e)
        {
            timer_images_buffer.Stop();
            switch (Mode)
            {
                case MLVMode.Details: FillSubItemsImagesBuffer(); break;
                case MLVMode.Thumbnails: FillItemImagesBufferThumbnails(); break;
            }
        }
        private void SetupSelectionRectangle(int scroll_x, int scroll_y)
        {
            int x1 = ms_down_point_as_view_port.X - scroll_x;
            int y1 = ms_down_point_as_view_port.Y - scroll_y;
            int x2 = ms_current_point.X;
            int y2 = ms_current_point.Y;

            if (x2 < x1)
            {
                x1 = ms_current_point.X;
                x2 = ms_down_point_as_view_port.X - scroll_x;
            }
            if (y2 < y1)
            {
                y1 = ms_current_point.Y;
                y2 = ms_down_point_as_view_port.Y - scroll_y;
            }
            it_selection_rectangle = new Rectangle(x1, y1, x2 - x1, y2 - y1);
        }
        private void DetailsSelectItemsOnSelectionRectangle()
        {
            bool control_holded = (ModifierKeys & Keys.Control) == Keys.Control;

            if (!control_holded)
                ClearSelectionBufferAndUnselect();
            if ((it_selection_rectangle.X + ScrollX) <= cl_objects[cl_objects.Count - 1].X2)
            {
                surpressClick = true;

                int first_index = (it_selection_rectangle.Y / it_height) - 1;
                first_index += ScrollY;
                if (first_index < 0)
                    first_index = 0;

                int last_index = ((it_selection_rectangle.Height + it_selection_rectangle.Y) / it_height) - 1;
                last_index += ScrollY;
                if (last_index >= item_objects.Count)
                    last_index = item_objects.Count - 1;

                for (int i = first_index; i <= last_index; i++)
                {
                    // Select that item
                    string o_id = item_objects[i].OID;
                    if (!item_objects[i].IsChild)
                    {
                        Items[o_id].Selected = true;// This will toggle the internal event which handles the collabse internally.
                    }
                    else
                    {
                        o_id = item_objects[i].ParentItemOID;
                        // This will toggle the internal event which handles the collabse internally.
                        Items[o_id].ChildItems[item_objects[i].OID].Selected = true;
                    }
                }
            }
        }
        private void ThumbnailsSelectItemsOnSelectionRectangle()
        {
            bool control_holded = (ModifierKeys & Keys.Control) == Keys.Control;
            if (!control_holded)
                ClearSelectionBufferAndUnselect();
            surpressClick = true;
            // Let's see which rows we are in
            int row_start = (it_selection_rectangle.Y / (thm_blk_height + thm_blk_space));
            if (row_start > thm_blks_count_row - 1)
            {
                return;
            }
            int row_end = ((it_selection_rectangle.Y + it_selection_rectangle.Height) / (thm_blk_height + thm_blk_space));
            if (row_end > thm_blks_count_row - 1)
            {
                row_end = thm_blks_count_row - 1;
            }
            // Let's see which columns we are in
            int cl_start = (it_selection_rectangle.X / (thm_blk_width + thm_blk_space));
            if (cl_start > thm_blks_count_cl - 1)
            {
                return;
            }
            int cl_end = ((it_selection_rectangle.X + it_selection_rectangle.Width) / (thm_blk_width + thm_blk_space));
            if (cl_end > thm_blks_count_cl - 1)
            {
                cl_end = thm_blks_count_cl - 1;
            }
            // Console.WriteLine("r_start=" + row_start + ", row_end=" + row_end + ", cl_start=" + cl_start + ", cl_end=" + cl_end);
            for (int r = row_start; r <= row_end; r++)
            {
                for (int c = cl_start; c <= cl_end; c++)
                {
                    int it_index = (r * thm_blks_count_cl) + c + it_start_index;

                    if (it_index >= 0 && it_index < item_objects.Count)
                    {
                        // Select that item
                        string o_id = item_objects[it_index].OID;
                        if (!item_objects[it_index].IsChild)
                        {
                            Items[o_id].Selected = true;// This will toggle the internal event which handles the collabse internally.
                        }
                        else
                        {
                            o_id = item_objects[it_index].ParentItemOID;
                            // This will toggle the internal event which handles the collabse internally.
                            Items[o_id].ChildItems[item_objects[it_index].OID].Selected = true;
                        }
                    }
                }
            }
        }
        // Thumbnails
        private void CalculateThumbnailsBlks()
        {
            if (Width == 0 || Height == 0)
                return;
            thm_blks_count_row = (int)Math.Floor((double)Height / (double)(thm_blk_space + thm_blk_height));
            thm_blks_count_cl = (int)Math.Floor((double)Width / (double)(thm_blk_space + thm_blk_width)) - 1;
            thm_blk_count_total = thm_blks_count_row * thm_blks_count_cl;
            thm_blks_rows_count = item_objects.Count / thm_blks_count_row;

            //Console.WriteLine("ROWS = " + thm_blks_count_row + ", CLs = " + thm_blks_count_cl);
        }
        private Size CalculateThumbnailStretchImageValues(int imgW, int imgH)
        {
            float pRatio = (float)thm_blk_width / thm_blk_img_area_height;
            float imRatio = (float)imgW / imgH;
            int viewImageWidth = 0;
            int viewImageHeight = 0;

            if (thm_blk_width >= imgW && thm_blk_img_area_height >= imgH)
            {
                viewImageWidth = imgW;
                viewImageHeight = imgH;
            }
            else if (thm_blk_width > imgW && thm_blk_img_area_height < imgH)
            {
                viewImageHeight = thm_blk_img_area_height;
                viewImageWidth = (int)(thm_blk_img_area_height * imRatio);
            }
            else if (thm_blk_width < imgW && thm_blk_img_area_height > imgH)
            {
                viewImageWidth = thm_blk_width;
                viewImageHeight = (int)(thm_blk_width / imRatio);
            }
            else if (thm_blk_width < imgW && thm_blk_img_area_height < imgH)
            {
                if (thm_blk_width >= thm_blk_img_area_height)
                {
                    //width image
                    if (imgW >= imgH && imRatio >= pRatio)
                    {
                        viewImageWidth = thm_blk_width;
                        viewImageHeight = (int)(thm_blk_width / imRatio);
                    }
                    else
                    {
                        viewImageHeight = thm_blk_img_area_height;
                        viewImageWidth = (int)(thm_blk_img_area_height * imRatio);
                    }
                }
                else
                {
                    if (imgW < imgH && imRatio < pRatio)
                    {
                        viewImageHeight = thm_blk_img_area_height;
                        viewImageWidth = (int)(thm_blk_img_area_height * imRatio);
                    }
                    else
                    {
                        viewImageWidth = thm_blk_width;
                        viewImageHeight = (int)(thm_blk_width / imRatio);
                    }
                }
            }

            return new Size(viewImageWidth, viewImageHeight);
        }
        private Size CalculateThumbnailStretchImageValuesStretch(int imgW, int imgH)
        {
            float pRatio = (float)thm_blk_width / thm_blk_img_area_height;
            float imRatio = (float)imgW / imgH;
            int viewImageWidth = 0;
            int viewImageHeight = 0;

            if (thm_blk_width >= imgW && thm_blk_img_area_height >= imgH)
            {
                if (thm_blk_width >= thm_blk_img_area_height)
                {
                    //width image
                    if (imgW >= imgH && imRatio >= pRatio)
                    {
                        viewImageWidth = thm_blk_width;
                        viewImageHeight = (int)(thm_blk_width / imRatio);
                    }
                    else
                    {
                        viewImageHeight = thm_blk_img_area_height;
                        viewImageWidth = (int)(thm_blk_width * imRatio);
                    }
                }
                else
                {
                    if (imgW < imgH && imRatio < pRatio)
                    {
                        viewImageHeight = thm_blk_img_area_height;
                        viewImageWidth = (int)(thm_blk_img_area_height * imRatio);
                    }
                    else
                    {
                        viewImageWidth = thm_blk_width;
                        viewImageHeight = (int)(this.Width / imRatio);
                    }
                }
            }
            else if (thm_blk_width > imgW && thm_blk_img_area_height < imgH)
            {
                viewImageHeight = thm_blk_img_area_height;
                viewImageWidth = (int)(thm_blk_img_area_height * imRatio);
            }
            else if (thm_blk_width < imgW && thm_blk_img_area_height > imgH)
            {
                viewImageWidth = thm_blk_width;
                viewImageHeight = (int)(thm_blk_width / imRatio);
            }
            else if (thm_blk_width < imgW && thm_blk_img_area_height < imgH)
            {
                if (thm_blk_width >= thm_blk_img_area_height)
                {
                    //width image
                    if (imgW >= imgH && imRatio >= pRatio)
                    {
                        viewImageWidth = thm_blk_width;
                        viewImageHeight = (int)(thm_blk_width / imRatio);
                    }
                    else
                    {
                        viewImageHeight = thm_blk_img_area_height;
                        viewImageWidth = (int)(thm_blk_img_area_height * imRatio);
                    }
                }
                else
                {
                    if (imgW < imgH && imRatio < pRatio)
                    {
                        viewImageHeight = thm_blk_img_area_height;
                        viewImageWidth = (int)(thm_blk_img_area_height * imRatio);
                    }
                    else
                    {
                        viewImageWidth = thm_blk_width;
                        viewImageHeight = (int)(thm_blk_width / imRatio);
                    }
                }
            }
            return new Size(viewImageWidth, viewImageHeight);
        }
        private Rectangle CenterThumbnailText(string text, int areaW, int areaH)
        {
            Rectangle rec = new Rectangle();
            Size ss = TextRenderer.MeasureText(text, items_default_font);

            rec.Y = (areaH / 2) - (ss.Height / 2);

            if (ss.Width < areaW)
                rec.X = (areaW / 2) - (ss.Width / 2);
            else
                rec.X = 0;

            rec.Width = ss.Width;
            rec.Height = ss.Height;
            return rec;
        }
        /// <summary>
        /// On painting
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            // Draw background color
            pe.Graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, this.Width, this.Height);

            // Draw background
            if (backgroundThumbnail != null)
                pe.Graphics.DrawImage(backgroundThumbnail, backgroundDrawX, backgroundDrawY, backgroundDrawW, backgroundDrawH);

            switch (Mode)
            {
                case MLVMode.Details: { OnPaintDetailsMode(pe); break; }
                case MLVMode.Thumbnails: { OnPaintThumbnailsMode(pe); break; }
            }
        }
        // DRAWING
        private void OnPaintDetailsMode(PaintEventArgs pe)
        {
            /*COLUMNS*/
            // Draw columns
            if (cl_objects.Count > 0 && (cl_start_index <= cl_end_index))
            {
                for (int cl_index = cl_start_index; cl_index <= cl_end_index; cl_index++)
                {
                    // Actual coordinates occurding to scroll
                    cl_x1 = cl_objects[cl_index].X1 - ScrollX;
                    cl_x2 = cl_objects[cl_index].X2 - ScrollX;

                    // Draw recangle
                    pe.Graphics.FillRectangle(new LinearGradientBrush(new Point(), new Point(0, columns_height - 1),
                        (cl_index == HeighlightedColumnIndex) ? ColumnHiehglightColor : ColumnColor,
                        Color.White),
                            new Rectangle(cl_x1, 0, cl_objects[cl_index].W, columns_height - 1));
                    // Draw splitter line
                    if (cl_x2 > columns_start_x)
                        pe.Graphics.DrawLine(new Pen(new SolidBrush(ColumnsSplitColor)), cl_x2, 0, cl_x2, Height);
                    // Draw text
                    pe.Graphics.DrawString(cl_objects[cl_index].Text, columns_font, new SolidBrush(ColumnTextColor),
                        new RectangleF(cl_x1 + cl_objects[cl_index].TextXOffset, cl_text_y_offset,
                        cl_objects[cl_index].W - cl_objects[cl_index].TextXOffset, columns_text_size.Height + 2), string_format);

                    // Draw all item lines that can be drawable
                    if (it_start_index <= it_end_index & item_objects.Count > 0)
                    {
                        int it_index_img = 0;
                        for (int it_index = it_start_index; it_index <= it_end_index; it_index++)
                        {
                            it_render_text = false;
                            it_render_image = false;
                            it_text_to_render = "";
                            it_text_use_custom_color = false;
                            it_text_custom_color = ItemTextColor;
                            it_image_to_render = null;
                            it_temp_is_rating_image = false;
                            it_temp_x = 0;
                            it_temp_y = columns_height + ((it_index - ScrollY) * it_height);
                            // Let's see what we need to do !
                            if (item_objects[it_index].SubItemsObjects[cl_index].IsRatingSubItem)
                            {
                                it_render_image = true;
                                it_temp_is_rating_image = true;
                                if (it_show_rating && it_details_cl_index == cl_index && it_possible_rating_it_index == it_index)
                                {
                                    switch (it_possible_rating)
                                    {
                                        case 0:
                                        default:
                                            {
                                                it_image_to_render = Properties.Resources.noneRating;
                                                break;
                                            }
                                        case 1:
                                            {
                                                it_image_to_render = Properties.Resources.star_1;
                                                break;
                                            }
                                        case 2:
                                            {
                                                it_image_to_render = Properties.Resources.star_2;
                                                break;
                                            }
                                        case 3:
                                            {
                                                it_image_to_render = Properties.Resources.star_3;
                                                break;
                                            }
                                        case 4:
                                            {
                                                it_image_to_render = Properties.Resources.star_4;
                                                break;
                                            }
                                        case 5:
                                            {
                                                it_image_to_render = Properties.Resources.star_5;
                                                break;
                                            }
                                    }
                                }
                                else
                                {
                                    switch (item_objects[it_index].SubItemsObjects[cl_index].Rating)
                                    {
                                        case 0:
                                        default:
                                            {
                                                it_image_to_render = Properties.Resources.noneRating;
                                                break;
                                            }
                                        case 1:
                                            {
                                                it_image_to_render = Properties.Resources.star_1;
                                                break;
                                            }
                                        case 2:
                                            {
                                                it_image_to_render = Properties.Resources.star_2;
                                                break;
                                            }
                                        case 3:
                                            {
                                                it_image_to_render = Properties.Resources.star_3;
                                                break;
                                            }
                                        case 4:
                                            {
                                                it_image_to_render = Properties.Resources.star_4;
                                                break;
                                            }
                                        case 5:
                                            {
                                                it_image_to_render = Properties.Resources.star_5;
                                                break;
                                            }
                                    }
                                }
                            }
                            else
                            {
                                switch (item_objects[it_index].SubItemsObjects[cl_index].Mode)
                                {
                                    case MLVItemDrawMode.Text:
                                        {
                                            it_render_text = true;
                                            it_render_image = false;
                                            it_text_to_render = item_objects[it_index].SubItemsObjects[cl_index].Text;
                                            it_text_use_custom_color = item_objects[it_index].SubItemsObjects[cl_index].UseCustomTextColor;
                                            it_text_custom_color = item_objects[it_index].SubItemsObjects[cl_index].CustomTextColor;
                                            break;
                                        }
                                    case MLVItemDrawMode.Image:
                                        {
                                            it_render_text = false;
                                            if (item_objects_images.Count > 0 && it_index_img < item_objects_images.Count)
                                            {
                                                if (item_objects_images[it_index_img].SubObjects.Count > 0)
                                                {
                                                    it_render_image = item_objects_images[it_index_img].SubObjects[cl_index].HasImage;
                                                    if (it_render_image)
                                                        it_image_to_render = item_objects_images[it_index_img].SubObjects[cl_index].Image;
                                                }
                                            }
                                            break;
                                        }
                                    case MLVItemDrawMode.User:
                                    case MLVItemDrawMode.TextImage:
                                        {
                                            it_render_text = true;
                                            it_text_to_render = item_objects[it_index].SubItemsObjects[cl_index].Text;
                                            it_text_use_custom_color = item_objects[it_index].SubItemsObjects[cl_index].UseCustomTextColor;
                                            it_text_custom_color = item_objects[it_index].SubItemsObjects[cl_index].CustomTextColor;
                                            if (item_objects_images.Count > 0 && it_index_img < item_objects_images.Count)
                                            {
                                                if (item_objects_images[it_index_img].SubObjects.Count > 0)
                                                {
                                                    it_render_image = item_objects_images[it_index_img].SubObjects[cl_index].HasImage;
                                                    if (it_render_image)
                                                        it_image_to_render = item_objects_images[it_index_img].SubObjects[cl_index].Image;
                                                }
                                            }
                                            break;
                                        }
                                }
                            }
                            // Is it selected
                            if (item_objects[it_index].Selected)
                            {
                                pe.Graphics.FillRectangle(new SolidBrush(ItemSelectionColor), new RectangleF(cl_x1 + it_temp_x, it_temp_y + 1, cl_objects[cl_index].W - it_temp_x, it_height - 1));
                            }
                            // Is this item is hieghlighted ?
                            else if (HeighlightedItemIndex == it_index)
                            {
                                pe.Graphics.FillRectangle(new SolidBrush(ItemHiehglightColor), new RectangleF(cl_x1 + it_temp_x, it_temp_y + 1, cl_objects[cl_index].W - it_temp_x, it_height - 1));
                            }
                            // Image first
                            if (it_render_image)
                            {
                                if (it_image_to_render != null)
                                {
                                    if (!it_temp_is_rating_image)
                                    {
                                        pe.Graphics.DrawImage(it_image_to_render, new Rectangle(cl_x1 + 2, it_temp_y + it_text_y_offset, it_text_size.Height + 4, it_text_size.Height + 4));
                                        it_temp_x += it_text_size.Height + 6;
                                    }
                                    else
                                    {
                                        // Rating image
                                        if (it_rating_image_width < cl_objects[cl_index].W)
                                            pe.Graphics.DrawImage(it_image_to_render, new Rectangle(cl_x1 + 2, it_temp_y + it_text_y_offset - 2, it_rating_image_width, it_text_size.Height + 4));
                                        else
                                            pe.Graphics.DrawImage(it_image_to_render, new Rectangle(cl_x1 + 2, it_temp_y + it_text_y_offset - 2, cl_objects[cl_index].W, it_text_size.Height + 4));
                                    }
                                }
                            }
                            // Now the text
                            if (it_render_text)
                            {
                                pe.Graphics.DrawString(it_text_to_render, items_default_font, new SolidBrush(it_text_use_custom_color ? it_text_custom_color : ItemTextColor),
                                new RectangleF(cl_x1 + it_temp_x + 2, it_temp_y + it_text_y_offset,
                                cl_objects[cl_index].W - 2 - it_temp_x, it_height), string_format);
                            }
                            if (ItemsSplitLines)
                            {
                                pe.Graphics.DrawLine(new Pen(new SolidBrush(ItemSplitLinesColor)), cl_x1, it_temp_y + it_height, cl_x2, it_temp_y + it_height);
                            }
                            // The item edge area ...
                            if (cl_index <= cl_start_index + 1)
                            {
                                // Draw heighlight or covering area.
                                Color bgcolor = BackColor;
                                if (item_objects[it_index].Selected)
                                    bgcolor = ItemSelectionColor;
                                else if (HeighlightedItemIndex == it_index)
                                    bgcolor = ItemHiehglightColor;

                                pe.Graphics.FillRectangle(new SolidBrush(bgcolor), new Rectangle(0, it_temp_y + 1, columns_start_x, it_height - 1));
                                // Draw image if possible. Only image is supported in the details mode.
                                if (item_objects_images.Count > 0 && it_index_img < item_objects_images.Count)
                                {
                                    if (item_objects_images[it_index_img].HasImage)
                                    {
                                        if (!item_objects[it_index].IsChild)
                                            pe.Graphics.DrawImage(item_objects_images[it_index_img].Image, new Rectangle(columns_start_x - it_height - 4, it_temp_y + it_text_y_offset + 2, it_text_size.Height + 2, it_text_size.Height + 2));
                                        else
                                            pe.Graphics.DrawImage(item_objects_images[it_index_img].Image, new Rectangle(columns_start_x - it_height + 4, it_temp_y + it_text_y_offset + 2, it_text_size.Height + 2, it_text_size.Height + 2));
                                    }
                                }

                                if (item_objects[it_index].HasChildren)
                                {
                                    if (item_objects[it_index].Collabsed)
                                    {
                                        Color plusColor = ItemTextColor;
                                        if (it_ms_on_collabse_area && (HeighlightedItemIndex == it_index))
                                        {
                                            plusColor = ItemCollabseAreaHeighlightColor;
                                            Size sz = TextRenderer.MeasureText("+", items_default_font);
                                            pe.Graphics.DrawRectangle(new Pen(new SolidBrush(plusColor)), new Rectangle(2, it_temp_y + it_text_y_offset + 2, sz.Width - 4, sz.Height - 3));
                                        }

                                        pe.Graphics.DrawString("+", items_default_font, new SolidBrush(plusColor), new Point(2, it_temp_y + it_text_y_offset));

                                    }
                                    else
                                    {
                                        Color plusColor = ItemTextColor;
                                        if (it_ms_on_collabse_area && (HeighlightedItemIndex == it_index))
                                        {
                                            plusColor = ItemCollabseAreaHeighlightColor;
                                            Size sz = TextRenderer.MeasureText("-", items_default_font);
                                            pe.Graphics.DrawRectangle(new Pen(new SolidBrush(plusColor)), new Rectangle(2, it_temp_y + it_text_y_offset + 2, sz.Width - 4, sz.Height - 3));
                                        }
                                        pe.Graphics.DrawString("-", items_default_font, new SolidBrush(plusColor), new Point(2, it_temp_y + it_text_y_offset));
                                    }
                                    it_collabse_area_x = 4 + it_text_size.Height;
                                }
                                if (ItemsSplitLines)
                                {
                                    pe.Graphics.DrawLine(new Pen(new SolidBrush(ItemSplitLinesColor), 2), 0, it_temp_y + it_height, columns_start_x, it_temp_y + it_height);
                                }
                            }
                            else if (cl_index == cl_end_index)
                            {
                                if (item_objects[it_index].Selected && HeighlightedItemIndex == it_index)
                                {
                                    int width = Width;
                                    if (cl_index == cl_objects.Count - 1)
                                        width = cl_objects[cl_objects.Count - 1].X2 - ScrollX;
                                    pe.Graphics.DrawRectangle(new Pen(new SolidBrush(ItemSelectionHeighlightColor)), new Rectangle(0, it_temp_y + 1, width, it_height - 1));
                                }
                            }
                            it_index_img++;

                        }
                    }
                }
                if (DoingColumnMoving)
                {
                    // Draw the column that it is moving on mouse coordinates
                    // Draw recangle
                    pe.Graphics.FillRectangle(new LinearGradientBrush(new Point(), new Point(0, columns_height - 1), ColumnColor, Color.White),
                            new Rectangle(ms_current_point.X, 10, cl_objects[cl_moved_index].W, columns_height - 1));

                    // Draw text
                    pe.Graphics.DrawString(cl_objects[cl_moved_index].Text, columns_font, new SolidBrush(ColumnTextColor),
                        new RectangleF(ms_current_point.X + cl_objects[cl_moved_index].TextXOffset, 10 + cl_text_y_offset,
                        cl_objects[cl_moved_index].W - cl_objects[cl_moved_index].TextXOffset, columns_text_size.Height + 2), string_format);
                }
                // Draw columns splitter lines
                pe.Graphics.DrawLine(new Pen(new SolidBrush(ColumnsSplitColor)), 0, columns_height, Width, columns_height);
                pe.Graphics.DrawLine(new Pen(new SolidBrush(ColumnsSplitColor)), columns_start_x, 0, columns_start_x, Height);
                // Draw icons area rectangle
                pe.Graphics.FillRectangle(new LinearGradientBrush(new Point(), new Point(0, columns_height - 1), ColumnColor, Color.White),
                          new Rectangle(0, 0, columns_start_x, columns_height - 2));

                // Draw the selection retangle if we must
                if (it_drawing_selection_rectangle)
                {
                    pe.Graphics.DrawRectangle(new Pen(new SolidBrush(SelectionRectangleColor)), it_selection_rectangle);
                }
            }
        }
        private void OnPaintThumbnailsMode(PaintEventArgs pe)
        {
            thm_blk_x = thm_blk_y = thm_blk_space;
            // Draw all item lines that can be drawable
            if (item_objects.Count > 0)
            {
                int it_index_img = 0;
                int it_index = it_start_index;
                //  for (int it_index = it_start_index; it_index <= it_end_index; it_index++)
                for (int i = 0; i < thm_blks_count_row; i++)
                {
                    for (int j = 0; j < thm_blks_count_cl; j++)
                    {
                        if (it_index >= item_objects.Count)
                        {
                            it_index = -1;
                            break;
                        }
                        // Is it selected
                        if (item_objects[it_index].Selected)
                        {
                            pe.Graphics.FillRectangle(new SolidBrush(ItemSelectionColor), new Rectangle(thm_blk_x, thm_blk_y, thm_blk_width, thm_blk_height));
                        }
                        // Is this item is hieghlighted ?
                        else if (HeighlightedItemIndex == it_index)
                        {
                            pe.Graphics.FillRectangle(new SolidBrush(ItemHiehglightColor), new Rectangle(thm_blk_x, thm_blk_y, thm_blk_width, thm_blk_height));
                        }
                        // Draw image
                        if (it_index_img < item_objects_images.Count)
                            if (item_objects_images[it_index_img].HasImage)
                                pe.Graphics.DrawImage(item_objects_images[it_index_img].Image, new Rectangle(
                                    thm_blk_x + item_objects_images[it_index_img].ImageRectangle.X,
                                    thm_blk_y + item_objects_images[it_index_img].ImageRectangle.Y,
                                    item_objects_images[it_index_img].ImageRectangle.Width,
                                    item_objects_images[it_index_img].ImageRectangle.Height));
                        // else
                        //     pe.Graphics.DrawImage(item_objects_images[i].Image, new Rectangle(thm_blk_x, thm_blk_y, thm_blk_width, thm_blk_img_area_height));

                        // Draw text
                        pe.Graphics.DrawString(item_objects[it_index].Text, items_default_font, new SolidBrush(item_objects[it_index].UseCustomTextColor ? item_objects[it_index].CustomTextColor : ItemTextColor),
                            new Rectangle(thm_blk_x + item_objects[it_index].TextRectangle.X, thm_blk_y + thm_blk_img_area_height + +item_objects[it_index].TextRectangle.Y,
                            thm_blk_width,
                            it_height),
                            string_format);

                        if (item_objects[it_index].Selected && HeighlightedItemIndex == it_index)
                        {
                            pe.Graphics.DrawRectangle(new Pen(new SolidBrush(ItemSelectionHeighlightColor)), new Rectangle(thm_blk_x, thm_blk_y, thm_blk_width, thm_blk_height));
                        }

                        thm_blk_x += thm_blk_width + thm_blk_space;

                        it_index_img++;
                        it_index++;
                        if (it_index >= item_objects.Count)
                        {
                            it_index = -1;
                            break;
                        }
                    }
                    if (it_index < 0)
                        break;
                    thm_blk_y += thm_blk_height + thm_blk_space;
                    thm_blk_x = thm_blk_space;
                }
                if (thmInfoVisible)
                {
                    int t_w = thmInfoRect.Width;
                    int t_h = thmInfoRect.Height;
                    if (thmInfoRating != -1)
                    {
                        t_h += 20;
                        if (t_w < 58)
                            t_w = 60;
                    }
                    int t_x = 1;
                    int t_y = this.Height - t_h + 1;


                    pe.Graphics.FillRectangle(new SolidBrush(ItemHiehglightColor), t_x, t_y, t_w, t_h);
                    pe.Graphics.DrawRectangle(Pens.Gray, t_x, t_y, t_w, t_h - 2);
                    pe.Graphics.DrawString(thmInfoText, items_default_font, new SolidBrush(Color.Black),
                    new Rectangle(t_x + 1, t_y, t_w, (thmInfoRating != -1) ? (t_h - 20) : t_h), string_format_thm_info);
                    if (thmInfoRating != -1)
                    {
                        switch (thmInfoRating)
                        {
                            case 0: pe.Graphics.DrawImage(Properties.Resources.noneRating, t_x + 1, this.Height - 20, 58, 18); break;
                            case 1: pe.Graphics.DrawImage(Properties.Resources.star_1, t_x + 1, this.Height - 20, 58, 18); break;
                            case 2: pe.Graphics.DrawImage(Properties.Resources.star_2, t_x + 1, this.Height - 20, 58, 18); break;
                            case 3: pe.Graphics.DrawImage(Properties.Resources.star_3, t_x + 1, this.Height - 20, 58, 18); break;
                            case 4: pe.Graphics.DrawImage(Properties.Resources.star_4, t_x + 1, this.Height - 20, 58, 18); break;
                            case 5: pe.Graphics.DrawImage(Properties.Resources.star_5, t_x + 1, this.Height - 20, 58, 18); break;
                        }
                    }
                }
            }
            // Draw the selection retangle if we must
            if (it_drawing_selection_rectangle)
            {
                pe.Graphics.DrawRectangle(new Pen(new SolidBrush(SelectionRectangleColor)), it_selection_rectangle);
            }
        }
        // RESIZING
        /// <summary>
        /// On resizing
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            switch (Mode)
            {
                case MLVMode.Details:
                    {
                        CalculateScrollMaxes();
                        CalculateColumnsIndiacs();
                        DetailsCalculateItemIndiacs();
                        break;
                    }
                case MLVMode.Thumbnails:
                    {
                        CalculateThumbnailsBlks();
                        CalculateScrollMaxes();
                        ThumbnailsCalculateItemIndiacs();
                        break;
                    }
            }
            CalculateBackgroundBounds();
            StartFillImagesBuffer();
            Invalidate();
        }
        // MOUSE HANDLING
        /// <summary>
        /// OnMouseMove
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            ms_current_point = e.Location;
            switch (Mode)
            {
                case MLVMode.Details:
                    {
                        OnMouseMoveDetails(e);
                        break;
                    }
                case MLVMode.Thumbnails:
                    {
                        OnMouseMoveThumbnails(e);
                        break;
                    }
            }
        }
        /// <summary>
        /// OnMouseDown
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            ms_down_point = e.Location;
            switch (Mode)
            {
                case MLVMode.Details:
                    {
                        OnMouseDownDetails(e);
                        break;
                    }
                case MLVMode.Thumbnails:
                    {
                        OnMouseDownThumbnails(e);
                        break;
                    }
            }
        }
        /// <summary>
        /// OnMouseUp
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            switch (Mode)
            {
                case MLVMode.Details:
                    {
                        OnMouseUpDetails(e);
                        break;
                    }
                case MLVMode.Thumbnails:
                    {
                        OnMouseUpThumbnails(e);
                        break;
                    }
            }
        }
        /// <summary>
        /// OnMouseClick
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (surpressClick)
            { surpressClick = false; return; }
            if (e.Button != MouseButtons.Left)
                return;
            OnEnter(e);
            switch (Mode)
            {
                case MLVMode.Details:
                    {
                        OnMouseClickDetails(e);
                        break;
                    }
                case MLVMode.Thumbnails:
                    {
                        OnMouseClickThumbnails(e);
                        break;
                    }
            }
        }
        /// <summary>
        /// OnMouseWheel
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                SetScrollY(ScrollY - 2);
                UpdateScrollBars?.Invoke(this, new EventArgs());
            }
            if (e.Delta < 0)
            {
                SetScrollY(ScrollY + 2);
                UpdateScrollBars?.Invoke(this, new EventArgs());
            }
            base.OnMouseWheel(e);
        }
        /// <summary>
        /// OnEnter
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

        }
        internal void OnKeyDownRaised(KeyEventArgs e)
        {
            switch (Mode)
            {
                case MLVMode.Details:
                    {
                        OnKeyDownDetails(e);
                        break;
                    }
                case MLVMode.Thumbnails:
                    {
                        OnKeyDownThumbnails(e);
                        break;
                    }
            }
        }
        // --ON KEY DOWN
        private void OnKeyDownDetails(KeyEventArgs e)
        {
            #region Page up/down
            if (item_objects.Count > 0)
            {
                if (e.KeyCode == Keys.PageUp)
                {
                    // Page Up means select the first item only then scroll to that item
                    // Select nothing
                    ClearSelectionBufferAndUnselect();
                    // Select the first item
                    SwitchItemLineSelection(0, true);
                    // Scroll
                    SetScrollY(0);
                    return;
                }
                else if (e.KeyCode == Keys.PageDown)
                {
                    // Page Down means select the last item only then scroll to that item
                    // Select nothing
                    ClearSelectionBufferAndUnselect();
                    // Select the first item
                    string o_id = item_objects[item_objects.Count - 1].OID;
                    if (!item_objects[item_objects.Count - 1].IsChild)
                    {
                        Items[o_id].Selected = true;// This will toggle the internal event which handles the collabse internally.
                    }
                    else
                    {
                        o_id = item_objects[item_objects.Count - 1].ParentItemOID;
                        // This will toggle the internal event which handles the collabse internally.
                        Items[o_id].ChildItems[item_objects[item_objects.Count - 1].OID].Selected = true;
                    }
                    UpdateItemOnSelectionBuffer(item_objects[item_objects.Count - 1]);
                    // Scroll
                    SetScrollY(ScrollYMax - 1);
                    return;
                }
            }
            #endregion
            #region Single item selected
            if (selection_buffer.Count == 1)
            {
                int index = GetItemLineObjectIndex(selection_buffer[0]);
                if (e.KeyCode == Keys.Down)
                {
                    if (index + 1 < item_objects.Count)
                    {
                        // Select nothing
                        ClearSelectionBufferAndUnselect();
                        index++;
                        // Select the element after
                        SwitchItemLineSelection(index, true);
                        // Scroll
                        SetScrollY(index);
                        Invalidate();
                    }
                }
                else if (e.KeyCode == Keys.Up)
                {
                    if (index - 1 >= 0)
                    {
                        // Select nothing
                        ClearSelectionBufferAndUnselect();
                        index--;
                        // Select the element before
                        SwitchItemLineSelection(index, true);
                        // Scroll
                        SetScrollY(index);
                        Invalidate();
                    }
                }
                else if (e.KeyCode == Keys.Return)
                {
                    EnterPressedOverItem?.Invoke(this, new EventArgs());
                }
                else//char ?
                {
                    KeysConverter conv = new KeysConverter();
                    if (conv.ConvertToString(e.KeyCode) != currentSearchChar)
                    {
                        // Select nothing
                        ClearSelectionBufferAndUnselect();
                        index = 0;
                    }
                    currentSearchChar = conv.ConvertToString(e.KeyCode);
                    for (int i = index + 1; i < item_objects.Count; i++)
                    {
                        if (item_objects[i].SubItemsObjects.Count > 0)
                        {
                            string text = item_objects[i].SubItemsObjects[0].Text;

                            if (text.Length > 0)
                            {
                                if (text.Substring(0, 1) == conv.ConvertToString(e.KeyCode))
                                {
                                    SwitchItemLineSelection(index, false);
                                    SwitchItemLineSelection(i, true);
                                    SetScrollY(i);
                                    UpdateScrollBars?.Invoke(this, new EventArgs());
                                    Invalidate();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #region Multi selection
            else if (selection_buffer.Count > 1)
            {
                int index = GetItemLineObjectIndex(selection_buffer[0]);
                KeysConverter conv = new KeysConverter();
                for (int i = index + 1; i < item_objects.Count; i++)
                {
                    if (item_objects[i].SubItemsObjects.Count > 0)
                    {
                        string text = item_objects[i].SubItemsObjects[0].Text;

                        if (text.Length > 0)
                        {
                            if (text.Substring(0, 1) == conv.ConvertToString(e.KeyCode))
                            {
                                SwitchItemLineSelection(index, false);
                                SwitchItemLineSelection(i, true);
                                SetScrollY(i);
                                UpdateScrollBars?.Invoke(this, new EventArgs()); Invalidate();
                                break;
                            }
                        }
                    }
                }
            }
            #endregion
            #region No selection
            else
            {
                KeysConverter conv = new KeysConverter();
                for (int i = 0; i < item_objects.Count; i++)
                {
                    if (item_objects[i].SubItemsObjects.Count > 0)
                    {
                        string text = item_objects[i].SubItemsObjects[0].Text;

                        if (text.Length > 0)
                        {
                            if (text.Substring(0, 1) == conv.ConvertToString(e.KeyCode))
                            {
                                SwitchItemLineSelection(i, true);
                                SetScrollY(i);
                                UpdateScrollBars?.Invoke(this, new EventArgs()); Invalidate();
                                break;
                            }
                        }
                    }
                }
            }
            #endregion
        }
        private void OnKeyDownThumbnails(KeyEventArgs e)
        {

        }
        // --ON MOVE
        private void OnMouseMoveDetails(MouseEventArgs e)
        {
            bool doInvalidate = false;
            bool mouseShapeChanged = false;
            ms_current_point_as_view_port = new Point(e.X + ScrollX, e.Y + (ScrollY * it_height));
            // Doing actions...
            if (e.Button == MouseButtons.Left)
            {
                if (IsResizingColumn)// Column resize
                {
                    Cursor = Cursors.VSplit;
                    int new_width = e.X + ScrollX - cl_column_resized_original_x1;
                    if (!cl_objects[HeighlightedColumnIndex].ContainRatingSubItem)
                    {
                        if (new_width >= cl_min_w)
                        {
                            cl_objects[HeighlightedColumnIndex].W = new_width;
                            cl_objects[HeighlightedColumnIndex].X2 = cl_objects[HeighlightedColumnIndex].X1 + new_width;
                            Columns[HeighlightedColumnIndex].Width = new_width;
                            for (int i = HeighlightedColumnIndex + 1; i < cl_objects.Count; i++)
                            {
                                if (i - 1 >= 0)
                                {
                                    cl_objects[i].X1 = cl_objects[i - 1].X2 + 1;
                                    cl_objects[i].X2 = cl_objects[i].X1 + cl_objects[i].W;
                                }
                            }
                            doInvalidate = true;
                            mouseShapeChanged = true;
                            CalculateColumnsIndiacs();
                            CalculateScrollMaxes();
                        }
                    }
                    else
                    {
                        if (new_width >= (it_rating_image_width + 10))
                        {
                            cl_objects[HeighlightedColumnIndex].W = new_width;
                            cl_objects[HeighlightedColumnIndex].X2 = cl_objects[HeighlightedColumnIndex].X1 + new_width;
                            Columns[HeighlightedColumnIndex].Width = new_width;
                            for (int i = HeighlightedColumnIndex + 1; i < cl_objects.Count; i++)
                            {
                                if (i - 1 >= 0)
                                {
                                    cl_objects[i].X1 = cl_objects[i - 1].X2 + 1;
                                    cl_objects[i].X2 = cl_objects[i].X1 + cl_objects[i].W;
                                }
                            }
                            doInvalidate = true;
                            mouseShapeChanged = true;
                            CalculateColumnsIndiacs();
                            CalculateScrollMaxes();
                        }
                    }
                }
                else if (IsMovingColumn)// Column moving (reorder)
                {
                    if (cl_moved_index >= 0)
                    {
                        DoingColumnMoving = true;
                        doInvalidate = true;
                        CalculateHeighlightedColumnIndex(e);
                    }
                }
                else if (IsChangingColumnHeight)// Column height changing
                {
                    Cursor = Cursors.HSplit;
                    if (e.Y >= columns_min_height && e.Y <= columns_max_height)
                    {
                        mouseShapeChanged = true;
                        columns_height = e.Y;
                        cl_text_y_offset = (columns_height / 2) - (columns_text_size.Height / 2);
                        doInvalidate = true;
                    }
                }
                else if (it_drawing_selection_rectangle)
                {
                    // Setup the rectangle
                    SetupSelectionRectangle(ScrollX, ScrollY * it_height);
                    DetailsSelectItemsOnSelectionRectangle();
                    DetailsCalculateItemIndiacs();
                    StartFillImagesBuffer();
                    doInvalidate = true;
                }
                else if (AllowDragItems)
                {
                    if (!items_draged)
                    {
                        if (HeighlightedItemIndex >= 0)
                            if (selection_buffer.Count > 0)
                                if (selection_buffer.Contains(item_objects[HeighlightedItemIndex].OID))
                                    if (e.X > ms_down_point.X + ColumnResizingSensitivity
                                     || e.X < ms_down_point.X - ColumnResizingSensitivity
                                     || e.Y > ms_down_point.Y + ColumnResizingSensitivity
                                     || e.Y < ms_down_point.Y - ColumnResizingSensitivity)
                                    {
                                        items_draged = true;
                                        ItemsDrag?.Invoke(this, new EventArgs());
                                    }
                    }
                }
                // On edges
                if (IsResizingColumn || IsMovingColumn || it_drawing_selection_rectangle)
                {
                    if (ScrollX > 0)
                    {
                        // On the left
                        if (e.X < columns_start_x + 15)
                        {
                            SetScrollX(ScrollX - 10);
                            UpdateScrollBars?.Invoke(this, new EventArgs());
                        }
                    }
                    if (ScrollXMax > 0)
                    {
                        // On the right
                        if (e.X > (Width - 15))
                        {
                            SetScrollX(ScrollX + 10);
                            UpdateScrollBars?.Invoke(this, new EventArgs());
                        }
                    }
                    if (it_drawing_selection_rectangle)
                    {
                        if (ScrollY > 0)
                        {
                            // On up
                            if (e.Y < columns_height - 15)
                            {
                                SetScrollY(ScrollY - 10);
                                UpdateScrollBars?.Invoke(this, new EventArgs());
                            }
                        }
                        if (ScrollYMax > 0)
                        {
                            // On the right
                            if (e.Y > (Height - 15))
                            {
                                SetScrollY(ScrollY + 10);
                                UpdateScrollBars?.Invoke(this, new EventArgs());
                            }
                        }
                    }
                }
            }
            else// Detecting actions ...
            {
                items_draged = false;
                int min_x = e.X - ColumnResizingSensitivity;
                int max_x = e.X + ColumnResizingSensitivity;
                int min_y = e.Y - ColumnResizingSensitivity;
                int max_y = e.Y + ColumnResizingSensitivity;
                IsChangingColumnHeight = false;
                IsResizingColumn = false;
                IsMovingColumn = false;
                DoingColumnMoving = false;
                // Resizing column
                int new_column_hl_index = -1;
                int new_item_hl_index = -1;
                it_details_cl_index = -1;
                bool on_collabse_area = false;
                it_show_rating = false;
                if (cl_objects.Count > 0)
                {
                    // Get the item index
                    if (item_objects.Count > 0 && e.Y > columns_height && ((e.X + ScrollX) <= cl_objects[cl_objects.Count - 1].X2))
                    {
                        new_item_hl_index = ((e.Y - columns_height) / it_height) + ScrollY;
                        if (new_item_hl_index >= item_objects.Count)
                            new_item_hl_index = -1;
                    }
                    // Get the column index
                    for (int index = cl_start_index; index <= cl_end_index; index++)
                    {
                        if (e.X >= (cl_objects[index].X1 - ScrollX) && e.X <= (cl_objects[index].X2 - ScrollX))
                        {
                            it_details_cl_index = index;
                            break;
                        }
                    }

                    if (e.Y < columns_height)
                    {
                        OnHideTooltip();
                        // Set current column index
                        new_column_hl_index = it_details_cl_index;
                        if (it_details_cl_index >= 0)
                        {
                            if (ColumnsCanBeResized)
                            {
                                if (min_x <= (cl_objects[it_details_cl_index].X2 - ScrollX) && max_x >= (cl_objects[it_details_cl_index].X2 - ScrollX))
                                {
                                    cl_column_resized_original_x1 = cl_objects[it_details_cl_index].X1;

                                    IsResizingColumn = true;
                                    Cursor = Cursors.VSplit;
                                    mouseShapeChanged = true;
                                }
                            }
                            if (e.X >= (cl_objects[it_details_cl_index].X1 - ScrollX) && e.X <= (cl_objects[it_details_cl_index].X2 - ScrollX))
                            {
                                if (ColumnsCanBeReordered)
                                {
                                    cl_moved_index = new_column_hl_index;
                                    IsMovingColumn = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        // RATING CHANGE ?
                        if (new_item_hl_index >= 0)
                        {
                            if (it_details_cl_index >= 0)
                            {
                                // See what subitem we are heighlighting
                                if (item_objects[new_item_hl_index].SubItemsObjects[it_details_cl_index].IsRatingSubItem)
                                {
                                    OnHideTooltip();
                                    it_show_rating = true;
                                    double blk = it_rating_image_width / 5;
                                    double pp = e.X - cl_objects[it_details_cl_index].X1;
                                    it_possible_rating = (int)Math.Ceiling(pp / blk);
                                    it_possible_rating_it_index = new_item_hl_index;
                                    doInvalidate = true;
                                }
                                else// Show tooltip !
                                {
                                    Size ss = TextRenderer.MeasureText(item_objects[new_item_hl_index].SubItemsObjects[it_details_cl_index].Text, items_default_font);
                                    if (cl_objects[it_details_cl_index].W <= ss.Width)
                                    {
                                        int x = cl_objects[it_details_cl_index].X1 + it_text_size.Height + 6;
                                        int y = columns_height + ((new_item_hl_index - ScrollY) * it_height);
                                        OnShowTooltip(it_details_cl_index + "_" + new_item_hl_index, item_objects[new_item_hl_index].SubItemsObjects[it_details_cl_index].Text, new Point(x, y));
                                    }
                                    else
                                        OnHideTooltip();
                                }
                            }
                            else
                                OnHideTooltip();
                        }
                        else
                            OnHideTooltip();
                    }

                    // Changing columns height
                    if (ColumnHeightCanBeChanged)
                    {
                        if (min_y <= columns_height && max_y >= columns_height)
                        {
                            IsChangingColumnHeight = true;
                            IsMovingColumn = false;
                            IsResizingColumn = false;
                            Cursor = Cursors.HSplit;
                            mouseShapeChanged = true;
                        }
                    }
                }
                else
                    OnHideTooltip();

                on_collabse_area = (e.X <= it_collabse_area_x);
                if (on_collabse_area != it_ms_on_collabse_area)
                {
                    it_ms_on_collabse_area = on_collabse_area;
                    doInvalidate = true;
                }
                if (HeighlightedColumnIndex != new_column_hl_index)
                {
                    HeighlightedColumnIndex = new_column_hl_index;
                    doInvalidate = true;
                }
                if (HeighlightedItemIndex != new_item_hl_index)
                {
                    HeighlightedItemIndex = new_item_hl_index;
                    doInvalidate = true;
                }
            }

            if (doInvalidate)
                Invalidate();
            if (!mouseShapeChanged)
                if (Cursor != Cursors.Default)
                    Cursor = Cursors.Default;
        }
        private void OnMouseMoveThumbnails(MouseEventArgs e)
        {
            bool doInvalidate = false;
            bool mouseShapeChanged = false;
            ms_current_point_as_view_port = new Point(e.X, e.Y + (ScrollY * thm_blks_count_cl));
            // Doing actions...
            if (e.Button == MouseButtons.Left)
            {
                if (it_drawing_selection_rectangle)
                {
                    // Setup the rectangle
                    SetupSelectionRectangle(0, ScrollY * thm_blks_count_cl);
                    ThumbnailsSelectItemsOnSelectionRectangle();
                    ThumbnailsCalculateItemIndiacs();
                    StartFillImagesBuffer();
                    doInvalidate = true;
                }
                else if (AllowDragItems)
                {
                    if (!items_draged)
                    {
                        if (HeighlightedItemIndex >= 0)
                            if (selection_buffer.Count > 0)
                                if (selection_buffer.Contains(item_objects[HeighlightedItemIndex].OID))
                                    if (e.X > ms_down_point.X + ColumnResizingSensitivity
                                     || e.X < ms_down_point.X - ColumnResizingSensitivity
                                     || e.Y > ms_down_point.Y + ColumnResizingSensitivity
                                     || e.Y < ms_down_point.Y - ColumnResizingSensitivity)
                                    {
                                        items_draged = true;
                                        ItemsDrag?.Invoke(this, new EventArgs());
                                    }
                    }
                }
                // On edges
                if (it_drawing_selection_rectangle)
                {
                    if (ScrollX > 0)
                    {
                        // On the left
                        if (e.X < columns_start_x + 15)
                        {
                            SetScrollX(ScrollX - 10);
                            UpdateScrollBars?.Invoke(this, new EventArgs());
                        }
                    }
                    if (ScrollXMax > 0)
                    {
                        // On the right
                        if (e.X > (Width - 15))
                        {
                            SetScrollX(ScrollX + 10);
                            UpdateScrollBars?.Invoke(this, new EventArgs());
                        }
                    }
                    if (it_drawing_selection_rectangle)
                    {
                        if (ScrollY > 0)
                        {
                            // On up
                            if (e.Y < columns_height - 15)
                            {
                                SetScrollY(ScrollY - 10);
                                UpdateScrollBars?.Invoke(this, new EventArgs());
                            }
                        }
                        if (ScrollYMax > 0)
                        {
                            // On the right
                            if (e.Y > (Height - 15))
                            {
                                SetScrollY(ScrollY + 10);
                                UpdateScrollBars?.Invoke(this, new EventArgs());
                            }
                        }
                    }
                }
            }
            else// Detecting actions ...
            {
                items_draged = false;
                int min_x = e.X - ColumnResizingSensitivity;
                int max_x = e.X + ColumnResizingSensitivity;
                int min_y = e.Y - ColumnResizingSensitivity;
                int max_y = e.Y + ColumnResizingSensitivity;
                int new_item_hl_index = -1;

                int row = (e.Y / (thm_blk_height + thm_blk_space));
                if (row > thm_blks_count_row - 1)
                {
                    goto CHECKINDEX;
                }

                int cl = (e.X / (thm_blk_width + thm_blk_space));
                if (cl > thm_blks_count_cl - 1)
                {
                    goto CHECKINDEX;
                }

                new_item_hl_index = (row * thm_blks_count_cl) + cl + it_start_index;

                if (new_item_hl_index >= item_objects.Count)
                    new_item_hl_index = -1;

                CHECKINDEX:
                if (HeighlightedItemIndex != new_item_hl_index)
                {
                    HeighlightedItemIndex = new_item_hl_index;
                    doInvalidate = true;
                }
                // Tooltip
                if (HeighlightedItemIndex >= 0)
                {
                    Size ss = TextRenderer.MeasureText(item_objects[new_item_hl_index].Text, items_default_font);
                    if (thm_blk_width <= ss.Width)
                    {
                        cl = (e.X / (thm_blk_width + thm_blk_space));
                        int x = cl * (thm_blk_width + thm_blk_space);
                        row = (e.Y / (thm_blk_height + thm_blk_space));
                        int y = row * (thm_blk_height + thm_blk_space);
                        y += thm_blk_img_area_height + 2;
                        OnShowTooltip(it_details_cl_index + "_" + new_item_hl_index, item_objects[new_item_hl_index].Text, new Point(x, y));
                    }
                    else
                        OnHideTooltip();

                    if (ShowItemInfoOnThumbnailMode)
                    {
                        OnShowThumpnailInfo(new_item_hl_index, item_objects[new_item_hl_index].Text);
                    }
                    else
                    {
                        OnHideThumbnailInfo();
                        OnHideTooltip();
                    }
                }
                else
                {
                    OnHideThumbnailInfo();
                    OnHideTooltip();
                }
            }

            if (doInvalidate)
                Invalidate();
            if (!mouseShapeChanged)
                if (Cursor != Cursors.Default)
                    Cursor = Cursors.Default;
        }
        // --ON DOWN
        private void OnMouseDownDetails(MouseEventArgs e)
        {
            ms_down_point_as_view_port = new Point(e.X + ScrollX, e.Y + (ScrollY * it_height));
            if (!IsResizingColumn && !IsMovingColumn && !IsChangingColumnHeight)
                it_drawing_selection_rectangle = HeighlightedItemIndex < 0;
            else
                it_drawing_selection_rectangle = false;
        }
        private void OnMouseDownThumbnails(MouseEventArgs e)
        {
            ms_down_point_as_view_port = new Point(e.X, e.Y + (ScrollY * thm_blks_count_cl));
            it_drawing_selection_rectangle = HeighlightedItemIndex < 0;
        }
        // --ON UP
        private void OnMouseUpDetails(MouseEventArgs e)
        {
            if (IsResizingColumn)
            {
                IsResizingColumn = false;
                ColumnResized?.Invoke(this, new ColumnEventArgs(HeighlightedColumnIndex, cl_objects[HeighlightedColumnIndex].ID));
            }
            if (IsChangingColumnHeight)
            {
                IsChangingColumnHeight = false;
                ColumnsAreaResized?.Invoke(this, new EventArgs());
            }
            if (IsMovingColumn)
            {
                IsMovingColumn = false;
                DoingColumnMoving = false;
                if (HeighlightedColumnIndex != cl_moved_index && HeighlightedColumnIndex >= 0)
                {
                    // Get the original column
                    MLVColumn or_cl = Columns[cl_moved_index];
                    // Remove it
                    Columns.RemoveAt(cl_moved_index);
                    // Insert it
                    Columns.Insert(HeighlightedColumnIndex, or_cl);

                    ColumnReordered?.Invoke(this, new ColumnEventArgs(HeighlightedColumnIndex, or_cl.ID));
                    CalculateColumnsObject();
                    CalculateColumnsIndiacs();
                    CalculateScrollMaxes();
                }
                cl_moved_index = -1;
                StartFillImagesBuffer();
            }
            if (it_drawing_selection_rectangle)
            {
                it_drawing_selection_rectangle = false;
                Invalidate();
            }
            items_draged = false;
        }
        private void OnMouseUpThumbnails(MouseEventArgs e)
        {
            if (it_drawing_selection_rectangle)
            {
                it_drawing_selection_rectangle = false;
                Invalidate();
            }
            items_draged = false;
        }
        // --ON CLICK
        private void OnMouseClickDetails(MouseEventArgs e)
        {
            if (IsResizingColumn || IsMovingColumn || IsChangingColumnHeight)
                return;
            if (it_show_rating)
            {
                // RATING CHANGE
                if (it_details_cl_index >= 0 && it_possible_rating_it_index >= 0)
                {
                    // Select that item
                    string o_id = item_objects[it_possible_rating_it_index].OID;
                    MLVSubItem sub = null;
                    if (!item_objects[it_possible_rating_it_index].IsChild)
                    {
                        sub = Items[o_id].SubItems[cl_objects[it_details_cl_index].ID];
                    }
                    else
                    {
                        o_id = item_objects[it_possible_rating_it_index].ParentItemOID;
                        // This will toggle the internal event which handles the collabse internally.
                        sub = Items[o_id].ChildItems[item_objects[it_possible_rating_it_index].OID].SubItems[cl_objects[it_details_cl_index].ID];
                    }
                    if (sub != null)
                    {
                        if (sub is MLVRatingSubItem)
                        {
                            int old = ((MLVRatingSubItem)sub).Rating;

                            if (old != it_possible_rating)
                            {
                                RatingChangedEventArgs args = null;
                                if (!item_objects[it_possible_rating_it_index].IsChild)
                                    args = new RatingChangedEventArgs(sub.ID, item_objects[it_possible_rating_it_index].Index, -1,
                                        it_possible_rating, old);
                                else
                                    args = new RatingChangedEventArgs(sub.ID, item_objects[it_possible_rating_it_index].ParentItemIndex,
                                        item_objects[it_possible_rating_it_index].Index, it_possible_rating, old);
                                if (!args.Cancel)
                                {
                                    ((MLVRatingSubItem)sub).Rating = it_possible_rating;
                                    RatingChangedOfSubItem.Invoke(this, args);
                                }
                            }
                        }
                    }
                }
            }
            else if (HeighlightedItemIndex >= 0)
            {
                if (it_ms_on_collabse_area)
                {
                    string oid = item_objects[HeighlightedItemIndex].OID;
                    Items[oid].ChildItemsCollabsed = !Items[oid].ChildItemsCollabsed;// This will toggle the internal event which handles the collabse internally.
                }
                else// Selection
                {
                    bool shift_holded = (ModifierKeys & Keys.Shift) == Keys.Shift;
                    bool control_holded = (ModifierKeys & Keys.Control) == Keys.Control;
                    string oid = item_objects[HeighlightedItemIndex].OID;
                    // Get the original value
                    bool orginal_value = false;
                    if (!item_objects[HeighlightedItemIndex].IsChild)
                    {
                        orginal_value = Items[oid].Selected;// This will toggle the internal event which handles the collabse internally.
                    }
                    else
                    {
                        oid = item_objects[HeighlightedItemIndex].ParentItemOID;
                        orginal_value = Items[oid].ChildItems[item_objects[HeighlightedItemIndex].OID].Selected;
                    }

                    if (shift_holded)
                    {
                        // Select all items heading from first selected item
                        if (selection_buffer.Count > 0)
                        {
                            // Get the index of the first previously selected item
                            int first_selected_index = 0;
                            foreach (string key in selection_buffer)
                            {
                                first_selected_index = GetItemLineObjectIndex(key);
                                break;
                            }
                            // The same index, this mean normal selection. Clear all selection buffer
                            ClearSelectionBufferAndUnselect();
                            // See which way we should go, down or up
                            if (first_selected_index != HeighlightedItemIndex)
                            {
                                if (first_selected_index < HeighlightedItemIndex)
                                {
                                    for (int i = first_selected_index; i < HeighlightedItemIndex; i++)
                                    {
                                        // Select that item
                                        string o_id = item_objects[i].OID;
                                        if (!item_objects[i].IsChild)
                                        {
                                            Items[o_id].Selected = true;// This will toggle the internal event which handles the collabse internally.
                                        }
                                        else
                                        {
                                            o_id = item_objects[i].ParentItemOID;
                                            // This will toggle the internal event which handles the collabse internally.
                                            Items[o_id].ChildItems[item_objects[i].OID].Selected = true;
                                        }
                                    }
                                }
                                else
                                {
                                    for (int i = HeighlightedItemIndex + 1; i <= first_selected_index; i++)
                                    {
                                        // Select that item
                                        string o_id = item_objects[i].OID;
                                        if (!item_objects[i].IsChild)
                                        {
                                            Items[o_id].Selected = true;// This will toggle the internal event which handles the collabse internally.
                                        }
                                        else
                                        {
                                            o_id = item_objects[i].ParentItemOID;
                                            // This will toggle the internal event which handles the collabse internally.
                                            Items[o_id].ChildItems[item_objects[i].OID].Selected = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // The same index, this mean normal selection. Do nothing since we are already cleared the selection buffer.
                            }
                        }
                    }
                    else if (control_holded)
                    {
                        // No need to do anything ...
                    }
                    else // Clear all pervious selections
                        ClearSelectionBufferAndUnselect();


                    if (!item_objects[HeighlightedItemIndex].IsChild)
                    {
                        Items[oid].Selected = !orginal_value;// This will toggle the internal event which handles the collabse internally.
                    }
                    else
                    {
                        oid = item_objects[HeighlightedItemIndex].ParentItemOID;
                        // This will toggle the internal event which handles the collabse internally.
                        Items[oid].ChildItems[item_objects[HeighlightedItemIndex].OID].Selected = !orginal_value;
                    }
                }
            }
            else
            {
                // Clicking on empty areas ... this should clear all selection.
                ClearSelectionBufferAndUnselect();
            }
        }
        private void OnMouseClickThumbnails(MouseEventArgs e)
        {
            if (HeighlightedItemIndex >= 0)
            {
                bool shift_holded = (ModifierKeys & Keys.Shift) == Keys.Shift;
                bool control_holded = (ModifierKeys & Keys.Control) == Keys.Control;
                string oid = item_objects[HeighlightedItemIndex].OID;
                // Get the original value
                bool orginal_value = false;
                if (!item_objects[HeighlightedItemIndex].IsChild)
                {
                    orginal_value = Items[oid].Selected;// This will toggle the internal event which handles the collabse internally.
                }
                else
                {
                    oid = item_objects[HeighlightedItemIndex].ParentItemOID;
                    orginal_value = Items[oid].ChildItems[item_objects[HeighlightedItemIndex].OID].Selected;
                }

                if (shift_holded)
                {
                    // Select all items heading from first selected item
                    if (selection_buffer.Count > 0)
                    {
                        // Get the index of the first previously selected item
                        int first_selected_index = 0;
                        foreach (string key in selection_buffer)
                        {
                            first_selected_index = GetItemLineObjectIndex(key);
                            break;
                        }
                        // The same index, this mean normal selection. Clear all selection buffer
                        ClearSelectionBufferAndUnselect();
                        // See which way we should go, down or up
                        if (first_selected_index != HeighlightedItemIndex)
                        {
                            if (first_selected_index < HeighlightedItemIndex)
                            {
                                for (int i = first_selected_index; i < HeighlightedItemIndex; i++)
                                {
                                    // Select that item
                                    string o_id = item_objects[i].OID;
                                    if (!item_objects[i].IsChild)
                                    {
                                        Items[o_id].Selected = true;// This will toggle the internal event which handles the collabse internally.
                                    }
                                    else
                                    {
                                        o_id = item_objects[i].ParentItemOID;
                                        // This will toggle the internal event which handles the collabse internally.
                                        Items[o_id].ChildItems[item_objects[i].OID].Selected = true;
                                    }
                                }
                            }
                            else
                            {
                                for (int i = HeighlightedItemIndex + 1; i <= first_selected_index; i++)
                                {
                                    // Select that item
                                    string o_id = item_objects[i].OID;
                                    if (!item_objects[i].IsChild)
                                    {
                                        Items[o_id].Selected = true;// This will toggle the internal event which handles the collabse internally.
                                    }
                                    else
                                    {
                                        o_id = item_objects[i].ParentItemOID;
                                        // This will toggle the internal event which handles the collabse internally.
                                        Items[o_id].ChildItems[item_objects[i].OID].Selected = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // The same index, this mean normal selection. Do nothing since we are already cleared the selection buffer.
                        }
                    }
                }
                else if (control_holded)
                {
                    // No need to do anything ...
                }
                else // Clear all pervious selections
                    ClearSelectionBufferAndUnselect();


                if (!item_objects[HeighlightedItemIndex].IsChild)
                {
                    Items[oid].Selected = !orginal_value;// This will toggle the internal event which handles the collabse internally.
                }
                else
                {
                    oid = item_objects[HeighlightedItemIndex].ParentItemOID;
                    // This will toggle the internal event which handles the collabse internally.
                    Items[oid].ChildItems[item_objects[HeighlightedItemIndex].OID].Selected = !orginal_value;
                }
            }
            else
            {
                // Clicking on empty areas ... this should clear all selection.
                ClearSelectionBufferAndUnselect();
            }
        }
        /// <summary>
        /// WndProc
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 257)// Key up !
            {
                // Fix when the window is no longer receive keydown events.
                OnKeyDownRaised(new KeyEventArgs((Keys)m.WParam));
            }
        }

        // Events
        /// <summary>
        /// ColumnsFontChanged
        /// </summary>
        public event EventHandler ColumnsFontChanged;
        /// <summary>
        /// ItemsFontChanged
        /// </summary>
        public event EventHandler ItemsFontChanged;
        /// <summary>
        /// RefreshScrollX
        /// </summary>
        public event EventHandler RefreshScrollX;
        /// <summary>
        /// RefreshScrollY
        /// </summary>
        public event EventHandler RefreshScrollY;
        /// <summary>
        /// UpdateScrollBars
        /// </summary>
        public event EventHandler UpdateScrollBars;
        /// <summary>
        /// ColumnResized
        /// </summary>
        public event EventHandler<ColumnEventArgs> ColumnResized;
        /// <summary>
        /// ColumnReordered
        /// </summary>
        public event EventHandler<ColumnEventArgs> ColumnReordered;
        /// <summary>
        /// ColumnsAreaResized
        /// </summary>
        public event EventHandler ColumnsAreaResized;
        /// <summary>
        /// ItemsDrag
        /// </summary>
        public event EventHandler ItemsDrag;
        /// <summary>
        /// EnterPressedOverItem
        /// </summary>
        public event EventHandler EnterPressedOverItem;
        /// <summary>
        /// RatingChangedOfSubItem
        /// </summary>
        public event EventHandler<RatingChangedEventArgs> RatingChangedOfSubItem;
        /// <summary>
        /// HideTooltip
        /// </summary>
        public event EventHandler HideTooltip;
        /// <summary>
        /// ShowTooltip
        /// </summary>
        public event EventHandler<ShowTooltipEventArgs> ShowTooltip;
        /// <summary>
        /// HideThumbnailInfo
        /// </summary>
        public event EventHandler HideThumbnailInfo;
        /// <summary>
        /// ShowThumbnailInfo
        /// </summary>
        public event EventHandler<ShowThumbnailInfoEventArgs> ShowThumbnailInfo;
        /// <summary>
        /// Raised when the control need to draw an item and that item draw mode is UserDrawMode.
        /// </summary>
        public event EventHandler<MLVDrawItemEventArgs> DrawItem;
        /// <summary>
        /// Raised when the control need to draw a sub item and that sub item draw mode is UserDrawMode.
        /// </summary>
        public event EventHandler<MLVDrawSubItemEventArgs> DrawSubItem;
    }
}
