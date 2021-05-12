using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;


public class Contents : MonoBehaviour
{
    //Класс отвечает за работу с таблицей Contents в БД
    //string formatForMySql = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

    public void Start()
    {
        AddContents("Bakery", "Bread", gameObject.GetComponent<Users>().IDUser);      
    }
    public static string GetSubjectChildInTheProcessOfAssembly(string subject_parent, int number_slot, int user_id) //Получаем продукт, находящийся в производстве для каждого слота по номеру
    {
        Debug.Log("GetSubjectChildQueue");
        Debug.Log(Connections.ConnectionString);
        MySqlConnection conn = new MySqlConnection(Connections.ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            //var SQLQuery = "SELECT subject_child FROM contents WHERE time_shipment > NOW() AND user_id='" + user_id + "' AND subject_parent='" + subject_parent + "' ORDER BY id_content ASC LIMIT '" + number_slot + "',1";
            var SQLQuery = "SELECT subject_child FROM contents WHERE time_shipment > NOW() AND user_id=" + user_id + " AND subject_parent='" + subject_parent + "' ORDER BY id_content ASC LIMIT " + number_slot + ",1";
            MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return (string)reader["subject_child"]; 
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
    static string GetServerDateTime()//Получаем серверное время
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
    static int GetOutputQuantity(string subjectName) //Получаем количество продукта на выходе
    {
        int outputQuantity;
        Debug.Log("GetOutputQuantity");
        Debug.Log(Connections.ConnectionString);
        MySqlConnection conn = new MySqlConnection(Connections.ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var SQLQuery = "SELECT output_quantity from output_quantity_subjects WHERE name_subject='" + subjectName + "' LIMIT 0,1 ";
            MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                outputQuantity = (int)reader["output_quantity"];

                Debug.Log(outputQuantity);
                return outputQuantity;
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
    static string GetSummDateTimeAndSeconds(string time, int second) //Прибавляем дате определенное количество секунд
    {
        var convertA = DateTime.Parse(time);//Конвертируем строку в дату
        return convertA.AddSeconds(second).ToString("yyyy-MM-dd HH:mm:ss"); 
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
    }//Проверяем соединение с БД
    public void AddContents(string subjectParent, string subjectChild, int userId) //Метод только добавляет в БД полученные значения
    {
        string timeLoading = GetServerDateTime();//Дата загрузки равна текущему времени сервера
        string timeShipment = GetSummDateTimeAndSeconds(timeLoading, GetTimeBuilding(subjectChild));//Время отгрузки равно текущему времени сервера плюс время изготовления объекта
        int outputQuantity = GetOutputQuantity(subjectChild);//Количество на выходе равно, значению из таблицы output_quantity

        //var timeShipmentTemp = DateTime.Parse(timeShipment);//Конвертируем строку в дату
        //timeShipmentTemp.AddSeconds(GetTimeBuilding(subjectChild));//Прибавляем конвертированной дате секунды производства равную времени производства объъекта
        //timeShipment = timeShipmentTemp.ToString("yyyy-MM-dd HH:mm:ss"); //Конвертируем дату во время определенного формата БД MySQL
        var SQLQuery = "INSERT contents (subject_parent, subject_child, time_loading, time_shipment, output_quantity, user_id) VALUES ('"+subjectParent+ "','" + subjectChild + "','" + timeLoading + "','" + timeShipment + "'," + outputQuantity + "," + userId + ")";
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
