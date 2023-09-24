using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class PanelQuestion : MonoBehaviour
{
    //������� ������ ���� ������
    public GameObject PanelQuestionBox;
    //������ ������� ������(������, ����������� ������ �� ������)
    public GameObject ProductionBuildingSendRequest;
    //������ ���������
    public GameObject PanelSlots;
    //����� �������� �������������, �������� �������, ������
    public string UserActionSelection; 
    //��� ��������, ������� �� ����� ����������, �� ��������� ������������
    public string SubjectNameForBuilding;
    //������� ������ �� ������ ����������� ������������
    public bool CheckResponseLastIngredients;
    //������� ������
    public GameObject MainCamera;

    //����� ������������
    public void SetUserActionSelection(string actionSelectionName)
    {
        UserActionSelection = actionSelectionName;
    }
    //������� ������
    public void CleanerPanel()
    {
        PanelSlots.GetComponent<PanelSlots>().DeleteClones();
        SubjectNameForBuilding = "";
        CheckResponseLastIngredients = true;
    }
    public void CloseObject()
    {
        //MainCamera.GetComponent<CameraScript>().IsZoomBlocked = false;
        //MainCamera.GetComponent<CameraScript>().IsDragBlocked = false;
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

    }

    // Update is called once per frame
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void Show()
    {
        PanelQuestionBox.SetActive(true);
        MainCamera.GetComponent<Camera>().orthographicSize = 357;
        MainCamera.GetComponent<CameraScript>().IsZoomBlocked = true;
        MainCamera.GetComponent<CameraScript>().IsDragBlocked = true;

    }
    void Update()
    {
        if (CheckResponseLastIngredients)
        {
            Debug.Log("MissingIngredients.Count" + ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().LastIngredients.Count);
            if (ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().LastIngredients.Count > 0)
            {
                CheckResponseLastIngredients = false;
                //�������� ���������� ��������� ��������� � ������
                int countLastSubjects = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().LastIngredients.Count;
                ProductionBuilding.LastIngredient[] lastIngredient = new ProductionBuilding.LastIngredient[3];
                // �������� � ������ �������� �� ������ ����������� ������������, �������� �� ����������
                ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().LastIngredients.CopyTo(0, lastIngredient, 0, countLastSubjects);
                for (int i = 0; i <= countLastSubjects; i++)
                {
                    Debug.Log("for last_name" + i);
                    //���������� ������ �� ������ ����� �������� ���������� � ��������� ���������
                    ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().GetTranslateInfoRUS(lastIngredient[i].lastIngredients);
                }
            }
            else
            {
                //�������� ����������� �����������
                //�������� ���������� ��������� ��������� � ������
                int countLastSubjects = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().LastIngredients.Count;
                Debug.Log("countIngredients=" + countLastSubjects);

                for (int i = 0; i <= countLastSubjects; i++)
                {
                    Debug.Log("for countLastSubjects" + i);
                    //��������� �������                   
                    AddSubjectAndCount(ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().LastIngredients[i].lastIngredients, 0);
                }
                //���� ���������� ������ � �������� ��������, �������� 
            }


        }

    }

    public void OnEnable()
    {

    }
}