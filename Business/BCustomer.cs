using System.Collections.Generic;
using Data;
using Entity;

namespace Business
{
    public class BCustomer
    {
        private DCustomer dataCustomer = new DCustomer();

        public List<Customer> ObtenerClientes()
        {
            return dataCustomer.GetCustomers();
        }

        public void InsertarCliente(Customer customer)
        {
            dataCustomer.InsertCustomer(customer);
        }
    }
}
