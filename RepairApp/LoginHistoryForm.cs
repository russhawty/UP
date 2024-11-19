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
    public partial class LoginHistoryForm : Form
    {
        private string connectionString = "Data Source=STEPANOVA;Integrated Security=True;MultipleActiveResultSets=True";
        private OperatorForm operatorForm;

        public LoginHistoryForm(OperatorForm parentForm)
        {
            InitializeComponent();
            LoadLoginHistory();
            operatorForm = parentForm;
           
        }

        private void LoadLoginHistory()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Запрос для получения истории входов с логином, временем и датой
                string query = @"
            SELECT 
                Login, 
                FORMAT(AttemptTime, 'HH:mm:ss') AS AttemptTime, -- Формат времени
                FORMAT(AttemptTime, 'yyyy-MM-dd') AS AttemptDate, -- Формат даты
                CASE 
                    WHEN Success = 1 THEN 'Успешно' 
                    ELSE 'Ошибка' 
                END AS Status -- Перевод статуса в текст
            FROM LoginHistory
            ORDER BY AttemptTime DESC"; // Сортируем по времени попытки

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Привязываем данные к DataGridView
                    loginHistoryDataGridView.DataSource = dt;

                    // Настраиваем заголовки столбцов
                    loginHistoryDataGridView.Columns["Login"].HeaderText = "Логин";
                    loginHistoryDataGridView.Columns["AttemptTime"].HeaderText = "Время входа";
                    loginHistoryDataGridView.Columns["AttemptDate"].HeaderText = "Дата входа";
                    loginHistoryDataGridView.Columns["Status"].HeaderText = "Статус";
                }
            }
        }


        private void sortByDateButton_Click(object sender, EventArgs e)
        {
            DataTable dt = loginHistoryDataGridView.DataSource as DataTable;
            if (dt != null)
            {
                dt.DefaultView.Sort = "AttemptDate DESC, AttemptTime DESC";
                loginHistoryDataGridView.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            operatorForm.Show(); // Показываем форму оператора
            this.Close();
        }
    }

}
