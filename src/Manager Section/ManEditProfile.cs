using System;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class ManEditProfile : Form
    {
        public ManEditProfile()
        {
            InitializeComponent();
        }

        private void btnEditEmail_Click(object sender, EventArgs e)
        {
            OpenConfirmationPage("Email", lblEmail.Text);
        }

        private void btnEditPhone_Click(object sender, EventArgs e)
        {
            OpenConfirmationPage("Phone", lblPhone.Text);
        }

        private void btnEditPassword_Click(object sender, EventArgs e)
        {
            OpenConfirmationPage("Password", lblPassword.Text);
        }

        private void btnEditUsername_Click(object sender, EventArgs e)
        {
            OpenConfirmationPage("Username", lblUsername.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new ManHomePage().Show();
            this.Hide();
        }

        private void OpenConfirmationPage(string fieldType, string currentValue)
        {
            ManEditProfConfirm confirmPage = new ManEditProfConfirm(fieldType, currentValue);
            confirmPage.Show();
            this.Hide();
        }

        private void ManEditProfile_Load(object sender, EventArgs e)
        {
            // Load user data into the labels
            string username = LoginSession.Username;
            EditProfile editProfile = new EditProfile(Config.ConnectionString);
            var user = editProfile.GetUser(username);

            lblEmail.Text = user.Email;
            lblPhone.Text = user.Phone;
            lblPassword.Text = user.Password;
            lblUsername.Text = user.Username;
        }
    }
}
