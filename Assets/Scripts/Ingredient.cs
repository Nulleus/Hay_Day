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

//������ ��������� ������ �� �������(������������) � ������� "Ingredient" �� ��������� ���� ������
public class Ingredient : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //�������� ���������� ��������, ����������� ��� ������������ ������� �� �����
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetCountAllIngredients(string subjectName)
    {
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT COUNT(*)FROM ingredients WHERE subject_name =" + "'" + subjectName + "'";
        int countAllIngredients;
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
                        countAllIngredients = Convert.ToInt32(reader.GetValue(0));
                        return countAllIngredients;
                    }

                }
            }
        }
        return 0;
    }

    //�������� ��� ����������� ����� ������� � �� ������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetIngredientName(string subjectName, int number)
    {
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        //string sqlExpression = "SELECT COUNT(*)FROM ingredients WHERE subject_name =" + "'" + subjectName + "'";
        string sqlExpression = "SELECT ingredient_name FROM ingredients WHERE subject_name =" + "'" + subjectName + "'" + "LIMIT " + number.ToString() + ",1";
        string ingredientName;
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
                        ingredientName = reader.GetValue(0).ToString();
                        return ingredientName;
                    }

                }
            }
        }
        return "Error";
    }
    //�������� ���������� ������������ ����������� ����� ������� � �� ������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetCountIngredient(string subjectName, int number)
    {
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        string sqlExpression = "SELECT count_ingredients FROM ingredients WHERE subject_name =" + "'" + subjectName + "'" + "LIMIT " + number.ToString() + ",1";
        int countIngredient;
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
                        countIngredient = Convert.ToInt32(reader.GetValue(0));
                        return countIngredient;
                    }
                }
            }
        }
        return 0;
    }

    //�������� �����������, � �� ���������� ����������� ��� ������������ ��������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public IDictionary<string, int> GetAllIngredients(string subjectName)
    {
        var allIngredients = new Dictionary<string, int>();
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        //string sqlExpression = "SELECT COUNT(*)FROM ingredients WHERE subject_name =" + "'" + subjectName + "'";
        string sqlExpression = "SELECT ingredient_name,count_ingredients FROM ingredients WHERE subject_name =" + "'" + subjectName + "'";
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
                        allIngredients.Add(reader.GetValue(0).ToString(), Convert.ToInt32(reader.GetValue(1)));
                    }
                    return allIngredients;
                }
            }
        }
        return allIngredients;
    }
}
