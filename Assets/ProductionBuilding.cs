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
    //Имя объекта в переводе
    public string TranslateName;
    //Описание объекта в переводе
    public string TranslateDiscription;
    //Время производства в переводе
    public string TranslateTimeBuilding;

    //public ExtendedDictonary<string, string> ResponseFromRequests = new ExtendedDictonary<string, string>();
    //GetTranslateInfoRUS
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
    public void CheckResponseFromRequests(string subjectNameForBuilding)
    {
        Debug.Log("CheckResponseFromRequests");
        foreach (var spisokResponseFromRequests in ResponseFromRequests)
        {
            //Если нехватает ингредиентов
            if (spisokResponseFromRequests.Key == "0x0000003")
            {
                GetMissingIngredients(subjectNameForBuilding);
                GetAllCost(subjectNameForBuilding);
                GetTranslateInfoRUS(subjectNameForBuilding);
                Debug.Log("0x0000003");
                GameObject panelFewResourcesBox = gameObject.GetComponent<ProductionBuildingUI>().PanelFewResourcesBox;
                GameObject panelFewResources = gameObject.GetComponent<ProductionBuildingUI>().PanelFewResources;
                panelFewResourcesBox.SetActive(true);
                panelFewResources.GetComponent<PanelFewResources>().SubjectNameForBuilding = subjectNameForBuilding;
                
                //Debug.Log(subjectNameForBuilding);
                panelFewResources.GetComponent<PanelFewResources>().MissingIngredients = MissingIngredients;
                //var range = MissingIngredients.GetRange(1,1);
                // копируем в массив первые три элемента
                //MissingIngredient[] partOfPeople = new MissingIngredient[3];
                //issingIngredients.CopyTo(0, partOfPeople, 0, 3);
                //panelFewResources.GetComponent<PanelFewResources>().AddSubjectAndCount(partOfPeople[0].ingredient_name, partOfPeople[0].count_ingredients);
                //panelFewResources.GetComponent<PanelFewResources>().AddSubjectAndCount("wheat", 2);
                //Debug.Log(spisokResponseFromRequests.Value);
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
        for (int i = 0; i <=MaxCountSlots; i++)
        {
        Debug.Log(i);
        GetSubjectChildInTheProcessOfAssembly(SubjectName, i);
        }
        Debug.Log("OnEnable");
    }

    // Update is called once per frame
    void Update()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GetAllCost(string subjectName)
    {
        RestClient.Post<ResponseGetAllCost>("http://farmpass.beget.tech/api/production_building_execute_methods.php", new POSTGetAllCost
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetAllCost",
            subjectName = subjectName
        }).Then(response => {
            //gameObject.GetComponent<ProductionBuildingUI>().PanelFewResources.GetComponent<PanelFewResources>().AllCost = response.allCost;
            AllCost = response.allCost;
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
            TranslateName = response.nameRU;
            TranslateDiscription = response.discriptionRU;
            TranslateTimeBuilding = response.timeBuildingRU;
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
        string basePath = "http://farmpass.beget.tech/api/production_building_execute_methods.php";
        RequestHelper currentRequest;
        currentRequest = new RequestHelper
        {
            Uri = basePath,
            Body = new POSTSubjectChildInTheProcessOfAssembly
            {
                jwt = Data.GetComponent<Users>().GetJWTToken(),
                methodName = "GetSubjectChildInTheProcessOfAssembly",
                subjectParentName = subjectParentName,
                numberSlot = numberSlot
            },
            EnableDebug = true
        };
        RestClient.Post<ResponseSubjectChildInTheProcessOfAssembly>(currentRequest)
        .Then(res => {
            // later we can clear the default query string params for all requests
            RestClient.ClearDefaultParams();
            SubjectsChildInTheProcessOfAssembly[numberSlot] = res.subjectChildInTheProcessOfAssembly;
        })
        .Catch(err => this.LogMessage("Error", err.Message));
    }
    

}
