using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ShopApp.Forms
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
            string Selectq = "SELECT U.id_user AS [id_user], U.Login AS [Логин],U.password AS [Пароль], R.RoleName AS [Роль] FROM [User] U JOIN dbo.Roles R ON U.id_Role = R.id_Role;";

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
       

        private void EditButton_Click(object sender, EventArgs e)
        {

            if (DGV.CurrentRow == null)
            {
                MessageBox.Show("Выберите пользователя для редактирования");
                return;
            }
            int id = (int)DGV.CurrentRow.Cells["id_user"].Value;

            var editForm = new EditForms.UserEditForm(id);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DGV.CurrentRow == null)
            {
                MessageBox.Show("Выберите сотрудника для удаления");
                return;
            }
            int id = (int)DGV.CurrentRow.Cells["id_user"].Value;

            var result = MessageBox.Show("Удалить выбранного пользователя?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(Globals.connectionString))
                {
                    string deleteQueryB = "DELETE FROM [Basket] WHERE id_user = @id_user";
                    string deleteQueryU = "DELETE FROM [User] WHERE id_user = @id_user";

                    SqlCommand cmdB = new SqlCommand(deleteQueryB, conn);
                    SqlCommand cmdU = new SqlCommand(deleteQueryU, conn);

                    cmdB.Parameters.AddWithValue("@id_user", id);
                    try
                    {
                        conn.Open();
                        cmdB.ExecuteNonQuery();
                        LoadData();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка удаления: " + ex.Message);
                    }
                    cmdU.Parameters.AddWithValue("@id_user", id);
                    try
                    {
                        conn.Open();
                        cmdU.ExecuteNonQuery();
                        LoadData();
                        conn.Close ();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка удаления: " + ex.Message);
                    }
                }
            }
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            var editForm = new EditForms.UserEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
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
