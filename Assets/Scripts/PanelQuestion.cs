using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class PanelQuestion : MonoBehaviour
{
    public GameObject Data;
    //Главный объект бокс панели
    public GameObject PanelQuestionBox;
    //Откуда ожидать ответа(объект, выполняющий запрос на сервер)
    public GameObject ProductionBuildingSendRequest;
    //Панель предметов
    public GameObject PanelSlots;
    public GameObject PanelSlot;
    //Выбор действия пользователем, например покупка, отмена
    public string UserActionSelection; 
    //Имя предмета, который мы хотим произвести, но нехватает ингредиентов
    public string SubjectNameForBuilding;
    //Ожидаем ответа на запрос нехватающих ингредиентов
    public bool CheckResponseLastIngredients;
    //Главная камера
    public GameObject MainCamera;

    //Выбор пользователя
    public void SetUserActionSelection(string actionSelectionName)
    {
        UserActionSelection = actionSelectionName;
    }
    //Очистка панели
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