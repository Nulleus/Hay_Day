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


public class ProgresSlot : MonoBehaviour
{
    [Serializable]
    public class POSTGetOpenSlotsCount
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
    public class ResponseGetOpenSlotsCount
    {
        public string message;
        public int openSlots;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    public GameObject Data;
    public int OpenSlots; //Количество открытых слотов у пользователя
    [SerializeField]
    public GameObject ParentSubject;
    private void Start()
    {

    }
    private void OnEnable()
    {

    }
    public void GetOpenSlotsCount(string subjectName)
    {

    }
    //Получить количество открытых слотов
    //$query = "SELECT open_slots FROM " . $this->table_name . " WHERE subject_name =? AND user_id =? LIMIT 0,1"; 
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetOpenSlotsCount(string subjectName, string locationDataProcessing)
    {
        if (locationDataProcessing == "Local")
        {
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
            string sqlExpression = "SELECT open_slots FROM progress_slots WHERE subject_name ='" + subjectName + "' LIMIT 0,1";
            int openSlots;
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
                            openSlots = Convert.ToInt32(reader.GetValue(0));
                            return openSlots;
                        }
                    }
                }
            }
        }
        if (locationDataProcessing == "Server")
        {
            RestClient.Post<ResponseGetOpenSlotsCount>("http://45.84.226.98/api/progres_slot_execute_methods.php", new POSTGetOpenSlotsCount
            {
                jwt = Data.GetComponent<User>().GetJWTToken(),
                methodName = "GetOpenSlotsCount",
                subjectName = subjectName
            }).Then(response => {
                //EditorUtility.DisplayDialog("message: ", response.message, "Ok");
                //EditorUtility.DisplayDialog("openSlots: ", response.openSlots.ToString(), "Ok");
                Debug.Log(response.openSlots);
                OpenSlots = response.openSlots;
                Debug.Log("openSlots=" + OpenSlots);
            });
        }
        return -1;
    }
}
