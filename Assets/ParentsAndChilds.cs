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

// ласс нужен дл€ производственных зданий, чтобы показывать что они производ€т
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


    
    public class Root
    {
        public string subject_child_name { get; set; }
    }


    public GameObject Data;
    //[SerializeField]
    [ShowInInspector]
    public List<Root> Childs;
    //public Dictionary<>
    public int CountSubjectsParent;
    public string SubjectParentName;
    [SerializeField]
    //public string SubjectChildName;


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

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            List<Root> products = JsonConvert.DeserializeObject<List<Root>>(uwr.downloadHandler.text);
            Debug.Log(products.Count);

            Root p1 = products[0];

            Debug.Log(p1.subject_child_name);
        }
    }
    IEnumerator postRequest(string url, string json)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            var b = new ResponseGetSubjectChildName();
            b = JsonUtility.FromJson<ResponseGetSubjectChildName>(uwr.downloadHandler.text);
            //Childs = b;
        }
    }

    private void OnEnable()
    {
        //var a = new POSTGetSubjectChildName();
        //a.jwt = Data.GetComponent<Users>().GetJWTToken();
        //a.methodName = "GetSubjectChildName";
        //a.subjectParentName = "field";
        //a.number = 2;
        var a = new POSTGetSubjectChildName();
        a.jwt = Data.GetComponent<Users>().GetJWTToken();
        a.methodName = "GetSubjectChildAllName";
        a.subjectParentName = "field";
        //postRequestSubjectChildAllName



        StartCoroutine(postRequestSubjectChildAllName("http://farmpass.beget.tech/api/parent_and_child_execute_methods.php",a.ToString()));
        //GetCountSubjectsParent("bakery");
        //GetSubjectParentName("wheat");
        //GetSubjectChildName("field",0);
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
    //ѕолучаем им€ родител€ по ребенку
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
    //ѕолучаем им€ ребенка по имени родител€
    public void GetSubjectChildName(string subjectParentName, int number)
    {
        RestClient.Post<ResponseGetSubjectChildName>("http://farmpass.beget.tech/api/parent_and_child_execute_methods.php", new POSTGetSubjectChildName
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetSubjectChildName",
            subjectParentName = subjectParentName,
            number = number

        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("subjectChildName: ", response.subjectChildName, "Ok");
            //SubjectChildName = response.subjectChildName;
        });
    }
}
