using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

public class OpenLevel : MonoBehaviour
{
    public GameObject Data;
    //Получаем все объекты, которые открываются с определенным уровням, на текущий уровеь и все предыдущие тоже <=
 /*   public List<string> GetAllSubjectNameByOpenLevel() 
    {
        //Получаем уровень пользователя
        int openLevel = Data.GetComponent<Users>().GetExperienceLevelUser();
        Debug.Log("openLevel=" + openLevel);
        List<string> allSubjectNameOpenLevel = new List<string>();
        Debug.Log("GetAllSubjectNameByOpenLevel");
        Debug.Log("connectionString: " + Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var sqlQuery = "SELECT subject_name, open_level_number FROM open_level WHERE open_level_number<= '" + openLevel + "'";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                allSubjectNameOpenLevel.Add((string)reader["subject_name"]);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return allSubjectNameOpenLevel;
        }
        conn.Close();
        Debug.Log("Done.");
        return allSubjectNameOpenLevel;
    }
 */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
