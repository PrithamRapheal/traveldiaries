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
    /// Interaction logic for EmailInvoiceView.xaml
    /// </summary>
    public partial class EmailInvoiceView : UserControl
    {
        public EmailInvoiceView()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        List<Tour_Master> tour = new List<Tour_Master>();
        FunctionClass Fc = new FunctionClass();

        private void CmbTourID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbTourID.SelectedValue.ToString() != null)
            {
                tour = new List<Tour_Master>();
                tour = Fc.GetTourMaster(cmbTourID.SelectedValue.ToString());

                List<Chauffer_Master> chauff = new List<Chauffer_Master>();
                chauff = Fc.GetChaufferMaster(tour[0].Chauffer_ID);
                txtChaufferEmail.Text = chauff[0].Chauffer_Email;

                List<Customer_Master> cust = new List<Customer_Master>();
                cust = Fc.GetCustomerMaster(tour[0].Customer_Code);
                txtReceiver.Text = cust[0].Customer_Email;

                txtSender.Text = "test"; //Email address of the sender
            }
        }

        private void BtnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Packages_Master> pack = new List<Packages_Master>();
                pack = Fc.GetPackageMaster(tour[0].Package_ID);
                EmailClass buildemail = new EmailClass();
                string html = buildemail.HTMLBody(tour, pack);
                if(buildemail.SendEmail(txtSender.Text,txtSender.Text,txtReceiver.Text,txtChaufferEmail.Text,tour,html)) //The second parameter must be th password of the email
                {
                    MessageBox.Show("Email Sent Successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Email Unsuccessful!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<Tour_Master> mast = new List<Tour_Master>();
            mast = Fc.GetTourMastCombo();
            cmbTourID.ItemsSource = null;
            cmbTourID.ItemsSource = mast;
            cmbTourID.DisplayMemberPath = "Tour_ID";
            cmbTourID.SelectedValuePath = "Tour_ID";
        }
    }
}
