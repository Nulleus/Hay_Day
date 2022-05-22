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


    
    public class Subject
    {
        public string subject_child_name { get; set; }
    }


    public GameObject Data;
    [ShowInInspector]
    //Все дети
    public List<string> Childs;
    //Количество родителей у объекта
    public int CountSubjectsChilds;
    //Имя родителя
    public string SubjectParentName;

    private void Start()
    {

    }
    IEnumerator postRequestSubjectChildAllName(string url, string json)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isDone)
        {
            Childs.Clear();
            Debug.Log("Received: " + uwr.downloadHandler.text);
            List<Subject> products = JsonConvert.DeserializeObject<List<Subject>>(uwr.downloadHandler.text);
            Debug.Log(products.Count);
            CountSubjectsChilds = products.Count;
            for (int i = 0; i < products.Count; i++)
            {
                Subject p1 = products[i];
                Childs.Add(p1.subject_child_name);
            }
        }
        else
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
    }
    //Получаем имя родителя по имени ребенка
    IEnumerator postRequestSubjectParentName(string url, string json)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isDone)
        {
            Childs.Clear();
            Debug.Log("Received: " + uwr.downloadHandler.text);
            List<Subject> products = JsonConvert.DeserializeObject<List<Subject>>(uwr.downloadHandler.text);
            Debug.Log(products.Count);
            CountSubjectsChilds = products.Count;
            for (int i = 0; i < products.Count; i++)
            {
                Subject p1 = products[i];
                Childs.Add(p1.subject_child_name);
            }
        }
        else
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
    }

    private void OnEnable()
    {
        var postrequest = new POSTGetSubjectChildName();
        postrequest.jwt = Data.GetComponent<Users>().GetJWTToken();
        postrequest.methodName = "GetSubjectChildAllName";
        postrequest.subjectParentName = SubjectParentName;
        StartCoroutine(postRequestSubjectChildAllName("http://farmpass.beget.tech/api/parent_and_child_execute_methods.php", postrequest.ToString()));
    }

    //Получаем имя родителя по ребенку
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
}
