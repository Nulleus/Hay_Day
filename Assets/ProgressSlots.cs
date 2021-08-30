using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

public class ProgressSlots : MonoBehaviour
{
    public GameObject Data;
    private void Start()
    {
        
    }
    public int GetOpenSlotsCount(string subjectName, int userID) //Получаем количество открытых слотов у пользователя.
    {
        
        //GameObject.Find("Data")
        //int idUser = Data.GetComponent<Users>().IDUser;
        Debug.Log("GetOpenSlotsCount");
        
        Debug.Log("connectionString: " + Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var SQLQuery = "SELECT open_slots FROM progress_slots WHERE  subject_name='" + subjectName + "' AND user_id='" + userID + "'";
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
