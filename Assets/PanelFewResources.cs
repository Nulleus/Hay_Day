using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PanelFewResources : MonoBehaviour
{
    [ShowInInspector]
    //public Dictionary<string, int> SubjectAndCount = new Dictionary<string, int>();
    public GameObject PanelSlots;
    public GameObject ButtonBuy;
    public int AllPriceSubjectsSum; //��������� ���� �������� ��� ������� ���������
    public string UserActionSelection; //����� �������� �������������, �������� �������, ������
    //��� ��������, ������� �� ����� ����������, �� ��������� ������������
    public string SubjectNameForBuilding;
    [ShowInInspector]
    
    public List<ProductionBuilding.MissingIngredient> MissingIngredients;

    //���������� �������
    // Start is called before the first frame update
    //����� ������������
    public void SetUserActionSelection(string actionSelectionName)
    {
        UserActionSelection = actionSelectionName;
    }
    //������� ������
    public void SetButtonBuyTextCount(int count)
    {
        AllPriceSubjectsSum = count; //
        ButtonBuy.GetComponent<ButtonScript>().SetAllPriceSubjectsText(count);
    }
    public void CleanerPanel()
    {
        PanelSlots.GetComponent<CloneObject>().DeleteClones();
    }
    public void CloseObject()
    {
        CleanerPanel();
        gameObject.SetActive(false);
    }
    public void AddSubjectAndCount(string subjectName, int subjectCount)
    {
        //SubjectAndCount.Add(subjecName, subjectCount);
        PanelSlots.GetComponent<CloneObject>().Clone(subjectName, subjectCount);
    }
    void Start()
    {
        //��������� ��� � �����, ������� ����� �������� ������
        
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
    public void OnEnable()
    {
        ProductionBuilding.MissingIngredient[] partOfPeople = new ProductionBuilding.MissingIngredient[3];
        MissingIngredients.CopyTo(0, partOfPeople, 0, 1);
        AddSubjectAndCount(partOfPeople[0].ingredient_name, partOfPeople[0].count_ingredients);
        //AddSubjectAndCount("wheat", 8);
    }
}
