using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TravelDiaries.Classes
{
    class EmailClass
    {
        public string HTMLBody(List<Tour_Master> list, List<Packages_Master> pack)
        {
            string HTMLBody = "";

            using (FileStream fs = File.Open("C:/Users/Magnex Desktop/Desktop/TravelDiaries/TravelDiaries/TravelDiaries/EmailFormat.html", FileMode.Open, FileAccess.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    HTMLBody = sr.ReadToEnd();
                }

                HTMLBody = HTMLBody.Replace("{Customer_Name}", list[0].Customer_Name);
                HTMLBody = HTMLBody.Replace("{Chauffer_Name}", list[0].Chauffer_Name);
                HTMLBody = HTMLBody.Replace("{Start_Date}", list[0].Start_Date.ToShortDateString());
                HTMLBody = HTMLBody.Replace("{Tour_ID}", list[0].Tour_ID);
                HTMLBody = HTMLBody.Replace("{Package_Name}", list[0].Package_Name);
                HTMLBody = HTMLBody.Replace("{Total_Amount}", list[0].Total_Amount.ToString());
                HTMLBody = HTMLBody.Replace("{Chauffeur_Expense}", list[0].Chauffer_Total.ToString());
                HTMLBody = HTMLBody.Replace("{Excursion_Total}", list[0].Excursion_Total.ToString());
                HTMLBody = HTMLBody.Replace("{Hotel_Total}", list[0].Hotel_Total.ToString());

                string hoteltable = "";
                string excursiontable = "";

                for (int i = 0; i < list.Count; i++)
                {
                    hoteltable += "<tr>";
                    hoteltable += "<td>" + list[i].Hotel_Name + "</td>" + "<td>" + list[i].Hotel_Total + "</td>";
                    hoteltable += "</tr>";
                }

                for (int i = 0; i < pack.Count; i++)
                {
                    excursiontable += "<tr>";
                    excursiontable += "<td>" + pack[i].Excursion_Name + "</td>" + "<td>" + pack[i].District_Name + "</td>";
                    excursiontable += "</tr>";
                }

                HTMLBody = HTMLBody.Replace("{Hotel_Body}", hoteltable);
                HTMLBody = HTMLBody.Replace("{Package_Body}", excursiontable);

                return HTMLBody;
            }
        }
        public bool SendEmail(string sender, string password, string customer_email, string chauffer_email, List<Tour_Master> list, string HTMLBody)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(sender, password);

                MailMessage mm = new MailMessage(sender, customer_email);
                mm.IsBodyHtml = true;
                mm.Body = HTMLBody;
                mm.Subject = "Tour Plan using Travel Diaries";
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }

    
}
