using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System.Data;


public class Contents : MonoBehaviour
{
    public string SQLQuery;
    //public string ConnectionString;
    public string[] QueryResult;
    public GameObject User;
    //string formatForMySql = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

    public void Start()
    {
        User = GameObject.Find("User");
        AddContents("bakery", "bread", "2021-04-14 22:40:00", "2021-04-14 22:45:00", 1, 11);
    }
    public void GetServerDateTime()
    {

    }
    public void AddContents(string subject_parent, string subject_child, string time_loading,string time_shipment, int output_quantity, int user_id)
    {
        
        //SQLQuery = "SELECT id_user from Users WHERE login='" + UserName + "' AND pasword='" + UserPassword + "'";
        SQLQuery = "INSERT contents (subject_parent, subject_child, time_loading, time_shipment, output_quantity, user_id) VALUES ('"+subject_parent+ "','" + subject_child + "','" + time_loading + "','" + time_shipment + "'," + output_quantity + "," + user_id + ")";
        IDbConnection dbcon;
        using (dbcon = new SqlConnection(User.GetComponent<UserData>().ConnectionString))
        {
            dbcon.Open();//Открытие соединения с базой данных
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                dbcmd.CommandText = SQLQuery;
            }
        }
    }
}
