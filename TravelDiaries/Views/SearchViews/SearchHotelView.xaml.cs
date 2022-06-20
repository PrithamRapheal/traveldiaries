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
    /// Interaction logic for SearchHotelView.xaml
    /// </summary>
    public partial class SearchHotelView : UserControl
    {
        public SearchHotelView()
        {
            InitializeComponent();
            LoadHotels();
        }

        List<Hotel_Master> hotel = new List<Hotel_Master>();
        FunctionClass FC = new FunctionClass();
        public string _Hotel_ID, _Hotel_Name, _Room_Type, _BB, _HB, _FB, _RO = "";

        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            if (listHotel.SelectedItem != null)
            {
                Hotel_Master pm = (Hotel_Master)listHotel.SelectedItem;
                _Hotel_ID = pm.Hotel_ID;
                _Hotel_Name = pm.Hotel_Name;
                _Room_Type = pm.Room_Type;
                _BB = pm.BB_Rate.ToString();
                _HB = pm.HB_Rate.ToString();
                _FB = pm.FB_Rate.ToString();
                _RO = pm.RO_Rate.ToString();

                Window.GetWindow(this).Close();
            }
        }

        private void TxtID_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = hotel.FindAll(x => x.Hotel_ID.Contains(txtID.Text));
            listHotel.ItemsSource = null;
            listHotel.ItemsSource = tmplist;
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = hotel.FindAll(x => x.Hotel_Name.Contains(txtName.Text));
            listHotel.ItemsSource = null;
            listHotel.ItemsSource = tmplist;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void LoadHotels()
        {
            hotel = new List<Hotel_Master>();
            hotel = FC.GetHotelMastForList();
            listHotel.ItemsSource = null;
            listHotel.ItemsSource = hotel;
        }

        private void ListHotel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Hotel_Master> hotels = new List<Hotel_Master>();
            Hotel_Master pm = (Hotel_Master)listHotel.SelectedItem;
            hotels = FC.GetHotelMaster(pm.Hotel_ID);
            listRates.ItemsSource = null;
            listRates.ItemsSource = hotels;
        }
    }
}
