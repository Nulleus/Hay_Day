using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class PanelFewResources : MonoBehaviour
{
    [ShowInInspector]
    //public Dictionary<string, int> SubjectAndCount = new Dictionary<string, int>();
    public GameObject PanelSlots;
    public GameObject ButtonBuy;
    public int AllCost; //��������� ���� �������� ��� ������� ���������
    public string UserActionSelection; //����� �������� �������������, �������� �������, ������
    //��� ��������, ������� �� ����� ����������, �� ��������� ������������
    public string SubjectNameForBuilding;
    //������� ������ �� ������ ����������� ������������
    public bool CheckResponseMissingIngredients;
    //������� ������ �� ������ ����� ��������� � ������� ��� ������������
    public bool CheckResponseAllCost;
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
    public void SetButtonBuyTextCount()
    {
        ButtonBuy.GetComponent<ButtonScript>().SetAllPriceSubjectsText(AllCost);
    }
    public void CleanerPanel()
    {
        PanelSlots.GetComponent<CloneObject>().DeleteClones();
        SubjectNameForBuilding = "";
        MissingIngredients.Clear();
        CheckResponseMissingIngredients = true;
        CheckResponseAllCost = true;
        AllCost = 0;
    }
    public void CloseObject()
    {      
        gameObject.SetActive(false);
    }
    public void AddSubjectAndCount(string subjectName, int subjectCount)
    {
        //SubjectAndCount.Add(subjecName, subjectCount);
        PanelSlots.GetComponent<CloneObject>().Clone(subjectName, subjectCount);
    }
    private void OnDisable()
    {
        CleanerPanel();
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
        if (CheckResponseAllCost)
        {
            if (AllCost > 0)
            {
                
                CheckResponseAllCost = false;
            }
            ButtonBuy.GetComponent<ButtonScript>().ButtonText.GetComponent<Text>().text = AllCost.ToString();

        }
        if (CheckResponseMissingIngredients)
        {
            if (MissingIngredients.Count > 0)
            {
                CheckResponseMissingIngredients = false;
            }
            MissingIngredients = gameObject.GetComponent<ProductionBuilding>().MissingIngredients;
            //�������� ����������� �����������
            //gameObject.GetComponent<ProductionBuilding>().GetMissingIngredients(SubjectNameForBuilding);
            //��������� ������ ����������� ������������ � ���� ������
            //MissingIngredients = GOProductionBuilding.GetComponent<ProductionBuilding>().MissingIngredients;
            //MissingIngredients = gameObject.GetComponent<ProductionBuilding>().MissingIngredients;
            //�������� ���������� ������������ � ������
            int countIngredients = MissingIngredients.Count;
            //������ �� ����������� ������������
            ProductionBuilding.MissingIngredient[] missingIngredient = new ProductionBuilding.MissingIngredient[3];
            // �������� � ������ �������� �� ������ ����������� ������������, �������� �� ����������
            MissingIngredients.CopyTo(0, missingIngredient, 0, countIngredients);
            //�������� �������� ��� ������������

            for (int i = 0; i <= countIngredients; i++)
            {
                Debug.Log(i);
                AddSubjectAndCount(missingIngredient[i].ingredient_name, missingIngredient[i].count_ingredients);
            }
            //���� ���������� ������ � �������� ��������, �������� 

        }

    }

    public void OnEnable()
    {
        MissingIngredients.Clear();
        
        //AddSubjectAndCount("wheat", 8);
    }
}
