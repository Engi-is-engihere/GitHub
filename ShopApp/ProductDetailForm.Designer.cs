namespace ShopApp
{
    partial class ProductDetailForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ProductPricetextBox = new System.Windows.Forms.TextBox();
            this.ProductNametextBox = new System.Windows.Forms.TextBox();
            this.CreateOrderbtn = new System.Windows.Forms.Button();
            this.PriceProductlabel = new System.Windows.Forms.Label();
            this.ProductpictureBox = new System.Windows.Forms.PictureBox();
            this.DescProductextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ProductNamelabel = new System.Windows.Forms.Label();
            this.ProductSizetextBox = new System.Windows.Forms.TextBox();
            this.ProductTypetextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProductpictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(718, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 29);
            this.label2.TabIndex = 43;
            this.label2.Text = "Тип товара";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(718, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 29);
            this.label1.TabIndex = 41;
            this.label1.Text = "Размер товара";
            // 
            // ProductPricetextBox
            // 
            this.ProductPricetextBox.Location = new System.Drawing.Point(723, 149);
            this.ProductPricetextBox.Name = "ProductPricetextBox";
            this.ProductPricetextBox.ReadOnly = true;
            this.ProductPricetextBox.Size = new System.Drawing.Size(305, 22);
            this.ProductPricetextBox.TabIndex = 40;
            // 
            // ProductNametextBox
            // 
            this.ProductNametextBox.Location = new System.Drawing.Point(723, 81);
            this.ProductNametextBox.Name = "ProductNametextBox";
            this.ProductNametextBox.ReadOnly = true;
            this.ProductNametextBox.Size = new System.Drawing.Size(305, 22);
            this.ProductNametextBox.TabIndex = 39;
            // 
            // CreateOrderbtn
            // 
            this.CreateOrderbtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.CreateOrderbtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.CreateOrderbtn.FlatAppearance.BorderSize = 0;
            this.CreateOrderbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateOrderbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CreateOrderbtn.ForeColor = System.Drawing.Color.Black;
            this.CreateOrderbtn.Location = new System.Drawing.Point(723, 348);
            this.CreateOrderbtn.Name = "CreateOrderbtn";
            this.CreateOrderbtn.Size = new System.Drawing.Size(305, 66);
            this.CreateOrderbtn.TabIndex = 37;
            this.CreateOrderbtn.Text = "Заказать";
            this.CreateOrderbtn.UseVisualStyleBackColor = false;
            this.CreateOrderbtn.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // PriceProductlabel
            // 
            this.PriceProductlabel.AutoSize = true;
            this.PriceProductlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PriceProductlabel.Location = new System.Drawing.Point(718, 117);
            this.PriceProductlabel.Name = "PriceProductlabel";
            this.PriceProductlabel.Size = new System.Drawing.Size(157, 29);
            this.PriceProductlabel.TabIndex = 34;
            this.PriceProductlabel.Text = "Цена товара";
            // 
            // ProductpictureBox
            // 
            this.ProductpictureBox.Location = new System.Drawing.Point(46, 38);
            this.ProductpictureBox.Name = "ProductpictureBox";
            this.ProductpictureBox.Size = new System.Drawing.Size(646, 376);
            this.ProductpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProductpictureBox.TabIndex = 33;
            this.ProductpictureBox.TabStop = false;
            // 
            // DescProductextBox
            // 
            this.DescProductextBox.Location = new System.Drawing.Point(46, 485);
            this.DescProductextBox.Multiline = true;
            this.DescProductextBox.Name = "DescProductextBox";
            this.DescProductextBox.ReadOnly = true;
            this.DescProductextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.DescProductextBox.Size = new System.Drawing.Size(1096, 229);
            this.DescProductextBox.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(41, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 29);
            this.label3.TabIndex = 31;
            this.label3.Text = "Описание товара";
            // 
            // ProductNamelabel
            // 
            this.ProductNamelabel.AutoSize = true;
            this.ProductNamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductNamelabel.Location = new System.Drawing.Point(718, 38);
            this.ProductNamelabel.Name = "ProductNamelabel";
            this.ProductNamelabel.Size = new System.Drawing.Size(211, 29);
            this.ProductNamelabel.TabIndex = 30;
            this.ProductNamelabel.Text = "Название товара";
            // 
            // ProductSizetextBox
            // 
            this.ProductSizetextBox.Location = new System.Drawing.Point(723, 214);
            this.ProductSizetextBox.Name = "ProductSizetextBox";
            this.ProductSizetextBox.ReadOnly = true;
            this.ProductSizetextBox.Size = new System.Drawing.Size(305, 22);
            this.ProductSizetextBox.TabIndex = 44;
            // 
            // ProductTypetextBox
            // 
            this.ProductTypetextBox.Location = new System.Drawing.Point(723, 271);
            this.ProductTypetextBox.Name = "ProductTypetextBox";
            this.ProductTypetextBox.ReadOnly = true;
            this.ProductTypetextBox.Size = new System.Drawing.Size(305, 22);
            this.ProductTypetextBox.TabIndex = 45;
            // 
            // ProductDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.ProductTypetextBox);
            this.Controls.Add(this.ProductSizetextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProductPricetextBox);
            this.Controls.Add(this.ProductNametextBox);
            this.Controls.Add(this.CreateOrderbtn);
            this.Controls.Add(this.PriceProductlabel);
            this.Controls.Add(this.ProductpictureBox);
            this.Controls.Add(this.DescProductextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProductNamelabel);
            this.MaximumSize = new System.Drawing.Size(1200, 800);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "ProductDetailForm";
            this.Text = "ProductDetailForm";
            ((System.ComponentModel.ISupportInitialize)(this.ProductpictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ProductPricetextBox;
        private System.Windows.Forms.TextBox ProductNametextBox;
        private System.Windows.Forms.Button CreateOrderbtn;
        private System.Windows.Forms.Label PriceProductlabel;
        private System.Windows.Forms.PictureBox ProductpictureBox;
        private System.Windows.Forms.TextBox DescProductextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ProductNamelabel;
        private System.Windows.Forms.TextBox ProductSizetextBox;
        private System.Windows.Forms.TextBox ProductTypetextBox;
    }
}