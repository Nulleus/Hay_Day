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

public class ProductionBuilding : MonoBehaviour
{
    private void LogMessage(string title, string message)
    {
#if UNITY_EDITOR
        EditorUtility.DisplayDialog(title, message, "Ok");
#else
		Debug.Log(message);
#endif
    }
    [ShowInInspector]
    public List<MissingIngredient> MissingIngredients;
    public GameObject Data;
    [ShowInInspector]
    public string SubjectName;

    public int MaxCountSlots;
    //Имя находящегося в производстве предмета
    public string[] SubjectsChildInTheProcessOfAssembly = new string[10];
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
    public float DateNowPlusDifferenceDateInSeconds;
    public bool CheckInBuilding;

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
    public void BuySubjectForDiamond(string subjectName)
    {
        RestClient.Post<ResponseBuySubjectForDiamonds>("http://farmpass.beget.tech/api/production_building_execute_methods.php", new POSTBuySubjectForDiamonds
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
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
    //Проверяем ответ от сервера
    public void CheckResponseFromRequests(string subjectNameForBuilding)
    {
        Debug.Log("CheckResponseFromRequests");
        foreach (var spisokResponseFromRequests in ResponseFromRequests)
        {
            //Если нехватает ингредиентов
            if (spisokResponseFromRequests.Key == "0x0000003")
            {
                //Отправляем запрос на сервер

                GetMissingIngredients(subjectNameForBuilding);
                //Отправляем запрос на сервер
                GetAllCost(subjectNameForBuilding);

                Debug.Log("0x0000003");
                GameObject panelFewResourcesBox = gameObject.GetComponent<ProductionBuildingUI>().PanelFewResourcesBox;
                GameObject panelFewResources = gameObject.GetComponent<ProductionBuildingUI>().PanelFewResources;
                panelFewResourcesBox.SetActive(true);
                panelFewResources.GetComponent<PanelFewResources>().SubjectNameForBuilding = subjectNameForBuilding;

                //Debug.Log(subjectNameForBuilding);
                //panelFewResources.GetComponent<PanelFewResources>().CheckResponseMissingIngredients = true;
                //panelFewResources.GetComponent<PanelFewResources>().MissingIngredients = MissingIngredients;
                ResponseFromRequests.Remove("0x0000003");
            }
            Console.WriteLine($"key: {spisokResponseFromRequests.Key}  value: {spisokResponseFromRequests.Value}");
        }
    }
    public void AddInSlotSubject(string subjectName, string productionBuildingName, int ignoreQuestion)
    {
        Debug.Log(subjectName+ productionBuildingName+ ignoreQuestion);
        RestClient.Post<ResponseAddInSlotSubject>("http://farmpass.beget.tech/api/production_building_execute_methods.php", new POSTAddInSlotSubject
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
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
        });

    }

    [Serializable]
    public class MissingIngredient
    {
        public string ingredient_name;
        public int count_ingredients;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class RootMissingIngredient
    {
        public List<MissingIngredient> missingIngredients;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }

    private void OnEnable()
    {

        //Получаем время в секундах до выгрузки объекта 0, который находится в производстве 
        GetDifferenceDateInSeconds(SubjectName, 0);
        for (int i = 0; i <= MaxCountSlots; i++)
        {
            Debug.Log(i);
            GetSubjectChildInTheProcessOfAssembly(SubjectName, i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Если таймер не истек
        if (DateNowPlusDifferenceDateInSeconds>0)
        {
            DateNowPlusDifferenceDateInSeconds -= Time.deltaTime;
        }
        //Если таймер истек
        else
        {            
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
                    //Получаем 
                    GetDifferenceDateInSeconds(SubjectName, 0);
                    for (int i = 0; i <= MaxCountSlots; i++)
                    {
                        Debug.Log(i);
                        GetSubjectChildInTheProcessOfAssembly(SubjectName, i);
                    }
                }

            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //Получаем секунды до выгрузки первого объекта из производства
    public void GetDifferenceDateInSeconds(string subjectParentName, int numberSlot)
    {
        Debug.Log("GetDifferenceDateInSeconds");
        RestClient.Post<ResponseGetDifferenceDateInSeconds>("http://farmpass.beget.tech/api/production_building_execute_methods.php", new POSTGetDifferenceDateInSeconds
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetDifferenceDateInSeconds",
            subjectParentName = subjectParentName,
            numberSlot = numberSlot
        }).Then(response => {           
            //Если дата не просрочена, значит в производстве есть предметы
            if (response.expiredDate=="no")
            {
                CheckInBuilding = true;
                //Останавливаем после получения значения
                CheckGetSubjectChildInTheProcessOfAssembly = false;
                //Секунд до обновления слотов
                DateNowPlusDifferenceDateInSeconds = response.differenceDateInSeconds;
                Debug.Log("DateNowPlusDifferenceDateInSeconds" + DateNowPlusDifferenceDateInSeconds);
            }
            //Если дата просрочена, значит в производстве нет предметов по номеру этого слота
            if (response.expiredDate == "yes")
            {
                CheckGetSubjectChildInTheProcessOfAssembly = false;
                CheckInBuilding = false;
            }
        });
    }
    public void GetAllCost(string subjectName)
    {
        Debug.Log("GetAllCost");
        AllCost = 0;
        RestClient.Post<ResponseGetAllCost>("http://farmpass.beget.tech/api/production_building_execute_methods.php", new POSTGetAllCost
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
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
        RestClient.Post<ResponseGetTranslateInfoRU>("http://farmpass.beget.tech/api/production_building_execute_methods.php", new POSTGetTranslateInfoRU
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
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

    public void GetMissingIngredients(string subjectName)
    {
        MissingIngredients.Clear();
        //gameObject.GetComponent<ProductionBuildingUI>().PanelFewResources.GetComponent<PanelFewResources>().MissingIngredients.Clear();
        string basePath = "http://farmpass.beget.tech/api/production_building_execute_methods.php";
        RequestHelper currentRequest;
        currentRequest = new RequestHelper
        {
            Uri = basePath,
            Body = new POSTGetMissingIngredients
            {
                jwt = Data.GetComponent<Users>().GetJWTToken(),
                methodName = "GetMissingIngredients",
                subjectName = subjectName
            },
            EnableDebug = true
        };
        RestClient.Post<RootMissingIngredient>(currentRequest)
        .Then(res => {
            // later we can clear the default query string params for all requests
            RestClient.ClearDefaultParams();
            Debug.Log(res.missingIngredients);
            //MissingIngredients = res.missingIngredients;
            MissingIngredients = res.missingIngredients;
        })
        .Catch(err => this.LogMessage("Error", err.Message));
    }
    public void Shipment(string subjectParentName)
    {
        RestClient.Post<ResponseShipment>("http://farmpass.beget.tech/api/production_building_execute_methods.php", new POSTShipment
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
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
    //Получаем продукт, находящийся в производстве для каждого слота по номеру, идентификатору пользователя
    public void GetSubjectChildInTheProcessOfAssembly(string subjectParentName, int numberSlot)
    {
        RestClient.Post<ResponseSubjectChildInTheProcessOfAssembly>("http://farmpass.beget.tech/api/production_building_execute_methods.php", new POSTSubjectChildInTheProcessOfAssembly
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetSubjectChildInTheProcessOfAssembly",
            subjectParentName = subjectParentName,
            numberSlot = numberSlot
        }).Then(response => {
            SubjectsChildInTheProcessOfAssembly[numberSlot] = response.subjectChildInTheProcessOfAssembly;
            Debug.Log("response.subjectChildInTheProcessOfAssembly" + response.subjectChildInTheProcessOfAssembly);
        });

    }
    

}
