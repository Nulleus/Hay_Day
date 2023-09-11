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

public class ProductionBuilding : MonoBehaviour
{
    private void LogMessage(string title, string message)
    {
#if UNITY_EDITOR
        //EditorUtility.DisplayDialog(title, message, "Ok");
#else
		Debug.Log(message);
#endif
    }

    [ShowInInspector]
    public List<LastIngredient> LastIngredients;
    public GameObject Data;
    [ShowInInspector]
    public string SubjectName;
    
    public int MaxCountSlots;
    //��� ������������ � ������������ ��������
    public string[] SubjectsChildInTheProcessOfAssembly = new string[10];
    //��� ������������ � ���� �������� ��������
    public string[] SubjectsChildInTheShipment = new string[10];
    //����� ��������� ��������� �� ������
    [ShowInInspector]
    public int AllCost;
    [ShowInInspector]
    public Dictionary<string, string> ResponseFromRequests = new Dictionary<string, string>();
    public bool CheckGetSubjectChildInTheProcessOfAssembly;

    //public ExtendedDictonary<string, string> ResponseFromRequests = new ExtendedDictonary<string, string>();
    //GetTranslateInfoRUS
    [ShowInInspector]
    public Dictionary<string, Translate> ResponsesTranslateInfoRUS = new Dictionary<string, Translate>();
    [ShowInInspector]
    //���� ���������� ������� ���������� ������ ������������
    public float TimeBeforeStartRequest;
    public bool CheckInBuilding;
    public bool TimerEnable;
    
    

