using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp.EditForms
{
    public partial class OrderEditForm : Form
    {
        private int _orderId;
        private List<(int ProductId, string ProductName, int Quantity, decimal Price)> selectedDetails = new List<(int, string, int, decimal)>();
        

        public OrderEditForm(int orderId = 0)
        {
            InitializeComponent();
            _orderId = orderId;

            LoadCustomers();
            LoadProducts();

            dgvSelectedProduct.Columns.Add("ProductId", "ID товара");
            dgvSelectedProduct.Columns.Add("ProductName", "Наименование");
            dgvSelectedProduct.Columns.Add("Quantity", "Количество");
            dgvSelectedProduct.Columns.Add("Price", "Цена за ед.");
            dgvSelectedProduct.Columns.Add("TotalPrice", "Общая стоимость");
            dgvSelectedProduct.Columns["ProductId"].Visible = false;


            if (_orderId > 0)
            {
                LoadOrderData();
                LoadOrderDetails();
                this.Text = "Редактировать заказ";
            }
            else
            {
                this.Text = "Добавить заказ";
            }
        }

        private void LoadCustomers()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string query = "SELECT id_user, Login FROM [User]";
                var da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    da.Fill(dt);
                    cmbCustomer.DataSource = dt;
                    cmbCustomer.DisplayMember = "Login";
                    cmbCustomer.ValueMember = "id_user";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки клиентов: " + ex.Message);
                }
            }
        }

        private void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string query = "SELECT id_product, Name FROM Product";
                var da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    da.Fill(dt);
                    cmbProduct.DataSource = dt;
                    cmbProduct.DisplayMember = "Name";
                    cmbProduct.ValueMember = "id_product";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки товаров: " + ex.Message);
                }
            }
        }

        private void LoadOrderData()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string query = "SELECT * FROM Zakaz WHERE id_zakaz = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", _orderId);
                try
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        AdresstextBox.Text = reader["delivery_address"].ToString();
                        dateTimePicker.Value = (DateTime)reader["order_date"];
                        
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки заказа: " + ex.Message);
                }
            }
        }

        private void LoadOrderDetails()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string query = @"
            SELECT p.id_product, p.Name, p.Price, po.quantity
            FROM Product_Zakaz po
            JOIN Product p ON po.id_product = p.id_product
            WHERE po.id_zakaz = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", _orderId);

                try
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int productId = (int)reader["id_product"];
                        string productName = (string)reader["Name"];
                        decimal price = (decimal)reader["Price"];
                        int quantity = (int)reader["quantity"];

                        selectedDetails.Add((productId, productName, quantity, price));

                        dgvSelectedProduct.Rows.Add(productId, productName, quantity, price, price * quantity);
                    }
                    reader.Close();
                    CalculateTotalCost();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки товаров заказа: " + ex.Message);
                }
            }
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

       

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedValue == null || string.IsNullOrWhiteSpace(NumQuantity.Text))
            {
                MessageBox.Show("Выберите товар и укажите количество");
                return;
            }

            int productId = (int)cmbProduct.SelectedValue;
            string productName = cmbProduct.Text;

            if (!int.TryParse(NumQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Введите корректное количество");
                return;
            }

            decimal price;
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string query = "SELECT Price FROM Product WHERE id_product = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", productId);
                conn.Open();
                var obj = cmd.ExecuteScalar();
                if (obj != null)
                    price = (decimal)obj;
                else
                {
                    MessageBox.Show("Не удалось получить цену товара");
                    return;
                }
            }

            int index = selectedDetails.FindIndex(d => d.ProductId == productId);
            if (index >= 0)
            {
                selectedDetails[index] = (productId, productName, quantity, price);
                foreach (DataGridViewRow row in dgvSelectedProduct.Rows)
                {
                    if ((int)row.Cells["ProductId"].Value == productId)
                    {
                        row.Cells["Quantity"].Value = quantity;
                        row.Cells["Price"].Value = price;
                        row.Cells["TotalPrice"].Value = price * quantity;
                        break;
                    }
                }
            }
            else
            {
                selectedDetails.Add((productId, productName, quantity, price));
                dgvSelectedProduct.Rows.Add(productId, productName, quantity, price, price * quantity);
            }
            CalculateTotalCost();
        }

        private void btnRemoveProduct_Click(object sender, EventArgs e)
        {
            if (dgvSelectedProduct.SelectedRows.Count > 0)
            {
                var row = dgvSelectedProduct.SelectedRows[0];
                int productId = (int)row.Cells["ProductId"].Value;
                selectedDetails.RemoveAll(d => d.ProductId == productId);
                dgvSelectedProduct.Rows.Remove(row);
                CalculateTotalCost();
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления");
            }
        }

        private void buttonCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            int orderId;
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string query;
                if (_orderId == 0)
                {
                    query = @"INSERT INTO Zakaz (id_user,delivery_address, order_date, status) VALUES (@id_user,@delivery_address, @order_date, @status); SELECT SCOPE_IDENTITY();";
                }
                else
                {
                    query = @"UPDATE Zakaz SET delivery_address=@delivery_address, order_date=@order_date, status=@status WHERE id_zakaz=@id";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_user", int.Parse(cmbCustomer.SelectedValue.ToString()));
                cmd.Parameters.AddWithValue("@delivery_address", AdresstextBox.Text);
                cmd.Parameters.AddWithValue("@order_date", dateTimePicker.Value);
                cmd.Parameters.AddWithValue("@status", StatustextBox.Text);

                if (_orderId > 0)
                    cmd.Parameters.AddWithValue("@id", _orderId);

                try
                {
                   conn.OpenAsync();
                    if (_orderId == 0)
                    {
                        var result = cmd.ExecuteScalarAsync();
                        _orderId = Convert.ToInt32(result);
                    }
                    else
                    {
                        cmd.ExecuteNonQueryAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка сохранения заказа: " + ex.Message);
                    return;
                }
            }
            SaveOrderDetails(_orderId);
            MessageBox.Show("Заказ успешно сохранен");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}