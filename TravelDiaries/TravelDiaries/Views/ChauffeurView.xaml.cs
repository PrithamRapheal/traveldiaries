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
    /// Interaction logic for ChauffeurView.xaml
    /// </summary>
    public partial class ChauffeurView : UserControl
    {
        public ChauffeurView()
        {
            InitializeComponent();
        }

        List<Chauffer_Master> chauf = new List<Chauffer_Master>();
        FunctionClass FC = new FunctionClass();
        private bool add = false;

        private void DisableObjects()
        {
            txtChaufID.IsEnabled = false;
            txtChaufName.IsEnabled = false;
            txtChaufAddress.IsEnabled = false;
            txtMobile.IsEnabled = false;
            txtEmail.IsEnabled = false;
            cmbVehicleType.IsEnabled = false;
            txtVehicleNo.IsEnabled = false;
            txtVehicleModel.IsEnabled = false;
            txtDayRate.IsEnabled = false;
        }

        private void EnableObjects()
        {
          //  txtChaufID.IsEnabled = true;
            txtChaufName.IsEnabled = true;
            txtChaufAddress.IsEnabled = true;
            txtMobile.IsEnabled = true;
            txtEmail.IsEnabled = true;
            cmbVehicleType.IsEnabled = true;
            txtVehicleNo.IsEnabled = true;
            txtVehicleModel.IsEnabled = true;
            txtDayRate.IsEnabled = true;
        }

        private void ClearObjects()
        {
            txtChaufID.Clear();
            txtChaufName.Clear();
            txtChaufAddress.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            cmbVehicleType.SelectedIndex = -1;
            txtVehicleNo.Clear();
            txtVehicleModel.Clear();
            txtDayRate.Clear();
            add = false;
        }


        private bool checkEmptyFields()
        {
            if (txtChaufID.Text == string.Empty && txtChaufName.Text == string.Empty && txtMobile.Text == string.Empty &&
                txtEmail.Text == string.Empty && txtVehicleNo.Text == string.Empty && txtVehicleModel.Text == string.Empty && txtDayRate.Text == string.Empty)
                return false;
            else
                return true;
        }

        private void SaveChauffer()
        {
            if (checkEmptyFields())
            {
                if (add)
                {
                    chauf = new List<Chauffer_Master>();
                    chauf.Add(new Chauffer_Master
                    {
                        Chauffer_ID = txtChaufID.Text,
                        Chauffer_Name = txtChaufName.Text,
                        Chauffer_Address = txtChaufAddress.Text,
                        Chauffer_Mobile = txtMobile.Text,
                        Chauffer_Email = txtEmail.Text,
                        Vehicle_No = txtVehicleNo.Text,
                        Vehicle_Type = cmbVehicleType.SelectedValue.ToString(),
                        Vehicle_Model = txtVehicleModel.Text,
                        Day_Rate = decimal.Parse(txtDayRate.Text)
                    });

                    if (FC.SaveChaufferMaster(chauf))
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
                    chauf = new List<Chauffer_Master>();
                    chauf.Add(new Chauffer_Master
                    {
                        Chauffer_ID = txtChaufID.Text,
                        Chauffer_Name = txtChaufName.Text,
                        Chauffer_Address = txtChaufAddress.Text,
                        Chauffer_Mobile = txtMobile.Text,
                        Chauffer_Email = txtEmail.Text,
                        Vehicle_No = txtVehicleNo.Text,
                        Vehicle_Type = cmbVehicleType.SelectedValue.ToString(),
                        Vehicle_Model = txtVehicleModel.Text,
                        Day_Rate = decimal.Parse(txtDayRate.Text)
                    });

                    if (FC.UpdateChaufferMaster(chauf))
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
            List<CustomClass> type = new List<CustomClass>();
            type.Add(new CustomClass { Value = "CR", Data = "Car" });
            type.Add(new CustomClass { Value = "VN", Data = "Van" });
            type.Add(new CustomClass { Value = "BS", Data = "Bus" });
            type.Add(new CustomClass { Value = "TK", Data = "Tuk" });
            cmbVehicleType.ItemsSource = null;
            cmbVehicleType.ItemsSource = type;
            cmbVehicleType.DisplayMemberPath = "Data";
            cmbVehicleType.SelectedValuePath = "Value";
        }

        private string GenerateAutoID()
        {
            DBClass db = new DBClass();
            string strqry = "select Count(*) from Chauffer_Master";
            int list = db.ReturnCount(strqry);
            list += 1;
            int x = 8;
            string _prefix = "CF";
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
            LoadCombos();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearObjects();
                txtChaufID.Text = GenerateAutoID();
                EnableObjects();
                LoadCombos();
                txtChaufName.Focus();
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
                    txtChaufID.IsEnabled = false;
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
                        if (FC.DeleteChaufferMaster(txtChaufID.Text))
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
                    if (validateUserID(txtChaufID.Text))
                    {
                        SaveChauffer();
                    }
                    else
                    {
                        MessageBox.Show("Chauffer ID already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    SaveChauffer();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private bool validateUserID(string ID)
        {
            chauf = new List<Chauffer_Master>();
            chauf = FC.GetChaufferMaster(ID);
            if (chauf.Count > 0)
                return false;
            else
                return true;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void LoadChauffer(string ID)
        {
            chauf = new List<Chauffer_Master>();
            chauf = FC.GetChaufferMaster(ID);
            txtChaufID.Text = chauf[0].Chauffer_ID;
            txtChaufName.Text = chauf[0].Chauffer_Name;
            txtChaufAddress.Text = chauf[0].Chauffer_Address;
            txtMobile.Text = chauf[0].Chauffer_Mobile;
            txtEmail.Text = chauf[0].Chauffer_Email;
            cmbVehicleType.SelectedValue = chauf[0].Vehicle_Type;
            txtVehicleNo.Text = chauf[0].Vehicle_No;
            txtVehicleModel.Text = chauf[0].Vehicle_Model;
            txtDayRate.Text = chauf[0].Day_Rate.ToString();
        }

        private void BtnSearchChauffer_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow mast = new MasterWindow();
            SearchChauffeurView scv = new SearchChauffeurView();
            mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mast.WindowStyle = WindowStyle.None;
            mast.Height = 600;
            mast.Width = 1024;
            mast.ResizeMode = ResizeMode.NoResize;
            mast.Content = scv;
            mast.Title = "Chauffer Search";
            mast.ShowDialog();

            if (scv._Chauffer_ID != "")
            {
                LoadChauffer(scv._Chauffer_ID);
            }
        }
    }
}
