using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MySql.Data;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

public class SQLClient : MonoBehaviour
{
    public string SQLQuery;
    public string ConnectionString;
    public string[] QueryResult;

    public void Start()
    {
        ConnectionString = GameObject.Find("User").GetComponent<UserData>().ConnectionString;//Получение данных для подключения из единой точки входа
    }
    public void GettingIDUser() //Получениие уникального идентификатора пользователя
    {
        SQLQuery = "SELECT ID from Users WHERE LoginUser='" + globals.login_user + "' AND PASWORD='" + globals.password_user + "'";
        //SqlConnection connstr = new SqlConnection();
        IDbConnection dbcon;
        using (dbcon = new SqlConnection(ConnectionString))
        {
            dbcon.Open();//Открытие соединения с базой данных
            using (IDbCommand dbcmd = dbcon.CreateCommand()) 
            {
                //string sql = "select ID from TBL_USERS WHERE LOGIN='"+globals.login_users+"' AND PASWORD='"+globals.password_users+"'";
                dbcmd.CommandText = SQLQuery;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Ingredients ingredients
                        QueryResult[0] = ((int)reader["ID"]).ToString();
                        //string LastName = (string)reader["lname"];
                        //Debug.Log("ID: " + globals.id_user);
                    }
                }
            }
        }
    }
    public void SQL_Data_ID(string connectionString, string sql)
    {
        //Connection string
        SqlConnection connstr = new SqlConnection();
        //connectionString = "Server = 127.0.0.1; Database = Farm_DB; User ID = farm_test; Password = z173500SS";
        IDbConnection dbcon;
        using (dbcon = new SqlConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                //string sql = "select ID from TBL_USERS WHERE LOGIN='"+globals.login_users+"' AND PASWORD='"+globals.password_users+"'";
                dbcmd.CommandText = sql;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Ingredients ingredients
                        //globals.id_user = (int)reader["ID"];
                        //string LastName = (string)reader["lname"];
                        //Debug.Log("ID: " + globals.id_user);
                    }
                }
            }
        }
    }
}
