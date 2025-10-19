namespace ShopApp
{
    partial class RegisterForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.PasswordtextBox = new System.Windows.Forms.TextBox();
            this.LogintextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PasswordtextBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Cyan;
            this.label5.Location = new System.Drawing.Point(391, 447);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Войти";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(215, 447);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Уже есть аккаунт?";
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LoginBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.LoginBtn.FlatAppearance.BorderSize = 0;
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.LoginBtn.Location = new System.Drawing.Point(243, 376);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(197, 40);
            this.LoginBtn.TabIndex = 13;
            this.LoginBtn.Text = "Зарегистрироваться";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // PasswordtextBox
            // 
            this.PasswordtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordtextBox.Location = new System.Drawing.Point(206, 249);
            this.PasswordtextBox.Name = "PasswordtextBox";
            this.PasswordtextBox.Size = new System.Drawing.Size(277, 30);
            this.PasswordtextBox.TabIndex = 12;
            this.PasswordtextBox.Enter += new System.EventHandler(this.PasswordtextBox_Enter);
            this.PasswordtextBox.Leave += new System.EventHandler(this.PasswordtextBox_Leave);
            // 
            // LogintextBox
            // 
            this.LogintextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.LogintextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogintextBox.Location = new System.Drawing.Point(206, 184);
            this.LogintextBox.Name = "LogintextBox";
            this.LogintextBox.Size = new System.Drawing.Size(277, 30);
            this.LogintextBox.TabIndex = 11;
            this.LogintextBox.Tag = "";
            this.LogintextBox.Enter += new System.EventHandler(this.LogintextBox_Enter);
            this.LogintextBox.Leave += new System.EventHandler(this.LogintextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(202, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Введите пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(202, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Введите логин";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(186, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 54);
            this.label1.TabIndex = 8;
            this.label1.Text = "Регистрация";
            // 
            // PasswordtextBox2
            // 
            this.PasswordtextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordtextBox2.Location = new System.Drawing.Point(206, 325);
            this.PasswordtextBox2.Name = "PasswordtextBox2";
            this.PasswordtextBox2.Size = new System.Drawing.Size(277, 30);
            this.PasswordtextBox2.TabIndex = 17;
            this.PasswordtextBox2.Enter += new System.EventHandler(this.PasswordtextBox2_Enter);
            this.PasswordtextBox2.Leave += new System.EventHandler(this.PasswordtextBox2_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(202, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Повторите пароль";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(392, 153);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(0, 16);
            this.ErrorLabel.TabIndex = 18;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(682, 553);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.PasswordtextBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PasswordtextBox);
            this.Controls.Add(this.LogintextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(700, 600);
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.TextBox PasswordtextBox;
        private System.Windows.Forms.TextBox LogintextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordtextBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label ErrorLabel;
    }
}