using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using Proyecto26;
using UnityEditor;
using Sirenix.OdinInspector;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

//Класс нужен для производственных зданий, чтобы показывать что они производят
public class ParentsAndChilds : MonoBehaviour
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
    public void GetSubjectChildNameByNumber(string subjectParentName, int number)
    {
        string basePath = "http://farmpass.beget.tech/api/parent_and_child_execute_methods.php";
        RequestHelper currentRequest;
        currentRequest = new RequestHelper
        {
            Uri = basePath,
            Body = new POSTGetSubjectChildNameByNumber
            {
                jwt = Data.GetComponent<Users>().GetJWTToken(),
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
        })
        .Catch(err => this.LogMessage("Error", err.Message));
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
    //Номер слота по которому будет вестись поиск в БД
    public int number;

    private void Start()
    {

    }

    private void OnEnable()
    {
        GetSubjectChildNameByNumber(SubjectParentName, number);
    }

}
