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
    /// Interaction logic for PackagesView.xaml
    /// </summary>
    public partial class PackagesView : UserControl
    {
        public PackagesView()
        {
            InitializeComponent();
        }

        List<Packages_Master> pack = new List<Packages_Master>();
        FunctionClass FC = new FunctionClass();
        private bool add = false;
        private int _ID;

        private void DisableObjects()
        {
            txtPackID.IsEnabled = false;
            txtPackName.IsEnabled = false;
            txtDays.IsEnabled = false;
            cmbDistrict.IsEnabled = false;
            cmbExcusrion.IsEnabled = false;
            btnAddToGrid.IsEnabled = false;
            btnRemoveFromGrid.IsEnabled = false;
        }

        private void EnableObjects()
        {
           // txtPackID.IsEnabled = true;
            txtPackName.IsEnabled = true;
            txtDays.IsEnabled = true;
            cmbDistrict.IsEnabled = true;
            cmbExcusrion.IsEnabled = true;
            btnAddToGrid.IsEnabled = true;
            btnRemoveFromGrid.IsEnabled = true;
        }

        private void ClearObjects()
        {
            txtPackID.Clear();
            txtPackName.Clear();
            txtDays.Clear();
            cmbExcusrion.SelectedIndex = -1;
            cmbDistrict.SelectedIndex = -1;
            pack = new List<Packages_Master>();
            listPackages.ItemsSource = null;
            add = false;
        }

        private bool checkEmptyFields()
        {
            if (txtPackID.Text == string.Empty && txtPackName.Text == string.Empty && txtDays.Text == string.Empty)
                return false;
            else
                return true;
        }

        private void LoadAllCombos()
        {
            List<Excursion_Master> exc = new List<Excursion_Master>();
            exc = FC.GetExcursionMaster("");
            cmbExcusrion.ItemsSource = null;
            cmbExcusrion.ItemsSource = exc;
            cmbExcusrion.DisplayMemberPath = "Excursion_Name";
            cmbExcusrion.SelectedValuePath = "Excursion_ID";

            List<District_Master> dist = new List<District_Master>();
            dist = FC.GetDistrictMaster("");
            cmbDistrict.ItemsSource = null;
            cmbDistrict.ItemsSource = dist;
            cmbDistrict.DisplayMemberPath = "District_Name";
            cmbDistrict.SelectedValuePath = "District_ID";
        }

        private string GenerateAutoID()
        {
            DBClass db = new DBClass();
            string strqry = "select Count(*) from Packages_Master";
            int list = db.ReturnCount(strqry);
            list += 1;
            int x = 7;
            string _prefix = "PK";
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

        private void SavePackage()
        {
            if (checkEmptyFields())
            {
                if(listPackages.ItemsSource != null)
                {
                    if (add)
                    {
                        if (FC.SavePackageMaster(pack))
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
                        if (FC.UpdatePackageMaster(pack))
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
                    MessageBox.Show("Enter atleast one item to create the package!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (add)
                {
                    if (validateUserID(txtPackID.Text))
                    {
                        SavePackage();
                    }
                    else
                    {
                        MessageBox.Show("Package ID already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    SavePackage();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private bool validateUserID(string ID)
        {
            List<Packages_Master> packages = new List<Packages_Master>();
            packages = FC.GetPackageMaster(ID);
            if (packages.Count > 0)
                return false;
            else
                return true;
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
                        if (FC.DeletePackageMaster(txtPackID.Text))
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

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkEmptyFields())
                {
                    EnableObjects();
                    txtPackID.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("No record to edit! Search for a record to edit.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearObjects();
                txtPackID.Text = GenerateAutoID();
                EnableObjects();
                LoadAllCombos();
                txtPackName.Focus();
                add = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnSearchPackages_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow mast = new MasterWindow();
            SearchPackagesView spv = new SearchPackagesView();
            mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mast.WindowStyle = WindowStyle.None;
            mast.Height = 600;
            mast.Width = 1024;
            mast.ResizeMode = ResizeMode.NoResize;
            mast.Content = spv;
            mast.Title = "Packages Search";
            mast.ShowDialog();

            if (spv._Package_ID != "")
            {
                LoadPackages(spv._Package_ID);
            }

            btnAddToGrid.IsEnabled = true;
            btnRemoveFromGrid.IsEnabled = true;
        }

        private void LoadPackages(string ID)
        {
            pack = new List<Packages_Master>();
            pack = FC.GetPackageMaster(ID);
            txtPackID.Text = pack[0].Package_ID;
            txtPackName.Text = pack[0].Package_Name;
            listPackages.ItemsSource = null;
            listPackages.ItemsSource = pack;

            //txtDays.Text = pack[0].Customer_Address;
            //txtMobile.Text = pack[0].Customer_Mobile;
            //txtEmail.Text = pack[0].Customer_Email;
            //cmbCountry.SelectedValue = pack[0].Country;
            //cmbGroup.SelectedValue = pack[0].Customer_Group;
            //dtDOB.SelectedDate = pack[0].Customer_DOB;
        }


        private void BtnRemoveFromGrid_Click(object sender, RoutedEventArgs e)
        {
            if(listPackages.SelectedItem != null)
            {
                pack.Remove((Packages_Master)listPackages.SelectedItem);
                listPackages.ItemsSource = null;
                listPackages.ItemsSource = pack;
            }
            else
            {
                MessageBox.Show("Select a row to remove!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAddToGrid_Click(object sender, RoutedEventArgs e)
        {
            if (txtDays.Text != string.Empty)
            {
                if(pack.Count == 0)
                {
                    pack = new List<Packages_Master>();
                    pack.Add(new Packages_Master
                    {
                        Package_ID = txtPackID.Text,
                        Package_Name = txtPackName.Text,
                        Excursion_ID = cmbExcusrion.SelectedValue.ToString(),
                        Excursion_Name = cmbExcusrion.Text,
                        District_ID = cmbDistrict.SelectedValue.ToString(),
                        District_Name = cmbDistrict.Text,
                        No_Of_Days = int.Parse(txtDays.Text)
                    });

                    listPackages.ItemsSource = null;
                    listPackages.ItemsSource = pack;
                }
                else
                {
                    pack.Add(new Packages_Master
                    {
                        Package_ID = txtPackID.Text,
                        Package_Name = txtPackName.Text,
                        Excursion_ID = cmbExcusrion.SelectedValue.ToString(),
                        Excursion_Name = cmbExcusrion.Text,
                        District_ID = cmbDistrict.SelectedValue.ToString(),
                        District_Name = cmbDistrict.Text, 
                        No_Of_Days = int.Parse(txtDays.Text)
                    });

                    listPackages.ItemsSource = null;
                    listPackages.ItemsSource = pack ;
                }
            }
            else
            {
                MessageBox.Show("Enter all details to add!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ClearObjects();
            DisableObjects();
            LoadAllCombos();
        }

        private void ListPackages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listPackages.SelectedItem != null)
            {
                Packages_Master pk = (Packages_Master)listPackages.SelectedItem;
                cmbDistrict.SelectedValue = pk.District_ID;
                cmbExcusrion.SelectedValue = pk.Excursion_ID;
                txtDays.Text = pk.No_Of_Days.ToString();
                txtPackID.Text = pk.Package_ID;
                txtPackName.Text = pk.Package_Name;
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void CmbExcusrion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbExcusrion.SelectedItem != null)
            {
                List<Excursion_Master> exc = new List<Excursion_Master>();
                exc = FC.GetDistrictUsingExcursion(cmbExcusrion.SelectedValue.ToString());
                cmbDistrict.SelectedValue = exc[0].District_ID;
            }    
        }
    }
}
