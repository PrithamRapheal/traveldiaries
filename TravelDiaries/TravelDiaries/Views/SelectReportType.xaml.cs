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
    /// Interaction logic for SelectReportType.xaml
    /// </summary>
    public partial class SelectReportType : UserControl
    {
        public SelectReportType()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMasterReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WindowFooter.gridMasterReports.Visibility == Visibility.Hidden)
                {
                    WindowFooter.gridInvoicesReport.Visibility = Visibility.Hidden;
                    WindowFooter.gridExpensesReports.Visibility = Visibility.Hidden;
                    WindowFooter.gridMasterReports.Visibility = Visibility.Visible;
                }
                else
                {
                    WindowFooter.gridMasterReports.Visibility = Visibility.Hidden;
                }
            }
            catch(Exception ee) { MessageBox.Show(ee.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WindowFooter.gridInvoicesReport.Visibility == Visibility.Hidden)
                {
                    WindowFooter.gridMasterReports.Visibility = Visibility.Hidden;
                    WindowFooter.gridExpensesReports.Visibility = Visibility.Hidden;
                    WindowFooter.gridInvoicesReport.Visibility = Visibility.Visible;
                }
                else
                {
                    WindowFooter.gridInvoicesReport.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ee) { MessageBox.Show(ee.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnExpenses_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WindowFooter.gridExpensesReports.Visibility == Visibility.Hidden)
                {
                    WindowFooter.gridMasterReports.Visibility = Visibility.Hidden;
                    WindowFooter.gridInvoicesReport.Visibility = Visibility.Hidden;
                    WindowFooter.gridExpensesReports.Visibility = Visibility.Visible;
                }
                else
                {
                    WindowFooter.gridExpensesReports.Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ee) { MessageBox.Show(ee.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
