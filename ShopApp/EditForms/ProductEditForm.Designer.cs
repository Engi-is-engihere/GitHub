namespace ShopApp.EditForms
{
    partial class ProductEditForm
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
            this.DescProducttextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ProductNamelabel = new System.Windows.Forms.Label();
            this.ProductpictureBox = new System.Windows.Forms.PictureBox();
            this.PriceProductlabel = new System.Windows.Forms.Label();
            this.SizeProductcmb = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.LoadPhotoBtn = new System.Windows.Forms.Button();
            this.ProductNametextBox = new System.Windows.Forms.TextBox();
            this.ProductPricetextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TypeProductcmb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProductpictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DescProducttextBox
            // 
            this.DescProducttextBox.Location = new System.Drawing.Point(59, 468);
            this.DescProducttextBox.Multiline = true;
            this.DescProducttextBox.Name = "DescProducttextBox";
            this.DescProducttextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.DescProducttextBox.Size = new System.Drawing.Size(1096, 229);
            this.DescProducttextBox.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(54, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 29);
            this.label3.TabIndex = 17;
            this.label3.Text = "Описание товара";
            // 
            // ProductNamelabel
            // 
            this.ProductNamelabel.AutoSize = true;
            this.ProductNamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductNamelabel.Location = new System.Drawing.Point(731, 21);
            this.ProductNamelabel.Name = "ProductNamelabel";
            this.ProductNamelabel.Size = new System.Drawing.Size(211, 29);
            this.ProductNamelabel.TabIndex = 16;
            this.ProductNamelabel.Text = "Название товара";
            // 
            // ProductpictureBox
            // 
            this.ProductpictureBox.Location = new System.Drawing.Point(59, 21);
            this.ProductpictureBox.Name = "ProductpictureBox";
            this.ProductpictureBox.Size = new System.Drawing.Size(646, 376);
            this.ProductpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ProductpictureBox.TabIndex = 19;
            this.ProductpictureBox.TabStop = false;
            // 
            // PriceProductlabel
            // 
            this.PriceProductlabel.AutoSize = true;
            this.PriceProductlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PriceProductlabel.Location = new System.Drawing.Point(731, 100);
            this.PriceProductlabel.Name = "PriceProductlabel";
            this.PriceProductlabel.Size = new System.Drawing.Size(157, 29);
            this.PriceProductlabel.TabIndex = 20;
            this.PriceProductlabel.Text = "Цена товара";
            // 
            // SizeProductcmb
            // 
            this.SizeProductcmb.FormattingEnabled = true;
            this.SizeProductcmb.Location = new System.Drawing.Point(736, 195);
            this.SizeProductcmb.Name = "SizeProductcmb";
            this.SizeProductcmb.Size = new System.Drawing.Size(305, 24);
            this.SizeProductcmb.TabIndex = 21;
            this.SizeProductcmb.Text = "Размер товара";
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.ForeColor = System.Drawing.Color.Black;
            this.buttonSave.Location = new System.Drawing.Point(736, 293);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(305, 66);
            this.buttonSave.TabIndex = 22;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.ForeColor = System.Drawing.Color.Black;
            this.buttonCancel.Location = new System.Drawing.Point(736, 377);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(305, 66);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // LoadPhotoBtn
            // 
            this.LoadPhotoBtn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.LoadPhotoBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.LoadPhotoBtn.FlatAppearance.BorderSize = 0;
            this.LoadPhotoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadPhotoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoadPhotoBtn.ForeColor = System.Drawing.Color.Black;
            this.LoadPhotoBtn.Location = new System.Drawing.Point(497, 406);
            this.LoadPhotoBtn.Name = "LoadPhotoBtn";
            this.LoadPhotoBtn.Size = new System.Drawing.Size(208, 37);
            this.LoadPhotoBtn.TabIndex = 24;
            this.LoadPhotoBtn.Text = "Загрузить фото";
            this.LoadPhotoBtn.UseVisualStyleBackColor = false;
            this.LoadPhotoBtn.Click += new System.EventHandler(this.LoadPhotoBtn_Click);
            // 
            // ProductNametextBox
            // 
            this.ProductNametextBox.Location = new System.Drawing.Point(736, 64);
            this.ProductNametextBox.Name = "ProductNametextBox";
            this.ProductNametextBox.Size = new System.Drawing.Size(305, 22);
            this.ProductNametextBox.TabIndex = 25;
            // 
            // ProductPricetextBox
            // 
            this.ProductPricetextBox.Location = new System.Drawing.Point(736, 132);
            this.ProductPricetextBox.Name = "ProductPricetextBox";
            this.ProductPricetextBox.Size = new System.Drawing.Size(305, 22);
            this.ProductPricetextBox.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(731, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 29);
            this.label1.TabIndex = 27;
            this.label1.Text = "Размер товара";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(731, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 29);
            this.label2.TabIndex = 29;
            this.label2.Text = "Тип товара";
            // 
            // TypeProductcmb
            // 
            this.TypeProductcmb.FormattingEnabled = true;
            this.TypeProductcmb.Location = new System.Drawing.Point(736, 254);
            this.TypeProductcmb.Name = "TypeProductcmb";
            this.TypeProductcmb.Size = new System.Drawing.Size(305, 24);
            this.TypeProductcmb.TabIndex = 28;
            this.TypeProductcmb.Text = "Тип товара";
            // 
            // ProductEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TypeProductcmb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProductPricetextBox);
            this.Controls.Add(this.ProductNametextBox);
            this.Controls.Add(this.LoadPhotoBtn);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.SizeProductcmb);
            this.Controls.Add(this.PriceProductlabel);
            this.Controls.Add(this.ProductpictureBox);
            this.Controls.Add(this.DescProducttextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProductNamelabel);
            this.MaximumSize = new System.Drawing.Size(1200, 800);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "ProductEditForm";
            this.Text = "ProductEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.ProductpictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DescProducttextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ProductNamelabel;
        private System.Windows.Forms.PictureBox ProductpictureBox;
        private System.Windows.Forms.Label PriceProductlabel;
        private System.Windows.Forms.ComboBox SizeProductcmb;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button LoadPhotoBtn;
        private System.Windows.Forms.TextBox ProductNametextBox;
        private System.Windows.Forms.TextBox ProductPricetextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TypeProductcmb;
    }
}