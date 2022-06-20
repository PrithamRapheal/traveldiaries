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
    /// Interaction logic for SearchTourView.xaml
    /// </summary>
    public partial class SearchTourView : UserControl
    {
        public SearchTourView()
        {
            InitializeComponent();
            LoadTourMaster();
        }

        public string _Tour_ID = "";
        List<Tour_Master> tour = new List<Tour_Master>();
        FunctionClass FC = new FunctionClass();

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void TxtID_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = tour.FindAll(x => x.Tour_ID.Contains(txtID.Text));
            listTour.ItemsSource = null;
            listTour.ItemsSource = tmplist;
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = tour.FindAll(x => x.Customer_Name.Contains(txtName.Text));
            listTour.ItemsSource = null;
            listTour.ItemsSource = tmplist;
        }

        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            Tour_Master tm = (Tour_Master)listTour.SelectedItem;
            _Tour_ID = tm.Tour_ID;

            Window.GetWindow(this).Close();
        }


        private void LoadTourMaster()
        {
            tour = new List<Tour_Master>();
            tour = FC.GetTourMaster("");
            listTour.ItemsSource = null;
            listTour.ItemsSource = tour;
        }
    }
}
