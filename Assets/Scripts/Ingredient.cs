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
    public GameObject Data;
    public class MissingIngredient
    {
        public string ingredient_name;
        public int count_ingredients;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    //�������� ������ ����������� ������������ � ������������ � �� ����������
    public List<MissingIngredient> GetMissingIngredients(string subjectName)
    {
        IDictionary<string, int> allIngredients = this.GetAllIngredients(subjectName);
        List<MissingIngredient> missing = new List<MissingIngredient>();
        //��������� ���� �� ������ �����������, �������� ������� ���������
        foreach (var item in allIngredients)
        {
            
            string ingredientNameTemp = item.Key;
            //�������� ���������� ����������� �� ������
            var ss = Data.GetComponent<SubjectSum>();
            int subjectSum = ss.GetSubjectSumCount(ingredientNameTemp, "Local");
            //���������, ������� �� ��������
            //���� ������������ �� ������ ������, ��� ����� ��� ������������
            if (subjectSum < item.Value) {					
                //���������� ����������� ��������
				int missSubjectCount = item.Value - subjectSum;
                
                var mi = new MissingIngredient();
                mi.ingredient_name = item.Key;
                mi.count_ingredients = missSubjectCount;
                missing.Add(mi);
            }
        }
        return missing;
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
            connection.Close();
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
            connection.Close();
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
            connection.Close();
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
            connection.Close();
        }
        return allIngredients;
    }
}
