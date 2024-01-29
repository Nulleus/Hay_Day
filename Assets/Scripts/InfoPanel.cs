using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    public GameObject Name;
    public GameObject Info;
    public GameObject BuildingTime;
    public string SubjectName;
    public GameObject Data;
    // Start is called before the first frame update
    //Присвоим значение свойствам
    public void SetProperties(string name, string info, string timeBuilding)
    {
        SetNameText(name);
        SetInfoText(info);
        SetTimeBuildingText(timeBuilding);
    }
    public void SetNameText(string text)
    {
        Name.GetComponent<Text>().text = text;
    }
    public void SetInfoText(string text)
    {
        Info.GetComponent<Text>().text = text;
    }
    public void SetTimeBuildingText(string text)
    {
        BuildingTime.GetComponent<Text>().text = text;
    }
    
    void Start()
    {
        //SetProperties();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        Name = gameObject.transform.Find("Name").gameObject;
        Info = gameObject.transform.Find("Info").gameObject;
        BuildingTime = gameObject.transform.Find("BuildingTime").gameObject;
    }
}
