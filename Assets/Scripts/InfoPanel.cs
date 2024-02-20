using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class InfoPanel : MonoBehaviour
{
    public GameObject Name;
    public GameObject Info;
    public GameObject BuildingTime;
    public string SubjectName;
    public GameObject Data;
    // Start is called before the first frame update
    //Присвоим значение свойствам
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetProperties(string name, string info, string timeBuilding)
    {
        SetNameText(name);
        SetInfoText(info);
        SetTimeBuildingText(timeBuilding);
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetNameText(string text)
    {
        if (Name.GetComponent<TMPro.TextMeshProUGUI>() != null)
        {
            Name.GetComponent<TMPro.TextMeshProUGUI>().text = text;
        }
        if (Name.GetComponent<Text>() != null)
        {
            Name.GetComponent<Text>().text = text;
        }
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetInfoText(string text)
    {
        if (Info.GetComponent<TMPro.TextMeshProUGUI>() != null)
        {
            Info.GetComponent<TMPro.TextMeshProUGUI>().text = text;
        }
        if (Info.GetComponent<Text>() != null)
        {
            Info.GetComponent<Text>().text = text;
        }
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetTimeBuildingText(string text)
    {
        if (BuildingTime.GetComponent<TMPro.TextMeshProUGUI>() != null)
        {
            BuildingTime.GetComponent<TMPro.TextMeshProUGUI>().text = text;
        }
        if (BuildingTime.GetComponent<Text>() != null)
        {
            BuildingTime.GetComponent<Text>().text = text;
        }
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
