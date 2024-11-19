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
    public partial class EditRequestForm : Form
    {
        private int requestID;
        private string connectionString = "Data Source=STEPANOVA;Integrated Security=True;MultipleActiveResultSets=True";

        public EditRequestForm(int requestID)
        {
            this.requestID = requestID;
            InitializeComponent();
            LoadRequestDetails();
        }

        private void LoadRequestDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Requests WHERE RequestID = @requestID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@requestID", requestID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Заполняем поля данными о заявке
                            DescriptionTextBox.Text = reader["ProblemDescription"].ToString();
                            priceTextBox.Text = reader["Price"] != DBNull.Value ? reader["Price"].ToString() : "";
                            reportTextBox.Text = reader["Report"] != DBNull.Value ? reader["Report"].ToString() : "";
                            // Дополнительно заполняем другие поля заявки, если нужно
                        }
                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Requests SET ProblemDescription = @description, Price = @price, Report = @report WHERE RequestID = @requestID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@description", DescriptionTextBox.Text);
                    cmd.Parameters.AddWithValue("@price", string.IsNullOrEmpty(priceTextBox.Text) ? (object)DBNull.Value : Convert.ToDecimal(priceTextBox.Text));
                    cmd.Parameters.AddWithValue("@report", string.IsNullOrEmpty(reportTextBox.Text) ? (object)DBNull.Value : reportTextBox.Text);
                    cmd.Parameters.AddWithValue("@requestID", requestID);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Заявка успешно обновлена.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
