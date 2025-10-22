namespace ShopApp
{
    partial class CreateOrderForm
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
            this.labelName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAdres = new System.Windows.Forms.TextBox();
            this.comboBoxTypePay = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.CountProductNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CountProductNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.Location = new System.Drawing.Point(173, 27);
            this.labelName.MaximumSize = new System.Drawing.Size(350, 40);
            this.labelName.MinimumSize = new System.Drawing.Size(350, 40);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(350, 40);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Оформление заказа";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(131, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Количесвто";
            // 
            // textBoxAdres
            // 
            this.textBoxAdres.Location = new System.Drawing.Point(380, 266);
            this.textBoxAdres.Name = "textBoxAdres";
            this.textBoxAdres.Size = new System.Drawing.Size(231, 22);
            this.textBoxAdres.TabIndex = 5;
            // 
            // comboBoxTypePay
            // 
            this.comboBoxTypePay.FormattingEnabled = true;
            this.comboBoxTypePay.Items.AddRange(new object[] {
            "Оплата картой",
            "Оплата по номеру телефона",
            "Оплата при получении"});
            this.comboBoxTypePay.Location = new System.Drawing.Point(379, 202);
            this.comboBoxTypePay.Name = "comboBoxTypePay";
            this.comboBoxTypePay.Size = new System.Drawing.Size(232, 24);
            this.comboBoxTypePay.TabIndex = 6;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.ForestGreen;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(136, 349);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(200, 38);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Оформить заказ";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.ForeColor = System.Drawing.Color.White;
            this.btnCancle.Location = new System.Drawing.Point(353, 349);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(200, 38);
            this.btnCancle.TabIndex = 8;
            this.btnCancle.Text = "Отменить";
            this.btnCancle.UseVisualStyleBackColor = false;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // CountProductNumeric
            // 
            this.CountProductNumeric.Location = new System.Drawing.Point(379, 138);
            this.CountProductNumeric.Name = "CountProductNumeric";
            this.CountProductNumeric.Size = new System.Drawing.Size(232, 22);
            this.CountProductNumeric.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(131, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Способ оплаты";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(131, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 29);
            this.label3.TabIndex = 11;
            this.label3.Text = "Адрес доставки";
            // 
            // errorlabel
            // 
            this.errorlabel.AutoSize = true;
            this.errorlabel.ForeColor = System.Drawing.Color.Red;
            this.errorlabel.Location = new System.Drawing.Point(142, 408);
            this.errorlabel.Name = "errorlabel";
            this.errorlabel.Size = new System.Drawing.Size(0, 16);
            this.errorlabel.TabIndex = 12;
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 503);
            this.Controls.Add(this.errorlabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CountProductNumeric);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.comboBoxTypePay);
            this.Controls.Add(this.textBoxAdres);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelName);
            this.MaximumSize = new System.Drawing.Size(740, 550);
            this.MinimumSize = new System.Drawing.Size(740, 550);
            this.Name = "CreateOrderForm";
            this.Text = "CreateOrderForm";
            ((System.ComponentModel.ISupportInitialize)(this.CountProductNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAdres;
        private System.Windows.Forms.ComboBox comboBoxTypePay;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.NumericUpDown CountProductNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label errorlabel;
    }
}