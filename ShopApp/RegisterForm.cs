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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
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
                LogintextBox.ForeColor = Color.Black;
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
            if (LogintextBox.Text == "Email/phone")
            {
                LogintextBox.Text = "";
                LogintextBox.ForeColor = Color.Black;
            }
        }

        private void PasswordtextBox_Leave(object sender, EventArgs e)
        {
            if (LogintextBox.Text == "")
            {
                LogintextBox.Text = "Email/phone";
                LogintextBox.ForeColor = Color.Gray;
            }
        }

        private void PasswordtextBox2_Enter(object sender, EventArgs e)
        {
            if (LogintextBox.Text == "Email/phone")
            {
                LogintextBox.Text = "";
                LogintextBox.ForeColor = Color.Black;
            }
        }

        private void PasswordtextBox2_Leave(object sender, EventArgs e)
        {
            if (LogintextBox.Text == "")
            {
                LogintextBox.Text = "Email/phone";
                LogintextBox.ForeColor = Color.Gray;
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (true)
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

                PasswordtextBox2.BorderStyle = BorderStyle.None;
                g.DrawRectangle(p, new Rectangle(PasswordtextBox2.Location.X - variance, PasswordtextBox2.Location.Y - variance, PasswordtextBox2.Width + variance, PasswordtextBox2.Height + variance));
                PasswordtextBox2.ForeColor = Color.Red;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
