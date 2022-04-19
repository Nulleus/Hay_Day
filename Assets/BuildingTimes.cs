using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Proyecto26;
using UnityEditor;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;

public class BuildingTimes : MonoBehaviour
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
    /*
    static async Task<int> GetTimeBuilding(GameObject data)
    {
        RestClient.Post<ResponseGetTimeBuilding>("http://farmpass.beget.tech/api/building_time_execute_methods.php", new POSTGetTimeBuilding
        {
            jwt = data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetTimeBuilding",
            subjectName = "wheat"

        }).Then(response => {
            EditorUtility.DisplayDialog("buildingTimeSeconds: ", response.buildingTimeSeconds.ToString(), "Ok");
            return response.buildingTimeSeconds;
        });
        return 99;
    }
    */
    //Получаем время сборки предмета
    /*
    public int GetTimeBuilding(string subjectName)
    {       
            RestClient.Post<ResponseGetTimeBuilding>("http://farmpass.beget.tech/api/building_time_execute_methods.php", new POSTGetTimeBuilding
            {
                jwt = Data.GetComponent<Users>().GetJWTToken(),
                methodName = "GetTimeBuilding",
                subjectName = subjectName

            }).Then(response => {
                EditorUtility.DisplayDialog("message: ", response.message, "Ok");
                EditorUtility.DisplayDialog("buildingTimeSeconds: ", response.buildingTimeSeconds.ToString(), "Ok");
                BuildingTimeSeconds = response.buildingTimeSeconds;
            });
        return BuildingTimeSeconds;

    }
    */
    static async Task<int> GetTimeBuilding(string subjectName, string jwt)
    {
        
        RestClient.Post<ResponseGetTimeBuilding>("http://farmpass.beget.tech/api/building_time_execute_methods.php", new POSTGetTimeBuilding
        {
            //jwt = Data.GetComponent<Users>().GetJWTToken(),
            jwt = jwt,
            methodName = "GetTimeBuilding",
            subjectName = subjectName

        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("buildingTimeSeconds: ", response.buildingTimeSeconds.ToString(), "Ok");
            Debug.Log(response.buildingTimeSeconds);
            return response.buildingTimeSeconds;
            //BuildingTimeSeconds = response.buildingTimeSeconds;
        });
        return 99;
    }
    //Для тестов
    public async Task<int> Test()
    {
        var responce = GetTimeBuilding("wheat", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwOi8vZXhhbXBsZS5vcmciLCJhdWQiOiJodHRwOi8vZXhhbXBsZS5vcmciLCJpYXQiOjEzNTY5OTk1MjQsIm5iZiI6MTM1NzAwMDAwMCwiZGF0YSI6eyJpZF91c2VyIjoxMiwibG9naW4iOiJBZG1pbkZhcm0iLCJuaWNrbmFtZSI6IlN0b3JtIiwiZmFybV9uYW1lIjoiR3JlZW4ifX0.WexHlXBl4CgHHM2V5VY2CaaJPpn-VVR0SQJYVIMMHtU");
        Debug.Log(responce);
        return await responce;
    }
    private void OnEnable()
    {
        int a = Test();
        //var a = Test();
        Debug.Log(a.ToString());
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
