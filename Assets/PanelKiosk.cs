using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class PanelKiosk : MonoBehaviour
{
    public GameObject Data;
    public string SelectedStorage;
    public List<string> AllSubjects; //��� �������
    public GameObject SelectedPredmet; //��������� �������
    public GameObject ObjectFromGetWidthClone; //������, � �������� ����� ������� ����
    public Transform ParentObjectClone; //������������ ������ �����
    [SerializeField]
    private int SelectedPredmetQuantity;
    [SerializeField]
    private int CoinQuantity;
    public GameObject ButtonPlusQuantity;
    public GameObject ButtonMinusQuantity;
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetSelectedPredmetQuantity()
    {
        return SelectedPredmetQuantity;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetSelectedPredmetQuantity(int quantity)
    {
        SelectedPredmetQuantity = quantity;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void ChangeSelectedPredmetQuantity()
    {
        //�������� ���������� ���������� ��������� �� ������
        int selectedPredmetSubjectSum = Data.GetComponent<SubjectSum>().GetSubjectSumCount(GetSelectedPredmet(), "Local");
        Debug.Log("selectedPredmetSubjectSum=" + selectedPredmetSubjectSum);
        //������� ���������� ��������� ��������� 
        SelectedPredmet.GetComponent<ShowText>().Show("x"+SelectedPredmetQuantity.ToString());
        if (SelectedPredmetQuantity < 2)
        {
            ButtonMinusQuantity.GetComponent<Image>().color = Color.grey;
            ButtonMinusQuantity.GetComponent<ButtonScript>().SetLock(true);
        }
        else
        {
            ButtonMinusQuantity.GetComponent<Image>().color = Color.white;
            ButtonMinusQuantity.GetComponent<ButtonScript>().SetLock(false);
            if (selectedPredmetSubjectSum <= SelectedPredmetQuantity)
            {
                ButtonPlusQuantity.GetComponent<Image>().color = Color.grey;
                Debug.Log("grey");
            }
            if (selectedPredmetSubjectSum >= SelectedPredmetQuantity)
            {
                ButtonPlusQuantity.GetComponent<Image>().color = Color.white;
                Debug.Log("white");
            }
        }

    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetCoinQuantity()
    {
        return CoinQuantity;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetCoinQuantity(int quantity)
    {
        SelectedPredmetQuantity = quantity;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetPlusQuantity(int quantity)
    {
        ChangeSelectedPredmetQuantity();
        //������� ����� ���������� ��������� �� ������

        SelectedPredmetQuantity = SelectedPredmetQuantity + quantity;

    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetMinusQuantity(int quantity)
    {
        ChangeSelectedPredmetQuantity();
        SelectedPredmetQuantity = SelectedPredmetQuantity - quantity;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetSelectedPredmet()
    {
        return SelectedPredmet.GetComponent<PanelSlot>().GetSubjectName();
    }
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
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetCountSubjects()
    {
        return AllSubjects.Count;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void CloneSubject()
    {
        
        int countSubjects = GetCountSubjects();
        for (int i = 0; i <countSubjects; i++)
        {
            GameObject clone = Instantiate(ObjectFromGetWidthClone, ParentObjectClone);
            //������� ����� �������� 
            clone.SetActive(true);
            //�������� ��� �������
            clone.GetComponent<Subject>().SetName(AllSubjects[i]);
            //������� �������� �������
            clone.GetComponent<SpriteController>().SetSprite(AllSubjects[i]);
            //������� ���������� �������� �� ������
            //-������� ���������� �������� �� ������
            int countSubjectSum = clone.GetComponent<Subject>().GetCount();
            clone.GetComponent<ShowText>().Show(countSubjectSum.ToString());
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
