using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

public class Users : MonoBehaviour
{
    public int IdUser;
    public string Login;
    public string Pasword;
    public string Nickname;
    public string FarmName;
    public GameObject Data;

    // Start is called before the first frame update
    public void GettingInfoUser() //Получениие информации пользователя по логину и паролю
    {
        Debug.Log("GettingIDUser()");
        Data = GameObject.Find("Data");
        //Получение данных для подключения из единой точки входа
        string SQLQuery = "SELECT id_user, nickname, farm_name" +
            " from users WHERE login='" + Login + "' AND pasword='" + Pasword + "'";
        Debug.Log(Data.GetComponent<Connections>().ConnectionString);
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
            gameObject.GetComponent<EnterAuthorization>().Authorization("failed");
            Debug.Log("Authorization Failed");
        }
        while (reader.Read())
        {
            Debug.Log("while (reader.Read())");
            IdUser = (int)reader["id_user"];
            Login = (string)reader["login"];
            Nickname = (string)reader["nickname"];
            FarmName = (string)reader["farm_name"];
            gameObject.GetComponent<EnterAuthorization>().Authorization("ok");
            Debug.Log("Authorization OK");
            Debug.Log("id_user=" + IdUser);
            Debug.Log("Login=" + Login);
            Debug.Log("Pasword=" + Pasword);
            Debug.Log("Nickname=" + Nickname);
            Debug.Log("FarmName=" + FarmName);
        }
        
        reader.Close(); // закрываем reader
        // закрываем соединение с БД
        conn.Close();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
