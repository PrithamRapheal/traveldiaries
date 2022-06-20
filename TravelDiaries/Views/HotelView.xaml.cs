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
    /// Interaction logic for HotelView.xaml
    /// </summary>
    public partial class HotelView : UserControl
    {
        public HotelView()
        {
            InitializeComponent();
        }

        List<Hotel_Master> hotel = new List<Hotel_Master>();
        FunctionClass FC = new FunctionClass();
        private bool add = false;

        private void DisableObjects()
        {
            txtHotelID.IsEnabled = false;
            txtHotelName.IsEnabled = false;
            txtHotelAddress.IsEnabled = false;
            txtMobile.IsEnabled = false;
            txtEmail.IsEnabled = false;
            cmbRoomType.IsEnabled = false;
            txtBB.IsEnabled = false;
            txtFB.IsEnabled = false;
            txtHB.IsEnabled = false;
            txtRO.IsEnabled = false;
        }

        private void EnableObjects()
        {
            //txtHotelID.IsEnabled = true;
            txtHotelName.IsEnabled = true;
            txtHotelAddress.IsEnabled = true;
            txtMobile.IsEnabled = true;
            txtEmail.IsEnabled = true;
            cmbRoomType.IsEnabled = true;
            txtBB.IsEnabled = true;
            txtFB.IsEnabled = true;
            txtHB.IsEnabled = true;
            txtRO.IsEnabled = true;
        }

        private void ClearObjects()
        {
            txtHotelID.Clear();
            txtHotelName.Clear();
            txtHotelAddress.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            cmbRoomType.SelectedIndex = -1;
            txtBB.Clear();
            txtFB.Clear();
            txtHB.Clear();
            txtRO.Clear();
            hotel = new List<Hotel_Master>();
            listRates.ItemsSource = null;
            add = false;
        }


        private bool checkEmptyFields()
        {
            if (txtHotelID.Text == string.Empty && txtHotelName.Text == string.Empty && txtMobile.Text == string.Empty &&
                txtEmail.Text == string.Empty && txtHotelAddress.Text == string.Empty)
                return false;
            else
                return true;
        }

        private void LoadCombo()
        {
            List<CustomClass> roomtype = new List<CustomClass>();
            roomtype.Add(new CustomClass { Data = "Deluxe", Value = "Deluxe" });
            roomtype.Add(new CustomClass { Data = "Superior", Value = "Superior" });
            roomtype.Add(new CustomClass { Data = "Standard", Value = "Standard" });
            roomtype.Add(new CustomClass { Data = "Suite", Value = "Suite" });
            cmbRoomType.ItemsSource = null;
            cmbRoomType.ItemsSource = roomtype;
            cmbRoomType.DisplayMemberPath = "Data";
            cmbRoomType.SelectedValuePath = "Value";
        }

        private string GenerateAutoID()
        {
            DBClass db = new DBClass();
            string strqry = "select Count(*) from Hotel_Master";
            int list = db.ReturnCount(strqry);
            list += 1;
            int x = 6;
            string _prefix = "HT";
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

        private void SaveHotelMaster()
        {
            if (checkEmptyFields())
            {
                if (listRates.ItemsSource != null)
                {
                    if (add)
                    {
                        if (FC.SaveHotelMaster(hotel))
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
                        if (FC.UpdateHotelMaster(hotel))
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ClearObjects();
            DisableObjects();
            LoadCombo();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearObjects();
                txtHotelID.Text = GenerateAutoID();
                txtRO.Text = "0.00";
                txtBB.Text = "0.00";
                txtHB.Text = "0.00";
                txtFB.Text = "0.00";
                EnableObjects();
                LoadCombo();
                txtHotelName.Focus();
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
                    txtHotelID.IsEnabled = false;
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
                        if (FC.DeleteHotelMaster(txtHotelID.Text))
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
                    if (validateUserID(txtHotelID.Text))
                    {
                        SaveHotelMaster();
                    }
                    else
                    {
                        MessageBox.Show("Hotel ID already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    SaveHotelMaster();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private bool validateUserID(string ID)
        {
            List<Hotel_Master> hot_mast = new List<Hotel_Master>();
            hot_mast = FC.GetHotelMaster(ID);
            if (hot_mast.Count > 0)
                return false;
            else
                return true;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void BtnSearchHotel_Click(object sender, RoutedEventArgs e)
        {
            MasterWindow mast = new MasterWindow();
            SearchHotelView shv = new SearchHotelView();
            mast.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            mast.WindowStyle = WindowStyle.None;
            mast.Height = 670;
            mast.Width = 1024;
            mast.ResizeMode = ResizeMode.NoResize;
            mast.Content = shv;
            mast.Title = "Hotels Search";
            mast.ShowDialog();

            if (shv._Hotel_ID != "")
            {
                LoadHotel(shv._Hotel_ID);
            }

            btnAddToGrid.IsEnabled = true;
            btnRemoveFromGrid.IsEnabled = true;
        }

        private void LoadHotel(string ID)
        {
            hotel = new List<Hotel_Master>();
            hotel = FC.GetHotelMaster(ID);
            txtHotelID.Text = hotel[0].Hotel_ID;
            txtHotelName.Text = hotel[0].Hotel_Name;
            txtHotelAddress.Text = hotel[0].Hotel_Address;
            txtMobile.Text = hotel[0].Hotel_Number;
            txtEmail.Text = hotel[0].Hotel_Email;
            listRates.ItemsSource = null;
            listRates.ItemsSource = hotel;

            //txtDays.Text = pack[0].Customer_Address;
            //txtMobile.Text = pack[0].Customer_Mobile;
            //txtEmail.Text = pack[0].Customer_Email;
            //cmbCountry.SelectedValue = pack[0].Country;
            //cmbGroup.SelectedValue = pack[0].Customer_Group;
            //dtDOB.SelectedDate = pack[0].Customer_DOB;
        }

        private void BtnAddToGrid_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txtRO.Text == string.Empty || txtBB.Text == string.Empty || txtHB.Text == string.Empty || txtFB.Text == string.Empty)
                {
                    MessageBox.Show("Enter all the details!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (hotel.Count == 0)
                    {
                        hotel = new List<Hotel_Master>();
                        hotel.Add(new Hotel_Master
                        {
                            Hotel_ID = txtHotelID.Text,
                            Hotel_Name = txtHotelName.Text,
                            Hotel_Address = txtHotelAddress.Text,
                            Hotel_Number = txtMobile.Text,
                            Hotel_Email = txtEmail.Text,
                            Room_Type = cmbRoomType.SelectedValue.ToString(),
                            RO_Rate = txtRO.Text == "" ? 0 : decimal.Parse(txtRO.Text),
                            BB_Rate = txtBB.Text == "" ? 0 : decimal.Parse(txtBB.Text),
                            HB_Rate = txtHB.Text == "" ? 0 : decimal.Parse(txtHB.Text),
                            FB_Rate = txtFB.Text == "" ? 0 : decimal.Parse(txtFB.Text)
                        });

                        listRates.ItemsSource = null;
                        listRates.ItemsSource = hotel;
                    }
                    else
                    {
                        hotel.Add(new Hotel_Master
                        {
                            Hotel_ID = txtHotelID.Text,
                            Hotel_Name = txtHotelName.Text,
                            Hotel_Address = txtHotelAddress.Text,
                            Hotel_Number = txtMobile.Text,
                            Hotel_Email = txtEmail.Text,
                            Room_Type = cmbRoomType.SelectedValue.ToString(),
                            RO_Rate = decimal.Parse(txtRO.Text),
                            BB_Rate = decimal.Parse(txtBB.Text),
                            HB_Rate = decimal.Parse(txtHB.Text),
                            FB_Rate = decimal.Parse(txtFB.Text)
                        });

                        listRates.ItemsSource = null;
                        listRates.ItemsSource = hotel;
                    }
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnRemoveFromGrid_Click(object sender, RoutedEventArgs e)
        {
            if (listRates.SelectedItem != null)
            {
                hotel.Remove((Hotel_Master)listRates.SelectedItem);
                listRates.ItemsSource = null;
                listRates.ItemsSource = hotel;
            }
            else
            {
                MessageBox.Show("Select a row to remove!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ListRates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listRates.SelectedItem != null)
            {
                Hotel_Master hm = (Hotel_Master)listRates.SelectedItem;
                cmbRoomType.SelectedValue = hm.Room_Type;
                txtRO.Text = hm.RO_Rate.ToString();
                txtBB.Text = hm.BB_Rate.ToString();
                txtHB.Text = hm.HB_Rate.ToString();
                txtFB.Text = hm.FB_Rate.ToString();
            }
        }
    }
}
