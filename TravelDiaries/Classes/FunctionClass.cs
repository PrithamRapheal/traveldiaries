using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelDiaries.Classes
{
    class FunctionClass
    {
        #region User Functions
        public List<User_Master> GetUserMaster(string ID)
        {
            List<User_Master> user = new List<User_Master>();
            DBClass db = new DBClass();
            string query = "";
            if (ID == "" || ID == null)
                query = "Select * from User_Master";
            else
                query = "Select * from User_Master where User_ID = '" + ID + "'";
            user = db.GetTableObject<User_Master>(query);
            return user;
        }

        public bool SaveUserMaster(List<User_Master> user)
        {
            DBClass db = new DBClass();
            string query = "";
            if (user != null)
            {
                query = "Insert into User_Master (User_ID, User_Name, User_Password, User_Type) values ('" + user[0].User_ID + "','" + user[0].User_Name + "','" + user[0].User_Password + "','" + user[0].User_Type + "')";
                return db.Execute_Query(query);
            }
            else
                return false;
        }

        public bool UpdateUserMaster(List<User_Master> user)
        {
            DBClass db = new DBClass();
            string query = "";
            if (user != null)
            {
                query = "Update User_Master set User_Name = '" + user[0].User_Name + "', User_Password = '" + user[0].User_Password + "', User_Type = '" + user[0].User_Type + "' where User_ID = '" + user[0].User_ID + "'";
                return db.Execute_Query(query);
            }
            else
                return false;
        }

        public bool DeleteUserMaster(string userID)
        {
            DBClass db = new DBClass();
            string query = "";
            if (userID != "")
            {
                query = "Delete from User_Master where User_ID = '" + userID + "'";
                return db.Execute_Query(query);
            }
            else
                return false;
        }
        #endregion

        #region Customer Functions
        public List<Customer_Master> GetCustomerMaster(string ID)
        {
            List<Customer_Master> cust = new List<Customer_Master>();
            DBClass db = new DBClass();
            string query = "";
            if (ID == "" || ID == null)
                query = "Select * from Customer_Master";
            else
                query = "Select * from Customer_Master where Customer_ID = '" + ID + "'";
            cust = db.GetTableObject<Customer_Master>(query);
            return cust;
        }

        public bool SaveCustomerMaster(List<Customer_Master> cust)
        {
            DBClass db = new DBClass();
            string query = "";
            if (cust != null)
            {
                query = "Insert into Customer_Master (Customer_ID, Customer_Name, Customer_Address, Customer_Mobile, Customer_Email, Customer_DOB, Customer_Group, Country) values ('" + cust[0].Customer_ID + "','" + cust[0].Customer_Name + "','" + cust[0].Customer_Address + "','" + cust[0].Customer_Mobile + "','" + cust[0].Customer_Email + "','" + cust[0].Customer_DOB + "', '" + cust[0].Customer_Group + "', '" + cust[0].Country + "')";
                return db.Execute_Query(query);
            }
            else
                return false;
        }

        public bool UpdateCustomerMaster(List<Customer_Master> cust)
        {
            DBClass db = new DBClass();
            string query = "";
            if (cust != null)
            {
                query = "Update Customer_Master set Customer_Name = '" + cust[0].Customer_Name + "', Customer_Address = '" + cust[0].Customer_Address + "', Customer_Mobile = '" + cust[0].Customer_Mobile + "', Customer_Email = '" + cust[0].Customer_Email + "', Customer_DOB = '" + cust[0].Customer_DOB + "', Customer_Group = '" + cust[0].Customer_Group + "', Country = '" + cust[0].Country + "' where Customer_ID = '" + cust[0].Customer_ID + "'";
                return db.Execute_Query(query);
            }
            else
                return false;
        }

        public bool DeleteCustomerMaster(string custID)
        {
            DBClass db = new DBClass();
            string query = "";
            if (custID != "")
            {
                query = "Delete from Customer_Master where Customer_ID = '" + custID + "'";
                return db.Execute_Query(query);
            }
            else
                return false;
        }
        #endregion

        #region Country Functions
        public List<Country_Master> GetCountryMaster(string ID)
        {
            List<Country_Master> user = new List<Country_Master>();
            DBClass db = new DBClass();
            string query = "";
            if (ID == "" || ID == null)
                query = "Select * from Country_Master";
            else
                query = "Select * from Country_Master where Country_ID = '" + ID + "'";
            user = db.GetTableObject<Country_Master>(query);
            return user;
        }

        public bool SaveCountryMaster(List<Country_Master> count)
        {
            DBClass db = new DBClass();
            string query = "";
            if (count != null)
            {
                query = "Insert into Country_Master (Country_ID, Country_Name) values ('" + count[0].Country_ID + "','" + count[0].Country_Name + "')";
                return db.Execute_Query(query);
            }
            else
                return false;
        }

        public bool UpdateCountryMaster(List<Country_Master> count)
        {
            DBClass db = new DBClass();
            string query = "";
            if (count != null)
            {
                query = "Update Country_Master set Country_Name = '" + count[0].Country_Name + "' where Country_ID = '" + count[0].Country_ID + "'";
                return db.Execute_Query(query);
            }
            else
                return false;
        }

        public bool DeleteCountryMaster(string ID)
        {
            DBClass db = new DBClass();
            string query = "";
            if (ID != "")
            {
                query = "Delete from Country_Master where Country_ID = '" + ID + "'";
                return db.Execute_Query(query);
            }
            else
                return false;
        }
        #endregion

        #region District Functions
        public List<District_Master> GetDistrictMaster(string ID)
        {
            List<District_Master> user = new List<District_Master>();
            DBClass db = new DBClass();
            string query = "";
            if (ID == "" || ID == null)
                query = "Select * from District_Master";
            else
                query = "Select * from District_Master where District_ID = '" + ID + "'";
            user = db.GetTableObject<District_Master>(query);
            return user;
        }

        public bool SaveDistrictMaster(List<District_Master> dist)
        {
            DBClass db = new DBClass();
            string query = "";
            if (dist != null)
            {
                query = "Insert into District_Master (District_ID, District_Name) values ('" + dist[0].District_ID + "','" + dist[0].District_Name + "')";
                return db.Execute_Query(query);
            }
            else
                return false;
        }

        public bool UpdateDistrictMaster(List<District_Master> dist)
        {
            DBClass db = new DBClass();
            string query = "";
            if (dist != null)
            {
                query = "Update District_Master set District_Name = '" + dist[0].District_Name + "' where District_ID = '" + dist[0].District_ID + "'";
                return db.Execute_Query(query);
            }
            else
                return false;
        }

        public bool DeleteDistrictMaster(string ID)
        {
            DBClass db = new DBClass();
            string query = "";
            if (ID != "")
            {
                query = "Delete from District_Master where District_ID = '" + ID + "'";
                return db.Execute_Query(query);
            }
            else
                return false;
        }
        #endregion

        #region Excusrion Functions
        public List<Excursion_Master> GetExcursionMaster(string ID)
        {
            List<Excursion_Master> user = new List<Excursion_Master>();
            DBClass db = new DBClass();
            string query = "";
            if (ID == "" || ID == null)
                query = "Select * from Excursion_Master";
            else
                query = "Select * from Excursion_Master where Excursion_ID = '" + ID + "'";
            user = db.GetTableObject<Excursion_Master>(query);
            return user;
        }

        public List<Excursion_Master> GetExcursionRatesPerPackage(string ID)
        {
            List<Excursion_Master> user = new List<Excursion_Master>();
            DBClass db = new DBClass();
            string query = "Select e.Excursion_ID, e.Excursion_Name, p.No_Of_Days, e.Excursion_Rate from Excursion_Master e, Packages_Master p " +
                "where e.Excursion_ID = p.Excursion_ID and p.Package_ID = '" + ID + "'";
            user = db.GetTableObject<Excursion_Master>(query);
            return user;
        }

        public List<Excursion_Master> GetDistrictUsingExcursion(string ID)
        {
            List<Excursion_Master> user = new List<Excursion_Master>();
            DBClass db = new DBClass();
            string query = "Select District_ID from Excursion_Master where Excursion_ID = '" + ID + "'";
            user = db.GetTableObject<Excursion_Master>(query);
            return user;
        }

        public bool SaveExcursionMaster(List<Excursion_Master> ex)
        {
            DBClass db = new DBClass();
            string query = "";
            if (ex != null)
            {
                query = "Insert into Excursion_Master (Excursion_ID, Excursion_Name, Excursion_Rate, District_ID, District_Name) values ('" + ex[0].Excursion_ID + "','" + ex[0].Excursion_Name + "','" + ex[0].Excursion_Rate + "','" + ex[0].District_ID + "', '" + ex[0].District_Name + "')";
                return db.Execute_Query(query);
            }
            else
                return false;
        }

        public bool UpdateExcursionMaster(List<Excursion_Master> ex)
        {
            DBClass db = new DBClass();
            string query = "";
            if (ex != null)
            {
                query = "Update Excursion_Master set Excursion_Name = '" + ex[0].Excursion_Name + "', Excursion_Rate = '" + ex[0].Excursion_Rate + "', District_ID = '" + ex[0].District_ID + "', District_Name = '" + ex[0].District_Name + "' where Excursion_ID = '" + ex[0].Excursion_ID + "'";
                return db.Execute_Query(query);
            }
            else
                return false;
        }

        public bool DeleteExcurionMaster(string userID)
        {
            DBClass db = new DBClass();
            string query = "";
            if (userID != "")
            {
                query = "Delete from Excursion_Master where Excursion_ID = '" + userID + "'";
                return db.Execute_Query(query);
            }
            else
                return false;
        }
        #endregion

        #region Chauffer Functions
        public List<Chauffer_Master> GetChaufferMaster(string ID)
        {
            List<Chauffer_Master> chauf = new List<Chauffer_Master>();
            DBClass db = new DBClass();
            string query = "";
            if (ID == "" || ID == null)
                query = "Select * from Chauffer_Master";
            else
                query = "Select * from Chauffer_Master where Chauffer_ID = '" + ID + "'";
            chauf = db.GetTableObject<Chauffer_Master>(query);
            return chauf;
        }

        public bool SaveChaufferMaster(List<Chauffer_Master> chauf)
        {
            DBClass db = new DBClass();
            string query = "";
            if (chauf != null)
            {
                query = "Insert into Chauffer_Master (Chauffer_ID, Chauffer_Name, Chauffer_Address, Chauffer_Mobile, Chauffer_Email, Vehicle_No, Vehicle_Type, Vehicle_Model, Day_Rate) values ('" + chauf[0].Chauffer_ID + "','" + chauf[0].Chauffer_Name + "','" + chauf[0].Chauffer_Address + "','" + chauf[0].Chauffer_Mobile + "','" + chauf[0].Chauffer_Email + "','" + chauf[0].Vehicle_No + "', '" + chauf[0].Vehicle_Type + "', '" + chauf[0].Vehicle_Model + "', '" + chauf[0].Day_Rate + "')";
                return db.Execute_Query(query);
            }
            else
                return false;
        }

        public bool UpdateChaufferMaster(List<Chauffer_Master> chauf)
        {
            DBClass db = new DBClass();
            string query = "";
            if (chauf != null)
            {
                query = "Update Chauffer_Master set Chauffer_Name = '" + chauf[0].Chauffer_Name + "', Chauffer_Address = '" + chauf[0].Chauffer_Address + "', Chauffer_Mobile = '" + chauf[0].Chauffer_Mobile + "', Chauffer_Email = '" + chauf[0].Chauffer_Email + "', Vehicle_No = '" + chauf[0].Vehicle_No + "', Vehicle_Type = '" + chauf[0].Vehicle_Type + "', Vehicle_Model = '" + chauf[0].Vehicle_Model + "', Day_Rate = '" + chauf[0].Day_Rate + "' where Chauffer_ID = '" + chauf[0].Chauffer_ID + "'";
                return db.Execute_Query(query);
            }
            else
                return false;
        }

        public bool DeleteChaufferMaster(string ID)
        {
            DBClass db = new DBClass();
            string query = "";
            if (ID != "")
            {
                query = "Delete from Chauffer_Master where Chauffer_ID = '" + ID + "'";
                return db.Execute_Query(query);
            }
            else
                return false;
        }
        #endregion

        #region Package Functions
        public List<Packages_Master> GetPackageMaster(string ID)
        {
            List<Packages_Master> cust = new List<Packages_Master>();
            DBClass db = new DBClass();
            string query = "";
            if (ID == "" || ID == null)
                query = "Select * from Packages_Master";
            else
                query = "Select * from Packages_Master where Package_ID = '" + ID + "'";
            cust = db.GetTableObject<Packages_Master>(query);
            return cust;
        }

        public List<Packages_Master> GetSumDaysPerPackage(string ID)
        {
            List<Packages_Master> cust = new List<Packages_Master>();
            DBClass db = new DBClass();
            string query = "Select Sum(No_Of_Days) as No_Of_Days from Packages_Master where Package_ID = '" + ID + "'";
            cust = db.GetTableObject<Packages_Master>(query);
            return cust;
        }

        public List<Packages_Master> GetDistrictMasterForList()
        {
            List<Packages_Master> user = new List<Packages_Master>();
            DBClass db = new DBClass();
            string query = "Select distinct Package_ID, Package_Name from Packages_Master Group by Package_ID, Package_Name";
            user = db.GetTableObject<Packages_Master>(query);
            return user;
        }

        public bool SavePackageMaster(List<Packages_Master> pack)
        {
            DBClass db = new DBClass();
            string query = "";
            if (pack != null)
            {
                if(pack.Count > 1)
                {
                    for (int i = 0; i < pack.Count; i++)
                    {
                        query = "Insert into Packages_Master (Package_ID, Package_Name, No_Of_Days, Excursion_ID, Excursion_Name, District_ID, District_Name) values ('" + pack[i].Package_ID + "','" + pack[i].Package_Name + "','" + pack[i].No_Of_Days + "','" + pack[i].Excursion_ID + "','" + pack[i].Excursion_Name + "','" + pack[i].District_ID + "', '" + pack[i].District_Name + "')";
                        db.Execute_Query(query);
                    }
                 
                    return true;
                }
                else
                {
                    query = "Insert into Packages_Master (Package_ID, Package_Name, No_Of_Days, Excursion_ID, Excursion_Name, District_ID, District_Name) values ('" + pack[0].Package_ID + "','" + pack[0].Package_Name + "','" + pack[0].No_Of_Days + "','" + pack[0].Excursion_ID + "','" + pack[0].Excursion_Name + "','" + pack[0].District_ID + "', '" + pack[0].District_Name + "')";
                    return db.Execute_Query(query);
                }  
            }
            else
                return false;
        }

        public bool UpdatePackageMaster(List<Packages_Master> pack)
        {
            DBClass db = new DBClass();
            string query = "";
            if (pack != null)
            {
                if (pack.Count > 1)
                {
                    db.Execute_Query("Delete from Packages_Master where Package_ID = '" + pack[0].Package_ID + "'");

                    for (int i = 0; i < pack.Count; i++)
                    {
                        query = "Insert into Packages_Master (Package_ID, Package_Name, No_Of_Days, Excursion_ID, Excursion_Name, District_ID, District_Name) values ('" + pack[i].Package_ID + "','" + pack[i].Package_Name + "','" + pack[i].No_Of_Days + "','" + pack[i].Excursion_ID + "','" + pack[i].Excursion_Name + "','" + pack[i].District_ID + "', '" + pack[i].District_Name + "')";
                        db.Execute_Query(query);
                    }
                    return true;
                }
                else
                {
                    query = "Update Packages_Master set Package_Name = '" + pack[0].Package_Name + "', No_Of_Days = '" + pack[0].No_Of_Days + "', Excursion_ID = '" + pack[0].Excursion_ID + "', Excursion_Name = '" + pack[0].Excursion_Name + "', District_ID = '" + pack[0].District_ID + "', District_Name = '" + pack[0].District_Name + "' where Excursion_ID = '" + pack[0].Excursion_ID + "'";
                    return db.Execute_Query(query);
                }
            }
            else
                return false;
        }

        public bool DeletePackageMaster(string ID)
        {
            DBClass db = new DBClass();
            string query = "";
            if (ID != "")
            {
                query = "Delete from Packages_Master where Package_ID = '" + ID + "'";
                return db.Execute_Query(query);
            }
            else
                return false;
        }
        #endregion

        #region Hotel Functions
        public List<Hotel_Master> GetHotelMaster(string ID)
        {
            List<Hotel_Master> cust = new List<Hotel_Master>();
            DBClass db = new DBClass();
            string query = "";
            if (ID == "" || ID == null)
                query = "Select * from Hotel_Master";
            else
                query = "Select * from Hotel_Master where Hotel_ID = '" + ID + "'";
            cust = db.GetTableObject<Hotel_Master>(query);
            return cust;
        }

        public List<Hotel_Master> GetRatesperType(string ID, string Room_Type)
        {
            List<Hotel_Master> cust = new List<Hotel_Master>();
            DBClass db = new DBClass();
            string query = "Select BB_Rate, HB_Rate, FB_Rate, RO_Rate from Hotel_Master where Room_Type = '" + Room_Type + "' and Hotel_ID = '" + ID + "'";
            cust = db.GetTableObject<Hotel_Master>(query);
            return cust;
        }

        public List<Hotel_Master> GetHotelMastForList()
        {
            List<Hotel_Master> user = new List<Hotel_Master>();
            DBClass db = new DBClass();
            string query = "Select distinct Hotel_ID, Hotel_Name from Hotel_Master Group by Hotel_ID, Hotel_Name";
            user = db.GetTableObject<Hotel_Master>(query);
            return user;
        }

        public bool SaveHotelMaster(List<Hotel_Master> hotel)
        {
            DBClass db = new DBClass();
            string query = "";
            if (hotel != null)
            {
                if (hotel.Count > 1)
                {
                    for (int i = 0; i < hotel.Count; i++)
                    {
                        query = "Insert into Hotel_Master (Hotel_ID, Hotel_Name, Hotel_Address, Hotel_Number, Hotel_Email, Room_Type, RO_Rate, BB_Rate, HB_Rate, FB_Rate) values ('" + hotel[i].Hotel_ID + "','" + hotel[i].Hotel_Name + "','" + hotel[i].Hotel_Address + "','" + hotel[i].Hotel_Number + "','" + hotel[i].Hotel_Email + "','" + hotel[i].Room_Type + "', '" + hotel[i].RO_Rate + "','" + hotel[i].BB_Rate + "','" + hotel[i].HB_Rate + "','" + hotel[i].FB_Rate + "')";
                        db.Execute_Query(query);
                    }

                    return true;
                }
                else
                {
                    query = "Insert into Hotel_Master (Hotel_ID, Hotel_Name, Hotel_Address, Hotel_Number, Hotel_Email, Room_Type, RO_Rate, BB_Rate, HB_Rate, FB_Rate) values ('" + hotel[0].Hotel_ID + "','" + hotel[0].Hotel_Name + "','" + hotel[0].Hotel_Address + "','" + hotel[0].Hotel_Number + "','" + hotel[0].Hotel_Email + "','" + hotel[0].Room_Type + "', '" + hotel[0].RO_Rate + "','" + hotel[0].BB_Rate + "','" + hotel[0].HB_Rate + "','" + hotel[0].FB_Rate + "')";
                    return db.Execute_Query(query);
                }
            }
            else
                return false;
        }

        public bool UpdateHotelMaster(List<Hotel_Master> hotel)
        {
            DBClass db = new DBClass();
            string query = "";
            if (hotel != null)
            {
                if (hotel.Count > 1)
                {
                    db.Execute_Query("Delete from Hotel_Master where Hotel_ID = '" + hotel[0].Hotel_ID + "'");

                    for (int i = 0; i < hotel.Count; i++)
                    {
                        query = "Insert into Hotel_Master (Hotel_ID, Hotel_Name, Hotel_Address, Hotel_Number, Hotel_Email, Room_Type, RO_Rate, BB_Rate, HB_Rate, FB_Rate) values ('" + hotel[i].Hotel_ID + "','" + hotel[i].Hotel_Name + "','" + hotel[i].Hotel_Address + "','" + hotel[i].Hotel_Number + "','" + hotel[i].Hotel_Email + "','" + hotel[i].Room_Type + "', '" + hotel[i].RO_Rate + "','" + hotel[i].BB_Rate + "','" + hotel[i].HB_Rate + "','" + hotel[i].FB_Rate + "')";
                        db.Execute_Query(query);
                    }
                    return true;
                }
                else
                {
                    query = "Update Hotel_Master set Hotel_Name = '" + hotel[0].Hotel_Name + "', Hotel_Address = '" + hotel[0].Hotel_Address + "', Hotel_Number = '" + hotel[0].Hotel_Number + "', Hotel_Email = '" + hotel[0].Hotel_Email + "', Room_Type = '" + hotel[0].Room_Type + "', RO_Rate = '" + hotel[0].RO_Rate + "', BB_Rate = '" + hotel[0].BB_Rate + "', HB_Rate = '" + hotel[0].HB_Rate + "', FB_Rate = '" + hotel[0].FB_Rate + "' where Hotel_ID = '" + hotel[0].Hotel_ID + "'";
                    return db.Execute_Query(query);
                }
            }
            else
                return false;
        }

        public bool DeleteHotelMaster(string ID)
        {
            DBClass db = new DBClass();
            string query = "";
            if (ID != "")
            {
                query = "Delete from Hotel_Master where Hotel_ID = '" + ID + "'";
                return db.Execute_Query(query);
            }
            else
                return false;
        }
        #endregion

        #region Tour Functions
        public List<Tour_Master> GetTourMaster(string ID)
        {
            List<Tour_Master> tour = new List<Tour_Master>();
            DBClass db = new DBClass();
            string query = "";
            if (ID == "" || ID == null)
                query = "Select * from Tour_Master";
            else
                query = "Select * from Tour_Master where Tour_ID = '" + ID + "'";
            tour = db.GetTableObject<Tour_Master>(query);
            return tour;
        }

        public List<Tour_Master> GetTourMastCombo()
        {
            List<Tour_Master> user = new List<Tour_Master>();
            DBClass db = new DBClass();
            string query = "Select distinct Tour_ID, Customer_Code, Chauffer_ID from Tour_Master Group by Tour_ID, Customer_Code, Chauffer_ID";
            user = db.GetTableObject<Tour_Master>(query);
            return user;
        }

        public bool SaveTourMaster(List<Tour_Master> tour)
        {
            DBClass db = new DBClass();
            string query = "";
            if (tour != null)
            {
                if (tour.Count > 1)
                {
                    for (int i = 0; i < tour.Count; i++)
                    {
                        query = "Insert into Tour_Master (Tour_ID, Package_ID, Package_Name, Start_Date, No_of_Days, Customer_Code, Customer_Name, Tour_Status, Hotel_ID, Hotel_Name, Room_Type, Booking_Type, Chauffer_ID, Chauffer_Name, Hotel_Total, Chauffer_Total, Excursion_Total, Total_Amount) values ('" + tour[i].Tour_ID + "','" + tour[i].Package_ID + "','" + tour[i].Package_Name + "','" + tour[i].Start_Date + "','" + tour[i].No_Of_Days + "','" + tour[i].Customer_Code + "', '" + tour[i].Customer_Name + "','" + tour[i].Tour_Status + "','" + tour[i].Hotel_ID + "','" + tour[i].Hotel_Name + "', '" + tour[i].Room_Type + "', '" + tour[i].Booking_Type + "', '" + tour[i].Chauffer_ID + "', '" + tour[i].Chauffer_Name + "', '" + tour[i].Hotel_Total + "', '" + tour[i].Chauffer_Total + "', '" + tour[i].Excursion_Total + "' , '" + tour[i].Total_Amount + "')";
                        db.Execute_Query(query);
                    }

                    return true;
                }
                else
                {
                    query = "Insert into Tour_Master (Tour_ID, Package_ID, Package_Name, Start_Date, No_of_Days, Customer_Code, Customer_Name, Tour_Status, Hotel_ID, Hotel_Name, Room_Type, Booking_Type, Chauffer_ID, Chauffer_Name, Hotel_Total, Chauffer_Total, Excursion_Total, Total_Amount) values ('" + tour[0].Tour_ID + "','" + tour[0].Package_ID + "','" + tour[0].Package_Name + "','" + tour[0].Start_Date + "','" + tour[0].No_Of_Days + "','" + tour[0].Customer_Code + "', '" + tour[0].Customer_Name + "','" + tour[0].Tour_Status + "','" + tour[0].Hotel_ID + "','" + tour[0].Hotel_Name + "', '" + tour[0].Room_Type + "', '" + tour[0].Booking_Type + "', '" + tour[0].Chauffer_ID + "', '" + tour[0].Chauffer_Name + "', '" + tour[0].Hotel_Total + "', '" + tour[0].Chauffer_Total + "', '" + tour[0].Excursion_Total + "', '" + tour[0].Total_Amount + "')";
                    return db.Execute_Query(query);
                }
            }
            else
                return false;
        }

        public bool UpdateTourMaster(List<Tour_Master> tour)
        {
            DBClass db = new DBClass();
            string query = "";
            if (tour != null)
            {
                if (tour.Count > 1)
                {
                    db.Execute_Query("Delete from Tour_Master where Tour_ID = '" + tour[0].Tour_ID + "'");

                    for (int i = 0; i < tour.Count; i++)
                    {
                        query = "Insert into Tour_Master (Tour_ID, Package_ID, Package_Name, Start_Date, No_of_Days, Customer_Code, Customer_Name, Tour_Status, Hotel_ID, Hotel_Name, Room_Type, Booking_Type, Chauffer_ID, Chauffer_Name, Hotel_Total, Chauffer_Total, Excursion_Total, Total_Amount) values ('" + tour[i].Tour_ID + "','" + tour[i].Package_ID + "','" + tour[i].Package_Name + "','" + tour[i].Start_Date + "','" + tour[i].No_Of_Days + "','" + tour[i].Customer_Code + "', '" + tour[i].Customer_Name + "','" + tour[i].Tour_Status + "','" + tour[i].Hotel_ID + "','" + tour[i].Hotel_Name + "', '" + tour[i].Room_Type + "', '" + tour[i].Booking_Type + "', '" + tour[i].Chauffer_ID + "', '" + tour[i].Chauffer_Name + "', '" + tour[i].Hotel_Total + "', '" + tour[i].Chauffer_Total + "', '" + tour[i].Excursion_Total + "' , '" + tour[i].Total_Amount + "')";
                        db.Execute_Query(query);
                    }
                    return true;
                }
                else
                { 
                    query = "Update Tour_Master Set Package_ID = '" + tour[0].Package_ID + "', Package_Name = '" + tour[0].Package_Name + "', Start_Date = '" + tour[0].Start_Date + "', No_Of_Days = '" + tour[0].No_Of_Days + "', Customer_Code = '" + tour[0].Customer_Code + "', Customer_Name = '" + tour[0].Customer_Name + "', Tour_Status = '" + tour[0].Tour_Status + "', Hotel_ID = '" + tour[0].Hotel_ID + "', Hotel_Name = '" + tour[0].Hotel_Name + "', Room_Type = '" + tour[0].Room_Type + "', Booking_Type = '" + tour[0].Booking_Type + "', Chauffer_ID = '" + tour[0].Chauffer_ID + "', Chauffer_Name = '" + tour[0].Chauffer_Name + "', Hotel_Total = '" + tour[0].Hotel_Total + "', Chauffer_Total = '" + tour[0].Chauffer_Total + "', Excursion_Total = '" + tour[0].Excursion_Total + "', Total_Amount =  '" + tour[0].Total_Amount + "' where Tour_ID = '" + tour[0].Tour_ID + "'";
                    return db.Execute_Query(query);
                }
            }
            else
                return false;
        }

        public bool DeleteTourMaster(string ID)
        {
            DBClass db = new DBClass();
            string query = "";
            if (ID != "")
            {
                query = "Delete from Tour_Master where Tour_ID = '" + ID + "'";
                return db.Execute_Query(query);
            }
            else
                return false;
        }
        #endregion

        #region Generate Report Data Tables
        //Return Tour Invoices 
        public DataTable Generate_Tour_Invoice(string ID)
        {
            DBClass db = new DBClass();
            string query = @"Select * from Tour_Master where Tour_ID = '" + ID + "'";
            return db.Get_Into_DataTable(query);
        }

        //Return Tour Invoices 
        public DataTable Generate_Tour_Invoice_Package(string ID)
        {
            DBClass db = new DBClass();
            string query = @"Select * from Packages_Master where Package_ID = '" + ID + "'";
            return db.Get_Into_DataTable(query);
        }

        //Return Tour Expenses Data Table
        public DataTable Generate_Tour_Master_Report(DateTime From, DateTime To, string ID)
        {
            DBClass db = new DBClass();
            string query = "";
            if(ID == "")
                query = @"Select * from Tour_Master where Start_Date between '" + From + "' and '" + To + "'";
            else
                query = @"Select * from Tour_Master where Start_Date between '" + From + "' and '" + To + "' and Tour_ID = '" + ID + "'";

            return db.Get_Into_DataTable(query);
        }

        //Return Chauffer Expenses Data Table
        public DataTable Generate_Chauffer_Expenses_Report(DateTime From, DateTime To, string ID)
        {
            DBClass db = new DBClass();
            string query = "";
            if (ID == "All")
                query = @"Select t.Tour_ID, c.Chauffer_ID, c.Chauffer_Name, Sum(t.Chauffer_Total) as Chauffer_Total, c.Day_Rate, t.Start_date from Tour_Master t, Chauffer_Master c
                        where c.Chauffer_ID = t.Chauffer_ID and t.Start_date between '" + From + "' and '" + To + "'" +
                        " group by c.Chauffer_ID, c.Chauffer_Name, c.Day_Rate, t.Tour_ID, t.Start_Date";
            else
                query = @"Select t.Tour_ID, c.Chauffer_ID, c.Chauffer_Name, Sum(t.Chauffer_Total) as Chauffer_Total, c.Day_Rate, t.Start_date from Tour_Master t, Chauffer_Master c
                        where c.Chauffer_ID = t.Chauffer_ID and t.Start_date between '" + From + "' and '" + To + "' and t.Chauffer_ID = '" + ID + "' " +
                        "group by c.Chauffer_ID, c.Chauffer_Name, c.Day_Rate, t.Tour_ID, t.Start_Date";

            return db.Get_Into_DataTable(query);
        }

        //Return Chauffer Expenses Data Table
        public DataTable Generate_Excursion_Expenses_Report(DateTime From, DateTime To)
        {
            DBClass db = new DBClass();
            string query = @"Select distinct Tour_ID, Package_Name, Customer_Name, Start_Date, Sum(Excursion_Total) as Excursion_Total from Tour_Master
                            Where Start_Date between '" + From + "' and '" + To + "' Group by Tour_ID, Package_Name, Start_Date, Customer_Name";
           

            return db.Get_Into_DataTable(query);
        }

        //Return Hotel Expenses Data Table
        public DataTable Generate_Hotel_Expenses_Report(DateTime From, DateTime To, string ID)
        {
            DBClass db = new DBClass();
            string query = "";
            if (ID == "All")
                query = @"Select t.Tour_ID, h.Hotel_ID, h.Hotel_Name, Sum(t.Hotel_Total) as Hotel_Total, t.Start_date 
                            from Tour_Master t, Hotel_Master h
                            where h.Hotel_ID= t.Hotel_ID and t.Start_date between '" + From + "' and '" + To + "' group by h.Hotel_ID, h.Hotel_Name, t.Tour_ID, t.Start_Date";
            else
                query = @"Select t.Tour_ID, h.Hotel_ID, h.Hotel_Name, Sum(t.Hotel_Total) as Hotel_Total, t.Start_date 
                            from Tour_Master t, Hotel_Master h
                            where h.Hotel_ID= t.Hotel_ID and t.Start_date between '" + From + "' and '" + To + "' and h.Hotel_ID = '" + ID + "' group by h.Hotel_ID, h.Hotel_Name, " +
                            "t.Tour_ID, t.Start_Date";

            return db.Get_Into_DataTable(query);
        }

        //Return Hotel Master Data Table
        public DataTable Generate_Hotel_Master_Report()
        {
            DBClass db = new DBClass();
            string query = @"Select * from Hotel_Master";
            return db.Get_Into_DataTable(query);
        }

        //Return Customer Master Data Table
        public DataTable Generate_Customer_Master_Report(string Type, string Country)
        {
            DBClass db = new DBClass();
            string query = @"Select * from Customer_Master";

            if (Type != "All" && Country == "All")
                query += " where Customer_Group = '" + Type + "'";
            if (Country != "All" && Type == "All")
                query += " where Country = '" + Country + "'";
            if (Type != "All" && Country != "All")
                query += " where Country = '" + Country + "' and Customer_Group = '" + Type + "'";

            return db.Get_Into_DataTable(query);
        }

        //Return Chauffer Master Data Table
        public DataTable Generate_Chauffer_Master_Report()
        {
            DBClass db = new DBClass();
            string query = @"Select * from Chauffer_Master";
            return db.Get_Into_DataTable(query);
        }

        //Return Excursion Master Data Table
        public DataTable Generate_Excursion_Master_Report()
        {
            DBClass db = new DBClass();
            string query = @"Select * from Excursion_Master";
            return db.Get_Into_DataTable(query);
        }

        //Return Packages Master Data Table
        public DataTable Generate_Packages_Master_Report()
        {
            DBClass db = new DBClass();
            string query = @"Select * from Packages_Master";
            return db.Get_Into_DataTable(query);
        }

        #endregion

        #region Dashboard Functions

        public List<Customer_Master> getCustomerbyCountry()
        {
            DBClass db = new DBClass();
            List<Customer_Master> cust = new List<Customer_Master>();
            string strqry = "Select distinct count(Country) as Count, Country from Customer_Master Group by Country";
            cust = db.GetTableObject<Customer_Master>(strqry);
            return cust;
        }

        public List<Chauffer_Master> getMostPaidChauffer()
        {
            DBClass db = new DBClass();
            List<Chauffer_Master> cust = new List<Chauffer_Master>();
            string strqry = "Select distinct Chauffer_ID, Chauffer_Name, Day_Rate from Chauffer_Master";
            cust = db.GetTableObject<Chauffer_Master>(strqry);
            return cust;
        }
        #endregion
    }
}
