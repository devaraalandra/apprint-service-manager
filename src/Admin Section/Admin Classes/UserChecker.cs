using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public class UserChecker
    {
        private string connectionString;

        public UserChecker(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool DoesUsernameExist(string username)
        {
            bool exists = false;

            string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    exists = (count > 0);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return exists;
        }
    }
}