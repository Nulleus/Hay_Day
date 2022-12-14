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
    public GameObject Data;
    [SerializeField]
    private string SubjectName;

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
    public class POSTTest1
    {
        public string jwt;
        public string methodName;
        public string subjectName;
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
    public void AddInSlotSubject(string subjectName)
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
    
    public class MissingIngredient
    {
        public string ingredient_name { get; set; }
        public int count_ingredients { get; set; }
    }

    public class Root
    {
        public List<MissingIngredient> MissingIngredients { get; set; }
    }

    private void OnEnable()
    {
        //BuySubjectForDiamond("cowFeed");
        //Post();
        string googleSearchText = @"{'MissingIngredients': [{'ingredient_name': 'corn','count_ingredients': 1},{'ingredient_name': 'soybean','count_ingredients': 2}]}";
        JObject googleSearch = JObject.Parse(googleSearchText);
        // get JSON result objects into a list
        IList<JToken> results = googleSearch["MissingIngredients"].Children().ToList();
        // serialize JSON results into .NET objects
        IList<SearchResult> searchResults = new List<SearchResult>();
        foreach (JToken result in results)
        {
            // JToken.ToObject is a helper method that uses JsonSerializer internally
            SearchResult searchResult = result.ToObject<SearchResult>();
            searchResults.Add(searchResult);
            Debug.Log(searchResult);
            //Debug.Log(searchResults[1]);
            Debug.Log("Success");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public class SearchResult
    {
        public string ingredient_name { get; set; }
        public string count_ingredients { get; set; }
    }
    public void Post()
    {

        string basePath = "http://farmpass.beget.tech/api/production_building_execute_methods.php";
        RequestHelper currentRequest;
        // We can add default query string params for all requests
        //RestClient.DefaultRequestParams["param1"] = "My first param";
        //RestClient.DefaultRequestParams["param3"] = "My other param";

        currentRequest = new RequestHelper
        {
            Uri = basePath,
            Params = new Dictionary<string, string> {
                //{ "param1", "value 1" },
                //{ "param2", "value 2" }
            },
            Body = new POSTTest1
            {
                jwt = Data.GetComponent<Users>().GetJWTToken(),
                methodName = "Test1",
                subjectName = "cowFeed"
            },
            EnableDebug = true
        };
        RestClient.Post<POSTTest1>(currentRequest)
        .Then(res => {

            // And later we can clear the default query string params for all requests
            RestClient.ClearDefaultParams();

            this.LogMessage("Success", JsonUtility.ToJson(res, true));
            //string googleSearchText = JsonUtility.ToJson(res, true);
            
            //Dictionary<string, string> htmlAttributes = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            //Debug.Log(htmlAttributes["corn"]);
            //var values = JsonSerializer.Deserialize<Dictionary<string, string>>(JsonUtility.ToJson(res, true));
            //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(JsonUtility.ToJson(res, true));
            //myDeserializedClass.
        })
        .Catch(err => this.LogMessage("Error", err.Message));
    }
}
