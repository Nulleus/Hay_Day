using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Proyecto26;
using UnityEditor;
using UnityEngine.Networking;
using System.Threading.Tasks;
using System.Threading;

public class OutputQuantity : MonoBehaviour
{
    public GameObject Data;
    [SerializeField]
    private int Count;
    [Serializable]
    public class POSTGetOutputQuantityBySubjectName
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
    public class ResponseGetOutputQuantityBySubjectName
    {
        public string message;
        public int count;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    private void Start()
    {

    }
    //ѕолучаем количество продукта на выходе.
    public int GetOutputQuantityBySubjectName(string subjectName)
    {
        RestClient.Post<ResponseGetOutputQuantityBySubjectName>("http://farmpass.beget.tech/api/output_quantity_execute_methods.php", new POSTGetOutputQuantityBySubjectName
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetOutputQuantityBySubjectName",
            subjectName = subjectName

        }).Then(response => {
            //EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            //EditorUtility.DisplayDialog("count: ", response.count.ToString(), "Ok");
            Debug.Log(response.count);
            Count = response.count;
            return Count;
        });
        return Count;
        }
    private void OnEnable()
    {
        //GetOutputQuantityBySubjectName("wheat"); 
    }
}
