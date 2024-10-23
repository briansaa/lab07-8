using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DProduct
{
    private string connectionString = "Server=LAPTOP-7EGTO68Q\\SQLEXPRESS;Database=InvoiceDB;User Id=Saa;Password=123456;";

    public DataTable GetProducts()
    {
        DataTable productsTable = new DataTable();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string storedProcedure = "GetAllProducts"; 
            SqlCommand command = new SqlCommand(storedProcedure, connection);
            command.CommandType = CommandType.StoredProcedure;

            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(productsTable);
            }
        }

        return productsTable; 
    }
}
}