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
    /// Interaction logic for CountryDistrictView.xaml
    /// </summary>
    public partial class CountryDistrictView : UserControl
    {
        public CountryDistrictView()
        {
            InitializeComponent();
        }

        List<Country_Master> count = new List<Country_Master>();
        List<District_Master> dist = new List<District_Master>();
        FunctionClass FC = new FunctionClass();
        private bool addCount, addDist = false;

        private void DisableCountryObjects()
        {
            txtCountryID.IsEnabled = false;
            txtCountryName.IsEnabled = false;
        }

        private void EnableCountryObjects()
        {
            txtCountryID.IsEnabled = true;
            txtCountryName.IsEnabled = true;
        }

        private void ClearCountryObjects()
        {
            txtCountryID.Clear();
            txtCountryName.Clear();
        }

        private void DisableDistrictObjects()
        {
            txtDistID.IsEnabled = false;
            txtDistName.IsEnabled = false;
        }

        private void EnableDistrictObjects()
        {
            txtDistID.IsEnabled = true;
            txtDistName.IsEnabled = true;
        }

        private void ClearDistrictObjects()
        {
            txtDistID.Clear();
            txtDistName.Clear();
        }

        private bool checkEmptyFieldsCountry()
        {
            if (txtCountryID.Text == string.Empty && txtCountryName.Text == string.Empty)
                return false;
            else
                return true;
        }

        private bool checkEmptyFieldsDistrict()
        {
            if (txtDistID.Text == string.Empty && txtDistName.Text == string.Empty)
                return false;
            else
                return true;
        }

        private void SaveCountryMaster()
        {
            if (checkEmptyFieldsCountry())
            {
                if (addCount)
                {
                    count = new List<Country_Master>();
                    count.Add(new Country_Master
                    {
                        Country_ID = txtCountryID.Text,
                        Country_Name = txtCountryName.Text
                    });

                    if (FC.SaveCountryMaster(count))
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
                    count = new List<Country_Master>();
                    count.Add(new Country_Master
                    {
                        Country_ID = txtCountryID.Text,
                        Country_Name = txtCountryName.Text
                    });

                    if (FC.UpdateCountryMaster(count))
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

        private void SaveDistrictMaster()
        {
            if (checkEmptyFieldsDistrict())
            {
                if (addDist)
                {
                    dist = new List<District_Master>();
                    dist.Add(new District_Master
                    {
                        District_ID = txtDistID.Text,
                        District_Name = txtDistName.Text
                    });

                    if (FC.SaveDistrictMaster(dist))
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
                    dist = new List<District_Master>();
                    dist.Add(new District_Master
                    {
                        District_ID = txtDistID.Text,
                        District_Name = txtDistName.Text
                    });

                    if (FC.UpdateDistrictMaster(dist))
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ClearCountryObjects();
            ClearDistrictObjects();
            DisableCountryObjects();
            DisableDistrictObjects();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearCountryObjects();
                txtCountryID.Focus();
                EnableCountryObjects();
                addCount = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkEmptyFieldsCountry())
                {
                    EnableCountryObjects();
                    txtCountryID.IsEnabled = false;
                    addCount = false;
                    addDist = false;
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
                if (checkEmptyFieldsCountry())
                {
                    if (MessageBox.Show("Are You Sure?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        return;
                    }
                    else
                    {
                        if (FC.DeleteCountryMaster(txtCountryID.Text))
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
                if (addCount)
                {
                    if (validateCountryID(txtCountryID.Text))
                    {
                        SaveCountryMaster();
                    }
                    else
                    {
                        MessageBox.Show("Country ID already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    SaveCountryMaster();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnSearchCountry_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow mast = new MasterWindow();
            SearchCountryView sd = new SearchCountryView();
            mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mast.WindowStyle = WindowStyle.None;
            mast.Height = 600;
            mast.Width = 1024;
            mast.ResizeMode = ResizeMode.NoResize;
            mast.Content = sd;
            mast.Title = "Country Search";
            mast.ShowDialog();

            if (sd._Country_ID != "")
            {
                LoadCountry(sd._Country_ID);
            }
        }

        private void LoadCountry(string ID)
        {
            count = new List<Country_Master>();
            count = FC.GetCountryMaster(ID);
            txtCountryID.Text = count[0].Country_ID;
            txtCountryName.Text = count[0].Country_Name;
        }

        private void BtnAdd_Dist_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearDistrictObjects();
                txtDistID.Focus();
                EnableDistrictObjects();
                addDist = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnEdit_Dist_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkEmptyFieldsDistrict())
                {
                    EnableDistrictObjects();
                    txtDistID.IsEnabled = false;
                    addCount = false;
                    addDist = false;
                }
                else
                {
                    MessageBox.Show("No record to edit! Search for a record to edit.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnDelete_Dist_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkEmptyFieldsDistrict())
                {
                    if (MessageBox.Show("Are You Sure?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        return;
                    }
                    else
                    {
                        if (FC.DeleteDistrictMaster(txtDistID.Text))
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

        private void BtnSave_Dist_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (addDist)
                {
                    if (validateDistrictID(txtDistID.Text))
                    {
                        SaveDistrictMaster();
                    }
                    else
                    {
                        MessageBox.Show("User ID already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    SaveDistrictMaster();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private bool validateCountryID(string ID)
        {
            count = new List<Country_Master>();
            count = FC.GetCountryMaster(ID);
            if (count.Count > 0)
                return false;
            else
                return true;
        }

        private bool validateDistrictID(string ID)
        {
            dist = new List<District_Master>();
            dist  = FC.GetDistrictMaster(ID);
            if (dist.Count > 0)
                return false;
            else
                return true;
        }

        private void BtnSearchDistrict_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow mast = new MasterWindow();
            SearchDistrictView sd = new SearchDistrictView();
            mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mast.WindowStyle = WindowStyle.None;
            mast.Height = 600;
            mast.Width = 1024;
            mast.ResizeMode = ResizeMode.NoResize;
            mast.Content = sd;
            mast.Title = "District Search";
            mast.ShowDialog();

            if (sd._District_ID != "")
            {
                LoadDistrict(sd._District_ID);
            }
        }

        private void LoadDistrict(string ID)
        {
            dist = new List<District_Master>();
            dist = FC.GetDistrictMaster(ID);
            txtDistID.Text = dist[0].District_ID;
            txtDistName.Text = dist[0].District_Name;
        }
    }
}
