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
    /// Interaction logic for ExcursionView.xaml
    /// </summary>
    public partial class ExcursionView : UserControl
    {
        List<Excursion_Master> ex = new List<Excursion_Master>();
        FunctionClass FC = new FunctionClass();
        private bool add = false;
        private int _ID;

        public ExcursionView()
        {
            InitializeComponent();
        }

        private void DisableObjects()
        {
            txtexcid.IsEnabled = false;
            txtexcname.IsEnabled = false;
            txtrate.IsEnabled = false;
            cmbDistrict.IsEnabled = false;
        }

        private void EnableObjects()
        {
            //txtexcid.IsEnabled = true;
            txtexcname.IsEnabled = true;
            txtrate.IsEnabled = true;
            cmbDistrict.IsEnabled = true;
        }

        private void ClearObjects()
        {
            txtexcid.Clear();
            txtexcname.Clear();
            txtrate.Clear();
            cmbDistrict.SelectedIndex = -1;
            add = false;
        }


        private bool checkEmptyFields()
        {
            if (txtexcid.Text == string.Empty && txtexcname.Text == string.Empty && txtrate.Text == string.Empty)
                return false;
            else
                return true;
        }

        private void SaveExcursion()
        {
            if (checkEmptyFields())
            {
                if (add)
                {
                    ex = new List<Excursion_Master>();
                    ex.Add(new Excursion_Master
                    {
                        Excursion_ID = txtexcid.Text,
                        Excursion_Name = txtexcname.Text,
                        Excursion_Rate = decimal.Parse(txtrate.Text),
                        District_ID = cmbDistrict.SelectedValue.ToString(),
                        District_Name = cmbDistrict.Text,
                    });

                    if (FC.SaveExcursionMaster(ex))
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
                    ex = new List<Excursion_Master>();
                    ex.Add(new Excursion_Master
                    {
                        Excursion_ID = txtexcid.Text,
                        Excursion_Name = txtexcname.Text,
                        Excursion_Rate = decimal.Parse(txtrate.Text),
                        District_ID = cmbDistrict.SelectedValue.ToString(),
                        District_Name = cmbDistrict.Text,
                    });

                    if (FC.UpdateExcursionMaster(ex))
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

        private void LoadCombo()
        {
            List<District_Master> country = new List<District_Master>();
            country = FC.GetDistrictMaster("");
            cmbDistrict.ItemsSource = null;
            cmbDistrict.ItemsSource = country;
            cmbDistrict.DisplayMemberPath = "District_Name";
            cmbDistrict.SelectedValuePath = "District_ID";
        }

        private string GenerateAutoID()
        {
            DBClass db = new DBClass();
            string strqry = "select Count(*) from Excursion_Master";
            int list = db.ReturnCount(strqry);
            list += 1;
            int x = 6;
            string _prefix = "EXC";
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ClearObjects();
            DisableObjects();
            LoadCombo();
        }

        private void LoadExcursion(string ID)
        {
            ex = new List<Excursion_Master>();
            ex = FC.GetExcursionMaster(ID);
            txtexcid.Text = ex[0].Excursion_ID;
            txtexcname.Text = ex[0].Excursion_Name;
            txtrate.Text = ex[0].Excursion_Rate.ToString();
            cmbDistrict.SelectedValue = ex[0].District_ID;
        }

        private void BtnSearchExcursion_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow mast = new MasterWindow();
            SearchExcursionView scv = new SearchExcursionView();
            mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mast.WindowStyle = WindowStyle.None;
            mast.Height = 600;
            mast.Width = 1024;
            mast.ResizeMode = ResizeMode.NoResize;
            mast.Content = scv;
            mast.Title = "Excursion Search";
            mast.ShowDialog();

            if (scv._Excursion_ID != "")
            {
                LoadExcursion(scv._Excursion_ID);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearObjects();
                txtexcid.Text = GenerateAutoID();
                EnableObjects();
                LoadCombo();
                txtexcname.Focus();
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
                    txtexcid.IsEnabled = false;
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
                        if (FC.DeleteExcurionMaster(txtexcid.Text))
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
                    if (validateUserID(txtexcid.Text))
                    {
                        SaveExcursion();
                    }
                    else
                    {
                        MessageBox.Show("User ID already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    SaveExcursion();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private bool validateUserID(string ID)
        {
            ex = new List<Excursion_Master>();
            ex = FC.GetExcursionMaster(ID);
            if (ex.Count > 0)
                return false;
            else
                return true;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
