namespace ShopApp
{
    partial class BasketForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.AdresstextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotalCost = new System.Windows.Forms.Label();
            this.dgvSelectedProduct = new System.Windows.Forms.DataGridView();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.btnRemoveProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(33, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 25);
            this.label7.TabIndex = 69;
            this.label7.Text = "Адрес доставки";
            // 
            // AdresstextBox
            // 
            this.AdresstextBox.Location = new System.Drawing.Point(36, 82);
            this.AdresstextBox.Name = "AdresstextBox";
            this.AdresstextBox.Size = new System.Drawing.Size(216, 22);
            this.AdresstextBox.TabIndex = 66;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(709, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 20);
            this.label5.TabIndex = 65;
            this.label5.Text = "Итоговая стоимость";
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.AutoSize = true;
            this.txtTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTotalCost.Location = new System.Drawing.Point(709, 79);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.Size = new System.Drawing.Size(34, 20);
            this.txtTotalCost.TabIndex = 64;
            this.txtTotalCost.Text = "0 Р";
            // 
            // dgvSelectedProduct
            // 
            this.dgvSelectedProduct.BackgroundColor = System.Drawing.Color.White;
            this.dgvSelectedProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedProduct.Location = new System.Drawing.Point(36, 155);
            this.dgvSelectedProduct.Name = "dgvSelectedProduct";
            this.dgvSelectedProduct.RowHeadersWidth = 51;
            this.dgvSelectedProduct.RowTemplate.Height = 24;
            this.dgvSelectedProduct.Size = new System.Drawing.Size(654, 323);
            this.dgvSelectedProduct.TabIndex = 58;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(666, 558);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(216, 66);
            this.buttonCancel.TabIndex = 56;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonCreateOrder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCreateOrder.FlatAppearance.BorderSize = 0;
            this.buttonCreateOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCreateOrder.ForeColor = System.Drawing.Color.White;
            this.buttonCreateOrder.Location = new System.Drawing.Point(55, 558);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(216, 66);
            this.buttonCreateOrder.TabIndex = 55;
            this.buttonCreateOrder.Text = "Сделать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = false;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveProduct.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnRemoveProduct.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRemoveProduct.FlatAppearance.BorderSize = 0;
            this.btnRemoveProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRemoveProduct.ForeColor = System.Drawing.Color.White;
            this.btnRemoveProduct.Location = new System.Drawing.Point(696, 155);
            this.btnRemoveProduct.Name = "btnRemoveProduct";
            this.btnRemoveProduct.Size = new System.Drawing.Size(216, 66);
            this.btnRemoveProduct.TabIndex = 102;
            this.btnRemoveProduct.Text = "Удалить товар";
            this.btnRemoveProduct.UseVisualStyleBackColor = false;
            this.btnRemoveProduct.Click += new System.EventHandler(this.btnRemoveProduct_Click_1);
            // 
            // BasketForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(917, 653);
            this.Controls.Add(this.btnRemoveProduct);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AdresstextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTotalCost);
            this.Controls.Add(this.dgvSelectedProduct);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreateOrder);
            this.MaximumSize = new System.Drawing.Size(935, 700);
            this.MinimumSize = new System.Drawing.Size(935, 700);
            this.Name = "BasketForm";
            this.Text = "BasketForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox AdresstextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtTotalCost;
        private System.Windows.Forms.DataGridView dgvSelectedProduct;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button btnRemoveProduct;
    }
}