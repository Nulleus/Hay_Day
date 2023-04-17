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
    public int AllCost; //Стоимость всех объектов для покупки основного
    public string UserActionSelection; //Выбор действия пользователем, например покупка, отмена
    //Имя предмета, который мы хотим произвести, но нехватает ингредиентов
    public string SubjectNameForBuilding;
    //Ожидаем ответа на запрос нехватающих ингредиентов
    public bool CheckResponseMissingIngredients;
    //Ожидаем ответа на запрос общей стоимости в алмазах для изготовления
    public bool CheckResponseAllCost;
    [ShowInInspector]
    
    public List<ProductionBuilding.MissingIngredient> MissingIngredients;

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
            //Получаем недостающие ингредиенты
            //gameObject.GetComponent<ProductionBuilding>().GetMissingIngredients(SubjectNameForBuilding);
            //Переносим список недостающих ингредиентов в этот модуль
            //MissingIngredients = GOProductionBuilding.GetComponent<ProductionBuilding>().MissingIngredients;
            //MissingIngredients = gameObject.GetComponent<ProductionBuilding>().MissingIngredients;
            //Получаем количество ингредиентов в списке
            int countIngredients = MissingIngredients.Count;
            //Массив из недостающих ингредиентов
            ProductionBuilding.MissingIngredient[] missingIngredient = new ProductionBuilding.MissingIngredient[3];
            // копируем в массив элементы из списка недостающих ингредиентов, согласно их количеству
            MissingIngredients.CopyTo(0, missingIngredient, 0, countIngredients);
            //Заполним описание для ингредиентов

            for (int i = 0; i <= countIngredients; i++)
            {
                Debug.Log(i);
                AddSubjectAndCount(missingIngredient[i].ingredient_name, missingIngredient[i].count_ingredients);
            }
            //Если переменная пустая и проверка включена, пытаемся 

        }

    }

    public void OnEnable()
    {
        MissingIngredients.Clear();
        
        //AddSubjectAndCount("wheat", 8);
    }
}
