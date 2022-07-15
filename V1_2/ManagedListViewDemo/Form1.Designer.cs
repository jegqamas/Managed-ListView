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
namespace ManagedListViewDemo
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.managedListView_demo1 = new MLV.ManagedListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_addItem = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_columnName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.managedListView_demo2 = new MLV.ManagedListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_demo2Status = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.managedListView_demo3 = new MLV.ManagedListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_zoomValue = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(605, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.managedListView_demo1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 411);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Details view mode demo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // managedListView_demo1
            // 
            this.managedListView_demo1.AllowColumnsReorder = true;
            this.managedListView_demo1.AllowItemsDragAndDrop = true;
            this.managedListView_demo1.AutoSetWheelScrollSpeed = true;
            this.managedListView_demo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.managedListView_demo1.ChangeColumnSortModeWhenClick = true;
            this.managedListView_demo1.ColumnClickColor = System.Drawing.Color.PaleVioletRed;
            this.managedListView_demo1.ColumnColor = System.Drawing.Color.Silver;
            this.managedListView_demo1.ColumnHighlightColor = System.Drawing.Color.LightSkyBlue;
            this.managedListView_demo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managedListView_demo1.DrawHighlight = true;
            this.managedListView_demo1.ItemHighlightColor = System.Drawing.Color.LightSkyBlue;
            this.managedListView_demo1.ItemMouseOverColor = System.Drawing.Color.LightGray;
            this.managedListView_demo1.ItemSpecialColor = System.Drawing.Color.YellowGreen;
            this.managedListView_demo1.Location = new System.Drawing.Point(3, 58);
            this.managedListView_demo1.Name = "managedListView_demo1";
            this.managedListView_demo1.Size = new System.Drawing.Size(591, 300);
            this.managedListView_demo1.StretchThumbnailsToFit = false;
            this.managedListView_demo1.TabIndex = 1;
            this.managedListView_demo1.ThunmbnailsHeight = 36;
            this.managedListView_demo1.ThunmbnailsWidth = 36;
            this.managedListView_demo1.ViewMode = MLV.ManagedListViewViewMode.Details;
            this.managedListView_demo1.WheelScrollSpeed = 34;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.textBox_addItem);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.textBox_columnName);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 358);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 50);
            this.panel1.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(496, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Clear all";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(415, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Clear items";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox_addItem
            // 
            this.textBox_addItem.Location = new System.Drawing.Point(291, 8);
            this.textBox_addItem.Name = "textBox_addItem";
            this.textBox_addItem.Size = new System.Drawing.Size(118, 20);
            this.textBox_addItem.TabIndex = 3;
            this.textBox_addItem.Text = "Item";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(210, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add item";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_columnName
            // 
            this.textBox_columnName.Location = new System.Drawing.Point(86, 8);
            this.textBox_columnName.Name = "textBox_columnName";
            this.textBox_columnName.Size = new System.Drawing.Size(118, 20);
            this.textBox_columnName.TabIndex = 1;
            this.textBox_columnName.Text = "Column";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add column";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(591, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "This demo will test how to add item in details view mode of the Managed ListView " +
    "control. Use the buttons below to test. You sholud add columns first before addi" +
    "ng items.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.managedListView_demo2);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(597, 411);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Advanced details mode";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // managedListView_demo2
            // 
            this.managedListView_demo2.AllowColumnsReorder = true;
            this.managedListView_demo2.AllowItemsDragAndDrop = true;
            this.managedListView_demo2.AutoSetWheelScrollSpeed = true;
            this.managedListView_demo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.managedListView_demo2.ChangeColumnSortModeWhenClick = false;
            this.managedListView_demo2.ColumnClickColor = System.Drawing.Color.PaleVioletRed;
            this.managedListView_demo2.ColumnColor = System.Drawing.Color.Silver;
            this.managedListView_demo2.ColumnHighlightColor = System.Drawing.Color.LightSkyBlue;
            this.managedListView_demo2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managedListView_demo2.DrawHighlight = true;
            this.managedListView_demo2.ImagesList = this.imageList1;
            this.managedListView_demo2.ItemHighlightColor = System.Drawing.Color.LightSkyBlue;
            this.managedListView_demo2.ItemMouseOverColor = System.Drawing.Color.LightGray;
            this.managedListView_demo2.ItemSpecialColor = System.Drawing.Color.YellowGreen;
            this.managedListView_demo2.Location = new System.Drawing.Point(3, 58);
            this.managedListView_demo2.Name = "managedListView_demo2";
            this.managedListView_demo2.Size = new System.Drawing.Size(591, 300);
            this.managedListView_demo2.StretchThumbnailsToFit = false;
            this.managedListView_demo2.TabIndex = 4;
            this.managedListView_demo2.ThunmbnailsHeight = 36;
            this.managedListView_demo2.ThunmbnailsWidth = 36;
            this.managedListView_demo2.ViewMode = MLV.ManagedListViewViewMode.Details;
            this.managedListView_demo2.WheelScrollSpeed = 19;
            this.managedListView_demo2.DrawSubItem += new System.EventHandler<MLV.ManagedListViewSubItemDrawArgs>(this.managedListView_demo2_DrawSubItem);
            this.managedListView_demo2.ColumnClicked += new System.EventHandler<MLV.ManagedListViewColumnClickArgs>(this.managedListView_demo2_ColumnClicked);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "flag_yellow.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "folder_add.png");
            this.imageList1.Images.SetKeyName(3, "folder_bell.png");
            this.imageList1.Images.SetKeyName(4, "folder_brick.png");
            this.imageList1.Images.SetKeyName(5, "folder_bug.png");
            this.imageList1.Images.SetKeyName(6, "folder_camera.png");
            this.imageList1.Images.SetKeyName(7, "folder_delete.png");
            this.imageList1.Images.SetKeyName(8, "folder_edit.png");
            this.imageList1.Images.SetKeyName(9, "folder_error.png");
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label_demo2Status);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 358);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(591, 50);
            this.panel2.TabIndex = 5;
            // 
            // label_demo2Status
            // 
            this.label_demo2Status.AutoSize = true;
            this.label_demo2Status.Location = new System.Drawing.Point(86, 11);
            this.label_demo2Status.Name = "label_demo2Status";
            this.label_demo2Status.Size = new System.Drawing.Size(118, 13);
            this.label_demo2Status.TabIndex = 1;
            this.label_demo2Status.Text = "Click on column to sort.";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(5, 6);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 0;
            this.button8.Text = "Refresh";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(591, 55);
            this.label2.TabIndex = 3;
            this.label2.Text = resources.GetString("label2.Text");
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.managedListView_demo3);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(597, 411);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Thumbnails view mode demo";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // managedListView_demo3
            // 
            this.managedListView_demo3.AllowColumnsReorder = true;
            this.managedListView_demo3.AllowDrop = true;
            this.managedListView_demo3.AllowItemsDragAndDrop = true;
            this.managedListView_demo3.AutoSetWheelScrollSpeed = true;
            this.managedListView_demo3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.managedListView_demo3.ChangeColumnSortModeWhenClick = false;
            this.managedListView_demo3.ColumnClickColor = System.Drawing.Color.PaleVioletRed;
            this.managedListView_demo3.ColumnColor = System.Drawing.Color.Silver;
            this.managedListView_demo3.ColumnHighlightColor = System.Drawing.Color.LightSkyBlue;
            this.managedListView_demo3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.managedListView_demo3.DrawHighlight = true;
            this.managedListView_demo3.ItemHighlightColor = System.Drawing.Color.LightSkyBlue;
            this.managedListView_demo3.ItemMouseOverColor = System.Drawing.Color.LightGray;
            this.managedListView_demo3.ItemSpecialColor = System.Drawing.Color.YellowGreen;
            this.managedListView_demo3.Location = new System.Drawing.Point(3, 58);
            this.managedListView_demo3.Name = "managedListView_demo3";
            this.managedListView_demo3.Size = new System.Drawing.Size(591, 300);
            this.managedListView_demo3.StretchThumbnailsToFit = false;
            this.managedListView_demo3.TabIndex = 7;
            this.managedListView_demo3.ThunmbnailsHeight = 120;
            this.managedListView_demo3.ThunmbnailsWidth = 120;
            this.managedListView_demo3.ViewMode = MLV.ManagedListViewViewMode.Thumbnails;
            this.managedListView_demo3.WheelScrollSpeed = 19;
            this.managedListView_demo3.DrawItem += new System.EventHandler<MLV.ManagedListViewItemDrawArgs>(this.managedListView_demo3_DrawItem);
            this.managedListView_demo3.ItemsDrag += new System.EventHandler(this.managedListView_demo3_ItemsDrag);
            this.managedListView_demo3.DragDrop += new System.Windows.Forms.DragEventHandler(this.managedListView_demo3_DragDrop);
            this.managedListView_demo3.DragEnter += new System.Windows.Forms.DragEventHandler(this.managedListView_demo3_DragEnter);
            this.managedListView_demo3.DragOver += new System.Windows.Forms.DragEventHandler(this.managedListView_demo3_DragOver);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label_zoomValue);
            this.panel3.Controls.Add(this.trackBar1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 358);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(591, 50);
            this.panel3.TabIndex = 8;
            // 
            // label_zoomValue
            // 
            this.label_zoomValue.AutoSize = true;
            this.label_zoomValue.Location = new System.Drawing.Point(280, 10);
            this.label_zoomValue.Name = "label_zoomValue";
            this.label_zoomValue.Size = new System.Drawing.Size(55, 13);
            this.label_zoomValue.TabIndex = 4;
            this.label_zoomValue.Text = "120 x 120";
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(128, 5);
            this.trackBar1.Maximum = 500;
            this.trackBar1.Minimum = 50;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(146, 23);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Zoom:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(466, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Note: only jpg, png and bmp formats accepted. You can drag items from the control" +
    " to a folder.";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(591, 55);
            this.label4.TabIndex = 6;
            this.label4.Text = resources.GetString("label4.Text");
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.linkLabel2);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.linkLabel1);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(597, 411);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "About";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(8, 132);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(212, 13);
            this.linkLabel2.TabIndex = 3;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "http://www.famfamfam.com/lab/icons/silk/";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 39);
            this.label7.TabIndex = 2;
            this.label7.Text = "Icons and images by:\r\n------------------\r\nMark James\r\n";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(8, 54);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(140, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "ahdsoftwares@hotmail.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(261, 39);
            this.label6.TabIndex = 0;
            this.label6.Text = "Managed ListView Demo + Managed ListView control:\r\n----------------------------\r\n" +
    "Copyright © Ala Ibrahim Hadid 2013";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 437);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Managed ListView Control Demo";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private MLV.ManagedListView managedListView_demo1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_columnName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_addItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private MLV.ManagedListView managedListView_demo2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_demo2Status;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tabPage3;
        private MLV.ManagedListView managedListView_demo3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_zoomValue;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label7;
    }
}

