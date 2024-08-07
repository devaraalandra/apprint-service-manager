using System;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class WorEditProfile : Form
    {
        public WorEditProfile()
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
            new WorHomePage(LoginSession.Username).Show();
            this.Hide();
        }

        private void OpenConfirmationPage(string fieldType, string currentValue)
        {
            WorEditProfConfirm confirmPage = new WorEditProfConfirm(fieldType, currentValue);
            confirmPage.Show();
            this.Hide();
        }

        private void WorEditProfile_Load(object sender, EventArgs e)
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
