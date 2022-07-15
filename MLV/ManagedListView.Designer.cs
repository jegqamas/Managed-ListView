namespace MLV
{
    partial class ManagedListView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel_h_scroll = new System.Windows.Forms.Panel();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.mlvPanel1 = new MLV.MLVPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel_h_scroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_h_scroll
            // 
            this.panel_h_scroll.Controls.Add(this.hScrollBar1);
            this.panel_h_scroll.Controls.Add(this.panel1);
            this.panel_h_scroll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_h_scroll.Location = new System.Drawing.Point(0, 695);
            this.panel_h_scroll.Name = "panel_h_scroll";
            this.panel_h_scroll.Size = new System.Drawing.Size(893, 17);
            this.panel_h_scroll.TabIndex = 0;
            this.panel_h_scroll.Visible = false;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 0);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(876, 17);
            this.hScrollBar1.TabIndex = 1;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            this.hScrollBar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManagedListView_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(876, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(17, 17);
            this.panel1.TabIndex = 0;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(876, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 695);
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.Visible = false;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            this.vScrollBar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManagedListView_KeyDown);
            // 
            // mlvPanel1
            // 
            this.mlvPanel1.BackColor = System.Drawing.Color.White;
            this.mlvPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mlvPanel1.Location = new System.Drawing.Point(0, 0);
            this.mlvPanel1.Name = "mlvPanel1";
            this.mlvPanel1.Size = new System.Drawing.Size(876, 695);
            this.mlvPanel1.TabIndex = 2;
            this.mlvPanel1.Text = "mlvPanel1";
            this.mlvPanel1.RefreshScrollX += new System.EventHandler(this.mlvPanel1_RefreshScrollX);
            this.mlvPanel1.RefreshScrollY += new System.EventHandler(this.mlvPanel1_RefreshScrollY);
            this.mlvPanel1.UpdateScrollBars += new System.EventHandler(this.mlvPanel1_UpdateScrollBars);
            this.mlvPanel1.ItemsDrag += new System.EventHandler(this.mlvPanel1_ItemsDrag_1);
            this.mlvPanel1.RatingChangedOfSubItem += new System.EventHandler<MLV.RatingChangedEventArgs>(this.mlvPanel1_RatingChangedOfSubItem);
            this.mlvPanel1.HideTooltip += new System.EventHandler(this.mlvPanel1_HideTooltip);
            this.mlvPanel1.ShowTooltip += new System.EventHandler<MLV.ShowTooltipEventArgs>(this.mlvPanel1_ShowTooltip);
            this.mlvPanel1.HideThumbnailInfo += new System.EventHandler(this.mlvPanel1_HideThumbnailInfo);
            this.mlvPanel1.ShowThumbnailInfo += new System.EventHandler<MLV.ShowThumbnailInfoEventArgs>(this.mlvPanel1_ShowThumbnailInfo);
            this.mlvPanel1.DrawItem += new System.EventHandler<MLV.MLVDrawItemEventArgs>(this.mlvPanel1_DrawItem);
            this.mlvPanel1.DrawSubItem += new System.EventHandler<MLV.MLVDrawSubItemEventArgs>(this.mlvPanel1_DrawSubItem);
            this.mlvPanel1.Enter += new System.EventHandler(this.mlvPanel1_Enter);
            // 
            // ManagedListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mlvPanel1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.panel_h_scroll);
            this.Name = "ManagedListView";
            this.Size = new System.Drawing.Size(893, 712);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ManagedListView_KeyDown);
            this.panel_h_scroll.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_h_scroll;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Panel panel1;
        private MLVPanel mlvPanel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
