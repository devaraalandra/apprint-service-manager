using System;
using System.Data;
using System.Data.SqlClient;

namespace OOP_G18_Final_Assignment_APPrint
{
    public class GetRequest
    {
        // Method GetRequestFrom returns DataTable from username
        public DataTable GetRequestFrom(string username)
        {
            DataTable dataTable = new DataTable(); // object creation
            string query = @"
                SELECT 
                    Requests.RequestID, 
                    Requests.Username, 
                    Services.ServiceType, 
                    Requests.Quantity, 
                    Requests.Size, 
                    Requests.TotalFee, 
                    Requests.Status, 
                    Requests.DateCreated, 
                    Requests.Urgency
                FROM Requests
                JOIN Services ON Requests.ServiceID = Services.ServiceID
                WHERE Requests.Username = @Username";

            // Establish connection to the database
            using (SqlConnection connection = new SqlConnection(Config.ConnectionString))
            {
                connection.Open(); // Open the connection
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Adding the username parameter to the query
                    command.Parameters.AddWithValue("@Username", username);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable); // Fill the DataTable with query results
                }
            }

            return dataTable; // Return data into DataTable
        }
    }
}
