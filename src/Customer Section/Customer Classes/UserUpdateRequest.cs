using System;
using System.Data.SqlClient;

namespace OOP_G18_Final_Assignment_APPrint
{
    public class UserUpdateRequest
    {
        private readonly string connectionString;

        public UserUpdateRequest(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Method to create a new request in the database; returns boolean
        public bool CreateRequest(string username, int serviceId, int quantity, string size, double totalFee, string status, DateTime dateCreated, string urgency)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Requests (Username, ServiceID, Quantity, Size, TotalFee, Status, DateCreated, Urgency) " +
                               "VALUES (@Username, @ServiceID, @Quantity, @Size, @TotalFee, @Status, @DateCreated, @Urgency)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to fill in the SQL command
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@ServiceID", serviceId);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Size", size);
                    command.Parameters.AddWithValue("@TotalFee", totalFee);
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@DateCreated", dateCreated);
                    command.Parameters.AddWithValue("@Urgency", urgency);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery(); // non query updates the database, returns x no. of records
                    return rowsAffected > 0; // Return true if at least one row is affected
                }
            }
        }
    }
}
