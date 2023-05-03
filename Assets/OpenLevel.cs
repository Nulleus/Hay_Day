using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using Proyecto26;
using UnityEditor;
//System.Text.Json.Serialization.JsonConverter;

public class OpenLevel : MonoBehaviour
{
    public GameObject Data;
    public int OpenLevelNumber;
    //Отправляемые данные
    [Serializable]
    public class POSTOpenLevel
    {
        //POST данные отправляемые серверу
        public string jwt;
        public string methodName;
        public int openLevelNumber;


        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    //Отправляемые данные
    [Serializable]
    public class POSTAllSubjectNameByOpenLevelWhereNumber
    {
        //POST данные отправляемые серверу
        public string jwt;
        public string methodName;
        public int openLevelNumber;
        public int openLevelNumberLimit;


        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    //Данные которые получаем в ответ
    [Serializable]
    public class ResponseCountOpenLevel
    {
        public string message;
        public string countSubjectAll;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    public class ResponseAllSubjectNameByOpenLevelWhereNumber
    {
        public string message;
        public string subjectName;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseOpenLevelNumberWhereSubjectName
    {
        public string message;
        public int openLevelNumber;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }

    [Serializable]
    public class POSTOpenLevelNumberWhereSubjectName
    {
        public string jwt;
        public string methodName;
        public string subjectName;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    public int GetCountAllSubjectNameByOpenLevel(int openLevelNumber)
    {
        //Debug.Log("GetAllSubjectNameByOpenLevel");
        RestClient.Post<ResponseCountOpenLevel>("http://farmpass.beget.tech/api/open_level_execute_methods.php", new POSTOpenLevel
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetCountAllSubjectNameByOpenLevel",
            openLevelNumber = openLevelNumber

        }).Then(response => {
            //EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            //EditorUtility.DisplayDialog("countSubjectAll: ", response.countSubjectAll, "Ok");
            return response.countSubjectAll;
        });
        return 0;
    }

    public List<string> GetAllSubjectNameByOpenLevelWhereNumber(int openLevelNumber, int openLevelNumberLimit)
    {
        List<string> allSubjectNameOpenLevel = new List<string>();
        //Debug.Log("GetCountAllSubjectNameByOpenLevelWhereNumber");
        RestClient.Post<ResponseAllSubjectNameByOpenLevelWhereNumber>("http://farmpass.beget.tech/api/open_level_execute_methods.php", new POSTAllSubjectNameByOpenLevelWhereNumber
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetAllSubjectNameByOpenLevelWhereNumber",
            openLevelNumber = openLevelNumber,
            openLevelNumberLimit = openLevelNumberLimit

        }).Then(response => {
            //EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            //EditorUtility.DisplayDialog("subjectName: ", response.subjectName, "Ok");
            allSubjectNameOpenLevel.Add(response.subjectName);
            return allSubjectNameOpenLevel;
        });
        return allSubjectNameOpenLevel;
    }
    //Получаем уровень открытия объекта по его имени
    public int GetOpenLevelNumberWhereSubjectName(string subjectName)
    {
        //Debug.Log("GetOpenLevelNumberWhereSubjectName");
        RestClient.Post<ResponseOpenLevelNumberWhereSubjectName>("http://farmpass.beget.tech/api/open_level_execute_methods.php", new POSTOpenLevelNumberWhereSubjectName
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetOpenLevelNumberWhereSubjectName",
            subjectName = subjectName

        }).Then(response => {
            //EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            //EditorUtility.DisplayDialog("openLevelNumber: ", response.openLevelNumber.ToString(), "Ok");
            return response.openLevelNumber;
        });
        return 0;
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        //GetCountAllSubjectNameByOpenLevel(2);
        //GetAllSubjectNameByOpenLevelWhereNumber(2, 1);
        //GetOpenLevelNumberWhereSubjectName("wheat");
    }
}
