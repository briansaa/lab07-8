using Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business
{
    public class BProduct
    {
        private DProduct dProduct = new DProduct();

        public DataTable GetProducts()
        {
            return dProduct.GetProducts(); 
        }
    }
}