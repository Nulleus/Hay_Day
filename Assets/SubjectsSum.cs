using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Proyecto26;
using UnityEditor;

public class SubjectsSum : MonoBehaviour
{
    [Serializable]
    public class POSTGetSubjectSumCount
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
    public class ResponseGetSubjectSumCount
    {
        public string message;
        public int sumCount;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
    public GameObject Data;
    public string SubjectName;
    public int SumCount;
    //Скрипт работает с таблицей subjects_sum
    // Start is called before the first frame update
    private void Start()
    {

    }
    private void OnEnable()
    {
        GetSubjectSumCount(SubjectName);
    }
    public void GetSubjectSumCount(string subjectName)
    {
        RestClient.Post<ResponseGetSubjectSumCount>("http://farmpass.beget.tech/api/subject_sum_execute_methods.php", new POSTGetSubjectSumCount
        {
            jwt = Data.GetComponent<Users>().GetJWTToken(),
            methodName = "GetSubjectSumCount",
            subjectName = subjectName

        }).Then(response => {
            //EditorUtility.DisplayDialog("message: ", response.message, "Ok");
            //EditorUtility.DisplayDialog("sumCount: ", response.sumCount.ToString(), "Ok");
            Debug.Log(response.sumCount);
            SumCount = response.sumCount;
            Debug.Log("sumCount=" + SumCount);
        });
    }

}
