using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp.EditForms
{
    public partial class ProductEditForm : Form
    {
        private int _productId;
        public ProductEditForm(int productId = 0)
        {
            InitializeComponent();
            _productId = productId;
            LoadSizes();

            if (productId > 0)
            {
                LoadProductData();
                this.Text = "Редактировать товар";
            }
            else
            {
                this.Text = "Добавить товар";
            }

        }

        private void LoadSizes() {

            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string queryS = "SELECT id_Size_Product, size_name FROM Size_Product";
                string queryT = "SELECT id_ProductType, type_name FROM ProductType";
                SqlDataAdapter dS = new SqlDataAdapter(queryS, conn);
                SqlDataAdapter dT = new SqlDataAdapter(queryT, conn);
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                try
                {
                    conn.Open();
                    dS.Fill(dt1);
                    SizeProductcmb.DataSource = dt1;
                    SizeProductcmb.DisplayMember = "size_name";
                    SizeProductcmb.ValueMember = "id_Size_Product";
                    dT.Fill(dt2);
                    TypeProductcmb.DataSource = dt2;
                    TypeProductcmb.DisplayMember = "type_name";
                    TypeProductcmb.ValueMember = "id_ProductType";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки мастерских: " + ex.Message);
                }
            }
        }

        private void LoadProductData()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string query = "SELECT Name, Price, id_Size_Product, id_ProductType, Description, Photo FROM [Product] WHERE id_product = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _productId);
                    byte[] photoBytes = null;

                    try
                    {
                        conn.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ProductNametextBox.Text = reader["Name"].ToString();
                                ProductPricetextBox.Text = reader["Price"].ToString();
                                SizeProductcmb.SelectedValue = reader["id_Size_Product"] != DBNull.Value ? (int)reader["id_Size_Product"] : 0;
                                TypeProductcmb.SelectedValue = reader["id_ProductType"] != DBNull.Value ? (int)reader["id_ProductType"] : 0;
                                DescProducttextBox.Text = reader["Description"].ToString();

                                if (!reader.IsDBNull(reader.GetOrdinal("Photo")))
                                {
                                    photoBytes = (byte[])reader["Photo"];
                                }
                            }
                        }

                        Image productImage = null;
                        if (photoBytes != null && photoBytes.Length > 0)
                        {
                            using (var ms = new System.IO.MemoryStream(photoBytes))
                            {
                                productImage = Image.FromStream(ms);
                            }
                        }

                        if (productImage != null)
                        {
                            ProductpictureBox.Image = productImage;
                        }
                        else
                        {
                            ProductpictureBox.Image = Properties.Resources.Computer_nerd_1536x1054;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка загрузки данных продукта: " + ex.Message);
                    }
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            byte[] photoBytes = null;
            if (ProductpictureBox.Image != null)
            {
                using (var ms = new System.IO.MemoryStream())
                {
                    ProductpictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    photoBytes = ms.ToArray();
                }
            }

            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string query;
                if (_productId > 0)
                {
                    query = @"UPDATE [Product] SET 
                        Name = @Name,
                        Price = @Price,
                        id_Size_Product = @SizeId,
                        id_ProductType = @TypeId,
                        Description = @Description,
                        Photo = @Photo
                      WHERE id_product = @id";
                }
                else
                {
                    query = @"INSERT INTO [Product] 
                        (Name, Price, id_Size_Product, id_ProductType, Description, Photo)
                      VALUES
                        (@Name, @Price, @SizeId, @TypeId, @Description, @Photo)";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", ProductNametextBox.Text);
                    cmd.Parameters.AddWithValue("@Price", Double.Parse(ProductPricetextBox.Text));
                    cmd.Parameters.AddWithValue("@SizeId", SizeProductcmb.SelectedValue);
                    cmd.Parameters.AddWithValue("@TypeId", TypeProductcmb.SelectedValue);
                    cmd.Parameters.AddWithValue("@Description", DescProducttextBox.Text);
                    if (photoBytes != null)
                        cmd.Parameters.AddWithValue("@Photo", photoBytes);
                    else
                        cmd.Parameters.AddWithValue("@Photo", DBNull.Value);

                    if (conn.State != ConnectionState.Open)
                        conn.Open();

                    if (_productId > 0)
                    {
                        cmd.Parameters.AddWithValue("@id", _productId);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Товар успешно создан!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoadPhotoBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Выберите изображение";
                openFileDialog.Filter = "Изображения (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image selectedImage = Image.FromFile(openFileDialog.FileName);
                        ProductpictureBox.Image = selectedImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
                    }
                }
            }
        }

        
    }
}
