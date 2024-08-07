using System;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class CusViewServicesPage : Form
    {
        // Constructor to initialize the form
        public CusViewServicesPage()
        {
            InitializeComponent();
        }

        // Form load with table adapter fill from database
        private void CusViewServicesPage_Load(object sender, EventArgs e)
        {
            this.servicesTableAdapter.Fill(this.aPPrint_DatabaseDataSet1.Services);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new cusHomePage().Show();
            this.Hide();
        }
    }
}
