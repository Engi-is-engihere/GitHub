using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ShopApp
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LogintextBox.Text = "Email/phone";
            LogintextBox.ForeColor = Color.Gray;
            PasswordtextBox.Text = "Password";
            PasswordtextBox.ForeColor = Color.Gray;
        }
        private void LogintextBox_Enter(object sender, EventArgs e)
        {
            if (LogintextBox.Text == "Email/phone")
            {
                LogintextBox.Text = "";
                LogintextBox.ForeColor = Color.Gray;
            }
        }
        private void LogintextBox_Leave(object sender, EventArgs e)
        {
            if (LogintextBox.Text == "")
            {
                LogintextBox.Text = "Email/phone";
                LogintextBox.ForeColor = Color.Gray;
            }
        }
        private void PasswordtextBox_Enter(object sender, EventArgs e)
        {
            if (PasswordtextBox.Text == "Password")
            {
                PasswordtextBox.Text = "";
                PasswordtextBox.ForeColor = Color.Gray;
            }
        }

        private void PasswordtextBox_Leave(object sender, EventArgs e)
        {
            if (PasswordtextBox.Text == "")
            {
                PasswordtextBox.Text = "Password";
                PasswordtextBox.ForeColor = Color.Gray;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(Globals.connectionString);
            string Selectq = "Select COUNT(id_user) FROM dbo.[User] Where [login] = @login and [password] = @password";
            string Selectid = "Select id_user FROM dbo.[User] Where [login] = @login and [password] = @password";
            string Selectrole = "Select id_Role From [User] Where [id_user] = @id_user";
            string selectIdBasket = "Select id_basket FROM Basket WHERE id_user = @id_user ";
           
            SqlCommand cmd = new SqlCommand(Selectq, connection);
            cmd.Parameters.Add(new SqlParameter("@login", LogintextBox.Text));
            cmd.Parameters.Add(new SqlParameter("@password", PasswordtextBox.Text));
            connection.Open();

            if (int.Parse(cmd.ExecuteScalar().ToString()) == 0)
            {
                LogintextBox.BorderStyle = BorderStyle.None;
                Pen p = new Pen(Color.Red);
                Graphics g = this.CreateGraphics();
                int variance = 3;
                g.DrawRectangle(p, new Rectangle(LogintextBox.Location.X - variance, LogintextBox.Location.Y - variance, LogintextBox.Width + variance, LogintextBox.Height + variance));
                LogintextBox.ForeColor = Color.Red;

                PasswordtextBox.BorderStyle = BorderStyle.None;
                g.DrawRectangle(p, new Rectangle(PasswordtextBox.Location.X - variance, PasswordtextBox.Location.Y - variance, PasswordtextBox.Width + variance, PasswordtextBox.Height + variance));
                PasswordtextBox.ForeColor = Color.Red;
                connection.Close();
            }
            else
            {
                SqlCommand cmdid = new SqlCommand(Selectid, connection);
                cmdid.Parameters.Add(new SqlParameter("@login", LogintextBox.Text));
                cmdid.Parameters.Add(new SqlParameter("@password", PasswordtextBox.Text));

                SqlDataReader sqlData = cmdid.ExecuteReader();
                sqlData.Read();
                Globals.id_user = sqlData.GetInt32(0);
                sqlData.Close();

                SqlCommand cmdroleId = new SqlCommand(Selectrole, connection);
                cmdroleId.Parameters.Add(new SqlParameter("@id_user", Globals.id_user));

                

                sqlData = cmdroleId.ExecuteReader();
                sqlData.Read();
                Globals.id_role = sqlData.GetInt32(0);
                sqlData.Close();

                SqlCommand cmdidBasket = new SqlCommand(selectIdBasket, connection);
                cmdidBasket.Parameters.Add(new SqlParameter("@id_user", Globals.id_user));
                sqlData = cmdidBasket.ExecuteReader();
                sqlData.Read();
                Globals.id_basket = sqlData.GetInt32(0);
                sqlData.Close();

                connection.Close();

                this.Hide();
                if (Globals.id_role == 1)
                {
                    ProductForm productForm = new ProductForm();
                    productForm.ShowDialog();
                    productForm.Close();
                }
                else if (Globals.id_role == 2)
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.ShowDialog();
                    adminForm.Close();
                }

                Show();
                LogintextBox.ForeColor = Color.Gray;
                PasswordtextBox.ForeColor = Color.Gray;
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            this.Hide();
            registerForm.ShowDialog();
            registerForm = null;
            Show();

        }


    }
}
