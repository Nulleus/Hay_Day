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
    public void SetProperties()
    {
        SetNameText();
        SetInfoText();
        SetTimeBuildingText();
    }
    public void SetNameText()
    {
        Name.GetComponent<Text>().text = Data.GetComponent<Translit>().GetNameRUSByNameObject(SubjectName);
    }
    public void SetInfoText()
    {
        Info.GetComponent<Text>().text = Data.GetComponent<Translit>().GetDescriptionRUSByNameObject(SubjectName);
    }
    public void SetTimeBuildingText()
    {
        BuildingTime.GetComponent<Text>().text = Data.GetComponent<Translit>().GetTimeBuildingRUSByNameObject(SubjectName); ;
    }
    
    void Start()
    {
        SetProperties();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
