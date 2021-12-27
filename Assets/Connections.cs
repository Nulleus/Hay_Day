using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Threading;

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
    //Проверка подключения к базе данных
    void CheckConnections()
    {
        new Thread(() =>
        {
         // Start the Thread
                    //Доработать входные данные 
                    //string connStr = "server=localhost;user=root;database=world;port=3306;password=******";
        MySqlConnection conn = new MySqlConnection(ConnectionString);
            try
            {
                Debug.Log("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'rabeev2_hayday';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int countTable =  Convert.ToInt32(result);
                    Debug.Log("Количество таблиц: " + countTable);
                }

            }
            catch (Exception ex)
            {
                Debug.Log(ex.ToString());
                Debug.Log("Подключиться к базе данных не удалось");
            }

            conn.Close();
            Debug.Log("Done.");
        }).Start();

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
        CheckConnections();//Провека подключения, таблицы, данных 
    }

    // Update is called once per frame

}
