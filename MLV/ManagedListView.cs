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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MLV
{
    /// <summary>
    /// Managed ListView Control.
    /// </summary>
    public partial class ManagedListView : UserControl
    {
        /// <summary>
        /// Managed ListView Control.
        /// </summary>
        public ManagedListView()
        {
            InitializeComponent();

        }

        private bool surpressScrolling;

        /*PROPERTIES*/
        /// <summary>
        /// Get the columns collection
        /// </summary>
        [Browsable(true)]
        [Description("The columns collection. Used only on Details mode."), Category("ManagedListView")]
        public MLVColumnsCollection Columns
        { get { return mlvPanel1.Columns; } }
        /// <summary>
        /// Get the items collection
        /// </summary>
        [Browsable(true)]
        [Description("The items collection."), Category("ManagedListView")]
        public MLVItemsCollection Items
        { get { return mlvPanel1.Items; } }
        /// <summary>
        /// Get or set the font that will be used for columns
        /// </summary>
        [Browsable(true)]
        [Description("The font to use for column texts."), Category("ManagedListView")]
        public Font ColumnsFont
        {
            get { return mlvPanel1.ColumnsFont; }
            set
            {
                if (mlvPanel1.ColumnsFont != value)
                {
                    mlvPanel1.ColumnsFont = value;
                    mlvPanel1.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the list mode
        /// </summary>
        [Browsable(true)]
        [Description("The list mode."), Category("ManagedListView")]
        public MLVMode Mode
        {
            get { return mlvPanel1.Mode; }
            set
            {
                if (mlvPanel1.Mode != value)
                {
                    mlvPanel1.Mode = value;
                    mlvPanel1.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set if the column height can be changed by user
        /// </summary>
        [Browsable(true)]
        [Description("Indicates if the columns height can be changed by user."), Category("ManagedListView")]
        public bool ColumnHeightCanBeChanged
        {
            get { return mlvPanel1.ColumnHeightCanBeChanged; }
            set
            {
                if (mlvPanel1.ColumnHeightCanBeChanged != value)
                {
                    mlvPanel1.ColumnHeightCanBeChanged = value;
                    mlvPanel1.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set if columns can be reordered by user
        /// </summary>
        [Browsable(true)]
        [Description("Indicates if the columns can be reordered by user."), Category("ManagedListView")]
        public bool ColumnsCanBeReordered
        {
            get { return mlvPanel1.ColumnsCanBeReordered; }
            set
            {
                if (mlvPanel1.ColumnsCanBeReordered != value)
                {
                    mlvPanel1.ColumnsCanBeReordered = value;
                    mlvPanel1.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set if the columns can be resized by the user.
        /// </summary>
        [Browsable(true)]
        [Description("Indicates if a column can be resized by user."), Category("ManagedListView")]
        public bool ColumnsCanBeResized
        {
            get { return mlvPanel1.ColumnsCanBeResized; }
            set
            {
                if (mlvPanel1.ColumnsCanBeResized != value)
                {
                    mlvPanel1.ColumnsCanBeResized = value;
                    mlvPanel1.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the image list to use for items.
        /// </summary>
        [Browsable(true)]
        [Description("The images list to use for items."), Category("ManagedListView")]
        public ImageList ItemsImageList
        {
            get { return mlvPanel1.ItemsImageList; }
            set
            {
                if (mlvPanel1.ItemsImageList != value)
                {
                    mlvPanel1.ItemsImageList = value;
                    mlvPanel1.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the image list to use for sub items.
        /// </summary>
        [Browsable(true)]
        [Description("The images list to use for sub items."), Category("ManagedListView")]
        public ImageList SubItemsImageList
        {
            get { return mlvPanel1.SubItemsImageList; }
            set
            {
                if (mlvPanel1.SubItemsImageList != value)
                {
                    mlvPanel1.SubItemsImageList = value;
                    mlvPanel1.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set if the split lines of items should be drawn.
        /// </summary>
        [Browsable(true)]
        [Description("Indicates if the split lines of items should be drawn"), Category("ManagedListView")]
        public bool DrawItemSplitLines
        {
            get { return mlvPanel1.ItemsSplitLines; }
            set
            {
                if (mlvPanel1.ItemsSplitLines != value)
                {
                    mlvPanel1.ItemsSplitLines = value;
                    mlvPanel1.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set if the render mode of background image rendering.
        /// </summary>
        [Browsable(true)]
        [Description("The render mode for background."), Category("ManagedListView")]
        public MLVBackgroundRenderMode BackgroundRenderMode
        {
            get { return mlvPanel1.BackgroundMode; }
            set
            {
                if (mlvPanel1.BackgroundMode != value)
                {
                    mlvPanel1.BackgroundMode = value;
                    mlvPanel1.CalculateBackgroundBounds();
                    mlvPanel1.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the background image. Set null to disable background image rendering.
        /// </summary>
        [Browsable(true)]
        [Description("The background image. Set null to disable background image rendering."), Category("ManagedListView")]
        public override Image BackgroundImage
        {
            get { return mlvPanel1.BackgroundImage; }
            set
            {
                if (mlvPanel1.BackgroundImage != value)
                {
                    mlvPanel1.BackgroundImage = value;
                    mlvPanel1.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the thumbnail zooming value (thumbnails mode only). This value will be set to the thumbnail block width and height.
        /// </summary>
        [Browsable(true)]
        [Description("The thumbnail zooming value (thumbnails mode only). This value will be set to the thumbnail block width and height."), Category("ManagedListView")]
        public int ThumbnailsZoom
        {
            get { return mlvPanel1.ThumbnailsZoom; }
            set
            {
                if (mlvPanel1.ThumbnailsZoom != value)
                {
                    mlvPanel1.ThumbnailsZoom = value;
                    mlvPanel1.Invalidate();
                }
            }
        }
        /// <summary>
        /// If true, the item image will be stretched using ratio stretch to fit thumbnails size. Thumbnails mode only.
        /// </summary>
        [Description("Indicate if the item image will be stretched using ratio stretch to fit thumbnails size. Thumbnails mode only."), Category("ManagedListView")]
        public bool StretchThumbnailsToFit
        {
            get { return mlvPanel1.ThumbnailsKeepImageSize; }
            set
            {
                mlvPanel1.ThumbnailsKeepImageSize = value;
                mlvPanel1.StartFillImagesBuffer();
                mlvPanel1.Invalidate();
            }
        }
        /// <summary>
        /// Get or set if the control should show tooltip on highlighted item when the text of that item is not fully visible.
        /// </summary>
        [Description("Indicate if the control should show tooltip on highlighted item when the text of that item is not fully visible."), Category("ManagedListView")]
        public bool ShowItemTooltips
        {
            get { return mlvPanel1.ShowItemTooltips; }
            set
            {
                if (mlvPanel1.ShowItemTooltips != value)
                {
                    mlvPanel1.ShowItemTooltips = value;
                    mlvPanel1.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set if the control should show info for highlighted item in the Thumbnails mode.
        /// </summary>
        [Description("Indicate if the control should show info for highlighted item in the Thumbnails mode."), Category("ManagedListView")]
        public bool ShowItemInfoOnThumbnailMode
        {
            get { return mlvPanel1.ShowItemInfoOnThumbnailMode; }
            set
            {
                if (mlvPanel1.ShowItemInfoOnThumbnailMode != value)
                {
                    mlvPanel1.ShowItemInfoOnThumbnailMode = value;
                    mlvPanel1.Invalidate();
                }
            }
        }

        /*EVENTS*/
        /// <summary>
        /// Raised when item(s) get draged.
        /// </summary>    
        [Description("Raised when item(s) get draged."), Category("ManagedListView")]
        public event EventHandler ItemDrag;
        /// <summary>
        /// Raised when the rating of a subitem (rating subitem) is changed.
        /// </summary>
        [Description("Raised when the rating of a subitem (rating subitem) is changed."), Category("ManagedListView")]
        public event EventHandler<RatingChangedEventArgs> RatingChangedOfSubItem;
        /// <summary>
        /// Raised when the tooltip is about to be hidden.
        /// </summary>
        [Description("Raised when the item(s) tooltip is about to be hidden (ShowItemTooltips must be set)."), Category("ManagedListView")]
        public event EventHandler HideTooltip;
        /// <summary>
        /// Raised when the tooltip is about to be shown. EventArgs allows to change the settings of the tooltip beside the option to cancel that tooltip.
        /// </summary>
        [Description("Raised when the item(s) tooltip is about to be shown (ShowItemTooltips must be set). EventArgs allows to change the settings of the tooltip beside the option to cancel that tooltip."), Category("ManagedListView")]
        public event EventHandler<ShowTooltipEventArgs> ShowTooltip;
        /// <summary>
        /// Raised when the thumbnail info is about to be hidden.
        /// </summary>
        [Description("Raised when the thumbnail info is about to be hidden (ShowItemInfoOnThumbnailMode must be set)."), Category("ManagedListView")]
        public event EventHandler HideThumbnailInfo;
        /// <summary>
        /// Raised when the thumbnail info is about to be shown. EventArgs allows to change the settings of the info beside the option to cancel that info.
        /// </summary>
        [Description("Raised when the thumbnail info is about to be shown (ShowItemInfoOnThumbnailMode must be set). EventArgs allows to change the settings of the info beside the option to cancel that info."), Category("ManagedListView")]
        public event EventHandler<ShowThumbnailInfoEventArgs> ShowThumbnailInfo;
        /// <summary>
        /// Raised when the control need to draw an item and that item draw mode is UserDrawMode.
        /// </summary>
        [Description("Raised when the control need to draw an item and that item draw mode is UserDrawMode."), Category("ManagedListView")]
        public event EventHandler<MLVDrawItemEventArgs> DrawItem;
        /// <summary>
        /// Raised when the control need to draw a sub item and that sub item draw mode is UserDrawMode.
        /// </summary>
        [Description("Raised when the control need to draw a sub item and that sub item draw mode is UserDrawMode."), Category("ManagedListView")]
        public event EventHandler<MLVDrawSubItemEventArgs> DrawSubItem;

        private void mlvPanel1_RefreshScrollX(object sender, EventArgs e)
        {
            if (mlvPanel1.ScrollXMax <= 0)
                panel_h_scroll.Visible = false;
            else
            {
                panel_h_scroll.Visible = true;
                hScrollBar1.Maximum = mlvPanel1.ScrollXMax;
                if (mlvPanel1.ScrollX < hScrollBar1.Maximum)
                    hScrollBar1.Value = mlvPanel1.ScrollX;
            }
        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (!surpressScrolling)
                mlvPanel1.SetScrollX(hScrollBar1.Value);
        }
        private void mlvPanel1_RefreshScrollY(object sender, EventArgs e)
        {
            if (mlvPanel1.ScrollYMax <= 0)
                vScrollBar1.Visible = false;
            else
            {
                vScrollBar1.Visible = true;
                vScrollBar1.Maximum = mlvPanel1.ScrollYMax;
                if (mlvPanel1.ScrollY < vScrollBar1.Maximum)
                    vScrollBar1.Value = mlvPanel1.ScrollY;
            }
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (!surpressScrolling)
                mlvPanel1.SetScrollY(vScrollBar1.Value);
        }
        private void mlvPanel1_ItemsDrag(object sender, EventArgs e)
        {

        }
        private void mlvPanel1_UpdateScrollBars(object sender, EventArgs e)
        {
            surpressScrolling = true;
            if (mlvPanel1.ScrollX < hScrollBar1.Maximum)
                hScrollBar1.Value = mlvPanel1.ScrollX;
            if (mlvPanel1.ScrollY < vScrollBar1.Maximum)
                vScrollBar1.Value = mlvPanel1.ScrollY;
            surpressScrolling = false;
        }
        private void mlvPanel1_Enter(object sender, EventArgs e)
        {
            mlvPanel1.Select();
            ParentForm.ActiveControl = mlvPanel1;
        }
        private void ManagedListView_KeyDown(object sender, KeyEventArgs e)
        {
            mlvPanel1.OnKeyDownRaised(e);
        }
        private void mlvPanel1_ItemsDrag_1(object sender, EventArgs e)
        {
            ItemDrag?.Invoke(this, new EventArgs());
        }
        private void mlvPanel1_RatingChangedOfSubItem(object sender, RatingChangedEventArgs e)
        {
            RatingChangedOfSubItem?.Invoke(this, e);
        }
        private void mlvPanel1_ShowTooltip(object sender, ShowTooltipEventArgs e)
        {
            ShowTooltipEventArgs args = new ShowTooltipEventArgs(e.TextToShow, e.Point);
            ShowTooltip?.Invoke(this, args);
            if (!args.Cancel)
            {
                toolTip1.SetToolTip(this, args.TextToShow);
                toolTip1.Show(args.TextToShow, this, args.Point);
            }
        }
        private void mlvPanel1_HideTooltip(object sender, EventArgs e)
        {
            HideTooltip?.Invoke(this, e);
            toolTip1.Hide(this);
        }
        private void mlvPanel1_ShowThumbnailInfo(object sender, ShowThumbnailInfoEventArgs e)
        {
            ShowThumbnailInfo?.Invoke(this, e);
        }
        private void mlvPanel1_HideThumbnailInfo(object sender, EventArgs e)
        {
            HideThumbnailInfo?.Invoke(this, e);
        }
        private void mlvPanel1_DrawItem(object sender, MLVDrawItemEventArgs e)
        {
            DrawItem?.Invoke(this, e);
        }
        private void mlvPanel1_DrawSubItem(object sender, MLVDrawSubItemEventArgs e)
        {
            DrawSubItem?.Invoke(this, e);
        }
    }
}
