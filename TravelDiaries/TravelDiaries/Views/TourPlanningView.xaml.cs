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
using TravelDiaries.Views.SearchViews;

namespace TravelDiaries.Views
{
    /// <summary>
    /// Interaction logic for TourPlanningView.xaml
    /// </summary>
    public partial class TourPlanningView : UserControl
    {
        List<Tour_Master> tour = new List<Tour_Master>();
        FunctionClass FC = new FunctionClass();
        private bool add = false;
        private string Cust_ID, Hotel_ID, Pack_ID, BB, HB, FB, RO, HOTEL_RATE, Days = "";

        public TourPlanningView()
        {
            InitializeComponent();
        }

        private void DisableObjects()
        {
            dtStart.IsEnabled = false;
            cmbChauffer.IsEnabled = false;
            btnAddCustomer.IsEnabled = false;
            btnAddPackage.IsEnabled = false;
            btnAddHotel.IsEnabled = false;
        }

        private void EnableObjects()
        {
            dtStart.IsEnabled = true;
            cmbChauffer.IsEnabled = true;
            btnAddCustomer.IsEnabled = true; 
            btnAddPackage.IsEnabled = true; 
            btnAddHotel.IsEnabled = true; 
        }

        private void ClearObjects()
        {
            txtTourID.Clear();
            txtPackageName.Clear();
            txtRate.Clear();
            txtCustomer.Clear();
            txtHotel.Clear();
            cmbBookingType.Text = string.Empty;
            cmbChauffer.Text = string.Empty;
            cmbRoomType.Text = string.Empty;
            dtStart.SelectedDate = DateTime.Now;
            tour = new List<Tour_Master>();
            add = false;
        }

        private bool checkEmptyFields()
        {
            if (txtPackageName.Text == string.Empty && txtCustomer.Text == string.Empty && txtHotel.Text == string.Empty && txtTourID.Text == string.Empty)
                return false;
            else
                return true;
        }

        private void LoadAllCombos()
        {
            List<CustomClass> roomtype = new List<CustomClass>();
            roomtype.Add(new CustomClass { Data = "Deluxe", Value = "Deluxe" });
            roomtype.Add(new CustomClass { Data = "Superior", Value = "Superior" });
            roomtype.Add(new CustomClass { Data = "Standard", Value = "Standard" });
            roomtype.Add(new CustomClass { Data = "Suite", Value = "Suite" });
            cmbRoomType.ItemsSource = null;
            cmbRoomType.ItemsSource = roomtype;
            cmbRoomType.DisplayMemberPath = "Data";
            cmbRoomType.SelectedValuePath = "Value";

            List<Chauffer_Master> chauf = new List<Chauffer_Master>();
            chauf = FC.GetChaufferMaster("");
            cmbChauffer.ItemsSource = null;
            cmbChauffer.ItemsSource = chauf;
            cmbChauffer.DisplayMemberPath = "Chauffer_Name";
            cmbChauffer.SelectedValuePath = "Chauffer_ID";

            List<CustomClass> booktype = new List<CustomClass>();
            booktype.Add(new CustomClass { Data = "Room Only", Value = "RO" });
            booktype.Add(new CustomClass { Data = "Bed & Breakfast", Value = "BB" });
            booktype.Add(new CustomClass { Data = "Half Board", Value = "HB" });
            booktype.Add(new CustomClass { Data = "Full Board", Value = "FB" });
            cmbBookingType.ItemsSource = null;
            cmbBookingType.ItemsSource = booktype;
            cmbBookingType.DisplayMemberPath = "Data";
            cmbBookingType.SelectedValuePath = "Value";
        }

