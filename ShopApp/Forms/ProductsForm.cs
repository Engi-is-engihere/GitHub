using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ShopApp.Forms
{
    public partial class ProductsForm : Form
    {
        public ProductsForm()
        {

            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            string Selectq = "Select P.[id_Product], P.[Name] AS [Название], P.[Price] AS [Цена], SP.[size_name] AS [Размер], TP.[type_name] AS [Тип] FROM [Product] P JOIN Size_Product SP ON P.id_Size_Product = SP.id_Size_Product JOIN ProductType TP ON P.id_ProductType = TP.id_ProductType";

            using (SqlConnection connection = new SqlConnection(Globals.connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(Selectq, connection);
                DataSet dataSet = new DataSet();

                try
                {
                    connection.Open();
                    adapter.Fill(dataSet, "Product");
                    DGV.DataSource = dataSet.Tables["Product"];
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
                MessageBox.Show("Выберите товар для редактирования");
                return;
            }
            int id = (int)DGV.CurrentRow.Cells["id_product"].Value;

            var editForm = new EditForms.ProductEditForm(id);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (DGV.CurrentRow == null)
            {
                MessageBox.Show("Выберите товар для удаления");
                return;
            }
            int id = (int)DGV.CurrentRow.Cells["id_product"].Value;

            var result = MessageBox.Show("Удалить выбранный товар?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(Globals.connectionString))
                {
                    string selectRevIdQuery = "SELECT TOP 1 id_review FROM [Product_Review] WHERE id_product = @id_product";
                    string deleteProdRevQuery = "DELETE FROM [Product_Review] WHERE id_product = @id_product";
                    string deleteProdQuery = "DELETE FROM [Product] WHERE id_product = @id_product";
                    string deleteReviewQuery = "DELETE FROM [Review] WHERE id_review = @id_review";

                    try
                    {
                        conn.Open();

                        int idReview = 0;

                        using (SqlCommand cmdSelectRev = new SqlCommand(selectRevIdQuery, conn))
                        {
                            cmdSelectRev.Parameters.AddWithValue("@id_product", id);
                            object res = cmdSelectRev.ExecuteScalar();
                            if (res != null && res != DBNull.Value)
                            {
                                idReview = Convert.ToInt32(res);
                            }
                        }

                        using (SqlCommand cmdDeleteProdRev = new SqlCommand(deleteProdRevQuery, conn))
                        {
                            cmdDeleteProdRev.Parameters.AddWithValue("@id_product", id);
                            cmdDeleteProdRev.ExecuteNonQuery();
                        }

                        using (SqlCommand cmdDeleteProd = new SqlCommand(deleteProdQuery, conn))
                        {
                            cmdDeleteProd.Parameters.AddWithValue("@id_product", id);
                            cmdDeleteProd.ExecuteNonQuery();
                        }

                        if (idReview > 0)
                        {
                            using (SqlCommand cmdDeleteReview = new SqlCommand(deleteReviewQuery, conn))
                            {
                                cmdDeleteReview.Parameters.AddWithValue("@id_review", idReview);
                                cmdDeleteReview.ExecuteNonQuery();
                            }
                        }

                        LoadData(); 
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
            var editForm = new EditForms.ProductEditForm();
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
