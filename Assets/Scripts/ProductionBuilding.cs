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
    public GameObject Data;
    [ShowInInspector]
    public string SubjectName;
    public GameObject Lines;
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
    [ShowInInspector]
    //���� ���������� ������� ���������� ������ ������������
    public float TimeBeforeStartRequest;
    public bool CheckInBuilding;
    public bool TimerEnable;

    public GameObject ExperiencePoint;
    public GameObject ExperiencePointUILevelText;

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
        Debug.Log("BuySubjectForDiamond(" + subjectName + "," + locationDataProcessing+");");
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
                            Debug.Log("Catch: "+ex);
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
        Debug.Log("AddInSlotSubject=" + subjectName + productionBuildingName+ ignoreQuestion+locationDataProcessing);
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
            long timeLoading = GetDateTimeNow();
            Debug.Log("timeLoading="+timeLoading);
            //���������� �������(���������� ��� ����������������� ������, �������� ���������� field1->field)
            AssociationSubject associationSubject = Data.GetComponent<AssociationSubject>();
            Debug.Log("associationSubject=" + associationSubject);
            string subjectAssociation = associationSubject.GetAssociation(productionBuildingName);
            Debug.Log("subjectAssociation=" + subjectAssociation);
            //���������� �������� ������ � ������������
            ProgresSlot progresSlot = Data.GetComponent<ProgresSlot>();
            Debug.Log("progresSlot=" + progresSlot);
			int countOpenSlotsUser = progresSlot.GetOpenSlotsCount(productionBuildingName, locationDataProcessing);
            Debug.Log("countOpenSlotsUser=" + countOpenSlotsUser);
            //��������� ��� ����������������� ������, ���������� ������� ������ ��������
            Content content = Data.GetComponent<Content>();
            //���������,������� ������ ������ ���������
            int countOfOccupiedShipmentSlots = content.GetCountOfOccupiedLoadingSlotsByParentName(productionBuildingName, timeLoading);
            Debug.Log("countOfOccupiedShipmentSlots=" + countOfOccupiedShipmentSlots);
            //���������,������� ������ ������ �������������
			int countOfOccupiedLoadingSlots = content.GetCountOfOccupiedLoadingSlotsByParentName(productionBuildingName, timeLoading);
            Debug.Log("countOfOccupiedLoadingSlots=" + countOfOccupiedLoadingSlots);
            if (subjectAssociation == "field")
            {
                //���������, ���� �� � ������ field ��� ����������� �������� � ������������
            }
            //���� ���������� ����������� �������, ������ ��� �������� ������ � ������������
            if (countOfOccupiedShipmentSlots > countOpenSlotsUser) 
            {
                gameObject.GetComponent<ProductionBuildingUI>().MessageUIBox.GetComponent<MessageUI>().ShowMessage("������ ������� ���������, ����� ���������� ������������(����� �������� ��������� ������)");
                Debug.Log("code 0x0000001 message ������ ������� ���������, ����� ���������� ������������(����� �������� ��������� ������)");
                return;
            }
            //���� ���������� ����������� � ������������ ��������>=�������� � ������������
            if (countOfOccupiedLoadingSlots >= countOpenSlotsUser) 
            {
                gameObject.GetComponent<ProductionBuildingUI>().MessageUIBox.GetComponent<MessageUI>().ShowMessage("��� �����(��������) ������! �������, ������ ��� ������ ������!");
                Debug.Log("message ��� �����(��������) ������! �������, ������ ��� ������ ������!");
                return;
                
            }
            //���� ���������� ����������� ������(�������) � ������������ ��������<�������� ������ � ������������
            if (countOfOccupiedLoadingSlots < countOpenSlotsUser) 
            {
                Debug.Log("if (countOfOccupiedLoadingSlots < countOpenSlotsUser)");
                //������� ��������� � ������������ ������
                //�������� ������ ������������ (����������, ����������)
                Ingredient ingredient = Data.GetComponent<Ingredient>();
                allIngredients = ingredient.GetAllIngredients(subjectName);
                Debug.Log("allIngredients" + allIngredients);
                //������� ������ ������������
                //�������� ������ ��������� � �� �����������, ������� ���������
                List<Ingredient.MissingIngredient> missingIngredients = ingredient.GetMissingIngredients(subjectName);
                Debug.Log("missingIngredients=" + missingIngredients);
                Debug.Log("missingIngredients.Count=" + missingIngredients.Count);
                if ((missingIngredients.Count > 0) && (ignoreQuestion == 0))
                {
                    Debug.Log("if (missingIngredients.Count > 0) ");
                    //���������� ������ ��� ����������� ������������
                    //Show ������ ���� �������, ����� �� ����� ��������
                    gameObject.GetComponent<ProductionBuildingUI>().PanelFewResources.GetComponent<PanelFewResources>().Show();
                    gameObject.GetComponent<ProductionBuildingUI>().PanelFewResources.GetComponent<PanelFewResources>().CleanerPanel();
                    gameObject.GetComponent<ProductionBuildingUI>().PanelFewResources.GetComponent<PanelFewResources>().SubjectNameForBuilding = subjectName;
                    gameObject.GetComponent<ProductionBuildingUI>().PanelFewResources.GetComponent<PanelFewResources>().SetUserActionSelection("buyForDaemonds");
                    

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
                Debug.Log("if ((countOfOccupiedShipmentSlots < countOpenSlotsUser) && (countOfOccupiedLoadingSlots < countOpenSlotsUser))");
                //���� ��� �� ����, ����� ���������, �������� �� ������ ���������� ��������� �� ������
                if (subjectAssociation != "field") 
                {
                    Debug.Log("if (subjectAssociation != field) ");
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
                            Debug.Log("code 0x0000008 �� ����������� ������������ ��������� ��������. ������ ����������?");
                            //����� ������ ���� ������ � ������������� ������� ����� �� ��������
                            lastIngredients.Add(item.Key);
                            GameObject panelQuestion = GetComponent<ProductionBuildingUI>().PanelQuestion;
                            panelQuestion.GetComponent<PanelQuestion>().Show();
                            panelQuestion.GetComponent<PanelQuestion>().CleanerPanel();
                            panelQuestion.GetComponent<PanelQuestion>().AddSubjectAndCount(item.Key, item.Value);
                            panelQuestion.GetComponent<PanelQuestion>().SubjectNameForBuilding = subjectName;
                            return;
                        }
                    }
                }
            }
            //������ �������� � ������������
            Debug.Log("������ �������� � ������������");
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
					    long dateShipmentEndBuildingSubject = ct.GetTimeShipmentDesc(productionBuildingName, timeLoading);
                        Debug.Log("dateShipmentEndBuildingSubject=" + dateShipmentEndBuildingSubject);
                        if (dateShipmentEndBuildingSubject==0) 
                        {
                            //����� �������� �����: ����� �������� ���������� � ������� �������� + ����� �������� ��������
                            //���� �� ��������� � ���� if, ��� ������ ��� ����� �������� ���������� �������� ����� ������� ����
                            long timeShipment = timeLoading+timeBuildingSubject;
                            Debug.Log("timeShipment=" + timeShipment);
                            int outputQuantityCount = oq.GetOutputQuantityBySubjectName(subjectChildName, "Local");
                            Debug.Log("outputQuantityCount=" + outputQuantityCount);
                            //DateTime convertTimeShipment = DateTime.ParseExact(timeShipment, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                            //DateTime convertTimeShipment = DateTime.ParseExact(dateShipmentEndBuildingSubject, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture.DateTimeFormat);
                            string query = ct.QueryAddContents(subjectParentName, subjectChildName, timeLoading, timeShipment, outputQuantityCount);
                            allQuery.Add(query);
                            Debug.Log(query);
                        } 
                        else
                        {
                            //����� �������� �����: ����� �������� ������� + ����� ��������
                            long timeShipment = dateShipmentEndBuildingSubject+timeBuildingSubject;
                            Debug.Log("TimeShipment=" + timeShipment);
                            //���������� �������� �� ������
					        int outputQuantityCount = oq.GetOutputQuantityBySubjectName(subjectChildName, "Local");
                            Debug.Log("outputQuantityCount=" + outputQuantityCount);
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
                        Debug.Log("������� ��������� �������");
                        connection.Close();
                        GetAllInfoSlots();
                    }
                    catch (Exception ex)
                    {
                        //���������� ���������
                        tra.Rollback();
                        Debug.Log("Catch: "+ex);
                        throw;
                    }
                }
            }
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
            Debug.Log("for (int i = 0; i <= MaxCountSlots; i++)" + i);
            //�������� �������, ����������� � ������������ ��� ������� ����� �� ������, �������������� ������������
            GetSubjectChildInTheProcessOfAssembly(SubjectName, i);
        }
        for (int i = 0; i <= MaxCountSlots; i++)
        {
            Debug.Log("for (int i = 0; i <= MaxCountSlots; i++)" +i);
            //�������� �������, ����������� � ������������ ��� ������� ����� �� ������, �������������� ������������

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
                if (TimeBeforeStartRequest >= 0)
                {
                    TimeBeforeStartRequest -= Time.deltaTime;
                }
                //���� ������ ����� 
                else
                {
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
                            CheckGetSubjectChildInTheProcessOfAssembly = false;
                        }
                    }
                }
            }
    }

    //�������� ������� � �������� ���: 1) ���������� � ������������ �������� 2) �������� �������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetDifferenceDateInSeconds(string subjectParentName, int numberSlot)
    {
        long dateTimeNow = GetDateTimeNow();
        //Debug.Log("dateTimeNow=" + dateTimeNow);
        //2+ ����� ��� �������������, ����� �������� ������ ����� ���� ��� ������ ������, ����� ������ �� �������� ��� �� ����� ��������� � ����� �����
        long dateShipment = 2+Data.GetComponent<Content>().GetTimeShipmentFirst(subjectParentName, dateTimeNow);
        //Debug.Log("dateShipment=" + dateShipment);
        var diff = dateShipment - dateTimeNow;
        //Debug.Log(diff);
        //���������� �� ����, ���� ���� ����������, ����� ������� ����� �������������
        if ((dateShipment >= dateTimeNow)&&(dateShipment != 0)){
            //Debug.Log("���� �� ����������");
            //���� �� ����������
            TimerEnable = true;
            CheckInBuilding = true;
            //������������� ����� ��������� ��������
            CheckGetSubjectChildInTheProcessOfAssembly = false;
            //������ �� ���������� ������
            TimeBeforeStartRequest = Convert.ToSingle(diff);
            //Debug.Log("TimeBeforeStartRequest" + TimeBeforeStartRequest);
        }
            //� ������������ �����
        else
        {
            //Debug.Log("���� ����������");
            TimerEnable = false;
            CheckGetSubjectChildInTheProcessOfAssembly = false;
            CheckInBuilding = false;

        }

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
            long dateTimeNow = GetDateTimeNow();
            //�������� ID ������� �������� �� �������� �������
            int idContent = Data.GetComponent<Content>().GetShipmentID(subjectParentName, dateTimeNow);
            //��������� ���������� �������� �� ������ �� id_content
			int countOutputQuantity = Data.GetComponent<Content>().GetCountOutputQuantity(idContent);
            //�������� ��� ������������ �������
            List<string> allQuery = new List<string>();
            string subjectChildName = Data.GetComponent<Content>().GetSubjectName(idContent);
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
                        //Debug.Log("Try");
                        string queryOne = Data.GetComponent<Content>().QueryDeleteContent(idContent);
                        allQuery.Add(queryOne);                 
                        //���������� ��������� ������� � ���������(subject_sum)
				        string queryTwo = Data.GetComponent<SubjectSum>().QueryIncreasingSubjectSumCount(subjectChildName, countOutputQuantity);
                        allQuery.Add(queryTwo);
                        //���������� ����� �� �������
                        int experiencePointsCount = Data.GetComponent<ExperiencePoint>().GetExperiencePoints(subjectChildName, "ingathering", "Local");
                        //Debug.Log("experiencePointsCount="+experiencePointsCount);
                        //���������� ������� � ���������(experiencePoint)
                        string queryThree = Data.GetComponent<SubjectSum>().QueryIncreasingSubjectSumCount("experiencePoint", experiencePointsCount);
                        allQuery.Add(queryThree);
                        if (subjectChildName != "Error")
                        {
                            Lines.GetComponent<CloneObjectLines>().Clone(subjectChildName, countOutputQuantity);
                            //�������� ����� �����
                            Lines.GetComponent<CloneObjectLines>().Clone("experience", experiencePointsCount);
                        }                      
                        //��� ����� �������� ���������� ����� �����
                        foreach (var item in allQuery)
                        {
                            Debug.Log(item);
                            SqliteCommand command = new SqliteCommand(item, connection, tra);
                            command.ExecuteNonQuery(); // 11
                        }
                        tra.Commit();
                        Debug.Log("code 0x0000009 �������� ������� ���������� �� �����!");
                        connection.Close();
                        GetAllInfoSlots();
                        //��������� ���������� �����
                        ExperiencePoint.GetComponent<ExperiencePointUI>().ShowFillExperiencePointUI();
                        ExperiencePointUILevelText.GetComponent<ShowValue>().ShowTextPro();
                        // Remember to always close the connection at the end.
                    }
                    catch (Exception ex)
                    {
                        //���������� ���������
                        tra.Rollback();
                        connection.Close();
                        Debug.Log("������� ����������� ��������! ������: "+ex);
                        throw;
                    }
                }
            }
        }
    }
    //�������� �������, ����������� � ������������ ��� ������� ����� �� ������, �������������� ������������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetSubjectChildInTheProcessOfAssembly(string subjectParentName, int numberSlot)
    {
        //Debug.Log("GetSubjectChildInTheProcessOfAssembly(" + subjectParentName + "," + numberSlot+");");
        long dateTimeNow = GetDateTimeNow();       
        string subjectChildInTheProcessOfAssembly = Data.GetComponent<Content>().GetSubjectChildInTheProcessOfAssembly(subjectParentName, numberSlot, dateTimeNow);
        //Debug.Log("GetSubjectChildInTheProcessOfAssembly|" + "dateTimeNow=" + dateTimeNow + ",subjectChildInTheProcessOfAssembly=" + subjectChildInTheProcessOfAssembly);
        SubjectsChildInTheProcessOfAssembly[numberSlot] = subjectChildInTheProcessOfAssembly;
    }
    //���������, ��������� �� ����������, ��� field ���������� ������������ 
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public bool GetCheckIsLastSubject(string subjectName, string productionBuildingName, string locationDataProcessing)
    {
        if (locationDataProcessing == "Local")
        {
            //���������� �������(���������� ��� ����������������� ������, �������� ���������� field1->field)
            string subjectAssociation = Data.GetComponent<AssociationSubject>().GetAssociation(productionBuildingName);
            //�������� ������ ������������ (����������, ����������)
            IDictionary<string, int> allIngredients = new Dictionary<string, int>();
            allIngredients = Data.GetComponent<Ingredient>().GetAllIngredients(subjectName);
            //Debug.Log(allIngredients);
            //���� ���������������� ������ �� �������� �����
            if (subjectAssociation != "field") {
                foreach (var item in allIngredients) {
                    //��������� ���������� ������������, �������� �� ������ ���������� ��������� �� ������, ���� ��������, ����� ������������� ������������, ������ ���� ��� �������� ��� ������
				    string queryCountCheck = Data.GetComponent<SubjectSum>().QueryReducingSubjectSumCount(item.Key,item.Value);
                    //Debug.Log("queryCountCheck=" + queryCountCheck);
                    //�������� ���������� ������������ �� ������
				    int countCheck = Data.GetComponent<SubjectSum>().GetSubjectSumCount(item.Key, "Local");
                    //Debug.Log("countCheck=" + countCheck);
                    //�������� ���������� ��������, ����������� � ������������/��������
                    int countCheckInContent = Data.GetComponent<Content>().GetCountAllSlotsBySubjectName(subjectName);
                    //Debug.Log("countCheckInContent=" + countCheckInContent);
                    //����� ������ � ����������� ���������� ��� ����������� ������������
                    if ((countCheck - item.Value <= 0) && (countCheckInContent <= 0)) {
                        //Debug.Log("if ((countCheck - item.Value == 0) && (countCheckInContent == 0))=");
                        //����� ������ ���� ������ � ������������� ������� ����� �� ��������
                        List<string> lastIngredients = new List<string>();
				        lastIngredients.Add(item.Key);
                        if (lastIngredients.Count > 0)
                        {
                            //Debug.Log(lastIngredients);
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
        
        long dateTimeNow = GetDateTimeNow();
        //Debug.Log("GetGetSubjectChildInTheShipment=" + subjectParentName + ",dateTimeNow=" + dateTimeNow + "numberSlot=" + numberSlot + ")");
        var c = Data.GetComponent<Content>();
        string subjectChildInTheShipment = c.GetSubjectChildInTheShipment(subjectParentName, numberSlot, dateTimeNow);
        //Debug.Log("subjectChildInTheShipment="+ subjectChildInTheShipment);
        SubjectsChildInTheShipment[numberSlot] = subjectChildInTheShipment;
    }
    public long GetDateTimeNow()
    {
        //����� � ������� timestamp
        var dateTimeNow = ((int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
        //Debug.Log("dateTimeNow:" + dateTimeNow);
        return dateTimeNow;
    }
}
