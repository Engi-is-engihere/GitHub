using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ShopApp
{
    public partial class RegisterForm : Form
    {
        Pen RedPen = new Pen(Color.Red);
        Pen GrayPen = new Pen(Color.Gray);
        int variance = 3;
        public RegisterForm()
        {
            InitializeComponent();
            Pen p = new Pen(Color.Red);

        }
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            LogintextBox.Text = "Email/phone";
            LogintextBox.ForeColor = Color.Gray;
            PasswordtextBox.Text = "Password";
            PasswordtextBox.ForeColor = Color.Gray;
            PasswordtextBox2.Text = "Password";
            PasswordtextBox2.ForeColor = Color.Gray;
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

        private void PasswordtextBox2_Enter(object sender, EventArgs e)
        {
            if (PasswordtextBox2.Text == "Password")
            {
                PasswordtextBox2.Text = "";
                PasswordtextBox2.ForeColor = Color.Gray;
            }
        }

        private void PasswordtextBox2_Leave(object sender, EventArgs e)
        {
            if (PasswordtextBox2.Text == "")
            {
                PasswordtextBox2.Text = "Password";
                PasswordtextBox2.ForeColor = Color.Gray;
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(Globals.connectionString);
            string Insertq = "INSERT INTO dbo.[User] ([Login], [password], [id_Role]) VALUES (@Login, @password, @id_Role); SELECT SCOPE_IDENTITY();";
            string InsertqB = "INSERT INTO Basket (id_user) VALUES (@id_user)";
            string Selectq = "SELECT COUNT(id_user) FROM dbo.[User] Where [login] = @login";
            SqlCommand Icmd = new SqlCommand(Insertq, connection);
            SqlCommand Scmd = new SqlCommand(Selectq, connection);
            SqlCommand IBcmd = new SqlCommand(InsertqB, connection);
            connection.Open();
            Scmd.Parameters.Add("@login", LogintextBox.Text);
            if (PasswordtextBox.Text.Length >= 8)
            {


                if (int.Parse(Scmd.ExecuteScalar().ToString()) > 0)
                {
                    connection.Close();

                    Graphics g = this.CreateGraphics();
                    LogintextBox.BorderStyle = BorderStyle.None;
                    g.DrawRectangle(RedPen, new Rectangle(LogintextBox.Location.X - variance, LogintextBox.Location.Y - variance, LogintextBox.Width + variance, LogintextBox.Height + variance));
                    LogintextBox.ForeColor = Color.Red;
                    ErrorLabel.Text = "Логин занят";

                }
                else if (PasswordtextBox.Text != PasswordtextBox2.Text)
                {
                    connection.Close();

                    Graphics g = this.CreateGraphics();
                    LogintextBox.BorderStyle = BorderStyle.None;
                    g.DrawRectangle(GrayPen, new Rectangle(LogintextBox.Location.X - variance, LogintextBox.Location.Y - variance, LogintextBox.Width + variance, LogintextBox.Height + variance));
                    LogintextBox.ForeColor = Color.Gray;

                    PasswordtextBox.BorderStyle = BorderStyle.None;
                    g.DrawRectangle(RedPen, new Rectangle(PasswordtextBox.Location.X - variance, PasswordtextBox.Location.Y - variance, PasswordtextBox.Width + variance, PasswordtextBox.Height + variance));
                    PasswordtextBox.ForeColor = Color.Red;

                    PasswordtextBox2.BorderStyle = BorderStyle.None;
                    g.DrawRectangle(RedPen, new Rectangle(PasswordtextBox2.Location.X - variance, PasswordtextBox2.Location.Y - variance, PasswordtextBox2.Width + variance, PasswordtextBox2.Height + variance));
                    PasswordtextBox2.ForeColor = Color.Red;
                    ErrorLabel.Text = "Пароли не совпадают";
                }
                else
                {
                    Icmd.Parameters.Add("@Login", LogintextBox.Text);
                    Icmd.Parameters.Add("@password", PasswordtextBox.Text);
                    Icmd.Parameters.Add("@id_Role", 1);
                    int id_user = int.Parse(Icmd.ExecuteScalar().ToString());
                    IBcmd.Parameters.Add("@id_user", id_user);
                    IBcmd.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                }
            }
            else {
                ErrorLabel.Text = "Минимальная длина пароля 8 символов";
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
