using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;

public class Ingredients : MonoBehaviour
{
    //Dictionary<string, int> Ingredient;
    //Скрипт загружает данные об составе(ингредиентах) в объекты "Ingredient"

    private void Start()
    {
        //Ingredient.Add("empty", 1);
    }

    public static Dictionary<string,int> GetCompositions (string SubjectName)
    {
        Dictionary<string, int>  Compositions = new Dictionary<string, int>();
        Debug.Log("GetCompositions");
        Debug.Log(Connections.ConnectionString);
        gameObject.GetComponent<Connections>().B
        MySqlConnection conn = new MySqlConnection(Connections.ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            //var SQLQuery = "SELECT subject_child FROM contents WHERE time_shipment > NOW() AND user_id='" + user_id + "' AND subject_parent='" + subject_parent + "' ORDER BY id_content ASC LIMIT '" + number_slot + "',1";
            var SQLQuery = "SELECT subject_child FROM contents WHERE time_shipment > NOW() AND user_id=" + user_id + " AND subject_parent='" + subject_parent + "' ORDER BY id_content ASC LIMIT " + number_slot + ",1";
            MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                return (string)reader["subject_child"];
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
            return "Error";
        }
        conn.Close();
        Debug.Log("Done.");
        return Compositions;
    }
}
