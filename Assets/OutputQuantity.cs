using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

public class OutputQuantity : MonoBehaviour
{
    public static int GetCount(string subjectName) //Получаем ID первого стоящего на выгрузку объекта
    {
        Debug.Log("method GetCount");
        string connectionString = Connections.GetConnectionString();
        Debug.Log("connectionString: " + connectionString);
        MySqlConnection conn = new MySqlConnection(connectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var SQLQuery = "SELECT count FROM output_quantity WHERE subject_name='" + subjectName + "'";
            MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return (int)reader["count"];
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return -1;
        }
        conn.Close();
        Debug.Log("Done.");
        return -2;
    }
}
