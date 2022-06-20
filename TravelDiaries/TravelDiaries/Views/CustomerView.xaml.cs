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
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        public CustomerView()
        {
            InitializeComponent();
        }

        List<Customer_Master> cust = new List<Customer_Master>();
        FunctionClass FC = new FunctionClass();
        private bool add = false, recall = false;
        private int _ID;

        private void DisableObjects()
        {
            txtCustID.IsEnabled = false;
            txtCustName.IsEnabled = false;
            txtCustAddress.IsEnabled = false;
            txtMobile.IsEnabled = false;
            txtEmail.IsEnabled = false;
            cmbGroup.IsEnabled = false;
            cmbCountry.IsEnabled = false;
            dtDOB.IsEnabled = false;
        }

        private void EnableObjects()
        {
            txtCustName.IsEnabled = true;
            txtCustAddress.IsEnabled = true;
            txtMobile.IsEnabled = true;
            txtEmail.IsEnabled = true;
            cmbGroup.IsEnabled = true;
            cmbCountry.IsEnabled = true;
            dtDOB.IsEnabled = true;
        }

        private void ClearObjects()
        {
            txtCustID.Clear();
            txtCustName.Clear();
            txtCustAddress.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            cmbCountry.SelectedIndex = -1;
            cmbGroup.SelectedIndex = -1;
            dtDOB.SelectedDate = DateTime.Now;
            add = false;
            recall = false;
        }


        private bool checkEmptyFields()
        {
            if (txtCustID.Text == string.Empty && txtCustName.Text == string.Empty && txtMobile.Text == string.Empty && txtEmail.Text == string.Empty)
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
                    cust = new List<Customer_Master>();
                    cust.Add(new Customer_Master
                    {
                        Customer_ID = txtCustID.Text,
                        Customer_Name = txtCustName.Text,
                        Customer_Address = txtCustAddress.Text,
                        Customer_Mobile = txtMobile.Text,
                        Customer_Email = txtEmail.Text,
                        Customer_DOB = dtDOB.SelectedDate.Value,
                        Country = cmbCountry.SelectedValue.ToString(),
                        Customer_Group = cmbGroup.SelectedValue.ToString()
                    });

                    if (FC.SaveCustomerMaster(cust))
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
                    cust = new List<Customer_Master>();
                    cust.Add(new Customer_Master
                    {
                        Customer_ID = txtCustID.Text,
                        Customer_Name = txtCustName.Text,
                        Customer_Address = txtCustAddress.Text,
                        Customer_Mobile = txtMobile.Text,
                        Customer_Email = txtEmail.Text,
                        Customer_DOB = dtDOB.SelectedDate.Value,
                        Country = cmbCountry.SelectedValue.ToString(),
                        Customer_Group = cmbGroup.SelectedValue.ToString()
                    });

                    if (FC.UpdateCustomerMaster(cust))
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

        private void LoadAllCombos()
        {
            List<CustomClass> group = new List<CustomClass>();
            group.Add(new CustomClass { Value = "LC", Data = "Local" });
            group.Add(new CustomClass { Value = "FR", Data = "Foreign" });
            cmbGroup.ItemsSource = null;
            cmbGroup.ItemsSource = group;
            cmbGroup.DisplayMemberPath = "Data";
            cmbGroup.SelectedValuePath = "Value";

            List<Country_Master> country = new List<Country_Master>();
            country = FC.GetCountryMaster("");
            cmbCountry.ItemsSource = null;
            cmbCountry.ItemsSource = country;
            cmbCountry.DisplayMemberPath = "Country_Name";
            cmbCountry.SelectedValuePath = "Country_ID";
        }

        private string GenerateAutoID()
        {
            DBClass db = new DBClass();
            string strqry = "select Count(*) from Customer_Master";
            int list = db.ReturnCount(strqry);
            list += 1;
            int x = 8;
            string _prefix = "CS";
            int y = x - (list.ToString().Length + _prefix.Length);

            var builder = new StringBuilder();
            for (int i = 0; i < y; i++)
            {
                builder.Append('0');
            }
            builder.Append(list);
            string pocode = _prefix + builder.ToString();

            return Convert.ToString(pocode);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearObjects();
                txtCustID.Text = GenerateAutoID();
                EnableObjects();
                LoadAllCombos();
                txtCustName.Focus();
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
                    txtCustID.IsEnabled = false;
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
                        if (FC.DeleteCustomerMaster(txtCustID.Text))
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
                    if (validateUserID(txtCustID.Text))
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
            cust = new List<Customer_Master>();
            cust = FC.GetCustomerMaster(ID);
            if (cust.Count > 0)
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
            LoadAllCombos();
        }

        private void LoadCustomers(string ID)
        {
            cust = new List<Customer_Master>();
            cust = FC.GetCustomerMaster(ID);
            txtCustID.Text = cust[0].Customer_ID;
            txtCustName.Text = cust[0].Customer_Name;
            txtCustAddress.Text = cust[0].Customer_Address;
            txtMobile.Text = cust[0].Customer_Mobile;
            txtEmail.Text = cust[0].Customer_Email;
            cmbCountry.SelectedValue = cust[0].Country;
            cmbGroup.SelectedValue = cust[0].Customer_Group;
            dtDOB.SelectedDate = cust[0].Customer_DOB;
        }

        private void BtnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow mast = new MasterWindow();
            SearchCustomerView scv = new SearchCustomerView();
            mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mast.WindowStyle = WindowStyle.None;
            mast.Height = 600;
            mast.Width = 1024;
            mast.ResizeMode = ResizeMode.NoResize;
            mast.Content = scv;
            mast.Title = "User Search";
            mast.ShowDialog();

            if (scv._Customer_ID != "")
            {
                recall = true;
                LoadCustomers(scv._Customer_ID);
            }
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbGroup.SelectedValue != null)
            {
                if(!recall)
                {
                    if (cmbGroup.SelectedValue.ToString() == "LC")
                    {
                        cmbCountry.SelectedValue = "SL";
                        cmbCountry.IsEnabled = false;
                    }
                    else if (cmbGroup.SelectedValue.ToString() == "FR")
                    {
                        cmbCountry.SelectedIndex = 0;
                        cmbCountry.IsEnabled = true;
                    }
                }
            }
        }
    }
}
