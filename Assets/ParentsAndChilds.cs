using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;


public class ParentsAndChilds : MonoBehaviour
{
    public GameObject Data;
    //Получаем Родителя объекта по имени ребенка
    public string GetSubjectParentNameBySubjectChildName(string subjectName)
    {
        Debug.Log("GetSubjectParentNameBySubjectChildName");
        Debug.Log("connectionString: " + Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var sqlQuery = "SELECT subject_parent_name FROM parents_and_childs WHERE subject_child_name= '" + subjectName + "'";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return (string)reader["subject_parent_name"];
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return "Exception";
        }
        conn.Close();
        Debug.Log("Done.");
        return "Done";
    }
}
