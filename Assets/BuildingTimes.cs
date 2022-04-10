using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Proyecto26;
using UnityEditor;

public class BuildingTimes : MonoBehaviour
{
    public GameObject Data;
    public string test;
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
    public int GetTimeBuilding(string subjectName)
    {
        //Debug.Log("GetTimeBuilding");
        RestClient.Post<ResponseGetTimeBuilding>("http://farmpass.beget.tech/api/building_time_execute_methods.php", new POSTGetTimeBuilding
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetTimeBuilding",
            subjectName = subjectName

        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("buildingTimeSeconds: ", response.buildingTimeSeconds.ToString(), "Ok");
            return response.buildingTimeSeconds;
        });
        
        return 0;
    }
    //Для тестов
    private void OnEnable()
    {
        //GetTimeBuilding("wheat");
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
