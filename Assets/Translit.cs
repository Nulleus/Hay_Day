using System.Collections;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;
using UnityEngine;
using System;

public class Translit : MonoBehaviour
{
    public GameObject Data;
    public string NameRUS;
    public string DescriptionRUS;
    private void Start()
    {
        NameRUS = GetNameRUSByNameObject("wheat");
        DescriptionRUS = GetDescriptionRUSByNameObject("wheat");
    }
    public string GetNameRUSByNameObject(string subjectName) 
    {
        Debug.Log("method GetNameRUSByNameObject");
        Debug.Log(Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var SQLQuery = "SELECT name_rus FROM translit WHERE subject_name='" + subjectName + "'";
            MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               string nameRUS = (string)reader["name_rus"];
                Debug.Log(nameRUS);
                return nameRUS;
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
        conn.Close();
        Debug.Log("Done.");
        return "0";
    }
    public string GetDescriptionRUSByNameObject(string subjectName) 
    {
        Debug.Log("method GetDescriptionRUSByNameObject");
        Debug.Log(Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var SQLQuery = "SELECT description_rus FROM translit WHERE subject_name='" + subjectName + "'";
            MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string descriptionRUS = (string)reader["description_rus"];
                Debug.Log(descriptionRUS);
                return descriptionRUS;
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
        conn.Close();
        Debug.Log("Done.");
        return "0";
    }
    public string GetTimeBuildingRUSByNameObject(string subjectName)
    {
        Debug.Log("method GetTimeBuildingRUSByNameObject");
        Debug.Log(Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var SQLQuery = "SELECT time_building_rus FROM translit WHERE subject_name='" + subjectName + "'";
            MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string descriptionRUS = (string)reader["time_building_rus"];
                Debug.Log(descriptionRUS);
                return descriptionRUS;
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
        conn.Close();
        Debug.Log("Done.");
        return "0";
    }
}
