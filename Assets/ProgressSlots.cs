using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

public class ProgressSlots : MonoBehaviour
{
    public GameObject Data;
    public int ProgressSlotsCount; // оличество открытых слотов у пользовател€
    private void Start()
    {
        //Debug.Log("GetOpenSlotsCount" + GetOpenSlotsCount("bakery", 11));
    }
    public int GetOpenSlotsCount(string subjectName, int userID) //ѕолучаем количество открытых слотов у пользовател€.
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
                ProgressSlotsCount = (int)reader["open_slots"];
                return ProgressSlotsCount;
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
        return ProgressSlotsCount;
    }
}
