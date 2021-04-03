using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

public class Users : MonoBehaviour
{
    public int IDUser;
    public string Login;
    public string Pasword;
    public string Nickname;
    public string FarmName;
    public string SQLQuery;
    // Start is called before the first frame update
    public void GetIDUser(string login, string password)
    {
        if ((login == "")||(password == ""))
        {
            Debug.Log("Логин и (или) пароль не введены");
            
        }
        Debug.Log("GetIDUser()");
        //Получение данных для подключения из единой точки входа
        var SQLQuery = "SELECT id_user from users WHERE login='" + login + "' AND pasword='" + password + "'";
        // Debug.Log(Data.GetComponent<Connections>().ConnectionString);
        Debug.Log(SQLQuery);
        // создаём объект для подключения к БД
        MySqlConnection conn = new MySqlConnection(Connections.ConnectionString);
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
        }
        while (reader.Read())
        {
            
            IDUser= (int)reader["id_user"];
            Debug.Log(IDUser+" id_user!!!!!!!!!!!!!!!");
        }
        
        reader.Close(); // закрываем reader
        // закрываем соединение с БД
        conn.Close();
    }

    void Awake()
    {
        Debug.Log("Awake");
        Debug.Log(Login);
    }
    void Start()
    {
        //GetInfoUser();
        GetIDUser(Login, Pasword);
    }
    public void GetInfoUser()
    {
        Debug.Log("GetInfoUser()");
        //tring connStr = "server=localhost;user=root;database=world;port=3306;password=******";
        //ConnectionString = Data.GetComponent<Connections>().ConnectionString;
        Debug.Log(Connections.ConnectionString);
        MySqlConnection conn = new MySqlConnection(Connections.ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();

            SQLQuery = "SELECT id_user, nickname, farm_name" +
            " from users WHERE login='" + Login + "' AND pasword='" + Pasword + "'";
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
