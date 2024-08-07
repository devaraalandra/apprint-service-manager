using OOP_G18_Final_Assignment_APPrint;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class AdmUserEditConfirm : Form
    {
        private string currentUsername;
        private readonly EditProfile editProfile;

        public AdmUserEditConfirm(string username)
        {
            InitializeComponent();
            this.currentUsername = username;
            this.editProfile = new EditProfile(Config.ConnectionString);
        }

        private void AdmUserEditConfirm_Load(object sender, EventArgs e)
        {
            LoadUserRoles();
            LoadUserData();
        }

        private void LoadUserRoles()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new string[] { "admin", "customer", "manager", "worker" });
            cmbRole.SelectedIndex = 0;
        }

        private void LoadUserData()
        {
            try
            {
                using (var connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = "SELECT * FROM Users WHERE Username = @Username";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", currentUsername);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtUsername.Text = reader["Username"].ToString();
                            txtPassword.Text = reader["Password"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtPhone.Text = reader["Phone"].ToString();
                            cmbRole.Text = reader["RoleName"].ToString();
                            txtFullname.Text = reader["FullName"].ToString();
                            txtAddress.Text = reader["Address"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string newUsername = txtUsername.Text;
            if (currentUsername != newUsername)
            {
                if (editProfile.UsernameExists(newUsername))
                {
                    MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (editProfile.UpdateUsername(currentUsername, newUsername))
                {
                    MessageBox.Show("Username updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    currentUsername = newUsername;
                }
                else
                {
                    MessageBox.Show("Failed to update username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            UpdateUserData();
        }

        private void UpdateUserData()
        {
            try
            {
                using (var connection = new SqlConnection(Config.ConnectionString))
                {
                    string query = "UPDATE Users SET Password = @Password, Email = @Email, Phone = @Phone, RoleName = @RoleName, FullName = @FullName, Address = @Address WHERE Username = @Username";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Password", txtPassword.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    command.Parameters.AddWithValue("@RoleName", cmbRole.Text);
                    command.Parameters.AddWithValue("@FullName", txtFullname.Text);
                    command.Parameters.AddWithValue("@Address", txtAddress.Text);
                    command.Parameters.AddWithValue("@Username", currentUsername);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update user information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating user data: {ex.Message}");
            }
        }

        private void btnGoback_Click(object sender, EventArgs e)
        {
            new AdmEditUser().Show();
            this.Close();
        }
    }
}
