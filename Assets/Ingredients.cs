using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

public class Ingredients : MonoBehaviour
{
    //Dictionary<string, int> Ingredient;
    //Скрипт загружает данные об составе(ингредиентах) в объекты "Ingredient"

    private void Start()
    {
        
    }

    

    public static Dictionary<string,int> GetCompositions (string SubjectName) //Получаем ингредиенты, необходимые для создания объекта
    {
        Dictionary<string, int>  Compositions = new Dictionary<string, int>();
        Debug.Log("GetCompositions");
        Debug.Log("connectionString: "+ Connections.ConnectionString);
        MySqlConnection conn = new MySqlConnection(Connections.ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            var sqlQuery = "SELECT ingredient_name, count_ingredients FROM ingredients WHERE subject_name=" + SubjectName + "";
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
