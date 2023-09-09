using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Proyecto26;
using UnityEditor;
using System.Linq;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;
using Sirenix.OdinInspector;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;
using System.IO;
using Mono.Data.Sqlite; // 1
using System.Data; // 1
using System.Globalization;

public class ExperienceLevel : MonoBehaviour
{
    [Serializable]
    public class ResponseExperienceLevel
    {
        public string message;
        public int numberLevel;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTExperienceLevel
    {
        //POST данные отправляемые серверу
        public string jwt;
        public string methodName;
        public int experiencePoints;


        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }

    public GameObject Data;
    //Получение номера уровня по очкам опыта пользователя
    public int GetLevelByExperiencePoints(int experiencePoints, string locationDataProcessing)
    {
        if (locationDataProcessing == "Local")
        {
            // $query = "SELECT level_number FROM " . $this->table_name . "WHERE experience_points >=  ? "; 
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
            string sqlExpression = "SELECT level_number FROM experience_level WHERE experience_points >= "+experiencePoints;
            int countOfOccupiedShipment;
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
                            countOfOccupiedShipment = Convert.ToInt32(reader.GetValue(0));
                            return countOfOccupiedShipment;
                        }
                    }
                }
            }
            return -1;
        }
        if (locationDataProcessing == "Server")
        {
            Debug.Log("method GetLevelByExperiencePoints");
            RestClient.Post<ResponseExperienceLevel>("http://45.84.226.98//api/user_execute_methods.php", new POSTExperienceLevel
            {
                jwt = Data.GetComponent<User>().JWTToken,
                methodName = "getLevelByExperiencePoints",
                experiencePoints = experiencePoints

            }).Then(response => {
                //EditorUtility.DisplayDialog("message: ", response.message, "Ok");
                //EditorUtility.DisplayDialog("numberLevel: ", response.numberLevel.ToString(), "Ok");
                Debug.Log("NumberLevel=" + response.numberLevel);
                return response.numberLevel;

            });
            return -1;
        }
        return -1;
    }

    private void OnEnable()
    {
        
    }
}
