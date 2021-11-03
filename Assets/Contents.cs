using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;


public class Contents : MonoBehaviour
{
    public GameObject Data;
    //Класс отвечает за работу с таблицей Contents в БД
    //string formatForMySql = dateValue.ToString("yyyy-MM-dd HH:mm:ss");

    public string GetSubjectChildInTheProcessOfAssembly(string subjectParentName, int numberSlot, int userID) //Получаем продукт, находящийся в производстве для каждого слота по номеру
    {
        Debug.Log("GetSubjectChildQueue");
        Debug.Log(Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            //var SQLQuery = "SELECT subject_child FROM contents WHERE time_shipment > NOW() AND user_id='" + user_id + "' AND subject_parent='" + subject_parent + "' ORDER BY id_content ASC LIMIT '" + number_slot + "',1";
            var sqlQuery = "SELECT subject_child_name FROM contents WHERE time_shipment > NOW() AND user_id=" + userID + " AND subject_parent_name='" + subjectParentName + "' ORDER BY id_content ASC LIMIT " + numberSlot + ",1";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return (string)reader["subject_child_name"]; 
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
    public string GetServerDateTime()//Получаем серверное время
    {
        DateTime serverDateTime;
        string serverDateTimeTemp;        
        Debug.Log("GetServerDateTime");
        Debug.Log(Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
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
    public int GetTimeBuilding(string subjectName) //Получаем время сборки предмета
    {
        int buildingTime;
        Debug.Log("GetTimeBuilding");
        Debug.Log(Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
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

    static string GetSummDateTimeAndSeconds(string time, int second) //Прибавляем дате определенное количество секунд
    {
        var convertA = DateTime.Parse(time);//Конвертируем строку в дату
        return convertA.AddSeconds(second).ToString("yyyy-MM-dd HH:mm:ss"); 
    }
    void CheckConnections()
    {   //Проверяем соединение с БД
        //Доработать входные данные 
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
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
    //Количество занятых слотов(shipment)
    public int GetCountOfOccupiedShipmentSlotsByParentName(string subjectParentName, int userID)
    {   //Проверяем соединение с БД
        //Доработать входные данные 
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();

            string sql = "SELECT COUNT(*) FROM contents WHERE time_shipment<NOW() AND user_id='" + userID + "' AND subject_parent_name = '" + subjectParentName + "' ORDER BY id_content";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                int r = Convert.ToInt32(result);
                Debug.Log("Number of countries in the world database is: " + r);
                return r;
            }

        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return -1;
        }

        conn.Close();
        Debug.Log("Done.");
        return -2;     
    }
    public int GetCountOfOccupiedLoadingSlotsByParentName(string subjectParentName, int userID)
    {   //Проверяем соединение с БД
        //Доработать входные данные 
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();

            string sql = "SELECT COUNT(*) FROM contents WHERE time_shipment>NOW() AND user_id='" + userID + "' AND subject_parent_name = '" + subjectParentName + "' ORDER BY id_content";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                int r = Convert.ToInt32(result);
                Debug.Log("Number of countries in the world database is: " + r);
                return r;
            }

        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return -1;
        }

        conn.Close();
        Debug.Log("Done.");
        return -2;
    }
    public void AddContents(string subjectParentName, string subjectChildName, int userId) //Метод только добавляет в БД полученные значения
    {
        string timeLoading = GetServerDateTime();//Дата загрузки равна текущему времени сервера
        string timeShipment = GetSummDateTimeAndSeconds(timeLoading, GetTimeBuilding(subjectChildName));//Время отгрузки равно текущему времени сервера плюс время изготовления объекта
        int outputQuantity = Data.GetComponent<OutputQuantity>().GetOutputQuantityBySubjectName(subjectChildName);//Количество на выходе равно, значению из таблицы output_quantity

        //var timeShipmentTemp = DateTime.Parse(timeShipment);//Конвертируем строку в дату
        //timeShipmentTemp.AddSeconds(GetTimeBuilding(subjectChild));//Прибавляем конвертированной дате секунды производства равную времени производства объъекта
        //timeShipment = timeShipmentTemp.ToString("yyyy-MM-dd HH:mm:ss"); //Конвертируем дату во время определенного формата БД MySQL
        var SQLQuery = "INSERT contents (subject_parent_name, subject_child_name, time_loading, time_shipment, output_quantity, user_id) VALUES ('"+subjectParentName+ "','" + subjectChildName + "','" + timeLoading + "','" + timeShipment + "'," + outputQuantity + "," + userId + ")";
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
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
    public int GetShipmentID(string subjectParentName, int userID) //Получаем ID первого стоящего на выгрузку объекта
    {
        int contentID;
        Debug.Log("method GetShipmentID");
        Debug.Log(Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            //var SQLQuery = "SELECT output_quantity from output_quantity_subjects WHERE name_subject='" + subjectName + "' LIMIT 0,1 ";
            var SQLQuery = "SELECT id_content FROM contents WHERE time_shipment<NOW() AND user_id='" + userID + "' AND subject_parent_name = '" + subjectParentName + "' ORDER BY id_content ASC LIMIT 0,1";
            MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                contentID = (int)reader["id_content"];

                Debug.Log(contentID);
                return contentID;
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
    //static string GetShipment
    //Получаем готовый продукт,для каждого слота по номеру(нужно ли это для механики?)
    //Получаем первый готовый продукт в очереди
    //Освобождение слота отгрузки(В нем вызываем метод, увеличивающий количество выгруженного предмета на складе)
    //archive_contents

}
