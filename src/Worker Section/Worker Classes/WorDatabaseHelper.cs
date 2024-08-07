using System;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

public class WorDatabaseHelper
{
    private string connectionString;

    public WorDatabaseHelper(string connectionString)
    {
        this.connectionString = connectionString;
    }



    public DataTable GetRequestsByWorker(string username)
    {
        DataTable dt = new DataTable();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = @"
                    SELECT 
                        Requests.RequestID, 
                        Requests.ServiceID, 
                        Requests.Quantity, 
                        Requests.Size, 
                        Requests.Status, 
                        Requests.DateCreated, 
                        Requests.Urgency
                    FROM 
                        Assignments
                    JOIN 
                        Requests ON Assignments.RequestID = Requests.RequestID
                    WHERE 
                        Assignments.WorkerID = @Username";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@searchText", "%");

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching data: " + ex.Message);
            }
        }

        return dt;
    }

    public DataTable SearchDatabaseByStatus(string workerID, string searchText)
    {
        DataTable dt = new DataTable();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = @"
                SELECT 
                    Requests.RequestID, 
                    Requests.ServiceID, 
                    Requests.Quantity, 
                    Requests.Size, 
                    Requests.Status, 
                    Requests.DateCreated, 
                    Requests.Urgency
                FROM 
                    Assignments
                JOIN 
                    Requests ON Assignments.RequestID = Requests.RequestID
                WHERE 
                    Assignments.WorkerID = @WorkerID AND Requests.Status LIKE @searchText";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@WorkerID", workerID);
                command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching data: " + ex.Message);
            }
        }

        return dt;
    }

    private bool IsRequestAssignedToWorker(string username, string requestId)
    {
        // Query the database to check if the request ID is assigned to the worker
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT COUNT(*) FROM Assignments WHERE WorkerID = @Username AND RequestID = @RequestId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@RequestId", requestId);
            int count = (int)command.ExecuteScalar();
            return count > 0;
        }
    }
    public DataTable SearchRequestsByID(string workerID, string searchText)
    {
        DataTable dt = new DataTable();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = @"
                    SELECT 
                        Requests.RequestID, 
                        Requests.ServiceID, 
                        Requests.Quantity, 
                        Requests.Size, 
                        Requests.Status, 
                        Requests.DateCreated, 
                        Requests.Urgency
                    FROM 
                        Assignments
                    JOIN 
                        Requests ON Assignments.RequestID = Requests.RequestID
                    WHERE 
                        Assignments.WorkerID = @WorkerID AND Requests.RequestID LIKE @searchText";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                command.Parameters.AddWithValue("@WorkerID", workerID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching data: " + ex.Message);
            }
        }

        return dt;
    }

    public DataTable GetSortedRequests(string username, string sortingOption)
    {
        DataTable dt = new DataTable();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"
                SELECT 
                        Requests.RequestID, 
                        Requests.ServiceID, 
                        Requests.Quantity, 
                        Requests.Size, 
                        Requests.Status, 
                        Requests.DateCreated, 
                        Requests.Urgency
                    FROM 
                        Assignments
                    JOIN 
                        Requests ON Assignments.RequestID = Requests.RequestID
                    WHERE 
                        Assignments.WorkerID = @Username";


            // Modify the query based on the selected sorting option
            switch (sortingOption)
            {
                case "Recently Assigned":
                    query += " ORDER BY Requests.DateCreated DESC"; // Assuming DateCreated is the column name
                    break;
                case "Oldest Assigned":
                    query += " ORDER BY Requests.DateCreated ASC";
                    break;
                case "Order by Number":
                    query += " ORDER BY Assignments.AssignmentID ASC";
                    break;
            }

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching data: " + ex.Message);
            }
        }

        return dt;
    }

    public void UpdateRequestStatus(int requestID, string status)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string updateQuery = "UPDATE dbo.Requests SET Status = @Status WHERE RequestID = @RequestID";
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@RequestID", requestID);
                command.Parameters.AddWithValue("@Status", status);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating request status: " + ex.Message);
            }
        }
    }
}

