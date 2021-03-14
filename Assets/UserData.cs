using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System.Data;

public class UserData : MonoBehaviour
{
    public int IDUser;
    public string Server;
    public string DataBase;
    public string UserName;
    public string UserPassword;
    public string ConnectionString;

    public string SQLQuery;
    public string[] QueryResult;
    // Start is called before the first frame update
    void Start()
    {
        //Строка пдключения к БД
        ConnectionString = 
            "Server=" + Server + ";" + 
            "DataBase=" + DataBase + ";" + 
            "USER=" + UserName + ";" + 
            "PASSWORD=" + UserPassword + ";";
        GetIDUser();
    }

    // Update is called once per frame
    public void GetIDUser() //Получениие уникального идентификатора пользователя
    {
        SQLQuery = "SELECT id_user from users WHERE login='Admin' AND pasword='123'";
        IDbConnection dbcon;
        using (dbcon = new SqlConnection(ConnectionString))
        {
            dbcon.Open();//Открытие соединения с базой данных
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                dbcmd.CommandText = SQLQuery;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IDUser = ((int)reader["id_user"]);
                    }
                }
            }
        }
    }
}
