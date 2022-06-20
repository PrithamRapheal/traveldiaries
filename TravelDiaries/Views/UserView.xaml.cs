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
using TravelDiaries.Views.SearchViews;

namespace TravelDiaries.Views
{
    /// <summary>
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        List<User_Master> user = new List<User_Master>();
        FunctionClass FC = new FunctionClass();
        private bool add = false;

        public UserView()
        {
            InitializeComponent();
        }

        private void DisableObjects()
        {
            txtUserID.IsEnabled = false;
            txtUserName.IsEnabled = false;
            txtPassword.IsEnabled = false;
            cmbUserType.IsEnabled = false;
        }

        private void EnableObjects()
        {
            txtUserID.IsEnabled = true;
            txtUserName.IsEnabled = true;
            txtPassword.IsEnabled = true;
            cmbUserType.IsEnabled = true;
        }

        private void ClearObjects()
        {
            txtUserID.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            cmbUserType.Text = string.Empty;
            user = new List<User_Master>();
            add = false;
        }

        private bool checkEmptyFields()
        {
            if (txtUserID.Text == string.Empty && txtUserName.Text == string.Empty && txtPassword.Text == string.Empty && cmbUserType.Text == string.Empty)
                return false;
            else
                return true; 
        }

        private void SaveUser()
        {
            if (checkEmptyFields())
            {
                if (add)
                {
                    user = new List<User_Master>();
                    user.Add(new User_Master
                    {
                        User_ID = txtUserID.Text,
                        User_Password = txtPassword.Text,
                        User_Name = txtUserName.Text,
                        User_Type = cmbUserType.SelectedValue.ToString()
                    });

                    if(FC.SaveUserMaster(user))
                    {
                        MessageBox.Show("Details Have Been Saved!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        UserControl_Loaded(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Failed to Save!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    user = new List<User_Master>();
                    user.Add(new User_Master
                    {
                        User_ID = txtUserID.Text,
                        User_Password = txtPassword.Text,
                        User_Name = txtUserName.Text,
                        User_Type = cmbUserType.SelectedValue.ToString()
                    });

                    if (FC.UpdateUserMaster(user))
                    {
                        MessageBox.Show("Details Have Been Updated!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        UserControl_Loaded(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Failed to Update!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty Fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void LoadCombos()
        {
            List<CustomClass> usertype = new List<CustomClass>();
            usertype.Add(new CustomClass { Value = "Admin", Data = "Admin" });
            usertype.Add(new CustomClass { Value = "Accounts", Data = "Accounts" });
            usertype.Add(new CustomClass { Value = "Receptionist", Data = "Receptionist" });
            cmbUserType.ItemsSource = null;
            cmbUserType.ItemsSource = usertype;
            cmbUserType.DisplayMemberPath = "Data";
            cmbUserType.SelectedValuePath = "Value";
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearObjects();
                txtUserID.Focus();
                EnableObjects();
                add = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkEmptyFields())
                {
                    EnableObjects();
                    txtUserID.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("No record to edit! Search for a record to edit.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkEmptyFields())
                {
                    if (MessageBox.Show("Are You Sure?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        return;
                    }
                    else
                    {
                        if (FC.DeleteUserMaster(txtUserID.Text))
                        {
                            MessageBox.Show("Delete Success!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                            UserControl_Loaded(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Save Failed!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No record to delete! Search for a record to edit.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (add)
                {
                    if (validateUserID(txtUserID.Text))
                    {
                        SaveUser();
                    }
                    else
                    {
                        MessageBox.Show("User ID already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    SaveUser();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private bool validateUserID(string ID)
        {
            user = new List<User_Master>();
            user = FC.GetUserMaster(ID);
            if (user.Count > 0)
                return false;
            else
                return true;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ClearObjects();
            DisableObjects();
            LoadCombos();
        }

        private void BtnSearchUser_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow mast = new MasterWindow();
            SearchUserView user = new SearchUserView();
            mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mast.WindowStyle = WindowStyle.None;
            mast.Height = 600;
            mast.Width = 1024;
            mast.ResizeMode = ResizeMode.NoResize;
            mast.Content = user;
            mast.Title = "User Search";
            mast.ShowDialog();

            if(user._userID != "")
            {
                LoadUsers(user._userID);
            }
        }

        private void LoadUsers(string ID)
        {
            user = new List<User_Master>();
            user = FC.GetUserMaster(ID);
            txtUserID.Text = user[0].User_ID; 
            txtUserName.Text = user[0].User_Name; 
            txtPassword.Text = user[0].User_Password; 
            cmbUserType.SelectedValue = user[0].User_Type; 
        }
    }
}
