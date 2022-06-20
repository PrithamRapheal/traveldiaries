using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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

namespace TravelDiaries.Dashboard
{
    /// <summary>
    /// Interaction logic for CustomerByCountry.xaml
    /// </summary>
    public partial class CustomerByCountry : UserControl
    {
        public SeriesCollection SeriesCollection { get; private set; }

        public CustomerByCountry()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomerbyCountryChart();
        }

        private void LoadCustomerbyCountryChart()
        {
            try
            {
                DataContext = null;
                SeriesCollection = new SeriesCollection();
                FunctionClass FC = new FunctionClass();
                List<Customer_Master> cust = new List<Customer_Master>();

                cust = FC.getCustomerbyCountry();

                foreach (var item in cust)
                {
                    PieSeries set = new PieSeries();
                    set.Title = item.Country;
                    set.Values = new ChartValues<ObservableValue> { new ObservableValue(double.Parse(item.Count.ToString())) };
                    set.DataLabels = true;
                    SeriesCollection.Add(set);
                }
                DataContext = this;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
