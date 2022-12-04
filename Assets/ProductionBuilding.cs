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

public class ProductionBuilding : MonoBehaviour
{
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

    private void OnEnable()
    {
        BuySubjectForDiamond("cowFeed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {

    }
}
