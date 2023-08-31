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
//System.Text.Json.Serialization.JsonConverter;
public class OpenSlotsDefault : MonoBehaviour
{
    //Получить количество открытых слотов у объекта
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetOpenSlotsLoadingCount(string subjectName)
    {
        //$query = "SELECT open_slots_loading_count FROM " . $this->table_name . "WHERE subject_name =? LIMIT 0,1"; 
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT open_slots_loading_count FROM open_level WHERE subject_name ='" + subjectName + "' LIMIT 0,1";
        int openSlotsLoadingCount;
        using (var connection = new SqliteConnection(dbUri))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read())   // построчно считываем данные
                    {
                        openSlotsLoadingCount = Convert.ToInt32(reader.GetValue(0));
                        return openSlotsLoadingCount;
                    }
                }
            }
        }
        return -1;
    }
    //Получить количество открытых слотов выгрузки у объекта
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetOpenSlotsShipmentCount(string subjectName)
    {
        //$query = "SELECT open_slots_shipment_count FROM " . $this->table_name . " WHERE subject_name =? LIMIT 0,1"; 
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT open_slots_shipment_count FROM open_level WHERE subject_name ='" + subjectName + "' LIMIT 0,1";
        int openSlotsShipmentCount;
        using (var connection = new SqliteConnection(dbUri))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read())   // построчно считываем данные
                    {
                        openSlotsShipmentCount = Convert.ToInt32(reader.GetValue(0));
                        return openSlotsShipmentCount;
                    }
                }
            }
        }
        return -1;
    }
    private void Start()
    {

    }
    private void OnEnable()
    {
        
    }
}
