using System;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class CusEditProfile : Form
    {
        // Constructor to initialize the form
        public CusEditProfile()
        {
            InitializeComponent();
            this.Load += new EventHandler(CusEditProfile_Load);
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
            new cusHomePage().Show();
            this.Hide();
        }

        // Method to open the confirmation page for editing
        private void OpenConfirmationPage(string fieldType, string currentValue)
        {
            CusEditProfConfirm confirmPage = new CusEditProfConfirm(fieldType, currentValue);
            confirmPage.Show();
            this.Hide();
        }

        private void CusEditProfile_Load(object sender, EventArgs e)
        {
            string username = LoginSession.Username;
            EditProfile editProfile = new EditProfile(Config.ConnectionString);
            var user = editProfile.GetUser(username);

            // Set labels to display current user details
            lblEmail.Text = user.Email;
            lblPhone.Text = user.Phone;
            lblPassword.Text = user.Password;
            lblUsername.Text = user.Username;
        }
    }
}
