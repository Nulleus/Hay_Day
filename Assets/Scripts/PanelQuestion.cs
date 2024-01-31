using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class PanelQuestion : MonoBehaviour
{
    public GameObject Data;
    //������� ������ ���� ������
    public GameObject PanelQuestionBox;
    //������ ������� ������(������, ����������� ������ �� ������)
    public GameObject ProductionBuildingSendRequest;
    //������ ���������
    public GameObject PanelSlots;
    public GameObject PanelSlot;
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
        Data.GetComponent<Ingredient>().GetAllIngredients(string subjectName)
    }
    void Update()
    {

    }

    public void OnEnable()
    {

    }
}