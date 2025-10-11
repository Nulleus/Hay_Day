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
//System.Text.Json.Serialization.JsonConverter;

public class OutputQuantity : MonoBehaviour
{
    public GameObject Data;
    [SerializeField]
    private int Count;
    [Serializable]
    public class POSTGetOutputQuantityBySubjectName
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
    public class ResponseGetOutputQuantityBySubjectName
    {
        public string message;
        public int count;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    private void Start()
    {

    }
    //Получаем количество продукта на выходе.
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetOutputQuantityBySubjectName(string subjectName, string locationDataProcessing)
    {
        if (locationDataProcessing == "Local")
        {
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
            //$query = "SELECT count FROM " . $this->table_name . " WHERE subject_name =? LIMIT 0,1"; 
            string sqlExpression = "SELECT count FROM output_quantity WHERE subject_name ='" + subjectName + "' LIMIT 0,1";
            int count;
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
                            count = Convert.ToInt32(reader.GetValue(0));
                            return count;
                        }
                    }
                }
                connection.Close();
            }
        }
        if (locationDataProcessing == "Server")
        {
            RestClient.Post<ResponseGetOutputQuantityBySubjectName>("http://89.110.90.192/api/output_quantity_execute_methods.php", new POSTGetOutputQuantityBySubjectName
            {
                jwt = Data.GetComponent<User>().GetJWTToken(),
                methodName = "GetOutputQuantityBySubjectName",
                subjectName = subjectName

            }).Then(response => {
                //EditorUtility.DisplayDialog("message: ", response.message, "Ok");
                //EditorUtility.DisplayDialog("count: ", response.count.ToString(), "Ok");
                Debug.Log(response.count);
                Count = response.count;
                return Count;
            });
            return 0;
        }
        return -1;
    }
    private void OnEnable()
    {
        //GetOutputQuantityBySubjectName("wheat"); 
        int Test1 = GetOutputQuantityBySubjectName("wheat", "Local");
        Debug.Log(Test1);
        int Test2 = GetOutputQuantityBySubjectName("wheat", "Server");
        Debug.Log(Test2);
    }
}
