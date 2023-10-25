using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;


public class ShowValue : MonoBehaviour
{
    //Объект который содержит значение для отображения (обычно Data)
    public GameObject GetTarget;
    //Объект, на который будет выведена информация
    public GameObject ShowTarget;
    //Имя subjectName, для получения информации из БД
    public string NameTarget;
    //Позиция на экране, где находится объект ShowTarget
    public Vector3 PositionShowTarget;
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    void GetPositionShowTarget()
    {
        PositionShowTarget = gameObject.transform.position;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    void SetValueText(string value)
    {
        ShowTarget.GetComponent<Text>().text = value;
    }

    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    void SetValueTextPro(string value)
    {
        ShowTarget.GetComponent<TMPro.TextMeshProUGUI>().text = value;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetValue(string subjectName)
    {
        var temp = GetTarget.GetComponent<SubjectSum>().GetSubjectSumCount(subjectName, "Local");
        return temp.ToString();
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void ShowText()
    {
        switch (NameTarget)
        {
            case "levelNumber":
                string experiencePoint = GetValue("experiencePoint");
                string levelNumber = GetTarget.GetComponent<ExperienceLevel>().GetLevelByExperiencePoints(int.Parse(experiencePoint), "Local").ToString();
                SetValueText(levelNumber);
                break;
            default:
                string value = GetValue(NameTarget);
                SetValueText(value);
                break;
        }
        
        
        //var component = GetTarget.Get
                
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void ShowTextPro()
    {
        
        switch (NameTarget)
        {
            case "levelNumber":
                string experiencePoint = GetValue("experiencePoint");
                string levelNumber = GetTarget.GetComponent<ExperienceLevel>().GetLevelByExperiencePoints(int.Parse(experiencePoint), "Local").ToString();
                SetValueTextPro(levelNumber);
                Debug.Log("Do nothing");
                break;
            default:
                string value = GetValue(NameTarget);
                SetValueTextPro(value);
                break;
        }
        //var component = GetTarget.Get
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GetPositionShowTarget();
        ShowText();
        ShowTextPro();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
