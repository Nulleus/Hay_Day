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
        AddContents("Bakery", "Bread", GetServerDateTime(), ServerDateTime, 1, 11);
        
    }
    static string GetServerDateTime()
    {
        DateTime serverDateTime;
        string serverDateTimeTemp;        
        Debug.Log("GetServerDateTime");
        Debug.Log(Connections.ConnectionString);
        MySqlConnection conn = new MySqlConnection(Connections.ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var SQLQuery = "SELECT NOW()";
            MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                serverDateTime = (DateTime)reader["NOW()"];//Получаем текущую дату серверного времени
                //ServerDateTimeTemp.AddSeconds(GetTimeBuilding("Wheat")); //Прибавляем секунды к дате
                //serverDateTimeTemp = serverDateTime.ToString("u");//u: 2008-06-15 21:15:07Z
                serverDateTimeTemp = serverDateTime.ToString("yyyy-MM-dd HH:mm:ss");//
                Debug.Log("NOW()=" + serverDateTimeTemp);
                return serverDateTimeTemp;               
            }
            reader.Close();
        }
        catch (Exception ex)
        {            
            Debug.Log(ex.ToString());
            return "Error";
        }
        conn.Close();
        Debug.Log("Done.");
        return "Done";
    }
    static int GetTimeBuilding(string subjectName) //Получаем время сборки предмета
    {
        int buildingTime;
        Debug.Log("GetTimeBuilding");
        Debug.Log(Connections.ConnectionString);
        MySqlConnection conn = new MySqlConnection(Connections.ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var SQLQuery = "SELECT building_time from subjects WHERE name_subject='" + subjectName + "' LIMIT 0,1 ";
            MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                buildingTime = (int)reader["building_time"];
                
                Debug.Log(buildingTime);
                return buildingTime;
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
        conn.Close();
        Debug.Log("Done.");
        return 0;
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
    public void AddContents(string subjectParent, string subjectChild, string timeLoading, string timeShipment, int outputQuantity, int userId) //Метод только добавляет в БД полученные значения
    {       
        
        var timeShipmentTemp = DateTime.Parse(timeShipment);//Конвертируем строку в дату
        timeShipmentTemp.AddSeconds(GetTimeBuilding(subjectChild));//Прибавляем конвертированной дате секунды производства равную времени производства объъекта
        timeShipment = timeShipmentTemp.ToString("yyyy-MM-dd HH:mm:ss"); //Конвертируем дату во время определенного формата БД MySQL
        SQLQuery = "INSERT contents (subject_parent, subject_child, time_loading, time_shipment, output_quantity, user_id) VALUES ('"+subjectParent+ "','" + subjectChild + "','" + timeLoading + "','" + timeShipment + "'," + outputQuantity + "," + userId + ")";
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
