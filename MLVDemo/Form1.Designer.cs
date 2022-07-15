namespace MLVDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_use_custom_text_colors = new System.Windows.Forms.CheckBox();
            this.checkBox_showThumbIfo = new System.Windows.Forms.CheckBox();
            this.checkBox_StretchThumbnailsToFit = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_mode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_includeRatingSubitem = new System.Windows.Forms.CheckBox();
            this.comboBox_bkg_mode = new System.Windows.Forms.ComboBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_child_items = new System.Windows.Forms.NumericUpDown();
            this.checkBox_addChildren = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.managedListView1 = new MLV.ManagedListView();
            this.imageList_items = new System.Windows.Forms.ImageList(this.components);
            this.imageList_subitems = new System.Windows.Forms.ImageList(this.components);
            this.checkBox_use_user_draw_mode = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_child_items)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add column";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox_use_user_draw_mode);
            this.panel1.Controls.Add(this.checkBox_use_custom_text_colors);
            this.panel1.Controls.Add(this.checkBox_showThumbIfo);
            this.panel1.Controls.Add(this.checkBox_StretchThumbnailsToFit);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.comboBox_mode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.checkBox_includeRatingSubitem);
            this.panel1.Controls.Add(this.comboBox_bkg_mode);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numericUpDown_child_items);
            this.panel1.Controls.Add(this.checkBox_addChildren);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 138);
            this.panel1.TabIndex = 1;
            // 
            // checkBox_use_custom_text_colors
            // 
            this.checkBox_use_custom_text_colors.AutoSize = true;
            this.checkBox_use_custom_text_colors.Location = new System.Drawing.Point(510, 16);
            this.checkBox_use_custom_text_colors.Name = "checkBox_use_custom_text_colors";
            this.checkBox_use_custom_text_colors.Size = new System.Drawing.Size(135, 17);
            this.checkBox_use_custom_text_colors.TabIndex = 20;
            this.checkBox_use_custom_text_colors.Text = "Use custom text colors";
            this.checkBox_use_custom_text_colors.UseVisualStyleBackColor = true;
            this.checkBox_use_custom_text_colors.CheckedChanged += new System.EventHandler(this.checkBox_use_custom_text_colors_CheckedChanged);
            // 
            // checkBox_showThumbIfo
            // 
            this.checkBox_showThumbIfo.AutoSize = true;
            this.checkBox_showThumbIfo.Location = new System.Drawing.Point(279, 117);
            this.checkBox_showThumbIfo.Name = "checkBox_showThumbIfo";
            this.checkBox_showThumbIfo.Size = new System.Drawing.Size(127, 17);
            this.checkBox_showThumbIfo.TabIndex = 19;
            this.checkBox_showThumbIfo.Text = "Show thumbnails info";
            this.checkBox_showThumbIfo.UseVisualStyleBackColor = true;
            this.checkBox_showThumbIfo.CheckedChanged += new System.EventHandler(this.checkBox_showThumbIfo_CheckedChanged);
            // 
            // checkBox_StretchThumbnailsToFit
            // 
            this.checkBox_StretchThumbnailsToFit.AutoSize = true;
            this.checkBox_StretchThumbnailsToFit.Location = new System.Drawing.Point(126, 117);
            this.checkBox_StretchThumbnailsToFit.Name = "checkBox_StretchThumbnailsToFit";
            this.checkBox_StretchThumbnailsToFit.Size = new System.Drawing.Size(147, 17);
            this.checkBox_StretchThumbnailsToFit.TabIndex = 18;
            this.checkBox_StretchThumbnailsToFit.Text = "Stretch Thumbnails To Fit";
            this.checkBox_StretchThumbnailsToFit.UseVisualStyleBackColor = true;
            this.checkBox_StretchThumbnailsToFit.CheckedChanged += new System.EventHandler(this.checkBox_StretchThumbnailsToFit_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(419, 90);
            this.trackBar1.Maximum = 300;
            this.trackBar1.Minimum = 36;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(174, 21);
            this.trackBar1.TabIndex = 17;
            this.trackBar1.Value = 36;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Thumbnails Zoom:";
            // 
            // comboBox_mode
            // 
            this.comboBox_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_mode.FormattingEnabled = true;
            this.comboBox_mode.Items.AddRange(new object[] {
            "Details",
            "Thumbnails"});
            this.comboBox_mode.Location = new System.Drawing.Point(126, 90);
            this.comboBox_mode.Name = "comboBox_mode";
            this.comboBox_mode.Size = new System.Drawing.Size(188, 21);
            this.comboBox_mode.TabIndex = 15;
            this.comboBox_mode.SelectedIndexChanged += new System.EventHandler(this.comboBox_mode_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(83, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Mode:";
            // 
            // checkBox_includeRatingSubitem
            // 
            this.checkBox_includeRatingSubitem.AutoSize = true;
            this.checkBox_includeRatingSubitem.Location = new System.Drawing.Point(126, 67);
            this.checkBox_includeRatingSubitem.Name = "checkBox_includeRatingSubitem";
            this.checkBox_includeRatingSubitem.Size = new System.Drawing.Size(132, 17);
            this.checkBox_includeRatingSubitem.TabIndex = 13;
            this.checkBox_includeRatingSubitem.Text = "Include rating subitem";
            this.checkBox_includeRatingSubitem.UseVisualStyleBackColor = true;
            // 
            // comboBox_bkg_mode
            // 
            this.comboBox_bkg_mode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_bkg_mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bkg_mode.FormattingEnabled = true;
            this.comboBox_bkg_mode.Items.AddRange(new object[] {
            "NormalStretchNoAspectRatio",
            "StretchWithAspectRatioIfLarger",
            "StretchWithAspectRatioToFit"});
            this.comboBox_bkg_mode.Location = new System.Drawing.Point(655, 65);
            this.comboBox_bkg_mode.Name = "comboBox_bkg_mode";
            this.comboBox_bkg_mode.Size = new System.Drawing.Size(124, 21);
            this.comboBox_bkg_mode.TabIndex = 12;
            this.comboBox_bkg_mode.SelectedIndexChanged += new System.EventHandler(this.comboBox_bkg_mode_SelectedIndexChanged);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(652, 49);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(91, 13);
            this.linkLabel2.TabIndex = 11;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Clear background";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(652, 36);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(82, 13);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Set background";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(655, 16);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(124, 17);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "Draw item split lines.";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Child item(s) as well.";
            // 
            // numericUpDown_child_items
            // 
            this.numericUpDown_child_items.Location = new System.Drawing.Point(194, 41);
            this.numericUpDown_child_items.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_child_items.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_child_items.Name = "numericUpDown_child_items";
            this.numericUpDown_child_items.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_child_items.TabIndex = 8;
            this.numericUpDown_child_items.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // checkBox_addChildren
            // 
            this.checkBox_addChildren.AutoSize = true;
            this.checkBox_addChildren.Location = new System.Drawing.Point(126, 42);
            this.checkBox_addChildren.Name = "checkBox_addChildren";
            this.checkBox_addChildren.Size = new System.Drawing.Size(45, 17);
            this.checkBox_addChildren.TabIndex = 7;
            this.checkBox_addChildren.Text = "Add";
            this.checkBox_addChildren.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(372, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Add images randomly.";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Item(s).";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(194, 15);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 2;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(126, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // managedListView1
            // 
            this.managedListView1.BackgroundRenderMode = MLV.MLVBackgroundRenderMode.NormalStretchNoAspectRatio;
            this.managedListView1.ColumnHeightCanBeChanged = true;
            this.managedListView1.ColumnsCanBeReordered = true;
            this.managedListView1.ColumnsCanBeResized = true;
            this.managedListView1.ColumnsFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managedListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managedListView1.DrawItemSplitLines = false;
            this.managedListView1.ItemsImageList = this.imageList_items;
            this.managedListView1.Location = new System.Drawing.Point(0, 138);
            this.managedListView1.Mode = MLV.MLVMode.Details;
            this.managedListView1.Name = "managedListView1";
            this.managedListView1.ShowItemInfoOnThumbnailMode = false;
            this.managedListView1.ShowItemTooltips = true;
            this.managedListView1.Size = new System.Drawing.Size(802, 537);
            this.managedListView1.StretchThumbnailsToFit = false;
            this.managedListView1.SubItemsImageList = this.imageList_subitems;
            this.managedListView1.TabIndex = 2;
            this.managedListView1.ThumbnailsZoom = 50;
            this.managedListView1.ItemDrag += new System.EventHandler(this.managedListView1_ItemDrag);
            this.managedListView1.ShowTooltip += new System.EventHandler<MLV.ShowTooltipEventArgs>(this.managedListView1_ShowTooltip);
            this.managedListView1.ShowThumbnailInfo += new System.EventHandler<MLV.ShowThumbnailInfoEventArgs>(this.managedListView1_ShowThumbnailInfo);
            this.managedListView1.DrawItem += new System.EventHandler<MLV.MLVDrawItemEventArgs>(this.managedListView1_DrawItem);
            this.managedListView1.DrawSubItem += new System.EventHandler<MLV.MLVDrawSubItemEventArgs>(this.managedListView1_DrawSubItem);
            // 
            // imageList_items
            // 
            this.imageList_items.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_items.ImageStream")));
            this.imageList_items.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_items.Images.SetKeyName(0, "drive_network.png");
            this.imageList_items.Images.SetKeyName(1, "drive_rename.png");
            this.imageList_items.Images.SetKeyName(2, "drive_user.png");
            this.imageList_items.Images.SetKeyName(3, "drive_web.png");
            this.imageList_items.Images.SetKeyName(4, "dvd.png");
            this.imageList_items.Images.SetKeyName(5, "dvd_add.png");
            this.imageList_items.Images.SetKeyName(6, "dvd_delete.png");
            this.imageList_items.Images.SetKeyName(7, "dvd_edit.png");
            this.imageList_items.Images.SetKeyName(8, "dvd_error.png");
            this.imageList_items.Images.SetKeyName(9, "dvd_go.png");
            this.imageList_items.Images.SetKeyName(10, "dvd_key.png");
            this.imageList_items.Images.SetKeyName(11, "dvd_link.png");
            this.imageList_items.Images.SetKeyName(12, "email.png");
            this.imageList_items.Images.SetKeyName(13, "email_add.png");
            this.imageList_items.Images.SetKeyName(14, "email_attach.png");
            this.imageList_items.Images.SetKeyName(15, "email_delete.png");
            this.imageList_items.Images.SetKeyName(16, "email_edit.png");
            this.imageList_items.Images.SetKeyName(17, "email_error.png");
            this.imageList_items.Images.SetKeyName(18, "email_go.png");
            this.imageList_items.Images.SetKeyName(19, "email_link.png");
            this.imageList_items.Images.SetKeyName(20, "email_open.png");
            this.imageList_items.Images.SetKeyName(21, "email_open_image.png");
            this.imageList_items.Images.SetKeyName(22, "emoticon_evilgrin.png");
            this.imageList_items.Images.SetKeyName(23, "emoticon_grin.png");
            this.imageList_items.Images.SetKeyName(24, "emoticon_happy.png");
            this.imageList_items.Images.SetKeyName(25, "emoticon_smile.png");
            this.imageList_items.Images.SetKeyName(26, "emoticon_surprised.png");
            this.imageList_items.Images.SetKeyName(27, "emoticon_tongue.png");
            this.imageList_items.Images.SetKeyName(28, "emoticon_unhappy.png");
            this.imageList_items.Images.SetKeyName(29, "emoticon_waii.png");
            this.imageList_items.Images.SetKeyName(30, "emoticon_wink.png");
            this.imageList_items.Images.SetKeyName(31, "error.png");
            this.imageList_items.Images.SetKeyName(32, "error_add.png");
            this.imageList_items.Images.SetKeyName(33, "error_delete.png");
            this.imageList_items.Images.SetKeyName(34, "error_go.png");
            this.imageList_items.Images.SetKeyName(35, "exclamation.png");
            this.imageList_items.Images.SetKeyName(36, "eye.png");
            this.imageList_items.Images.SetKeyName(37, "feed.png");
            this.imageList_items.Images.SetKeyName(38, "feed_add.png");
            this.imageList_items.Images.SetKeyName(39, "feed_delete.png");
            this.imageList_items.Images.SetKeyName(40, "feed_disk.png");
            this.imageList_items.Images.SetKeyName(41, "feed_edit.png");
            this.imageList_items.Images.SetKeyName(42, "feed_error.png");
            this.imageList_items.Images.SetKeyName(43, "feed_go.png");
            this.imageList_items.Images.SetKeyName(44, "feed_key.png");
            this.imageList_items.Images.SetKeyName(45, "feed_link.png");
            this.imageList_items.Images.SetKeyName(46, "feed_magnify.png");
            this.imageList_items.Images.SetKeyName(47, "female.png");
            this.imageList_items.Images.SetKeyName(48, "film.png");
            this.imageList_items.Images.SetKeyName(49, "film_add.png");
            this.imageList_items.Images.SetKeyName(50, "film_delete.png");
            this.imageList_items.Images.SetKeyName(51, "film_edit.png");
            this.imageList_items.Images.SetKeyName(52, "film_error.png");
            this.imageList_items.Images.SetKeyName(53, "film_go.png");
            this.imageList_items.Images.SetKeyName(54, "film_key.png");
            this.imageList_items.Images.SetKeyName(55, "film_link.png");
            this.imageList_items.Images.SetKeyName(56, "film_save.png");
            this.imageList_items.Images.SetKeyName(57, "find.png");
            this.imageList_items.Images.SetKeyName(58, "flag_blue.png");
            this.imageList_items.Images.SetKeyName(59, "flag_green.png");
            this.imageList_items.Images.SetKeyName(60, "flag_orange.png");
            this.imageList_items.Images.SetKeyName(61, "flag_pink.png");
            this.imageList_items.Images.SetKeyName(62, "flag_purple.png");
            this.imageList_items.Images.SetKeyName(63, "flag_red.png");
            this.imageList_items.Images.SetKeyName(64, "flag_yellow.png");
            this.imageList_items.Images.SetKeyName(65, "folder.png");
            this.imageList_items.Images.SetKeyName(66, "folder_add.png");
            this.imageList_items.Images.SetKeyName(67, "folder_bell.png");
            this.imageList_items.Images.SetKeyName(68, "folder_brick.png");
            this.imageList_items.Images.SetKeyName(69, "folder_bug.png");
            this.imageList_items.Images.SetKeyName(70, "folder_camera.png");
            this.imageList_items.Images.SetKeyName(71, "folder_database.png");
            this.imageList_items.Images.SetKeyName(72, "folder_delete.png");
            this.imageList_items.Images.SetKeyName(73, "folder_edit.png");
            this.imageList_items.Images.SetKeyName(74, "folder_error.png");
            this.imageList_items.Images.SetKeyName(75, "folder_explore.png");
            this.imageList_items.Images.SetKeyName(76, "folder_feed.png");
            this.imageList_items.Images.SetKeyName(77, "folder_find.png");
            this.imageList_items.Images.SetKeyName(78, "folder_go.png");
            this.imageList_items.Images.SetKeyName(79, "folder_heart.png");
            this.imageList_items.Images.SetKeyName(80, "folder_image.png");
            this.imageList_items.Images.SetKeyName(81, "folder_key.png");
            this.imageList_items.Images.SetKeyName(82, "folder_lightbulb.png");
            this.imageList_items.Images.SetKeyName(83, "folder_link.png");
            this.imageList_items.Images.SetKeyName(84, "folder_magnify.png");
            this.imageList_items.Images.SetKeyName(85, "folder_page.png");
            this.imageList_items.Images.SetKeyName(86, "folder_page_white.png");
            this.imageList_items.Images.SetKeyName(87, "folder_palette.png");
            this.imageList_items.Images.SetKeyName(88, "folder_picture.png");
            this.imageList_items.Images.SetKeyName(89, "folder_star.png");
            this.imageList_items.Images.SetKeyName(90, "folder_table.png");
            // 
            // imageList_subitems
            // 
            this.imageList_subitems.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_subitems.ImageStream")));
            this.imageList_subitems.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_subitems.Images.SetKeyName(0, "text_horizontalrule.png");
            this.imageList_subitems.Images.SetKeyName(1, "text_indent.png");
            this.imageList_subitems.Images.SetKeyName(2, "text_indent_remove.png");
            this.imageList_subitems.Images.SetKeyName(3, "text_italic.png");
            this.imageList_subitems.Images.SetKeyName(4, "text_kerning.png");
            this.imageList_subitems.Images.SetKeyName(5, "text_letter_omega.png");
            this.imageList_subitems.Images.SetKeyName(6, "text_letterspacing.png");
            this.imageList_subitems.Images.SetKeyName(7, "text_linespacing.png");
            this.imageList_subitems.Images.SetKeyName(8, "text_list_bullets.png");
            this.imageList_subitems.Images.SetKeyName(9, "text_list_numbers.png");
            this.imageList_subitems.Images.SetKeyName(10, "text_lowercase.png");
            this.imageList_subitems.Images.SetKeyName(11, "text_padding_bottom.png");
            this.imageList_subitems.Images.SetKeyName(12, "text_padding_left.png");
            this.imageList_subitems.Images.SetKeyName(13, "text_padding_right.png");
            this.imageList_subitems.Images.SetKeyName(14, "text_padding_top.png");
            this.imageList_subitems.Images.SetKeyName(15, "text_replace.png");
            this.imageList_subitems.Images.SetKeyName(16, "text_signature.png");
            this.imageList_subitems.Images.SetKeyName(17, "text_smallcaps.png");
            this.imageList_subitems.Images.SetKeyName(18, "text_strikethrough.png");
            this.imageList_subitems.Images.SetKeyName(19, "text_subscript.png");
            this.imageList_subitems.Images.SetKeyName(20, "text_superscript.png");
            this.imageList_subitems.Images.SetKeyName(21, "text_underline.png");
            this.imageList_subitems.Images.SetKeyName(22, "text_uppercase.png");
            this.imageList_subitems.Images.SetKeyName(23, "textfield.png");
            this.imageList_subitems.Images.SetKeyName(24, "textfield_add.png");
            this.imageList_subitems.Images.SetKeyName(25, "textfield_delete.png");
            this.imageList_subitems.Images.SetKeyName(26, "textfield_key.png");
            this.imageList_subitems.Images.SetKeyName(27, "textfield_rename.png");
            this.imageList_subitems.Images.SetKeyName(28, "thumb_down.png");
            this.imageList_subitems.Images.SetKeyName(29, "thumb_up.png");
            this.imageList_subitems.Images.SetKeyName(30, "tick.png");
            this.imageList_subitems.Images.SetKeyName(31, "time.png");
            this.imageList_subitems.Images.SetKeyName(32, "time_add.png");
            this.imageList_subitems.Images.SetKeyName(33, "time_delete.png");
            this.imageList_subitems.Images.SetKeyName(34, "time_go.png");
            this.imageList_subitems.Images.SetKeyName(35, "timeline_marker.png");
            this.imageList_subitems.Images.SetKeyName(36, "transmit.png");
            this.imageList_subitems.Images.SetKeyName(37, "transmit_add.png");
            this.imageList_subitems.Images.SetKeyName(38, "transmit_blue.png");
            this.imageList_subitems.Images.SetKeyName(39, "transmit_delete.png");
            this.imageList_subitems.Images.SetKeyName(40, "transmit_edit.png");
            this.imageList_subitems.Images.SetKeyName(41, "transmit_error.png");
            this.imageList_subitems.Images.SetKeyName(42, "transmit_go.png");
            this.imageList_subitems.Images.SetKeyName(43, "tux.png");
            this.imageList_subitems.Images.SetKeyName(44, "user.png");
            this.imageList_subitems.Images.SetKeyName(45, "user_add.png");
            this.imageList_subitems.Images.SetKeyName(46, "user_comment.png");
            this.imageList_subitems.Images.SetKeyName(47, "user_delete.png");
            this.imageList_subitems.Images.SetKeyName(48, "user_edit.png");
            this.imageList_subitems.Images.SetKeyName(49, "user_female.png");
            this.imageList_subitems.Images.SetKeyName(50, "user_go.png");
            this.imageList_subitems.Images.SetKeyName(51, "user_gray.png");
            this.imageList_subitems.Images.SetKeyName(52, "user_green.png");
            this.imageList_subitems.Images.SetKeyName(53, "user_orange.png");
            this.imageList_subitems.Images.SetKeyName(54, "user_red.png");
            this.imageList_subitems.Images.SetKeyName(55, "user_suit.png");
            this.imageList_subitems.Images.SetKeyName(56, "vcard.png");
            this.imageList_subitems.Images.SetKeyName(57, "vcard_add.png");
            this.imageList_subitems.Images.SetKeyName(58, "vcard_delete.png");
            this.imageList_subitems.Images.SetKeyName(59, "vcard_edit.png");
            this.imageList_subitems.Images.SetKeyName(60, "vector.png");
            this.imageList_subitems.Images.SetKeyName(61, "vector_add.png");
            this.imageList_subitems.Images.SetKeyName(62, "vector_delete.png");
            this.imageList_subitems.Images.SetKeyName(63, "wand.png");
            this.imageList_subitems.Images.SetKeyName(64, "weather_clouds.png");
            this.imageList_subitems.Images.SetKeyName(65, "weather_cloudy.png");
            this.imageList_subitems.Images.SetKeyName(66, "weather_lightning.png");
            this.imageList_subitems.Images.SetKeyName(67, "weather_rain.png");
            this.imageList_subitems.Images.SetKeyName(68, "weather_snow.png");
            this.imageList_subitems.Images.SetKeyName(69, "weather_sun.png");
            this.imageList_subitems.Images.SetKeyName(70, "webcam.png");
            this.imageList_subitems.Images.SetKeyName(71, "webcam_add.png");
            this.imageList_subitems.Images.SetKeyName(72, "webcam_delete.png");
            this.imageList_subitems.Images.SetKeyName(73, "webcam_error.png");
            this.imageList_subitems.Images.SetKeyName(74, "world.png");
            this.imageList_subitems.Images.SetKeyName(75, "world_add.png");
            this.imageList_subitems.Images.SetKeyName(76, "world_delete.png");
            this.imageList_subitems.Images.SetKeyName(77, "world_edit.png");
            this.imageList_subitems.Images.SetKeyName(78, "world_go.png");
            this.imageList_subitems.Images.SetKeyName(79, "world_link.png");
            this.imageList_subitems.Images.SetKeyName(80, "wrench.png");
            this.imageList_subitems.Images.SetKeyName(81, "wrench_orange.png");
            this.imageList_subitems.Images.SetKeyName(82, "xhtml.png");
            this.imageList_subitems.Images.SetKeyName(83, "xhtml_add.png");
            this.imageList_subitems.Images.SetKeyName(84, "xhtml_delete.png");
            this.imageList_subitems.Images.SetKeyName(85, "xhtml_go.png");
            this.imageList_subitems.Images.SetKeyName(86, "xhtml_valid.png");
            this.imageList_subitems.Images.SetKeyName(87, "zoom.png");
            this.imageList_subitems.Images.SetKeyName(88, "zoom_in.png");
            this.imageList_subitems.Images.SetKeyName(89, "zoom_out.png");
            // 
            // checkBox_use_user_draw_mode
            // 
            this.checkBox_use_user_draw_mode.AutoSize = true;
            this.checkBox_use_user_draw_mode.Location = new System.Drawing.Point(412, 117);
            this.checkBox_use_user_draw_mode.Name = "checkBox_use_user_draw_mode";
            this.checkBox_use_user_draw_mode.Size = new System.Drawing.Size(128, 17);
            this.checkBox_use_user_draw_mode.TabIndex = 21;
            this.checkBox_use_user_draw_mode.Text = "Use user draw mode.";
            this.checkBox_use_user_draw_mode.UseVisualStyleBackColor = true;
            this.checkBox_use_user_draw_mode.CheckedChanged += new System.EventHandler(this.checkBox_use_user_draw_mode_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 675);
            this.Controls.Add(this.managedListView1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(818, 714);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_child_items)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private MLV.ManagedListView managedListView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ImageList imageList_items;
        private System.Windows.Forms.ImageList imageList_subitems;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_child_items;
        private System.Windows.Forms.CheckBox checkBox_addChildren;
        private System.Windows.Forms.ComboBox comboBox_bkg_mode;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox checkBox_includeRatingSubitem;
        private System.Windows.Forms.ComboBox comboBox_mode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_StretchThumbnailsToFit;
        private System.Windows.Forms.CheckBox checkBox_showThumbIfo;
        private System.Windows.Forms.CheckBox checkBox_use_custom_text_colors;
        private System.Windows.Forms.CheckBox checkBox_use_user_draw_mode;
    }
}