        private void SaveTourPlanning()
        {
            if (checkEmptyFields())
            {
                if (listHotels.ItemsSource != null)
                {
                    if (add)
                    {
                        tour[0].Chauffer_Total = GetChauffeurRate();
                        tour[0].Excursion_Total = GetExcursionRate();
                        decimal hotel = tour.Sum(x => x.Hotel_Total);
                        tour[0].Total_Amount = (tour[0].Chauffer_Total + tour[0].Excursion_Total + hotel);
                        if (FC.SaveTourMaster(tour))
                        {
                            MessageBox.Show("Details Have Been Saved!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            //UserControl_Loaded(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Failed to Save!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        if (FC.UpdateTourMaster(tour))
                        {
                            MessageBox.Show("Details Have Been Updated!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                            //UserControl_Loaded(null, null);
                        }
                        else
                        {
                            MessageBox.Show("Failed to Update!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter atleast one item to create the hotels!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void BtnSearchTour_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow mast = new MasterWindow();
            SearchTourView stv = new SearchTourView();
            mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mast.WindowStyle = WindowStyle.None;
            mast.Height = 670;
            mast.Width = 1024;
            mast.ResizeMode = ResizeMode.NoResize;
            mast.Content = stv;
            mast.Title = "Tour Plans Search";
            mast.ShowDialog();

            if (stv._Tour_ID != "")
            {
                LoadTourPlans(stv._Tour_ID);
            }
        }

        private void LoadTourPlans(string ID)
        {
            tour = new List<Tour_Master>();
            tour = FC.GetTourMaster(ID);
            txtTourID.Text = tour[0].Hotel_ID;
            txtPackageName.Text = tour[0].Package_Name;

            txtCustomer.Text = tour[0].Customer_Name;
            listPackages.ItemsSource = null;
            listPackages.ItemsSource = tour;

            listHotels.ItemsSource = null;
            listHotels.ItemsSource = tour;
        }

        private string GenerateAutoID()
        {
            DBClass db = new DBClass();
            string strqry = "select Count(*) from Tour_Master";
            int list = db.ReturnCount(strqry);
            list += 1;
            int x = 8;
            string _prefix = "TR";
            int y = x - (list.ToString().Length + _prefix.Length);

            var builder = new StringBuilder();
            for (int i = 0; i < y; i++)
            {
                builder.Append('0');
            }
            builder.Append(list);
            string pocode = _prefix + builder.ToString();

            return Convert.ToString(pocode);
        }

        private void ListPackages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAddHotel_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow mast = new MasterWindow();
            SearchHotelView stv = new SearchHotelView();
            mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mast.WindowStyle = WindowStyle.None;
            mast.Height = 670;
            mast.Width = 1024;
            mast.ResizeMode = ResizeMode.NoResize;
            mast.Content = stv;
            mast.Title = "Hotel Search";
            mast.ShowDialog();

            if (stv._Hotel_ID != "")
            {
                Hotel_ID = stv._Hotel_ID;
                txtHotel.Text = stv._Hotel_Name;
                cmbRoomType.SelectedValue = stv._Room_Type;
                //LoadTourPlans(stv._Tour_ID);
            }
        }

        private void BtnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow mast = new MasterWindow();
            SearchCustomerView stv = new SearchCustomerView();
            mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mast.WindowStyle = WindowStyle.None;
            mast.Height = 670;
            mast.Width = 1024;
            mast.ResizeMode = ResizeMode.NoResize;
            mast.Content = stv;
            mast.Title = "Customer Search";
            mast.ShowDialog();

            if (stv._Customer_ID != "")
            {
                Cust_ID = stv._Customer_ID;
                txtCustomer.Text = stv._Customer_Name;
            }
        }

        private void BtnAddPackage_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow mast = new MasterWindow();
            SearchPackagesView stv = new SearchPackagesView();
            mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mast.WindowStyle = WindowStyle.None;
            mast.Height = 670;
            mast.Width = 1024;
            mast.ResizeMode = ResizeMode.NoResize;
            mast.Content = stv;
            mast.Title = "Packages Search";
            mast.ShowDialog();

            if (stv._Package_ID != "")
            {
                Pack_ID = stv._Package_ID;
                txtPackageName.Text = stv._Package_Name;
                Days = stv._Days;

                List<Packages_Master> pack = new List<Packages_Master>();
                pack = FC.GetPackageMaster(stv._Package_ID);
                listPackages.ItemsSource = null;
                listPackages.ItemsSource = pack;
            }
        }

        private decimal GetChauffeurRate()
        {
            decimal Chauffer_Rate = 0;
            List<Chauffer_Master> chf = new List<Chauffer_Master>();
            chf = FC.GetChaufferMaster(cmbChauffer.SelectedValue.ToString());
            if (chf.Count > 0)
            {
                Chauffer_Rate = chf[0].Day_Rate * decimal.Parse(Days);
                return Chauffer_Rate;
            }
            else
                return Chauffer_Rate;
        }

        private decimal GetExcursionRate()
        {
            decimal Excursion_Rate = 0;
            List<Excursion_Master> ex = new List<Excursion_Master>();
            ex = FC.GetExcursionRatesPerPackage(Pack_ID);
            if(ex.Count > 0)
            {
                return Excursion_Rate = ex.Sum(x => x.Excursion_Rate);
            }
            else
                return Excursion_Rate;
        }

        private void BtnAddToHotelGrid_Click(object sender, RoutedEventArgs e)
        {
            if(txtHotel.Text != string.Empty || cmbBookingType.SelectedItem != null || txtHotelDays.Text != string.Empty)
            {
                if (tour.Count == 0)
                {
                    tour = new List<Tour_Master>();
                    tour.Add(new Tour_Master
                    {
                        Tour_ID = txtTourID.Text,
                        Booking_Type = cmbBookingType.SelectedValue.ToString(),
                        Chauffer_ID = cmbChauffer.SelectedValue.ToString(),
                        Chauffer_Name = cmbChauffer.Text,
                        // Chauffer_Total = GetChauffeurRate(),
                        Customer_Code = Cust_ID,
                        Customer_Name = txtCustomer.Text,
                        // Excursion_Total = GetExcursionRate(),
                        Hotel_ID = Hotel_ID,
                        Hotel_Name = txtHotel.Text,
                        Hotel_Total = decimal.Parse(txtHotelDays.Text) * decimal.Parse(txtRate.Text),
                        No_Of_Days = int.Parse(Days),
                        Package_ID = Pack_ID,
                        Package_Name = txtPackageName.Text,
                        Room_Type = cmbRoomType.SelectedValue.ToString(),
                        Start_Date = dtStart.SelectedDate.Value,
                        //Total_Amount = getTotalAmount(),
                        Tour_Status = 1
                    });

                    listHotels.ItemsSource = null;
                    listHotels.ItemsSource = tour;
                }
                else
                {
                    tour.Add(new Tour_Master
                    {
                        Tour_ID = txtTourID.Text,
                        Booking_Type = cmbBookingType.SelectedValue.ToString(),
                        Chauffer_ID = cmbChauffer.SelectedValue.ToString(),
                        Chauffer_Name = cmbChauffer.Text,
                        // Chauffer_Total = GetChauffeurRate(),
                        Customer_Code = Cust_ID,
                        Customer_Name = txtCustomer.Text,
                        // Excursion_Total = GetExcursionRate(),
                        Hotel_ID = Hotel_ID,
                        Hotel_Name = txtHotel.Text,
                        Hotel_Total = decimal.Parse(txtHotelDays.Text) * decimal.Parse(txtRate.Text),
                        No_Of_Days = int.Parse(txtHotelDays.Text),
                        Package_ID = Pack_ID,
                        Package_Name = txtPackageName.Text,
                        Room_Type = cmbRoomType.SelectedValue.ToString(),
                        Start_Date = dtStart.SelectedDate.Value,
                        //Total_Amount = getTotalAmount(),
                        Tour_Status = 1
                    });

                    listHotels.ItemsSource = null;
                    listHotels.ItemsSource = tour;
                }
            }
        }

        private void CmbBookingType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbBookingType.SelectedValue.ToString() != null && cmbRoomType.SelectedValue.ToString() != null)
            {
                List<Hotel_Master> hotel = new List<Hotel_Master>();
                hotel = FC.GetRatesperType(Hotel_ID, cmbRoomType.SelectedValue.ToString()); 

                if(hotel.Count > 0)
                {
                    if (cmbBookingType.SelectedValue.ToString() == "RO")
                    {
                        HOTEL_RATE = hotel[0].RO_Rate.ToString();
                    }
                    else if (cmbBookingType.SelectedValue.ToString() == "BB")
                    {
                        HOTEL_RATE = hotel[0].BB_Rate.ToString();
                    }
                    else if (cmbBookingType.SelectedValue.ToString() == "HB")
                    {
                        HOTEL_RATE = hotel[0].HB_Rate.ToString();
                    }
                    else
                    {
                        HOTEL_RATE = hotel[0].FB_Rate.ToString();
                    }

                    txtRate.Text = HOTEL_RATE;
                }
                else
                {
                    MessageBox.Show("No rates for the selected room type", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            }
        }

        private void BtnRemoveFromHotelGrid_Click(object sender, RoutedEventArgs e)
        {
            if (listHotels.SelectedItem != null)
            {
                tour.Remove((Tour_Master)listHotels.SelectedItem);
                listHotels.ItemsSource = null;
                listHotels.ItemsSource = tour;
            }
            else
            {
                MessageBox.Show("Select a row to remove!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearObjects();
                txtTourID.Text = GenerateAutoID();
                EnableObjects();
                LoadAllCombos();
                add = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkEmptyFields())
                {
                    EnableObjects();
                    txtTourID.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("No record to edit! Search for a record to edit.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkEmptyFields())
                {
                    if (MessageBox.Show("Are You Sure?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        return;
                    }
                    else
                    {
                        if (FC.DeleteTourMaster(txtTourID.Text))
                        {
                            MessageBox.Show("Delete Success!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                           
                        }
                        else
                        {
                            MessageBox.Show("Save Failed!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No record to delete! Search for a record to edit.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (add)
                {
                    if (validateUserID(txtTourID.Text))
                    {
                        SaveTourPlanning();
                    }
                    else
                    {
                        MessageBox.Show("Tour ID already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    SaveTourPlanning();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private bool validateUserID(string ID)
        {
            List<Tour_Master> tour_mast = new List<Tour_Master>();
            tour_mast = FC.GetTourMaster(ID);
            if (tour_mast.Count > 0)
                return false;
            else
                return true;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
