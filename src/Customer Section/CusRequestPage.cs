using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OOP_G18_Final_Assignment_APPrint.APPrint_DatabaseDataSetTableAdapters;

namespace OOP_G18_Final_Assignment_APPrint
{
    public partial class CusRequestPage : Form
    {

        // Constructor to initialize the form
        public CusRequestPage()
        {
            InitializeComponent();
        }

        string myConnectionString = Config.ConnectionString;

        private void btnBack_Click(object sender, EventArgs e)
        {
            new cusHomePage().Show();
            this.Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            HandleRequest(confirm: true);
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            HandleRequest(confirm: false);
        }

        // Method to handle request confirmation & price checking
        private void HandleRequest(bool confirm)
        {
            CalcService serviceRequest = new CalcService(myConnectionString); // Create an instance of CalcService with connectionString
            List<Service> services = serviceRequest.GetServices(); // Get services from database

            int quantity = int.TryParse(txtQuantity.Text, out quantity) ? quantity : 1; // Default to 1 for quantity
            string urgency = cbUrgency.SelectedItem?.ToString() ?? "Not Urgent"; // Gets the selected Item from urgency combobox. Detaults to Not Urgent
            bool isUrgent = urgency == "Urgent"; // Boolean to determine 

            var selectedServiceDetails = GetDetails(services); // searches and gets service details from input

            if (selectedServiceDetails.serviceId != null && selectedServiceDetails.size != null) // check if both are selected
            {
                // Find selected service in list of services
                Service selectedService = services.FirstOrDefault( // cycles the lambda expression through the services list to find the selected service
                    service => service.ServiceId == selectedServiceDetails.serviceId && // lambda expression, checks if serviceID matches with user
                               service.Sizes.Contains(selectedServiceDetails.size) // checks if size matches
                );

                // if found, start calc process
                if (selectedService != null)
                {
                    double totalCost = serviceRequest.CalculateTotalCost(selectedService, quantity, isUrgent); // calculate total cost
                    string discountApplicable = (selectedService.QuantityThreshold.HasValue && quantity >= selectedService.QuantityThreshold.Value) ? "Yes" : "No"; // check if applicable

                    if (confirm) // if confirm is true, show message box and generate new request
                    {
                        MessageBox.Show(
                            "ID: " + selectedService.ServiceId + "\nFee: RM " + selectedService.ServiceFee.ToString() +
                            "\nQuantity: " + quantity + "\nSize: " + selectedServiceDetails.size +
                            "\n\nDiscount: " + selectedService.DisplayDiscountPercent +
                            "\nDiscount Applicable: " + discountApplicable + "\nTotal Cost: RM " + totalCost.ToString(),
                            "Service Cost", MessageBoxButtons.OK, MessageBoxIcon.Information
                        );

                        CreateNewRequest(
                            selectedService.ServiceId, selectedServiceDetails.size, quantity, totalCost, urgency
                        );
                    }
                    else // else, only show in message box for price checking
                    {
                        MessageBox.Show(
                            "ID: " + selectedService.ServiceId + "\nFee: RM " + selectedService.ServiceFee.ToString() +
                            "\nQuantity: " + quantity + "\nSize: " + selectedServiceDetails.size +
                            "\n\nDiscount: " + selectedService.DisplayDiscountPercent +
                            "\nDiscount Applicable: " + discountApplicable + "\nTotal Cost: RM " + totalCost.ToString(),
                            "Service Cost", MessageBoxButtons.OK, MessageBoxIcon.Information
                        );
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Service not found. Please check the Service Type and Size.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                MessageBox.Show(
                    "Please select a service type.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
        }


        // Method to get selected service details based on user input
        private (string serviceId, string size) GetDetails(List<Service> services)
        {
            if (rbBnW.Checked) return ("1", "A4");
            if (rbColor.Checked) return ("2", "A4");
            if (rbPosterA0.Checked) return ("5", "A0");
            if (rbPosterA1.Checked) return ("5", "A1");
            if (rbPosterA2.Checked) return ("6", "A2");
            if (rbPosterA3.Checked) return ("6", "A3");
            if (rbBindComb.Checked) return ("3", "-");
            if (rbBindThick.Checked) return ("4", "-");

            return (null, null);
        }

        // Method to create a new request
        private void CreateNewRequest(string serviceId, string size, int quantity, double totalFee, string urgency)
        {
            string username = LoginSession.Username;
            string status = "Pending";
            DateTime dateCreated = DateTime.Now;

            UserUpdateRequest updateRequest = new UserUpdateRequest(myConnectionString);

            bool requestCreated = updateRequest.CreateRequest(username, int.Parse(serviceId), quantity, size, totalFee, status, dateCreated, urgency);

            if (requestCreated)
            {
                MessageBox.Show("Request created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to create request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
