using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace OOP_G18_Final_Assignment_APPrint
{
    public class CalcService
    {
        private readonly string connectionString;

        // Constructor to initialize connection string
        public CalcService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Method GetServices returns a list of service objects
        public List<Service> GetServices()
        {
            List<Service> services = new List<Service>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Services";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create Service object and get each property from database
                            Service service = new Service
                            {
                                ServiceId = reader["ServiceID"].ToString(), // service ID convert to string
                                ServiceType = reader["ServiceType"].ToString(), // service type convert to string
                                Sizes = reader["Size"].ToString().Split(',').Select(s => s.Trim()).ToList(), // split sizes by , and put them into a list
                                ServiceFee = Convert.ToDouble(reader["ServiceFee"]), // convert service fees to Double
                                DiscountPercent = reader["DiscountPercent"] != DBNull.Value ? Convert.ToDouble(reader["DiscountPercent"]) : 0, // if not null, converts Discount % to double
                                QuantityThreshold = reader["QuantityThreshold"] != DBNull.Value ? (int?)Convert.ToInt32(reader["QuantityThreshold"]) : null // if not null, converts Qty Threshold to int

                            };

                            services.Add(service); // adds object to the list
                        }
                    }
                }
            }

            return services;
        }

        // Method to calculate total cost based on service details, quantity, and urgency
        public double CalculateTotalCost(Service service, int quantity, bool isUrgent)
        {
            double totalFee = service.ServiceFee * quantity;

            double discountAmount = 0;

            if (service.DiscountPercent > 0 && quantity >= service.QuantityThreshold)
            {
                discountAmount = totalFee * (service.DiscountPercent / 100);
            }

            double totalCost = totalFee - discountAmount;

            if (isUrgent)
            {
                totalCost += totalCost * 0.30; // additional cost for urgent services
            }

            return totalCost;
        }
    }

    // Service class for individual services
    public class Service
    {
        public string ServiceId { get; set; }
        public string ServiceType { get; set; }
        public List<string> Sizes { get; set; }
        public double ServiceFee { get; set; }
        public double DiscountPercent { get; set; }
        public int? QuantityThreshold { get; set; }
        public string Urgency { get; set; }

        // Display discount percentage as string
        public string DisplayDiscountPercent
        {
            get
            {
                return DiscountPercent > 0 ? $"{DiscountPercent}%" : "No discounts available";
            }
        }

        // Property to check if the service is urgent
        public bool IsUrgent
        {
            get
            {
                return Urgency == "Urgent";
            }
        }
    }
}
