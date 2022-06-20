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
    /// Interaction logic for SearchCountryView.xaml
    /// </summary>
    public partial class SearchCountryView : UserControl
    {
        public SearchCountryView()
        {
            InitializeComponent();
            LoadCountryMaster();
        }

        List<Country_Master> count = new List<Country_Master>();
        FunctionClass FC = new FunctionClass();
        public string _Country_ID = "";

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = count.FindAll(x => x.Country_Name.Contains(txtName.Text));
            listCountry.ItemsSource = null;
            listCountry.ItemsSource = tmplist;
        }

        private void TxtID_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = count.FindAll(x => x.Country_ID.Contains(txtID.Text));
            listCountry.ItemsSource = null;
            listCountry.ItemsSource = tmplist;
        }

        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            Country_Master cm = (Country_Master)listCountry.SelectedItem;
            _Country_ID = cm.Country_ID;

            Window.GetWindow(this).Close();
        }

        private void LoadCountryMaster()
        {
            count = new List<Country_Master>();
            count = FC.GetCountryMaster("");
            listCountry.ItemsSource = null;
            listCountry.ItemsSource = count;
        }
    }
}
