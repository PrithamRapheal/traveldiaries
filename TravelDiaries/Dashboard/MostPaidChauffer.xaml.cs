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
    /// Interaction logic for MostPaidChauffer.xaml
    /// </summary>
    public partial class MostPaidChauffer : UserControl
    {
        public MostPaidChauffer()
        {
            InitializeComponent();
        }

        public SeriesCollection SeriesCollection { get; private set; }

        private void LoadChaufferbyPay()
        {
            try
            {
                DataContext = null;
                SeriesCollection = new SeriesCollection();
                FunctionClass FC = new FunctionClass();
                List<Chauffer_Master> cust = new List<Chauffer_Master>();

                cust = FC.getMostPaidChauffer();

                foreach (var item in cust)
                {
                    PieSeries set = new PieSeries();
                    set.Title = item.Chauffer_Name;
                    set.Values = new ChartValues<ObservableValue> { new ObservableValue(double.Parse(item.Day_Rate.ToString())) };
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadChaufferbyPay();
        }
    }
}
