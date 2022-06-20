using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TravelDiaries.Classes
{
    class DBClass
    {
        SqlConnection sql_con = new SqlConnection();
        SqlCommand sql_cmd = new SqlCommand();
        string connetionString = "Data Source=.; Initial Catalog=Travel_Diary_DB;User ID=sa; Password=sa@123";

        //Opening the SQL Database Connection 
        public SqlConnection Con_Open()
        {
            sql_con = new SqlConnection(connetionString);
            if (sql_con.State == System.Data.ConnectionState.Closed)
            {
                sql_con.Open();
            }
            return sql_con;
        }

        //Executing queries in database and returning datatables
        public bool Execute_Query(string Query_Str)
        {
            sql_con = new SqlConnection(connetionString);
            sql_cmd = new SqlCommand(Query_Str);
            DataTable dt = new DataTable();
            SqlDataReader dr;

            sql_cmd.Connection = Con_Open();
            dr = sql_cmd.ExecuteReader();
            dt.Load(dr);
            sql_con.Close();
            return true;
        }

        //Returing the database value count of a particular query
        public int ReturnCount(string Query_Str)
        {
            sql_cmd = new SqlCommand(Query_Str);
            sql_cmd.Connection = Con_Open();
            var obj = sql_cmd.ExecuteScalar();
            int count = 0;
            if (obj != null || obj.ToString() != "")
            {
                count = int.Parse(obj.ToString());
            }
            return count;
        }

        //get objects or values from the table database
        public List<T> GetTableObject<T>(string Qry)
        {
            sql_con= new SqlConnection(connetionString);
            sql_cmd = new SqlCommand(Qry, sql_con);
            DataTable dt = new DataTable();
            SqlDataReader dr;
            sql_con.Open();
            List<T> myList = new List<T>();
            {
                dr = sql_cmd.ExecuteReader();
                dt.Load(dr);
                sql_con.Close();
                myList =  ConvertDataTable<T>(dt);
            }
            sql_con.Close();

            return myList;
        }

        //Converting data tables into object list 
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row); ;
                data.Add(item);
            }
            return data;
        }

        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        //convert list to datatable
        public DataTable Get_Into_DataTable(string Query_Str)
        {
            sql_cmd = new SqlCommand(Query_Str);
            DataTable dt = new DataTable();
            SqlDataReader dr;

            sql_cmd.Connection = Con_Open();
            dr = sql_cmd.ExecuteReader();
            dt.Load(dr);
            sql_con.Close();
            return dt;
        }
    }
}
