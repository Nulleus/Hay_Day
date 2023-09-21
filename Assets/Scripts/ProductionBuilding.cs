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

    //�������� �� ������ ��������, ������� ���������� ��� ������������ �������� � ��������� �� �� �����
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
            List<string> allQuery = new List<string>();
            Debug.Log("allQuery=" + allQuery);
            //��������, ������� � ������������ �������
            var ss = Data.GetComponent<SubjectSum>();
            int countsSubject = ss.GetSubjectSumCount("diamond", "Local");
            Debug.Log("countsSubject="+countsSubject);
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
                            foreach (var item in missingIngredients)
                            {
                                string query = ss.QueryIncreasingSubjectSumCount(item.ingredient_name, item.count_ingredients);
                                Debug.Log(query);
                                allQuery.Add(query);
                            }
                            string queryTwo = ss.QueryReducingSubjectSumCount("diamond", allCost);
                            allQuery.Add(queryTwo);
                            foreach (var item in allQuery)
                            {
                                Debug.Log(item);
                                SqliteCommand command = new SqliteCommand(item, connection, tra);
                                command.ExecuteNonQuery(); // 11
                            }
                            tra.Commit();
                            connection.Close();   
                            // Remember to always close the connection at the end.
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
                GetCheckIsLastSubject(subjectNameForBuilding, SubjectName, "Server");
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
    //���������� ������� � ���� ������������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void AddInSlotSubject(string subjectName, string productionBuildingName, int ignoreQuestion, string locationDataProcessing)
    {
        Debug.Log(subjectName+ productionBuildingName+ ignoreQuestion);
        if (locationDataProcessing == "Server")
        {
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
        if (locationDataProcessing == "Local")
        {
            IDictionary<string, int> allIngredients = new Dictionary<string, int>();
            //�������� ������� ���� �������(���� �������� �������)
            DateTime timeLoading = DateTime.Now;
            Debug.Log("timeLoading="+timeLoading);
            //���������� �������(���������� ��� ����������������� ������, �������� ���������� field1->field)
            AssociationSubject associationSubject = Data.GetComponent<AssociationSubject>();
            string subjectAssociation = associationSubject.GetAssociation(productionBuildingName);
            //���������� �������� ������ � ������������
            ProgresSlot progresSlot = Data.GetComponent<ProgresSlot>();
			int countOpenSlotsUser = progresSlot.GetOpenSlotsCount(productionBuildingName, locationDataProcessing);
            //��������� ��� ����������������� ������, ���������� ������� ������ ��������
            Content content = Data.GetComponent<Content>();
			int countOfOccupiedShipmentSlots = content.GetCountOfOccupiedLoadingSlotsByParentName(productionBuildingName, timeLoading);
            //���������,������� ������ ������ �������������
			int countOfOccupiedLoadingSlots = content.GetCountOfOccupiedLoadingSlotsByParentName(productionBuildingName, timeLoading);
            if (subjectAssociation == "field")
            {
                //���������, ���� �� � ������ field ��� ����������� �������� � ������������
            }
            //���� ���������� ����������� �������, ������ ��� �������� ������ � ������������
            if (countOfOccupiedShipmentSlots > countOpenSlotsUser) 
            {
                
                Debug.Log("code 0x0000001 message ������ ������� ���������, ����� ���������� ������������(����� �������� ��������� ������)");
            }
            //���� ���������� ����������� � ������������ ��������>=�������� � ������������
            if (countOfOccupiedLoadingSlots >= countOpenSlotsUser) 
            {
                Debug.Log("message ��� �����(��������) ������! �������, ������ ��� ������ ������!");
            }
            //���� ���������� ����������� ������(�������) � ������������ ��������<�������� ������ � ������������
            if (countOfOccupiedLoadingSlots < countOpenSlotsUser) 
            {
                //������� ��������� � ������������ ������
                //�������� ������ ������������ (����������, ����������)
                Ingredient ingredient = Data.GetComponent<Ingredient>();
                allIngredients = ingredient.GetAllIngredients(subjectName);
                //������� ������ ������������
                //�������� ������ ��������� � �� �����������, ������� ���������
                List<Ingredient.MissingIngredient> missingIngredients = ingredient.GetMissingIngredients(subjectName);
                if (missingIngredients.Count > 0) 
                {
                    //���������� ������ ��� ����������� ������������
                    //Show ������ ���� �������, ����� �� ����� ��������
                    gameObject.GetComponent<ProductionBuildingUI>().PanelFewResources.GetComponent<PanelFewResources>().Show();
                    gameObject.GetComponent<ProductionBuildingUI>().PanelFewResources.GetComponent<PanelFewResources>().CleanerPanel();

                    Debug.Log("code0x0000003 message ��������� ������������ ��� ������������!");

                    //����� ��������� �������� �� ������
                    PriceSubject priceSubject = Data.GetComponent<PriceSubject>();
                    Dictionary<string, int> temp = new Dictionary<string, int>();
                    foreach (var item in missingIngredients)
                    {
                        temp.Add(item.ingredient_name, item.count_ingredients);
                        gameObject.GetComponent<ProductionBuildingUI>().PanelFewResources.GetComponent<PanelFewResources>().AddSubjectAndCount(item.ingredient_name, item.count_ingredients);


                    }
                    int allCost = priceSubject.GetAllCost(ref temp);
                    Debug.Log("allCost=" + allCost);
                    gameObject.GetComponent<ProductionBuildingUI>().PanelFewResources.GetComponent<PanelFewResources>().SetAllCost(allCost);
                    
                    //���������� ���������� ���� ��������� ��������
                    return;
                }
            }
            //���� ������� ���������, ����� ��������� ��������� � ������������
            //(/���� ���������� ����������� ������(�������) � ������������ �������� < ����� ��������� �������� ������ ��������) � (���� ���������� ����������� ������ � ������������ �������� < �������� � ������������ )
            if ((countOfOccupiedShipmentSlots < countOpenSlotsUser) && (countOfOccupiedLoadingSlots < countOpenSlotsUser)) 
            {
                //���� ��� �� ����, ����� ���������, �������� �� ������ ���������� ��������� �� ������
                if (subjectAssociation != "field") 
                {
                    List<string> lastIngredients = new List<string>();
                    foreach (var item in allIngredients) 
                    {
                    //��������� ���������� ������������, �������� �� ������ ���������� ��������� �� ������, ���� ��������, ����� ������������� ������������, ������ ���� ��� �������� ��� ������
                    SubjectSum subjectSum = Data.GetComponent<SubjectSum>();
                    string queryCountCheck = subjectSum.QueryReducingSubjectSumCount(item.Key, item.Value);
                    //�������� ���������� �������������� �� ������
					int countCheck = subjectSum.GetSubjectSumCount(item.Key, "Local");
					//�������� ���������� ��������, ����������� � ������������/��������
					int countCheckInContent = content.GetCountAllSlotsBySubjectName(item.Key);
                    //����� ������ � ����������� ���������� ��� ����������� ������������
                        if ((countCheck - item.Value == 0) && (ignoreQuestion == 0) && (countCheckInContent == 0)) 
                        {
                            //����� ������ ���� ������ � ������������� ������� ����� �� ��������
                            lastIngredients.Add(item.Key);
                            GameObject panelQuestion = GetComponent<ProductionBuildingUI>().PanelQuestion;
                            panelQuestion.GetComponent<PanelQuestion>().CleanerPanel();
                            panelQuestion.GetComponent<PanelQuestion>().AddSubjectAndCount(item.Key, item.Value);
                            panelQuestion.GetComponent<PanelQuestion>().Show();
                            Debug.Log("code 0x0000008 �� ����������� ������������ ��������� ��������. ������ ����������?");

                            return;
                        }
                    }
                }
            }
            //������ �������� � ������������
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
            List<string> allQuery = new List<string>();
            var ss = Data.GetComponent<SubjectSum>();
            var bt = Data.GetComponent<BuildingTime>();
            var ct = Data.GetComponent<Content>();
            var oq = Data.GetComponent<OutputQuantity>();
            using (var connection = new SqliteConnection(dbUri))
            {
                connection.Open();
                using (var tra = connection.BeginTransaction())
                {
                    try
                    {
                        Debug.Log("Try");
                        foreach (var item in allIngredients)
                        {
                            string query = ss.QueryReducingSubjectSumCount(item.Key, item.Value);
                            Debug.Log(query);
                            allQuery.Add(query);
                        }
                        // Remember to always close the connection at the end.
                        string subjectParentName = productionBuildingName;
					    string subjectChildName = subjectName;
                        //�������� ����� ������������ ������� �� ������� building_time

					    int timeBuildingSubject = bt.GetTimeBuilding(subjectChildName, "Local");
                        //�������� ���� ��������, ���������� ��������, ������������ � �������� ������������
					    string dateShipmentEndBuildingSubject = ct.GetTimeShipmentDesc(productionBuildingName, timeLoading);
                        Debug.Log("dateShipmentEndBuildingSubject=" + dateShipmentEndBuildingSubject);
                        if (dateShipmentEndBuildingSubject=="null") 
                        {
                            //����� �������� �����: ����� �������� ���������� � ������� �������� + ����� �������� ��������
                            //���� �� ��������� � ���� if, ��� ������ ��� ����� �������� ���������� �������� ����� ������� ����
                            //������������ ������ � ���� � ��������� ���������� ������
                            DateTime timeShipment = timeLoading.AddSeconds(timeBuildingSubject);
                            int outputQuantityCount = oq.GetOutputQuantityBySubjectName(subjectChildName, "Local");
                            //DateTime convertTimeShipment = DateTime.ParseExact(timeShipment, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                            //DateTime convertTimeShipment = DateTime.ParseExact(dateShipmentEndBuildingSubject, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture.DateTimeFormat);
                            string query = ct.QueryAddContents(subjectParentName, subjectChildName, timeLoading, timeShipment, outputQuantityCount);
                            allQuery.Add(query);
                            Debug.Log(query);
                        } 
                        else
                        {
                            //����� �������� �����: ����� �������� ������� + ����� ��������
                            DateTime timeShipment = timeLoading;
                            timeShipment.AddSeconds(timeBuildingSubject);
                            Debug.Log("TimeShipment=" + timeShipment);
                            //���������� �������� �� ������
					        int outputQuantityCount = oq.GetOutputQuantityBySubjectName(subjectChildName, "Local");
					        string query = ct.QueryAddContents(subjectParentName, subjectChildName, timeLoading, timeShipment, outputQuantityCount);
                            Debug.Log(query);
                            allQuery.Add(query);
                        }

                        foreach (var item in allQuery)
                        {
                            Debug.Log(item);
                            SqliteCommand command = new SqliteCommand(item, connection, tra);
                            command.ExecuteNonQuery(); // 11
                        }
                        //��������� ������ � ���� ������
                        tra.Commit();
                        connection.Close();
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
    //�������� ��������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void Shipment(string subjectParentName, string locationDataProcessing)
    {
        if (locationDataProcessing == "Server")
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
        if (locationDataProcessing == "Local")
        {
            DateTime dateTimeNow = DateTime.Now;
            //�������� ID ������� �������� �� �������� �������
            var ct = Data.GetComponent<Content>();
            var ss = Data.GetComponent<SubjectSum>();
            int idContent = ct.GetShipmentID(subjectParentName, dateTimeNow);
            //��������� ���������� �������� �� ������ �� id_content
			int countOutputQuantity = ct.GetCountOutputQuantity(idContent);
            //�������� ��� ������������ �������
            List<string> allQuery = new List<string>();
            string subjectChildName = ct.GetSubjectName(idContent);
            string dbName = "MyDatabase.sqlite";
            string dbUri = "URI=file:" + Application.persistentDataPath + "/" + dbName + ".db";  // 4
            using (var connection = new SqliteConnection(dbUri))
            {
                connection.Open();
                using (var tra = connection.BeginTransaction())
                {
                    try
                    {
                        //�������� ������ � ��������� id ��������
                        
				        string queryOne = ct.QueryDeleteContent(idContent);
                        allQuery.Add(queryOne);
                        Debug.Log("Try");
                        //���������� ��������� ������� � ���������(subject_sum)
				        string queryTwo = ss.QueryIncreasingSubjectSumCount(subjectChildName, countOutputQuantity);
                        allQuery.Add(queryTwo);
                        foreach (var item in allQuery)
                        {
                            Debug.Log(item);
                            SqliteCommand command = new SqliteCommand(item, connection, tra);
                            command.ExecuteNonQuery(); // 11
                        }
                        tra.Commit();
                        Debug.Log("code 0x0000009 �������� ������� ���������� �� �����!");
                        connection.Close();
                        // Remember to always close the connection at the end.
                    }
                    catch (Exception ex)
                    {
                        //���������� ���������
                        tra.Rollback();
                        Debug.Log("������� ����������� ��������!");
                        throw;
                    }
                }
            }
        }
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
    //���������, ��������� �� ����������, ��� field ���������� ������������� 
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public bool GetCheckIsLastSubject(string subjectName, string productionBuildingName, string locationDataProcessing)
    {
        if (locationDataProcessing == "Server")
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
        if (locationDataProcessing == "Local")
        {
            //���������� �������(���������� ��� ����������������� ������, �������� ���������� field1->field)
            var aSubject = Data.GetComponent<AssociationSubject>();
            string subjectAssociation = aSubject.GetAssociation(productionBuildingName);
            //�������� ������ ������������ (����������, ����������)
            var ingredient = Data.GetComponent<Ingredient>();
            var ss = Data.GetComponent<SubjectSum>();
            var content = Data.GetComponent<Content>();
            IDictionary<string, int> allIngredients = new Dictionary<string, int>();
            allIngredients = ingredient.GetAllIngredients(subjectName);
            Debug.Log(allIngredients);
            //���� ���������������� ������ �� �������� �����
            if (subjectAssociation != "field") {
                foreach (var item in allIngredients) {
                    //��������� ���������� ������������, �������� �� ������ ���������� ��������� �� ������, ���� ��������, ����� ������������� ������������, ������ ���� ��� �������� ��� ������
				    string queryCountCheck = ss.QueryReducingSubjectSumCount(item.Key,item.Value);
                    Debug.Log("queryCountCheck=" + queryCountCheck);
                    //�������� ���������� ������������ �� ������
				    int countCheck = ss.GetSubjectSumCount(item.Key, "Local");
                    Debug.Log("countCheck=" + countCheck);
                    //�������� ���������� ��������, ����������� � ������������/��������
                    int countCheckInContent = content.GetCountAllSlotsBySubjectName(subjectName);
                    Debug.Log("countCheckInContent=" + countCheckInContent);
                    //����� ������ � ����������� ���������� ��� ����������� ������������
                    if ((countCheck - item.Value <= 0) && (countCheckInContent <= 0)) {
                        Debug.Log("if ((countCheck - item.Value == 0) && (countCheckInContent == 0))=");
                        //����� ������ ���� ������ � ������������� ������� ����� �� ��������
                        List<string> lastIngredients = new List<string>();
				        lastIngredients.Add(item.Key);
                        if (lastIngredients.Count > 0)
                        {
                            Debug.Log(lastIngredients);
                            return true;
                        }                       
                    }
                }
                return false;
            }
            return false;
        }
        return false;
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
