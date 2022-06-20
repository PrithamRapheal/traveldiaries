using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelDiaries.Classes;

namespace TravelDiaries.Views.SearchViews
{
    /// <summary>
    /// Interaction logic for SearchCustomerView.xaml
    /// </summary>
    public partial class SearchCustomerView : UserControl
    {
        public SearchCustomerView()
        {
            InitializeComponent();
            LoadCustomerMaster();
        }

        List<Customer_Master> cust = new List<Customer_Master>();
        FunctionClass FC = new FunctionClass();
        public string _Customer_ID = "";
        public string _Customer_Name = "";

        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            Customer_Master cm = (Customer_Master)listCustomers.SelectedItem;
            _Customer_ID = cm.Customer_ID;
            _Customer_Name = cm.Customer_Name;

            Window.GetWindow(this).Close();
        }

        private void TxtID_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = cust.FindAll(x => x.Customer_ID.Contains(txtID.Text));
            listCustomers.ItemsSource = null;
            listCustomers.ItemsSource = tmplist;
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = cust.FindAll(x => x.Customer_Name.Contains(txtName.Text));
            listCustomers.ItemsSource = null;
            listCustomers.ItemsSource = tmplist;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void LoadCustomerMaster()
        {
            cust = new List<Customer_Master>();
            cust = FC.GetCustomerMaster("");
            listCustomers.ItemsSource = null;
            listCustomers.ItemsSource = cust;
        }
    }
}
