using System;
using System.Data;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class WorViewPage : Form
    {
        private WorDatabaseHelper dbHelper;
        private string username;

        public WorViewPage(string username)
        {
            InitializeComponent();
            this.username = username;
            dbHelper = new WorDatabaseHelper(Config.ConnectionString);

            cmbAssignedReq.Items.Add("Recently Assigned");
            cmbAssignedReq.Items.Add("Oldest Assigned");
            cmbAssignedReq.Items.Add("Order by Number");

            this.Load += new EventHandler(viewpage_Load);
            btnSearch.Click += new EventHandler(btnSearch_Click);
            txtSearchText.TextChanged += new EventHandler(textBox1_TextChanged);
            cmbAssignedReq.SelectedIndexChanged += new EventHandler(cmbAssignedReq_SelectedIndexChanged);
        }

        private void viewpage_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
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
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            WorHomePage workerDash = new WorHomePage(username);
            workerDash.Show();
            this.Hide();
        }

        private void cmbAssignedReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = cmbAssignedReq.SelectedItem.ToString();
            FetchAndDisplayData(selectedOption);
        }

        private void FetchAndDisplayData(string sortingOption)
        {
            try
            {
                DataTable dt = dbHelper.GetSortedRequests(username, sortingOption);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchText.Text.Trim(); // Assuming txtSearchText is your search text box
            if (string.IsNullOrEmpty(searchText))
            {
                PopulateDataGridView();
            }
            else
            {
                SearchDatabaseByStatus(username, searchText);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchText.Text.Trim(); // Assuming txtSearchText is your search text box
            if (string.IsNullOrWhiteSpace(searchText))
            {
                PopulateDataGridView();
            }
            else
            {
                SearchDatabaseByStatus(username, searchText);
            }
        }

        private void SearchDatabaseByStatus(string workerID, string searchText)
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
    }
}
