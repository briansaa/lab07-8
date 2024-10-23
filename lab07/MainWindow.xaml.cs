using Business;
using Data;
using Entity;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;


namespace Lab7
{
    public partial class MainWindow : Window
    {
        private BCustomer bCustomer = new BCustomer();
        private BProduct bProduct = new BProduct();

        public MainWindow()
        {
            InitializeComponent();
            LoadCustomers();
            LoadProducts();
        }

        private void LoadCustomers()
        {
            dgvCustomers.ItemsSource = bCustomer.ObtenerClientes();
        }

        private void LoadProducts()
        {
            DataTable products = bProduct.GetProducts();
            dgvProducts.ItemsSource = products.DefaultView;
        }

        private void InsertCustomerButton_Click(object sender, RoutedEventArgs e) 
        {
            Customer newCustomer = new Customer
            {
                Name = txtName.Text,     
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Active = (bool)chkActive.IsChecked  
            };

            bCustomer.InsertarCliente(newCustomer);

            LoadCustomers();
        }
    }
}