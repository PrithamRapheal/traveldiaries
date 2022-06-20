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
    /// Interaction logic for SearchUserView.xaml
    /// </summary>
    public partial class SearchUserView : UserControl
    {
        public SearchUserView()
        {
            InitializeComponent();
            LoadUserMaster();
        }

        List<User_Master> user = new List<User_Master>();
        FunctionClass FC = new FunctionClass();
        public string _userID = "";

        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            User_Master um = (User_Master)listUsers.SelectedItem;
            _userID = um.User_ID;

            Window.GetWindow(this).Close();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void TxtID_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = user.FindAll(x => x.User_ID.Contains(txtID.Text));
            listUsers.ItemsSource = null;
            listUsers.ItemsSource = tmplist;
        }

        private void TxtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tmplist = user.FindAll(x => x.User_Name.Contains(txtName.Text));
            listUsers.ItemsSource = null;
            listUsers.ItemsSource = tmplist;
        }

        private void LoadUserMaster()
        {
            user = new List<User_Master>();
            user = FC.GetUserMaster("");
            listUsers.ItemsSource = null;
            listUsers.ItemsSource = user;
        }
    }
}
