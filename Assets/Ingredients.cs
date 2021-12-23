using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

public class Ingredients : MonoBehaviour
{
    private void Start()
    {

    }
    public GameObject Data;
    //Dictionary<string, int> Ingredient;
    //Скрипт загружает данные об составе(ингредиентах) в объекты "Ingredient"
    public Dictionary<string,int> GetCompositions (string subjectName) //Получаем ингредиенты, необходимые для создания объекта
    {
        Dictionary<string, int>  Compositions = new Dictionary<string, int>();
        Debug.Log("GetCompositions");
        Debug.Log("connectionString: "+ Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var sqlQuery = "SELECT ingredient_name, count_ingredients FROM ingredients WHERE subject_name='" + subjectName + "'";
            MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Compositions.Add((string)reader["ingredient_name"], (int)reader["count_ingredients"]);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return Compositions;
        }
        conn.Close();
        Debug.Log("Done.");
        return Compositions;
    }


}
