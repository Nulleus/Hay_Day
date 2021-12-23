using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

public class OutputQuantity : MonoBehaviour
{
    public GameObject Data;
    private void Start()
    {

    }
    public int GetOutputQuantityBySubjectName(string subjectName) //ѕолучаем количество продукта на выходе.
    {
        Debug.Log("method GetCount");
        Debug.Log("connectionString: " + Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var SQLQuery = "SELECT count FROM output_quantity WHERE subject_name='" + subjectName + "' LIMIT 0,1 ";
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
