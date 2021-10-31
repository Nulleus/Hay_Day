using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

public class Connections : MonoBehaviour
{
    public string Server;
    public string DataBase;
    public string UserName;
    public string UserPassword;
    public string Port;
    public string ConnectionString;
    
    public static string BuildingConnectionString(string server, string dataBase, string userName, string userPassword, string port)
    {
        string connectionString =
            "Server=" + server + ";" +
            "DataBase=" + dataBase + ";" +
            "USER=" + userName + ";" +
            "PASSWORD=" + userPassword + ";" +
            "Port=" + port + ";"
        ;
        return connectionString;
    }

    void CheckConnections()
    {

        //Доработать входные данные 
        //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
        MySqlConnection conn = new MySqlConnection(ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();

            string sql = "SELECT COUNT(*) FROM users";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                int r = Convert.ToInt32(result);
                Debug.Log("Number of countries in the world database is: " + r);
            }

        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }

        conn.Close();
        Debug.Log("Done.");
    }
    // Start is called before the first frame update
    void Start()
    {
        ConnectionString = BuildingConnectionString(Server, DataBase, UserName, UserPassword, Port);//Должна запуститься первой
        //BuildingConnectionString();//Сборка строки подключения 
        CheckConnections();//Провека подключения, таблицы, данных 
    }
    void Awake()
    {
        ConnectionString = BuildingConnectionString(Server, DataBase, UserName, UserPassword, Port);//Должна запуститься первой

    }

    // Update is called once per frame

}
