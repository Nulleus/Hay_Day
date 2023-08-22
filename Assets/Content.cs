using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Proyecto26;
using UnityEditor;
using System.Linq;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;
using Sirenix.OdinInspector;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;
using System.IO;
using Mono.Data.Sqlite; // 1
using System.Data; // 1
using System.Globalization;
public class Content : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        var test1 = DateTime.Now;
        string test = GetSubjectChildInTheProcessOfAssembly("bakery", 0, test1);
        Debug.Log("Test="+test+";time="+test1);
        string test2 = GetSubjectChildInTheShipment("bakery", 0, test1);
        Debug.Log("Test2=" + test2 + ";time=" + test1);
        int test3 = GetCountOfOccupiedShipmentSlotsByParentName("bakery", test1);
        Debug.Log("Test3=" + test3 + ";time=" + test1);
        int test4 = GetCountOfOccupiedLoadingSlotsByParentName("bakery", test1);
        Debug.Log("Test4=" + test4 + ";time=" + test1);
        int test5 = GetCountAllSlotsBySubjectName("bakery");
        Debug.Log("Test5=" + test5);
        string test6 = QueryAddContents("bakery", "bread", test1, test1, 2);
        Debug.Log("Test6=" + test6);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //ѕолучаем продукт, наход€щийс€ в зоне отгрузки дл€ каждого слота по номеру
    //SELECT subject_child_name FROM contents WHERE time_shipment < NOW() AND user_id=11 AND subject_parent_name="bakery" ORDER BY id_content ASC LIMIT 1,1
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetSubjectChildInTheShipment(string subjectParentName, int numberSlot, DateTime dateTimeNow)
    {
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT subject_child_name FROM contents WHERE time_shipment < " + "'"+dateTimeNow+"'" + "AND subject_parent_name=" + "'" + subjectParentName+"'" + "ORDER BY id_content ASC LIMIT "+numberSlot+",1";
        string subjectChildInTheShipment;
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
                        subjectChildInTheShipment = reader.GetValue(0).ToString();
                        return subjectChildInTheShipment;
                    }

                }
            }
        }
        return "Error";
    }
    //ѕолучаем продукт, наход€щийс€ в производстве дл€ каждого слота по номеру, идентификатору пользовател€
    //SELECT subject_child_name FROM contents WHERE time_shipment > NOW() AND user_id=11 AND subject_parent_name="bakery" ORDER BY id_content ASC LIMIT 1,1
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetSubjectChildInTheProcessOfAssembly(string subjectParentName, int numberSlot, DateTime dateTimeNow)
    {
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT subject_child_name FROM contents WHERE time_shipment > " + "'" + dateTimeNow + "'" + "AND subject_parent_name=" + "'" + subjectParentName + "'" + "ORDER BY id_content ASC LIMIT " + numberSlot + ",1";
        string subjectChildInTheShipment;
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
                        subjectChildInTheShipment = reader.GetValue(0).ToString();
                        return subjectChildInTheShipment;
                    }

                }
            }
        }
        return "Error";
    }
    //ѕолучить количество готовых продуктово, наход€щиес€ в зоне отгрузки
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetCountOfOccupiedShipmentSlotsByParentName(string subjectParentName, DateTime dateTimeNow)
    {
        //"SELECT COUNT(*) FROM contents WHERE time_shipment<NOW() AND user_id='" + userID + "' AND subject_parent_name = '" + subjectParentName + "' ORDER BY id_content";
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT COUNT(*) FROM contents WHERE time_shipment < " + "'" + dateTimeNow + "'" + "AND subject_parent_name=" + "'" + subjectParentName + "'" + "ORDER BY id_content";
        int countOfOccupiedShipment;
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
                        countOfOccupiedShipment = Convert.ToInt32(reader.GetValue(0));
                        return countOfOccupiedShipment;
                    }
                }
            }
        }
        return 0;
    }
    //ѕолучаем количество зан€тых слотов(которые производ€т в данный момент) загрузки по имени родител€
    public int GetCountOfOccupiedLoadingSlotsByParentName(string subjectParentName, DateTime dateTimeNow)
    {
        //string sql = "SELECT COUNT(*) FROM contents WHERE time_shipment>NOW() AND user_id='" + userID + "' AND subject_parent_name = '" + subjectParentName + "' ORDER BY id_content";
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT COUNT(*) FROM contents WHERE time_shipment > " + "'" + dateTimeNow + "'" + "AND subject_parent_name=" + "'" + subjectParentName + "'" + "ORDER BY id_content";
        int countOfOccupiedLoading;
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
                        countOfOccupiedLoading = Convert.ToInt32(reader.GetValue(0));
                        return countOfOccupiedLoading;
                    }
                }
            }
        }
        return 0;
    }
    //ѕолучаем количество предметов наход€щихс€ в таблице, по имени объекта
    public int GetCountAllSlotsBySubjectName(string subjectChildName)
    {
        //string sql = ""SELECT COUNT(*)FROM " . $this->table_name . "WHERE user_id =? AND subject_child_name =?ORDER BY id_content"; 
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT COUNT(*) FROM contents WHERE subject_parent_name=" + "'" + subjectChildName + "'" + "ORDER BY id_content";
        int countAllSlots;
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
                        countAllSlots = Convert.ToInt32(reader.GetValue(0));
                        return countAllSlots;
                    }
                }
            }
        }
        return 0;
    }
    //ѕодготовка запроса
    public string QueryAddContents(string subjectParentName, string subjectChildName, DateTime timeLoading, DateTime timeShipment, int outputQuantity)
    {
        // SQLQuery = "INSERT INTO contents (subject_parent_name, subject_child_name, time_loading, time_shipment, output_quantity, user_id) VALUES ('"+subjectParentName+ "','" + subjectChildName + "','" + timeLoading + "','" + timeShipment + "'," + outputQuantity + "," + userId + ")";;
        string query = "INSERT INTO contents (subject_parent_name, subject_child_name, time_loading, time_shipment, output_quantity) VALUES("+"'"+subjectParentName+"','"+subjectChildName+"','"+timeLoading+"','" + timeShipment + "'," +outputQuantity+")"; 
        //var_dump($query);
        return query;
    }
}
