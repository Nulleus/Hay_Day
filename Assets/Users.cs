﻿using System.Collections;
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

public class Users : MonoBehaviour
{
    public class Info
    {
        public string email;
        public string password;
        public string message;
        public string jwt;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    public GameObject Data;
    //Токен с данными пользователя после авторизации
    public string JWTToken;
    //Уникальный идентификатор пользователя
    public int IDUser;

    public string Login;
    public string Pasword;
    public string Nickname;
    public string FarmName;
    public string SQLQuery;
    public int ExperiencePoints;
    public int LevelUserNumber;
    // Start is called before the first frame update
    //Получаем уровень пользователя
    public void PostLogin()
    {

        RestClient.Post<Info>("http://farmpass.beget.tech/api/login.php", new PostLogin
        {
            email = Login,
            password = Pasword
        }).Then(response => {
            EditorUtility.DisplayDialog("Message: ", response.message, "Ok");
            JWTToken = response.jwt;
            EditorUtility.DisplayDialog("JWT: ", response.jwt, "Ok");

        });
    }
    private void Start()
    {
        PostLogin();
    }
    public int GetLevelUserNumber()
    {
        return GetExperienceLevelByIDUser(ExperiencePoints);
    }
    public int GetIDUser()
    {
        return IDUser;
    }
    //Получаем ID пользователя по логину и паролю
    public void GetIDUserByLoginAndPassword()
    {
        new Thread(() =>
        {
            if ((Login == "")||(Pasword == ""))
        {
            Debug.Log("Логин и (или) пароль не введены");
            return;
        }
        Debug.Log("GetIDUser()");
        //Получение данных для подключения из единой точки входа
        var SQLQuery = "SELECT id_user from users WHERE login='" + Login + "' AND pasword='" + Pasword + "'";
        // Debug.Log(Data.GetComponent<Connections>().ConnectionString);
        Debug.Log(SQLQuery);
        // создаём объект для подключения к БД
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        // устанавливаем соединение с БД
        conn.Open();
        // объект для выполнения SQL-запроса
        MySqlCommand command = new MySqlCommand(SQLQuery, conn);
        // объект для чтения ответа сервера
        MySqlDataReader reader = command.ExecuteReader();
        // читаем результат
        //Debug.Log("reader:" + reader.Read());
        //if (reader.Read() == false)
        //{
        //gameObject.GetComponent<EnterAuthorization>().Authorization("failed");
        //Debug.Log("Authorization Failed");
        //}
        if (reader.HasRows == false)
        {           
            Debug.Log("Authorization Failed");
            return;
        }
        while (reader.Read())
        {           
            IDUser= (int)reader["id_user"];
            Debug.Log(IDUser+" id_user!!!!!!!!!!!!!!!");
        }        
        reader.Close(); // закрываем reader
        // закрываем соединение с БД
        conn.Close();
        }).Start(); // Start the Thread
    }
    //Получение номера уровня по очкам пользователя
    public int GetExperienceLevelByIDUser(int experiencePoints)
    {
        //Получаем количество очков у пользователя
        int idUser = GetIDUser();
        GetExperiencePointsByIDUser(idUser);
        //Переводим количество очков в уровень
        return LevelUserNumber = Data.GetComponent<ExperienceLevel>().GetLevelByExperiencePoints(ExperiencePoints);
    }
    //Получаем количество очков у пользователя
    public void GetExperiencePointsByIDUser(int id_user)
    {
        new Thread(() =>
        {
            Debug.Log("GetExperiencePointsByIDUser()");
            Debug.Log(Data.GetComponent<Connections>().ConnectionString);
            MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
            try
                {
                Debug.Log("Connecting to MySQL...");
                conn.Open();
                SQLQuery = "SELECT experience_points FROM users WHERE id_user='" + id_user + "'";
                MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Debug.Log("while (reader.Read())");
                    ExperiencePoints = (int)reader["experience_points"];
                    Debug.Log("experience_points="+ExperiencePoints);
                }
                reader.Close();
                }
                catch (Exception ex)
                {
                    Debug.Log(ex.ToString());
                }
                conn.Close();
                Debug.Log("Done.");
        }).Start(); // Start the Thread
}

    public void GetInfoUser()
    {

            Debug.Log("GetInfoUser()");
            //tring connStr = "server=localhost;user=root;database=world;port=3306;password=******";
            //ConnectionString = Data.GetComponent<Connections>().ConnectionString;
            Debug.Log(Data.GetComponent<Connections>().ConnectionString);
            MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
            try
                {
                    Debug.Log("Connecting to MySQL...");
                    conn.Open();
                    SQLQuery = "SELECT id_user, nickname, farm_name" +
                    " FROM users WHERE login='" + Login + "' AND pasword='" + Pasword + "'";
                    MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Debug.Log("while (reader.Read())");
                        IDUser = (int)reader["id_user"];
                        Nickname = (string)reader["nickname"];
                        FarmName = (string)reader["farm_name"];
                        //gameObject.GetComponent<EnterAuthorization>().Authorization("ok"); //Нужно тут?
                        Debug.Log("Authorization OK");
                        Debug.Log("id_user=" + IDUser);
                        Debug.Log("Login=" + Login);
                        Debug.Log("Pasword=" + Pasword);
                        Debug.Log("Nickname=" + Nickname);
                        Debug.Log("FarmName=" + FarmName);
                    }
                    reader.Close();
                 }
            catch (Exception ex)
                {
                    Debug.Log(ex.ToString());
                }

            conn.Close();
            Debug.Log("Done.");
    }

}
