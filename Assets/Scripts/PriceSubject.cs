using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Proyecto26;
using UnityEditor;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;
using Sirenix.OdinInspector;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Mono.Data.Sqlite; // 1
using System.Data; // 1

public class PriceSubject : MonoBehaviour
{
    public GameObject Data;
    private void Start()
    {
    }
    //Получаем стоимость предмета в указанной валюте
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetPrice(string subjectName, string currency)
    {
        int priceCoin;
        int priceDiamond;
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        if (currency == "coin")
		{
		    //echo "GetPrice currency=coin";
		    //debug
            Debug.Log("GetPrice currency=coin");

            string sqlQuery = "SELECT coins_for_one_round FROM price_subjects WHERE subject_name =" + "'" + subjectName + "'" + "LIMIT 0,1";
            Debug.Log("sqlQuery=" + sqlQuery);
            using (var connection = new SqliteConnection(dbUri))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlQuery, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            priceCoin = Convert.ToInt32(reader.GetValue(0));
                            return priceCoin;
                        }
                    }
                }
            }
        }
        //diamonds_for_one_ingredients
        if (currency == "diamond")
		{
            Debug.Log("GetPrice currency=diamond");

            string sqlQuery = "SELECT diamonds_for_one_ingredients FROM price_subjects WHERE subject_name =" + "'" + subjectName + "'" + " LIMIT 0,1";
            Debug.Log("sqlQuery=" + sqlQuery);
            using (var connection = new SqliteConnection(dbUri))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlQuery, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read())   // построчно считываем данные
                        {
                            priceDiamond = Convert.ToInt32(reader.GetValue(0));
                            return priceDiamond;
                        }
                    }
                }
            }
        }
        return 0;
    }
    //Получить общую стоимоить объектов по списку (предмет, количество)
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetAllCost(ref Dictionary<string,int> massive)
    {
     //Временная переменная
     int priceSubjectTemp = 0;
	 //Валюта
	 string currency = "diamond";
     //Общая стоимость
	 int allPriceSubjects = 0;
            foreach (var d in massive) {
            //Debug.Log("massive="+massive);
            //Узнаем стоимость объекта в указанной валюте
			priceSubjectTemp = GetPrice(d.Key, currency);
            Debug.Log("priceSubjectTemp="+priceSubjectTemp);
            //Прибавляем стоимость, так как этот цикл может состоять из нескольких предметов+умножить на количество необходимых ингредиентов
			allPriceSubjects = allPriceSubjects + (priceSubjectTemp * d.Value);
            Debug.Log("allPriceSubjects" + allPriceSubjects);
            }
            return allPriceSubjects;
    }
}
