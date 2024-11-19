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
namespace RepairApp
{
    public partial class OperatorForm : Form
    {
        private string connectionString = "Data Source=STEPANOVA;Integrated Security=True;MultipleActiveResultSets=True";
        private DataTable requestsDataTable;
        private string lastSortedColumn = "";
        private bool sortAscending = true;
        private string userLogin;
        private string userFullName;

        public OperatorForm(string login, string fullName)
        {
            InitializeComponent();
            LoadRequests();
            LoadMasters();
            LoadStatuses();
            userLogin = login;
            userFullName = fullName;
            requestsDataGridView.ColumnHeaderMouseClick += requestsDataGridView_ColumnHeaderMouseClick;
            // Отображаем ФИО сбоку
            label6.Text = userFullName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Открываем форму авторизации
            AuthForm authForm = new AuthForm();
            authForm.Show();

            // Закрываем текущую форму
            this.Close();
        }

        private void LoadMasters()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UserID, FIO FROM Users WHERE UserType = 'Мастер'";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable mastersTable = new DataTable();
                    da.Fill(mastersTable);
                    masterComboBox.DataSource = mastersTable;
                    masterComboBox.DisplayMember = "FIO";
                    masterComboBox.ValueMember = "UserID";
                }
            }
        }


        private void LoadRequests()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT r.RequestID, r.StartDate, r.ProblemDescription, r.Price, r.Report, 
                   u.FIO AS CustomerName, u.UserID AS CustomerID,
                   ht.HomeTechType, ht.HomeTechModel, 
                   s.Status AS StatusName, r.StatusID, r.HomeTechID,
                   m.FIO AS MasterName, -- Информация о мастере
                   c.CommentText AS MasterComment -- Комментарий мастера к заявке
            FROM Requests r
            JOIN Users u ON r.CustomerID = u.UserID
            JOIN HomeTech ht ON r.HomeTechID = ht.HomeTechID
            JOIN Statuses s ON r.StatusID = s.StatusID
            LEFT JOIN Users m ON r.MasterID = m.UserID
            LEFT JOIN Comments c ON c.RequestID = r.RequestID 
                AND c.OperatorID IS NULL"; // Берем комментарий, оставленный мастером

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    requestsDataTable = new DataTable();
                    da.Fill(requestsDataTable);

                    requestsDataGridView.AutoGenerateColumns = true;
                    requestsDataGridView.DataSource = requestsDataTable;

                    // Настраиваем заголовки столбцов
                    if (requestsDataGridView.Columns["RequestID"] != null)
                    {
                        requestsDataGridView.Columns["RequestID"].Visible = false;
                    }
                    requestsDataGridView.Columns["MasterComment"].HeaderText = "Комментарий мастера";
                    requestsDataGridView.Columns["StatusName"].HeaderText = "Статус";
                }
            }
        }






        private void deleteRequestButton_Click(object sender, EventArgs e)
        {
            // Проверяем, что выбрана хотя бы одна строка
            if (requestsDataGridView.SelectedRows.Count > 0)
            {
                // Извлекаем RequestID из выбранной строки
                DataGridViewRow selectedRow = requestsDataGridView.SelectedRows[0];

                // Проверяем, что в строке есть ячейка с RequestID и она не пуста
                if (selectedRow.Cells["RequestID"].Value != null)
                {
                    int requestID = (int)selectedRow.Cells["RequestID"].Value;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Requests WHERE RequestID = @requestID";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@requestID", requestID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadRequests();
                    MessageBox.Show("Заявка удалена.");
                }
                else
                {
                    MessageBox.Show("Не удалось получить RequestID. Пожалуйста, попробуйте снова.");
                }
            }
            else
            {
                MessageBox.Show("Выберите заявку для удаления.");
            }
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

        private void requestsDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = requestsDataGridView.Columns[e.ColumnIndex].Name;

            if (lastSortedColumn == columnName)
            {
                sortAscending = !sortAscending;
            }
            else
            {
                sortAscending = true;
            }

            lastSortedColumn = columnName;
            SortRequestsByColumn(columnName, sortAscending);
        }

        private void SortRequestsByColumn(string columnName, bool ascending)
        {
            DataView dataView = requestsDataTable.DefaultView;
            dataView.Sort = columnName + (ascending ? " ASC" : " DESC");
            requestsDataGridView.DataSource = dataView.ToTable();
        }

        private void LoadStatuses()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT StatusID, Status FROM Statuses";
                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    DataTable statusesTable = new DataTable();
                    da.Fill(statusesTable);
                    statusComboBox.DataSource = statusesTable;
                    statusComboBox.DisplayMember = "Status";
                    statusComboBox.ValueMember = "StatusID";
                }
            }
        }




        private void updateStatusButton_Click(object sender, EventArgs e)
        {
            if (requestsDataGridView.SelectedRows.Count > 0 && statusComboBox.SelectedValue != null)
            {
                int requestID = (int)requestsDataGridView.SelectedRows[0].Cells["RequestID"].Value;
                int newStatusID = (int)statusComboBox.SelectedValue;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Requests SET StatusID = @statusID WHERE RequestID = @requestID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@statusID", newStatusID);
                        cmd.Parameters.AddWithValue("@requestID", requestID);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Статус заявки обновлен.");
                LoadRequests();
            }
            else
            {
                MessageBox.Show("Выберите заявку и новый статус.");
            }
        }


        private void viewLoginHistoryButton_Click(object sender, EventArgs e)
        {
            LoginHistoryForm historyForm = new LoginHistoryForm(this);
            this.Hide(); // Скрываем текущую форму оператора
            historyForm.Show();
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Завершаем редактирование в DataGridView
                requestsDataGridView.EndEdit();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataRow row in requestsDataTable.Rows)
                    {
                        if (row.RowState == DataRowState.Modified)
                        {
                            // Обновляем данные в таблице Requests
                            string updateRequestQuery = "UPDATE Requests SET StatusID = @statusID, Price = @price, Report = @report WHERE RequestID = @requestID";
                            using (SqlCommand cmd = new SqlCommand(updateRequestQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@statusID", row["StatusID"]);
                                cmd.Parameters.AddWithValue("@price", row["Price"]);
                                cmd.Parameters.AddWithValue("@report", row["Report"]);
                                cmd.Parameters.AddWithValue("@requestID", row["RequestID"]);
                                cmd.ExecuteNonQuery();
                            }

                            // Если у тебя есть колонки из других таблиц, например, Users (например, поле CustomerName)
                            if (row["CustomerName"] != DBNull.Value)
                            {
                                string updateUserQuery = "UPDATE Users SET FIO = @fio WHERE UserID = @customerID";
                                using (SqlCommand cmd = new SqlCommand(updateUserQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@fio", row["CustomerName"]);
                                    cmd.Parameters.AddWithValue("@customerID", row["CustomerID"]);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // Аналогично обновляем данные из других связанных таблиц
                            // Например, обновление HomeTech, если есть изменения в HomeTechType или HomeTechModel
                            if (row["HomeTechType"] != DBNull.Value || row["HomeTechModel"] != DBNull.Value)
                            {
                                string updateHomeTechQuery = "UPDATE HomeTech SET HomeTechType = @techType, HomeTechModel = @techModel WHERE HomeTechID = @homeTechID";
                                using (SqlCommand cmd = new SqlCommand(updateHomeTechQuery, conn))
                                {
                                    cmd.Parameters.AddWithValue("@techType", row["HomeTechType"]);
                                    cmd.Parameters.AddWithValue("@techModel", row["HomeTechModel"]);
                                    cmd.Parameters.AddWithValue("@homeTechID", row["HomeTechID"]);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    MessageBox.Show("Изменения сохранены.");
                    requestsDataTable.AcceptChanges(); // Применяем изменения только после успешного выполнения
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message);
            }
        }


        private void assignMasterButton_Click(object sender, EventArgs e)
        {
            if (requestsDataGridView.SelectedRows.Count > 0 && masterComboBox.SelectedValue != null)
            {
                int requestID = (int)requestsDataGridView.SelectedRows[0].Cells["RequestID"].Value;
                int masterID = (int)masterComboBox.SelectedValue;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Проверяем, назначен ли уже мастер на эту заявку
                    string checkQuery = "SELECT MasterID FROM Requests WHERE RequestID = @requestID";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@requestID", requestID);
                        object existingMasterID = checkCmd.ExecuteScalar();

                        if (existingMasterID != DBNull.Value && existingMasterID != null)
                        {
                            DialogResult result = MessageBox.Show(
                                "Для этой заявки уже назначен мастер. Хотите заменить его?",
                                "Подтверждение",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );

                            if (result == DialogResult.No)
                            {
                                return; // Выход без переназначения
                            }
                        }
                    }

                    // Назначаем или переназначаем мастера
                    string updateQuery = "UPDATE Requests SET MasterID = @masterID WHERE RequestID = @requestID";
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@masterID", masterID);
                        cmd.Parameters.AddWithValue("@requestID", requestID);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Мастер назначен.");

                // Перезагрузка списка заявок для обновления данных в DataGridView
                LoadRequests();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку и мастера для назначения.");
            }
        }





    }

}
