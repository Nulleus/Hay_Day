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
    [ShowInInspector]
    public int AllCost;
    [ShowInInspector]
    public Dictionary<string, string> ResponseFromRequests = new Dictionary<string, string>();
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
            EditorUtility.DisplayDialog("code: ", response.message, "Ok");
            EditorUtility.DisplayDialog("message: ", response.code, "Ok");
        });
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
            ResponseFromRequests.Add(response.code, response.message);
            //EditorUtility.DisplayDialog("code: ", response.message, "Ok");
            //EditorUtility.DisplayDialog("message: ", response.code, "Ok");
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
        public List<MissingIngredient> MissingIngredients;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }

    private void OnEnable()
    {
        //GetSubjectChildInTheProcessOfAssembly("bakery", 1);
        for (int i = 0; i <=MaxCountSlots; i++)
        {
        Debug.Log(i);
        GetSubjectChildInTheProcessOfAssembly(SubjectName, i);
        }
        Debug.Log("OnEnable");
        //AddInSlotSubject("bread","bakery", 0);
        //AddInSlotSubject("cowFeed", "feedMill1");
        //GetMissingIngredients("cowFeed");
        //Shipment("bakery");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GetMissingIngredients(string subjectName)
    {
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
            MissingIngredients = res.MissingIngredients;
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
            EditorUtility.DisplayDialog("code: ", response.message, "Ok");
            EditorUtility.DisplayDialog("message: ", response.code, "Ok");
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
