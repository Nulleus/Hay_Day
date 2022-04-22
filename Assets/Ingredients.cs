using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Proyecto26;
using UnityEditor;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;

public class Ingredients : MonoBehaviour
{
    [Serializable]
    public class POSTGetCountAllIngredients
    {
        public string jwt;
        public string methodName;
        public string subjectName;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseGetCountAllIngredients
    {
        public string message;
        public int count;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    private void Start()
    {

    }
    public GameObject Data;
    [SerializeField]
    private int Count;

    //Dictionary<string, int> Ingredient;
    //Имя ингредиента, количество ингредиента
    //Скрипт загружает данные об составе(ингредиентах) в объекты "Ingredient"
    public int GetCountAllIngredients(string subjectName)
    {
        RestClient.Post<ResponseGetCountAllIngredients>("http://farmpass.beget.tech/api/output_quantity_execute_methods.php", new POSTGetCountAllIngredients
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetCountAllIngredients",
            subjectName = subjectName

        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("count: ", response.count.ToString(), "Ok");
            Debug.Log(response.count);
            Count = response.count;
            Debug.Log("Count=" + Count);
            return Count;
        });
        return Count;
    }
    /*
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
    */
    private void OnEnable()
    {
        GetCountAllIngredients("cowFeed");
    }
}
