using System;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class CusEditProfConfirm : Form
    {
        private readonly string fieldType;
        private readonly string currentValue;

        // Constructor to initialize the form with field type and current value
        public CusEditProfConfirm(string fieldType, string currentValue)
        {
            InitializeComponent();
            this.fieldType = fieldType;
            this.currentValue = currentValue;
            lblOldValue.Text = currentValue;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            CusEditProfile editProfilePage = new CusEditProfile();
            editProfilePage.Show();
            this.Hide();
        }
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string newValue = txtNewValue.Text;
            string confirmNewValue = txtConfirmValue.Text;

            // Confirm if both values match
            if (newValue != confirmNewValue)
            {
                MessageBox.Show("New value and confirm new value do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string username = LoginSession.Username;
            EditProfile editProfile = new EditProfile(Config.ConnectionString);

            bool updateSuccessful = false;

            // If updating username, check if username conflicts with existing user
            if (fieldType == "Username")
            {
                if (editProfile.UsernameExists(newValue))
                {
                    MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Switch case for different field types
            switch (fieldType)
            {
                case "Email":
                    updateSuccessful = editProfile.UpdateEmail(username, newValue);
                    break;
                case "Phone":
                    updateSuccessful = editProfile.UpdatePhone(username, newValue);
                    break;
                case "Password":
                    updateSuccessful = editProfile.UpdatePassword(username, newValue);
                    break;
                case "Username":
                    updateSuccessful = editProfile.UpdateUsername(username, newValue);
                    if (updateSuccessful)
                    {
                        LoginSession.Username = newValue; // Update session username
                    }
                    break;
            }

            // Show property update success/fail
            if (updateSuccessful)
            {
                MessageBox.Show($"{fieldType} updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CusEditProfile editProfilePage = new CusEditProfile();
                editProfilePage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show($"Failed to update {fieldType}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
