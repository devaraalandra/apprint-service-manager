using System;
using System.Data;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class CusViewStatus : Form
    {
        // Constructor to initialize the form
        public CusViewStatus()
        {
            InitializeComponent();
        }

        // Method to display the status of customer requests
        public void DisplayStatus()
        {
            string username = LoginSession.Username;
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("No user is logged in.");
                return;
            }

            // Get requests of the logged-in user
            GetRequest getRequest = new GetRequest();
            DataTable dataTable = getRequest.GetRequestFrom(username);

            // Filter the requests based on selected status
            string selectedStatus = cmbStatus.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "All")
            {
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = $"Status = '{selectedStatus}'";
                dgvStatus.DataSource = dataView;
            }
            else
            {
                dgvStatus.DataSource = dataTable;
            }

            // Hide the username column in the data grid view
            dgvStatus.Columns["Username"].Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new cusHomePage().Show();
            this.Close();
        }

        private void CusViewStatus_Load(object sender, EventArgs e)
        {
            // Default selected index for the status combo box
            cmbStatus.SelectedIndex = 0;

            // Display status of requests
            DisplayStatus();
        }
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update the displayed status based on the selected status
            DisplayStatus();
        }
    }
}
