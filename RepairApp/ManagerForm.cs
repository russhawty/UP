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
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void btnDailyReport_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=STEPANOVA;Integrated Security=True;MultipleActiveResultSets=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Requests WHERE startDate = @today";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@today", DateTime.Now.Date);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Отчёт за день сгенерирован!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnWeeklyReport_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=STEPANOVA;Integrated Security=True;MultipleActiveResultSets=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Requests WHERE startDate >= @startOfWeek AND startDate <= @endOfWeek";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@startOfWeek", DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek));
                    cmd.Parameters.AddWithValue("@endOfWeek", DateTime.Now);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Отчёт за неделю сгенерирован!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnMonthlyReport_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=STEPANOVA;Integrated Security=True;MultipleActiveResultSets=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Requests WHERE startDate >= @startOfMonth AND startDate <= @endOfMonth";
                    SqlCommand cmd = new SqlCommand(query, con);
                    DateTime startOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

                    cmd.Parameters.AddWithValue("@startOfMonth", startOfMonth);
                    cmd.Parameters.AddWithValue("@endOfMonth", endOfMonth);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Отчёт за месяц сгенерирован!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=STEPANOVA;Integrated Security=True;MultipleActiveResultSets=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "INSERT INTO Users (fio, phone, login, password, userType) " +
                                   "VALUES (@fio, @phone, @login, @password, @userType)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@fio", txtEFIO.Text);
                    cmd.Parameters.AddWithValue("@phone", txtEPhone.Text);
                    cmd.Parameters.AddWithValue("@login", txtELogin.Text);
                    cmd.Parameters.AddWithValue("@password", txtEPassword.Text);
                    cmd.Parameters.AddWithValue("@userType", cmbUserType.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Сотрудник зарегистрирован!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
