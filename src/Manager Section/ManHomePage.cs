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
    public partial class ManHomePage : Form
    {
        public ManHomePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AssignJob ManViewModeForm = new AssignJob();
            ManViewModeForm.ShowDialog();
            this.Close();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            ManViewMode AssignJobForm = new ManViewMode();
            AssignJobForm.Show();
            this.Close();
        }
        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            ManEditProfile EditProfile = new ManEditProfile();
            EditProfile.Show();
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
