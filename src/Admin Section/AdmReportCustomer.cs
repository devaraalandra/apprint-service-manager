using OOP_G18_Final_Assignment_APPrint;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class AdmReportCustomer : Form
    {
        private CustomerReportGenerator customerReportGenerator;

        public AdmReportCustomer()
        {
            InitializeComponent();

            string connectionString = Config.ConnectionString;
            customerReportGenerator = new CustomerReportGenerator(connectionString);

            // load customer ID
            LoadCustomerIDs();

            // load months
            LoadMonths();

            // load yaers
            LoadYears();
        }

        private void LoadCustomerIDs()
        {
            List<string> customerIDs = customerReportGenerator.GetCustomerIDs();
            if (customerIDs.Count > 0)
            {
                foreach (var id in customerIDs)
                {
                    Console.WriteLine("Customer ID: " + id);
                }
                cmbCustomerID.DataSource = customerIDs;
            }
            else
            {
                MessageBox.Show("No customer IDs found.");
            }
        }

        private void LoadMonths()
        {
            cmbMonth.Items.AddRange(new string[]
            {
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"
            });
        }

        private void LoadYears()
        {
            cmbYear.Items.AddRange(new string[]
            {
                "2023", "2024"
            });
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbCustomerID.SelectedItem == null || cmbMonth.SelectedItem == null || cmbYear.SelectedItem == null)
            {
                MessageBox.Show("Please select all required fields.");
                return;
            }

            string selectedCustomerID = cmbCustomerID.SelectedItem.ToString();
            int month = int.Parse(cmbMonth.SelectedItem.ToString());
            int year = int.Parse(cmbYear.SelectedItem.ToString());

            DataTable reportData = customerReportGenerator.GetCustomerReportData(selectedCustomerID, month, year);

            // Display report data in DataGridView
            dataGridView1.DataSource = reportData;

            // Calculate total spending
            decimal totalSpending = customerReportGenerator.GetTotalSpending(reportData);

            lblTotalSpending.Text = $"Total Spending: {totalSpending}";
        }

        private void btnGoback_Click(object sender, EventArgs e)
        {
            AdmReports admReports = new AdmReports();
            admReports.Show();
            this.Close();
        }
    }
}
