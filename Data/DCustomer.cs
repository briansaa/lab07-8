using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DCustomer
    {
        private string connectionString = "Server=LAPTOP-7EGTO68Q\\SQLEXPRESS;Database=InvoiceDB;User Id=Saa;Password=123456;";

        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string storedProcedure = "GetAllCustomers";
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        CustomerId = (int)reader["customer_id"],
                        Name = reader["name"].ToString(),
                        Address = reader["address"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Active = (bool)reader["active"]
                    };

                    customers.Add(customer);
                }
            }

            return customers;
        }

        public void InsertCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string storedProcedure = "InsertCustomer";
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", customer.Name);
                command.Parameters.AddWithValue("@Address", customer.Address);
                command.Parameters.AddWithValue("@Phone", customer.Phone);
                command.Parameters.AddWithValue("@Active", customer.Active);

                command.ExecuteNonQuery();

                string selectQuery = "SELECT TOP 1 * FROM Customers ORDER BY customer_id DESC";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Customer newCustomer = new Customer
                        {
                            CustomerId = (int)reader["customer_id"],
                            Name = reader["name"].ToString(),
                            Address = reader["address"].ToString(),
                            Phone = reader["phone"].ToString(),
                            Active = (bool)reader["active"]
                        };

                        Console.WriteLine($"Inserted Customer - ID: {newCustomer.CustomerId}, Name: {newCustomer.Name}");
                    }
                }
            }
        }
    }
}
