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
    /// Interaction logic for SearchPackagesView.xaml
    /// </summary>
    public partial class SearchPackagesView : UserControl
    {
        public SearchPackagesView()
        {
            InitializeComponent();
            LoadPackagesMaster();
        }

        List<Packages_Master> pack = new List<Packages_Master>();
        FunctionClass FC = new FunctionClass();
        public string _Package_ID, _Package_Name, _Days = "";

        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            if(listPackages.SelectedItem != null)
            {
                Packages_Master pm = (Packages_Master)listPackages.SelectedItem;
                _Package_ID = pm.Package_ID;
                _Package_Name = pm.Package_Name;

                var list = FC.GetSumDaysPerPackage(pm.Package_ID);
                _Days = list[0].No_Of_Days.ToString();

                Window.GetWindow(this).Close();
            }
        }

        private void TxtID_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = pack.FindAll(x => x.Package_ID.Contains(txtID.Text));
            listPackages.ItemsSource = null;
            listPackages.ItemsSource = tmplist;
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = pack.FindAll(x => x.Package_Name.Contains(txtName.Text));
            listPackages.ItemsSource = null;
            listPackages.ItemsSource = tmplist;
        }

        private void ListPackages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Packages_Master> packages = new List<Packages_Master>();
            Packages_Master pm = (Packages_Master)listPackages.SelectedItem;
            packages = FC.GetPackageMaster(pm.Package_ID);
            listPackageItems.ItemsSource = null;
            listPackageItems.ItemsSource = packages;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void LoadPackagesMaster()
        {
            pack = new List<Packages_Master>();
            pack = FC.GetDistrictMasterForList();
            listPackages.ItemsSource = null;
            listPackages.ItemsSource = pack;
        }
    }
}
