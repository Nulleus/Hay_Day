using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class PanelFewResources : MonoBehaviour
{
    //������� ������ ���� ������ ��������
    public GameObject PanelFewResourceBox;
    //������ ������� ������(������, ����������� ������ �� ������)
    public GameObject ProductionBuildingSendRequest;
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
    public GameObject MainCamera;
    public bool MainCameraBlock;

    //[ShowInInspector]
    
    //public List<ProductionBuilding.MissingIngredient> MissingIngredients;

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
        PanelSlots.GetComponent<PanelSlots>().DeleteClones();
        SubjectNameForBuilding = "";
        //MissingIngredients.Clear();
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
        PanelSlots.GetComponent<PanelSlots>().Clone(subjectName, subjectCount);
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
    public void Show()
    {
        Debug.Log("Show");
        gameObject.SetActive(true);


    }
    void Update()
    {
        if (MainCameraBlock)
        {
            MainCamera.GetComponent<CameraScript>().IsZoomBlocked = true;
            MainCamera.GetComponent<CameraScript>().IsDragBlocked = true;
        }
        else
        {
            MainCamera.GetComponent<CameraScript>().IsZoomBlocked = false;
            MainCamera.GetComponent<CameraScript>().IsDragBlocked = false;
        }
        if (CheckResponseAllCost)
        {
            if (AllCost > 0)
            {
                
                CheckResponseAllCost = false;
            }
            AllCost = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().AllCost;
            ButtonBuy.GetComponent<ButtonScript>().ButtonText.GetComponent<Text>().text = AllCost.ToString();

        }
        if (CheckResponseMissingIngredients)
        {
            Debug.Log("MissingIngredients.Count"+ ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().MissingIngredients.Count);
            if (ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().MissingIngredients.Count > 0)
            {
                CheckResponseMissingIngredients = false;
                //�������� ���������� ������������ � ������
                int countIngredients = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().MissingIngredients.Count;
                ProductionBuilding.MissingIngredient[] missingIngredient = new ProductionBuilding.MissingIngredient[3];
                // �������� � ������ �������� �� ������ ����������� ������������, �������� �� ���������� (�����???)
                ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().MissingIngredients.CopyTo(0, missingIngredient, 0, countIngredients);
                for (int i = 0; i <= countIngredients; i++)
                {
                    Debug.Log("for ingredient_name" + i);
                    //���������� ������ �� ������ ����� �������� ���������� (��� ������ ���� �������) � ����������� ���������
                    ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().GetTranslateInfoRUS(missingIngredient[i].ingredient_name);
                    AddSubjectAndCount(ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().MissingIngredients[i].ingredient_name, ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().MissingIngredients[i].count_ingredients);

                }                              
            }
        }

    }

    public void OnEnable()
    {
        //��������� ��������� ���� ������
        MainCamera.GetComponent<CameraScript>().SaveOrthographicSize = MainCamera.GetComponent<Camera>().orthographicSize;
        //��������� ������ ��������������� ������ 357
        MainCamera.GetComponent<Camera>().orthographicSize = 357;
        //MissingIngredients.Clear();

        //AddSubjectAndCount("wheat", 8);
    }
}
