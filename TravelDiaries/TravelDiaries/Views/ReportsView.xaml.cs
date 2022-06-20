using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportsView : UserControl
    {
        FunctionClass FC = new FunctionClass();
        public string _Report_Type;
        public ReportsView(string Report_Type)
        {
            InitializeComponent();
            _Report_Type = Report_Type;

            switch (Report_Type)
            {
                case "Hotel_Master":
                    MasterFilter.Visibility = Visibility.Visible;
                    break;
                case "Customer_Master":
                    CustomerFilter.Visibility = Visibility.Visible;
                    LoadCustomerFilters();
                    break;
                case "Tour_Master":
                    TourExpenseFilter.Visibility = Visibility.Visible;
                    dtTourFrom.SelectedDate = DateTime.Now;
                    dtTourTo.SelectedDate = DateTime.Now;
                    break;
                case "Chauffer_Master":
                    MasterFilter.Visibility = Visibility.Visible;
                    break;
                case "Excursion_Master":
                    MasterFilter.Visibility = Visibility.Visible;
                    break;
                case "Packages_Master":
                    MasterFilter.Visibility = Visibility.Visible;
                    break;
                case "Tour_Expenses":
                    TourExpenseFilter.Visibility = Visibility.Visible;
                    dtTourFrom.SelectedDate = DateTime.Now;
                    dtTourTo.SelectedDate = DateTime.Now;
                    break;
                case "Chauffer_Expenses":
                    ChaufferExpenseFilter.Visibility = Visibility.Visible;
                    dtChaufFrom.SelectedDate = DateTime.Now;
                    dtChaufTo.SelectedDate = DateTime.Now;
                    LoadChauffer();
                    break;
                case "Excursion_Expenses":
                    ExcursionExpenseFilter.Visibility = Visibility.Visible;
                    dtExcFrom.SelectedDate = DateTime.Now;
                    dtExcTo.SelectedDate = DateTime.Now;
                    //LoadExcursion();
                    break;
                case "Hotel_Expenses":
                    HotelExpenseFilter.Visibility = Visibility.Visible;
                    dtHotelFrom.SelectedDate = DateTime.Now;
                    dtHotelTo.SelectedDate = DateTime.Now;
                    LoadHotel();
                    break;
                case "Tour_Invoice":
                    InvoiceExpenses.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        //Refresh Report View
        private void Refresh_Report_View()
        {
            reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 100;
            reportViewer.RefreshReport();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            switch(_Report_Type)
            {
                case "Hotel_Master":
                    Create_Hotel_Master_Report();
                    break;
                case "Customer_Master":
                    Create_Customer_Master_Report();
                    break;
                case "Tour_Master":
                    Create_Tour_Master_Report(dtTourFrom.SelectedDate.Value, dtTourTo.SelectedDate.Value, txtBookingID.Text);
                    break;
                case "Chauffer_Master":
                    Create_Chauffer_Master_Report();
                    break;
                case "Excursion_Master":
                    Create_Excursion_Master_Report();
                    break;
                case "Packages_Master":
                    Create_Packages_Master_Report();
                    break;
                case "Tour_Expenses":
                    Create_Tour_Expenses_Report(dtTourFrom.SelectedDate.Value, dtTourTo.SelectedDate.Value, txtBookingID.Text);
                    break;
                case "Chauffer_Expenses":
                    Create_Chauffer_Expenses_Report(dtChaufFrom.SelectedDate.Value, dtChaufTo.SelectedDate.Value, cmbChauffer.SelectedValue.ToString(), cmbChauffer.Text);
                    break;
                case "Hotel_Expenses":
                    Create_Hotel_Expenses_Report(dtHotelFrom.SelectedDate.Value, dtHotelTo.SelectedDate.Value, cmbHotel.SelectedValue.ToString(), cmbHotel.Text);
                    break;
                case "Excursion_Expenses":
                    Create_Excursion_Expenses_Report(dtExcFrom.SelectedDate.Value, dtExcTo.SelectedDate.Value);
                    break;
                case "Tour_Invoice":
                    if (txtTourIDInvoice.Text != string.Empty)
                    { Create_Tour_Invoice(txtTourIDInvoice.Text); }
                    break;
                default:
                    break;
            }
        }
        #region Function Methods
        private void LoadChauffer()
        {
            List<Chauffer_Master> chauf = new List<Chauffer_Master>();
            chauf = FC.GetChaufferMaster("");
            chauf.Insert(0, new Chauffer_Master { Chauffer_ID = "All", Chauffer_Name = "All" });
            cmbChauffer.ItemsSource = chauf;
            cmbChauffer.DisplayMemberPath = "Chauffer_Name";
            cmbChauffer.SelectedValuePath = "Chauffer_ID";
            cmbChauffer.SelectedIndex = 0;
        }

        private void LoadHotel()
        {
            List<Hotel_Master> hotel = new List<Hotel_Master>();
            hotel = FC.GetHotelMastForList();
            hotel.Insert(0, new Hotel_Master { Hotel_ID = "All", Hotel_Name = "All" });
            cmbHotel.ItemsSource = hotel;
            cmbHotel.DisplayMemberPath = "Hotel_Name";
            cmbHotel.SelectedValuePath = "Hotel_ID";
            cmbHotel.SelectedIndex = 0;
        }

        private void LoadCustomerFilters()
        {
            List<CustomClass> group = new List<CustomClass>();
            group.Add(new CustomClass { Value = "All", Data = "All" });
            group.Add(new CustomClass { Value = "LC", Data = "Local" });
            group.Add(new CustomClass { Value = "FR", Data = "Foreign" });
            cmbCustType.ItemsSource = group;
            cmbCustType.DisplayMemberPath = "Data";
            cmbCustType.SelectedValuePath = "Value";
            cmbCustType.SelectedIndex = 0;

            List<Country_Master> country = new List<Country_Master>();
            country = FC.GetCountryMaster("");
            country.Insert(0, new Country_Master { Country_ID = "All", Country_Name = "All" });
            cmbCustCountry.ItemsSource = country;
            cmbCustCountry.DisplayMemberPath = "Country_Name";
            cmbCustCountry.SelectedValuePath = "Country_ID";
            cmbCustCountry.SelectedIndex = 0;
        }
        #endregion

        private void Create_Tour_Invoice(string ID)
        {
            try
            {
                FunctionClass FC = new FunctionClass();
                reportViewer.Reset();
                DataTable dt1,dt2;
                List<Tour_Master> tour = new List<Tour_Master>();
                ReportParameter[] parameters;

                tour = FC.GetTourMaster(ID);
                dt1 = FC.Generate_Tour_Invoice(ID);
                dt2 = FC.Generate_Tour_Invoice_Package(tour[0].Package_ID);
              

                parameters = new ReportParameter[]
                {
                    new ReportParameter("header", "Tour Invoice"),
                    new ReportParameter("id", "Tour ID : " + tour[0].Tour_ID),
                    new ReportParameter("customer", "Customer Name : " + tour[0].Customer_Name),
                    new ReportParameter("date", "Tour Date : " + tour[0].Start_Date.ToShortDateString()),
                    new ReportParameter("chauffer", "Chauffer Name : " + tour[0].Chauffer_Name),
                    new ReportParameter("package", "Package Name : " + tour[0].Package_Name),
                    new ReportParameter("hotel",  tour[0].Hotel_Total.ToString()),
                    new ReportParameter("excursion",  tour[0].Excursion_Total.ToString()),
                    new ReportParameter("chauffer_total",  tour[0].Chauffer_Total.ToString()),
                    new ReportParameter("total",  tour[0].Total_Amount.ToString())
                };
                ReportDataSource ds1 = new ReportDataSource("DataSet1", dt1);
                ReportDataSource ds2 = new ReportDataSource("DataSet2", dt2);
                reportViewer.LocalReport.DataSources.Add(ds1);
                reportViewer.LocalReport.DataSources.Add(ds2);
                reportViewer.LocalReport.ReportEmbeddedResource = "TravelDiaries.Reports.InvoiceReports.TourInvoice.rdlc";
                reportViewer.LocalReport.SetParameters(parameters);
                Refresh_Report_View();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Create_Excursion_Expenses_Report(DateTime From, DateTime To)
        {
            try
            {
                FunctionClass FC = new FunctionClass();
                reportViewer.Reset();
                DataTable dt;
                ReportParameter[] parameters;

                dt = FC.Generate_Excursion_Expenses_Report(From, To);

                parameters = new ReportParameter[]
                {
                    new ReportParameter("header", "Excursion Expense Report"),
                    new ReportParameter("from", "Booking Date From : " + From.ToShortDateString()),
                    new ReportParameter("to", "Booking Date TO : " + From.ToShortDateString())
                };
                ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                reportViewer.LocalReport.DataSources.Add(ds);
                reportViewer.LocalReport.ReportEmbeddedResource = "TravelDiaries.Reports.ExpensesReports.ExcursionExpensesReport.rdlc";
                reportViewer.LocalReport.SetParameters(parameters);
                Refresh_Report_View();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Create_Chauffer_Expenses_Report(DateTime From, DateTime To, string ID, string Name)
        {
            try
            {
                FunctionClass FC = new FunctionClass();
                reportViewer.Reset();
                DataTable dt;
                ReportParameter[] parameters;
                string book;

                dt = FC.Generate_Chauffer_Expenses_Report(From, To, ID);

                parameters = new ReportParameter[]
                {
                    new ReportParameter("header", "Chauffer Expense Report"),
                    new ReportParameter("from", "Booking Date From : " + From.ToShortDateString()),
                    new ReportParameter("to", "Booking Date TO : " + From.ToShortDateString()),
                    new ReportParameter("id", "Chauffer ID : " + ID),
                    new ReportParameter("name", "Chauffer Name : " + Name)
                };
                ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                reportViewer.LocalReport.DataSources.Add(ds);
                reportViewer.LocalReport.ReportEmbeddedResource = "TravelDiaries.Reports.ExpensesReports.ChaufferExpensesReport.rdlc";
                reportViewer.LocalReport.SetParameters(parameters);
                Refresh_Report_View();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Create_Hotel_Expenses_Report(DateTime From, DateTime To, string ID, string Name)
        {
            try
            {
                FunctionClass FC = new FunctionClass();
                reportViewer.Reset();
                DataTable dt;
                ReportParameter[] parameters;

                dt = FC.Generate_Hotel_Expenses_Report(From, To, ID);

                parameters = new ReportParameter[]
                {
                    new ReportParameter("header", "Hotel Expense Report"),
                    new ReportParameter("from", "Booking Date From : " + From.ToShortDateString()),
                    new ReportParameter("to", "Booking Date TO : " + From.ToShortDateString()),
                    new ReportParameter("id", "Hotel ID : " + ID),
                    new ReportParameter("name", "Hotel Name : " + Name)
                };
                ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                reportViewer.LocalReport.DataSources.Add(ds);
                reportViewer.LocalReport.ReportEmbeddedResource = "TravelDiaries.Reports.ExpensesReports.HotelExpensesReport.rdlc";
                reportViewer.LocalReport.SetParameters(parameters);
                Refresh_Report_View();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Create_Tour_Expenses_Report(DateTime From, DateTime To, string ID)
        {
            try
            {
                FunctionClass FC = new FunctionClass();
                reportViewer.Reset();
                DataTable dt;
                ReportParameter[] parameters;
                string book;

                dt = FC.Generate_Tour_Master_Report(From, To, ID);
                if (ID == "")
                    book = "All";
                else
                    book = ID;

                parameters = new ReportParameter[]
                {
                    new ReportParameter("header", "Tour Expense Report"),
                    new ReportParameter("from", "Booking Date From : " + From.ToShortDateString()),
                    new ReportParameter("to", "Booking Date TO : " + From.ToShortDateString()),
                    new ReportParameter("id", "Booking ID : " + book)
                };
                ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                reportViewer.LocalReport.DataSources.Add(ds);
                reportViewer.LocalReport.ReportEmbeddedResource = "TravelDiaries.Reports.ExpensesReports.TourExpensesReport.rdlc";
                reportViewer.LocalReport.SetParameters(parameters);
                Refresh_Report_View();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Create_Tour_Master_Report(DateTime From, DateTime To, string ID)
        {
            try
            {
                FunctionClass FC = new FunctionClass();
                reportViewer.Reset();
                DataTable dt;
                ReportParameter[] parameters;
                string book;

                dt = FC.Generate_Tour_Master_Report(From, To, ID);
                if (ID == "")
                    book = "All";
                else
                    book = ID;

                parameters = new ReportParameter[]
                {
                    new ReportParameter("header", "Tour Report"),
                    new ReportParameter("from", "Booking Date From : " + From.ToShortDateString()),
                    new ReportParameter("to", "Booking Date TO : " + From.ToShortDateString()),
                    new ReportParameter("id", "Booking ID : " + book)
                };
                ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                reportViewer.LocalReport.DataSources.Add(ds);
                reportViewer.LocalReport.ReportEmbeddedResource = "TravelDiaries.Reports.MasterReports.TourMasterReport.rdlc";
                reportViewer.LocalReport.SetParameters(parameters);
                Refresh_Report_View();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Create_Hotel_Master_Report()
        {
            try
            {
                FunctionClass FC = new FunctionClass();
                reportViewer.Reset();
                DataTable dt;
                ReportParameter[] parameters;

                dt = FC.Generate_Hotel_Master_Report();

                parameters = new ReportParameter[]
                {
                    new ReportParameter("header", "Hotel Report"),
                };
                ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                reportViewer.LocalReport.DataSources.Add(ds);
                reportViewer.LocalReport.ReportEmbeddedResource = "TravelDiaries.Reports.MasterReports.HotelMasterReport.rdlc";
                reportViewer.LocalReport.SetParameters(parameters);
                Refresh_Report_View();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Create_Customer_Master_Report()
        {
            try
            {
                FunctionClass FC = new FunctionClass();
                reportViewer.Reset();
                DataTable dt;
                ReportParameter[] parameters;

                dt = FC.Generate_Customer_Master_Report(cmbCustType.SelectedValue.ToString(), cmbCustCountry.SelectedValue.ToString());

                parameters = new ReportParameter[]
                {
                    new ReportParameter("header", "Customer Report"),
                    new ReportParameter("CustType", "Customer Type : " + cmbCustType.Text),
                    new ReportParameter("CustCountry", "Country : " + cmbCustCountry.Text),
                };
                ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                reportViewer.LocalReport.DataSources.Add(ds);
                reportViewer.LocalReport.ReportEmbeddedResource = "TravelDiaries.Reports.MasterReports.CustomerMasterReport.rdlc";
                reportViewer.LocalReport.SetParameters(parameters);
                Refresh_Report_View();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Create_Chauffer_Master_Report()
        {
            try
            {
                FunctionClass FC = new FunctionClass();
                reportViewer.Reset();
                DataTable dt;
                ReportParameter[] parameters;

                dt = FC.Generate_Chauffer_Master_Report();

                parameters = new ReportParameter[]
                {
                    new ReportParameter("header", "Chauffer Report"),
                };
                ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                reportViewer.LocalReport.DataSources.Add(ds);
                reportViewer.LocalReport.ReportEmbeddedResource = "TravelDiaries.Reports.MasterReports.ChaufferMasterReport.rdlc";
                reportViewer.LocalReport.SetParameters(parameters);
                Refresh_Report_View();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Create_Excursion_Master_Report()
        {
            try
            {
                FunctionClass FC = new FunctionClass();
                reportViewer.Reset();
                DataTable dt;
                ReportParameter[] parameters;

                dt = FC.Generate_Excursion_Master_Report();

                parameters = new ReportParameter[]
                {
                    new ReportParameter("header", "Excursion Report"),
                };
                ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                reportViewer.LocalReport.DataSources.Add(ds);
                reportViewer.LocalReport.ReportEmbeddedResource = "TravelDiaries.Reports.MasterReports.ExcursionMasterReport.rdlc";
                reportViewer.LocalReport.SetParameters(parameters);
                Refresh_Report_View();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Create_Packages_Master_Report()
        {
            try
            {
                FunctionClass FC = new FunctionClass();
                reportViewer.Reset();
                DataTable dt;
                ReportParameter[] parameters;

                dt = FC.Generate_Packages_Master_Report();

                parameters = new ReportParameter[]
                {
                    new ReportParameter("header", "Packages Report"),
                };
                ReportDataSource ds = new ReportDataSource("DataSet1", dt);
                reportViewer.LocalReport.DataSources.Add(ds);
                reportViewer.LocalReport.ReportEmbeddedResource = "TravelDiaries.Reports.MasterReports.PackagesMasterReport.rdlc";
                reportViewer.LocalReport.SetParameters(parameters);
                Refresh_Report_View();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtBookingID_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F1)
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
                    txtBookingID.Text = stv._Tour_ID;
                }
            }
        }

        private void TxtTourIDInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
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
                    txtTourIDInvoice.Text = stv._Tour_ID;
                }
            }
        }
    }
}
