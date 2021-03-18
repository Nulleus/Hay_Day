using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;


public class Contents : MonoBehaviour
{
    public string SQLQuery;
    //public string ConnectionString;
    public string[] QueryResult;
    public string ServerDateTime;
    public DateTime ServerDateTimeTemp;
    //string formatForMySql = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

    public void Start()
    {
        GetServerDateTime();
        AddContents("bakery", "bread", ServerDateTime, ServerDateTime, 1, 11);
        
    }
    public void GetServerDateTime()
    {
        Debug.Log("GetServerDateTime");
        Debug.Log(Connections.ConnectionString);
        MySqlConnection conn = new MySqlConnection(Connections.ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            SQLQuery = "SELECT NOW()";
            MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ServerDateTimeTemp = (DateTime)reader["NOW()"];
                ServerDateTime = ServerDateTimeTemp.ToString("u");//u: 2008-06-15 21:15:07Z
                Debug.Log("NOW()=" + ServerDateTime);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
        conn.Close();
        Debug.Log("Done.");
    }
    void CheckConnections()
    {
        //Доработать входные данные 
        MySqlConnection conn = new MySqlConnection(Connections.ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();

            string sql = "SELECT COUNT(*) FROM users";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                int r = Convert.ToInt32(result);
                Debug.Log("Number of countries in the world database is: " + r);
            }

        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }

        conn.Close();
        Debug.Log("Done.");
    }
    public void AddContents(string subject_parent, string subject_child, string time_loading, string time_shipment, int output_quantity, int user_id)
    {        
        SQLQuery = "INSERT contents (subject_parent, subject_child, time_loading, time_shipment, output_quantity, user_id) VALUES ('"+subject_parent+ "','" + subject_child + "','" + time_loading + "','" + time_shipment + "'," + output_quantity + "," + user_id + ")";
        MySqlConnection conn = new MySqlConnection(Connections.ConnectionString);
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();          
            MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        conn.Close();
        Console.WriteLine("Done.");
    }
}
