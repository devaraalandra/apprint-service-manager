using OOP_G18_Final_Assignment_APPrint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class AdmEditUser : Form
    {
        private string connectionString = Config.ConnectionString;
        private UserChecker userChecker;

        public AdmEditUser()
        {
            InitializeComponent();

            string connectionString = Config.ConnectionString;
            userChecker = new UserChecker(connectionString);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;

            if (userChecker.DoesUsernameExist(username))
            {
                MessageBox.Show("Username exists.");
                AdmUserEditConfirm adminUserEditConfirm = new AdmUserEditConfirm(username);
                adminUserEditConfirm.Show();
            }
            else
            {
                MessageBox.Show("Username does not exist.");
            }
            this.Close();
        }

        private void AdmEditUser_Load(object sender, EventArgs e)
        {
            this.usersTableAdapter.Fill(this.aPPrint_DatabaseDataSet.Users);
        }


        private void btnGoback_Click(object sender, EventArgs e)
        {
            AdmHomePage homePage = new AdmHomePage();
            homePage.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
