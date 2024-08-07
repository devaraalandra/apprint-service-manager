using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class ManViewMode : Form
    {
        private SqlConnection connection = new SqlConnection(Config.ConnectionString);

        public ManViewMode()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.AssignJob_Load); 
        }

        private void LoadData()
        {
            string query = "SELECT Requests.*, Assignments.WorkerID " +
                           "FROM Requests " +
                           "INNER JOIN Assignments ON Requests.RequestID = Assignments.RequestID";
            SqlCommand cmd = new SqlCommand(query, connection);
            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManHomePage ManHomePageForm = new ManHomePage();
            ManHomePageForm.Show();
            this.Close();
        }

        private void AssignJob_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
