using OOP_G18_Final_Assignment_APPrint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class AdmHomePage : Form
    {
        public AdmHomePage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdmEditUser admEditUser = new AdmEditUser();
            admEditUser.Show();
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            AdmRegisterUser admRegisterUser = new AdmRegisterUser();
            admRegisterUser.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            AdmReports admReports = new AdmReports();
            admReports.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginSession.Username = null;

            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            this.Close();
        }
    }
}
