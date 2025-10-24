using System;
using System.Windows.Forms;

namespace ShopApp
{
    public partial class AdminForm : Form
    {
        private Form activeform;
        public AdminForm()
        {
            InitializeComponent();
        }
        private void OpenChildForm(Form childForm, object btnsender)
        {
            if (activeform != null)
            {
                activeform.Close();
            }

            activeform = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.PanelDesktopPane.Controls.Add(childForm);
            this.PanelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.UsersForm(), sender);
        }

        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.OrdersForm(), sender);
        }

        private void товарыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ProductsForm(), sender);
        }
    }
}
