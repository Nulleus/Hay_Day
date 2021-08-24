using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

public class SubjectsSum : MonoBehaviour
{
    //Скрипт работает с таблицей subjects_sum
    // Start is called before the first frame update
    public static int GetSubjectSumCountByName(string SubjectName, int UserID)
    {
        Debug.Log("GetSubjectSumCountbyName");
        string connectionString = Connections.GetConnectionString();
        Debug.Log("connectionString: " + connectionString);
        MySqlConnection conn = new MySqlConnection(connectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var sqlQuery = "select subject_sum_count from subjects_sum WHERE subject_name="+SubjectName+" AND user_id="+UserID+"";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {                
                return (int)reader["subject_sum_count"];
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
