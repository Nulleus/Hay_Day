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
    public void ShowText(string value = "default string")
    {
        switch (NameTarget)
        {           
            case "coin":
                value = GetValue(NameTarget);
                SetValueText(value);
                break;
             case "diamond":
                value = GetValue(NameTarget);
                SetValueText(value);
                break;
            case "output_quantity":
                SetValueText("+" + value);
                Debug.Log("Do nothing");
                break;
            default:
                Debug.Log("default");
                break;
        }
        
        
        //var component = GetTarget.Get
                
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void ShowTextPro(string value = "default string")
    {
        string experiencePoint;
        string levelNumber;
        switch (NameTarget)
        {
            case "levelNumber":
                experiencePoint = GetValue("experiencePoint");
                levelNumber = GetTarget.GetComponent<ExperienceLevel>().GetLevelByExperiencePoints(int.Parse(experiencePoint), "Local").ToString();
                SetValueTextPro(levelNumber);
                Debug.Log("Do nothing");
                break;
            case "output_quantity":
                SetValueTextPro("+"+value);
                Debug.Log("Do nothing");
                break;
            default:
                Debug.Log("default");
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
