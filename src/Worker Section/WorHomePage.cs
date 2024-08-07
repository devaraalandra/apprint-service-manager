using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class WorHomePage : Form
    {
        private string username;

        public WorHomePage(string username)
        {
            InitializeComponent();
            this.username = username;
            this.Load += new EventHandler(workerdash_Load);

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            WorViewPage viewPage = new WorViewPage(username);
            viewPage.Show();

            this.Hide();
        }

        private void workerdash_Load(object sender, EventArgs e)
        {
            lblWelcomeMessage.Text = $"Welcome, {username}";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginSession.Username = null;
            LoginForm Login = new LoginForm();
            Login.Show();

            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            WorUpdate Update = new WorUpdate(username);
            Update.Show();

            this.Hide();
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            WorEditProfile EditProfile = new WorEditProfile();
            EditProfile.Show();

            this.Hide();
        }
    }
}
