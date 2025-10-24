namespace ShopApp
{
    partial class ProductForm
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbSortType = new System.Windows.Forms.ComboBox();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.BasketBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.ProductPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(39, 28);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(280, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmbSortType
            // 
            this.cmbSortType.FormattingEnabled = true;
            this.cmbSortType.Location = new System.Drawing.Point(352, 28);
            this.cmbSortType.Name = "cmbSortType";
            this.cmbSortType.Size = new System.Drawing.Size(270, 24);
            this.cmbSortType.TabIndex = 1;
            this.cmbSortType.SelectedIndexChanged += new System.EventHandler(this.cmbSortType_SelectedIndexChanged);
            // 
            // cmbSort
            // 
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "Дороже",
            "Дешевле"});
            this.cmbSort.Location = new System.Drawing.Point(652, 28);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(270, 24);
            this.cmbSort.TabIndex = 2;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // BasketBtn
            // 
            this.BasketBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BasketBtn.FlatAppearance.BorderSize = 0;
            this.BasketBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BasketBtn.Location = new System.Drawing.Point(951, 28);
            this.BasketBtn.Name = "BasketBtn";
            this.BasketBtn.Size = new System.Drawing.Size(109, 42);
            this.BasketBtn.TabIndex = 3;
            this.BasketBtn.Text = "Корзина";
            this.BasketBtn.UseVisualStyleBackColor = false;
            this.BasketBtn.Click += new System.EventHandler(this.BasketBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.UpdateBtn.FlatAppearance.BorderSize = 0;
            this.UpdateBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateBtn.Location = new System.Drawing.Point(39, 66);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(139, 46);
            this.UpdateBtn.TabIndex = 4;
            this.UpdateBtn.Text = "Обновить и сбросить фильтры";
            this.UpdateBtn.UseVisualStyleBackColor = false;
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // ProductPanel
            // 
            this.ProductPanel.AutoScroll = true;
            this.ProductPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ProductPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProductPanel.Location = new System.Drawing.Point(0, 118);
            this.ProductPanel.Name = "ProductPanel";
            this.ProductPanel.Size = new System.Drawing.Size(1382, 615);
            this.ProductPanel.TabIndex = 5;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 733);
            this.Controls.Add(this.ProductPanel);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.BasketBtn);
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.cmbSortType);
            this.Controls.Add(this.txtSearch);
            this.MaximumSize = new System.Drawing.Size(1400, 780);
            this.MinimumSize = new System.Drawing.Size(1400, 780);
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbSortType;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Button BasketBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.FlowLayoutPanel ProductPanel;
    }
}