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

namespace TravelDiaries.Views
{
    /// <summary>
    /// Interaction logic for MainFooterView.xaml
    /// </summary>
    public partial class MainFooterView : UserControl
    {
        public MainFooterView()
        {
            InitializeComponent();
        }

        private void BtnHotel_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow report = new MasterWindow();
            ReportsView rv = new ReportsView("Hotel_Master");
            report.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            report.WindowStyle = WindowStyle.None;
            report.Height = 768;
            report.Width = 1024;
            report.ResizeMode = ResizeMode.NoResize;
            report.Content = rv;
            report.Title = "Report View";
            report.ShowDialog();
        }

        private void BtnCustomer_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow report = new MasterWindow();
            ReportsView rv = new ReportsView("Customer_Master");
            report.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            report.WindowStyle = WindowStyle.None;
            report.Height = 768;
            report.Width = 1024;
            report.ResizeMode = ResizeMode.NoResize;
            report.Content = rv;
            report.Title = "Report View";
            report.ShowDialog();
        }

        private void BtnTour_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow report = new MasterWindow();
            ReportsView rv = new ReportsView("Tour_Master");
            report.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            report.WindowStyle = WindowStyle.None;
            report.Height = 768;
            report.Width = 1024;
            report.ResizeMode = ResizeMode.NoResize;
            report.Content = rv;
            report.Title = "Report View";
            report.ShowDialog();
        }

        private void BtnChauffer_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow report = new MasterWindow();
            ReportsView rv = new ReportsView("Chauffer_Master");
            report.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            report.WindowStyle = WindowStyle.None;
            report.Height = 768;
            report.Width = 1024;
            report.ResizeMode = ResizeMode.NoResize;
            report.Content = rv;
            report.Title = "Report View";
            report.ShowDialog();
        }

        private void BtnPackages_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow report = new MasterWindow();
            ReportsView rv = new ReportsView("Packages_Master");
            report.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            report.WindowStyle = WindowStyle.None;
            report.Height = 768;
            report.Width = 1024;
            report.ResizeMode = ResizeMode.NoResize;
            report.Content = rv;
            report.Title = "Report View";
            report.ShowDialog();
        }

        private void BtnExcursion_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow report = new MasterWindow();
            ReportsView rv = new ReportsView("Excursion_Master");
            report.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            report.WindowStyle = WindowStyle.None;
            report.Height = 768;
            report.Width = 1024;
            report.ResizeMode = ResizeMode.NoResize;
            report.Content = rv;
            report.Title = "Report View";
            report.ShowDialog();
        }

        private void BtnChaufferExpenses_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow report = new MasterWindow();
            ReportsView rv = new ReportsView("Chauffer_Expenses");
            report.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            report.WindowStyle = WindowStyle.None;
            report.Height = 768;
            report.Width = 1024;
            report.ResizeMode = ResizeMode.NoResize;
            report.Content = rv;
            report.Title = "Report View";
            report.ShowDialog();
        }

        private void BtnExcursionExpenses_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow report = new MasterWindow();
            ReportsView rv = new ReportsView("Excursion_Expenses");
            report.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            report.WindowStyle = WindowStyle.None;
            report.Height = 768;
            report.Width = 1024;
            report.ResizeMode = ResizeMode.NoResize;
            report.Content = rv;
            report.Title = "Report View";
            report.ShowDialog();
        }

        private void BtnTourExpenses_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow report = new MasterWindow();
            ReportsView rv = new ReportsView("Tour_Expenses");
            report.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            report.WindowStyle = WindowStyle.None;
            report.Height = 768;
            report.Width = 1024;
            report.ResizeMode = ResizeMode.NoResize;
            report.Content = rv;
            report.Title = "Report View";
            report.ShowDialog();
        }

        private void BtnTourInvocie_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow report = new MasterWindow();
            ReportsView rv = new ReportsView("Tour_Invoice");
            report.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            report.WindowStyle = WindowStyle.None;
            report.Height = 768;
            report.Width = 1024;
            report.ResizeMode = ResizeMode.NoResize;
            report.Content = rv;
            report.Title = "Report View";
            report.ShowDialog();
        }

        private void BtnHotelExpenses_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow report = new MasterWindow();
            ReportsView rv = new ReportsView("Hotel_Expenses");
            report.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            report.WindowStyle = WindowStyle.None;
            report.Height = 768;
            report.Width = 1024;
            report.ResizeMode = ResizeMode.NoResize;
            report.Content = rv;
            report.Title = "Report View";
            report.ShowDialog();
        }

        private void BtnEmailInvoice_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow report = new MasterWindow();
            EmailInvoiceView rv = new EmailInvoiceView();
            report.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            report.WindowStyle = WindowStyle.None;
            report.Height = 460;
            report.Width = 810;
            report.ResizeMode = ResizeMode.NoResize;
            report.Content = rv;
            report.Title = "Send Email View";
            report.ShowDialog();
        }
    }
}
