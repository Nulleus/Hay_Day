using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite; // 1
using System;
using Sirenix.OdinInspector;

public class ExperiencePoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetExperiencePoints(string subjectName, string actionName, string locationDataProcessing)
    {
        if (locationDataProcessing == "Local")
        {
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
            string sqlExpression = "SELECT experience_points FROM experience_points WHERE subject_name = '"+subjectName+"' AND action = '"+actionName+"'";
            Debug.Log(sqlExpression);
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
                            return Convert.ToInt32(reader.GetValue(0));
                        }
                    }
                }
            }
            return 0;
        }
        return 0;
    }
}
