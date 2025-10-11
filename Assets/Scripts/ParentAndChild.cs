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

//Класс нужен для производственных зданий, чтобы показывать что они производят
public class ParentAndChild : MonoBehaviour
{

    private void LogMessage(string title, string message)
    {
#if UNITY_EDITOR
        Debug.Log(title + message);
#else
		Debug.Log(message);
#endif
    }

    [Serializable]
    public class POSTGetCountSubjectsParent
    {
        public string jwt;
        public string methodName;
        public string subjectChildName;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseGetCountSubjectsParent
    {
        public string message;
        public int countSubjectsParent;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTGetSubjectParentName
    {
        public string jwt;
        public string methodName;
        public string subjectChildName;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseGetSubjectParentName
    {
        public string message;
        public string subjectParentName;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTGetSubjectChildName
    {
        public string jwt;
        public string methodName;
        public string subjectParentName;
        public int number;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTGetSubjectChildAllName
    {
        public string jwt;
        public string methodName;
        public string subjectParentName;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseGetSubjectChildName
    {
        public string message;
        public string subjectChildName;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTGetSubjectChildNameByNumber
    { 
        public string jwt;
        public string methodName;
        public string subjectParentName;
        public int number;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseGetSubjectChildNameByNumber
    {
        public string message;
        public string subjectChildName;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }



    public class Subject
    {
        public string subject_child_name { get; set; }
    }


    public GameObject Data;
    [ShowInInspector]
    //Дети
    public string[] Childs = new string[10];
    //Имя родителя
    public string SubjectParentName;
    //Номер слота по которому будет произведен поиск в БД
    public int number;
    //Должно расчитываться от уровня пользователя
    public int OpenSubjectChilds;

    private void Start()
    {

    }

    private void OnEnable()
    {
        //GetSubjectChildNameByNumber(SubjectParentName, number);
        for (int i = 0; i <= OpenSubjectChilds; i++)
        {
            Debug.Log(i);
            GetSubjectChildNameByNumber(SubjectParentName, i);
        }
    }
    //Получаем количество объектов, изготовливаемых родителем
    //SELECT COUNT(*) 
    public void GetSubjectChildNameByNumber(string subjectParentName, int number)
    {
        string basePath = "http://89.110.90.192/api/parent_and_child_execute_methods.php";
        RequestHelper currentRequest;
        currentRequest = new RequestHelper
        {
            Uri = basePath,
            Body = new POSTGetSubjectChildNameByNumber
            {
                jwt = Data.GetComponent<User>().GetJWTToken(),
                methodName = "GetSubjectChildNameByNumber",
                subjectParentName = subjectParentName,
                number = number
            },
            EnableDebug = true
        };
        RestClient.Post<ResponseGetSubjectChildNameByNumber>(currentRequest)
        .Then(res => {
                // later we can clear the default query string params for all requests
                RestClient.ClearDefaultParams();
            Childs[number] = res.subjectChildName;
            return Childs[number];
        })
        .Catch(err => this.LogMessage("Error", err.Message));
    }
    //Получаем количество объектов, изготовливаемых родителем
    //$query = "SELECT COUNT(*) FROM " . $this->table_name . " WHERE subject_parent_name =? ";
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetCountSubjectsParent(string subjectParentName, string locationDataProcessing)
    {
        if (locationDataProcessing == "Local")
        {
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
            //$query = "SELECT count FROM " . $this->table_name . " WHERE subject_name =? LIMIT 0,1"; 
            string sqlExpression = "SELECT COUNT(*) FROM parents_and_childs WHERE subject_parent_name ='" + subjectParentName + "'";
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
            Debug.Log("Метод не был написан");
            return 0;
        }
        return -1;
    }

    //$query = "SELECT subject_parent_name FROM  WHERE subject_child_name =? LIMIT 0,1"; 
    //Получаем Родителя объекта по имени ребенка
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetSubjectParentName(string subjectChildName, string locationDataProcessing)
    {
        if (locationDataProcessing == "Local")
        {
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4 
            string sqlExpression = "SELECT subject_parent_name FROM parents_and_childs WHERE subject_child_name ='" + subjectChildName + "' LIMIT 0,1";
            string subjectParentName;
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
                            subjectParentName = reader.GetValue(0).ToString();
                            return subjectParentName;
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
    //Получить имя ингредиента имени объекта и по номеру
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    //$query = "SELECT subject_child_name FROM " . $this->table_name . "WHERE subject_parent_name =? LIMIT ?,1"; 
    public string GetSubjectChildName(string subjectParentName, int number, string locationDataProcessing)
    {
        if (locationDataProcessing == "Local")
        {
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4 
            string sqlExpression = "SELECT subject_parent_name FROM parents_and_childs WHERE subject_child_name ='" + subjectParentName + "' LIMIT "+number+",1";
            using (var connection = new SqliteConnection(dbUri))
            {
                string subjectParentNameOut;
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            subjectParentNameOut = reader.GetValue(0).ToString();
                            return subjectParentNameOut;
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
    //Получить всех детей по имени родителя
    //$query = "SELECT subject_child_name FROM " . $this->table_name . " WHERE subject_parent_name =? "; 
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public List<string> GetSubjectChildAllName(string subjectParentName, string locationDataProcessing)
    {
        List<string> childAllName = new List<string>();
        if (locationDataProcessing == "Local")
        {
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4 
            string sqlExpression = "SELECT subject_parent_name FROM parents_and_childs WHERE subject_child_name ='" + subjectParentName+"'";
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
                            childAllName.Add(reader.GetValue(0).ToString());
                        }
                        return childAllName;
                    }
                }
                connection.Close();
            }
        }
        if (locationDataProcessing == "Server")
        {
            return childAllName;
        }
        return childAllName;
    }
}
