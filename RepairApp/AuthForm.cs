using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RepairApp
{
    public partial class AuthForm : Form
    {
        private string connectionString = "Data Source=STEPANOVA;Integrated Security=True;MultipleActiveResultSets=True";
        private int loginAttempts = 0;
        private DateTime lockoutEndTime;

        public AuthForm()
        {
            InitializeComponent();
            // Устанавливаем маску для пароля
            passwordTextBox.PasswordChar = '•';
            showPasswordCheckBox.CheckedChanged += showPasswordCheckBox_CheckedChanged;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (DateTime.Now < lockoutEndTime)
            {
                MessageBox.Show("Вход заблокирован. Попробуйте через 3 минуты.");
                SaveLoginAttempt(loginTextBox.Text, false); // Сохраняем неудачную попытку
                return;
            }

            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;

            var authResult = AuthenticateUser(login, password);

            if (authResult.IsAuthenticated)
            {
                SaveLoginAttempt(login, true); // Сохраняем успешную попытку
                OpenUserPage(login, authResult.UserType, authResult.FullName);
            }
            else
            {
                loginAttempts++;
                SaveLoginAttempt(login, false); // Сохраняем неудачную попытку

                if (loginAttempts == 1)
                {
                    // Открываем CAPTCHA форму после первой ошибки
                    CaptchaForm captchaForm = new CaptchaForm();
                    if (captchaForm.ShowDialog() != DialogResult.OK)
                    {
                        MessageBox.Show("Неверная CAPTCHA.");
                        return;
                    }
                }

                if (loginAttempts >= 3)
                {
                    lockoutEndTime = DateTime.Now.AddMinutes(3);
                    MessageBox.Show("Вход заблокирован на 3 минуты.");
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.");
                }
            }
        }



        private void SaveLoginAttempt(string login, bool success)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=STEPANOVA;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                conn.Open();
                string query = "INSERT INTO LoginHistory (Login, AttemptTime, Success) VALUES (@login, @attemptTime, @success)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@attemptTime", DateTime.Now);
                    cmd.Parameters.AddWithValue("@success", success);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private (bool IsAuthenticated, string UserType, string FullName) AuthenticateUser(string login, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Password, UserType, FIO FROM Users WHERE Login = @login";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Логин найден, проверяем пароль
                            bool isAuthenticated = reader["Password"].ToString() == password;
                            string userType = reader["UserType"].ToString();
                            string fullName = reader["FIO"].ToString();
                            return (isAuthenticated, userType, fullName);
                        }
                        else
                        {
                            // Логин не найден
                            return (false, null, null);
                        }
                    }
                }
            }
        }



        private void OpenUserPage(string login, string userType, string fullName)
        {
            switch (userType)
            {
                case "Заказчик":
                    CustomerForm customerForm = new CustomerForm(login, fullName);
                    customerForm.Show();
                    break;
                case "Мастер":
                    MasterForm masterForm = new MasterForm(login, fullName);
                    masterForm.Show();
                    break;
                case "Оператор":
                    OperatorForm operatorForm = new OperatorForm(login, fullName);
                    operatorForm.Show();
                    break;
            }
            this.Hide(); // Закрываем текущую форму
        }


        private string GetUserType(string login)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT UserType FROM Users WHERE Login = @login";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    return (string)cmd.ExecuteScalar();
                }
            }
        }

        private bool CheckUserExists(string login)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Login = @login";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    int userCount = (int)cmd.ExecuteScalar();
                    return userCount > 0;
                }
            }
        }


        private void registerAuthButton_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        // Обработчик события изменения состояния чекбокса
        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Если чекбокс выбран, показываем пароль, иначе маскируем его
            passwordTextBox.PasswordChar = showPasswordCheckBox.Checked ? '\0' : '•';
        }
    }
}
