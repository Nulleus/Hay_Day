using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PanelFewResources : MonoBehaviour
{
    [ShowInInspector]
    //public Dictionary<string, int> SubjectAndCount = new Dictionary<string, int>();
    public GameObject PanelSlots;
    //Необходимы объекты
    // Start is called before the first frame update
    //Очистка панели
    public void ClearPanel()
    {
        //SubjectAndCount = null; //Clear
    }
    public void AddSubjectAndCount(string subjectName, int subjectCount)
    {
        //SubjectAndCount.Add(subjecName, subjectCount);
        PanelSlots.GetComponent<CloneObject>().Clone(subjectName, subjectCount);
    }

    void Start()
    {
        //Перенести это в метод, который будет вызывать панель
        //AddSubjectAndCount("wheat", 8);
        //AddSubjectAndCount("corn", 5);
        /*foreach (KeyValuePair<string, int> kvpSubjectAndCount in SubjectAndCount)
        {
            PanelSlots.GetComponent<CloneObject>().Clone(kvpSubjectAndCount.Key, kvpSubjectAndCount.Value);
            Debug.Log(kvpSubjectAndCount.Key);
            Debug.Log(kvpSubjectAndCount.Value);
        }
        */
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
