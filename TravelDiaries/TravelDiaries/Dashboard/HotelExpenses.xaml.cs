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
    /// Interaction logic for HotelExpenses.xaml
    /// </summary>
    public partial class HotelExpenses : UserControl
    {
        public HotelExpenses()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadHotelExpenses();
        }

        private void LoadHotelExpenses()
        {
            try
            {
                FunctionClass FC = new FunctionClass();
                List<Tour_Master> tour = new List<Tour_Master>();
                HotelExpense.To = 1000000;

                tour = FC.GetTourMaster("");
                decimal Total_Expenses = tour.Sum(x => x.Hotel_Total);

                txtValue.Text = Total_Expenses.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
