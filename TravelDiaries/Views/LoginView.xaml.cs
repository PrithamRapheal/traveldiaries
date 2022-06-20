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

namespace TravelDiaries.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtusername.Focus();
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                txtpassword.Focus();
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnLogin_Click(sender, e);
            }
            else if (e.Key == Key.Escape)
            {
                BtnClear_Click(sender, e);
            }
            else
            { return; }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            DBClass db = new DBClass();
            List<User_Master> user = new List<User_Master>();
            try
            {
                string Query = "Select * from User_Master where User_ID ='" + txtusername.Text + "' and User_Password ='" + txtpassword.Password.ToString() + "'";
                user = db.GetTableObject<User_Master>(Query);
                if (user.Count > 0)
                {
                    MessageBox.Show("Login Successfull " + user[0].User_Name + " !", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    Window parentwin = Window.GetWindow(this);
                    MainMenuWindow menu = new MainMenuWindow(user[0].User_Type);
                    parentwin.Close();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
            txtusername.Focus();
        }

        private void BtnNewUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MasterWindow mast = new MasterWindow();
                UserView user = new UserView();
            }
            catch (Exception ex) { MessageBox.Show("Error", ex.ToString(), MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
