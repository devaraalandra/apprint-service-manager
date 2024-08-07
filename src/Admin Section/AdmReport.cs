using OOP_G18_Final_Assignment_APPrint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class AdmReports : Form
    {
        public AdmReports()
        {
            InitializeComponent();
        }

        private void btnGoback_Click(object sender, EventArgs e)
        {
            AdmHomePage homePage = new AdmHomePage();
            homePage.Show();
            this.Close();
        }

        private void btnYearly_Click(object sender, EventArgs e)
        {
            AdmReportYearly admReportYearly = new AdmReportYearly();
            admReportYearly.Show();
            this.Close();

        }

        private void btnService_Click(object sender, EventArgs e)
        {
            AdmReportRequest AdmReportRequest = new AdmReportRequest();
            AdmReportRequest.Show();
            this.Close();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            AdmReportCustomer admReportCustomer = new AdmReportCustomer();
            admReportCustomer.Show();
            this.Close();
        }

    }
}
