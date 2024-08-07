using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class AssignJob : Form
    {
        private string connectionString = Config.ConnectionString;
        private DataTable dataTable;

        public AssignJob()
        {
            InitializeComponent();
            PopulateComboBoxes();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManHomePage managerPageForm = new ManHomePage();
            managerPageForm.Show();

            this.Close();
        }


        private void ViewMode_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void PopulateComboBoxes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT RequestID FROM Requests", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbRequestID.Items.Add(reader.GetInt32(0));
                        }
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Username FROM Users WHERE RoleName = 'worker'", connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbWorker.Items.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Requests";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void SearchData(string urgentTerm, string statusTerm)
        {
            string filter = string.Empty;

            if (!string.IsNullOrEmpty(urgentTerm))
            {
                filter = string.Format("urgency LIKE '%{0}%'", urgentTerm);
            }

            if (!string.IsNullOrEmpty(statusTerm))
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    filter += " AND ";
                }
                filter += string.Format("status LIKE '%{0}%'", statusTerm);
            }

            DataView dv = dataTable.DefaultView;
            dv.RowFilter = filter;
            dataGridView1.DataSource = dv.ToTable();
        }

        private void nameSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchData(nameSearchTextBox.Text, statusSearch.Text);
        }

        private void statusSearch_TextChanged(object sender, EventArgs e)
        {
            SearchData(nameSearchTextBox.Text, statusSearch.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            object requestIdObject = cmbRequestID.SelectedItem;
            int requestId;

            if (requestIdObject != null && int.TryParse(requestIdObject.ToString(), out requestId))
            {
                if (cmbWorker.SelectedItem == null)
                {
                    MessageBox.Show("Please select a valid Worker.");
                    return;
                }

                string worker = cmbWorker.SelectedItem.ToString();
                string status = "Assigned";
                DateTime dateAssigned = DateTime.Now;

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Update the status of the request
                        string updateQuery = "UPDATE Requests SET status = @status WHERE RequestID = @requestId";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@status", status);
                            updateCommand.Parameters.AddWithValue("@requestId", requestId);
                            updateCommand.ExecuteNonQuery();
                        }

                        string insertQuery = "INSERT INTO Assignments (RequestID, WorkerID, DateAssigned) VALUES (@requestId, @workerID, @dateAssigned)";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@requestId", requestId);
                            insertCommand.Parameters.AddWithValue("@workerID", worker);
                            insertCommand.Parameters.AddWithValue("@dateAssigned", dateAssigned);

                            insertCommand.ExecuteNonQuery();
                        }
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid Request ID.");
            }
        }

    }
}
