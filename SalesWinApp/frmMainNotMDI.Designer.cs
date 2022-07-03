namespace SalesWinApp
{
    partial class frmMainNotMDI
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đângXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QLSPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QLTVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelHoten = new System.Windows.Forms.ToolStripStatusLabel();
            this.QLHDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.QLSPToolStripMenuItem,
            this.QLTVToolStripMenuItem,
            this.QLHDToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(869, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đângXuấtToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // đângXuấtToolStripMenuItem
            // 
            this.đângXuấtToolStripMenuItem.Name = "đângXuấtToolStripMenuItem";
            this.đângXuấtToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.đângXuấtToolStripMenuItem.Text = "Đăng xuất";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            // 
            // QLSPToolStripMenuItem
            // 
            this.QLSPToolStripMenuItem.Name = "QLSPToolStripMenuItem";
            this.QLSPToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.QLSPToolStripMenuItem.Text = "Quản lý sản phẩm";
            this.QLSPToolStripMenuItem.Click += new System.EventHandler(this.QLSPToolStripMenuItem_Click);
            // 
            // QLTVToolStripMenuItem
            // 
            this.QLTVToolStripMenuItem.Name = "QLTVToolStripMenuItem";
            this.QLTVToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.QLTVToolStripMenuItem.Text = "Quản lý Thành Viên ";
            this.QLTVToolStripMenuItem.Click += new System.EventHandler(this.QLTVToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelHoten});
            this.statusStrip.Location = new System.Drawing.Point(0, 442);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip.Size = new System.Drawing.Size(869, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabelHoten
            // 
            this.toolStripStatusLabelHoten.Name = "toolStripStatusLabelHoten";
            this.toolStripStatusLabelHoten.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabelHoten.Text = "Email";
            // 
            // QLHDToolStripMenuItem
            // 
            this.QLHDToolStripMenuItem.Name = "QLHDToolStripMenuItem";
            this.QLHDToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.QLHDToolStripMenuItem.Text = "Quản Lý Hóa Đơn ";
            this.QLHDToolStripMenuItem.Click += new System.EventHandler(this.QLHDToolStripMenuItem_Click);
            // 
            // frmMainNotMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(869, 464);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmMainNotMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelHoten;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đângXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QLSPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QLTVToolStripMenuItem;
        private ToolStripMenuItem QLHDToolStripMenuItem;
    }
}