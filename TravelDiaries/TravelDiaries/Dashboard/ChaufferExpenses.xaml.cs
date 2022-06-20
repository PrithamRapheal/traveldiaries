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
    /// Interaction logic for ChaufferExpenses.xaml
    /// </summary>
    public partial class ChaufferExpenses : UserControl
    {
        public ChaufferExpenses()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCHaufferExpenses();
        }

        private void LoadCHaufferExpenses()
        {
            try
            {
                FunctionClass FC = new FunctionClass();
                List<Tour_Master> tour = new List<Tour_Master>();
                ChaufferExpense.To = 100000;

                tour = FC.GetTourMaster("");
                decimal Total_Expenses = tour.Sum(x => x.Chauffer_Total);

                txtValue.Text = Total_Expenses.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
