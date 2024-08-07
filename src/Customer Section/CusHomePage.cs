using System;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class cusHomePage : Form
    {
        public cusHomePage()
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {LoginSession.Username}";
        }
        private void btnServices_Click(object sender, EventArgs e)
        {
            new CusViewServicesPage().Show();
            this.Hide();
        }
        private void btnRequest_Click(object sender, EventArgs e)
        {
            new CusRequestPage().Show();
            this.Hide();
        }
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            new CusEditProfile().Show();
            this.Hide();
        }
        private void btnViewStatus_Click(object sender, EventArgs e)
        {
            new CusViewStatus().Show();
            this.Hide();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginSession.Username = null; // Clear username on logout

            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            this.Close();
        }
    }
}

