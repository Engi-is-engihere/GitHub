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

namespace ShopApp
{
    public partial class ProductDetailForm : Form
    {
        private int _id_product;
        public ProductDetailForm(int id_product)
        {
            InitializeComponent();
            _id_product = id_product;
            LoadProductData();
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
        private void LoadProductData()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string query = "SELECT P.[Name], P.[Price], SP.[size_name], PT.[type_name], P.[Description], P.[Photo] FROM [Product] P JOIN Size_Product SP ON SP.id_Size_Product  = p.id_Size_Product JOIN ProductType PT ON PT.id_ProductType = P.id_ProductType WHERE id_product = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", _id_product);
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
                                ProductSizetextBox.Text = reader["size_name"].ToString();
                                ProductTypetextBox.Text = reader["type_name"].ToString();
                                DescProductextBox.Text = reader["Description"].ToString();

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
                            ProductpictureBox.Image = LoadDefaultImage();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка загрузки данных продукта: " + ex.Message);
                    }
                }
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CreateOrderForm createOrderForm = new CreateOrderForm(_id_product);
            createOrderForm.ShowDialog();
        }

       
    }
}
