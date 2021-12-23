using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

public class SubjectsSum : MonoBehaviour
{
    public GameObject Data;
    //Скрипт работает с таблицей subjects_sum
    // Start is called before the first frame update
    private void Start()
    {

    }
    public int GetSubjectSumCountByName(string subjectName, int userID)
    {
        Debug.Log("GetSubjectSumCountbyName");
        Debug.Log("connectionString: " + Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var sqlQuery = "SELECT subject_sum_count FROM subjects_sum WHERE subject_name='"+subjectName+"' AND user_id='"+userID+"'";
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
