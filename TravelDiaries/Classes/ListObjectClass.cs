using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelDiaries.Classes
{
    class ListObjectClass
    {
    }

    public class CustomClass
    {
        public string Data { get; set; }
        public string Value { get; set; }
    }

    public class User_Master
    {
        public string User_ID { get; set; }
        public string User_Name { get; set; }
        public string User_Password { get; set; }
        public string User_Type { get; set; }
    }

    public class Customer_Master
    {
        public string Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Address { get; set; }
        public string Customer_Mobile { get; set; }
        public string Customer_Email { get; set; }
        public DateTime Customer_DOB { get; set; }
        public string Customer_Group { get; set; }
        public string Country { get; set; }
        public int Count { get; set; } = 0; //Dashboard Customerbby Country Count
    }

    public class Country_Master
    {
        public string Country_ID { get; set; }
        public string Country_Name { get; set; }
    }

    public class District_Master
    {
        public string District_ID { get; set; }
        public string District_Name { get; set; }
    }

    public class Excursion_Master
    {
        public string Excursion_ID { get; set; }
        public string Excursion_Name { get; set; }
        public decimal Excursion_Rate { get; set; }
        public string District_ID { get; set; }
        public string District_Name { get; set; }
    }

    public class Chauffer_Master
    {
        public string Chauffer_ID { get; set; }
        public string Chauffer_Name { get; set; }
        public string Chauffer_Address { get; set; }
        public string Chauffer_Email { get; set; }
        public string Chauffer_Mobile { get; set; }
        public string Vehicle_No { get; set; }
        public string Vehicle_Type { get; set; }
        public string Vehicle_Model { get; set; }
        public decimal Day_Rate { get; set; }
    }

    public class Packages_Master
    {
        public string Package_ID { get; set; }
        public string Package_Name { get; set; }
        public int No_Of_Days { get; set; }
        public string Excursion_ID { get; set; }
        public string Excursion_Name { get; set; }
        public string District_ID { get; set; }
        public string District_Name { get; set; }
    }

    public class Hotel_Master
    {
        public string Hotel_ID { get; set; }
        public string Hotel_Name { get; set; }
        public string Hotel_Number { get; set; }
        public string Hotel_Email { get; set; }
        public string Room_Type { get; set; }
        public decimal BB_Rate { get; set; }
        public decimal HB_Rate { get; set; }
        public decimal FB_Rate { get; set; }
        public decimal RO_Rate { get; set; }
        public string Hotel_Address { get; set; }
    }

    public class Tour_Master 
    {
        public string Tour_ID { get; set; }
        public string Package_ID { get; set; }
        public string Package_Name { get; set; }
        public DateTime Start_Date { get; set; }
        public int No_Of_Days { get; set; }
        public string Customer_Code { get; set; }
        public string Customer_Name  { get; set; }
        public int Tour_Status { get; set; }
        public string Hotel_ID { get; set; }
        public string Hotel_Name { get; set; }
        public string Room_Type { get; set; }
        public string Booking_Type { get; set; }
        public string Chauffer_ID { get; set; }
        public string Chauffer_Name { get; set; }
        public decimal Hotel_Total { get; set; }
        public decimal Chauffer_Total { get; set; }
        public decimal Excursion_Total { get; set; }
        public decimal Total_Amount { get; set; }
    }
}
