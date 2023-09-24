using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class PanelQuestion : MonoBehaviour
{
    //Главный объект бокс панели
    public GameObject PanelQuestionBox;
    //Откуда ожидать ответа(объект, выполняющий запрос на сервер)
    public GameObject ProductionBuildingSendRequest;
    //Панель предметов
    public GameObject PanelSlots;
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

    }
    void Update()
    {
        if (CheckResponseLastIngredients)
        {
            Debug.Log("MissingIngredients.Count" + ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().LastIngredients.Count);
            if (ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().LastIngredients.Count > 0)
            {
                CheckResponseLastIngredients = false;
                //Получаем количество последних предметов в списке
                int countLastSubjects = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().LastIngredients.Count;
                ProductionBuilding.LastIngredient[] lastIngredient = new ProductionBuilding.LastIngredient[3];
                // копируем в массив элементы из списка недостающих ингредиентов, согласно их количеству
                ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().LastIngredients.CopyTo(0, lastIngredient, 0, countLastSubjects);
                for (int i = 0; i <= countLastSubjects; i++)
                {
                    Debug.Log("for last_name" + i);
                    //Отправляем запрос на сервер чтобы получить информацию о последних предметах
                    ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().GetTranslateInfoRUS(lastIngredient[i].lastIngredients);
                }
            }
            else
            {
                //Получаем недостающие ингредиенты
                //Получаем количество последних предметов в списке
                int countLastSubjects = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().LastIngredients.Count;
                Debug.Log("countIngredients=" + countLastSubjects);

                for (int i = 0; i <= countLastSubjects; i++)
                {
                    Debug.Log("for countLastSubjects" + i);
                    //Клонируем объекты                   
                    AddSubjectAndCount(ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().LastIngredients[i].lastIngredients, 0);
                }
                //Если переменная пустая и проверка включена, пытаемся 
            }


        }

    }

    public void OnEnable()
    {

    }
}