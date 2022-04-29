using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using Proyecto26;
using UnityEditor;

//Класс нужен для производственных зданий, чтобы показывать что они производят
public class ParentsAndChilds : MonoBehaviour
{


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
    public GameObject Data;
    public int CountSubjectsParent;
    public string SubjectParentName;


    private void Start()
    {

    }
    private void OnEnable()
    {
        GetCountSubjectsParent("bakery");
    }
    public void GetCountSubjectsParent(string subjectChildName)
    {
        RestClient.Post<ResponseGetCountSubjectsParent>("http://farmpass.beget.tech/api/parent_and_child_execute_methods.php", new POSTGetCountSubjectsParent
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetCountSubjectsParent",
            subjectChildName = subjectChildName

        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("countSubjectsParent: ", response.countSubjectsParent.ToString(), "Ok");
            Debug.Log(response.countSubjectsParent);
            CountSubjectsParent = response.countSubjectsParent;
            Debug.Log("CountSubjectsParent=" + CountSubjectsParent);
        });
    }
    public void GetSubjectParentName(string subjectChildName)
    {
        RestClient.Post<ResponseGetSubjectParentName>("http://farmpass.beget.tech/api/parent_and_child_execute_methods.php", new POSTGetSubjectParentName
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetSubjectParentName",
            subjectChildName = subjectChildName

        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("subjectParentName: ", response.subjectParentName, "Ok");
            Debug.Log(response.subjectParentName);
            SubjectParentName = response.subjectParentName;
            Debug.Log("SubjectParentName=" + SubjectParentName);
        });
    }
    //Получаем Родителя объекта по имени ребенка
    /*
    public string GetSubjectParentName(string subjectChildName)
    {
        Debug.Log("GetSubjectParentNameBySubjectChildName");
        Debug.Log("connectionString: " + Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var sqlQuery = "SELECT subject_parent_name FROM parents_and_childs WHERE subject_child_name= '" + subjectChildName + "'";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return (string)reader["subject_parent_name"];
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return "Exception";
        }
        conn.Close();
        Debug.Log("Done.");
        return "Done";
    */
    //Получаем всех детей по родителю
    //Переделать метод, ключ должен быть уникален
    public List<string> GetAllSubjectChildName(string subjectParentName, int number)
    {
        List<string> subjectParentNameAndSubjectChildName = new List<string>();
        Debug.Log("GetAllSubjectChildNameBySubjectParentName");
        Debug.Log("connectionString: " + Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var sqlQuery = "SELECT subject_parent_name, subject_child_name FROM parents_and_childs WHERE subject_parent_name= '" + subjectParentName + "'";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                subjectParentNameAndSubjectChildName.Add((string)reader["subject_child_name"]);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return subjectParentNameAndSubjectChildName;
        }
        conn.Close();
        Debug.Log("Done.");
        return subjectParentNameAndSubjectChildName;
    }
}
