using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
            UpdateProduct();    
        }
        public void UpdateProduct() {
            GroupBox groupBox = new GroupBox();
            groupBox.Width = 200; 
            groupBox.Height = 300; 
            groupBox.Text = ""; 

            
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Properties.Resources.Computer_nerd_1536x1054;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Width = 180;
            pictureBox.Height = 120;
            pictureBox.Top = 10;
            pictureBox.Left = 10;

            Label labelName = new Label();
            labelName.Text = "Название товара";
            labelName.Top = pictureBox.Bottom + 10;
            labelName.Left = 10;
            labelName.AutoSize = true;

            Label labelPrice = new Label();
            labelPrice.Text = "Цена: 1000 ₽";
            labelPrice.Top = labelName.Bottom + 5;
            labelPrice.Left = 10;
            labelPrice.AutoSize = true;

            Button btnAddToCart = new Button();
            btnAddToCart.Text = "В корзину";
            btnAddToCart.Width = 80;
            btnAddToCart.Top = labelPrice.Bottom + 10;
            btnAddToCart.Left = 10;

            Button btnReview = new Button();
            btnReview.Text = "Отзыв";
            btnReview.Width = 80;
            btnReview.Top = labelPrice.Bottom + 10;
            btnReview.Left = btnAddToCart.Right + 10;

            Button btnOrder = new Button();
            btnOrder.Text = "Оформить заказ";
            btnOrder.Width = 80;
            btnOrder.Top = labelPrice.Bottom + 10;
            btnOrder.Left = btnReview.Right + 10;

            groupBox.Controls.Add(pictureBox);
            groupBox.Controls.Add(labelName);
            groupBox.Controls.Add(labelPrice);
            groupBox.Controls.Add(btnAddToCart);
            groupBox.Controls.Add(btnReview);
            groupBox.Controls.Add(btnOrder);

            ProductPanel.Controls.Add(groupBox);
        
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
