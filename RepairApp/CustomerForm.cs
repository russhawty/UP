using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RepairApp
{
    public partial class CustomerForm : Form
    {
        private string connectionString = "Data Source=STEPANOVA;Integrated Security=True;MultipleActiveResultSets=True";
        private string userLogin;
        private string userFullName;

        public CustomerForm(string login, string fullName)
        {
            userLogin = login;
            InitializeComponent();
            LoadRequests();
            userLogin = login;
            userFullName = fullName;
            // Отображаем ФИО сбоку
            label4.Text = userFullName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Открываем форму авторизации
            AuthForm authForm = new AuthForm();
            authForm.Show();

            // Закрываем текущую форму
            this.Close();
        }
        private void LoadRequests()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT r.RequestID, 
                                        ht.HomeTechType, 
                                        ht.HomeTechModel, 
                                        r.ProblemDescription, 
                                        s.Status 
                                 FROM Requests r
                                 JOIN HomeTech ht ON r.HomeTechID = ht.HomeTechID
                                 JOIN Statuses s ON r.StatusID = s.StatusID
                                 WHERE r.CustomerID = (SELECT UserID FROM Users WHERE Login = @login)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", userLogin);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    requestsListBox.Items.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        string itemText = $"{row["HomeTechType"]} {row["HomeTechModel"]}: {row["ProblemDescription"]} - {row["Status"]}";
                        requestsListBox.Items.Add(new ListItem { RequestID = (int)row["RequestID"], DisplayText = itemText });
                    }
                }
            }
        }

        private void createRequestButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Получаем StatusID для статуса "Новая заявка"
                int statusID = GetStatusID("Новая заявка");

                string query = "INSERT INTO Requests (ProblemDescription, CustomerID, HomeTechID, StatusID) VALUES (@desc, @customerID, @homeTechID, @statusID)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@desc", problemDescriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("@customerID", GetCustomerID(userLogin));
                    cmd.Parameters.AddWithValue("@homeTechID", GetHomeTechID(techTypeTextBox.Text, modelTextBox.Text));
                    cmd.Parameters.AddWithValue("@statusID", statusID);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadRequests();
        }

        private int GetStatusID(string statusName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT StatusID FROM Statuses WHERE Status = @statusName";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@statusName", statusName);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return (int)result;
                    }
                    else
                    {
                        throw new Exception($"Статус '{statusName}' не найден в базе данных.");
                    }
                }
            }
        }

        private void deleteRequestButton_Click(object sender, EventArgs e)
        {
            if (requestsListBox.SelectedItem != null)
            {
                var selectedItem = (ListItem)requestsListBox.SelectedItem;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Requests WHERE RequestID = @requestID AND StatusID = (SELECT StatusID FROM Statuses WHERE Status = 'Новая заявка')";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@requestID", selectedItem.RequestID);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadRequests();
            }
        }

        private int GetCustomerID(string login)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UserID FROM Users WHERE Login = @login";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        private int GetHomeTechID(string techType, string techModel)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT HomeTechID FROM HomeTech WHERE HomeTechType = @techType AND HomeTechModel = @techModel";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@techType", techType);
                    cmd.Parameters.AddWithValue("@techModel", techModel);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return (int)result;
                    }
                    else
                    {
                        query = "INSERT INTO HomeTech (HomeTechType, HomeTechModel) VALUES (@techType, @techModel); SELECT SCOPE_IDENTITY();";
                        cmd.CommandText = query;
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
        }

        // Вспомогательный класс для хранения ID заявки и отображаемого текста
        private class ListItem
        {
            public int RequestID { get; set; }
            public string DisplayText { get; set; }

            public override string ToString()
            {
                return DisplayText;
            }
        }
    }
}
