using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Config.ConnectionString))
                {
                    con.Open();

                    string query = "SELECT RoleName FROM Users WHERE Username = @username AND Password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                LoginSession.Username = txtUsername.Text;

                                string role = dr["RoleName"].ToString();

                                if (role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                                {
                                    new AdmHomePage().Show();
                                }
                                else if (role.Equals("customer", StringComparison.OrdinalIgnoreCase))
                                {
                                    new cusHomePage().Show();
                                }
                                else if (role.Equals("manager", StringComparison.OrdinalIgnoreCase))
                                {
                                    new ManHomePage().Show();
                                }
                                else if (role.Equals("worker", StringComparison.OrdinalIgnoreCase))
                                {
                                    new WorHomePage(LoginSession.Username).Show();
                                }
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("The username or password you entered is incorrect, try again.");
                                txtPassword.Clear();
                                txtUsername.Focus();
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log exception
                MessageBox.Show("An error occurred accessing the database: " + ex.Message);
            }
        }

    }
}
