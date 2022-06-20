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
    /// Interaction logic for SearchExcursionView.xaml
    /// </summary>
    public partial class SearchExcursionView : UserControl
    {
        public SearchExcursionView()
        {
            InitializeComponent();
            LoadExcursionMaster();
        }

        List<Excursion_Master> ex = new List<Excursion_Master>();
        FunctionClass FC = new FunctionClass();
        public string _Excursion_ID = "";

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void TxtID_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = ex.FindAll(x => x.Excursion_ID.Contains(txtID.Text));
            listExcursion.ItemsSource = null;
            listExcursion.ItemsSource = tmplist;
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = ex.FindAll(x => x.Excursion_Name.Contains(txtName.Text));
            listExcursion.ItemsSource = null;
            listExcursion.ItemsSource = tmplist;
        }

        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            Excursion_Master em = (Excursion_Master)listExcursion.SelectedItem;
            _Excursion_ID = em.Excursion_ID;

            Window.GetWindow(this).Close();
        }

        private void LoadExcursionMaster()
        {
            ex = new List<Excursion_Master>();
            ex = FC.GetExcursionMaster("");
            listExcursion.ItemsSource = null;
            listExcursion.ItemsSource = ex;
        }
    }
}
