using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Mono.Data.Sqlite;

public class PanelKiosk : MonoBehaviour
{
    public GameObject Data;
    public string SelectedStorage;
    public List<string> AllSubjects; //��� �������
    public GameObject SelectedPredmet; //��������� �������
    public GameObject ObjectFromGetWidthClone; //������, � �������� ����� ������� ����
    public Transform ParentObjectClone; //������������ ������ �����

    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetAllSubjects()
    {
        //���������� ����� � ������������
        int experiencePointUser = Data.GetComponent<SubjectSum>().GetSubjectSumCount("experiencePoint", "Local");
        //������� ������� ������������
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
            //������� ����� �������� 
            clone.GetComponent<SpriteController>().SetSprite(AllSubjects[i]);
            //�������� ����������
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
