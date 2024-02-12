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
    public long GetDateTimeNow()
    {
        //var dateTimeNow = DateTime.Now.ToFileTime();
        var dateTimeNow = ((int) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
        Debug.Log("dateTimeNow:" + dateTimeNow);
        //string dateTimeNow = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        return dateTimeNow;
    }
    private void Test()
    {
        long dateTimeNow = GetDateTimeNow();
        string test = GetSubjectChildInTheProcessOfAssembly("bakery", 0, dateTimeNow);
        Debug.Log("Test=" + test + ";time=" + dateTimeNow);
        string test2 = GetSubjectChildInTheShipment("bakery", 0, dateTimeNow);
        Debug.Log("Test2=" + test2 + ";time=" + dateTimeNow);
        int test3 = GetCountOfOccupiedShipmentSlotsByParentName("bakery", dateTimeNow);
        Debug.Log("Test3=" + test3 + ";time=" + dateTimeNow);
        int test4 = GetCountOfOccupiedLoadingSlotsByParentName("bakery", dateTimeNow);
        Debug.Log("Test4=" + test4 + ";time=" + dateTimeNow);
        int test5 = GetCountAllSlotsBySubjectName("bakery");
        Debug.Log("Test5=" + test5);
        string test6 = QueryAddContents("bakery", "bread", dateTimeNow, dateTimeNow, 2);
        Debug.Log("Test6=" + test6);
        AddContents("bakery", "bread", dateTimeNow, dateTimeNow, 1);
        int test7 = GetShipmentID("bakery", dateTimeNow);
        Debug.Log("Test7=" + test7);
        int test8 = GetCountOutputQuantity(2);
        Debug.Log("Test8=" + test8);
        string test9 = GetSubjectName(2);
        Debug.Log("Test9=" + test9);
        string test10=QueryDeleteContent(2);
        Debug.Log("Test10=" + test10);
        string test11=GetDateShipment("bakery", 0, dateTimeNow);
        Debug.Log("Test11=" + test11);
        long test12=GetTimeShipmentDesc("bakery", dateTimeNow);
        Debug.Log("Test12=" + test12);
        long test13 = GetTimeShipmentFirst("bakery", dateTimeNow);
        Debug.Log("Test13=" + test13);
        int test14 = GetCountOfOccupiedBuildingSlots("bakery", dateTimeNow);
        Debug.Log("Test14=" + test14);
    }
    private void OnEnable()
    {
        //Test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Получаем продукт, находящийся в зоне отгрузки для каждого слота по номеру
    //SELECT subject_child_name FROM contents WHERE time_shipment < NOW() AND user_id=11 AND subject_parent_name="bakery" ORDER BY id_content ASC LIMIT 1,1
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetSubjectChildInTheShipment(string subjectParentName, int numberSlot, long dateTimeNow)
    {
        Debug.Log("GetSubjectChildInTheShipment=" + subjectParentName + ",dateTimeNow=" + dateTimeNow + "numberSlot=" + numberSlot + ")");
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        //string sqlExpression = "SELECT subject_child_name FROM contents WHERE time_shipment >=" + "'"+dateTimeNow+"'" + " AND subject_parent_name=" + "'" + subjectParentName+"'" + "ORDER BY id_content ASC LIMIT "+numberSlot+",1";
        string sqlExpression = "SELECT subject_child_name FROM contents WHERE time_shipment <="  + dateTimeNow  + " AND subject_parent_name=" + "'" + subjectParentName + "'" + " ORDER BY id_content ASC LIMIT " + numberSlot + ",1";
        using (var connection = new SqliteConnection(dbUri))
        {
            connection.Open();
            Debug.Log("connection.Open()");
            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // если есть данные
                {
                    string subjectChildInTheShipment;
                    while (reader.Read())   // построчно считываем данные
                    {
                        subjectChildInTheShipment = reader.GetValue(0).ToString();
                        Debug.Log(subjectChildInTheShipment);
                        return subjectChildInTheShipment;
                    }
                }
            }
            connection.Close();
        }
        return "Not Found";
    }
    //Получаем продукт, находящийся в производстве для каждого слота по номеру, идентификатору пользователя
    //SELECT subject_child_name FROM contents WHERE time_shipment > NOW() AND user_id=11 AND subject_parent_name="bakery" ORDER BY id_content ASC LIMIT 1,1
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetSubjectChildInTheProcessOfAssembly(string subjectParentName, int numberSlot, long dateTimeNow)
    {
        Debug.Log("GetSubjectChildInTheProcessOfAssembly(subjectParentName=" + subjectParentName + ",dateTimeNow=" + dateTimeNow + "numberSlot="+numberSlot+ ")");
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        //string sqlExpression = "SELECT subject_child_name FROM contents WHERE time_shipment <=" + "'" + dateTimeNow + "'" + " AND subject_parent_name=" + "'" + subjectParentName + "'" + "ORDER BY id_content ASC LIMIT " + numberSlot + ",1";
        string sqlExpression = "SELECT subject_child_name FROM contents WHERE time_shipment >=" + dateTimeNow + " AND subject_parent_name=" + "'" + subjectParentName + "'" + " ORDER BY id_content ASC LIMIT " + numberSlot + ",1";
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
            connection.Close();
        }
        return "Error";
    }
    //Получить количество готовых продуктово, находящиеся в зоне отгрузки
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetCountOfOccupiedShipmentSlotsByParentName(string subjectParentName, long dateTimeNow)
    {
        //"SELECT COUNT(*) FROM contents WHERE time_shipment<NOW() AND user_id='" + userID + "' AND subject_parent_name = '" + subjectParentName + "' ORDER BY id_content";
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT COUNT(*) FROM contents WHERE time_shipment < " + dateTimeNow +  " AND subject_parent_name=" + "'" + subjectParentName + "'" + "ORDER BY id_content";
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
            connection.Close();
        }
        return 0;
    }
    //Получаем количество занятых слотов(которые производят в данный момент) загрузки по имени родителя
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetCountOfOccupiedLoadingSlotsByParentName(string subjectParentName, long dateTimeNow)
    {
        Debug.Log("GetCountOfOccupiedLoadingSlotsByParentName(subjectParentName=" + subjectParentName + ",dateTimeNow=" + dateTimeNow + ")");
        //string sql = "SELECT COUNT(*) FROM contents WHERE time_shipment>NOW() AND user_id='" + userID + "' AND subject_parent_name = '" + subjectParentName + "' ORDER BY id_content";
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT COUNT(*) FROM contents WHERE time_shipment > " + dateTimeNow + " AND subject_parent_name=" + "'" + subjectParentName + "'" + "ORDER BY id_content";
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
            connection.Close();
        }
        return 0;
    }
    //Получаем количество предметов находящихся в таблице, по имени объекта
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
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
            connection.Close();
        }
        return 0;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    //Подготовка запроса
    public string QueryAddContents(string subjectParentName, string subjectChildName, long timeLoading, long timeShipment, int outputQuantity)
    {
        // SQLQuery = "INSERT INTO contents (subject_parent_name, subject_child_name, time_loading, time_shipment, output_quantity, user_id) VALUES ('"+subjectParentName+ "','" + subjectChildName + "','" + timeLoading + "','" + timeShipment + "'," + outputQuantity + "," + userId + ")";;
        string query = "INSERT INTO contents (subject_parent_name, subject_child_name, time_loading, time_shipment, output_quantity) VALUES("+"'"+subjectParentName+"','"+subjectChildName+"','"+ timeLoading + "','" + timeShipment + "'," +outputQuantity+")";
        Debug.Log(query);
        //var_dump($query);
        return query;
    }
    //Метод только добавляет в БД полученные значения
    // SQLQuery = "INSERT contents (subject_parent_name, subject_child_name, time_loading, time_shipment, output_quantity, user_id) VALUES ('"+subjectParentName+ "','" + subjectChildName + "','" + timeLoading + "','" + timeShipment + "'," + outputQuantity + "," + userId + ")";;
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void AddContents(string subjectParentName, string subjectChildName, long timeLoading, long timeShipment, int outputQuantity)
    {     
        // Open a connection to the database.
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        IDbConnection dbConnection = new SqliteConnection(dbUri); // 5
        dbConnection.Open(); // 6
        // Create a table for the hit count in the database if it does not exist yet.
        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand(); // 6
        string query = QueryAddContents(subjectParentName, subjectChildName, timeLoading, timeShipment, outputQuantity);
        Debug.Log(query);
        dbCommandCreateTable.CommandText = query; // 7
        dbCommandCreateTable.ExecuteReader(); // 8
        //dbCommandCreateTable.CommandText = SQLQueryFull; // 7
        //dbCommandCreateTable.ExecuteReader(); // 8
        dbConnection.Close(); // 9
    }
    //Получаем ID первого стоящего на отгрузку объекта
    //query = "SELECT id_content FROM content WHERE time_shipment<? AND user_id =? AND subject_parent_name =? ORDER BY id_content ASC LIMIT 0,1"; 
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetShipmentID(string subjectParentName, long dateTimeNow)
    {
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        //string sqlExpression = "SELECT COUNT(*) FROM contents WHERE subject_parent_name=" + "'" + subjectChildName + "'" + "ORDER BY id_content";
        string sqlExpression = "SELECT id_content FROM contents WHERE time_shipment <" +dateTimeNow+ " AND subject_parent_name =" + "'" + subjectParentName + "'" + " ORDER BY id_content ASC LIMIT 0,1";
        int shipmentID;
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
                        shipmentID = Convert.ToInt32(reader.GetValue(0));
                        return shipmentID;
                    }
                }
            }
            connection.Close();
        }
        return -1;
    }
    //Получение количества объектов на выходе по id_content
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetCountOutputQuantity(int idContent)
    {
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        //$query = "SELECT output_quantity FROM " . $this->table_name . "WHERE id_content =? ";
        string sqlExpression = "SELECT output_quantity FROM contents WHERE id_content=" + idContent + "";
        int count;
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
                        count = Convert.ToInt32(reader.GetValue(0));
                        return count;
                    }
                }
            }
            connection.Close();
        }
        return -1;
    }
    //Получение имени выгружаемого объекта по id_content
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetSubjectName(int idContent)
    {
        //$query = "SELECT subject_child_name FROM " . $this->table_name . "WHERE id_content =? ";
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT subject_child_name FROM contents WHERE id_content= " + "" + idContent + "";
        string subjectChildName;
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
                        subjectChildName = reader.GetValue(0).ToString();
                        return subjectChildName;
                    }
                }
            }
            connection.Close();
        }
        return "Error";
    }
    //Формирование запроса на удаление записи
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string QueryDeleteContent(int idContent)
    {
        //$query = "DELETE FROM " . $this->table_name . "WHERE id_content = ".$idContent;
        string query = "DELETE FROM contents WHERE id_content="+idContent+"";           
        return query;
    }

    //Получаем дату выгрузки предмета(который еще находится в производстве) по номеру слота и имени главного объекта
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetDateShipment(string subjectParentName, int numberSlot, long dateTimeNow)
    {
        //$query = "SELECT time_shipment FROM " . $this->table_name . "WHERE time_shipment>? AND user_id =? AND subject_parent_name =?ORDER BY id_content ASC LIMIT ?,1"; 
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT time_shipment FROM contents WHERE time_shipment > "  + dateTimeNow + " AND subject_parent_name=" + "'" + subjectParentName + "'" + "ORDER BY id_content ASC LIMIT " + numberSlot + ",1";
        string dateShipment;
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
                        dateShipment = reader.GetValue(0).ToString();
                        return dateShipment;
                    }
                }
            }
            connection.Close();
        }
        return "Error";
    }
    //Получаем дату последнего стоящего в очереди объекта
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public long GetTimeShipmentDesc(string subjectParentName, long dateTimeNow)
    {
        //$query = "SELECT time_shipment FROM ". $this->table_name. "WHERE time_shipment>? AND user_id =? AND subject_parent_name =? ORDER BY id_content DESC LIMIT 0,1";
   
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT time_shipment FROM contents WHERE time_shipment > " +  dateTimeNow + " AND subject_parent_name=" + "'" + subjectParentName + "'" + " ORDER BY id_content DESC LIMIT 0,1";
        Debug.Log(sqlExpression);
        long dateShipmentDesc;
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
                        dateShipmentDesc = Convert.ToInt64(reader.GetValue(0));
                        return dateShipmentDesc;
                    }
                }
            }
            connection.Close();
        }
        return 0;
    }
    //Получаем Дату отгрузки первого объекта, находящегося в производстве
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public long GetTimeShipmentFirst(string subjectParentName, long dateTimeNow)
    {
        //$query = "SELECT time_shipment FROM " . $this->table_name . "WHERE time_shipment>? AND user_id =? AND subject_parent_name =? ORDER BY id_content ASC LIMIT 0,1"; 
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        //string sqlExpression = "SELECT CAST(time_shipment as nvarchar(20)) FROM contents WHERE time_shipment > " + "'" + dateTimeNow + "'" + " AND subject_parent_name=" + "'" + subjectParentName + "'" + " ORDER BY id_content ASC LIMIT 0,1";
        string sqlExpression = "SELECT time_shipment FROM contents WHERE time_shipment > " + dateTimeNow + " AND subject_parent_name=" + "'" + subjectParentName + "'" + " ORDER BY id_content ASC LIMIT 0,1";
        long dateShipmentAsc;
        Debug.Log(sqlExpression);
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
                        //reader.GetDateTime(0).ToString("dd.MM.yyyy HH:mm:ss");
                        //temp = reader.GetValue(0).T;
                        dateShipmentAsc = Convert.ToInt64(reader.GetValue(0));
                        Debug.Log(dateShipmentAsc);
                        return dateShipmentAsc;
                    }
                }
            }
            connection.Close();
        }
        return 0;
    }
    //Получить количество продуктов, находящихся в производстве
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetCountOfOccupiedBuildingSlots(string subjectParentName,long dateTimeNow)
    {
        //echo 'GetCountOfOccupiedShipmentSlotsByParentName($subjectParentName, $userID, $dateTimeNow)';
        //"SELECT COUNT(*) FROM contents WHERE time_shipment<NOW() AND user_id='" + userID + "' AND subject_parent_name = '" + subjectParentName + "' ORDER BY id_content";
        //$query = "SELECT COUNT(*) FROM " . $this->table_name . "WHERE time_shipment>? AND user_id =? AND subject_parent_name =? ORDER BY id_content";
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        //$query = "SELECT output_quantity FROM " . $this->table_name . "WHERE id_content =? ";
        string sqlExpression = "SELECT time_shipment FROM contents WHERE time_shipment > " + dateTimeNow + " AND subject_parent_name=" + "'" + subjectParentName + "'" + "ORDER BY id_content";
        int count;
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
                        count = Convert.ToInt32(reader.GetValue(0));
                        return count;
                    }
                }
            }
            connection.Close();
        }
        return -1;
    }
}
