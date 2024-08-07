using System;
using System.Data.SqlClient;

namespace OOP_G18_Final_Assignment_APPrint
{
    // Class for editing user profile
    public class EditProfile
    {
        private readonly string connectionString;

        // Constructor to initialize the connection string
        public EditProfile(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Method to get user details from the database
        public User GetUser(string username)
        {
            string query = "SELECT * FROM dbo.Users WHERE Username = @Username";
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                connection.Open();
                using (var reader = command.ExecuteReader()) // data reader
                {
                    if (reader.Read()) // check  if there are rows in the results
                    {
                        return new User // if found, create new user Object
                        {
                            Username = reader["Username"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Password = reader["Password"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        // Method to update the email of a user
        public bool UpdateEmail(string username, string newEmail)
        {
            return UpdateUserField(username, "Email", newEmail);
        }

        // Method to update the phone number of a user
        public bool UpdatePhone(string username, string newPhone)
        {
            return UpdateUserField(username, "Phone", newPhone);
        }

        // Method to update the password of a user
        public bool UpdatePassword(string username, string newPassword)
        {
            return UpdateUserField(username, "Password", newPassword);
        }

        // Method to update the username of a user
        public bool UpdateUsername(string currentUsername, string newUsername)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction()) // create new transaction
                {
                    try
                    {
                        // Disable foreign key constraints
                        ExecuteNonQuery(connection, transaction, "ALTER TABLE dbo.Assignments NOCHECK CONSTRAINT FK_Assignments_WorkerID");
                        ExecuteNonQuery(connection, transaction, "ALTER TABLE dbo.Requests NOCHECK CONSTRAINT fk_Username");

                        // Update the username in Users, Requests, and Assignments tables
                        ExecuteUpdate(connection, transaction, "UPDATE dbo.Users SET Username = @newUsername WHERE Username = @currentUsername", currentUsername, newUsername);
                        ExecuteUpdate(connection, transaction, "UPDATE dbo.Requests SET Username = @newUsername WHERE Username = @currentUsername", currentUsername, newUsername);
                        ExecuteUpdate(connection, transaction, "UPDATE dbo.Assignments SET WorkerID = @newUsername WHERE WorkerID = @currentUsername", currentUsername, newUsername);

                        // Re-enable foreign key constraints
                        ExecuteNonQuery(connection, transaction, "ALTER TABLE dbo.Assignments CHECK CONSTRAINT FK_Assignments_WorkerID");
                        ExecuteNonQuery(connection, transaction, "ALTER TABLE dbo.Requests CHECK CONSTRAINT fk_Username");

                        transaction.Commit(); // commit transaction if all commands succeed
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback(); // rollback if an exception/error occurs
                        throw;
                    }
                }
            }
        }

        // Method to check if a username already exists
        public bool UsernameExists(string username)
        {
            string query = "SELECT COUNT(*) FROM dbo.Users WHERE Username = @Username";
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                connection.Open();
                int count = (int)command.ExecuteScalar(); // checks the query and returns int
                return count > 0; // returns true if there is existing username in database
            }
        }

        // Helper method to execute an update query
        private void ExecuteUpdate(SqlConnection connection, SqlTransaction transaction, string query, string currentUsername, string newUsername)
        {
            using (var command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@newUsername", newUsername);
                command.Parameters.AddWithValue("@currentUsername", currentUsername);
                command.ExecuteNonQuery();
            }
        }

        // Helper method to execute a non-query command
        // non query updates the database, returns x no. of records
        private void ExecuteNonQuery(SqlConnection connection, SqlTransaction transaction, string query)
        {
            using (var command = new SqlCommand(query, connection, transaction))
            {
                command.ExecuteNonQuery();
            }
        }

        // Helper method to update a specific field in the Users table
        private bool UpdateUserField(string username, string fieldName, string newValue)
        {
            string query = $"UPDATE dbo.Users SET {fieldName} = @NewValue WHERE Username = @Username";
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NewValue", newValue);
                command.Parameters.AddWithValue("@Username", username);
                connection.Open();
                return command.ExecuteNonQuery() > 0; // return true if the row was changed
            }
        }
    }

    // User class to extract users
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
