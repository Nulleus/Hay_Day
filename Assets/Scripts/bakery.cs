using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class bakery : MonoBehaviour
{
    private string TypeObject= "production_building";
    private GameObject MainCamera; 
    private bool IsSlotsPanelGetOn;
    private int Count = 0;
    private bool IsCountOn = false;
    private Vector3 PrimaryPosition;//Сохранение начального положения объкта
    private Vector3 Offset; //Смещение
    private Vector3 ScreenPoint;
    private string Temp;
    private sql_client SC;
    private bool IsMouseDragBlockOn = false;
    private bool IsMoveModeOn=false;
    private bool IsCollisionMoveModeOn = false;
    private string[,] ArraySlotsLoading;
    private string[,] ArraySlotsShipment;
    private int OpenSlots;

    GameObject Subjects;
    GameObject Collider;
    GameObject Arrow;
    GameObject Arrow0;
    GameObject Arrow1;
    GameObject Arrow2;
    GameObject Arrow3;
    GameObject Arrow4;
    GameObject SlotsPanel;
    GameObject ButtonFlip;
    GameObject ButtonMoveOff;
    GameObject SlotsSubject;
    GameObject SlotsLoading;
    GameObject SlotsShipment;
    GameObject FarmBoxColliders;
    GameObject SlotInfo;
    GameObject ConnectionString;

    // Start is called before the first frame update
    void Start()
    {
        Subjects = transform.Find("Subjects").gameObject;//Поиск хранилища со всеми предметами игры
        SlotsPanel = transform.Find("SlotsPanel").gameObject;//Find Child gameobject
        SlotsSubject = transform.Find("SlotsSubject").gameObject;
        SlotsLoading = transform.Find("SlotsLoading").gameObject;
        SlotsShipment = transform.Find("SlotsShipment").gameObject;
        FarmBoxColliders = transform.Find("FarmBoxColliders").gameObject;
        Arrow.transform.Find("Arrow");
        Arrow0.transform.Find("Arrow0");
        Arrow1.transform.Find("Arrow1");
        Arrow2.transform.Find("Arrow2");
        Arrow3.transform.Find("Arrow3");
        Arrow4.transform.Find("Arrow4");
        SlotInfo = GameObject.Find("SlotInfo");
        ConnectionString = GameObject.Find("ConnectionString");
        //MainCamera = GameObject.Find("MainCamera");
        //SlotsPanel.transform.Find("SlotsPanel");//Find Child gameobject
        //Collider.transform.Find("Collider");
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
        if (SlotsSubject.activeSelf)
        {
            SlotsSubject.SetActive(true);
            SlotsLoading.SetActive(true);
        }
        else
        {
            SlotsSubject.SetActive(false);
            SlotsLoading.SetActive(false);
        }
        if (IsMoveModeOn)//Если режим перемещения включен
        {
            SlotsSubject.SetActive(false);
            SlotsLoading.SetActive(false);
            SlotsPanel.SetActive(true);
            gameObject.tag = "obj_move_mod";

            if (IsCollisionMoveModeOn)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;//Окрашиваем пекарню в красный цвет
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.white;//Окрашиваем пекарню в белый цвет
            }
            if (gameObject.GetComponent<Renderer>().material.color != Color.red)//Эффект мигания
            {
                gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
            }


        }
        else
        {
            SlotsPanel.SetActive(false);
            FarmBoxColliders.SetActive(false);
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            gameObject.tag = globals.bakery_type_obj;//

        }
        if (IsCountOn)
        {
            Count++;

            if (Count == 6) { Arrow0.GetComponent<Renderer>().material.color = Color.yellow; }
            if (Count == 12) { Arrow1.GetComponent<Renderer>().material.color = Color.yellow; }
            if (Count == 18) { Arrow2.GetComponent<Renderer>().material.color = Color.yellow; }
            if (Count == 24) { Arrow3.GetComponent<Renderer>().material.color = Color.yellow; }
            if (Count == 30) { Arrow4.GetComponent<Renderer>().material.color = Color.yellow; }
            if (Count > 30)//Активация режима перемещение
            {
                IsMoveModeOn = true;//Активация режима перемещение
                Arrow.SetActive(false);//Скрытие стрелочки
                FarmBoxColliders.SetActive(true);
                SlotsPanel.SetActive(true);//Включаем панель с кнопкой Flip
                IsCountOn = false;
            }
        }
        ShipmentSubject();//Контоль отгрузк предмета
    }
    void OffsetArray()//Смещение массива на одну позицию  
    {
        //Добавить цикл, для прохода по открытым объектам
        ArraySlotsLoading[0, 0] = ArraySlotsLoading[1, 0];
        ArraySlotsLoading[0, 1] = ArraySlotsLoading[1, 1];
        ArraySlotsLoading[0, 2] = ArraySlotsLoading[1, 2];

        ArraySlotsLoading[1, 0] = ArraySlotsLoading[2, 0];
        ArraySlotsLoading[1, 1] = ArraySlotsLoading[2, 1];
        ArraySlotsLoading[1, 2] = ArraySlotsLoading[2, 2];

        ArraySlotsLoading[2, 0] = ArraySlotsLoading[3, 0];
        ArraySlotsLoading[2, 1] = ArraySlotsLoading[3, 1];
        ArraySlotsLoading[2, 2] = ArraySlotsLoading[3, 2];

        ArraySlotsLoading[3, 0] = ArraySlotsLoading[4, 0];
        ArraySlotsLoading[3, 1] = ArraySlotsLoading[4, 1];
        ArraySlotsLoading[3, 2] = ArraySlotsLoading[4, 2];

        ArraySlotsLoading[4, 0] = ArraySlotsLoading[5, 0];
        ArraySlotsLoading[4, 1] = ArraySlotsLoading[5, 1];
        ArraySlotsLoading[4, 2] = ArraySlotsLoading[5, 2];

        ArraySlotsLoading[5, 0] = ArraySlotsLoading[6, 0];
        ArraySlotsLoading[5, 1] = ArraySlotsLoading[6, 1];
        ArraySlotsLoading[5, 2] = ArraySlotsLoading[6, 2];

        ArraySlotsLoading[6, 0] = ArraySlotsLoading[7, 0];
        ArraySlotsLoading[6, 1] = ArraySlotsLoading[7, 1];
        ArraySlotsLoading[6, 2] = ArraySlotsLoading[7, 2];

        ArraySlotsLoading[7, 0] = ArraySlotsLoading[8, 0];
        ArraySlotsLoading[7, 1] = ArraySlotsLoading[8, 1];
        ArraySlotsLoading[7, 2] = ArraySlotsLoading[8, 2];

        ArraySlotsLoading[8, 0] = "";
        ArraySlotsLoading[8, 1] = "";
        ArraySlotsLoading[8, 2] = "";



    }
    void OffsetArrayShipment()
    {
        //Добавить цикл, для прохода по открытым объектам
        ArraySlotsShipment[0, 0] = ArraySlotsShipment[1, 0];
        ArraySlotsShipment[0, 1] = ArraySlotsShipment[1, 1];
        ArraySlotsShipment[0, 2] = ArraySlotsShipment[1, 2];

        ArraySlotsShipment[1, 0] = ArraySlotsShipment[2, 0];
        ArraySlotsShipment[1, 1] = ArraySlotsShipment[2, 1];
        ArraySlotsShipment[1, 2] = ArraySlotsShipment[2, 2];

        ArraySlotsShipment[2, 0] = ArraySlotsShipment[3, 0];
        ArraySlotsShipment[2, 1] = ArraySlotsShipment[3, 1];
        ArraySlotsShipment[2, 2] = ArraySlotsShipment[3, 2];

        ArraySlotsShipment[3, 0] = ArraySlotsShipment[4, 0];
        ArraySlotsShipment[3, 1] = ArraySlotsShipment[4, 1];
        ArraySlotsShipment[3, 2] = ArraySlotsShipment[4, 2];

        ArraySlotsShipment[4, 0] = ArraySlotsShipment[5, 0];
        ArraySlotsShipment[4, 1] = ArraySlotsShipment[5, 1];
        ArraySlotsShipment[4, 2] = ArraySlotsShipment[5, 2];

        ArraySlotsShipment[5, 0] = ArraySlotsShipment[6, 0];
        ArraySlotsShipment[5, 1] = ArraySlotsShipment[6, 1];
        ArraySlotsShipment[5, 2] = ArraySlotsShipment[6, 2];

        ArraySlotsShipment[6, 0] = ArraySlotsShipment[7, 0];
        ArraySlotsShipment[6, 1] = ArraySlotsShipment[7, 1];
        ArraySlotsShipment[6, 2] = ArraySlotsShipment[7, 2];

        ArraySlotsShipment[7, 0] = ArraySlotsShipment[8, 0];
        ArraySlotsShipment[7, 1] = ArraySlotsShipment[8, 1];
        ArraySlotsShipment[7, 2] = ArraySlotsShipment[8, 2];

        ArraySlotsShipment[8, 0] = "";
        ArraySlotsShipment[8, 1] = "";
        ArraySlotsShipment[8, 2] = "";

    }
    void ShipmentSubject()
    {
        //Добавить цикл прохода, только по откытым слотам
        var nowtime = DateTime.Now;

        if (ArraySlotsLoading[0, 0] != "")//Если слот_0  не пустой (нужно для оптимизации)
        {
            TimeSpan time = Convert.ToDateTime(ArraySlotsLoading[0, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat) - Convert.ToDateTime(nowtime, System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            //Разница дат            
            if (Convert.ToDateTime(ArraySlotsLoading[0, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat) < Convert.ToDateTime(nowtime, System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat))//Если (дата отгрузки < текущей даты)
            {
                if (ArraySlotsShipment[0, 0] == "")//Если слот отгрузки 0, пустой
                {
                    ArraySlotsShipment[0, 0] = ArraySlotsLoading[0, 0];//Имя предмета
                    ArraySlotsLoading[0, 0] = "";//Очищаем слот загрузки с именем предмета
                    ArraySlotsShipment[0, 1] = ArraySlotsLoading[0, 1];//Дата загрузки предмета
                    ArraySlotsLoading[0, 1] = "";//Очищаем слот загрузки с датой загрузки предмета
                    ArraySlotsShipment[0, 2] = ArraySlotsLoading[0, 2]; //Дата отгрузки предмета
                    ArraySlotsLoading[0, 2] = "";//Очищаем слот загрузки с датой отгрузки предмета
                    OffsetArray();
                    Debug.Log("Отгрузился в слот отгрузки: 0 ");

                    return;
                }
                if (ArraySlotsShipment[1, 0] == "")
                {
                    ArraySlotsShipment[1, 0] = ArraySlotsLoading[0, 0];//Имя предмета
                    ArraySlotsLoading[0, 0] = "";
                    ArraySlotsShipment[1, 1] = ArraySlotsLoading[0, 1];//Дата загрузки предмета
                    ArraySlotsLoading[0, 1] = "";
                    ArraySlotsShipment[1, 2] = ArraySlotsLoading[0, 2]; //Дата отгрузки предмета
                    ArraySlotsLoading[0, 2] = "";
                    OffsetArray();
                    Debug.Log("Отгрузился в слот отгрузки: 1 ");
                    return;
                }
                if (ArraySlotsShipment[2, 0] == "")
                {
                    ArraySlotsShipment[2, 0] = ArraySlotsLoading[0, 0];//Имя предмета
                    ArraySlotsLoading[0, 0] = "";
                    ArraySlotsShipment[2, 1] = ArraySlotsLoading[0, 1];//Дата загрузки предмета
                    ArraySlotsLoading[0, 1] = "";
                    ArraySlotsShipment[2, 2] = ArraySlotsLoading[0, 2]; //Дата отгрузки предмета
                    ArraySlotsLoading[0, 2] = "";
                    OffsetArray();
                    Debug.Log("Отгрузился в слот отгрузки: 2 ");
                    return;
                }
                if (ArraySlotsShipment[3, 0] == "")
                {
                    ArraySlotsShipment[3, 0] = ArraySlotsLoading[0, 0];//Имя предмета
                    ArraySlotsLoading[0, 0] = "";
                    ArraySlotsShipment[3, 1] = ArraySlotsLoading[0, 1];//Дата загрузки предмета
                    ArraySlotsLoading[0, 1] = "";
                    ArraySlotsShipment[3, 2] = ArraySlotsLoading[0, 2]; //Дата отгрузки предмета
                    ArraySlotsLoading[0, 2] = "";
                    OffsetArray();
                    Debug.Log("Отгрузился в слот отгрузки: 3 ");
                    return;
                }
                if (ArraySlotsShipment[4, 0] == "")
                {
                    ArraySlotsShipment[4, 0] = ArraySlotsLoading[0, 0];//Имя предмета
                    ArraySlotsLoading[0, 0] = "";
                    ArraySlotsShipment[4, 1] = ArraySlotsLoading[0, 1];//Дата загрузки предмета
                    ArraySlotsLoading[0, 1] = "";
                    ArraySlotsShipment[4, 2] = ArraySlotsLoading[0, 2]; //Дата отгрузки предмета
                    ArraySlotsLoading[0, 2] = "";
                    OffsetArray();
                    Debug.Log("Отгрузился в слот отгрузки: 4 ");
                    return;
                }
                if (ArraySlotsShipment[5, 0] == "")
                {
                    ArraySlotsShipment[5, 0] = ArraySlotsLoading[0, 0];//Имя предмета
                    ArraySlotsLoading[0, 0] = "";
                    ArraySlotsShipment[5, 1] = ArraySlotsLoading[0, 1];//Дата загрузки предмета
                    ArraySlotsLoading[0, 1] = "";
                    ArraySlotsShipment[5, 2] = ArraySlotsLoading[0, 2]; //Дата отгрузки предмета
                    ArraySlotsLoading[0, 2] = "";
                    OffsetArray();
                    Debug.Log("Отгрузился в слот отгрузки: 5 ");
                    return;
                }
                if (ArraySlotsShipment[6, 0] == "")
                {
                    ArraySlotsShipment[6, 0] = ArraySlotsLoading[0, 0];//Имя предмета
                    ArraySlotsLoading[0, 0] = "";
                    ArraySlotsShipment[6, 1] = ArraySlotsLoading[0, 1];//Дата загрузки предмета
                    ArraySlotsLoading[0, 1] = "";
                    ArraySlotsShipment[6, 2] = ArraySlotsLoading[0, 2]; //Дата отгрузки предмета
                    ArraySlotsLoading[0, 2] = "";
                    OffsetArray();
                    Debug.Log("Отгрузился в слот отгрузки: 6 ");
                    return;
                }
                if (ArraySlotsShipment[7, 0] == "")
                {
                    ArraySlotsShipment[7, 0] = ArraySlotsLoading[0, 0];//Имя предмета
                    ArraySlotsLoading[0, 0] = "";
                    ArraySlotsShipment[7, 1] = ArraySlotsLoading[0, 1];//Дата загрузки предмета
                    ArraySlotsLoading[0, 1] = "";
                    ArraySlotsShipment[7, 2] = ArraySlotsLoading[0, 2]; //Дата отгрузки предмета
                    ArraySlotsLoading[0, 2] = "";
                    OffsetArray();
                    Debug.Log("Отгрузился в слот отгрузки: 7 ");
                    return;
                }
                if (ArraySlotsShipment[8, 0] == "")
                {
                    ArraySlotsShipment[8, 0] = ArraySlotsLoading[0, 0];//Имя предмета
                    ArraySlotsLoading[0, 0] = "";
                    ArraySlotsShipment[8, 1] = ArraySlotsLoading[0, 1];//Дата загрузки предмета
                    ArraySlotsLoading[0, 1] = "";
                    ArraySlotsShipment[8, 2] = ArraySlotsLoading[0, 2]; //Дата отгрузки предмета
                    ArraySlotsLoading[0, 2] = "";
                    OffsetArray();
                    Debug.Log("Отгрузился в слот отгрузки: 8 ");
                    return;
                }


            }



            //Смещение массива



        }
    }//Отгрузка предмета из слота загрузки в слот отгрузки
    //public void Add
    public void AddInSlotSubject(string subject)//Метод добавления предмета в слоты
    {

        //Если все слоты заняты, не загружать
        if (ArraySlotsLoading[OpenSlots - 1, 0] != "")//Если последний открытый слот пекарни не пустой
        {
            Debug.Log("Очередь производства заполнена! Подожди, ускорь или докупи ячейки!");
            return;
        }
        //Вычитать ресурсы со склада, а если это последняя культура, предупредить
        DateTime time_slot;
        Debug.Log("add: " + subject);
        int building_time = 20;//Время сборки
        GameObject GO = GameObject.Find(subject);//Поиск объекта, например Bread
        
        string[] ingredients = GO.GetComponent<Ingredients>().GetAllKeysSubjects();//Получаем список ингредиентов
        //Поиск объекта из массива
        foreach (string ingredient in ingredients)//Перебор найденных ингредиентов
        {
            //Если найденый ингредиент и его количество на складе минус(необходимое количество для производства)>=0, тогда выполняем действие
           if( GameObject.Find(ingredient).GetComponent<Subject>().GetCount() - GO.GetComponent<Ingredients>().GetCountByName(ingredient) >= 0)
            {
                //Вычитаем количество предмета через сетод SetCount
                GameObject.Find(ingredient).GetComponent<Subject>().SetCount(GO.GetComponent<Ingredients>().GetCountByName(ingredient));
            }
           else
            {
                Debug.Log("Нехватает ингредиентов!");
                //Добавляем в SlotInfo, ингредиенты, которых нехватает и их количество
                //Предмет

                //Количество, которого нехватает = Количество ингредиентов на складе - Необходимое количество ингредиентов для производства
                var countMissing = (GameObject.Find(ingredient).GetComponent<Subject>().GetCount() - GO.GetComponent<Ingredients>().GetCountByName(ingredient)) * (-1);//-1 Для получения положительного числа(сколько нехватает ингредиентов)
                //Информация для Панели слота инфо с 
                //Не тут лолжно быть, а на MouseDown SlotInfo.GetComponent<SlotInfo>().AddMissingIngredient(GameObject.Find(ingredient), GO.GetComponent<Ingredients>().GetCountByName(ingredient).ToString());
            }
        }

        if (subject == "bread")
        {

            

            //Проверка наличия всех ингридиентов
            if (GameObject.Find("Wheat").GetComponent<Subject>().GetCount() - 3 >= 0)
            {
                GameObject.Find("Wheat").GetComponent<Subject>().SetCount(-3);
                //globals.wheat = globals.wheat - 3;
            }
            else
            {
                Debug.Log("Нехватает ингредиентов!");
                //GameObject.Find("")
                globals.price_for_diamonds_panel_current_item = subject;//Присваиваем переменной предмет, у которого нехватает ингредиентов
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
        if (subject == "corn_bread")
        {
            building_time = 10;//Время сборки

            if ((globals.corn - 2 >= 0) && (globals.egg - 2 >= 0))//Если всего хватает
            {
                globals.corn = globals.corn - 2;
                globals.egg = globals.egg - 2;
            }
            else
            {
                Debug.Log("Нехватает ингредиентов!");
                Debug.Log("corn:" + globals.corn + "egg:" + globals.egg);
                globals.price_for_diamonds_panel_current_item = subject;//Присваиваем переменной предмет, у которого нехватает ингредиентов
                if ((globals.corn - 2 < 0) && (globals.egg - 2 < 0))//Если нехватает и кукурузы и яиц
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
                    GameObject_Enable_Controller.price_for_diamonds_panel.SetActive(true);//Открываем форму нехватки ресурсов
                    GameObject_Enable_Controller.price_for_diamonds_panel_slot_0.SetActive(true);
                    GameObject_Enable_Controller.price_for_diamonds_panel_slot_1.SetActive(true);
                    GameObject_Enable_Controller.price_for_diamonds_panel_slot_2.SetActive(false);
                    GameObject_Enable_Controller.price_for_diamonds_panel_slot_3.SetActive(false);
                    return;
                }
                if (globals.corn - 2 < 0)//Если нехватило только кукурузы
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

                return;
            }
        }
        if (subject == "cookie")
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
                Debug.Log("Нехватает ингредиентов!");
                Debug.Log("brown_sugar:" + globals.brown_sugar + "egg:" + globals.egg + "globals.wheat" + globals.wheat);
                globals.price_for_diamonds_panel_current_item = subject;//Присваиваем переменной предмет, у которого нехватает ингредиентов
                if ((globals.brown_sugar - 1 < 0) && (globals.egg - 2 < 0) && (globals.wheat - 2 < 0))//Если нехватает коричневого сахара и яиц и пшеницы
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
                    globals.price_for_diamonds_panel_current_item = subject;//Присваиваем переменной предмет, у которого нехватает ингредиентов
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
            globals.bakery_array_slots_zagruzki[0, 0] = subject; //Загружаемый предмет
            globals.bakery_array_slots_zagruzki[0, 1] = Convert.ToString(nowtime, System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat); //Дата загрузки
            globals.bakery_array_slots_zagruzki[0, 2] = Convert.ToString(nowtime.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat); //Дата отгрузки
            Debug.Log("globals.bakery_array_slots_zagruzki[0, 0]" + globals.bakery_array_slots_zagruzki[0, 0]);
            Debug.Log("globals.bakery_array_slots_zagruzki[0, 1]" + globals.bakery_array_slots_zagruzki[0, 1]);
            Debug.Log("globals.bakery_array_slots_zagruzki[0, 2]" + globals.bakery_array_slots_zagruzki[0, 2]);
            return;
        }
        if (globals.bakery_array_slots_zagruzki[1, 0] == "")
        {
            globals.bakery_array_slots_zagruzki[1, 0] = subject;
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
            globals.bakery_array_slots_zagruzki[2, 0] = subject;
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
            globals.bakery_array_slots_zagruzki[3, 0] = subject;
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
            globals.bakery_array_slots_zagruzki[4, 0] = subject;
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
            globals.bakery_array_slots_zagruzki[5, 0] = subject;
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
            globals.bakery_array_slots_zagruzki[6, 0] = subject;
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
            globals.bakery_array_slots_zagruzki[7, 0] = subject;
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
            globals.bakery_array_slots_zagruzki[8, 0] = subject;
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
    void sort_slots()//Сортиовка слотов загрузки
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = i + 1; j < 9; j++)
            {
                if (Convert.ToDateTime(globals.bakery_array_slots_zagruzki[i, 1], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat) > Convert.ToDateTime(globals.bakery_array_slots_zagruzki[j, 1], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat))
                {
                    Temp = globals.bakery_array_slots_zagruzki[i, 1];//Второй столбик
                    globals.bakery_array_slots_zagruzki[i, 1] = globals.bakery_array_slots_zagruzki[j, 1];
                    globals.bakery_array_slots_zagruzki[j, 1] = Temp;

                    Temp = globals.bakery_array_slots_zagruzki[i, 0];//Первый столбик
                    globals.bakery_array_slots_zagruzki[i, 0] = globals.bakery_array_slots_zagruzki[j, 0];
                    globals.bakery_array_slots_zagruzki[j, 0] = Temp;

                    Temp = globals.bakery_array_slots_zagruzki[i, 2];//Третий столбик
                    globals.bakery_array_slots_zagruzki[i, 2] = globals.bakery_array_slots_zagruzki[j, 2];
                    globals.bakery_array_slots_zagruzki[j, 2] = Temp;
                }
            }
        }


    }//Сортировка слотов по возрастанию
    void control_slots()//Вывод массива
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Debug.Log("globals.bakery_array_slots_zagruzki[" + i + "," + j + "]=" + globals.bakery_array_slots_zagruzki[i, j]);
            }
        }
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


                OffsetArrayShipment();
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
                OffsetArrayShipment();
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
                OffsetArrayShipment();
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
