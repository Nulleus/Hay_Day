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

public class Preload : MonoBehaviour
{
    [ShowInInspector]
    public string SQLQueryFull;
    public GameObject Data;
    [ShowInInspector]
    public string File;
    [ShowInInspector]
    public DateTime ServerTimeNow;
    [ShowInInspector]
    public DateTime ClientTimeNow;
    [ShowInInspector]
    public TimeSpan DateDifference;
    [Serializable]
    public class ResponseGetDateTimeNowServer
    {
        public string dateTimeNow;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTGetDateTimeNowServer
    {
        public string jwt;
        public string methodName;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }

    [Serializable]
    public class POSTFileDataBase
    {
        public string jwt;
        public string methodName;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseFileDataBase
    {
        public string file;
    }
    //Получаем файл .sql для импорта данных в локальную базу данных
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetFileDataBase(string fileName)
    {
        RestClient.Post<ResponseFileDataBase>("http://farmpass.beget.tech/api/dump_sql.php", new POSTFileDataBase
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetSQLQueryFull"
        }).Then(response => {
            File = response.file;
            Debug.Log("File" + response.file);
        });

    }

    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    //Получаем даннные для импорта в базу данных
    void GetSQLQueryFull()
    {
        var PFDB = new POSTFileDataBase
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetSQLQueryFull"
        };

        var body = JsonUtility.ToJson(PFDB);
        StartCoroutine(postRequest("http://farmpass.beget.tech/api/dump_sql.php", body));
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    //Импортируем БД с сервера
    private void SetSQLQueryFull()
    {
        Debug.Log("SetSQLQueryFull");
        // Insert hits into the table.
        // Open a connection to the database.
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        IDbConnection dbConnection = new SqliteConnection(dbUri); // 5
        dbConnection.Open(); // 6
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand(); // 9
        dbCommandInsertValue.CommandText = SQLQueryFull; // 10
        dbCommandInsertValue.ExecuteNonQuery(); // 11
        // Remember to always close the connection at the end.
        dbConnection.Close(); // 12
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    //Очищаем БД с которой будем работать
    private IDbConnection ClearingDatabase() // 3
    {
        Debug.Log("CreateAndOpenDatabase()");
        // Open a connection to the database.
        string dbName = "MyDatabase.sqlite";
        string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
        IDbConnection dbConnection = new SqliteConnection(dbUri); // 5
        dbConnection.Open(); // 6
        
        // Create a table for the hit count in the database if it does not exist yet.
        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand(); // 6
        //Очищаем таблицу полностью
        dbCommandCreateTable.CommandText = "DROP TABLE IF EXISTS users; DROP TABLE IF EXISTS contents; DROP TABLE IF EXISTS contents; DROP TABLE IF EXISTS progress_slots; DELETE FROM sqlite_sequence; DROP TABLE IF EXISTS subjects_sum; "; // 7
        dbCommandCreateTable.ExecuteReader(); // 8
        //dbCommandCreateTable.CommandText = SQLQueryFull; // 7
        //dbCommandCreateTable.ExecuteReader(); // 8
        dbConnection.Close(); // 9
        return dbConnection;
    }

    //Получаем файл .sql для импорта данных в локальную базу данных
    IEnumerator postRequest(string url, string json)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            SQLQueryFull = utf8.GetString(uwr.downloadHandler.data);
            Debug.Log("Received: " + SQLQueryFull);
            Debug.Log(Application.persistentDataPath);
            //StreamWriter sw = new StreamWriter(Application.persistentDataPath + @"/PlayerName.txt");
            //sw.Write(uwr.downloadHandler.text);
            //sw.Close();
        }
    }

   //Получаем серверное время
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetDateTimeNowServer()
    {
        RestClient.Post<ResponseGetDateTimeNowServer>("http://farmpass.beget.tech/api/preload_execute_methods.php", new POSTGetDateTimeNowServer
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetDateTimeNow"
        }).Then(response => {
            ServerTimeNow = DateTime.Parse(response.dateTimeNow);
            Debug.Log("dateTimeNowServer" + response.dateTimeNow);
        });
    }
    //Получаем время клиента
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetDateTimeNowClient()
    {
        ClientTimeNow = DateTime.Now;
        Debug.Log("ClientTimeNow=" + ClientTimeNow);
    }
    //Получаем разницу времени между клиентом и сервером
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetDateDifference()
    {
        DateTime clientTimeNow = ClientTimeNow;
        DateTime serverTimeNow = ServerTimeNow;
        string formatForConvertA = clientTimeNow.ToString("yyyy-MM-dd HH:mm:ss");
        string formatForConvertB = serverTimeNow.ToString("yyyy-MM-dd HH:mm:ss");
        //Возвращает объект CultureInfo, не зависящий от языка и региональных параметров(инвариантный).
        DateTime start = DateTime.ParseExact(formatForConvertA, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        Debug.Log("start" + start);
        //Возвращает объект CultureInfo, не зависящий от языка и региональных параметров (инвариантный).
        DateTime end = DateTime.ParseExact(formatForConvertB, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        Debug.Log("end" + end);
        DateDifference = start - end;
        Debug.Log("DateDifference=" + DateDifference.TotalSeconds);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        GetDateTimeNowClient();
        GetDateTimeNowServer();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
