/* This file is part of ALV "Advanced ListView" project.
   A custom control which provide advanced list view.

   Copyright © Ala Ibrahim Hadid 2013

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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MLV;

namespace ManagedListViewDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Initialize demo 2 items.
            RefreshDemo2();
        }

        #region Demo 1 (test columns and item add in details view)
        private bool IsColumnExist(string headerText)
        {
            foreach (ManagedListViewColumn cl in managedListView_demo1.Columns)
            {
                if (cl.HeaderText == headerText)
                {
                    return true;
                }
            }
            return false;
        }
        // add column
        private void button1_Click(object sender, EventArgs e)
        {
            ManagedListViewColumn column = new ManagedListViewColumn();
            string name = textBox_columnName.Text;
            // let's see if this column exists
            if (IsColumnExist(name))
            {
                int i = 0;
                name = textBox_columnName.Text + i;
                while (IsColumnExist(name))
                {
                    i++;
                    name = textBox_columnName.Text + i;
                }
            }
            // add the column
            column.HeaderText = name;// the name that will apears in the control
            column.ID = name.ToLower();// you can set the id as you like, we set here the easiest thing to remember.
            column.SortMode = ManagedListViewSortMode.None;
            managedListView_demo1.Columns.Add(column);

            managedListView_demo1.Invalidate();
        }
        // add item
        private void button2_Click(object sender, EventArgs e)
        {
            if (managedListView_demo1.Columns.Count == 0)
            {
                MessageBox.Show("Please add column(s) first. In details view mode, adding items without adding columns will show nothing and the items will be ignored.");
                return;
            }
            ManagedListViewItem item = new ManagedListViewItem();
            // In details view mode, the item text will not get shown, the subitems do instead
            // so here we need to setup subitems.
            // 1 Loop through columns to see what we need to add
            foreach (ManagedListViewColumn column in managedListView_demo1.Columns)
            {
                // 2 Create the subitem and give it the column id. This is how the mlv control works, the subitems
                // must has the column id that should be listed for.
                ManagedListViewSubItem subitem = new ManagedListViewSubItem();
                subitem.ColumnID = column.ID;// by this, the subitem will be shown and listed under the 'column'
                subitem.DrawMode = ManagedListViewItemDrawMode.Text;// this demo is only for testing items and columns so let's keep it that way
                subitem.Text = textBox_addItem.Text + ", id=" + column.ID;
                // 3 Add this subitem to the item
                item.SubItems.Add(subitem);
            }
            // 4 Now the item is ready to be added
            managedListView_demo1.Items.Add(item);
            managedListView_demo1.Invalidate();
        }
        // clear items
        private void button3_Click(object sender, EventArgs e)
        {
            managedListView_demo1.Items.Clear();
            managedListView_demo1.Invalidate();
        }
        // clear all
        private void button4_Click(object sender, EventArgs e)
        {
            managedListView_demo1.Columns.Clear();
            managedListView_demo1.Items.Clear();
            managedListView_demo1.Invalidate();
        }
        #endregion

        #region Demo 2 (test advanced functions for details view)
        private void RefreshDemo2()
        {
            // Clear all
            managedListView_demo2.Columns.Clear();
            managedListView_demo2.Items.Clear();
            // Add columns
            ManagedListViewColumn column = new ManagedListViewColumn();
            column.HeaderText = "Text with image";
            column.ID = "text with image";
            column.Width = 120;
            managedListView_demo2.Columns.Add(column);

            column = new ManagedListViewColumn();
            column.HeaderText = "Text only with custom fonts";
            column.ID = "text only";
            column.Width = 120;
            managedListView_demo2.Columns.Add(column);

            column = new ManagedListViewColumn();
            column.HeaderText = "Image only";
            column.ID = "image only";
            column.Width = 120;
            managedListView_demo2.Columns.Add(column);

            column = new ManagedListViewColumn();
            column.HeaderText = "Rating";
            column.ID = "rating";
            column.Width = 120;
            managedListView_demo2.Columns.Add(column);

            column = new ManagedListViewColumn();
            column.HeaderText = "User draw";
            column.ID = "user draw";
            column.Width = 120;
            managedListView_demo2.Columns.Add(column);
            // Add items, let's add 10 items for test.
            for (int i = 0; i < 10; i++)
            {
                ManagedListViewItem item = new ManagedListViewItem();
                // In details view mode, the item text will not get shown, the subitems do instead
                // so here we need to setup subitems.

                // 1 The first subitem is for 'text with image' testing. We need to specify both text and image.
                // the text can be set easily, the image must be set via index, index within ImagesList that set
                // in ImagesList property of the MLV control.
                ManagedListViewSubItem subitem = new ManagedListViewSubItem();
                subitem.ColumnID = "text with image";// by this, the subitem will be shown and listed under the 'text with image' column
                subitem.Text = "Item # " + (i + 1).ToString();
                subitem.ImageIndex = i;// this value must be index within ImagesList that set in ImagesList property of the MLV control.
                // in this demo, 10 images already added
                subitem.DrawMode = ManagedListViewItemDrawMode.TextAndImage;// draw both image and text.
                item.SubItems.Add(subitem);

                // 2 This subitem is for 'text only' testing. We need to specify only text.
                subitem = new ManagedListViewSubItem();
                subitem.ColumnID = "text only";// by this, the subitem will be shown and listed under the 'text only' column
                subitem.Text = "Item # " + (i + 1).ToString();
                subitem.DrawMode = ManagedListViewItemDrawMode.Text;// draw text only. Even an image index set to this subitem it will be ignored.
                subitem.CustomFontEnabled = true;// we want to do some changes here, let's draw custom font !
                subitem.CustomFont = new System.Drawing.Font("Times New Roman", 9, FontStyle.Bold);
                subitem.Color = Color.FromArgb(i * 10, i * 25, i * 20);// draw custom color. This doesn't need the "CustomFontEnabled" to be set.
                item.SubItems.Add(subitem);

                // 3 This subitem is for 'image only' testing. We need to specify the image we need to draw.
                // The image must be set via index, index within ImagesList that set
                // in ImagesList property of the MLV control.
                subitem = new ManagedListViewSubItem();
                subitem.ColumnID = "image only";// by this, the subitem will be shown and listed under the 'text with image' column
                //subitem.Text = "Item # " + (i + 1).ToString(); // no need to set text here ..
                subitem.ImageIndex = i;// this value must be index within ImagesList that set in ImagesList property of the MLV control.
                // in this demo, 10 images already added
                subitem.DrawMode = ManagedListViewItemDrawMode.Image;// draw image only.
                item.SubItems.Add(subitem);

                // 4 This subitem is for 'rating' testing. We want to draw a subitem that represent rating (five stars)
                // just like we see in media programs for rating songs.
                // To do so, we need to use this special subitem. The MLV control treat this subitem as special case,
                // all properties of this subitem ignored except the rating value.
                ManagedListViewRatingSubItem ratingSubitem = new ManagedListViewRatingSubItem();
                ratingSubitem.ColumnID = "rating";// as always, this is nesseccary.
                ratingSubitem.RatingChanged += ratingSubitem_RatingChanged;// this Raised when you change rating value via mouse.
                ratingSubitem.UpdateRatingRequest += ratingSubitem_UpdateRatingRequest;// this Raised when the control needs to update ratings. 
                item.SubItems.Add(ratingSubitem);

                // 5 This subitem is for 'user draw' testing. We need to draw text and images manualy.
                subitem = new ManagedListViewSubItem();
                subitem.ColumnID = "user draw";// by this, the subitem will be shown and listed under the 'user draw' column
                //subitem.Text = "Item # " + (i + 1).ToString(); // no need to set text here ..
                // subitem.ImageIndex = i;// no need to set anything here ethier..
                subitem.DrawMode = ManagedListViewItemDrawMode.UserDraw;// now we are using the custom draw function.
                // To handle draws, we need to use 'DrawSubItem' event of the MLV control.
                item.SubItems.Add(subitem);

                // 6 Now the item is ready to be added
                managedListView_demo2.Items.Add(item);
            }
            managedListView_demo2.Invalidate();
        }

        void ratingSubitem_UpdateRatingRequest(object sender, ManagedListViewRatingChangedArgs e)
        {

        }

        void ratingSubitem_RatingChanged(object sender, ManagedListViewRatingChangedArgs e)
        {
            MessageBox.Show("You changed the rating to " + e.Rating + " for the item #" + (e.ItemIndex + 1).ToString());
        }

        private void managedListView_demo2_DrawSubItem(object sender, ManagedListViewSubItemDrawArgs e)
        {
            // we recieve the information via the arguments. Just tell the arguments what you want to draw !!
            if (e.ColumnID == "user draw")// just in case, make this check if you have more subitems draw as same as this but for more columns
            {
                e.TextToDraw = "Item # " + (e.ItemIndex + 1).ToString() + " user draw.";
                e.ImageToDraw = imageList1.Images[e.ItemIndex];
                // just like that ! all calculation will be done automaticly
                // debending on font size. Font size will determine text and image sizes.
                // It uses the Font property of MLV for sure. 
            }
        }
        // refresh
        private void button8_Click(object sender, EventArgs e)
        {
            RefreshDemo2();
        }
        // event for sort function.
        private void managedListView_demo2_ColumnClicked(object sender, ManagedListViewColumnClickArgs e)
        {
            // Please note that 'ChangeColumnSortModeWhenClick' in managedListView_demo2 control is set to false.
            // This value is set to false so disables the auto sort mode change when a column get clicked, we
            // set the sort mode manualy here. You can keep it active if you like and no need to do anything
            // here but sort.
            // Make some check
            if (e.ColumnID == "rating")
            {
                MessageBox.Show("You can sort rating but it's not supported here :)");
                return;
            }
            if (e.ColumnID == "user draw")
            {
                MessageBox.Show("The items of user draw will not sort in normal way, we should use additional code lines to determine the subitem's text that uses user draw. Since the subitem.Text value is not set so we can't do sort, see ItemsComparer.cs");
                return;
            }
            if (e.ColumnID == "image only")
            {
                MessageBox.Show("You can sort images but this requires additional codes in the used comparer, see ItemsComparer.cs");
                return;
            }
            // get the column
            ManagedListViewColumn column = managedListView_demo2.Columns.GetColumnByID(e.ColumnID);
            if (column == null) return;
            bool az = false;
            // now let's see what is the sort mode
            switch (column.SortMode)
            {
                case ManagedListViewSortMode.None:
                case ManagedListViewSortMode.ZtoA: az = true; break;
            }
            // disable sort for all columns
            foreach (ManagedListViewColumn cl in managedListView_demo2.Columns)
                cl.SortMode = ManagedListViewSortMode.None;
            // sort (we need to add a compare class for comparing in the project, see ItemsComparer.cs)
            // Since the items is List<> collection, we can sort using comparers directly.
            // Or you can use information given to sort external collection then to apply it here.
            managedListView_demo2.Items.Sort(new ItemsComparer(az, e.ColumnID));
            // Reverse sort mode.
            if (az)
                column.SortMode = ManagedListViewSortMode.AtoZ;
            else
                column.SortMode = ManagedListViewSortMode.ZtoA;

            managedListView_demo2.Invalidate();
        }
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            managedListView_demo3.Items.Clear();
            managedListView_demo3.Invalidate();
        }
        #region Demo 3 (test thumbnails view mode and drag and drop)
        private void managedListView_demo3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void managedListView_demo3_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void managedListView_demo3_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // get draged files
                List<string> files = new List<string>((string[])e.Data.GetData(DataFormats.FileDrop));
                List<string> addFiles = new List<string>();
                for (int i = 0; i < files.Count; i++)
                {
                    if (Directory.Exists(files[i]))
                    {
                        addFiles.AddRange(Directory.GetFiles(files[i], "*", SearchOption.AllDirectories));
                    }
                }
                files.AddRange(addFiles);
                // search for images
                foreach (string file in files)
                {
                    if (Path.GetExtension(file).ToLower() == ".jpg" || Path.GetExtension(file).ToLower() == ".png" ||
                        Path.GetExtension(file).ToLower() == ".bmp")
                    {
                        // add the item
                        ManagedListViewItem item = new ManagedListViewItem();
                        item.Tag = Image.FromFile(file);
                        item.DrawMode = ManagedListViewItemDrawMode.UserDraw;// this will allow us to draw manualy, use DrawItem event of MLV control.
                        item.Text = file;
                        managedListView_demo3.Items.Add(item);
                        // We saved the image data in each item Tag property to make things faster ...
                        // This may cause memory issues so limit the items count to 20
                        if (managedListView_demo3.Items.Count > 20)
                            managedListView_demo3.Items.Remove(managedListView_demo3.Items[0]);
                    }
                }
            }
        }
        private void managedListView_demo3_DrawItem(object sender, ManagedListViewItemDrawArgs e)
        {
            // This work only with thumbnails view.
            e.TextToDraw = managedListView_demo3.Items[e.ItemIndex].Text;
            e.ImageToDraw = (Image)managedListView_demo3.Items[e.ItemIndex].Tag;
            // just like that !!
        }
        private void managedListView_demo3_ItemsDrag(object sender, EventArgs e)
        {
            if (managedListView_demo3.SelectedItems.Count == 0)
                return;
            //get items
            List<string> dragedItems = new List<string>();
            foreach (ManagedListViewItem item in managedListView_demo3.SelectedItems)
            {
                dragedItems.Add(item.Text);
            }
            DoDragDrop(new DataObject(DataFormats.FileDrop, dragedItems.ToArray()), DragDropEffects.Copy);
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            managedListView_demo3.ThunmbnailsHeight = managedListView_demo3.ThunmbnailsWidth = trackBar1.Value;
            managedListView_demo3.Invalidate();
            label_zoomValue.Text = trackBar1.Value + " x " + trackBar1.Value;
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:ahdsoftwares@hotmail.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.famfamfam.com/lab/icons/silk/"); 
        }
    }
}
