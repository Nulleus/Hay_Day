using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite; // 1
using System;
using Sirenix.OdinInspector;

public class Storage : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string GetStorageName(string subjectName, string locationDataProcessing)
    {
        if (locationDataProcessing == "Local")
        {
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
            string sqlExpression = "SELECT storage_name FROM storages WHERE subject_name = " + subjectName;

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
                            return (reader.GetValue(0).ToString());
                        }
                    }
                }
                connection.Close();
            }
            return "Not Found";
        }
        return "Null";
    }

}
