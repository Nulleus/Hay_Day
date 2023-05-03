using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using Proyecto26;
using UnityEditor;

public class ProgressSlots : MonoBehaviour
{
    [Serializable]
    public class POSTGetOpenSlotsCount
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
    public class ResponseGetOpenSlotsCount
    {
        public string message;
        public int openSlots;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    public GameObject Data;
    public int OpenSlots; // оличество открытых слотов у пользовател€
    [SerializeField]
    public GameObject ParentSubject;
    private void Start()
    {
        string subjectName = ParentSubject.GetComponent<ProductionBuildingUI>().NameSystem;
        GetOpenSlotsCount(subjectName);
        //Debug.Log("GetOpenSlotsCount" + GetOpenSlotsCount("bakery", 11));
    }
    private void OnEnable()
    {

    }
    public void GetOpenSlotsCount(string subjectName)
    {
        RestClient.Post<ResponseGetOpenSlotsCount>("http://farmpass.beget.tech/api/progres_slot_execute_methods.php", new POSTGetOpenSlotsCount
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetOpenSlotsCount",
            subjectName = subjectName

        }).Then(response => {
            //EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            //EditorUtility.DisplayDialog("openSlots: ", response.openSlots.ToString(), "Ok");
            Debug.Log(response.openSlots);
            OpenSlots = response.openSlots;
            Debug.Log("openSlots=" + OpenSlots);
        });
    }
}
