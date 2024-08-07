using OOP_G18_Final_Assignment_APPrint;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class AdmRegisterUser : Form
    {
        public AdmRegisterUser()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string fullName = txtFullName.Text;
            string userName = txtUsername.Text;
            string password = txtPassword.Text;
            string phoneNumber = txtPhon.Text;
            string email = txtEmail.Text;
            string role = comboBox1.SelectedItem?.ToString();
            string address = txtAddress.Text; 

            
            string connectionString = Config.ConnectionString;

            
            string query = "INSERT INTO Users (FullName, UserName, Password, Phone, Email, RoleName, Address) " +
                           "VALUES (@FullName, @UserName, @Password, @PhoneNumber, @Email, @RoleName, @Address)"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

              
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@RoleName", role);
                command.Parameters.AddWithValue("@Address", address); 

                
                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    
                    if (result > 0)
                    {
                        MessageBox.Show("User information saved successfully.");
                    }
                    else
                    {
                        MessageBox.Show("An error occurred while saving the user information.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }

            }
        }


        private void InitializeComboBox()
        {
            comboBox1.Items.Add("admin");
            comboBox1.Items.Add("worker");
            comboBox1.Items.Add("customer");
            comboBox1.Items.Add("manager");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtPhon_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void buttonGoBack_Click(object sender, EventArgs e)
        {
            AdmHomePage homePage = new AdmHomePage();
            homePage.Show();
            this.Close();
        }

    }
}