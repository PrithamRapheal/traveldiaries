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
    /// Interaction logic for SearchChauffeurView.xaml
    /// </summary>
    public partial class SearchChauffeurView : UserControl
    {
        public SearchChauffeurView()
        {
            InitializeComponent();
            LoadChaufferMaster();
        }

        public string _Chauffer_ID = "";
        List<Chauffer_Master> chauf = new List<Chauffer_Master>();
        FunctionClass FC = new FunctionClass();

        private void LoadChaufferMaster()
        {
            chauf = new List<Chauffer_Master>();
            chauf = FC.GetChaufferMaster("");
            listCHauffers.ItemsSource = null;
            listCHauffers.ItemsSource = chauf;
        }

        private void TxtID_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = chauf.FindAll(x => x.Chauffer_ID.Contains(txtID.Text));
            listCHauffers.ItemsSource = null;
            listCHauffers.ItemsSource = tmplist;
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = chauf.FindAll(x => x.Chauffer_Name.Contains(txtName.Text));
            listCHauffers.ItemsSource = null;
            listCHauffers.ItemsSource = tmplist;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            Chauffer_Master cm = (Chauffer_Master)listCHauffers.SelectedItem;
            _Chauffer_ID = cm.Chauffer_ID;

            Window.GetWindow(this).Close();
        }
    }
}
