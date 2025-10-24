using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ShopApp.EditForms
{
    public partial class UserEditForm : Form
    {
        private int _userId;
        public UserEditForm(int userId = 0)
        {
            InitializeComponent();
            _userId = userId;

            LoadRoles();

            if (userId > 0)
            {
                LoadUserData();
                this.Text = "Редактировать пользователя";
            }
            else
            {
                this.Text = "Добавить пользователя";
            }
        }

        private void LoadRoles()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string query = "SELECT id_Role, RoleName FROM Roles";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    da.Fill(dt);
                    cmbRole.DataSource = dt;
                    cmbRole.DisplayMember = "RoleName";
                    cmbRole.ValueMember = "id_Role";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки мастерских: " + ex.Message);
                }
            }
        }
        private void LoadUserData()
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string query = "SELECT * FROM [User] WHERE id_user = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", _userId);
                try
                {
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        LogintextBox.Text = reader["Login"].ToString();
                        PasswordtextBox.Text = reader["password"].ToString();
                        cmbRole.SelectedValue = reader["id_Role"] != DBNull.Value ? (int)reader["id_Role"] : 0;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки данных сотрудника: " + ex.Message);
                }
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Globals.connectionString))
            {
                string query;
                if (_userId == 0)
                {
                    query = @"INSERT INTO [User] (Login,password, id_Role)
                          VALUES (@Login, @password, @id_Role)";
                }
                else
                {
                    query = @"UPDATE [User] SET Login=@Login, password=@password, id_Role=@id_Role WHERE id_user = @Id";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Login", LogintextBox.Text);
                cmd.Parameters.AddWithValue("@password", PasswordtextBox.Text);
                cmd.Parameters.AddWithValue("@id_Role", (int)cmbRole.SelectedValue);

                if (_userId > 0)
                    cmd.Parameters.AddWithValue("@Id", _userId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные сохранены");
                    conn.Close();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка сохранения: " + ex.Message);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
