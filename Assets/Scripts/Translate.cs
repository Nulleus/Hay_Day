using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Proyecto26;
using UnityEditor;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;
using Sirenix.OdinInspector;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Mono.Data.Sqlite; // 1
using System.Data; // 1
public class Translate : MonoBehaviour
{
    //Получить имя объекта на русском языке
    //$query = "SELECT display_name FROM " . $this->table_name . " WHERE subject_name =? AND system_language =? LIMIT 0,1"; 
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetDisplayName(string subjectName, string systemLanguage, string locationDataProcessing)
    {
        if (locationDataProcessing == "Local")
        {
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4 
            string sqlExpression = "SELECT display_name FROM translate WHERE subject_name ='" + subjectName + "' AND system_language='" + systemLanguage + "' LIMIT 0,1";
            string displayName;
            using (var connection = new SqliteConnection(dbUri))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            displayName= reader.GetValue(0).ToString();
                            return displayName;
                        }
                    }
                }
                connection.Close();
            }
        }
        if (locationDataProcessing == "Server")
        {
            return "Null";
        }
        return "Error";
    }

    //Получить описание объекта на русском языке
    //$query = "SELECT description FROM " . $this->table_name . " WHERE subject_name =? AND system_language =? LIMIT 0,1"; 
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetDescription(string subjectName, string systemLanguage, string locationDataProcessing)
    {
        if (locationDataProcessing == "Local")
        {
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4 
            string sqlExpression = "SELECT description FROM translate WHERE subject_name ='" + subjectName + "' AND system_language='" + systemLanguage + "' LIMIT 0,1";
            string description;
            using (var connection = new SqliteConnection(dbUri))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            description = reader.GetValue(0).ToString();
                            return description;
                        }
                    }
                }
                connection.Close();
            }

        }
        if (locationDataProcessing == "Server")
        {
            return "Null";
        }
        return "Error";
    }
    //Получить время производства объекта на русском языке
    //$query = "SELECT time_building_display FROM " . $this->table_name . " WHERE subject_name =? AND system_language =? LIMIT 0,1"; 
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetTimeBuildingDisplay(string subjectName, string systemLanguage, string locationDataProcessing)
    {
        if (locationDataProcessing == "Local")
        {
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4 
            string sqlExpression = "SELECT time_building_display FROM translate WHERE subject_name ='" + subjectName + "' AND system_language='" + systemLanguage + "' LIMIT 0,1";
            string description;
            using (var connection = new SqliteConnection(dbUri))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            description = reader.GetValue(0).ToString();
                            return description;
                        }
                    }
                }
                connection.Close();
            }
        }
        if (locationDataProcessing == "Server")
        {
            return "Null";
        }
        return "Error";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
