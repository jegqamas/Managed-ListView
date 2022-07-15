using System;
using System.Windows.Forms;
using System.Drawing;
using MLV;

namespace MLVDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox_bkg_mode.SelectedIndex = 0;
            comboBox_mode.SelectedIndex = 0;

            images = System.IO.Directory.GetFiles(img_path);
        }
        int cl_index = 1;
        int it_index = 1;
        int it_image_index = 0;
        int it_sub_image_index = 0;
        int it_child_image_index = 0;
        int it_rating = 0;
        int color_r;
        int color_g;
        int color_b;
        string img_path = @"E:\Pictures\Art";
        string[] images;
        Image[] images_to_draw;

        private Color GenerateColor()
        {
            color_r = (color_r + 1) % 256;
            color_g = (color_g + 2) % 256;
            color_b = (color_b + 4) % 256;
            return Color.FromArgb(255, color_r, color_g, color_b);
        }
        // Add column
        private void button1_Click(object sender, EventArgs e)
        {
            MLVColumn cl = new MLVColumn("column_" + cl_index, "column_" + cl_index, 75);
            cl.Text = "Column " + cl_index;
            managedListView1.Columns.Add(cl);
            cl_index++;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                MLVItem item = new MLVItem("Item" + it_index);
                item.DrawMode = MLVItemDrawMode.TextImage;
                item.UseCustomTextColor = checkBox_use_custom_text_colors.Checked;
                item.CustomTextColor = GenerateColor();
                // Add the sub items
                if (!checkBox_includeRatingSubitem.Checked)
                {
                    for (int j = 0; j < managedListView1.Columns.Count; j++)
                    {
                        MLVSubItem sub = new MLVSubItem(managedListView1.Columns[j].ID, "SubItem" + managedListView1.Columns[j].ID);
                        sub.DrawMode = MLVItemDrawMode.TextImage;
                        sub.UseCustomTextColor = checkBox_use_custom_text_colors.Checked;
                        sub.CustomTextColor = GenerateColor();

                        sub.Text = "Item[" + it_index + "]Sub[" + managedListView1.Columns[j].ID + "]";

                        if (checkBox1.Checked)
                        {
                            sub.ImageIndex = it_sub_image_index;
                            it_sub_image_index = (it_sub_image_index + 1) % imageList_subitems.Images.Count;
                        }

                        item.SubItems.Add(sub);
                    }
                }
                else
                {
                    for (int j = 0; j < managedListView1.Columns.Count - 1; j++)
                    {
                        MLVSubItem sub = new MLVSubItem(managedListView1.Columns[j].ID, "SubItem" + managedListView1.Columns[j].ID);
                        sub.DrawMode = MLVItemDrawMode.TextImage;
                        sub.UseCustomTextColor = checkBox_use_custom_text_colors.Checked;
                        sub.CustomTextColor = GenerateColor();
                        sub.Text = "Item[" + it_index + "]Sub[" + managedListView1.Columns[j].ID + "]";

                        if (checkBox1.Checked)
                        {
                            sub.ImageIndex = it_sub_image_index;
                            it_sub_image_index = (it_sub_image_index + 1) % imageList_subitems.Images.Count;
                        }

                        item.SubItems.Add(sub);
                    }
                    MLVRatingSubItem subrating = new MLVRatingSubItem(managedListView1.Columns[managedListView1.Columns.Count - 1].ID);
                    subrating.Rating = it_rating;
                    it_rating = (it_rating + 1) % 6;
                    item.SubItems.Add(subrating);
                }
                // Add children
                if (checkBox_addChildren.Checked)
                {
                    item.ChildItemsCollabsed = true;
                    for (int c = 0; c < numericUpDown_child_items.Value; c++)
                    {
                        MLVChildItem child = new MLVChildItem("ChildItem" + (c + 1));
                        child.DrawMode = MLVItemDrawMode.TextImage;
                        child.UseCustomTextColor = checkBox_use_custom_text_colors.Checked;
                        child.CustomTextColor = GenerateColor();
                        if (!checkBox_includeRatingSubitem.Checked)
                        {
                            for (int j = 0; j < managedListView1.Columns.Count; j++)
                            {
                                MLVSubItem sub = new MLVSubItem(managedListView1.Columns[j].ID, "SubItem" + managedListView1.Columns[j].ID);
                                sub.DrawMode = MLVItemDrawMode.TextImage;

                                sub.Text = "ChildItem[" + (c + 1) + "]Sub[" + managedListView1.Columns[j].ID + "]";
                                sub.UseCustomTextColor = checkBox_use_custom_text_colors.Checked;
                                sub.CustomTextColor = GenerateColor();
                                if (checkBox1.Checked)
                                {
                                    sub.ImageIndex = it_sub_image_index;
                                    it_sub_image_index = (it_sub_image_index + 1) % imageList_subitems.Images.Count;
                                }

                                child.SubItems.Add(sub);
                            }
                        }
                        else
                        {
                            for (int j = 0; j < managedListView1.Columns.Count - 1; j++)
                            {
                                MLVSubItem sub = new MLVSubItem(managedListView1.Columns[j].ID, "SubItem" + managedListView1.Columns[j].ID);
                                sub.DrawMode = MLVItemDrawMode.TextImage;
                                sub.UseCustomTextColor = checkBox_use_custom_text_colors.Checked;
                                sub.CustomTextColor = GenerateColor();
                                sub.Text = "ChildItem[" + (c + 1) + "]Sub[" + managedListView1.Columns[j].ID + "]";

                                if (checkBox1.Checked)
                                {
                                    sub.ImageIndex = it_sub_image_index;
                                    it_sub_image_index = (it_sub_image_index + 1) % imageList_subitems.Images.Count;
                                }

                                child.SubItems.Add(sub);
                            }
                            MLVRatingSubItem subrating = new MLVRatingSubItem(managedListView1.Columns[managedListView1.Columns.Count - 1].ID);
                            subrating.Rating = it_rating;
                            it_rating = (it_rating + 1) % 6;
                            child.SubItems.Add(subrating);
                        }
                        if (checkBox1.Checked)
                        {
                            child.ImageIndex = it_child_image_index;
                            it_child_image_index = (it_child_image_index + 1) % imageList_items.Images.Count;
                        }

                        item.ChildItems.Add(child);
                    }
                }
                if (checkBox1.Checked)
                {
                    item.ImageIndex = it_image_index;
                    it_image_index = (it_image_index + 1) % imageList_items.Images.Count;
                }
                managedListView1.Items.Add(item);
                it_index++;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            managedListView1.DrawItemSplitLines = checkBox2.Checked;
        }
        private void managedListView1_ItemDrag(object sender, EventArgs e)
        {
            DoDragDrop(new string[0], DragDropEffects.All);
        }
        private void comboBox_bkg_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_bkg_mode.SelectedIndex)
            {
                case 0: managedListView1.BackgroundRenderMode = MLVBackgroundRenderMode.NormalStretchNoAspectRatio; break;
                case 1: managedListView1.BackgroundRenderMode = MLVBackgroundRenderMode.StretchWithAspectRatioIfLarger; break;
                case 2: managedListView1.BackgroundRenderMode = MLVBackgroundRenderMode.StretchWithAspectRatioToFit; break;
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Open image";
            if (file.ShowDialog(this) == DialogResult.OK)
            {
                managedListView1.BackgroundImage = System.Drawing.Image.FromFile(file.FileName);
            }
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            managedListView1.BackgroundImage = null;
        }
        private void comboBox_mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_mode.SelectedIndex)
            {
                case 0: managedListView1.Mode = MLVMode.Details; break;
                case 1: managedListView1.Mode = MLVMode.Thumbnails; break;
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            managedListView1.ThumbnailsZoom = trackBar1.Value;
        }
        private void checkBox_StretchThumbnailsToFit_CheckedChanged(object sender, EventArgs e)
        {
            managedListView1.StretchThumbnailsToFit = checkBox_StretchThumbnailsToFit.Checked;
        }
        private void managedListView1_ShowTooltip(object sender, ShowTooltipEventArgs e)
        {
            e.TextToShow += "\nThis is a test !\nYes, you can modify the text of the tooltip :)";
        }
        private void checkBox_showThumbIfo_CheckedChanged(object sender, EventArgs e)
        {
            managedListView1.ShowItemInfoOnThumbnailMode = checkBox_showThumbIfo.Checked;
        }
        private void managedListView1_ShowThumbnailInfo(object sender, ShowThumbnailInfoEventArgs e)
        {
            e.Rating = it_rating;
            it_rating = (it_rating + 1) % 6;
        }
        private void checkBox_use_custom_text_colors_CheckedChanged(object sender, EventArgs e)
        {
            foreach (MLVItem it in managedListView1.Items)
            {
                it.UseCustomTextColor = checkBox_use_custom_text_colors.Checked;
                foreach (MLVSubItem sub in it.SubItems)
                    sub.UseCustomTextColor = checkBox_use_custom_text_colors.Checked;
                foreach (MLVChildItem ch in it.ChildItems)
                {
                    ch.UseCustomTextColor = checkBox_use_custom_text_colors.Checked;
                    foreach (MLVSubItem csub in ch.SubItems)
                        csub.UseCustomTextColor = checkBox_use_custom_text_colors.Checked;
                }
            }
        }
        private void managedListView1_DrawItem(object sender, MLVDrawItemEventArgs e)
        {
            e.ImageToDraw = images_to_draw[e.Index % images_to_draw.Length];
        }
        private void managedListView1_DrawSubItem(object sender, MLVDrawSubItemEventArgs e)
        {
            e.ImageToDraw = images_to_draw[e.Index % images_to_draw.Length];
        }
        private void checkBox_use_user_draw_mode_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_use_user_draw_mode.Checked)
            {
                FolderBrowserDialog op = new FolderBrowserDialog();
                op.Description = "Open the images folder for thumnails";
                op.SelectedPath = img_path;
                if (op.ShowDialog() == DialogResult.OK)
                {
                    img_path = op.SelectedPath;
                    images = System.IO.Directory.GetFiles(img_path);
                    images_to_draw = new Image[images.Length];
                    for (int i = 0; i < images.Length; i++)
                    {
                        images_to_draw[i] = Image.FromFile(images[i]);
                    }
                }
            }
            foreach (MLVItem it in managedListView1.Items)
            {
                it.DrawMode = checkBox_use_user_draw_mode.Checked ? MLVItemDrawMode.User : MLVItemDrawMode.TextImage;
                foreach (MLVSubItem sub in it.SubItems)
                    sub.DrawMode = checkBox_use_user_draw_mode.Checked ? MLVItemDrawMode.User : MLVItemDrawMode.TextImage;
                foreach (MLVChildItem ch in it.ChildItems)
                {
                    ch.DrawMode = checkBox_use_user_draw_mode.Checked ? MLVItemDrawMode.User : MLVItemDrawMode.TextImage;
                    foreach (MLVSubItem csub in ch.SubItems)
                        csub.DrawMode = checkBox_use_user_draw_mode.Checked ? MLVItemDrawMode.User : MLVItemDrawMode.TextImage;
                }
            }
        }
    }
}
