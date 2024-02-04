using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;


public class ProductionBuildingUI : MonoBehaviour
{
    //==============Свойства здания=======================//
    [SerializeField]
    public GameObject PanelFewResources;
    public GameObject PanelFewResourcesBox;
    public GameObject PanelQuestion;
    public GameObject PanelQuestionBox;
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
    [ShowInInspector]
    public float Count = 0;
    private bool IsCountOn = false;
    private string[,] ArraySlotsLoading;//Массив слотов загрузки 
    private string[,] ArraySlotsShipment;//Массив слотов отгрузки
    public GameObject MainCamera;
    public Vector3 offset; //Смещение
    public Vector3 screenPoint;
    //Сообщения UI для пользователя
    public GameObject MessageUIBox;
    //Цвет последнего колайдера со столкновением
    public string LastMapColliderColor;

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
    public GameObject SlotsLoading;
    //Слоты с отгруженными предметами
    [SerializeField]
    GameObject SlotsShipment;
    public void SetLastMapColliderColor(string color)
    {
        LastMapColliderColor = color;
    }
    public string GetLastMapColliderColor()
    {
       return LastMapColliderColor;
    }
    public void FlipObject()
    {
        Debug.Log("FlipObject()");
        if (gameObject.GetComponent<SpriteRenderer>().flipX) { gameObject.GetComponent<SpriteRenderer>().flipX = false; }
        if (gameObject.GetComponent<SpriteRenderer>().flipX == false) { gameObject.GetComponent<SpriteRenderer>().flipX = true; }
    }
    void Start()
    {

    }
    void SlotPanelSetActiveCheck()
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
    }
    //
    void SlotPredmetSetActiveCheck()
    {
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
    }
    //Режим перемещения
    void MoveModeCheck()
    {
        if (IsMoveModeOn)//Если режим перемещения включен
        {
            //MainCamera.GetComponent<CameraScript>().IsZoomBlocked = false;
            MainCamera.GetComponent<CameraScript>().IsDragBlocked = false;
            SlotsPredmets.SetActive(false);
            SlotsLoading.SetActive(false);
            SlotsPanel.SetActive(true);
            gameObject.tag = "obj_move_mod";
            if (IsCollisionMoveModeOn)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;//Окрашиваем пекарню в красный цвет
            }
            if (IsCollisionMoveModeOn == false)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.white;//Окрашиваем пекарню в белый цвет
            }
            if (gameObject.GetComponent<Renderer>().material.color != Color.red)//Эффект мигания здания. (красный значит, что объект стоит на красном колайдере)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
            }
        }
        else
        {
            //MainCamera.GetComponent<CameraScript>().IsZoomBlocked = true;
            //MainCamera.GetComponent<CameraScript>().IsDragBlocked = true;
            SlotsPanel.SetActive(false);
            Collider.SetActive(false);
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            //gameObject.tag = globals.bakery_type_obj;//Закомментировал, потому что вызывало ошибку
        }
    }

    //счетчик удержания клика на объекте
    void CountModeCheck()
    {

        if (IsCountOn)
        {
            Count += Time.deltaTime;
            //Debug.Log(Count);
            if (Count > 0.0f) { Arrow.GetComponent<Arrow>().BrushColor(0, Color.yellow); }//Закрашена часть стрелки 0
            if (Count > 0.5f) { Arrow.GetComponent<Arrow>().BrushColor(1, Color.yellow); }//Закрашена часть стрелки 1
            if (Count > 0.7f) { Arrow.GetComponent<Arrow>().BrushColor(2, Color.yellow); }//Закрашена часть стрелки 2
            if (Count > 0.8f) { Arrow.GetComponent<Arrow>().BrushColor(3, Color.yellow); }//Закрашена часть стрелки 3
            if (Count > 1.0f) { Arrow.GetComponent<Arrow>().BrushColor(4, Color.yellow); }//Закрашена часть стрелки 4

            if (Count >= 1.0f)//Активация режима перемещение
            {
                //Debug.Log("if (Count >= 1.0f)");
                IsMoveModeOn = true;//Активация режима перемещение
                Arrow.SetActive(false);//Скрытие стрелочки
                Collider.SetActive(true);//Активация коллайдера
                SlotsPanel.SetActive(true);//Включаем панель с кнопкой Flip
                IsCountOn = false;
            }
        }
    }

    /// <returns>true if mouse or first touch is over any event system object ( usually gui elements )</returns>


    void CheckInput()
    {
        PointerEventData pointer = new PointerEventData(EventSystem.current);
        List<RaycastResult> raycastResult = new List<RaycastResult>();
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Check if finger is over a UI element

                        Debug.Log("TouchPhase.Began:");
                        Debug.Log("!!");
                        pointer.position = touch.position;
                        EventSystem.current.RaycastAll(pointer, raycastResult);

                        foreach (RaycastResult result in raycastResult)
                        {
                            Debug.Log("!!!");
                            Debug.Log(result.gameObject.name);
                            Debug.Log(result.gameObject.tag);
                        if (result.gameObject.tag == "ui_interface")
                            {
                            
                            Debug.Log("ui_interface");
                                return;
                            }
                            if (result.gameObject.name == "ProductionBuilding")
                            {
                                //result.gameObject.GetComponent<ButtonController>().ButtonDown();
                                Debug.Log("ProductionBuilding Click");
                                MouseDown();
                            }
                        }
                        raycastResult.Clear();
                        
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Check if finger is over a UI element

                        Debug.Log("TouchPhase.Moved");
                        Debug.Log("!!");
                        pointer.position = touch.position;
                        EventSystem.current.RaycastAll(pointer, raycastResult);

                        foreach (RaycastResult result in raycastResult)
                        {
                            Debug.Log("!!!");
                            Debug.Log(result.gameObject.name);
                            Debug.Log(result.gameObject.tag);
                            if (result.gameObject.tag == "ui_interface")
                            {

                                Debug.Log("ui_interface");
                                return;
                            }
                            else
                            {
                                //result.gameObject.GetComponent<ButtonController>().ButtonDown();
                                Debug.Log("Moved");
                                MouseDrag();
                            }
                        }
                        raycastResult.Clear();
                    break;

                case TouchPhase.Ended:
                    Debug.Log("TouchPhase.Ended:");
                    Debug.Log("!!");
                    pointer.position = touch.position;
                    EventSystem.current.RaycastAll(pointer, raycastResult);

                    foreach (RaycastResult result in raycastResult)
                    {
                        Debug.Log("!!!");
                        Debug.Log(result.gameObject.name);
                        Debug.Log(result.gameObject.tag);
                        if (result.gameObject.tag == "ui_interface")
                        {

                            Debug.Log("ui_interface");
                            return;
                        }
                        if (result.gameObject.name == "ProductionBuilding")
                        {
                            //result.gameObject.GetComponent<ButtonController>().ButtonDown();
                            Debug.Log("ProductionBuilding Click");
                            MouseUp();
                        }
                    }
                    raycastResult.Clear();
                    break;
            }
        }

        // Check if there is a touch
        /*
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

        }
        // Check if there is a touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

        }
        // Check if there is a touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {

        }
        */
        /*
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse was clicked over a UI element
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Input.GetMouseButtonDown(0)");
                MouseDown();
            }
            else
            {
                Debug.Log("Clicked on the UI");
                return;
            }
        }
        
        //Update the Text on the screen depending on current TouchPhase, and the current direction vector
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonUp(0))
        {
            // Check if the mouse was clicked over a UI element
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Input.GetMouseButtonUp(0)");
                MouseUp();
            }
            else
            {
                Debug.Log("Clicked on the UI");
                return;
            }
        }
        */

        // Track a single touch as a direction control.
    }
    // Update is called once per frame
    void MouseDrag()
    {
        if (IsMoveModeOn)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Debug.Log("curScreenPoint="+ curScreenPoint);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            Collider.transform.position = curPosition;
        }
    }
    void Update()
    {
        CheckInput();
        SlotPredmetSetActiveCheck();
        SlotPanelSetActiveCheck();

        MoveModeCheck();
        CountModeCheck();

    }
    public void AddInSlotSubject(string subjectName, string productionBuildingName, int ignoreQuestion)//Метод добавления предмета в слоты
    {
        ///Метод нужен для визуализации и обновления других участников при добавлении в производство
        gameObject.GetComponent<ProductionBuilding>().AddInSlotSubject(subjectName, productionBuildingName, ignoreQuestion, "Local");
        gameObject.GetComponent<ProductionBuilding>().AddInSlotSubject(subjectName, productionBuildingName, ignoreQuestion, "Server");
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

    public void MouseUp()//Когда отпускаешь кнопку
    {
        Count = 0;
        IsCountOn = false;
        Arrow.GetComponent<Arrow>().ClearBrushColorAll();
        Arrow.SetActive(false);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;//Включаем коллайдер обратно
        if (IsMoveModeOn)
        {
            string lastColor = GetLastMapColliderColor();
            Debug.Log("gameObject.GetComponent<SpriteRenderer>().material.color=" + gameObject.GetComponent<SpriteRenderer>().material.color);
            Collider.GetComponent<j1_collider>().MoveMode = IsMoveModeOn;
            if (lastColor == "green")
            {
                //Перемещаем объект на место последнего удачного коллайдера 
                //gameObject.transform.position = PrimaryPosition;//Возвращаем пекарню на начальную точку зачем?
                gameObject.transform.position = Collider.GetComponent<j1_collider>().LastGreenPosition;
                gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;//Делаем нормального цвета
            }
            if (lastColor == "red")
            {
                gameObject.transform.position = Collider.GetComponent<j1_collider>().LastGreenPosition;
                //Collider.transform.position = PrimaryPosition;
                Collider.transform.position = Collider.GetComponent<j1_collider>().LastGreenPosition;
            }

        }
        else//Если IsMoveModeOn==false
        {
            Collider.GetComponent<j1_collider>().MoveMode = IsMoveModeOn;
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
        gameObject.GetComponent<ProductionBuilding>().Shipment(NameSystem, "Local");
        gameObject.GetComponent<ProductionBuilding>().Shipment(NameSystem, "Server");

    }
    public void MouseDown()//Когда нажимаешь кнопку
    {
        if (IsMoveModeOn)//Если режим перемещения активирован
        {
            Collider.GetComponent<j1_collider>().MoveMode = IsMoveModeOn;
            if (gameObject.GetComponent<Renderer>().material.color == Color.white)//Если цвет пекарни обычный
            {
                PrimaryPosition = gameObject.transform.position;//Запоминаем позицию пекарни
            }
        }
        if (IsMoveModeOn == false)//Если режим перемещения не активирован
        {
            //Двигаем камеру к объекту
            MainCamera.GetComponent<ApproachingCamera>().ApproachingStatus = true;
            PrimaryPosition = gameObject.transform.position;//Сохраняем первоначальное положение пекарни
            Arrow.SetActive(true);//Активируем стрелку
            Count = 0;//Обнуляем счетчик
            IsCountOn = true;//Запускаем счетчик 
            Collider.GetComponent<j1_collider>().MoveMode = IsMoveModeOn;
        }
    }

}
