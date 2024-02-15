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


public class SubjectSum : MonoBehaviour
{
    [Serializable]
    public class POSTGetSubjectSumCount
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
    public class ResponseGetSubjectSumCount
    {
        public string message;
        public int sumCount;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    public GameObject Data;
    public string SubjectName;
    public int SumCount;
    //Скрипт работает с таблицей subjects_sum
    // Start is called before the first frame update
    private void Start()
    {

    }
    private void OnEnable()
    {

    }
    //Подготовка запроса на уменьшение количества объектов
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string QueryReducingSubjectSumCount(string subjectName, int count)
    {
	    string query = "UPDATE subjects_sum SET sum_count=sum_count - "+count+" WHERE subject_name='"+subjectName+"'";
        return query;
    }
    //Подготовка запроса на увеличение количества объектов
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string QueryIncreasingSubjectSumCount(string subjectName, int count)
    {
	    string query = "UPDATE subjects_sum SET sum_count=sum_count + "+count+" WHERE subject_name='"+subjectName+"'";
        return query;
    }

    //Получить количество объектов
    //$query = "SELECT sum_count FROM " . $this->table_name . "WHERE subject_name =? AND user_id =? LIMIT 0,1";
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetSubjectSumCount(string subjectName, string locationDataProcessing)
    {
        if (locationDataProcessing == "Local")
        {
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
            string sqlExpression = "SELECT sum_count FROM subjects_sum WHERE subject_name ='" + subjectName + "' LIMIT 0,1";
            int subjectSumCount;
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
                            subjectSumCount = Convert.ToInt32(reader.GetValue(0));
                            return subjectSumCount;
                        }
                    }
                }
                connection.Close();
            }
        }
        if (locationDataProcessing == "Server")
        {
            return -1;
        }
        return -1;
}

}
