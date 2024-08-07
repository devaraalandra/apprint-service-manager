using OOP_G18_Final_Assignment_APPrint;
using System;
using System.Data;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class WorUpdate : Form
    {
        private WorDatabaseHelper dbHelper;
        private string username;

        public WorUpdate(string username)
        {
            InitializeComponent();
            this.username = username;
            dbHelper = new WorDatabaseHelper(Config.ConnectionString);

            PopulateRequestIDsComboBox();
            PopulateStatusComboBox();
            PopulateFilterComboBox();
            PopulateDataGridView();

            btnSearch.Click += new EventHandler(btnSearch_Click);
            btnUpdate.Click += new EventHandler(btnUpdate_Click);
            cmbAssignedReq.SelectedIndexChanged += new EventHandler(cmbAssignedReq_SelectedIndexChanged);
        }

        private void PopulateRequestIDsComboBox()
        {
            try
            {
                DataTable dt = dbHelper.GetRequestsByWorker(username);
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Status"].ToString() != "Completed")
                    {
                        cmbRequest.Items.Add(row["RequestID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void PopulateStatusComboBox()
        {
            cmbStatus.Items.Add("In Progress");
            cmbStatus.Items.Add("Completed");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtRequestID.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                SearchDatabaseByID(username, searchText);
            }
        }

        private void SearchDatabaseByID(string workerID, string searchText)
        {
            try
            {
                DataTable dt = dbHelper.SearchDatabaseByStatus(workerID, searchText);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void PopulateFilterComboBox()
        {
            cmbAssignedReq.Items.Add("Recently Assigned");
            cmbAssignedReq.Items.Add("Oldest Assigned");
            cmbAssignedReq.Items.Add("Order by Number");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRequest.SelectedItem != null && cmbStatus.SelectedItem != null)
                {
                    int requestID = Convert.ToInt32(cmbRequest.SelectedItem);
                    string status = cmbStatus.SelectedItem.ToString();

                    dbHelper.UpdateRequestStatus(requestID, status);
                    PopulateDataGridView();
                    MessageBox.Show("Request status updated successfully.");
                }
                else
                {
                    MessageBox.Show("Please select a request and a status.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating request: " + ex.Message);
            }
        }

        private void PopulateDataGridView()
        {
            try
            {
                DataTable dt = dbHelper.GetRequestsByWorker(username);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtRequestID_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtRequestID.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                PopulateDataGridView();
            }
            else
            {
                SearchDatabaseByID(username, searchText);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            WorHomePage workerDash = new WorHomePage(username);
            workerDash.Show();
            this.Hide();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtRequestID.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                PopulateDataGridView();
            }
            else
            {
                SearchDatabaseByID(username, searchText);
            }
        }

        private void cmbAssignedReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = cmbAssignedReq.SelectedItem.ToString();

            try
            {
                DataTable dt = dbHelper.GetSortedRequests(username, selectedOption);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
