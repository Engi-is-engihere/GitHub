using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShopApp
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
            LoadProductTypes();

           
           
            UpdateProduct();
        }

        private Image LoadDefaultImage()
        {
            try
            {
                // Try to load NOPHOTO from resources
                return Properties.Resources.NOPHOTO;
            }
            catch
            {
                // If NOPHOTO fails, try to load from file
                try
                {
                    string imagePath = System.IO.Path.Combine(Application.StartupPath, "Resources", "NOPHOTO.jpg");
                    if (System.IO.File.Exists(imagePath))
                    {
                        return Image.FromFile(imagePath);
                    }
                }
                catch
                {
                    // If all else fails, create a simple placeholder
                    Bitmap placeholder = new Bitmap(180, 120);
                    using (Graphics g = Graphics.FromImage(placeholder))
                    {
                        g.Clear(Color.LightGray);
                        g.DrawString("No Photo", new Font("Arial", 12), Brushes.Black, 50, 50);
                    }
                    return placeholder;
                }
            }
            return null;
        }

        public void UpdateProduct()
        {
            using (SqlConnection connection = new SqlConnection(Globals.connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT P.[id_product], P.[Name], P.[Price], P.[Description], P.[Photo], P.[id_ProductType], PT.[type_name] FROM [Product] P JOIN ProductType PT ON PT.id_ProductType = P.id_ProductType";
                SqlCommand cmd = new SqlCommand(selectQuery, connection);
                using (SqlDataReader sqlData = cmd.ExecuteReader())
                {
                    int offsetY = 10;
                    while (sqlData.Read())
                    {
                        int id = sqlData.GetInt32(0);
                        string name = sqlData.GetString(1);
                        decimal price = sqlData.GetDecimal(2);
                        string description = sqlData.GetString(3);
                        byte[] photoBytes = null;
                        int typeId = sqlData.GetInt32(5); 
                        string typeName = sqlData.GetString(6);

                        if (!sqlData.IsDBNull(4))
                        {
                            photoBytes = (byte[])sqlData["Photo"];
                        }

                        Image productImage = null;
                        if (photoBytes != null && photoBytes.Length > 0)
                        {
                            using (var ms = new System.IO.MemoryStream(photoBytes))
                            {
                                productImage = Image.FromStream(ms);
                            }
                        }

                        PictureBox pictureBox = new PictureBox
                        {
                            Image = productImage ?? LoadDefaultImage(),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Width = 180,
                            Height = 120,
                            Top = 10,
                            Left = 10
                        };

                        Label labelId = new Label { Text = id.ToString(), Visible = false };
                        Label labelName = new Label
                        {
                            Text = name,
                            Top = pictureBox.Bottom + 10,
                            Left = 10,
                            AutoSize = true
                        };
                        Label labelPrice = new Label
                        {
                            Text = price.ToString() + " ₽",
                            Top = pictureBox.Bottom + 10,
                            Left = labelName.Right + 5,
                            AutoSize = true
                        };
                        Label labeltypeName = new Label
                        {
                            Text = typeName.ToString(),
                            Top = labelName.Bottom + 5,
                            Left = 10,
                            AutoSize = true
                        };

                        Button btnAddToBasket = new Button
                        {
                            Text = "В корзину",
                            Width = 80,
                            Top = labelPrice.Bottom + 5,
                            Left = labeltypeName.Right + 5,
                            BackColor = Color.Green,
                            FlatStyle = FlatStyle.Flat,
                            ForeColor = Color.White
                        };
                        btnAddToBasket.Click += (sender, e) => this.addToBasket(sender, e, id);

                        Button btnOrder = new Button
                        {
                            Text = "Оформить заказ",
                            Width = 80,
                            Top = labeltypeName.Bottom + 5,
                            Left = 10,
                            BackColor = Color.Blue,
                            FlatStyle = FlatStyle.Flat,
                            ForeColor = Color.White
                        };
                        btnOrder.Click += (sender, e) => this.btnOrder_Click(sender, e, id);

                        Button btnDetails = new Button
                        {
                            Text = "Детали",
                            Width = 80,
                            Top = btnAddToBasket.Bottom + 5,
                            Left = btnOrder.Right + 25,
                            BackColor = Color.Red,
                            FlatStyle = FlatStyle.Flat,
                            ForeColor = Color.White
                        };
                        btnDetails.Click += (sender, e) => this.btnDetails_Click(sender, e, id);

                        GroupBox groupBox = new GroupBox
                        {
                            Width = 200,
                            Height = 300,
                            Tag = new { Name = name, TypeId = typeId }
                        };
                        groupBox.Controls.Add(labelId);
                        groupBox.Controls.Add(pictureBox);
                        groupBox.Controls.Add(labelName);
                        groupBox.Controls.Add(labelPrice);
                        groupBox.Controls.Add(labeltypeName);
                        groupBox.Controls.Add(btnAddToBasket);
                        groupBox.Controls.Add(btnDetails);
                        groupBox.Controls.Add(btnOrder);
                        groupBox.Left = 10;
                        groupBox.Top = offsetY;
                        ProductPanel.Controls.Add(groupBox);
                        offsetY += groupBox.Height + 10;
                    }
                }
            }
        }

        private void LoadProductTypes()
        {
            using (SqlConnection connection = new SqlConnection(Globals.connectionString))
            {
                string query = "SELECT id_ProductType, type_name FROM ProductType";
                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    da.Fill(dt);
                    cmbSortType.DataSource = dt;
                    cmbSortType.DisplayMember = "type_name";
                    cmbSortType.ValueMember = "id_ProductType";
                    cmbSortType.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки типов: " + ex.Message);
                }
            }
        }
        private void addToBasket(object sender, EventArgs e, int id_product)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(Globals.connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Product_Basket (id_product, id_basket, count) VALUES (@id_product, @id_basket, @count)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id_product", id_product);
                        int currentUserId = Globals.id_basket; 
                        cmd.Parameters.AddWithValue("@id_basket", currentUserId);
                        cmd.Parameters.AddWithValue("@count", 1); 

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Товар добавлен в корзину.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления товара в корзину: " + ex.Message);
            }
        }
        private void ApplyFilters()
        {
            string searchText = txtSearch.Text.Trim().ToLower();
            int? selectedTypeId = null;
            if (cmbSortType.SelectedValue != null && int.TryParse(cmbSortType.SelectedValue.ToString(), out int typeId))
            {
                selectedTypeId = typeId;
            }

            string sortOrder = "";
            if (cmbSort.SelectedItem != null)
            {
                string selectedSort = cmbSort.SelectedItem.ToString();
                if (selectedSort == "Дороже")
                    sortOrder = "Price DESC";
                else if (selectedSort == "Дешевле")
                    sortOrder = "Price ASC";
            }

            var allGroups = ProductPanel.Controls.OfType<GroupBox>().ToList();

            var filteredGroups = allGroups.Where(gb =>
            {
                dynamic tag = gb.Tag;
                string productName = tag?.Name ?? "";
                int productTypeId = tag?.TypeId ?? -1;

                bool visible = true;

                if (!string.IsNullOrEmpty(searchText))
                {
                    visible &= productName.ToLower().Contains(searchText);
                }

                if (selectedTypeId.HasValue)
                {
                    visible &= productTypeId == selectedTypeId.Value;
                }

                return visible;
            }).ToList();

            if (!string.IsNullOrEmpty(sortOrder))
            {
                Func<GroupBox, decimal> getPrice = gb =>
                {
                    var labelPrice = gb.Controls.OfType<Label>().FirstOrDefault(l => l.Text.Contains("₽"));
                    if (labelPrice != null)
                    {
                        string priceText = labelPrice.Text.Replace("₽", "").Trim();
                        if (decimal.TryParse(priceText, out decimal price))
                        {
                            return price;
                        }
                    }
                    return 0m; 
                };

                if (sortOrder == "Price DESC")
                {
                    filteredGroups = filteredGroups
                        .OrderByDescending(gb => getPrice(gb))
                        .ToList();
                }
                else if (sortOrder == "Price ASC")
                {
                    filteredGroups = filteredGroups
                        .OrderBy(gb => getPrice(gb))
                        .ToList();
                }
            }

            // Clear all controls first
            ProductPanel.Controls.Clear();
            
            // Add all filtered groups back with proper visibility
            foreach (var gb in filteredGroups)
            {
                gb.Visible = true;
                ProductPanel.Controls.Add(gb);
            }

            // Add remaining groups but make them invisible
            foreach (var gb in allGroups.Except(filteredGroups))
            {
                gb.Visible = false;
                ProductPanel.Controls.Add(gb);  // Add back to controls to maintain references
            }
        }

        private void btnOrder_Click(object sender, EventArgs e, int id_product)
        {
            CreateOrderForm createOrderForm = new CreateOrderForm(id_product);
            createOrderForm.ShowDialog();
        }
        private void btnDetails_Click(object sender, EventArgs e, int id_product) {
            ProductDetailForm productDetailForm = new ProductDetailForm(id_product);
            productDetailForm.ShowDialog();
        }
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            ProductPanel.Controls.Clear();
            cmbSort.SelectedItem = null;
            cmbSortType.SelectedItem = null;
            UpdateProduct();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbSortType_SelectedIndexChanged(object sender, EventArgs e)
        {

            ApplyFilters();
        }

        private void cmbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void BasketBtn_Click(object sender, EventArgs e)
        {
            BasketForm basketForm = new BasketForm();
            basketForm.ShowDialog();
        }
    }
}