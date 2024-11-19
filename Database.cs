using System;
using System.Data.SqlClient;
using System.Collections.Generic;

public static class Database
{
    private static string connectionString = "Data Source=STEPANOVA;Integrated Security=True;MultipleActiveResultSets=Tru";

    public static bool CheckUser(string login, string password)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT COUNT(*) FROM Users WHERE Login = @login AND Password = @password";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }

    public static string GetUserType(string login)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT UserType FROM Users WHERE Login = @login";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@login", login);
                return (string)command.ExecuteScalar();
            }
        }
    }

    public static bool RegisterUser(string fio, string phone, string login, string password)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Users (FIO, Phone, Login, Password, UserType) VALUES (@fio, @phone, @login, @password, 'Customer')";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@fio", fio);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }

    public static List<Request> GetCustomerRequests(string customerName)
    {
        List<Request> requests = new List<Request>();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Requests WHERE CustomerID = (SELECT UserID FROM Users WHERE FIO = @fio)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@fio", customerName);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        requests.Add(new Request
                        {
                            RequestID = (int)reader["RequestID"],
                            ProblemDescription = reader["ProblemDescription"].ToString(),
                            Status = reader["StatusID"].ToString(), // Не забудьте сопоставить ID со статусом
                        });
                    }
                }
            }
        }
        return requests;
    }

    public static bool CreateRequest(string customerName, string techType, string techModel, string problemDescription)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Requests (ProblemDescription, CustomerID, StatusID, HomeTechID) VALUES (@problemDescription, (SELECT UserID FROM Users WHERE FIO = @fio), 1, (SELECT HomeTechID FROM HomeTech WHERE HomeTechType = @techType AND HomeTechModel = @techModel))";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@problemDescription", problemDescription);
                command.Parameters.AddWithValue("@fio", customerName);
                command.Parameters.AddWithValue("@techType", techType);
                command.Parameters.AddWithValue("@techModel", techModel);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }

    public static bool DeleteRequest(int requestId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Requests WHERE RequestID = @requestId AND StatusID = 1"; // Удаление только новой заявки
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@requestId", requestId);
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}

public class Request
{
    public int RequestID { get; set; }
    public string ProblemDescription { get; set; }
    public string Status { get; set; } // Добавьте свойство для статуса
}
