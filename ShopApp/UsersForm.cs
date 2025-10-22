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
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            string Selectq = "SELECT \r\n    U.id_user AS [ID],\r\n    U.Login AS [Логин],\r\n    U.password AS [Пароль],\r\n    R.RoleName AS [Роль]\r\nFROM [User] U\r\nJOIN dbo.Roles R ON U.id_Role = R.id_Role;";

            using (SqlConnection connection = new SqlConnection(Globals.connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(Selectq, connection);
                DataSet dataSet = new DataSet();

                try
                {
                    connection.Open();
                    adapter.Fill(dataSet, "User");
                    DGV.DataSource = dataSet.Tables["User"];
                    DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    DGV.Refresh();
                    DGV.Columns[0].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void EditButton_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void ExportButton_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                LoadData();
                return;
            }

            DataTable dt = ((DataTable)DGV.DataSource);
            if (dt == null)
                return;

            var filterParts = new List<string>();

            foreach (DataColumn col in dt.Columns)
            {
                string columnName = col.ColumnName;

                filterParts.Add($"Convert([{columnName}], System.String) LIKE '%{searchText}%'");
            }

            string filterString = string.Join(" OR ", filterParts);

            DataView dv = dt.DefaultView;
            dv.RowFilter = filterString;
        }
    }
}
