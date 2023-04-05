using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class ProductionBuildingUI : MonoBehaviour
{
    //==============Свойства здания=======================//
    [SerializeField]
    public GameObject PanelFewResources;
    public GameObject PanelFewResourcesBox;
    public string NameSystem;//Системное имя объекта
    public GameObject Data;
    public GameObject PanelSlots; //
    [SerializeField]
    string NameView;//Отображаемое имя объекта
    int OpenLevel;// Уровень, на котором открывается объект
    int PriceCoins;//Цена здания в монетах
    int BuildingTimeSec;//Время постройки здания в секундах
    int PriceDiamondsForMaxTimes;//Стоимость ускорения постройки здания в алмазах
    int OpenSlotsDefault;//Открытых слотов по умолчанию(думаю это не пригодится)
    int OpenSlots; //Открытых слотов
    Vector3 PrimaryPosition;
    string Temp;
    public Coroutine UserWaitingCoroutine; //Ожидание пользователя
    public bool IsMoveModeOn = false;
    private bool IsCollisionMoveModeOn = false;
    private int Count = 0;
    private bool IsCountOn = false;
    private string[,] ArraySlotsLoading;//Массив слотов загрузки 
    private string[,] ArraySlotsShipment;//Массив слотов отгрузки


    //=======Дочерние и другие объекты================//

    //Коллайдер для здания
    [SerializeField]
    GameObject Collider;
    //Стрелка загрузки, используемая как временная шкала
    [SerializeField]
    GameObject Arrow;
    //Слоты с панелями кнопок
    [SerializeField]
    GameObject SlotsPanel;
    //Слоты с предметами загрузки
    [SerializeField]
    GameObject SlotsPredmets;
    //Слоты с загруженными предметами
    [SerializeField]
    GameObject SlotsLoading;
    //Слоты с отгруженными предметами
    [SerializeField]
    GameObject SlotsShipment; 


    public void FlipObject()
    {
        Debug.Log("FlipObject()");
        if (gameObject.GetComponent<SpriteRenderer>().flipX) {gameObject.GetComponent<SpriteRenderer>().flipX = false; }
        if (gameObject.GetComponent<SpriteRenderer>().flipX == false) {gameObject.GetComponent<SpriteRenderer>().flipX = true; }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Проверяем, активена ли панель со слотами
        if (SlotsPanel.activeSelf)
        {
            //Если активна, тогда диактивируем ее
            SlotsPanel.SetActive(false);
        }
        else
        {
            //Если не активна, активируем ее
            SlotsPanel.SetActive(true);
        }

        //Если слоты с предметами активны
        if (SlotsPredmets.activeSelf)
        {
            SlotsPredmets.SetActive(true);
            SlotsLoading.SetActive(true);
        }
        else
        {
            SlotsPredmets.SetActive(false);
            SlotsLoading.SetActive(false);
        }
        if (IsMoveModeOn)//Если режим перемещения включен
        {
            SlotsPredmets.SetActive(false);
            SlotsLoading.SetActive(false);
            SlotsPanel.SetActive(true);
            gameObject.tag = "obj_move_mod";
     
            if (IsCollisionMoveModeOn)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;//Окрашиваем пекарню в красный цвет
            }
            if (IsCollisionMoveModeOn==false)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.white;//Окрашиваем пекарню в белый цвет
            }
            if (gameObject.GetComponent<Renderer>().material.color != Color.red)//Эффект мигания здания. (красный значит, что объект стоит на красном колайдере)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
            }


        }
        if (IsMoveModeOn==false)
        {
            SlotsPanel.SetActive(false);
            Collider.SetActive(false);
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            //gameObject.tag = globals.bakery_type_obj;//Закомментировал, потому что вызывало ошибку
        }
        if (IsCountOn)
        {
            Count++;
            if (Count == 6){ Arrow.GetComponent<Arrow>().BrushColor(1, Color.yellow); }//Закрашена часть стрелки 0
            if (Count == 12) { Arrow.GetComponent<Arrow>().BrushColor(2, Color.yellow); }//Закрашена часть стрелки 1
            if (Count == 18) { Arrow.GetComponent<Arrow>().BrushColor(3, Color.yellow); }//Закрашена часть стрелки 2
            if (Count == 24) { Arrow.GetComponent<Arrow>().BrushColor(4, Color.yellow); }//Закрашена часть стрелки 3
            if (Count == 30) { Arrow.GetComponent<Arrow>().BrushColor(5, Color.yellow); }//Закрашена часть стрелки 4

            if (Count > 30)//Активация режима перемещение
            {
                IsMoveModeOn = true;//Активация режима перемещение
                Arrow.SetActive(false);//Скрытие стрелочки
                Collider.SetActive(true);//Активация коллайдера
                SlotsPanel.SetActive(true);//Включаем панель с кнопкой Flip
                IsCountOn = false;
            }
        }
    }
    public void AddInSlotSubject(string subjectName, string productionBuildingName, int ignoreQuestion)//Метод добавления предмета в слоты
    {
        ///Метод нужен для визуализации и обновления других участников при добавлении в производство
        gameObject.GetComponent<ProductionBuilding>().AddInSlotSubject(subjectName, productionBuildingName, ignoreQuestion);
        
    }
    //Ожидание выбора действия от пользователя
    IEnumerator Cutscene()
    {
        //Cutscene Stuff
        Debug.Log(" IEnumerator Cutscene()");
        Debug.Log(PanelFewResources.GetComponent<PanelFewResources>().UserActionSelection);
        while (PanelFewResources.GetComponent<PanelFewResources>().UserActionSelection == "")
        {
            Debug.Log(PanelFewResources.GetComponent<PanelFewResources>().UserActionSelection);
            //PanelFewResources.SetActive(false);
            yield return null;
        }
        if (PanelFewResources.GetComponent<PanelFewResources>().UserActionSelection == "buyForDaemonds")
        {
            Debug.Log("StopCorutine");
            Debug.Log("PanelFewResourcesBox.SetActive(false);");
            PanelFewResources.GetComponent<PanelFewResources>().UserActionSelection = "";
            PanelFewResources.GetComponent<PanelFewResources>().CleanerPanel();
            PanelFewResourcesBox.SetActive(false);
        }
        //More Cutscene Stuff and End the cutscene
    }

    void OnMouseUp()//Когда отпускаешь кнопку
    {
        Count = 0;
        IsCountOn = false;
        Arrow.GetComponent<Arrow>().ClearBrushColorAll();
        Arrow.SetActive(false);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;//Включаем коллайдер обратно
        if (IsMoveModeOn)
        {

            if (gameObject.GetComponent<Renderer>().material.color == Color.red)
            {
                gameObject.transform.position = PrimaryPosition;//Возвращаем пекарню на начальную точку
                gameObject.GetComponent<Renderer>().material.color = Color.white;//Делаем нормального цвета
            }
            if (gameObject.GetComponent<Renderer>().material.color == Color.white)
            {
                gameObject.transform.position = PrimaryPosition;
                Collider.transform.position = PrimaryPosition;
            }

        }
        else//Если IsMoveModeOn==false
        {

            if (SlotsPredmets.activeSelf)
            {
                SlotsLoading.SetActive(false);
                SlotsPredmets.SetActive(false);
            }
            else
            {
                SlotsLoading.SetActive(true);
                SlotsPredmets.SetActive(true);
            }
        }
        //Метод открузки предметов
        gameObject.GetComponent<ProductionBuilding>().Shipment(NameSystem);
        
    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {
        if (IsMoveModeOn)//Если режим перемещения активирован
        {
            if (gameObject.GetComponent<Renderer>().material.color == Color.white)//Если цвет пекарни обычный
            {
                PrimaryPosition = gameObject.transform.position;//Запоминаем позицию пекарни
            }
        }
        if (IsMoveModeOn == false)//Если режим перемещения не активирован
        {

            PrimaryPosition = gameObject.transform.position;//Сохраняем первоначальное положение пекарни
            Arrow.SetActive(true);//Активируем стрелку
            Count = 0;//Обнуляем счетчик
            IsCountOn = true;//Запускаем счетчик 
        }
    }
    void OnMouseDrag()//Когда перемещение мыши
    {

    }

}
