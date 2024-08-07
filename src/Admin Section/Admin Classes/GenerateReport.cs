using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace OOP_G18_Final_Assignment_APPrint
{
    public class YearlyReportGenerator
    {
        private string connectionString;

        public YearlyReportGenerator(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable GetYearlyReportData(int year)
        {
            string query = @"
                SELECT MONTH(DateCreated) AS Month, SUM(TotalFee) AS TotalIncome
                FROM Requests
                WHERE YEAR(DateCreated) = @Year
                GROUP BY MONTH(DateCreated)
                ORDER BY MONTH(DateCreated)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Year", year);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Add MonthName column and populate it
                dataTable.Columns.Add("MonthName", typeof(string));
                foreach (DataRow row in dataTable.Rows)
                {
                    row["MonthName"] = GetMonthName(Convert.ToInt32(row["Month"]));
                }

                // Reorder columns to make MonthName the first column
                DataTable reorderedTable = dataTable.Clone();
                reorderedTable.Columns["MonthName"].SetOrdinal(0);

                foreach (DataRow row in dataTable.Rows)
                {
                    reorderedTable.ImportRow(row);
                }

                return reorderedTable;
            }
        }

        private string GetMonthName(int month)
        {
            return new DateTime(1, month, 1).ToString("MMMM");
        }
    }

    public class RequestReportGenerator
    {
        private string connectionString;

        public RequestReportGenerator(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Request> GetRequests(int serviceId, int month, int year)
        {
            List<Request> requests = new List<Request>();

            string query = @"
            SELECT *
            FROM Requests
            WHERE ServiceID = @ServiceID
                AND MONTH(DateCreated) = @Month
                AND YEAR(DateCreated) = @Year";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ServiceID", serviceId);
                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Request request = new Request
                        {
                            RequestID = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            ServiceID = reader.GetInt32(2),
                            Quantity = reader.GetInt32(3),
                            Size = reader.GetString(4),
                            TotalFee = reader.GetDecimal(5),
                            Status = reader.GetString(6),
                            DateCreated = reader.GetDateTime(7),
                            Urgency = reader.GetString(8)
                        };
                        requests.Add(request);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return requests;
        }
    }

    public class CustomerReportGenerator
    {
        private string connectionString;

        public CustomerReportGenerator(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable GetCustomerReportData(string customerId, int month, int year)
        {
            string query = @"
                SELECT r.RequestID, s.ServiceType, r.Quantity, r.Size, r.TotalFee, r.Status, r.DateCreated, r.Urgency
                FROM Requests r
                JOIN Services s ON r.ServiceID = s.ServiceID
                WHERE r.Username = @CustomerID
                    AND MONTH(r.DateCreated) = @Month
                    AND YEAR(r.DateCreated) = @Year";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@Month", month);
                cmd.Parameters.AddWithValue("@Year", year);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                return dataTable;
            }
        }

        public decimal GetTotalSpending(DataTable dataTable)
        {
            decimal totalSpending = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                totalSpending += Convert.ToDecimal(row["TotalFee"]);
            }
            return totalSpending;
        }

        public List<string> GetCustomerIDs()
        {
            List<string> customerIDs = new List<string>();

            string query = "SELECT DISTINCT Username FROM Requests";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        customerIDs.Add(reader.GetString(0)); // Assuming Username is a string
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return customerIDs;
        }
    }


    public class Request
    {
        public int RequestID { get; set; }
        public string Username { get; set; }
        public int ServiceID { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public decimal TotalFee { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public string Urgency { get; set; }
    }
}
