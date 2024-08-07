using OOP_G18_Final_Assignment_APPrint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class AdmReportRequest : Form
    {
        private RequestReportGenerator requestReportGenerator;

        public AdmReportRequest()
        {
            InitializeComponent();

            string connectionString = Config.ConnectionString;
            requestReportGenerator = new RequestReportGenerator(connectionString);

            label5.TextAlign = ContentAlignment.MiddleLeft;
            label7.TextAlign = ContentAlignment.MiddleLeft;

        }


        private (int ServiceID, string Size) GetServiceDetails(string serviceName)
        {
            switch (serviceName)
            {
                case "A4 Printing - B&W":
                    return (1, "A4");
                case "A4 Printing - Color":
                    return (2, "A4");
                case "Binding - Comb Binding":
                    return (3, "N/A");
                case "Binding - Thick Cover":
                    return (4, "N/A");
                case "Printing - Poster (A0)":
                    return (5, "A0");
                case "Printing - Poster (A1)":
                    return (5, "A1");
                case "Printing - Poster (A2)":
                    return (6, "A2");
                case "Printing - Poster (A3)":
                    return (6, "A3");
                default:
                    throw new ArgumentException("Invalid service name");
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbServiceType.SelectedItem == null || cmbMonth.SelectedItem == null || cmbYear.SelectedItem == null)
            {
                MessageBox.Show("Please select all required fields.");
                return;
            }

            string selectedService = cmbServiceType.SelectedItem.ToString();
            int month = int.Parse(cmbMonth.SelectedItem.ToString());
            int year = int.Parse(cmbYear.SelectedItem.ToString());

            var (serviceId, size) = GetServiceDetails(selectedService);

            List<Request> requests = requestReportGenerator.GetRequests(serviceId, month, year);

            dataGridView1.DataSource = requests;
            dataGridView1.Columns["ServiceID"].Visible = false;

            decimal totalIncome = requests.Sum(r => r.TotalFee);
            int totalRequests = requests.Count;

            lblTotalIncome.Text = $"{totalIncome}";
            lblTotalReq.Text = $"{totalRequests}";
        }

        private void AdmReportRequest_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnGoback_Click(object sender, EventArgs e)
        {
            AdmReports admReports = new AdmReports();
            admReports.Show();
            this.Close();
        }
    }
}
