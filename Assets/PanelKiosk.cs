using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Mono.Data.Sqlite;

public class PanelKiosk : MonoBehaviour
{
    public GameObject Data;
    public string SelectedStorage;
    public List<string> AllSubjects; //Все объекты
    public GameObject SelectedPredmet; //Выбранный предмет
    public GameObject ObjectFromGetWidthClone; //Объект, с которого нужно сделать клон
    public Transform ParentObjectClone; //Родительский объект клона

    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetAllSubjects()
    {
        //Количество очков у пользователя
        int experiencePointUser = Data.GetComponent<SubjectSum>().GetSubjectSumCount("experiencePoint", "Local");
        //Текущий уровень пользователя
        int levelNumber = Data.GetComponent<ExperienceLevel>().GetLevelByExperiencePoints(experiencePointUser, "Local");
        string selectedStorages = GetSelectedStorage();
        SetAllSubjects(Data.GetComponent<Storage>().GetAllSubjects(selectedStorages, levelNumber, "Local"));
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetSelectedStorage()
    {
        return SelectedStorage;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetAllSubjects(List<string> allSubjects)
    {
        AllSubjects = allSubjects;
    }
    public int GetCountSubjects()
    {
        return AllSubjects.Count;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void CloneSubject()
    {
        
        int countSubjects = GetCountSubjects();
        for (int i = 0; i <=countSubjects; i++)
        {
            GameObject clone = Instantiate(ObjectFromGetWidthClone, ParentObjectClone);
            //Добавим клону свойства 
            clone.GetComponent<SpriteController>().SetSprite(AllSubjects[i]);
            //Добавить количество
            //clone.
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
