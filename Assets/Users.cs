using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;

public class Users : MonoBehaviour
{
    public int ID;
    public string LoginUser;
    public string PasswordUser;
    public string NicknameUser;
    public string Farmname;


    // Start is called before the first frame update
    public void GettingInfoUser() //Получениие информации пользователя по логину и паролю
    {
        Debug.Log("GettingIDUser()");
        string ConnectionString = GameObject.Find("Users").GetComponent<UserData>().ConnectionString;//Получение данных для подключения из единой точки входа
        string SQLQuery = "SELECT ID, NicknameUser, FarmName" +
            " from Users WHERE LoginUser='" + globals.login_user + "' AND PasswordUser='" + globals.password_user + "'";
        Debug.Log(ConnectionString);
        Debug.Log(SQLQuery);
        // создаём объект для подключения к БД
        MySqlConnection conn = new MySqlConnection(ConnectionString);
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
            globals.id_user = (int)reader["ID"];
            //globals.login_user = (string)reader["LoginUser"];
            //globals.password_user = (string)reader["PasswordUser"];
            globals.nickname_user = (string)reader["NicknameUser"];
            globals.farm_name_user = (string)reader["FarmName"];

            gameObject.GetComponent<EnterAuthorization>().Authorization("ok");
            Debug.Log("Authorization OK");
            Debug.Log("ID=" + globals.id_user);
            Debug.Log("Login=" + globals.login_user);
            Debug.Log("Password=" + globals.password_user);
            Debug.Log("Nickname=" + globals.nickname_user);
            Debug.Log("FarmName=" + globals.farm_name_user);
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
