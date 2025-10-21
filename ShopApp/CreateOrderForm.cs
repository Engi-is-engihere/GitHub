using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp
{
    public partial class CreateOrderForm : Form
    {
        public CreateOrderForm(int id_user, int id_product)
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string InsertqZ = "Insert INTO Zakaz ([id_user],[order_date],[status]) Values (@id_user, @order_date, @status)";
            
            string InsertqPZ = "INSERT INTO Product_Zakaz (id_product, id_zakaz, quantity) VALUES (@id_product, @id_zakaz, @quantity)";

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
