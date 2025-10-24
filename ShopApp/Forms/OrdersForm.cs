using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ShopApp.Forms
{
    public partial class OrdersForm : Form
    {
        public OrdersForm()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            string Selectq = "SELECT Z.[id_zakaz], U.[Login] AS [Пользователь], Z.delivery_address AS [Адрес], Z.order_date AS [Дата прибытия], Z.[status] AS [Статус доставки] FROM [Zakaz] Z  JOIN dbo.[User] U ON Z.id_user = U.id_user ";

            using (SqlConnection connection = new SqlConnection(Globals.connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(Selectq, connection);
                DataSet dataSet = new DataSet();

                try
                {
                    connection.Open();
                    adapter.Fill(dataSet, "Zakaz");
                    DGV.DataSource = dataSet.Tables["Zakaz"];
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
        private void EditButton_Click(object sender, System.EventArgs e)
        {
            if (DGV.CurrentRow == null)
            {
                MessageBox.Show("Выберите пользователя для редактирования");
                return;
            }
            int id = (int)DGV.CurrentRow.Cells["id_zakaz"].Value;

            var editForm = new EditForms.OrderEditForm(id);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void DeleteButton_Click(object sender, System.EventArgs e)
        {
            if (DGV.CurrentRow == null)
            {
                MessageBox.Show("Выберите заказ для удаления");
                return;
            }
            int id = (int)DGV.CurrentRow.Cells["id_zakaz"].Value;

            var result = MessageBox.Show("Удалить выбранный заказ?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(Globals.connectionString))
                {
                    string deleteZ = "DELETE FROM [Zakaz] WHERE id_zakaz = @id_zakaz";
                    string deletePZ = "DELETE FROM [Product_Zakaz] WHERE id_zakaz = @id_zakaz";
                    SqlCommand cmdZ = new SqlCommand(deleteZ, conn);
                    SqlCommand cmdPZ = new SqlCommand(deletePZ, conn);
                    cmdZ.Parameters.AddWithValue("@id_zakaz", id);
                    cmdPZ.Parameters.AddWithValue("@id_zakaz", id);
                    try
                    {
                        conn.Open();
                        cmdPZ.ExecuteNonQuery();
                        cmdZ.ExecuteNonQuery();
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка удаления: " + ex.Message);
                    }
                }
            }
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            var editForm = new EditForms.OrderEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
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
