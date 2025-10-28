using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp
{
    public partial class BasketForm : Form
    {
        private int _orderId;
        private List<(int ProductId, string ProductName, int Quantity, decimal Price)> selectedDetails = new List<(int, string, int, decimal)>();
        public BasketForm()
        {
            InitializeComponent();

            dgvSelectedProduct.Columns.Add("id_product", "ID товара");
            dgvSelectedProduct.Columns.Add("Name", "Наименование");
            dgvSelectedProduct.Columns.Add("Price", "Цена");
            dgvSelectedProduct.Columns.Add("count", "Количество");
            dgvSelectedProduct.Columns.Add("TotalPrice", "Общая стоимость");
            dgvSelectedProduct.Columns["id_product"].Visible = false;

            LoadBasket();
        }

        private void CalculateTotalCost()
        {
            decimal totalCost = 0;
            foreach (var item in selectedDetails)
            {
                totalCost += item.Price * item.Quantity;
            }
            txtTotalCost.Text = totalCost.ToString("C2");
        }

        private async Task SaveOrderDetails(int orderId)
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                await conn.OpenAsync();
                string deleteQuery = "DELETE FROM Product_Zakaz WHERE id_zakaz = @id";
                using (var deleteCmd = new SqlCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@id", orderId);
                    await deleteCmd.ExecuteNonQueryAsync();
                }
                foreach (var item in selectedDetails)
                {
                    string insertQuery = "INSERT INTO Product_Zakaz (id_product, id_zakaz, quantity) VALUES (@productId, @orderId, @quantity)";
                    using (var cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@productId", item.ProductId);
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
        }

        private void LoadBasket()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string query = @" SELECT p.id_product, p.Name, p.Price, PB.count
                        FROM Product_Basket PB
                        JOIN Product p ON PB.id_product = p.id_product
                        JOIN Basket B ON B.id_basket = PB.id_basket
                        WHERE B.id_user = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", Globals.id_user);
                try
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int productId = (int)reader["id_product"];
                        string productName = (string)reader["Name"];
                        decimal price = (decimal)reader["Price"];
                        int Count = (int)reader["count"];

                        selectedDetails.Add((productId, productName, Count, price));
                        dgvSelectedProduct.Rows.Add(productId, productName, Count, price, price * Count);
                    }
                    reader.Close();
                    CalculateTotalCost();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки товаров корзины: " + ex.Message);
                }
            }
        }

        private async void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            // Validate address input
            if (string.IsNullOrWhiteSpace(AdresstextBox.Text))
            {
                MessageBox.Show("Введите адрес доставки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            int orderId;
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string query = @"INSERT INTO Zakaz (id_user,delivery_address, order_date, status) VALUES (@id_user,@delivery_address, @order_date, @status); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_user", Globals.id_user);
                cmd.Parameters.AddWithValue("@delivery_address", AdresstextBox.Text);
                cmd.Parameters.AddWithValue("@order_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@status", "Заказано");
                try
                {
                    conn.Open();
                    var result = await cmd.ExecuteScalarAsync();
                    orderId = Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка сохранения заказа: " + ex.Message);
                    return;
                }
            }
            await SaveOrderDetails(orderId);
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string deleteBasketQuery = "DELETE FROM Product_Basket WHERE id_basket = @id";
                
               
                using (var deleteBasketCmd = new SqlCommand(deleteBasketQuery, conn))
                {
                    deleteBasketCmd.Parameters.AddWithValue("@id", Globals.id_basket);
                    try
                    {
                        conn.Open();
                        await deleteBasketCmd.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка очистки корзины: " + ex.Message);
                        return;
                    }
                }
               
            }
            MessageBox.Show("Заказ успешно сохранен");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnRemoveProduct_Click_1(object sender, EventArgs e)
        {
            if (dgvSelectedProduct.SelectedRows.Count > 0)
            {
                var row = dgvSelectedProduct.SelectedRows[0];
                int productId = (int)row.Cells["id_product"].Value;
                selectedDetails.RemoveAll(d => d.ProductId == productId);
                dgvSelectedProduct.Rows.Remove(row);
                CalculateTotalCost();
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления");
            }
        }
    }
}