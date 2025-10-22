using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public void UpdateProduct()
        {
            using (SqlConnection connection = new SqlConnection(Globals.connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Product";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                using (SqlDataReader sqlData = cmd.ExecuteReader())
                {
                    int offsetY = 10; 
                    while (sqlData.Read())
                    {
                        int id = sqlData.GetInt32(0);
                        string name = sqlData.GetString(1);
                        decimal price = sqlData.GetDecimal(2);
                        string description = sqlData.GetString(5);

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

                        Label labelId = new Label();
                        labelId.Text = id.ToString();
                        labelId.Visible = false;

                        Label labelName = new Label();
                        labelName.Text = "Название товара";
                        labelName.Top = pictureBox.Bottom + 10;
                        labelName.Left = 10;
                        labelName.AutoSize = true;

                        Label labelPrice = new Label();
                        labelPrice.Text = "Цена: 1000 ₽";
                        labelPrice.Top = pictureBox.Bottom + 10;
                        labelPrice.Left = labelName.Right + 5;
                        labelPrice.AutoSize = true;

                        Label labelStars = new Label();
                        labelStars.Text = "5 звезд";
                        labelStars.Top = labelName.Bottom + 5;
                        labelStars.Left = 10;
                        labelStars.AutoSize = true;

                        Button btnAddToBasket = new Button();
                        btnAddToBasket.Text = "В корзину";
                        btnAddToBasket.Width = 80;
                        btnAddToBasket.Top = labelPrice.Bottom + 5;
                        btnAddToBasket.Left = labelStars.Right + 5;
                        btnAddToBasket.BackColor = Color.Green;
                        btnAddToBasket.FlatStyle = FlatStyle.Flat;
                        btnAddToBasket.ForeColor = Color.White;

                        Button btnOrder = new Button();
                        btnOrder.Text = "Оформить заказ";
                        btnOrder.Width = 80;
                        btnOrder.Top = labelStars.Bottom + 5;
                        btnOrder.Left = 10;
                        btnOrder.BackColor = Color.Blue;
                        btnOrder.FlatStyle = FlatStyle.Flat;
                        btnOrder.ForeColor = Color.White;
                        btnOrder.Click += (sender, e) => this.btnOrder_Click(sender, e, int.Parse(labelId.Text));

                        Button btnReview = new Button();
                        btnReview.Text = "Отзыв";
                        btnReview.Width = 80;
                        btnReview.Top = btnAddToBasket.Bottom + 5;
                        btnReview.Left = btnOrder.Right + 25;
                        btnReview.BackColor = Color.Red;
                        btnReview.FlatStyle = FlatStyle.Flat;
                        btnReview.ForeColor = Color.White;

                        groupBox.Controls.Add(labelId);
                        groupBox.Controls.Add(pictureBox);
                        groupBox.Controls.Add(labelName);
                        groupBox.Controls.Add(labelPrice);
                        groupBox.Controls.Add(labelStars);
                        groupBox.Controls.Add(btnAddToBasket);
                        groupBox.Controls.Add(btnReview);
                        groupBox.Controls.Add(btnOrder);

                        groupBox.Left = 10; 
                        groupBox.Top = offsetY;

                        ProductPanel.Controls.Add(groupBox);

                        offsetY += groupBox.Height + 10; 
                    }
                }
            }
        }
        private void btnOrder_Click(object sender, EventArgs e,int id_product) {
            CreateOrderForm createOrderForm = new CreateOrderForm(id_product);
            createOrderForm.ShowDialog();
            createOrderForm = null;
        }
        private void BasketBtn_Click(object sender, EventArgs e)
        {

        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            ProductPanel.Controls.Clear();
            UpdateProduct();
        }
    }
}
