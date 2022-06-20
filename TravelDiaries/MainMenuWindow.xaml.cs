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
using System.Windows.Shapes;
using TravelDiaries.Views;

namespace TravelDiaries
{
    /// <summary>
    /// Interaction logic for MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public string _User_Type;
        public MainMenuWindow(string User_Type)
        {
            InitializeComponent();
            _User_Type = User_Type;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnBookTour_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(_User_Type == "Accounts")
                {
                    MessageBox.Show("Account users are not authorized to enter this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MasterWindow mast = new MasterWindow();
                    TourPlanningView tour = new TourPlanningView();
                    btnLogOut.Visibility = Visibility.Collapsed;
                    mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    mast.WindowStyle = WindowStyle.None;
                    mast.Height = 600;
                    mast.Width = 1024;
                    mast.ResizeMode = ResizeMode.NoResize;
                    mast.Content = tour;
                    mast.Title = "Tour Plan Master";
                    mast.ShowDialog();

                    btnLogOut.Visibility = Visibility.Visible;
                }   
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_User_Type == "Accounts" || _User_Type == "Receptionist")
                {
                    MessageBox.Show("Account and Receptionist users are not authorized to enter this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MasterWindow mast = new MasterWindow();
                    UserView user = new UserView();
                    btnLogOut.Visibility = Visibility.Collapsed;
                    mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    mast.WindowStyle = WindowStyle.None;
                    mast.Height = 600;
                    mast.Width = 1024;
                    mast.ResizeMode = ResizeMode.NoResize;
                    mast.Content = user;
                    mast.Title = "User Master";
                    mast.ShowDialog();

                    btnLogOut.Visibility = Visibility.Visible;
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnPackages_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_User_Type == "Accounts")
                {
                    MessageBox.Show("Account users are not authorized to enter this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MasterWindow mast = new MasterWindow();
                    PackagesView pack = new PackagesView();
                    btnLogOut.Visibility = Visibility.Collapsed;
                    mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    mast.WindowStyle = WindowStyle.None;
                    mast.Height = 600;
                    mast.Width = 1024;
                    mast.ResizeMode = ResizeMode.NoResize;
                    mast.Content = pack;
                    mast.Title = "Package Master";
                    mast.ShowDialog();

                    btnLogOut.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnChauffer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_User_Type == "Accounts")
                {
                    MessageBox.Show("Account users are not authorized to enter this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MasterWindow mast = new MasterWindow();
                    ChauffeurView chauf = new ChauffeurView();
                    btnLogOut.Visibility = Visibility.Collapsed;
                    mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    mast.WindowStyle = WindowStyle.None;
                    mast.Height = 650;
                    mast.Width = 1024;
                    mast.ResizeMode = ResizeMode.NoResize;
                    mast.Content = chauf;
                    mast.Title = "Chauffer Master";
                    mast.ShowDialog();

                    btnLogOut.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnHotel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_User_Type == "Accounts")
                {
                    MessageBox.Show("Account users are not authorized to enter this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MasterWindow mast = new MasterWindow();
                    HotelView chauf = new HotelView();
                    btnLogOut.Visibility = Visibility.Collapsed;
                    mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    mast.WindowStyle = WindowStyle.None;
                    mast.Height = 670;
                    mast.Width = 1024;
                    mast.ResizeMode = ResizeMode.NoResize;
                    mast.Content = chauf;
                    mast.Title = "Hotel Master";
                    mast.ShowDialog();

                    btnLogOut.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnExcursion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_User_Type == "Accounts")
                {
                    MessageBox.Show("Account users are not authorized to enter this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MasterWindow mast = new MasterWindow();
                    ExcursionView exc = new ExcursionView();
                    btnLogOut.Visibility = Visibility.Collapsed;
                    mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    mast.WindowStyle = WindowStyle.None;
                    mast.Height = 600;
                    mast.Width = 1024;
                    mast.ResizeMode = ResizeMode.NoResize;
                    mast.Content = exc;
                    mast.Title = "Excursion Master";
                    mast.ShowDialog();

                    btnLogOut.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_User_Type == "Accounts")
                {
                    MessageBox.Show("Account users are not authorized to enter this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MasterWindow mast = new MasterWindow();
                    CustomerView cust = new CustomerView();
                    btnLogOut.Visibility = Visibility.Collapsed;
                    mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    mast.WindowStyle = WindowStyle.None;
                    mast.Height = 600;
                    mast.Width = 1024;
                    mast.ResizeMode = ResizeMode.NoResize;
                    mast.Content = cust;
                    mast.Title = "Customer Master";
                    mast.ShowDialog();

                    btnLogOut.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnReports_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_User_Type == "Receptionist")
                {
                    MessageBox.Show("Receptionist users are not authorized to enter this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MasterWindow mast = new MasterWindow();
                    SelectReportType SRT = new SelectReportType();
                    btnLogOut.Visibility = Visibility.Collapsed;
                    mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    mast.WindowStyle = WindowStyle.None;
                    mast.Height = 650;
                    mast.Width = 850;
                    mast.ResizeMode = ResizeMode.NoResize;
                    mast.Content = SRT;
                    mast.Title = "Select Report Type";
                    mast.ShowDialog();

                    btnLogOut.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnOther_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_User_Type == "Accounts" || _User_Type == "Receptionist")
                {
                    MessageBox.Show("Account and Receptionist users are not authorized to enter this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MasterWindow mast = new MasterWindow();
                    CountryDistrictView CD = new CountryDistrictView();
                    btnLogOut.Visibility = Visibility.Collapsed;
                    mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    mast.WindowStyle = WindowStyle.None;
                    mast.Height = 700;
                    mast.Width = 1024;
                    mast.ResizeMode = ResizeMode.NoResize;
                    mast.Content = CD;
                    mast.Title = "Country & District Master";
                    mast.ShowDialog();

                    btnLogOut.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow log = new LoginWindow();
            Window.GetWindow(this).Close();
            log.Show();
        }

        private void BtnDashboard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ( _User_Type == "Receptionist")
                {
                    MessageBox.Show("Receptionist users are not authorized to enter this page!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    //MasterWindow mast = new MasterWindow();
                    DashboardWindow DB = new DashboardWindow();
                    btnLogOut.Visibility = Visibility.Collapsed;
                    //mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    //mast.WindowStyle = WindowStyle.None;
                    //mast.Height = 700;
                    //mast.Width = 1024;
                    //mast.ResizeMode = ResizeMode.NoResize;
                    //mast.Content = DB;
                    //mast.Title = "Dashboard";
                    DB.ShowDialog();

                    btnLogOut.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
