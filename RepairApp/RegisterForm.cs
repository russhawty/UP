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
    public partial class RegisterForm : Form
    {
        private string connectionString = "Data Source=STEPANOVA;Integrated Security=True;MultipleActiveResultSets=True";

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string fio = fioRegTextBox.Text;
            string phone = phoneRegTextBox.Text;
            string login = loginRegTextBox.Text;
            string password = passwordRegTextBox.Text;

            if (RegisterCustomer(fio, phone, login, password))
            {
                MessageBox.Show("Регистрация успешна.");
            }
            else
            {
                MessageBox.Show("Ошибка регистрации.");
            }
        }
        private bool RegisterCustomer(string fio, string phone, string login, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Проверка, существует ли уже пользователь с таким логином
                if (IsLoginTaken(login, conn))
                {
                    MessageBox.Show("Этот логин уже используется. Пожалуйста, выберите другой.");
                    return false;
                }

                // Если логин не занят, выполняем вставку
                string query = "INSERT INTO Users (FIO, Phone, Login, Password, UserType) VALUES (@fio, @phone, @login, @password, 'Заказчик')";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fio", fio);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Открываем форму авторизации
            AuthForm authForm = new AuthForm();
            authForm.Show();

            // Закрываем текущую форму
            this.Close();
        }

        // Метод для проверки, занят ли логин
        private bool IsLoginTaken(string login, SqlConnection conn)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Login = @login";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@login", login);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

    }
}