    [Serializable]
    public class POSTGetDifferenceDateInSeconds
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
    public class Translate
    {
        public string SubjectName;
        public string Name;
        public string Discription;
        public string TimeBuilding;
        public Translate(string subjectName, string name, string discription, string timeBuilding)
        {
            SubjectName = subjectName;
            Name = name;
            Discription = discription;
            TimeBuilding = timeBuilding;
        }
    }
    [Serializable]
    public class POSTGetTranslateInfoRU
    {
        public string jwt;
        public string methodName;
        public string subjectName;
        public string languageName;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseGetTranslateInfoRU
    {
        public string nameRU;
        public string discriptionRU;
        public string timeBuildingRU;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTGetAllCost
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
    public class ResponseGetAllCost
    {
        public int allCost;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTBuySubjectForDiamonds
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
    public class ResponseGetDifferenceDateInSeconds
    {

        public string expiredDate;
        public float differenceDateInSeconds;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseBuySubjectForDiamonds
    {
        public string code;
        public string message;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseAddInSlotSubject
    {
        public string code;
        public string message;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseShipment
    {
        public string code;
        public string message;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTAddInSlotSubject
    {
        public string jwt;
        public string methodName;
        public string subjectName;
        public string productionBuildingName;
        public int ignoreQuestion;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTGetMissingIngredients
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
    public class POSTGetLastIngredients
    {
        public string jwt;
        public string methodName;
        public string subjectName;
        public string productionBuildingName;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTShipment
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
    public class ResponseSubjectChildInTheProcessOfAssembly
    {
        public string subjectChildInTheProcessOfAssembly;
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
    public class ResponseSubjectChildInTheShipment
    {
        public string subjectChildInTheShipment;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTSubjectChildInTheShipment
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

    //�������� ������� �� ������ 
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void BuySubjectForDiamond(string subjectName, string locationDataProcessing)
    {
        if (locationDataProcessing == "Server")
        {
            RestClient.Post<ResponseBuySubjectForDiamonds>("http://45.84.226.98/api/production_building_execute_methods.php", new POSTBuySubjectForDiamonds
            {
                jwt = Data.GetComponent<User>().GetJWTToken(),
                methodName = "BuySubjectForDiamonds",
                subjectName = subjectName
            }).Then(response => {
                if (!ResponseFromRequests.ContainsKey(response.code))
                {
                    ResponseFromRequests.Add(response.code, response.message);
                }
                CheckResponseFromRequests(subjectName);
            });
        }
        if (locationDataProcessing == "Local")
        {
            //�������� ������ ��������� � �� �����������, ������� ���������
            var i = Data.GetComponent<Ingredient>();
            List<Ingredient.MissingIngredient> missingIngredients = i.GetMissingIngredients(subjectName);
            Debug.Log(missingIngredients);
            Dictionary<string, int> massive = new Dictionary<string, int>();
            foreach (var item in missingIngredients)
            {
                massive.Add(item.ingredient_name, item.count_ingredients);
            }
            //����� ��������� �������� �� ������
            var ps = Data.GetComponent<PriceSubject>();
            int allCost = ps.GetAllCost(ref massive);
            Debug.Log("allCost="+allCost);
            //��������, ������� � ������������ �������
            var ss = Data.GetComponent<SubjectSum>();
            int countsSubject = ss.GetSubjectSumCount("diamond", "Local");
            //���� ���������(������) ����������
            if (countsSubject >= allCost)
            {
                string dbName = "MyDatabase.sqlite";
                string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
                using (var connection = new SqliteConnection(dbUri))
                {
                    connection.Open();
                    using (var tra = connection.BeginTransaction())
                    {
                        try
                        {
                            Debug.Log("Try");
                            //connection.BeginTransaction();
                            //connection.BeginTransaction();
                            foreach (var item in missingIngredients)
                            {
                                string query = ss.QueryIncreasingSubjectSumCount(item.ingredient_name, item.count_ingredients);
                                Debug.Log(query);
                                SqliteCommand command = new SqliteCommand(query, connection, tra);
                                command.ExecuteNonQuery(); // 11
                            }
                            //string queryTwo = ss.QueryReducingSubjectSumCount("diamond", allCost);
                            //SqliteCommand commandTwo = new SqliteCommand(queryTwo, connection, tra);
                            
                            //commandTwo.ExecuteNonQuery();
                            tra.Commit();
                            // Remember to always close the connection at the end.
                            connection.Close(); // 12
                        }
                        catch (Exception ex)
                        {
                            //���������� ���������
                            tra.Rollback();
                            Debug.Log("Catch!");
                            throw;
                        }
                    }
                }
            }
            if (countsSubject < allCost) {
                //��������� ���������� �������� (�������) � ������� subjects_sum
                //���� ���������
                Debug.Log("��������� ���������� �������� (�������) � ������� subjects_sum");                            
            }
        }
    }
    //�������� ������� �� ������ �� ������� �������
    public void BuySubjectForDiamondClient(string subjectName)
    {
        //�������� ������ ��������� � �� �����������, ������� ���������
        //missingIngredients
        //����� ��������� �������� �� ������
        //��������, ������� � ������������ �������
        //$countsSubject
        //���� ���������(������) ����������
        //if ($countsSubject >= $allCost) {}

        //dbConnection.BeginTransaction().Rollback();
    }
    //��������� ����� �� �������
    public void CheckResponseFromRequests(string subjectNameForBuilding)
    {
        Debug.Log("CheckResponseFromRequests");
        foreach (var spisokResponseFromRequests in ResponseFromRequests)
        {
            //���� ������� ��������� �������
            if (spisokResponseFromRequests.Key == "0x0000004")
            {
                Debug.Log("0x0000004");
                //��������� ����� ��������
                GetAllInfoSlots();
                ResponseFromRequests.Remove("0x0000004");
            }
            
            //���� �������� �������, ������� �������� ��������� �� ������, ������� ��� � ������������
            if (spisokResponseFromRequests.Key == "0x0000008")
            {
                GetCheckIsLastSubject(subjectNameForBuilding, SubjectName);
                Debug.Log("0x0000008");
                GameObject panelQuestionBox = gameObject.GetComponent<ProductionBuildingUI>().PanelQuestionBox;
                GameObject panelQuestion = gameObject.GetComponent<ProductionBuildingUI>().PanelQuestion;
                panelQuestionBox.SetActive(true);
                panelQuestion.GetComponent<PanelQuestion>().SubjectNameForBuilding = subjectNameForBuilding;
                ResponseFromRequests.Remove("0x0000008");
            }
            //���� �������� ������� ���������� �� ����� ��� ��������
            if (spisokResponseFromRequests.Key == "0x0000009")
            {
                Debug.Log("0x0000009");
                //��������� ����� ��������
                GetAllInfoSlots();
                ResponseFromRequests.Remove("0x0000009");
            }
            Console.WriteLine($"key: {spisokResponseFromRequests.Key}  value: {spisokResponseFromRequests.Value}");
        }
    }
    public void AddInSlotSubject(string subjectName, string productionBuildingName, int ignoreQuestion)
    {
        Debug.Log(subjectName+ productionBuildingName+ ignoreQuestion);
        RestClient.Post<ResponseAddInSlotSubject>("http://45.84.226.98/api/production_building_execute_methods.php", new POSTAddInSlotSubject
        {
            jwt = Data.GetComponent<User>().GetJWTToken(),
            methodName = "AddInSlotSubject",
            subjectName = subjectName,
            productionBuildingName = productionBuildingName,
            ignoreQuestion = ignoreQuestion
        }).Then(response => {

            if (!ResponseFromRequests.ContainsKey(response.code))
            {
                ResponseFromRequests.Add(response.code, response.message);                
            }
            CheckResponseFromRequests(subjectName);
            //�������� ���������� � ������
            GetAllInfoSlots();
        });

    }

    [Serializable]
    public class LastIngredient
    {
        public string lastIngredients;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class RootLastIngredient
    {
        public List<LastIngredient> lastIngredients;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }

    private void OnEnable()
    {
        GetAllInfoSlots();
    }
    //�������� ��� ���������� � ������, �����������, �����������, ����������� � ������������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    void GetAllInfoSlots()
    {
        Array.Clear(SubjectsChildInTheProcessOfAssembly, 0, SubjectsChildInTheProcessOfAssembly.Length);
        Array.Clear(SubjectsChildInTheShipment, 0, SubjectsChildInTheShipment.Length);
        Debug.Log("GetAllInfoSlots()");
        //0 - ������ ������� � ������
        GetDifferenceDateInSeconds(SubjectName, 0);
        


        for (int i = 0; i <= MaxCountSlots; i++)
        {
            Debug.Log(i);
            //�������� �������, ����������� � ������������ ��� ������� ����� �� ������, �������������� ������������
            GetSubjectChildInTheProcessOfAssembly(SubjectName, i);
            GetSubjectChildInTheShipment(SubjectName, i);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //���� ������ �������
        if (TimerEnable)
        {
            //���� ������ �� �����
            if (TimeBeforeStartRequest > 0)
            {
                TimeBeforeStartRequest -= Time.deltaTime;
            }
            //���� ������ ����� 
            else
            {
                TimerEnable = false;
                Debug.Log("TimerEnable = false;");
                GetAllInfoSlots();
                //���� �������� ��������
                if (CheckGetSubjectChildInTheProcessOfAssembly)
                {
                    if (CheckInBuilding)
                    {
                        
                        //���� � ������������ ���� ��������
                    }
                    //���� � ������������ ��� ���������, ��������� �� �����������
                    else
                    {
                        //�������� ������� �� �������� ������� ������� �� ������������
                        //GetDifferenceDateInSeconds(SubjectName, 0);
                        CheckGetSubjectChildInTheProcessOfAssembly = false;
                        //for (int i = 0; i <= MaxCountSlots; i++)
                        //{
                        //Debug.Log(i);
                        //�������� �������, ����������� � ������������ ��� ������� ����� �� ������, �������������� ������������
                        //GetSubjectChildInTheProcessOfAssembly(SubjectName, i);
                        //}
                        GetAllInfoSlots();
                    }

                }
            }
        }
        else
        {

        }
        
    }

    //�������� ������� �� �������� ������� ������� �� ������������
    public void GetDifferenceDateInSeconds(string subjectParentName, int numberSlot)
    {
        Debug.Log("GetDifferenceDateInSeconds");
        RestClient.Post<ResponseGetDifferenceDateInSeconds>("http://45.84.226.98/api/production_building_execute_methods.php", new POSTGetDifferenceDateInSeconds
        {
            jwt = Data.GetComponent<User>().GetJWTToken(),
            methodName = "GetDifferenceDateInSeconds",
            subjectParentName = subjectParentName,
            numberSlot = numberSlot
        }).Then(response => {           
            //���� ���� �� ����������, ������ � ������������ ���� ��������
            if (response.expiredDate=="no")
            {
                TimerEnable = true;
                CheckInBuilding = true;
                //������������� ����� ��������� ��������
                CheckGetSubjectChildInTheProcessOfAssembly = false;
                //������ �� ���������� ������
                TimeBeforeStartRequest = response.differenceDateInSeconds;
                Debug.Log("TimeBeforeStartRequest" + TimeBeforeStartRequest);
            }
            //���� ���� ����������, ������ � ������������ ��� ���������
            if (response.expiredDate == "yes")
            {
                //TimerEnable = false; 03.05.2023 ���� false
                TimerEnable = false;
                CheckGetSubjectChildInTheProcessOfAssembly = false;
                CheckInBuilding = false;
            }
        });
    }

    public void GetAllCost(string subjectName)
    {
        Debug.Log("GetAllCost");
        AllCost = 0;
        RestClient.Post<ResponseGetAllCost>("http://45.84.226.98/api/production_building_execute_methods.php", new POSTGetAllCost
        {
            jwt = Data.GetComponent<User>().GetJWTToken(),
            methodName = "GetAllCost",
            subjectName = subjectName
        }).Then(response => {
            //gameObject.GetComponent<ProductionBuildingUI>().PanelFewResources.GetComponent<PanelFewResources>().AllCost = response.allCost;
            AllCost = response.allCost;
            Debug.Log("GetAllCostResponse"+response.allCost);
        });
    }
    public void GetTranslateInfoRUS(string subjectName)
    {
        RestClient.Post<ResponseGetTranslateInfoRU>("http://45.84.226.98/api/production_building_execute_methods.php", new POSTGetTranslateInfoRU
        {
            jwt = Data.GetComponent<User>().GetJWTToken(),
            methodName = "GetTranslateInfo",
            languageName = "RU",
            subjectName = subjectName
        }).Then(response => {
            ResponsesTranslateInfoRUS.Add(subjectName, new Translate(subjectName, response.nameRU, response.discriptionRU, response.timeBuildingRU));
            //TranslateName = response.nameRU;
            //TranslateDiscription = response.discriptionRU;
            //TranslateTimeBuilding = response.timeBuildingRU;
        });
    }

    public void Shipment(string subjectParentName)
    {
        RestClient.Post<ResponseShipment>("http://45.84.226.98/api/production_building_execute_methods.php", new POSTShipment
        {
            jwt = Data.GetComponent<User>().GetJWTToken(),
            methodName = "Shipment",
            subjectParentName = subjectParentName
        }).Then(response => {
            if (!ResponseFromRequests.ContainsKey(response.code))
            {
                ResponseFromRequests.Add(response.code, response.message);
            }
            CheckResponseFromRequests(subjectParentName);
        });
    }
    //SubjectChildInTheProcessOfAssembly
    //�������� �������, ����������� � ������������ ��� ������� ����� �� ������, �������������� ������������
    public void GetSubjectChildInTheProcessOfAssembly(string subjectParentName, int numberSlot)
    {
        RestClient.Post<ResponseSubjectChildInTheProcessOfAssembly>("http://45.84.226.98/api/production_building_execute_methods.php", new POSTSubjectChildInTheProcessOfAssembly
        {
            jwt = Data.GetComponent<User>().GetJWTToken(),
            methodName = "GetSubjectChildInTheProcessOfAssembly",
            subjectParentName = subjectParentName,
            numberSlot = numberSlot
        }).Then(response => {
            SubjectsChildInTheProcessOfAssembly[numberSlot] = response.subjectChildInTheProcessOfAssembly;
            Debug.Log("response.subjectChildInTheProcessOfAssembly" + response.subjectChildInTheProcessOfAssembly);
        });

    }
    //�������� �������� �������, ������� �������� ��������� �� ������, ������� ��� � ������������
    public void GetCheckIsLastSubject(string subjectName, string productionBuildingName)
    {
        RestClient.Post<RootLastIngredient>("http://45.84.226.98/api/production_building_execute_methods.php", new POSTGetLastIngredients
        {
            jwt = Data.GetComponent<User>().GetJWTToken(),
            methodName = "CheckIsLastSubject",
            subjectName = subjectName,
            productionBuildingName = productionBuildingName
        }).Then(response => {
            LastIngredients = response.lastIngredients;
            Debug.Log("response.lastIngredients" + response.lastIngredients);
        });

    }
    //�������� �������, ����������� � ���� �������� ��� ������� ����� �� ������, �������������� ������������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetSubjectChildInTheShipment(string subjectParentName, int numberSlot)
    {
        RestClient.Post<ResponseSubjectChildInTheShipment>("http://45.84.226.98/api/production_building_execute_methods.php", new POSTSubjectChildInTheShipment
        {
            jwt = Data.GetComponent<User>().GetJWTToken(),
            methodName = "GetSubjectChildInTheShipment",
            subjectParentName = subjectParentName,
            numberSlot = numberSlot
        }).Then(response => {
            SubjectsChildInTheShipment[numberSlot] = response.subjectChildInTheShipment;
            Debug.Log("response.subjectChildInTheShipment" + response.subjectChildInTheShipment);
        });

    }

    

}
