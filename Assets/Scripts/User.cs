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
    //Отправляемые данные
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
    //Отправляемые данные
    [Serializable]
    public class POSTUser
    {
        //POST данные отправляемые серверу
        public string jwt;
        public string methodName;
        public int experience_points;


        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    //Данные которые получаем в ответ
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
    //Данные которые получаем в ответ
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
    //Данные которые получаем в ответ
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
    //Токен с данными пользователя после авторизации
    public string JWTToken;
    public string Login;
    public string Password;
    public string Nickname;
    public string FarmName;
    // Start is called before the first frame update

    //Отправляем логин и пароль, получает jwt токен
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
    //Получаем количество очков у пользователя
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
        //Тестирование
        //PostLogin();
        //GetUserInfoAPIExperiencePoints();
        Data.GetComponent<ExperienceLevel>().GetLevelByExperiencePoints(125,"Server");
    }
    //Получение токена пользователя, временно, после необходимо запрашивать токен
    public string GetJWTToken()
    {
        return JWTToken;
    }
    public void Start()
    {


    }
    //Получение номера уровня по очкам пользователя
    public int GetExperienceLevelUser()
    {
        //Получаем количество очков у пользователя
        int experiencePointsUser = GetUserInfoAPIExperiencePoints();
        //Переводим количество очков в уровень
        return Data.GetComponent<ExperienceLevel>().GetLevelByExperiencePoints(experiencePointsUser, "Server");
    }
}
