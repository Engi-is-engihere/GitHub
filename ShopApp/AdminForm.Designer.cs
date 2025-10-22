namespace ShopApp
{
    partial class AdminForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.пользователиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.товарыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelDesktopPane = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пользователиToolStripMenuItem,
            this.заказыToolStripMenuItem,
            this.товарыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1382, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip";
            // 
            // пользователиToolStripMenuItem
            // 
            this.пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
            this.пользователиToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.пользователиToolStripMenuItem.Text = "Пользователи";
            this.пользователиToolStripMenuItem.Click += new System.EventHandler(this.пользователиToolStripMenuItem_Click);
            // 
            // заказыToolStripMenuItem
            // 
            this.заказыToolStripMenuItem.Name = "заказыToolStripMenuItem";
            this.заказыToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.заказыToolStripMenuItem.Text = "Заказы";
            this.заказыToolStripMenuItem.Click += new System.EventHandler(this.заказыToolStripMenuItem_Click);
            // 
            // товарыToolStripMenuItem
            // 
            this.товарыToolStripMenuItem.Name = "товарыToolStripMenuItem";
            this.товарыToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.товарыToolStripMenuItem.Text = "Товары";
            this.товарыToolStripMenuItem.Click += new System.EventHandler(this.товарыToolStripMenuItem_Click);
            // 
            // PanelDesktopPane
            // 
            this.PanelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDesktopPane.Location = new System.Drawing.Point(0, 28);
            this.PanelDesktopPane.Name = "PanelDesktopPane";
            this.PanelDesktopPane.Size = new System.Drawing.Size(1382, 705);
            this.PanelDesktopPane.TabIndex = 1;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 733);
            this.Controls.Add(this.PanelDesktopPane);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1400, 780);
            this.MinimumSize = new System.Drawing.Size(1400, 780);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem пользователиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem товарыToolStripMenuItem;
        private System.Windows.Forms.Panel PanelDesktopPane;
    }
}