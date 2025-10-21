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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.BasketBtn = new System.Windows.Forms.Button();
            this.UpdateBtn = new System.Windows.Forms.Button();
            this.ProductPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(39, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(280, 22);
            this.textBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(352, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(270, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(652, 28);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(270, 24);
            this.comboBox2.TabIndex = 2;
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
            this.UpdateBtn.Size = new System.Drawing.Size(107, 46);
            this.UpdateBtn.TabIndex = 4;
            this.UpdateBtn.Text = "Обновить";
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
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.MaximumSize = new System.Drawing.Size(1400, 780);
            this.MinimumSize = new System.Drawing.Size(1400, 780);
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button BasketBtn;
        private System.Windows.Forms.Button UpdateBtn;
        private System.Windows.Forms.FlowLayoutPanel ProductPanel;
    }
}