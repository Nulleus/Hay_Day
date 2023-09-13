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
    private void Test()
    {
        var dateTimeNow = DateTime.Now;
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
        string test12=GetTimeShipmentDesc("bakery", dateTimeNow);
        Debug.Log("Test12=" + test12);
        string test13 = GetTimeShipmentFirst("bakery", dateTimeNow);
        Debug.Log("Test13=" + test13);
        int test14 = GetCountOfOccupiedBuildingSlots("bakery", dateTimeNow);
        Debug.Log("Test14=" + test14);
    }
    private void OnEnable()
    {
        Test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //�������� �������, ����������� � ���� �������� ��� ������� ����� �� ������
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
                if (reader.HasRows) // ���� ���� ������
                {
                    while (reader.Read())   // ��������� ��������� ������
                    {
                        subjectChildInTheShipment = reader.GetValue(0).ToString();
                        return subjectChildInTheShipment;
                    }
                }
            }
        }
        return "Error";
    }
    //�������� �������, ����������� � ������������ ��� ������� ����� �� ������, �������������� ������������
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
                if (reader.HasRows) // ���� ���� ������
                {
                    while (reader.Read())   // ��������� ��������� ������
                    {
                        subjectChildInTheShipment = reader.GetValue(0).ToString();
                        return subjectChildInTheShipment;
                    }

                }
            }
        }
        return "Error";
    }
    //�������� ���������� ������� ����������, ����������� � ���� ��������
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
                if (reader.HasRows) // ���� ���� ������
                {
                    while (reader.Read())   // ��������� ��������� ������
                    {
                        countOfOccupiedShipment = Convert.ToInt32(reader.GetValue(0));
                        return countOfOccupiedShipment;
                    }
                }
            }
        }
        return 0;
    }
    //�������� ���������� ������� ������(������� ���������� � ������ ������) �������� �� ����� ��������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
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
                if (reader.HasRows) // ���� ���� ������
                {
                    while (reader.Read())   // ��������� ��������� ������
                    {
                        countOfOccupiedLoading = Convert.ToInt32(reader.GetValue(0));
                        return countOfOccupiedLoading;
                    }
                }
            }
        }
        return 0;
    }
    //�������� ���������� ��������� ����������� � �������, �� ����� �������
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
                if (reader.HasRows) // ���� ���� ������
                {
                    while (reader.Read())   // ��������� ��������� ������
                    {
                        countAllSlots = Convert.ToInt32(reader.GetValue(0));
                        return countAllSlots;
                    }
                }
            }
        }
        return 0;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    //���������� �������
    public string QueryAddContents(string subjectParentName, string subjectChildName, DateTime timeLoading, DateTime timeShipment, int outputQuantity)
    {
        // SQLQuery = "INSERT INTO contents (subject_parent_name, subject_child_name, time_loading, time_shipment, output_quantity, user_id) VALUES ('"+subjectParentName+ "','" + subjectChildName + "','" + timeLoading + "','" + timeShipment + "'," + outputQuantity + "," + userId + ")";;


        string convertTimeLoading = timeLoading.ToString();
        string convertTimeShipment = timeShipment.ToString();
        string query = "INSERT INTO contents (subject_parent_name, subject_child_name, time_loading, time_shipment, output_quantity) VALUES("+"'"+subjectParentName+"','"+subjectChildName+"','"+ convertTimeLoading + "','" + convertTimeShipment + "'," +outputQuantity+")";
        Debug.Log(query);
        //var_dump($query);
        return query;
    }
    //����� ������ ��������� � �� ���������� ��������
    // SQLQuery = "INSERT contents (subject_parent_name, subject_child_name, time_loading, time_shipment, output_quantity, user_id) VALUES ('"+subjectParentName+ "','" + subjectChildName + "','" + timeLoading + "','" + timeShipment + "'," + outputQuantity + "," + userId + ")";;
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void AddContents(string subjectParentName, string subjectChildName, DateTime timeLoading, DateTime timeShipment, int outputQuantity)
    {
        string timeLoadingConvert = timeLoading.ToString();
        string timeShipmentConvert = timeShipment.ToString();
        
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
    //�������� ID ������� �������� �� �������� �������
    //query = "SELECT id_content FROM content WHERE time_shipment<? AND user_id =? AND subject_parent_name =? ORDER BY id_content ASC LIMIT 0,1"; 
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetShipmentID(string subjectParentName, DateTime dateTimeNow)
    {
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        //string sqlExpression = "SELECT COUNT(*) FROM contents WHERE subject_parent_name=" + "'" + subjectChildName + "'" + "ORDER BY id_content";
        string sqlExpression = "SELECT id_content FROM contents WHERE time_shipment<"+"'"+dateTimeNow+"'"+ "AND subject_parent_name =" + "'" + subjectParentName + "'" + " ORDER BY id_content ASC LIMIT 0,1";
        int shipmentID;
        using (var connection = new SqliteConnection(dbUri))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // ���� ���� ������
                {
                    while (reader.Read())   // ��������� ��������� ������
                    {
                        shipmentID = Convert.ToInt32(reader.GetValue(0));
                        return shipmentID;
                    }
                }
            }
        }
        return -1;
    }
    //��������� ���������� �������� �� ������ �� id_content
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
                if (reader.HasRows) // ���� ���� ������
                {
                    while (reader.Read())   // ��������� ��������� ������
                    {
                        count = Convert.ToInt32(reader.GetValue(0));
                        return count;
                    }
                }
            }
        }
        return -1;
    }
    //��������� ����� ������������ ������� �� id_content
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
                if (reader.HasRows) // ���� ���� ������
                {
                    while (reader.Read())   // ��������� ��������� ������
                    {
                        subjectChildName = reader.GetValue(0).ToString();
                        return subjectChildName;
                    }
                }
            }
        }
        return "Error";
    }
    //������������ ������� �� �������� ������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string QueryDeleteContent(int idContent)
    {
        //$query = "DELETE FROM " . $this->table_name . "WHERE id_content = ".$idContent;
        string query = "DELETE FROM contents WHERE id_content="+idContent+"";           
        return query;
    }

    //�������� ���� �������� ��������(������� ��� ��������� � ������������) �� ������ ����� � ����� �������� �������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetDateShipment(string subjectParentName, int numberSlot, DateTime dateTimeNow)
    {
        //$query = "SELECT time_shipment FROM " . $this->table_name . "WHERE time_shipment>? AND user_id =? AND subject_parent_name =?ORDER BY id_content ASC LIMIT ?,1"; 
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT time_shipment FROM contents WHERE time_shipment > " + "'" + dateTimeNow + "'" + "AND subject_parent_name=" + "'" + subjectParentName + "'" + "ORDER BY id_content ASC LIMIT " + numberSlot + ",1";
        string dateShipment;
        using (var connection = new SqliteConnection(dbUri))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // ���� ���� ������
                {
                    while (reader.Read())   // ��������� ��������� ������
                    {
                        dateShipment = reader.GetValue(0).ToString();
                        return dateShipment;
                    }
                }
            }
        }
        return "Error";
    }
    //�������� ���� ���������� �������� � ������� �������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetTimeShipmentDesc(string subjectParentName, DateTime dateTimeNow)
    {
        //$query = "SELECT time_shipment FROM ". $this->table_name. "WHERE time_shipment>? AND user_id =? AND subject_parent_name =? ORDER BY id_content DESC LIMIT 0,1";
        string dateTimeNowConvert = dateTimeNow.ToString(); 
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT time_shipment FROM contents WHERE time_shipment > " + "'" + dateTimeNowConvert + "'" + " AND subject_parent_name=" + "'" + subjectParentName + "'" + " ORDER BY id_content DESC LIMIT 0,1";
        Debug.Log(sqlExpression);
        string dateShipmentDesc;
        using (var connection = new SqliteConnection(dbUri))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // ���� ���� ������
                {
                    while (reader.Read())   // ��������� ��������� ������
                    {
                        dateShipmentDesc = reader.GetValue(0).ToString();
                        return dateShipmentDesc;
                    }
                }
            }
        }
        return "Error";
    }
    //�������� ���� �������� ������� �������, ������������ � ������������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetTimeShipmentFirst(string subjectParentName, DateTime dateTimeNow)
    {
        //$query = "SELECT time_shipment FROM " . $this->table_name . "WHERE time_shipment>? AND user_id =? AND subject_parent_name =? ORDER BY id_content ASC LIMIT 0,1"; 
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT time_shipment FROM contents WHERE time_shipment > " + "'" + dateTimeNow + "'" + "AND subject_parent_name=" + "'" + subjectParentName + "'" + "ORDER BY id_content ASC LIMIT 0,1";
        string dateShipmentAsc;
        using (var connection = new SqliteConnection(dbUri))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // ���� ���� ������
                {
                    while (reader.Read())   // ��������� ��������� ������
                    {
                        dateShipmentAsc = reader.GetValue(0).ToString();
                        return dateShipmentAsc;
                    }
                }
            }
        }
        return "Error";
    }
    //�������� ���������� ���������, ����������� � ������������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetCountOfOccupiedBuildingSlots(string subjectParentName,DateTime dateTimeNow)
    {
        //echo 'GetCountOfOccupiedShipmentSlotsByParentName($subjectParentName, $userID, $dateTimeNow)';
        //"SELECT COUNT(*) FROM contents WHERE time_shipment<NOW() AND user_id='" + userID + "' AND subject_parent_name = '" + subjectParentName + "' ORDER BY id_content";
        //$query = "SELECT COUNT(*) FROM " . $this->table_name . "WHERE time_shipment>? AND user_id =? AND subject_parent_name =? ORDER BY id_content";
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        //$query = "SELECT output_quantity FROM " . $this->table_name . "WHERE id_content =? ";
        string sqlExpression = "SELECT time_shipment FROM contents WHERE time_shipment > " + "'" + dateTimeNow + "'" + "AND subject_parent_name=" + "'" + subjectParentName + "'" + "ORDER BY id_content";
        int count;
        using (var connection = new SqliteConnection(dbUri))
        {
            connection.Open();
            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // ���� ���� ������
                {
                    while (reader.Read())   // ��������� ��������� ������
                    {
                        count = Convert.ToInt32(reader.GetValue(0));
                        return count;
                    }
                }
            }
        }
        return -1;
    }
}
