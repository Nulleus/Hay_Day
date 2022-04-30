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

public class Ingredients : MonoBehaviour
{
    [Serializable]
    public class POSTGetCountAllIngredients
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
    public class ResponseGetCountAllIngredients
    {
        public string message;
        public int count;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTGetIngredientName
    {
        public string jwt;
        public string methodName;
        public string subjectName;
        public int number;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseGetIngredientName
    {
        public string message;
        public string ingredientName;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTGetCountIngredient
    {
        public string jwt;
        public string methodName;
        public string subjectName;
        public int number;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseGetCountIngredient
    {
        public string message;
        public int count;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class POSTGetIngredientsAndCount
    {
        public string jwt;
        public string methodName;
        public string subjectName;
        public int number;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    [Serializable]
    public class ResponseGetIngredientsAndCount
    {
        public string message;
        public string ingredientName;
        public int ingredientCount;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    private void Start()
    {
        
    }
    public GameObject Data;
    [SerializeField]
    private int CountAllIngredients;
    [SerializeField]
    private string IngredientName;
    [SerializeField]
    private string SubjectName;
    [SerializeField]
    private int CountIngredient;
    [ShowInInspector]
    public Dictionary<string, int> IngredientsAndCount = new Dictionary<string, int>();

    //Dictionary<string, int> Ingredient;
    //Имя ингредиента, количество ингредиента
    //Скрипт загружает данные об составе(ингредиентах) в объекты "Ingredient"
    public void GetCountAllIngredients(string subjectName)
    {

        RestClient.Post<ResponseGetCountAllIngredients>("http://farmpass.beget.tech/api/ingredient_execute_methods.php", new POSTGetCountAllIngredients
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetCountAllIngredients",
            subjectName = subjectName

        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("count: ", response.count.ToString(), "Ok");
            Debug.Log(response.count);
            CountAllIngredients = response.count;
            
            Debug.Log("Count=" + CountAllIngredients);
        });
    }
    public string GetIngredientName(string subjectName, int number)
    {
        RestClient.Post<ResponseGetIngredientName>("http://farmpass.beget.tech/api/ingredient_execute_methods.php", new POSTGetIngredientName
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetIngredientName",
            subjectName = subjectName,
            number = number

        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("ingredientsName: ", response.ingredientName, "Ok");
            
            IngredientName = response.ingredientName;
            Debug.Log("IngredientName=" + IngredientName);

            return IngredientName;
        });
        return IngredientName;
    }
    public int GetCountIngredient(string subjectName, int number)
    {
        RestClient.Post<ResponseGetCountIngredient>("http://farmpass.beget.tech/api/ingredient_execute_methods.php", new POSTGetCountIngredient
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetCountIngredient",
            subjectName = subjectName,
            number = number

        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("count: ", response.count.ToString(), "Ok");
            Debug.Log(response.count);
            CountIngredient = response.count;
            Debug.Log("CountIngredient=" + CountIngredient);
            return CountIngredient;
        });
        return CountIngredient;
    }
    //Получаем ингредиенты, необходимые для создания объекта
    public void GetIngredientsAndCount(string subjectName, int number)
    {

        RestClient.Post<ResponseGetIngredientsAndCount>("http://farmpass.beget.tech/api/ingredient_execute_methods.php", new POSTGetIngredientsAndCount
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetIngredientsAndCount",
            subjectName = subjectName,
            number = number

        }).Then(response => {
            EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            EditorUtility.DisplayDialog("ingredientName: ", response.ingredientName, "Ok");
            EditorUtility.DisplayDialog("ingredientCount: ", response.ingredientCount.ToString(), "Ok");
            if (response.ingredientCount != 0)
            {
                IngredientsAndCount.Add(response.ingredientName, response.ingredientCount);
            }
            
        });
    }

    private void OnEnable()
    {
        SubjectName = gameObject.name;
        for (int i = 0;i<5 ; i++)
        {
            GetIngredientsAndCount(SubjectName, i);
        }
            
        //GetIngredientsAndCount("cowFeed", 0);
        //GetCountAllIngredients("cowFeed");
        //GetIngredientName("cowFeed",0);
        //GetCountIngredient("cowFeed", 0);
        //StartCoroutine(GetCompositions("cowFeed"));
        //Compositions = GetCompositions("cowFeed");
        //Dictionary<string, int> compositions = new Dictionary<string, int>();
        //compositions.Add("wheat", 2);
        //Compositions = compositions; 
    }
}
