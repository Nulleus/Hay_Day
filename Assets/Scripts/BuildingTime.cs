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

public class BuildingTime : MonoBehaviour
{
    public GameObject Data;
    [SerializeField]
    private int BuildingTimeSeconds;

    [Serializable]
    public class POSTGetTimeBuilding
    {
        public string jwt;
        public string methodName;
        public string subjectName;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseGetTimeBuilding
    {
        public string message;
        public int buildingTimeSeconds;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    //Получаем время сборки предмета
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetTimeBuilding(string subjectName, string locationDataProcessing)
    {
        if (locationDataProcessing == "Local")
        {
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
            string sqlExpression = "SELECT building_time_seconds FROM building_times WHERE subject_name =" + "'" + subjectName + "' LIMIT 0,1";
            int timeBuilding;
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
                            timeBuilding = Convert.ToInt32(reader.GetValue(0));
                            return timeBuilding;
                        }

                    }
                }
            }
            return -1;
        }
        if (locationDataProcessing == "Server")
        {
            RestClient.Post<ResponseGetTimeBuilding>("http://farmpass.beget.tech/api/building_time_execute_methods.php", new POSTGetTimeBuilding
            {
                jwt = Data.GetComponent<User>().GetJWTToken(),
                methodName = "GetTimeBuilding",
                subjectName = subjectName

            }).Then(response => {
                //EditorUtility.DisplayDialog("message: ", response.message, "Ok");
                //EditorUtility.DisplayDialog("buildingTimeSeconds: ", response.buildingTimeSeconds.ToString(), "Ok");
                Debug.Log(response.buildingTimeSeconds);
                BuildingTimeSeconds = response.buildingTimeSeconds;
                return BuildingTimeSeconds;
            });
            return BuildingTimeSeconds;
        }
        return -1;
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
