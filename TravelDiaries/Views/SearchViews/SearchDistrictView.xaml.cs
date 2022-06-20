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
    /// Interaction logic for SearchDistrictView.xaml
    /// </summary>
    public partial class SearchDistrictView : UserControl
    {
        public SearchDistrictView()
        {
            InitializeComponent();
            LoadDistrictMaster();
        }

        List<District_Master> dist = new List<District_Master>();
        FunctionClass FC = new FunctionClass();
        public string _District_ID = "";

        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            District_Master dm = (District_Master)listDistrict.SelectedItem;
            _District_ID = dm.District_ID;

            Window.GetWindow(this).Close();
        }

        private void TxtID_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = dist.FindAll(x => x.District_ID.Contains(txtID.Text));
            listDistrict.ItemsSource = null;
            listDistrict.ItemsSource = tmplist;
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = dist.FindAll(x => x.District_Name.Contains(txtName.Text));
            listDistrict.ItemsSource = null;
            listDistrict.ItemsSource = tmplist;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void LoadDistrictMaster()
        {
            dist = new List<District_Master>();
            dist = FC.GetDistrictMaster("");
            listDistrict.ItemsSource = null;
            listDistrict.ItemsSource = dist;
        }
    }
}
