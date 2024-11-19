using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RepairApp
{
    public partial class MasterForm : Form
    {
        private string connectionString = "Data Source=STEPANOVA;Integrated Security=True;MultipleActiveResultSets=True";
        private string userLogin;
        private string userFullName;

        public MasterForm(string login, string fullName)
        {
            InitializeComponent();
            userLogin = login;
            userFullName = fullName;

            // Отображаем ФИО сбоку
            label4.Text = userFullName;

            LoadRequests();
        }

        private int GetTotalRequestCount()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Requests";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Открываем форму авторизации
            AuthForm authForm = new AuthForm();
            authForm.Show();

            // Закрываем текущую форму
            Close();
        }

        private void LoadRequests()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT r.RequestID, r.StartDate, r.ProblemDescription, r.Price, 
                   ht.HomeTechType, ht.HomeTechModel, 
                   s.Status AS StatusName, r.StatusID,
                   c.CommentText AS MasterComment -- Комментарий мастера к заявке
            FROM Requests r
            JOIN HomeTech ht ON r.HomeTechID = ht.HomeTechID
            JOIN Statuses s ON r.StatusID = s.StatusID
            LEFT JOIN Comments c ON c.RequestID = r.RequestID 
                AND c.OperatorID IS NULL -- Берем только комментарии мастера
            WHERE r.MasterID = (SELECT UserID FROM Users WHERE Login = @login)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", userLogin);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    requestsDataGridView.DataSource = dt;

                    // Настройка видимости и заголовков столбцов
                    requestsDataGridView.Columns["RequestID"].Visible = false; // Скрываем ID заявки
                    requestsDataGridView.Columns["StatusID"].Visible = false; // Скрываем ID статуса
                    requestsDataGridView.Columns["StartDate"].HeaderText = "Дата начала";
                    requestsDataGridView.Columns["ProblemDescription"].HeaderText = "Описание проблемы";
                    requestsDataGridView.Columns["Price"].HeaderText = "Стоимость";
                    requestsDataGridView.Columns["HomeTechType"].HeaderText = "Тип техники";
                    requestsDataGridView.Columns["HomeTechModel"].HeaderText = "Модель техники";
                    requestsDataGridView.Columns["StatusName"].HeaderText = "Статус";
                    requestsDataGridView.Columns["MasterComment"].HeaderText = "Комментарий мастера";
                }
            }
        }



        private void addCommentButton_Click(object sender, EventArgs e)
        {
            if (requestsDataGridView.SelectedRows.Count > 0)
            {
                int selectedRow = requestsDataGridView.SelectedRows[0].Index;
                int requestID = (int)requestsDataGridView.Rows[selectedRow].Cells["RequestID"].Value;

                string commentText = commentTextBox.Text;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Указываем OperatorID = NULL для комментариев мастера
                    string query = "INSERT INTO Comments (CommentText, RequestID, OperatorID) VALUES (@commentText, @requestID, NULL)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@commentText", commentText);
                        cmd.Parameters.AddWithValue("@requestID", requestID);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Комментарий добавлен.");
                commentTextBox.Clear();
                LoadRequests(); // Обновляем данные, чтобы показать новый комментарий
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для добавления комментария.");
            }
        }




        private void completeRequestButton_Click(object sender, EventArgs e)
        {
            if (requestsDataGridView.SelectedRows.Count > 0)
            {
                int selectedRow = requestsDataGridView.SelectedRows[0].Index;
                int requestID = (int)requestsDataGridView.Rows[selectedRow].Cells["RequestID"].Value;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Requests SET StatusID = 3 WHERE RequestID = @requestID"; // 3 – это ID статуса "Завершена"
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@requestID", requestID);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Статус заявки изменен на 'Завершена'.");
                LoadRequests(); // Перезагружаем данные, чтобы обновить статус в DataGridView
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для завершения.");
            }
        }
    }
}
