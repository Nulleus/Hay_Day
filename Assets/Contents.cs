using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using Proyecto26;
using UnityEditor;


public class Contents : MonoBehaviour
{
    [Serializable]
    public class ResponseSubjectChildInTheProcessOfAssembly
    {
        public string message;
        public string subjectChildName;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }

    [Serializable]
    public class POSTSubjectChildInTheProcessOfAssembly
    {
        public string jwt;
        public string methodName;
        public string subjectParentName;
        public int numberSlot;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseGetServerDateTime
    {
        public string message;
        public string serverDateTime;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }

    [Serializable]
    public class POSTGetServerDateTime
    {
        public string jwt;
        public string methodName;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTGetCountOfOccupiedShipmentSlotsByParentName
    {
        public string jwt;
        public string methodName;
        public string subjectParentName;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseGetCountOfOccupiedShipmentSlotsByParentName
    {
        public string message;
        public int countShipmentSlots;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    public class POSTGetCountOfOccupiedLoadingSlotsByParentName
    {
        public string jwt;
        public string methodName;
        public string subjectParentName;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseGetCountOfOccupiedLoadingSlotsByParentName
    {
        public string message;
        public int countLoadingSlots;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    public class POSTAddContents
    {
        public string jwt;
        public string methodName;
        public string subjectParentName;
        public string subjectChildName;
        public string timeLoading;
        public string timeShipment;
        public int outputQuantity;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseAddContents
    {
        public string message;
        public bool result;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    //GetCountOfOccupiedShipmentSlotsByParentName
    public GameObject Data;
    [SerializeField]
    private string ServerDateTime;
 

    private void Start()
    {

    }
    //Получаем продукт, находящийся в производстве для каждого слота по номеру
    public string GetSubjectChildInTheProcessOfAssembly(string subjectParentName, int numberSlot)
    {
        //Debug.Log("GetAllSubjectNameByOpenLevel");
        RestClient.Post<ResponseSubjectChildInTheProcessOfAssembly>("http://farmpass.beget.tech/api/content_execute_methods.php", new POSTSubjectChildInTheProcessOfAssembly
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetSubjectChildInTheProcessOfAssembly",
            subjectParentName = subjectParentName,
            numberSlot = numberSlot
            

        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("message: ", response.ToString(), "Ok");
            EditorUtility.DisplayDialog("subjectChildName: ", response.subjectChildName, "Ok");
            return response.subjectChildName;
        });
        return "empty";
    }

    //Класс отвечает за работу с таблицей Contents в БД
    //string formatForMySql = dateValue.ToString("yyyy-MM-dd HH:mm:ss");
    public string GetServerDateTime()//Получаем серверное время
    {
        //Debug.Log("GetServerDateTime");
        RestClient.Post<ResponseGetServerDateTime>("http://farmpass.beget.tech/api/content_execute_methods.php", new POSTGetServerDateTime
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetServerDateTime"

        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("serverDateTime: ", response.serverDateTime, "Ok");
            ServerDateTime = response.serverDateTime;
        });
        return ServerDateTime;
    }

    //Прибавляем дате определенное количество секунд
    public string GetSummDateTimeAndSeconds(string time, int second) 
    {
        var convertA = DateTime.Parse(time);//Конвертируем строку в дату
        return convertA.AddSeconds(second).ToString("yyyy-MM-dd HH:mm:ss"); 
    }
    //Получить количество готовых продуктово, находящиеся в зоне отгрузки(shipment)
    public int GetCountOfOccupiedShipmentSlotsByParentName(string subjectParentName)
    {
        //Debug.Log("GetCountOfOccupiedShipmentSlotsByParentName");
        RestClient.Post<ResponseGetCountOfOccupiedShipmentSlotsByParentName>("http://farmpass.beget.tech/api/content_execute_methods.php", new POSTGetCountOfOccupiedShipmentSlotsByParentName
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetCountOfOccupiedShipmentSlotsByParentName",
            subjectParentName = subjectParentName


        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("countShipmentSlots: ", response.countShipmentSlots.ToString(), "Ok");
            return response.countShipmentSlots;
        });
        return 0;
    }
    //Получаем количество занятых слотов загрузки по имени родителя
    public int GetCountOfOccupiedLoadingSlotsByParentName(string subjectParentName)
    {
        //Debug.Log("GetCountOfOccupiedLoadingSlotsByParentName");
        RestClient.Post<ResponseGetCountOfOccupiedLoadingSlotsByParentName>("http://farmpass.beget.tech/api/content_execute_methods.php", new POSTGetCountOfOccupiedLoadingSlotsByParentName
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetCountOfOccupiedLoadingSlotsByParentName",
            subjectParentName = subjectParentName


        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("countLoadingSlots: ", response.countLoadingSlots.ToString(), "Ok");
            return response.countLoadingSlots;
        });
        return 0;
    }
    //Метод только добавляет в БД полученные значения
    public void AddContents(string subjectParentName, string subjectChildName)
    {
        string timeLoading = Data.GetComponent<Contents>().GetServerDateTime();//Дата загрузки равна текущему времени сервера
        Debug.Log("timeLoading=" + timeLoading);
        int timeBuilding = Data.GetComponent<BuildingTimes>().GetTimeBuilding(subjectChildName);
        Debug.Log("timeBuilding" + timeBuilding);
        //Время отгрузки равно текущему времени сервера плюс время изготовления объекта
        string timeShipment = Data.GetComponent<Contents>().GetSummDateTimeAndSeconds(timeLoading, Data.GetComponent<BuildingTimes>().GetTimeBuilding(subjectChildName));
        Debug.Log("timeShipment=" + timeShipment);
        //int outputQuantity = Data.GetComponent<OutputQuantity>().GetOutputQuantityBySubjectName(subjectChildName);//Количество на выходе равно, значению из таблицы output_quantity
        //Для тестирования, необходимо переделать класс Output Quantity
        int outputQuantity = 1;
        RestClient.Post<ResponseAddContents>("http://farmpass.beget.tech/api/content_execute_methods.php", new POSTAddContents
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "AddContents",
            subjectParentName = subjectParentName,
            subjectChildName = subjectChildName,
            timeLoading = timeLoading,
            timeShipment = timeShipment,
            outputQuantity = outputQuantity

            //($subjectParentName, $subjectChildName, $timeLoading, $timeShipment, $outputQuantity, $userID)

        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("result: ", response.result.ToString(), "Ok");
            return response.result;
        });
    }
    /*
    public void AddContents(string subjectParentName, string subjectChildName, int userId) 
    {
        string timeLoading = GetServerDateTime();//Дата загрузки равна текущему времени сервера
        string timeShipment = GetSummDateTimeAndSeconds(timeLoading, Data.GetComponent<BuildingTimes>().GetTimeBuilding(subjectChildName));//Время отгрузки равно текущему времени сервера плюс время изготовления объекта
        int outputQuantity = Data.GetComponent<OutputQuantity>().GetOutputQuantityBySubjectName(subjectChildName);//Количество на выходе равно, значению из таблицы output_quantity

        //var timeShipmentTemp = DateTime.Parse(timeShipment);//Конвертируем строку в дату
        //timeShipmentTemp.AddSeconds(GetTimeBuilding(subjectChild));//Прибавляем конвертированной дате секунды производства равную времени производства объъекта
        //timeShipment = timeShipmentTemp.ToString("yyyy-MM-dd HH:mm:ss"); //Конвертируем дату во время определенного формата БД MySQL
        var SQLQuery = "INSERT contents (subject_parent_name, subject_child_name, time_loading, time_shipment, output_quantity, user_id) VALUES ('"+subjectParentName+ "','" + subjectChildName + "','" + timeLoading + "','" + timeShipment + "'," + outputQuantity + "," + userId + ")";
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();          
            MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        conn.Close();
        Console.WriteLine("Done.");
    }
    */
    //Получаем ID первого стоящего на выгрузку объекта
    public int GetShipmentID(string subjectParentName, int userID) 
    {
        int contentID;
        Debug.Log("method GetShipmentID");
        Debug.Log(Data.GetComponent<Connections>().ConnectionString);
        MySqlConnection conn = new MySqlConnection(Data.GetComponent<Connections>().ConnectionString);
        try
        {
            Debug.Log("Connecting to MySQL...");
            conn.Open();
            //var SQLQuery = "SELECT output_quantity from output_quantity_subjects WHERE name_subject='" + subjectName + "' LIMIT 0,1 ";
            var SQLQuery = "SELECT id_content FROM contents WHERE time_shipment<NOW() AND user_id='" + userID + "' AND subject_parent_name = '" + subjectParentName + "' ORDER BY id_content ASC LIMIT 0,1";
            MySqlCommand cmd = new MySqlCommand(SQLQuery, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                contentID = (int)reader["id_content"];

                Debug.Log(contentID);
                return contentID;
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());
        }
        conn.Close();
        Debug.Log("Done.");
        return 0;
    }
    //static string GetShipment
    //Получаем готовый продукт,для каждого слота по номеру(нужно ли это для механики?)
    //Получаем первый готовый продукт в очереди
    //Освобождение слота отгрузки(В нем вызываем метод, увеличивающий количество выгруженного предмета на складе)
    //archive_contents
    private void OnEnable()
    {
        //GetSubjectChildInTheProcessOfAssembly("bakery", 1);
        //GetServerDateTime();
        //GetCountOfOccupiedShipmentSlotsByParentName("bakery");
        //GetCountOfOccupiedLoadingSlotsByParentName("bakery");

        //Data.GetComponent<BuildingTimes>().GetTimeBuilding("bread");
        //AddContents("bakery", "bread");
        BuildingTimes BT = new BuildingTimes();
        int s = BT.GetTimeBuilding("wheat");
        Debug.Log(s);
    }
}
