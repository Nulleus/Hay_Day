using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

//Класс нужен для производственных зданий, чтобы показывать что они производят
public class ParentsAndChilds : MonoBehaviour
{
    public GameObject Data;
    
    private void Start()
    {

    }
    public void GetCountSubjectsParent(string subjectParentName)
    {

    }
    //Получаем Родителя объекта по имени ребенка
    public string GetSubjectParentName(string subjectChildName)
    {
        Debug.Log("GetSubjectParentNameBySubjectChildName");
        Debug.Log("connectionString: " + Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var sqlQuery = "SELECT subject_parent_name FROM parents_and_childs WHERE subject_child_name= '" + subjectChildName + "'";
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
    //Получаем всех детей по родителю
    //Переделать метод, ключ должен быть уникален
    public List<string> GetAllSubjectChildName(string subjectParentName, int number)
    {
        List<string> subjectParentNameAndSubjectChildName = new List<string>();
        Debug.Log("GetAllSubjectChildNameBySubjectParentName");
        Debug.Log("connectionString: " + Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var sqlQuery = "SELECT subject_parent_name, subject_child_name FROM parents_and_childs WHERE subject_parent_name= '" + subjectParentName + "'";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                subjectParentNameAndSubjectChildName.Add((string)reader["subject_child_name"]);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return subjectParentNameAndSubjectChildName;
        }
        conn.Close();
        Debug.Log("Done.");
        return subjectParentNameAndSubjectChildName;
    }
}
