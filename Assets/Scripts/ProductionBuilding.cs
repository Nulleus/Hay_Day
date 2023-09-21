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
    //Имя находящегося в производстве предмета
    public string[] SubjectsChildInTheProcessOfAssembly = new string[10];
    //Имя находящегося в зоне отгрузки предмета
    public string[] SubjectsChildInTheShipment = new string[10];
    //Общая стоимость предметов за алмазы
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
    //Дата следующего запуска обновления слотов производства
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

    //Покупаем за алмазы предметы, которые необходимы для производства предмета и добавляем их на склад
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
            //Получаем массив предметов с их количеством, которых нехватает
            var i = Data.GetComponent<Ingredient>();
            List<Ingredient.MissingIngredient> missingIngredients = i.GetMissingIngredients(subjectName);
            Debug.Log(missingIngredients);
            Dictionary<string, int> massive = new Dictionary<string, int>();
            foreach (var item in missingIngredients)
            {
                massive.Add(item.ingredient_name, item.count_ingredients);
            }
            //Общая стоимость объектов за алмазы
            var ps = Data.GetComponent<PriceSubject>();
            int allCost = ps.GetAllCost(ref massive);
            Debug.Log("allCost="+allCost);
            List<string> allQuery = new List<string>();
            Debug.Log("allQuery=" + allQuery);
            //Получаем, сколько у пользователя алмазов
            var ss = Data.GetComponent<SubjectSum>();
            int countsSubject = ss.GetSubjectSumCount("diamond", "Local");
            Debug.Log("countsSubject="+countsSubject);
            //Если предметов(алмазы) достаточно
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
                            //Откатываем изменения
                            tra.Rollback();
                            Debug.Log("Catch!");
                            throw;
                        }
                    }
                }
            }
            if (countsSubject < allCost) {
                //Нехватает количества объектов (алмазов) в таблице subjects_sum
                //Если нехватает
                Debug.Log("Нехватает количества объектов (алмазов) в таблице subjects_sum");                            
            }
        }
    }
    //Проверяем ответ от сервера
    public void CheckResponseFromRequests(string subjectNameForBuilding)
    {
        Debug.Log("CheckResponseFromRequests");
        foreach (var spisokResponseFromRequests in ResponseFromRequests)
        {
            //Если запросы выполнены успешно
            if (spisokResponseFromRequests.Key == "0x0000004")
            {
                Debug.Log("0x0000004");
                //Обновляем слоты отгрузки
                GetAllInfoSlots();
                ResponseFromRequests.Remove("0x0000004");
            }
            
            //если предметы культур, которые остались последние на складе, которые нет в производстве
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
            //Если предметы успешно перемешены на склад при отгрузке
            if (spisokResponseFromRequests.Key == "0x0000009")
            {
                Debug.Log("0x0000009");
                //Обновляем слоты отгрузки
                GetAllInfoSlots();
                ResponseFromRequests.Remove("0x0000009");
            }
            Console.WriteLine($"key: {spisokResponseFromRequests.Key}  value: {spisokResponseFromRequests.Value}");
        }
    }
    //Добавление объекта в слот производства
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
                //Получаем информацию о слотах
                GetAllInfoSlots();
            });
        }
        if (locationDataProcessing == "Local")
        {
            IDictionary<string, int> allIngredients = new Dictionary<string, int>();
            //Получаем текущую дату клиента(дата загрузки объекта)
            DateTime timeLoading = DateTime.Now;
            Debug.Log("timeLoading="+timeLoading);
            //Ассоциация объекта(Отправляем имя производственного здания, получаем ассоциацию field1->field)
            AssociationSubject associationSubject = Data.GetComponent<AssociationSubject>();
            string subjectAssociation = associationSubject.GetAssociation(productionBuildingName);
            //Количество открытых слотов у пользователя
            ProgresSlot progresSlot = Data.GetComponent<ProgresSlot>();
			int countOpenSlotsUser = progresSlot.GetOpenSlotsCount(productionBuildingName, locationDataProcessing);
            //Требуется имя производственного здания, количество занятых слотов отгрузки
            Content content = Data.GetComponent<Content>();
			int countOfOccupiedShipmentSlots = content.GetCountOfOccupiedLoadingSlotsByParentName(productionBuildingName, timeLoading);
            //Проверяем,сколько слотов занято производством
			int countOfOccupiedLoadingSlots = content.GetCountOfOccupiedLoadingSlotsByParentName(productionBuildingName, timeLoading);
            if (subjectAssociation == "field")
            {
                //Проверяем, есть ли в данном field уже загруженная культура в производство
            }
            //Если количество отгруженных товаров, больше чем открытых слотов у пользователя
            if (countOfOccupiedShipmentSlots > countOpenSlotsUser) 
            {
                
                Debug.Log("code 0x0000001 message Собери готовую продукцию, чтобы продолжить изготовление(слоты отгрузки полностью заняты)");
            }
            //Если количество загруженных в производство объектов>=открытых у пользователя
            if (countOfOccupiedLoadingSlots >= countOpenSlotsUser) 
            {
                Debug.Log("message Все слоты(загрузки) заняты! Подожди, ускорь или докупи ячейки!");
            }
            //Если количество загруженных слотов(занятых) в производство объектов<открытых слотов у пользователя
            if (countOfOccupiedLoadingSlots < countOpenSlotsUser) 
            {
                //Пробуем запустить в производство объект
                //Получаем список ингредиентов (ингредиент, количество)
                Ingredient ingredient = Data.GetComponent<Ingredient>();
                allIngredients = ingredient.GetAllIngredients(subjectName);
                //Выводим список ингредиентов
                //Получаем массив предметов с их количеством, которых нехватает
                List<Ingredient.MissingIngredient> missingIngredients = ingredient.GetMissingIngredients(subjectName);
                if (missingIngredients.Count > 0) 
                {
                    //Подготовим панель для нехватающих ингредиентов
                    //Show должен быть вначале, иначе не будет работать
                    gameObject.GetComponent<ProductionBuildingUI>().PanelFewResources.GetComponent<PanelFewResources>().Show();
                    gameObject.GetComponent<ProductionBuildingUI>().PanelFewResources.GetComponent<PanelFewResources>().CleanerPanel();

                    Debug.Log("code0x0000003 message Нехватает ингредиентов для производства!");

                    //Общая стоимость объектов за алмазы
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
                    
                    //Остановить выполнение если нехватает объектов
                    return;
                }
            }
            //Если условия совпадают, можно пробовать запускать в производство
            //(/Если количество загруженных слотов(занятых) в производство объектов < число дефолтных значений слотов отгрузки) И (Если количество загруженных слотов в производство объектов < открытых у пользователя )
            if ((countOfOccupiedShipmentSlots < countOpenSlotsUser) && (countOfOccupiedLoadingSlots < countOpenSlotsUser)) 
            {
                //Если это не поле, тогда проверяем, является ли данный ингредиент последним на складе
                if (subjectAssociation != "field") 
                {
                    List<string> lastIngredients = new List<string>();
                    foreach (var item in allIngredients) 
                    {
                    //Проверяем количество ингредиентов, является ли данный ингредиент последним на складе, если является, тогда предупреждаем пользователя, только если это культура для посева
                    SubjectSum subjectSum = Data.GetComponent<SubjectSum>();
                    string queryCountCheck = subjectSum.QueryReducingSubjectSumCount(item.Key, item.Value);
                    //Получаем количество ингредиснентов на складе
					int countCheck = subjectSum.GetSubjectSumCount(item.Key, "Local");
					//Получаем количество объектов, находящихся в производстве/отгрузке
					int countCheckInContent = content.GetCountAllSlotsBySubjectName(item.Key);
                    //Нужен массив с несколькими предметами для отображения пользователю
                        if ((countCheck - item.Value == 0) && (ignoreQuestion == 0) && (countCheckInContent == 0)) 
                        {
                            //Здесь должен быть массив с ингредиентами которых почти не осталось
                            lastIngredients.Add(item.Key);
                            GameObject panelQuestion = GetComponent<ProductionBuildingUI>().PanelQuestion;
                            panelQuestion.GetComponent<PanelQuestion>().CleanerPanel();
                            panelQuestion.GetComponent<PanelQuestion>().AddSubjectAndCount(item.Key, item.Value);
                            panelQuestion.GetComponent<PanelQuestion>().Show();
                            Debug.Log("code 0x0000008 Ты собираешься использовать последние растения. Хочешь продолжить?");

                            return;
                        }
                    }
                }
            }
            //Начало загрузки в производство
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
                        //Получаем время производства объекта из таблицы building_time

					    int timeBuildingSubject = bt.GetTimeBuilding(subjectChildName, "Local");
                        //Получаем дату выгрузки, последнего предмета, находящегося в процессе изготовления
					    string dateShipmentEndBuildingSubject = ct.GetTimeShipmentDesc(productionBuildingName, timeLoading);
                        Debug.Log("dateShipmentEndBuildingSubject=" + dateShipmentEndBuildingSubject);
                        if (dateShipmentEndBuildingSubject=="null") 
                        {
                            //Время отгрузки равно: время отгрузки последнего в очереди предмета + время создания предмета
                            //Если мы находится в этом if, это значит что время отгрузки последнего предмета равна текущей дате
                            //Конвертируем строку в дату и добавляем количество секунд
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
                            //Время отгрузки равно: время создания объекта + время загрузки
                            DateTime timeShipment = timeLoading;
                            timeShipment.AddSeconds(timeBuildingSubject);
                            Debug.Log("TimeShipment=" + timeShipment);
                            //Количество объектов на выходе
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
                        //Выполняем коммит в базу данных
                        tra.Commit();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        //Откатываем изменения
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
    //Получаем всю информацию о слотах, загруженных, отгруженных, находящихся в производстве
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    void GetAllInfoSlots()
    {
        Array.Clear(SubjectsChildInTheProcessOfAssembly, 0, SubjectsChildInTheProcessOfAssembly.Length);
        Array.Clear(SubjectsChildInTheShipment, 0, SubjectsChildInTheShipment.Length);
        Debug.Log("GetAllInfoSlots()");
        //0 - первый элемент в списке
        GetDifferenceDateInSeconds(SubjectName, 0);
        for (int i = 0; i <= MaxCountSlots; i++)
        {
            Debug.Log(i);
            //Получаем продукт, находящийся в производстве для каждого слота по номеру, идентификатору пользователя
            GetSubjectChildInTheProcessOfAssembly(SubjectName, i);
            GetSubjectChildInTheShipment(SubjectName, i);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Если таймер включен
        if (TimerEnable)
        {
            //Если таймер не истек
            if (TimeBeforeStartRequest > 0)
            {
                TimeBeforeStartRequest -= Time.deltaTime;
            }
            //Если таймер истек 
            else
            {
                TimerEnable = false;
                Debug.Log("TimerEnable = false;");
                GetAllInfoSlots();
                //Если проверка включена
                if (CheckGetSubjectChildInTheProcessOfAssembly)
                {
                    if (CheckInBuilding)
                    {
                        
                        //Если в производстве есть предметы
                    }
                    //Если в производстве нет предметов, проверять не обязательно
                    else
                    {
                        //Получаем секунды до выгрузки первого объекта из производства
                        //GetDifferenceDateInSeconds(SubjectName, 0);
                        CheckGetSubjectChildInTheProcessOfAssembly = false;
                        //for (int i = 0; i <= MaxCountSlots; i++)
                        //{
                        //Debug.Log(i);
                        //Получаем продукт, находящийся в производстве для каждого слота по номеру, идентификатору пользователя
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

    //Получаем секунды до выгрузки первого объекта из производства
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
            //Если дата не просрочена, значит в производстве есть предметы
            if (response.expiredDate=="no")
            {
                TimerEnable = true;
                CheckInBuilding = true;
                //Останавливаем после получения значения
                CheckGetSubjectChildInTheProcessOfAssembly = false;
                //Секунд до обновления слотов
                TimeBeforeStartRequest = response.differenceDateInSeconds;
                Debug.Log("TimeBeforeStartRequest" + TimeBeforeStartRequest);
            }
            //Если дата просрочена, значит в производстве нет предметов
            if (response.expiredDate == "yes")
            {
                //TimerEnable = false; 03.05.2023 стал false
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
    //Выгрузка объектов
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
            //Получаем ID первого стоящего на отгрузку объекта
            var ct = Data.GetComponent<Content>();
            var ss = Data.GetComponent<SubjectSum>();
            int idContent = ct.GetShipmentID(subjectParentName, dateTimeNow);
            //Получение количества объектов на выходе по id_content
			int countOutputQuantity = ct.GetCountOutputQuantity(idContent);
            //Получаем имя выгружаемого объекта
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
                        //удаление строки с указанным id контента
                        
				        string queryOne = ct.QueryDeleteContent(idContent);
                        allQuery.Add(queryOne);
                        Debug.Log("Try");
                        //Прибавляем удаленный контент в хранилище(subject_sum)
				        string queryTwo = ss.QueryIncreasingSubjectSumCount(subjectChildName, countOutputQuantity);
                        allQuery.Add(queryTwo);
                        foreach (var item in allQuery)
                        {
                            Debug.Log(item);
                            SqliteCommand command = new SqliteCommand(item, connection, tra);
                            command.ExecuteNonQuery(); // 11
                        }
                        tra.Commit();
                        Debug.Log("code 0x0000009 Предметы успешно перемещены на склад!");
                        connection.Close();
                        // Remember to always close the connection at the end.
                    }
                    catch (Exception ex)
                    {
                        //Откатываем изменения
                        tra.Rollback();
                        Debug.Log("Запросы завершились неудачно!");
                        throw;
                    }
                }
            }
        }
    }
    //SubjectChildInTheProcessOfAssembly
    //Получаем продукт, находящийся в производстве для каждого слота по номеру, идентификатору пользователя
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
    //Проверяем, последний ли ингредиент, для field собираемся использовавть 
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
            //Ассоциация объекта(Отправляем имя производственного здания, получаем ассоциацию field1->field)
            var aSubject = Data.GetComponent<AssociationSubject>();
            string subjectAssociation = aSubject.GetAssociation(productionBuildingName);
            //Получаем список ингредиентов (ингредиент, количество)
            var ingredient = Data.GetComponent<Ingredient>();
            var ss = Data.GetComponent<SubjectSum>();
            var content = Data.GetComponent<Content>();
            IDictionary<string, int> allIngredients = new Dictionary<string, int>();
            allIngredients = ingredient.GetAllIngredients(subjectName);
            Debug.Log(allIngredients);
            //Если производственное здание не является полем
            if (subjectAssociation != "field") {
                foreach (var item in allIngredients) {
                    //Проверяем количество ингредиентов, является ли данный ингредиент последним на складе, если является, тогда предупреждаем пользователя, только если это культура для посева
				    string queryCountCheck = ss.QueryReducingSubjectSumCount(item.Key,item.Value);
                    Debug.Log("queryCountCheck=" + queryCountCheck);
                    //Получаем количество ингредиентов на складе
				    int countCheck = ss.GetSubjectSumCount(item.Key, "Local");
                    Debug.Log("countCheck=" + countCheck);
                    //Получаем количество объектов, находящихся в производстве/отгрузке
                    int countCheckInContent = content.GetCountAllSlotsBySubjectName(subjectName);
                    Debug.Log("countCheckInContent=" + countCheckInContent);
                    //Нужен массив с несколькими предметами для отображения пользователю
                    if ((countCheck - item.Value <= 0) && (countCheckInContent <= 0)) {
                        Debug.Log("if ((countCheck - item.Value == 0) && (countCheckInContent == 0))=");
                        //Здесь должен быть массив с ингредиентами которых почти не осталось
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
    //Получаем продукт, находящийся в зоне отгрузки для каждого слота по номеру, идентификатору пользователя
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
