using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class ProductionBuilding : MonoBehaviour
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

    public void AddInSlotSubject(string subjectName)//Метод добавления предмета в слоты
    {
        // Проверяем, нужно ли выгрузить готовые предметы
        Debug.Log("AddInSlotSubject: " + subjectName);
        //Если все слоты заняты, не загружать
        //Получаем Родителя объекта по имени ребенка
        string subjectChildName = Data.GetComponent<ParentsAndChilds>().GetSubjectParentNameBySubjectChildName(subjectName);
        Debug.Log("AddInSlotSubject(subjectChildName)" + subjectChildName);
        //countOpenSlotsUser - отвечает за количество открытых слотов у определенного пользователя по его id
        //Получаем имя производственного здания по имени ребнка
        string subjectNameChild = Data.GetComponent<ParentsAndChilds>().GetSubjectParentNameBySubjectChildName(subjectName);
        Debug.Log("AddInSlotSubject(subjectNameChild)" + subjectNameChild);
        //Количество открытых слотов у пользователя.
        int countOpenSlotsUser = Data.GetComponent<ProgressSlots>().GetOpenSlotsCount(subjectNameChild,1 /*Data.GetComponent<Users>().*/);
        //Debug.Log("AddInSlotSubject(IDUser)" + Data.GetComponent<Users>().IDUser);
        Debug.Log("AddInSlotSubject(countOpenSlotsUser)" + countOpenSlotsUser);
        //Получаем количество занятых слотов по имени Родителя(т.е в данном случае производствнного здания)слоты отгрузки
        int countOfOccupiedShipmentSlots = Data.GetComponent<Contents>().GetCountOfOccupiedShipmentSlotsByParentName(subjectName);
        Debug.Log("AddInSlotSubject(countOfOccupiedShipmentSlots)" + countOfOccupiedShipmentSlots);
        //Получаем дефолтное значение открытых слотов по имени объекта
        int openSlotsLoadingDefaults = Data.GetComponent<OpenSlotsDefaults>().GetOpenSlotsLoadingBySubjectName(subjectChildName);
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
                int subjectSum = Data.GetComponent<SubjectsSum>().GetSubjectSumCountByName(composition.Key, userID);

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
    //Вычитать ресурсы со склада, а если это последняя культура, предупредить
    //DateTime time_slot;
    // Debug.Log("add: " + subjectName);
    //int building_time = 20;//Время сборки
    //GameObject GO = GameObject.Find(subjectName);//Поиск объекта, например Bread

    //string[] ingredients = GO.GetComponent<Ingredients>().GetAllKeysSubjects();//Получаем список ингредиентов
    //Поиск объекта из массива
    /*
    foreach (string ingredient in ingredients)//Перебор найденных ингредиентов
    {
        //Если найденый ингредиент и его количество на складе минус(необходимое количество для производства)>=0, тогда выполняем действие
        if (GameObject.Find(ingredient).GetComponent<Subject>().GetCount() - GO.GetComponent<Ingredients>().GetCountByName(ingredient) >= 0)
        {
            //Вычитаем количество предмета через сетод SetCount
            GameObject.Find(ingredient).GetComponent<Subject>().SetCount(GO.GetComponent<Ingredients>().GetCountByName(ingredient));
        }
        else
        {
            Debug.Log("Не хватает ингредиентов!");
            //Добавляем в SlotInfo, ингредиенты, которых не хватает и их количество
            //Предмет

            //Количество, которого не хватает = Количество ингредиентов на складе - Необходимое количество ингредиентов для производства
            //var countMissing = (GameObject.Find(ingredient).GetComponent<Subject>().GetCount() - GO.GetComponent<Ingredients>().GetCountByName(ingredient)) * (-1);//-1 Для получения положительного числа(сколько нехватает ингредиентов)
            //Информация для Панели слота инфо с 
            //Не тут лолжно быть, а на MouseDown SlotInfo.GetComponent<SlotInfo>().AddMissingIngredient(GameObject.Find(ingredient), GO.GetComponent<Ingredients>().GetCountByName(ingredient).ToString());
        }
    }
    */
    /*if (subjectName == "bread")
    {



        //Проверка наличия всех ингридиентов
        if (1>2)
        {

            //globals.wheat = globals.wheat - 3;
        }
        else
        {
            Debug.Log("Не хватает ингредиентов!");
            //GameObject.Find("")
            globals.price_for_diamonds_panel_current_item = subjectName;//Присваиваем переменной предмет, у которого не хватает ингредиентов
            globals.price_for_diamonds_panel_slot_0_quantity = (globals.wheat - 3) * (-1);
            globals.price_for_diamonds_panel_slot_0_predmet_name = "wheat";
            globals.price_for_diamonds_panel_slot_1_quantity = 0;
            globals.price_for_diamonds_panel_slot_1_predmet_name = "empty";
            globals.price_for_diamonds_panel_slot_2_quantity = 0; ;
            globals.price_for_diamonds_panel_slot_2_predmet_name = "empty";
            globals.price_for_diamonds_panel_slot_3_quantity = 0;
            globals.price_for_diamonds_panel_slot_3_predmet_name = "empty";
            globals.price_for_diamonds_panel_button_ok_diamonds_quantity = globals.wheat_price_for_diamonds * globals.price_for_diamonds_panel_slot_0_quantity;
            GameObject_Enable_Controller.price_for_diamonds_panel.SetActive(true);
            GameObject_Enable_Controller.price_for_diamonds_panel_slot_0.SetActive(true);
            GameObject_Enable_Controller.price_for_diamonds_panel_slot_1.SetActive(false);
            GameObject_Enable_Controller.price_for_diamonds_panel_slot_2.SetActive(false);
            GameObject_Enable_Controller.price_for_diamonds_panel_slot_3.SetActive(false);
            return;
        }
    }
    if (subjectName == "corn_bread")
    {
        building_time = 10;//Время сборки

        if ((globals.corn - 2 >= 0) && (globals.egg - 2 >= 0))//Если всего хватает
        {
            globals.corn = globals.corn - 2;
            globals.egg = globals.egg - 2;
        }
        else
        {
            Debug.Log("Не хватает ингредиентов!");
            Debug.Log("corn:" + globals.corn + "egg:" + globals.egg);
            globals.price_for_diamonds_panel_current_item = subjectName;//Присваиваем переменной предмет, у которого не хватает ингредиентов
            if ((globals.corn - 2 < 0) && (globals.egg - 2 < 0))//Если не хватает и кукурузы и яиц
            {
                globals.price_for_diamonds_panel_slot_0_quantity = (globals.corn - 2) * -1;//Считаем, количество продуктов, которых нехватает, умножаем на1, чтобы избавится от минуса
                globals.price_for_diamonds_panel_slot_0_predmet_name = "corn";
                globals.price_for_diamonds_panel_slot_0_predmet_info = "Сбор урожая через 2м.";
                globals.price_for_diamonds_panel_slot_0_predmet_building_time = "2 м.";
                globals.price_for_diamonds_panel_slot_1_quantity = (globals.egg - 2) * -1;//Считаем, количество продуктов, которых нехватает
                globals.price_for_diamonds_panel_slot_1_predmet_name = "egg";
                globals.price_for_diamonds_panel_slot_1_predmet_info = "Берется у кур.";
                globals.price_for_diamonds_panel_slot_1_predmet_building_time = "20 м.";
                globals.price_for_diamonds_panel_slot_2_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_2_quantity = 0;
                globals.price_for_diamonds_panel_slot_3_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_3_quantity = 0;
                //Количество необходимых алмазов = цена продукта в алмазах * количество
                globals.price_for_diamonds_panel_button_ok_diamonds_quantity =
                                              (globals.corn_price_for_diamonds * globals.price_for_diamonds_panel_slot_0_quantity) +
                                              (globals.egg_price_for_diamonds * globals.price_for_diamonds_panel_slot_1_quantity);
                Debug.Log("globals.price_for_diamonds_panel_button_ok_diamonds_quantity=" + globals.price_for_diamonds_panel_button_ok_diamonds_quantity);
                Debug.Log("globals.price_for_diamonds_panel_slot_0_quantity=" + globals.price_for_diamonds_panel_slot_0_quantity);
                Debug.Log("globals.egg_price_for_diamonds=" + globals.egg_price_for_diamonds);
                Debug.Log("globals.price_for_diamonds_panel_slot_1_quantity=" + globals.price_for_diamonds_panel_slot_1_quantity);
                GameObject_Enable_Controller.price_for_diamonds_panel.SetActive(true);//Открываем форму не хватки ресурсов
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_0.SetActive(true);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_1.SetActive(true);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_2.SetActive(false);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_3.SetActive(false);
                return;
            }
            if (globals.corn - 2 < 0)//Если не хватило только кукурузы
            {

                globals.price_for_diamonds_panel_slot_0_quantity = (globals.corn - 2) * -1;//Считаем, количество продуктов, которых нехватает, умножаем на1, чтобы избавится от минуса
                globals.price_for_diamonds_panel_slot_0_predmet_name = "corn";
                globals.price_for_diamonds_panel_slot_1_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_1_quantity = 0;
                globals.price_for_diamonds_panel_slot_2_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_2_quantity = 0;
                globals.price_for_diamonds_panel_slot_3_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_3_quantity = 0;
                //Количество необходимых алмазов = цена продукта в алмазах * количество
                globals.price_for_diamonds_panel_button_ok_diamonds_quantity = globals.corn_price_for_diamonds * globals.price_for_diamonds_panel_slot_0_quantity;
                GameObject_Enable_Controller.price_for_diamonds_panel.SetActive(true);//Открываем форму нехватки ресурсов
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_0.SetActive(true);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_1.SetActive(false);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_2.SetActive(false);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_3.SetActive(false);
                return;
            }
            if (globals.egg - 2 < 0)//Если не хватило только яиц
            {
                Debug.Log("Не хватило только яиц");
                globals.price_for_diamonds_panel_slot_0_quantity = (globals.egg - 2) * -1;//Считаем, количество продуктов, которых нехватает
                globals.price_for_diamonds_panel_slot_0_predmet_name = "egg";
                globals.price_for_diamonds_panel_slot_1_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_1_quantity = 0;
                globals.price_for_diamonds_panel_slot_2_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_2_quantity = 0;
                globals.price_for_diamonds_panel_slot_3_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_3_quantity = 0;
                //Количество необходимых алмазов = цена продукта в алмазах * количество
                //GameObject_Enable_Controller.price_for_diamonds_panel_button_ok_diamonds_quantity.GetComponent<Text>().text = (globals.egg_price_for_diamonds * globals.price_for_diamonds_panel_slot_0_quantity).ToString();
                globals.price_for_diamonds_panel_button_ok_diamonds_quantity = globals.egg_price_for_diamonds * globals.price_for_diamonds_panel_slot_0_quantity;
                Debug.Log("globals.price_for_diamonds_panel_button_ok_diamonds_quantity=" + globals.price_for_diamonds_panel_button_ok_diamonds_quantity);
                GameObject_Enable_Controller.price_for_diamonds_panel.SetActive(true);//Открываем форму нехватки ресурсов
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_0.SetActive(true);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_1.SetActive(false);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_2.SetActive(false);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_3.SetActive(false);
                return;

            }

            return;
        }
    }
    if (subjectName == "cookie")
    {
        building_time = 10;
        //building_time = globals.cookie_building_time;//Время сборки, добавить сюда глобальную переменную
        if ((globals.brown_sugar - 1 >= 0) && (globals.egg - 2 >= 0) && (globals.wheat - 2 >= 0))//Если всего хватает
        {
            globals.brown_sugar = globals.brown_sugar - 1;
            globals.egg = globals.egg - 2;
            globals.wheat = globals.wheat - 2;
        }
        else
        {
            Debug.Log("Не хватает ингредиентов!");
            Debug.Log("brown_sugar:" + globals.brown_sugar + "egg:" + globals.egg + "globals.wheat" + globals.wheat);
            globals.price_for_diamonds_panel_current_item = subjectName;//Присваиваем переменной предмет, у которого не хватает ингредиентов
            if ((globals.brown_sugar - 1 < 0) && (globals.egg - 2 < 0) && (globals.wheat - 2 < 0))//Если не хватает коричневого сахара и яиц и пшеницы
            {
                globals.price_for_diamonds_panel_slot_0_quantity = (globals.brown_sugar - 1) * -1;//Считаем, количество продуктов, которых нехватает, умножаем на1, чтобы избавится от минуса
                globals.price_for_diamonds_panel_slot_0_predmet_name = "brown_sugar";
                globals.price_for_diamonds_panel_slot_1_quantity = (globals.egg - 2) * -1;//Считаем, количество продуктов, которых нехватает
                globals.price_for_diamonds_panel_slot_1_predmet_name = "egg";
                globals.price_for_diamonds_panel_slot_2_quantity = (globals.wheat - 2) * -1;//Считаем, количество продуктов, которых нехватает, умножаем на1, чтобы избавится от минуса
                globals.price_for_diamonds_panel_slot_2_predmet_name = "wheat";
                globals.price_for_diamonds_panel_slot_3_quantity = 0;
                globals.price_for_diamonds_panel_slot_3_predmet_name = "empty";
                //Количество необходимых алмазов = цена продукта в алмазах * количество
                globals.price_for_diamonds_panel_button_ok_diamonds_quantity =
                                              (globals.brown_sugar_price_for_diamonds * globals.price_for_diamonds_panel_slot_0_quantity) +
                                              (globals.egg_price_for_diamonds * globals.price_for_diamonds_panel_slot_1_quantity) +
                                              (globals.wheat_price_for_diamonds * globals.price_for_diamonds_panel_slot_2_quantity);
                Debug.Log("globals.price_for_diamonds_panel_button_ok_diamonds_quantity=" + globals.price_for_diamonds_panel_button_ok_diamonds_quantity);
                Debug.Log("globals.price_for_diamonds_panel_slot_0_quantity=" + globals.price_for_diamonds_panel_slot_0_quantity);
                Debug.Log("globals.egg_price_for_diamonds=" + globals.egg_price_for_diamonds);
                Debug.Log("globals.price_for_diamonds_panel_slot_1_quantity=" + globals.price_for_diamonds_panel_slot_1_quantity);
                GameObject_Enable_Controller.price_for_diamonds_panel.SetActive(true);//Открываем форму нехватки ресурсов
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_0.SetActive(true);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_1.SetActive(true);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_2.SetActive(true);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_3.SetActive(false);
                return;
            }
            if (globals.brown_sugar - 1 < 0)//Если нехватило только коричневого сахара
            {
                globals.price_for_diamonds_panel_slot_0_quantity = (globals.brown_sugar - 1) * -1;//Считаем, количество продуктов, которых нехватает, умножаем на1, чтобы избавится от минуса
                globals.price_for_diamonds_panel_slot_0_predmet_name = "brown_sugar";
                globals.price_for_diamonds_panel_slot_1_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_1_quantity = 0;
                globals.price_for_diamonds_panel_slot_2_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_2_quantity = 0;
                globals.price_for_diamonds_panel_slot_3_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_3_quantity = 0;
                //Количество необходимых алмазов = цена продукта в алмазах * количество
                globals.price_for_diamonds_panel_button_ok_diamonds_quantity = globals.brown_sugar_price_for_diamonds * globals.price_for_diamonds_panel_slot_0_quantity;
                GameObject_Enable_Controller.price_for_diamonds_panel.SetActive(true);//Открываем форму нехватки ресурсов
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_0.SetActive(true);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_1.SetActive(false);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_2.SetActive(false);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_3.SetActive(false);
                return;
            }
            if (globals.egg - 2 < 0)//Если нехватило только яиц
            {
                Debug.Log("Нехватило только яиц");
                globals.price_for_diamonds_panel_slot_0_quantity = (globals.egg - 2) * -1;//Считаем, количество продуктов, которых нехватает
                globals.price_for_diamonds_panel_slot_0_predmet_name = "egg";
                globals.price_for_diamonds_panel_slot_1_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_1_quantity = 0;
                globals.price_for_diamonds_panel_slot_2_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_2_quantity = 0;
                globals.price_for_diamonds_panel_slot_3_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_3_quantity = 0;
                //Количество необходимых алмазов = цена продукта в алмазах * количество
                //GameObject_Enable_Controller.price_for_diamonds_panel_button_ok_diamonds_quantity.GetComponent<Text>().text = (globals.egg_price_for_diamonds * globals.price_for_diamonds_panel_slot_0_quantity).ToString();
                globals.price_for_diamonds_panel_button_ok_diamonds_quantity = globals.egg_price_for_diamonds * globals.price_for_diamonds_panel_slot_0_quantity;
                Debug.Log("globals.price_for_diamonds_panel_button_ok_diamonds_quantity=" + globals.price_for_diamonds_panel_button_ok_diamonds_quantity);
                GameObject_Enable_Controller.price_for_diamonds_panel.SetActive(true);//Открываем форму нехватки ресурсов
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_0.SetActive(true);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_1.SetActive(false);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_2.SetActive(false);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_3.SetActive(false);
                return;
            }
            if (globals.wheat - 2 < 0)
            {
                Debug.Log("Нехватило только пшеницы");
                globals.price_for_diamonds_panel_current_item = subjectName;//Присваиваем переменной предмет, у которого не хватает ингредиентов
                globals.price_for_diamonds_panel_slot_0_quantity = (globals.wheat - 2) * (-1);
                globals.price_for_diamonds_panel_slot_0_predmet_name = "wheat";
                globals.price_for_diamonds_panel_slot_1_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_1_quantity = 0;
                globals.price_for_diamonds_panel_slot_2_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_2_quantity = 0;
                globals.price_for_diamonds_panel_slot_3_predmet_name = "empty";
                globals.price_for_diamonds_panel_slot_3_quantity = 0;
                globals.price_for_diamonds_panel_button_ok_diamonds_quantity = globals.wheat_price_for_diamonds * globals.price_for_diamonds_panel_slot_0_quantity;
                GameObject_Enable_Controller.price_for_diamonds_panel.SetActive(true);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_0.SetActive(true);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_1.SetActive(false);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_2.SetActive(false);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_3.SetActive(false);
                return;
            }

            return;
        }
    }
    var nowtime = DateTime.Now;//Текущее время
    if (globals.bakery_array_slots_zagruzki[0, 0] == "")
    {
        globals.bakery_array_slots_zagruzki[0, 0] = subjectName; //Загружаемый предмет
        globals.bakery_array_slots_zagruzki[0, 1] = Convert.ToString(nowtime, System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat); //Дата загрузки
        globals.bakery_array_slots_zagruzki[0, 2] = Convert.ToString(nowtime.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat); //Дата отгрузки
        Debug.Log("globals.bakery_array_slots_zagruzki[0, 0]" + globals.bakery_array_slots_zagruzki[0, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[0, 1]" + globals.bakery_array_slots_zagruzki[0, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[0, 2]" + globals.bakery_array_slots_zagruzki[0, 2]);
        return;
    }
    if (globals.bakery_array_slots_zagruzki[1, 0] == "")
    {
        globals.bakery_array_slots_zagruzki[1, 0] = subjectName;
        globals.bakery_array_slots_zagruzki[1, 1] = globals.bakery_array_slots_zagruzki[0, 2];
        time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[0, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        globals.bakery_array_slots_zagruzki[1, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        Debug.Log("globals.bakery_array_slots_zagruzki[1, 0]" + globals.bakery_array_slots_zagruzki[1, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[1, 1]" + globals.bakery_array_slots_zagruzki[1, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[1, 2]" + globals.bakery_array_slots_zagruzki[1, 2]);
        return;
    }
    if (globals.bakery_array_slots_zagruzki[2, 0] == "")
    {
        globals.bakery_array_slots_zagruzki[2, 0] = subjectName;
        globals.bakery_array_slots_zagruzki[2, 1] = globals.bakery_array_slots_zagruzki[1, 2];
        time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[1, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        globals.bakery_array_slots_zagruzki[2, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        Debug.Log("globals.bakery_array_slots_zagruzki[2, 0]" + globals.bakery_array_slots_zagruzki[2, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[2, 1]" + globals.bakery_array_slots_zagruzki[2, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[2, 2]" + globals.bakery_array_slots_zagruzki[2, 2]);
        return;
    }
    if (globals.bakery_array_slots_zagruzki[3, 0] == "")
    {
        globals.bakery_array_slots_zagruzki[3, 0] = subjectName;
        globals.bakery_array_slots_zagruzki[3, 1] = globals.bakery_array_slots_zagruzki[2, 2];
        time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[2, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        globals.bakery_array_slots_zagruzki[3, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        Debug.Log("globals.bakery_array_slots_zagruzki[3, 0]" + globals.bakery_array_slots_zagruzki[3, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[3, 1]" + globals.bakery_array_slots_zagruzki[3, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[3, 2]" + globals.bakery_array_slots_zagruzki[3, 2]);
        return;
    }
    if (globals.bakery_array_slots_zagruzki[4, 0] == "")
    {
        globals.bakery_array_slots_zagruzki[4, 0] = subjectName;
        globals.bakery_array_slots_zagruzki[4, 1] = globals.bakery_array_slots_zagruzki[3, 2];
        time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[3, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        globals.bakery_array_slots_zagruzki[4, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        Debug.Log("globals.bakery_array_slots_zagruzki[4, 0]" + globals.bakery_array_slots_zagruzki[4, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[4, 1]" + globals.bakery_array_slots_zagruzki[4, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[4, 2]" + globals.bakery_array_slots_zagruzki[4, 2]);
        return;
    }
    if (globals.bakery_array_slots_zagruzki[5, 0] == "")
    {
        globals.bakery_array_slots_zagruzki[5, 0] = subjectName;
        globals.bakery_array_slots_zagruzki[5, 1] = globals.bakery_array_slots_zagruzki[4, 2];
        time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[4, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        globals.bakery_array_slots_zagruzki[5, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        Debug.Log("globals.bakery_array_slots_zagruzki[5, 0]" + globals.bakery_array_slots_zagruzki[5, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[5, 1]" + globals.bakery_array_slots_zagruzki[5, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[5, 2]" + globals.bakery_array_slots_zagruzki[5, 2]);
        return;
    }
    if (globals.bakery_array_slots_zagruzki[6, 0] == "")
    {
        globals.bakery_array_slots_zagruzki[6, 0] = subjectName;
        globals.bakery_array_slots_zagruzki[6, 1] = globals.bakery_array_slots_zagruzki[5, 2];
        time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[5, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        globals.bakery_array_slots_zagruzki[6, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        Debug.Log("globals.bakery_array_slots_zagruzki[6, 0]" + globals.bakery_array_slots_zagruzki[6, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[6, 1]" + globals.bakery_array_slots_zagruzki[6, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[6, 2]" + globals.bakery_array_slots_zagruzki[6, 2]);
        return;
    }
    if (globals.bakery_array_slots_zagruzki[7, 0] == "")
    {
        globals.bakery_array_slots_zagruzki[7, 0] = subjectName;
        globals.bakery_array_slots_zagruzki[7, 1] = globals.bakery_array_slots_zagruzki[6, 2];
        time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[6, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        globals.bakery_array_slots_zagruzki[7, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        Debug.Log("globals.bakery_array_slots_zagruzki[7, 0]" + globals.bakery_array_slots_zagruzki[7, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[7, 1]" + globals.bakery_array_slots_zagruzki[7, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[7, 2]" + globals.bakery_array_slots_zagruzki[7, 2]);
        return;
    }
    if (globals.bakery_array_slots_zagruzki[8, 0] == "")
    {
        globals.bakery_array_slots_zagruzki[8, 0] = subjectName;
        globals.bakery_array_slots_zagruzki[8, 1] = globals.bakery_array_slots_zagruzki[7, 2];
        time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[7, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        globals.bakery_array_slots_zagruzki[8, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
        Debug.Log("globals.bakery_array_slots_zagruzki[8, 0]" + globals.bakery_array_slots_zagruzki[8, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[8, 1]" + globals.bakery_array_slots_zagruzki[8, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[8, 2]" + globals.bakery_array_slots_zagruzki[8, 2]);
        return;
    }
    //Максимальное количество слотов

}

*/

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
