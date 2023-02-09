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
    int OpenSlotsDefault;//Открытых слотов по умолчанию
    int OpenSlots; //Открытых слотов
    Vector3 PrimaryPosition;
    string Temp;
    public Coroutine UserWaitingCoroutine; //Ожидание пользователя
    private bool IsMoveModeOn = false;
    private bool IsCollisionMoveModeOn = false;
    private int Count = 0;
    private bool IsCountOn = false;
    private string[,] ArraySlotsLoading;//Массив слотов загрузки 
    private string[,] ArraySlotsShipment;//Массив слотов отгрузки
    

    //=======Дочерние и другие объекты================//
    GameObject Collider; //Коллайдер для здания
    GameObject Arrow;//Стрелка загрузки, используемая как временная шкала
    GameObject SlotsPanel;//Слоты с панелями кнопок
    GameObject SlotsPredmets; //Слоты с предметами
    GameObject SlotsLoading; //Слоты с загруженными предметами
    GameObject SlotsShipment; //Слоты с отгруженными предметами


    public void FlipObject()
    {
        if (gameObject.GetComponent<SpriteRenderer>().flipX) {gameObject.GetComponent<SpriteRenderer>().flipX = false; }
        if (gameObject.GetComponent<SpriteRenderer>().flipX == false) {gameObject.GetComponent<SpriteRenderer>().flipX = true; }
    }
    void Start()
    {
        
        //SlotsPanel = gameObject.transform.Find("SlotsPanel").gameObject;//Find Child gameobject
        Collider = gameObject.transform.Find("Collider").gameObject;
        Arrow = gameObject.transform.Find("Arrow").gameObject;
        SlotsPanel = gameObject.transform.Find("SlotsPanel").gameObject;
        SlotsPredmets = gameObject.transform.Find("SlotsPredmets").gameObject;
        SlotsLoading = gameObject.transform.Find("SlotsLoading").gameObject;
        SlotsShipment = gameObject.transform.Find("SlotsShipment").gameObject;
        
        //AddInSlotSubject("bread");

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
            if (Count == 6){ Arrow.GetComponent<Arrow>().BrushColor("Arrow0", Color.yellow); }//Закрашена часть стрелки 0
            if (Count == 12) { Arrow.GetComponent<Arrow>().BrushColor("Arrow1", Color.yellow); }//Закрашена часть стрелки 1
            if (Count == 18) { Arrow.GetComponent<Arrow>().BrushColor("Arrow2", Color.yellow); }//Закрашена часть стрелки 2
            if (Count == 24) { Arrow.GetComponent<Arrow>().BrushColor("Arrow3", Color.yellow); }//Закрашена часть стрелки 3
            if (Count == 30) { Arrow.GetComponent<Arrow>().BrushColor("Arrow4", Color.yellow); }//Закрашена часть стрелки 4

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

    public void AddInSlotSubject(string subjectName, string productionBuildingName)//Метод добавления предмета в слоты
    {
        // Проверяем, нужно ли выгрузить готовые предметы(Проверяется на сервере)
        Debug.Log("AddInSlotSubject: " + subjectName);
        Debug.Log("AddInSlotSubject(subjectName)" + subjectName);
        Debug.Log("AddInSlotSubject(productionBuildingName)" + productionBuildingName);

        //Количество открытых слотов у пользователя.
        //int countOpenSlotsUser = Data.GetComponent<ProgressSlots>().GetOpenSlotsCount(productionBuildingName);
        int countOpenSlotsUser = 1;
        Debug.Log("AddInSlotSubject(countOpenSlotsUser)" + countOpenSlotsUser);
        //Получаем количество занятых слотов по имени Родителя(т.е в данном случае производствнного здания)слоты отгрузки
        int countOfOccupiedShipmentSlots = Data.GetComponent<Contents>().GetCountOfOccupiedShipmentSlotsByParentName(subjectName);
        Debug.Log("AddInSlotSubject(countOfOccupiedShipmentSlots)" + countOfOccupiedShipmentSlots);
        //Получаем значение открытых слотов пользователя по имени объекта
        int openSlotsLoadingDefaults = Data.GetComponent<OpenSlotsDefaults>().GetOpenSlotsLoadingBySubjectName(productionBuildingName);
        Debug.Log("AddInSlotSubject(openSlotsLoadingDefaults)" + openSlotsLoadingDefaults);
        //Если количество занятых слотов, больше,либо равно открытым слотам по дефолту
        //Проверяем,сколько слотов занято производством
        int countOfOccupiedLoadingSlots = Data.GetComponent<Contents>().GetCountOfOccupiedLoadingSlotsByParentName(subjectName);
        Debug.Log("AddInSlotSubject(countOfOccupiedLoadingSlots)" + countOfOccupiedLoadingSlots);
        //Если количество отгруженных товаров, превышает число дефолтных значений слотов отгрузки
        if (countOfOccupiedShipmentSlots >= openSlotsLoadingDefaults)
        {
            Debug.Log("Собери руду, чтобы продолжить добычу");
            Debug.Log("Собери готовую продукцию, чтобы продолжить изготовление");//Пример заглушки, но нужно будет создать таблицу с данными.
            return;
        }
        //Если количество загруженных в производство объектов>=открытых у пользователя 
        if (countOfOccupiedLoadingSlots >= countOpenSlotsUser)
        {
            Debug.Log("Все слоты заняты! Подожди, ускорь или докупи ячейки!");
            return;
        }
        //Если количество загруженных в производство объектов<открытых у пользователя 
        if (countOfOccupiedLoadingSlots < countOpenSlotsUser)
        {
            Debug.Log("countOfOccupiedLoadingSlots < countOpenSlotsUser");
            //Полуаем список ингредиентов (ингредиент, количество)
            Dictionary<string, int> compositions = new Dictionary<string, int>();
            //compositions = Data.GetComponent<Ingredients>().GetCompositions(subjectName);
            int allPriceSubjects = 0; //Общая стоимость необходимых ингредиентов
            //Запускаем цикл из ключей компонентов, объектов которых нехватает
            foreach (KeyValuePair<string, int> composition in compositions)
            {
                //Key - название компонента, Value - значение
                Console.WriteLine("Key = {0}, Value = {1}", composition.Key, composition.Value);
                //Получаем идентификатор пользователя
                int userID = 1; //Data.GetComponent<Users>().GetIDUser();
                //Получаем количество ингредиентов на складе
                //int subjectSum = Data.GetComponent<SubjectsSum>().GetSubjectSumCountByName(composition.Key, userID);
                int subjectSum = 3;

                //Проверяем, хватает ли ресурсов
                //Если ингредиентов на складе меньше, чем нужно для изготовления
                if (subjectSum < composition.Value)
                {
                    //Количество недостающих объектов
                    int missSubjectCount = (composition.Value-subjectSum);
                    //PanelFewResources.GetComponent<PanelFewResources>().ClearPanel();
                    //Узнаем стоимость объекта в алмазах
                    int priceSubject = (Data.GetComponent<PriceSubjects>().GetPriceDiamondsByNameSubject(composition.Key) * missSubjectCount);
                    //Прибавляем стоимость
                    allPriceSubjects += priceSubject;
                    Debug.Log("Стоимость предмета в сумме=" + priceSubject);
                    Debug.Log("Стоимость всех предметов=" + allPriceSubjects);
                    //Display.displays[1].Activate();
                    PanelFewResources.SetActive(true);
                    PanelFewResources.GetComponent<PanelFewResources>().AddSubjectAndCount(composition.Key, missSubjectCount);

                    //PanelFewResources.GetComponent<PanelFewResources>().
                    //Считаем сколько именно не хватает ингредиентов.
                    Debug.Log("Не хватает:" + (composition.Value - subjectSum).ToString());
                    //Рассчитываем каких и сколько не хватает ингредиентов и предлагаем их купить за алмазы.
                    //Для этого лучше создать класс?
                }
            }
            //Если ресурсов не хватает, передаем информацию в панель покупки ресурсов, чтобы там посчитать стоимость
            PanelFewResources.GetComponent<PanelFewResources>().SetButtonBuyTextCount(allPriceSubjects);
            //Предварительно очищаем панель ресурсов
            PanelFewResources.GetComponent<PanelFewResources>().CleanerPanel();
            PanelFewResourcesBox.SetActive(true);
            Debug.Log(" PanelFewResourcesBox.SetActive(true);");
            //Тут ожидаем решение от пользователя
            StartCoroutine(Cutscene());

            //Если пользователь выбрал покупку за алмазы
            //Процесс покупки за алмазы и проверка хватает ли ему алмазов.
            //Если всего хватает, запускаем выбранный предмет в производство
            //Закрываем панель
            //PanelFewResourcesBox.SetActive(false);
            //Напрямую не удалятьPanelFewResourcesBox.SetActive(false);
            //Узнаем и указываем стоимость компонентов

            //Загружаем новый объект в производство
        }
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
        GameObject_Enable_Controller.bakery_arrow_0.GetComponent<Renderer>().material.color = Color.white;
        GameObject_Enable_Controller.bakery_arrow_1.GetComponent<Renderer>().material.color = Color.white;
        GameObject_Enable_Controller.bakery_arrow_2.GetComponent<Renderer>().material.color = Color.white;
        GameObject_Enable_Controller.bakery_arrow_3.GetComponent<Renderer>().material.color = Color.white;
        GameObject_Enable_Controller.bakery_arrow_4.GetComponent<Renderer>().material.color = Color.white;
        GameObject_Enable_Controller.bakery_arrow.SetActive(false);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;//Включаем коллайдер пекарни обратно
        if (globals.bakery_move_mode_on)
        {

            if (gameObject.GetComponent<Renderer>().material.color == Color.red)
            {
                gameObject.transform.position = PrimaryPosition;//Возвращаем пекарню на начальную точку
                gameObject.GetComponent<Renderer>().material.color = Color.white;//Делаем нормального цвета
            }
            if (gameObject.GetComponent<Renderer>().material.color == Color.white)
            {
                gameObject.transform.position = PrimaryPosition;
                GameObject.Find("bakery_collider").transform.position = PrimaryPosition;
            }

        }
        else//Если globals.bakery_move_mode_on==false
        {

            if (GameObject_Enable_Controller.bakery_slots_predmets.activeSelf)
            {
                GameObject_Enable_Controller.bakery_slots_zagruzki.SetActive(false);
                GameObject_Enable_Controller.bakery_slots_predmets.SetActive(false);
            }
            else
            {
                GameObject_Enable_Controller.bakery_slots_zagruzki.SetActive(true);
                GameObject_Enable_Controller.bakery_slots_predmets.SetActive(true);
            }
        }
        if (globals.bakery_array_slots_otgruzki[0, 0] != "")//Если слоты отгрузки не пустые, переместить этот код в другое место
        {
            if (globals.bakery_array_slots_otgruzki[0, 0] == "bread")
            {
                Debug.Log("bread mouseup");
                globals.bread++;//Прибавляем количество хлеба на склад
                Debug.Log("bread = " + globals.bread);
                globals.user_experience_point = globals.user_experience_point + globals.bread_experience_point;
                Debug.Log("globals.user_experience_point=" + globals.user_experience_point);
                globals.bakery_array_slots_otgruzki[0, 0] = ""; //Очищаем слот, из которого выгрузили
                globals.bakery_array_slots_otgruzki[0, 1] = ""; //Очищаем слот, из которого выгрузили
                globals.bakery_array_slots_otgruzki[0, 2] = ""; //Очищаем слот, из которого выгрузили
                return;
            }
            if (globals.bakery_array_slots_otgruzki[0, 0] == "corn_bread")
            {
                Debug.Log("corn_bread mouseup");
                globals.corn_bread++;//Прибавляем количество хлеба на склад
                Debug.Log("corn_bread = " + globals.corn_bread);
                globals.user_experience_point = globals.user_experience_point + globals.corn_bread_experience_point;
                Debug.Log("globals.user_experience_point" + globals.user_experience_point);
                globals.bakery_array_slots_otgruzki[0, 0] = ""; //Очищаем слот, из которого выгрузили
                globals.bakery_array_slots_otgruzki[0, 1] = ""; //Очищаем слот, из которого выгрузили
                globals.bakery_array_slots_otgruzki[0, 2] = ""; //Очищаем слот, из которого выгрузили
                return;
            }
            if (globals.bakery_array_slots_otgruzki[0, 0] == "cookie")
            {
                Debug.Log("cookie mouseup");
                globals.cookie++;//Прибавляем количество хлеба на склад
                Debug.Log("cookie = " + globals.cookie);
                globals.user_experience_point = globals.user_experience_point + globals.cookie_experience_point;
                Debug.Log("globals.user_experience_point" + globals.user_experience_point);
                globals.bakery_array_slots_otgruzki[0, 0] = ""; //Очищаем слот, из которого выгрузили
                globals.bakery_array_slots_otgruzki[0, 1] = ""; //Очищаем слот, из которого выгрузили
                globals.bakery_array_slots_otgruzki[0, 2] = ""; //Очищаем слот, из которого выгрузили
                return;
            }
        }
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
            GameObject_Enable_Controller.bakery_arrow.SetActive(true);//Активируем стрелку
            Count = 0;//Обнуляем счетчик
            IsCountOn = true;//Запускаем счетчик 
        }
    }
    void OnMouseDrag()//Когда перемещение мыши
    {

    }

}
