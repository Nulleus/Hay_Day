using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Threading;
using UnityEditor;
using Models;
using Proyecto26;
using UnityEngine.Networking;

public class User : MonoBehaviour
{
    //������������ ������
    [Serializable]
    public class POSTLogin
    {
        public string login;
        public string password;
        public string message;
        public string jwt;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    //������������ ������
    [Serializable]
    public class POSTUser
    {
        //POST ������ ������������ �������
        public string jwt;
        public string methodName;
        public int experience_points;


        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    //������ ������� �������� � �����
    public class ResponseInfo
    {
        public string login;
        public string password;
        public string message;
        public string jwt;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    //������ ������� �������� � �����
    public class ResponseUserInfoExperiencePoints
    {
        //public string jwt;
        public string message;
        public int experience_points;


        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    //������ ������� �������� � �����
    public class UserInfoName
    {
        //public string jwt;
        public string message;
        public string farm_name;
        public string nickname;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    public GameObject Data;
    //����� � ������� ������������ ����� �����������
    public string JWTToken;
    public string Login;
    public string Password;
    public string Nickname;
    public string FarmName;
    // Start is called before the first frame update

    //���������� ����� � ������, �������� jwt �����
    public void PostLogin()
    {

        RestClient.Post<ResponseInfo>("http://farmpass.beget.tech/api/login.php", new POSTLogin
        {
            login = Login,
            password = Password
        }).Then(response => {
            //EditorUtility.DisplayDialog("Message: ", response.message, "Ok");
            JWTToken = response.jwt;
            //EditorUtility.DisplayDialog("JWT: ", response.jwt, "Ok");


        });
    }
    //�������� ���������� ����� � ������������
    public int GetUserInfoAPIExperiencePoints()
    {
        Debug.Log("GetInfoUserAPIExperiencePoints()");
        RestClient.Post<ResponseUserInfoExperiencePoints>("http://farmpass.beget.tech/api/user_execute_methods.php", new POSTUser
        {
            jwt = JWTToken,
            methodName = "getExperiencePoints"

        }).Then(response => {
            //EditorUtility.DisplayDialog("Message: ", response.message, "Ok");
            //EditorUtility.DisplayDialog("ExperiencePoints: ", response.experience_points.ToString(), "Ok");
            return response.experience_points;

        });
        return 0;
    }

    public void OnEnable()
    {
        //������������
        //PostLogin();
        //GetUserInfoAPIExperiencePoints();
        Data.GetComponent<ExperienceLevel>().GetLevelByExperiencePoints(125,"Server");
    }
    //��������� ������ ������������, ��������, ����� ���������� ����������� �����
    public string GetJWTToken()
    {
        return JWTToken;
    }
    public void Start()
    {


    }
    //��������� ������ ������ �� ����� ������������
    public int GetExperienceLevelUser()
    {
        //�������� ���������� ����� � ������������
        int experiencePointsUser = GetUserInfoAPIExperiencePoints();
        //��������� ���������� ����� � �������
        return Data.GetComponent<ExperienceLevel>().GetLevelByExperiencePoints(experiencePointsUser, "Server");
    }
}
