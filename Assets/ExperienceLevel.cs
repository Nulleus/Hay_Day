using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using Proyecto26;
using UnityEditor;

public class ExperienceLevel : MonoBehaviour
{
    
    public class ResponseExperienceLevel
    {
        public string message;
        public int numberLevel;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    public GameObject Data;
    // Start is called before the first frame update
    /*public void GetLevelByExperiencePoints()
    {
        Debug.Log("method GetLevelByExperiencePoints");
        RestClient.Post<ResponseExperienceLevel>("http://farmpass.beget.tech/api/user_execute_methods.php", new POSTExperienceLevel
        {
            jwt = Data.GetComponent<Users>().JWTToken,
            methodName = "getLevelByExperiencePoints",
            experiencePoints = 125

        }).Then(response => {
            EditorUtility.DisplayDialog("Message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("NumberLevel: ", response.numberLevel.ToString(), "Ok");

        });
    }*/
    public int GetLevelByExperiencePoints(int experiencePoints) //Номер уровня по очкам
    {
        Debug.Log("method GetLevelByExperiencePoints");
        RestClient.Post<ResponseExperienceLevel>("http://farmpass.beget.tech/api/user_execute_methods.php", new POSTExperienceLevel
        {
            jwt = Data.GetComponent<Users>().JWTToken,
            methodName = "getLevelByExperiencePoints",
            experiencePoints = experiencePoints

        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("numberLevel: ", response.numberLevel.ToString(), "Ok");
            Debug.Log("NumberLevel=" + response.numberLevel);
            return response.numberLevel;

        });
        return 0;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
