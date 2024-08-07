using OOP_G18_Final_Assignment_APPrint;
using System;
using System.Data;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class AdmReportYearly : Form
    {
        public AdmReportYearly()
        {
            InitializeComponent();
            LoadYearsIntoComboBox();
        }

        private void LoadYearsIntoComboBox()
        {
            cmbYear.Items.Add("2023");
            cmbYear.Items.Add("2024");
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbYear.SelectedItem == null)
            {
                MessageBox.Show("Please select a year.");
                return;
            }

            int selectedYear = int.Parse(cmbYear.SelectedItem.ToString());

            string connectionString = Config.ConnectionString;
            YearlyReportGenerator reportGenerator = new YearlyReportGenerator(connectionString);

            try
            {
                DataTable reportData = reportGenerator.GetYearlyReportData(selectedYear);

                reportData.DefaultView.Sort = "Month ASC";
                DataTable sortedData = reportData.DefaultView.ToTable();

                dataGridView1.DataSource = sortedData;

                // hide the Month column
                dataGridView1.Columns["Month"].Visible = false;

                // show the month name column
                dataGridView1.Columns["MonthName"].Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void btnGoback_Click(object sender, EventArgs e)
        {
            AdmReports admReports = new AdmReports();
            admReports.Show();
            this.Close();
        }
    }
}
