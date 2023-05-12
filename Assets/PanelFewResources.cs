using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class PanelFewResources : MonoBehaviour
{
    //Главный объект бокс панели ресурсов
    public GameObject PanelFewResourceBox;
    //Откуда ожидать ответа(объект, выполняющий запрос на сервер)
    public GameObject ProductionBuildingSendRequest;
    //public Dictionary<string, int> SubjectAndCount = new Dictionary<string, int>();
    public GameObject PanelSlots;
    public GameObject ButtonBuy;
    public int AllCost; //Стоимость всех объектов для покупки основного
    public string UserActionSelection; //Выбор действия пользователем, например покупка, отмена
    //Имя предмета, который мы хотим произвести, но нехватает ингредиентов
    public string SubjectNameForBuilding;
    //Ожидаем ответа на запрос нехватающих ингредиентов
    public bool CheckResponseMissingIngredients;
    //Ожидаем ответа на запрос общей стоимости в алмазах для изготовления
    public bool CheckResponseAllCost;
    public GameObject MainCamera;
    public bool MainCameraBlock;

    //[ShowInInspector]
    
    //public List<ProductionBuilding.MissingIngredient> MissingIngredients;

    //Необходимы объекты
    // Start is called before the first frame update
    //Выбор пользователя
    public void SetUserActionSelection(string actionSelectionName)
    {
        UserActionSelection = actionSelectionName;
    }
    //Очистка панели
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
        //Перенести это в метод, который будет вызывать панель
        
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
                //Получаем количество ингредиентов в списке
                int countIngredients = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().MissingIngredients.Count;
                ProductionBuilding.MissingIngredient[] missingIngredient = new ProductionBuilding.MissingIngredient[3];
                // копируем в массив элементы из списка недостающих ингредиентов, согласно их количеству (зачем???)
                ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().MissingIngredients.CopyTo(0, missingIngredient, 0, countIngredients);
                for (int i = 0; i <= countIngredients; i++)
                {
                    Debug.Log("for ingredient_name" + i);
                    //Отправляем запрос на сервер чтобы получить информацию (для панели выше объекта) о недостающих предметах
                    ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().GetTranslateInfoRUS(missingIngredient[i].ingredient_name);
                    AddSubjectAndCount(ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().MissingIngredients[i].ingredient_name, ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().MissingIngredients[i].count_ingredients);

                }                              
            }
        }

    }

    public void OnEnable()
    {
        //Сохраняем положение зума камеры
        MainCamera.GetComponent<CameraScript>().SaveOrthographicSize = MainCamera.GetComponent<Camera>().orthographicSize;
        //Примерный размер ортографической камеры 357
        MainCamera.GetComponent<Camera>().orthographicSize = 357;
        //MissingIngredients.Clear();

        //AddSubjectAndCount("wheat", 8);
    }
}
