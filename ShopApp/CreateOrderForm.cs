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
    public partial class CreateOrderForm : Form
    {
        private int idProduct;

        public CreateOrderForm(int id_product)
        {
            InitializeComponent();
            idProduct = id_product;
       
            
        }

        

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CountProductNumeric.Value != 0 && textBoxAdres.Text.Trim().Length != 0 && CountProductNumeric.Value > 0)
            {
                string InsertqZ = "Insert INTO Zakaz ([id_user],[order_date],[status]) Values (@id_user, @order_date, @status);SELECT SCOPE_IDENTITY();";

                string InsertqPZ = "INSERT INTO Product_Zakaz (id_product, id_zakaz, quantity) VALUES (@id_product, @id_zakaz, @quantity)";

                SqlConnection connection = new SqlConnection(Globals.connectionString);
                SqlCommand cmdZ = new SqlCommand(InsertqZ, connection);
                cmdZ.Parameters.Add("@id_user", Globals.id_user);
                cmdZ.Parameters.Add("@order_date", DateTime.Now);
                cmdZ.Parameters.Add("@status", "Оформлен");

                connection.Open();

                int idZakaz = Convert.ToInt32(cmdZ.ExecuteScalar());

                SqlCommand cmdZP = new SqlCommand(InsertqPZ, connection);
                cmdZP.Parameters.Add("@id_product", idProduct);
                cmdZP.Parameters.Add("@id_zakaz", idZakaz);
                cmdZP.Parameters.Add("@quantity", CountProductNumeric.Value);
               
                cmdZP.ExecuteNonQuery();

                connection.Close();
                this.Close();
            }
            else {
                errorlabel.Text = "Введите все данные";
            }

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
