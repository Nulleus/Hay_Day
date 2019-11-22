using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class bakery : MonoBehaviour
{
    public int count = 0;
    public bool count_on = false;
    public Vector3 primary_position;//Сохранение начального положения объкта
    public Vector3 offset; //Смещение
    public Vector3 screenPoint;
    string temp;
    
    public bool mousedrag_block_on = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("+++++++++" + GameObject_Enable_Controller.bakery_arrow);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject_Enable_Controller.bakery_slots_panel.activeSelf)
        {
            GameObject_Enable_Controller.bakery_slots_panel.SetActive(false);
        }
        else
        {
            GameObject_Enable_Controller.bakery_slots_panel.SetActive(true);
        }
        if (GameObject_Enable_Controller.bakery_slots_predmets.activeSelf)
        {
            GameObject_Enable_Controller.bakery_slots_predmets.SetActive(true);
            GameObject_Enable_Controller.bakery_slots_zagruzki.SetActive(true);           
        }
        else
        {
            GameObject_Enable_Controller.bakery_slots_predmets.SetActive(false);
            GameObject_Enable_Controller.bakery_slots_zagruzki.SetActive(false);
        }
        if (globals.bakery_move_mode_on)//Если режим перемещения включен
        {
            GameObject_Enable_Controller.bakery_slots_predmets.SetActive(false);
            GameObject_Enable_Controller.bakery_slots_zagruzki.SetActive(false);
            GameObject_Enable_Controller.bakery_slots_panel.SetActive(true);
            gameObject.tag = "obj_move_mod";

            if (globals.collision_move_mod_on)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;//Окрашиваем пекарню в красный цвет
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.white;//Окрашиваем пекарню в белый цвет
            }
            if (gameObject.GetComponent<Renderer>().material.color != Color.red)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
            }


        }
        else
        {
            GameObject_Enable_Controller.bakery_slots_panel.SetActive(false);
            GameObject_Enable_Controller.farm_box_colliders.SetActive(false);
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            gameObject.tag = globals.bakery_type_obj;//

        }
        if (count_on)
        {
            count++;

            if (count == 6) { GameObject_Enable_Controller.bakery_arrow_0.GetComponent<Renderer>().material.color = Color.yellow; }
            if (count == 12) { GameObject_Enable_Controller.bakery_arrow_1.GetComponent<Renderer>().material.color = Color.yellow; }
            if (count == 18) { GameObject_Enable_Controller.bakery_arrow_2.GetComponent<Renderer>().material.color = Color.yellow; }
            if (count == 24) { GameObject_Enable_Controller.bakery_arrow_3.GetComponent<Renderer>().material.color = Color.yellow; }
            if (count == 30) { GameObject_Enable_Controller.bakery_arrow_4.GetComponent<Renderer>().material.color = Color.yellow; }
            if (count > 30)//Активация режима перемещение
            {
                globals.bakery_move_mode_on = true;//Активация режима перемещение
                GameObject_Enable_Controller.bakery_arrow.SetActive(false);//Скрытие стрелочки
                GameObject_Enable_Controller.farm_box_colliders.SetActive(true);
                GameObject_Enable_Controller.bakery_slots_panel.SetActive(true);//Включаем панель с кнопкой Flip
                count_on = false;
            }
        }
        otgruzka_predmeta();//Контоль отгрузк предмета
    }
    void offset_massive()//Смещение массива на одну позицию  
    {
        //Добавить цикл, для прохода по открытым объектам
        globals.bakery_array_slots_zagruzki[0, 0] = globals.bakery_array_slots_zagruzki[1, 0];
        globals.bakery_array_slots_zagruzki[0, 1] = globals.bakery_array_slots_zagruzki[1, 1];
        globals.bakery_array_slots_zagruzki[0, 2] = globals.bakery_array_slots_zagruzki[1, 2];

        globals.bakery_array_slots_zagruzki[1, 0] = globals.bakery_array_slots_zagruzki[2, 0];
        globals.bakery_array_slots_zagruzki[1, 1] = globals.bakery_array_slots_zagruzki[2, 1];
        globals.bakery_array_slots_zagruzki[1, 2] = globals.bakery_array_slots_zagruzki[2, 2];

        globals.bakery_array_slots_zagruzki[2, 0] = globals.bakery_array_slots_zagruzki[3, 0];
        globals.bakery_array_slots_zagruzki[2, 1] = globals.bakery_array_slots_zagruzki[3, 1];
        globals.bakery_array_slots_zagruzki[2, 2] = globals.bakery_array_slots_zagruzki[3, 2];

        globals.bakery_array_slots_zagruzki[3, 0] = globals.bakery_array_slots_zagruzki[4, 0];
        globals.bakery_array_slots_zagruzki[3, 1] = globals.bakery_array_slots_zagruzki[4, 1];
        globals.bakery_array_slots_zagruzki[3, 2] = globals.bakery_array_slots_zagruzki[4, 2];

        globals.bakery_array_slots_zagruzki[4, 0] = globals.bakery_array_slots_zagruzki[5, 0];
        globals.bakery_array_slots_zagruzki[4, 1] = globals.bakery_array_slots_zagruzki[5, 1];
        globals.bakery_array_slots_zagruzki[4, 2] = globals.bakery_array_slots_zagruzki[5, 2];

        globals.bakery_array_slots_zagruzki[5, 0] = globals.bakery_array_slots_zagruzki[6, 0];
        globals.bakery_array_slots_zagruzki[5, 1] = globals.bakery_array_slots_zagruzki[6, 1];
        globals.bakery_array_slots_zagruzki[5, 2] = globals.bakery_array_slots_zagruzki[6, 2];

        globals.bakery_array_slots_zagruzki[6, 0] = globals.bakery_array_slots_zagruzki[7, 0];
        globals.bakery_array_slots_zagruzki[6, 1] = globals.bakery_array_slots_zagruzki[7, 1];
        globals.bakery_array_slots_zagruzki[6, 2] = globals.bakery_array_slots_zagruzki[7, 2];

        globals.bakery_array_slots_zagruzki[7, 0] = globals.bakery_array_slots_zagruzki[8, 0];
        globals.bakery_array_slots_zagruzki[7, 1] = globals.bakery_array_slots_zagruzki[8, 1];
        globals.bakery_array_slots_zagruzki[7, 2] = globals.bakery_array_slots_zagruzki[8, 2];

        globals.bakery_array_slots_zagruzki[8, 0] = "";
        globals.bakery_array_slots_zagruzki[8, 1] = "";
        globals.bakery_array_slots_zagruzki[8, 2] = "";


    }
    void offset_massive_otgruzki()
    {
        //Добавить цикл, для прохода по открытым объектам
        globals.bakery_array_slots_otgruzki[0, 0] = globals.bakery_array_slots_otgruzki[1, 0];
        globals.bakery_array_slots_otgruzki[0, 1] = globals.bakery_array_slots_otgruzki[1, 1];
        globals.bakery_array_slots_otgruzki[0, 2] = globals.bakery_array_slots_otgruzki[1, 2];

        globals.bakery_array_slots_otgruzki[1, 0] = globals.bakery_array_slots_otgruzki[2, 0];
        globals.bakery_array_slots_otgruzki[1, 1] = globals.bakery_array_slots_otgruzki[2, 1];
        globals.bakery_array_slots_otgruzki[1, 2] = globals.bakery_array_slots_otgruzki[2, 2];

        globals.bakery_array_slots_otgruzki[2, 0] = globals.bakery_array_slots_otgruzki[3, 0];
        globals.bakery_array_slots_otgruzki[2, 1] = globals.bakery_array_slots_otgruzki[3, 1];
        globals.bakery_array_slots_otgruzki[2, 2] = globals.bakery_array_slots_otgruzki[3, 2];

        globals.bakery_array_slots_otgruzki[3, 0] = globals.bakery_array_slots_otgruzki[4, 0];
        globals.bakery_array_slots_otgruzki[3, 1] = globals.bakery_array_slots_otgruzki[4, 1];
        globals.bakery_array_slots_otgruzki[3, 2] = globals.bakery_array_slots_otgruzki[4, 2];

        globals.bakery_array_slots_otgruzki[4, 0] = globals.bakery_array_slots_otgruzki[5, 0];
        globals.bakery_array_slots_otgruzki[4, 1] = globals.bakery_array_slots_otgruzki[5, 1];
        globals.bakery_array_slots_otgruzki[4, 2] = globals.bakery_array_slots_otgruzki[5, 2];

        globals.bakery_array_slots_otgruzki[5, 0] = globals.bakery_array_slots_otgruzki[6, 0];
        globals.bakery_array_slots_otgruzki[5, 1] = globals.bakery_array_slots_otgruzki[6, 1];
        globals.bakery_array_slots_otgruzki[5, 2] = globals.bakery_array_slots_otgruzki[6, 2];

        globals.bakery_array_slots_otgruzki[6, 0] = globals.bakery_array_slots_otgruzki[7, 0];
        globals.bakery_array_slots_otgruzki[6, 1] = globals.bakery_array_slots_otgruzki[7, 1];
        globals.bakery_array_slots_otgruzki[6, 2] = globals.bakery_array_slots_otgruzki[7, 2];

        globals.bakery_array_slots_otgruzki[7, 0] = globals.bakery_array_slots_otgruzki[8, 0];
        globals.bakery_array_slots_otgruzki[7, 1] = globals.bakery_array_slots_otgruzki[8, 1];
        globals.bakery_array_slots_otgruzki[7, 2] = globals.bakery_array_slots_otgruzki[8, 2];

        globals.bakery_array_slots_otgruzki[8, 0] = "";
        globals.bakery_array_slots_otgruzki[8, 1] = "";
        globals.bakery_array_slots_otgruzki[8, 2] = "";
    }
    void otgruzka_predmeta()
    {
        //Добавить цикл прохода, только по откытым слотам
        var nowtime = DateTime.Now;
        
        if (globals.bakery_array_slots_zagruzki[0, 0] != "")//Если слот_0  не пустой (нужно для оптимизации)
        {
            TimeSpan time = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[0, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat) - Convert.ToDateTime(nowtime, System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            //Разница дат            
            if (Convert.ToDateTime(globals.bakery_array_slots_zagruzki[0, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat) < Convert.ToDateTime(nowtime, System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat))//Если (дата отгрузки < текущей даты)
            {
                if (globals.bakery_array_slots_otgruzki[0, 0] == "")//Если слот отгрузки 0, пустой
                {
                    globals.bakery_array_slots_otgruzki[0, 0] = globals.bakery_array_slots_zagruzki[0, 0];//Имя предмета
                    globals.bakery_array_slots_zagruzki[0, 0] = "";//Очищаем слот загрузки с именем предмета
                    globals.bakery_array_slots_otgruzki[0, 1] = globals.bakery_array_slots_zagruzki[0, 1];//Дата загрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 1] = "";//Очищаем слот загрузки с датой загрузки предмета
                    globals.bakery_array_slots_otgruzki[0, 2] = globals.bakery_array_slots_zagruzki[0, 2]; //Дата отгрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 2] = "";//Очищаем слот загрузки с датой отгрузки предмета
                    offset_massive();
                    Debug.Log("Отгрузился в слот отгрузки: 0 ");

                    return;
                }
                if (globals.bakery_array_slots_otgruzki[1, 0] == "")
                {
                    globals.bakery_array_slots_otgruzki[1, 0] = globals.bakery_array_slots_zagruzki[0, 0];//Имя предмета
                    globals.bakery_array_slots_zagruzki[0, 0] = "";
                    globals.bakery_array_slots_otgruzki[1, 1] = globals.bakery_array_slots_zagruzki[0, 1];//Дата загрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 1] = "";
                    globals.bakery_array_slots_otgruzki[1, 2] = globals.bakery_array_slots_zagruzki[0, 2]; //Дата отгрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 2] = "";
                    offset_massive();
                    Debug.Log("Отгрузился в слот отгрузки: 1 ");
                    return;
                }
                if (globals.bakery_array_slots_otgruzki[2, 0] == "")
                {
                    globals.bakery_array_slots_otgruzki[2, 0] = globals.bakery_array_slots_zagruzki[0, 0];//Имя предмета
                    globals.bakery_array_slots_zagruzki[0, 0] = "";
                    globals.bakery_array_slots_otgruzki[2, 1] = globals.bakery_array_slots_zagruzki[0, 1];//Дата загрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 1] = "";
                    globals.bakery_array_slots_otgruzki[2, 2] = globals.bakery_array_slots_zagruzki[0, 2]; //Дата отгрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 2] = "";
                    offset_massive();
                    Debug.Log("Отгрузился в слот отгрузки: 2 ");
                    return;
                }
                if (globals.bakery_array_slots_otgruzki[3, 0] == "")
                {
                    globals.bakery_array_slots_otgruzki[3, 0] = globals.bakery_array_slots_zagruzki[0, 0];//Имя предмета
                    globals.bakery_array_slots_zagruzki[0, 0] = "";
                    globals.bakery_array_slots_otgruzki[3, 1] = globals.bakery_array_slots_zagruzki[0, 1];//Дата загрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 1] = "";
                    globals.bakery_array_slots_otgruzki[3, 2] = globals.bakery_array_slots_zagruzki[0, 2]; //Дата отгрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 2] = "";
                    offset_massive();
                    Debug.Log("Отгрузился в слот отгрузки: 3 ");
                    return;
                }
                if (globals.bakery_array_slots_otgruzki[4, 0] == "")
                {
                    globals.bakery_array_slots_otgruzki[4, 0] = globals.bakery_array_slots_zagruzki[0, 0];//Имя предмета
                    globals.bakery_array_slots_zagruzki[0, 0] = "";
                    globals.bakery_array_slots_otgruzki[4, 1] = globals.bakery_array_slots_zagruzki[0, 1];//Дата загрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 1] = "";
                    globals.bakery_array_slots_otgruzki[4, 2] = globals.bakery_array_slots_zagruzki[0, 2]; //Дата отгрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 2] = "";
                    offset_massive();
                    Debug.Log("Отгрузился в слот отгрузки: 4 ");
                    return;
                }
                if (globals.bakery_array_slots_otgruzki[5, 0] == "")
                {
                    globals.bakery_array_slots_otgruzki[5, 0] = globals.bakery_array_slots_zagruzki[0, 0];//Имя предмета
                    globals.bakery_array_slots_zagruzki[0, 0] = "";
                    globals.bakery_array_slots_otgruzki[5, 1] = globals.bakery_array_slots_zagruzki[0, 1];//Дата загрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 1] = "";
                    globals.bakery_array_slots_otgruzki[5, 2] = globals.bakery_array_slots_zagruzki[0, 2]; //Дата отгрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 2] = "";
                    offset_massive();
                    Debug.Log("Отгрузился в слот отгрузки: 5 ");
                    return;
                }
                if (globals.bakery_array_slots_otgruzki[6, 0] == "")
                {
                    globals.bakery_array_slots_otgruzki[6, 0] = globals.bakery_array_slots_zagruzki[0, 0];//Имя предмета
                    globals.bakery_array_slots_zagruzki[0, 0] = "";
                    globals.bakery_array_slots_otgruzki[6, 1] = globals.bakery_array_slots_zagruzki[0, 1];//Дата загрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 1] = "";
                    globals.bakery_array_slots_otgruzki[6, 2] = globals.bakery_array_slots_zagruzki[0, 2]; //Дата отгрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 2] = "";
                    offset_massive();
                    Debug.Log("Отгрузился в слот отгрузки: 6 ");
                    return;
                }
                if (globals.bakery_array_slots_otgruzki[7, 0] == "")
                {
                    globals.bakery_array_slots_otgruzki[7, 0] = globals.bakery_array_slots_zagruzki[0, 0];//Имя предмета
                    globals.bakery_array_slots_zagruzki[0, 0] = "";
                    globals.bakery_array_slots_otgruzki[7, 1] = globals.bakery_array_slots_zagruzki[0, 1];//Дата загрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 1] = "";
                    globals.bakery_array_slots_otgruzki[7, 2] = globals.bakery_array_slots_zagruzki[0, 2]; //Дата отгрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 2] = "";
                    offset_massive();
                    Debug.Log("Отгрузился в слот отгрузки: 7 ");
                    return;
                }
                if (globals.bakery_array_slots_otgruzki[8, 0] == "")
                {
                    globals.bakery_array_slots_otgruzki[8, 0] = globals.bakery_array_slots_zagruzki[0, 0];//Имя предмета
                    globals.bakery_array_slots_zagruzki[0, 0] = "";
                    globals.bakery_array_slots_otgruzki[8, 1] = globals.bakery_array_slots_zagruzki[0, 1];//Дата загрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 1] = "";
                    globals.bakery_array_slots_otgruzki[8, 2] = globals.bakery_array_slots_zagruzki[0, 2]; //Дата отгрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 2] = "";
                    offset_massive();
                    Debug.Log("Отгрузился в слот отгрузки: 8 ");
                    return;
                }

            }



            //Смещение массива



        }
    }//Отгрузка предмета из слота загрузки в слот отгрузки
    public static void add_in_slot_predmet(string predmet)//Метод добавления предмета в слоты
    {
        //Если все слоты заняты, не загружать

        //Вычитать ресурсы со склада, а если это последняя культура, предупредить
        DateTime time_slot;
        Debug.Log("add: "+predmet);
        int building_time = 20;//Время сборки предмета 10 секунд
        if (predmet == "bread")
        {
            if (globals.bakery_array_slots_zagruzki[globals.bakery_slots_zagruzki_open - 1,0] != "")//Если последний открытый слот пекарни не пустой
            {
                Debug.Log("Очередь производства заполнена! Подожди, ускорь или докупи ячейки!");
                return;
            }
            building_time = 20;//Время сборки
            if (globals.wheat - 3 >= 0)
            {
                globals.wheat = globals.wheat - 3;
            }
            else
            {
                Debug.Log("Нехватает ингредиентов!");
                globals.price_for_diamonds_panel_current_item = predmet;//Присваиваем переменной предмет, у которого нехватает ингредиентов
                globals.price_for_diamonds_panel_slot_0_quantity = (globals.wheat-3)*(-1);
                globals.price_for_diamonds_panel_slot_0_predmet_name = "wheat";
                globals.price_for_diamonds_panel_slot_0_predmet_info = "Сбор урожая через 2 м.";
                globals.price_for_diamonds_panel_slot_0_predmet_building_time = "2 м.";
                globals.price_for_diamonds_panel_button_ok_diamonds_quantity = globals.wheat_price_for_diamonds * globals.price_for_diamonds_panel_slot_0_quantity;
                GameObject_Enable_Controller.price_for_diamonds_panel.SetActive(true);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_0.SetActive(true);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_1.SetActive(false);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_2.SetActive(false);
                GameObject_Enable_Controller.price_for_diamonds_panel_slot_3.SetActive(false);
                return;
            }
        }
        if (predmet == "corn_bread")
        {
            building_time = 22;//Время сборки

            if ((globals.corn - 2 >= 0)&&(globals.egg - 2 >= 0))//Если всего хватает
            {               
                globals.corn = globals.corn - 2;
                globals.egg = globals.egg - 2;
            }
            else
            {
                Debug.Log("Нехватает ингредиентов!");
                Debug.Log("corn:"+globals.corn+ "egg:" + globals.egg);
                globals.price_for_diamonds_panel_current_item = predmet;//Присваиваем переменной предмет, у которого нехватает ингредиентов
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
                    //Количество необходимых алмазов = цена продукта в алмазах * количество
                    globals.price_for_diamonds_panel_button_ok_diamonds_quantity =
                                                  (globals.corn_price_for_diamonds * globals.price_for_diamonds_panel_slot_0_quantity) +
                                                  (globals.egg_price_for_diamonds * globals.price_for_diamonds_panel_slot_1_quantity);
                    Debug.Log("globals.price_for_diamonds_panel_button_ok_diamonds_quantity=" + globals.price_for_diamonds_panel_button_ok_diamonds_quantity);
                    Debug.Log("globals.price_for_diamonds_panel_slot_0_quantity=" + globals.price_for_diamonds_panel_slot_0_quantity);
                    Debug.Log("globals.egg_price_for_diamonds=" + globals.egg_price_for_diamonds);
                    Debug.Log("globals.price_for_diamonds_panel_slot_1_quantity="+ globals.price_for_diamonds_panel_slot_1_quantity);
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
                    globals.price_for_diamonds_panel_slot_0_predmet_info = "Сбор урожая через 2м.";
                    globals.price_for_diamonds_panel_slot_0_predmet_building_time = "2 м.";
                    //Количество необходимых алмазов = цена продукта в алмазах * количество
                    globals.price_for_diamonds_panel_button_ok_diamonds_quantity =globals.corn_price_for_diamonds * globals.price_for_diamonds_panel_slot_0_quantity;
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
                    globals.price_for_diamonds_panel_slot_0_predmet_info = "Берется у кур.";
                    globals.price_for_diamonds_panel_slot_0_predmet_building_time = "20 м.";
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
        if (predmet == "cookie")
        {
            building_time = 22;//Время сборки, добавить сюда глобальную переменную

            if ((globals.corn - 2 >= 0) && (globals.egg - 2 >= 0))//Если всего хватает
            {
                globals.corn = globals.corn - 2;
                globals.egg = globals.egg - 2;
            }
            else
            {
                Debug.Log("Нехватает ингредиентов!");
                Debug.Log("corn:" + globals.corn + "egg:" + globals.egg);
                globals.price_for_diamonds_panel_current_item = predmet;//Присваиваем переменной предмет, у которого нехватает ингредиентов
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
                    globals.price_for_diamonds_panel_slot_0_predmet_info = "Сбор урожая через 2м.";
                    globals.price_for_diamonds_panel_slot_0_predmet_building_time = "2 м.";
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
                    globals.price_for_diamonds_panel_slot_0_predmet_info = "Берется у кур.";
                    globals.price_for_diamonds_panel_slot_0_predmet_building_time = "20 м.";
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
        var nowtime = DateTime.Now;//Текущее время
        if (globals.bakery_array_slots_zagruzki[0, 0] == "")
        {           
            globals.bakery_array_slots_zagruzki[0, 0] = predmet; //Загружаемый предмет
            globals.bakery_array_slots_zagruzki[0, 1] = Convert.ToString(nowtime, System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat); //Дата загрузки
            globals.bakery_array_slots_zagruzki[0, 2] = Convert.ToString(nowtime.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat); //Дата отгрузки
            Debug.Log("globals.bakery_array_slots_zagruzki[0, 0]" + globals.bakery_array_slots_zagruzki[0, 0]);
            Debug.Log("globals.bakery_array_slots_zagruzki[0, 1]" + globals.bakery_array_slots_zagruzki[0, 1]);
            Debug.Log("globals.bakery_array_slots_zagruzki[0, 2]" + globals.bakery_array_slots_zagruzki[0, 2]);
            return;
        }
        if (globals.bakery_array_slots_zagruzki[1, 0] == "")
        {
            globals.bakery_array_slots_zagruzki[1, 0] = predmet;
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
            globals.bakery_array_slots_zagruzki[2, 0] = predmet;
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
            globals.bakery_array_slots_zagruzki[3, 0] = predmet;
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
            globals.bakery_array_slots_zagruzki[4, 0] = predmet;
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
            globals.bakery_array_slots_zagruzki[5, 0] = predmet;
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
            globals.bakery_array_slots_zagruzki[6, 0] = predmet;
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
            globals.bakery_array_slots_zagruzki[7, 0] = predmet;
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
            globals.bakery_array_slots_zagruzki[8, 0] = predmet;
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
                    temp = globals.bakery_array_slots_zagruzki[i, 1];//Второй столбик
                    globals.bakery_array_slots_zagruzki[i, 1] = globals.bakery_array_slots_zagruzki[j, 1];
                    globals.bakery_array_slots_zagruzki[j, 1] = temp;

                    temp = globals.bakery_array_slots_zagruzki[i, 0];//Первый столбик
                    globals.bakery_array_slots_zagruzki[i, 0] = globals.bakery_array_slots_zagruzki[j, 0];
                    globals.bakery_array_slots_zagruzki[j, 0] = temp;

                    temp = globals.bakery_array_slots_zagruzki[i, 2];//Третий столбик
                    globals.bakery_array_slots_zagruzki[i, 2] = globals.bakery_array_slots_zagruzki[j, 2];
                    globals.bakery_array_slots_zagruzki[j, 2] = temp;
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
        count = 0;
        count_on = false;
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
                gameObject.transform.position = globals.bakery_primary_position;//Возвращаем пекарню на начальную точку
                gameObject.GetComponent<Renderer>().material.color = Color.white;//Делаем нормального цвета
            }
            if (gameObject.GetComponent<Renderer>().material.color == Color.white)
            {
                gameObject.transform.position = globals.bakery_primary_position;
                GameObject.Find("bakery_collider").transform.position = globals.bakery_primary_position;
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
                globals.bakery_array_slots_otgruzki[0, 0] = ""; //Очищаем слот, из которого выгрузили
                globals.bakery_array_slots_otgruzki[0, 1] = ""; //Очищаем слот, из которого выгрузили
                globals.bakery_array_slots_otgruzki[0, 2] = ""; //Очищаем слот, из которого выгрузили
                Debug.Log("bread = " + globals.bread);
                offset_massive_otgruzki();
                return;
            }
            if (globals.bakery_array_slots_otgruzki[0, 0] == "corn_bread")
            {
                Debug.Log("corn_bread mouseup");
                globals.corn_bread++;//Прибавляем количество хлеба на склад
                globals.bakery_array_slots_otgruzki[0, 0] = ""; //Очищаем слот, из которого выгрузили
                globals.bakery_array_slots_otgruzki[0, 1] = ""; //Очищаем слот, из которого выгрузили
                globals.bakery_array_slots_otgruzki[0, 2] = ""; //Очищаем слот, из которого выгрузили
                Debug.Log("corn_bread = " + globals.corn_bread);
                offset_massive_otgruzki();
                return;
            }
            if (globals.bakery_array_slots_otgruzki[0, 0] == "cookie")
            {
                Debug.Log("cookie mouseup");
                globals.cookie++;//Прибавляем количество хлеба на склад
                globals.bakery_array_slots_otgruzki[0, 0] = ""; //Очищаем слот, из которого выгрузили
                globals.bakery_array_slots_otgruzki[0, 1] = ""; //Очищаем слот, из которого выгрузили
                globals.bakery_array_slots_otgruzki[0, 2] = ""; //Очищаем слот, из которого выгрузили
                Debug.Log("cookie = " + globals.cookie);
                offset_massive_otgruzki();
                return;
            }
        }
    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {
        if (globals.bakery_move_mode_on)//Если режим перемещения активирован
        {
            if (gameObject.GetComponent<Renderer>().material.color == Color.white)//Если цвет пекарни обычный
            {
                globals.bakery_primary_position = gameObject.transform.position;//Запоминаем позицию пекарни
            }
        }
        if (globals.bakery_move_mode_on == false)//Если режим перемещения не активирован
        {

            globals.bakery_primary_position = gameObject.transform.position;//Сохраняем первоначальное положение пекарни
            GameObject_Enable_Controller.bakery_arrow.SetActive(true);//Активируем стрелку
            count = 0;//Обнуляем счетчик
            count_on = true;//Запускаем счетчик 
        }
    }
    void OnMouseDrag()//Когда перемещение мыши
    {
        globals.zoom = false;
        globals.drag = false;
        if (globals.bakery_move_mode_on)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            GameObject.Find("bakery_collider").transform.position = curPosition;
            globals.zoom = false;
            globals.drag = false;
        }
    }
}
