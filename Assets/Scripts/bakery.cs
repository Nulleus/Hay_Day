using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class bakery : MonoBehaviour
{
    public int count = 0;
    public bool count_on = false;
    public GameObject bakery_slots_panel;
    public GameObject bakery_arrow;
    public GameObject bakery_arrow_0;
    public GameObject bakery_arrow_1;
    public GameObject bakery_arrow_2;
    public GameObject bakery_arrow_3;
    public GameObject bakery_arrow_4;
    public GameObject farm_box_colliders;
    public GameObject bakery_slots_predmets;
    public Vector3 primary_position;//Сохранение начального положения объкта
    public Vector3 offset; //Смещение
    public Vector3 screenPoint;
    string temp;
    
    public bool mousedrag_block_on = false;

    // Start is called before the first frame update
    void Start()
    {
        var nowtime = DateTime.Now;//Текущее время 
        bakery_slots_panel = GameObject.Find("bakery_slots_panel");
        bakery_slots_predmets = GameObject.Find("bakery_slots_predmets");
        bakery_arrow = GameObject.Find("bakery_arrow");
        bakery_arrow_0 = GameObject.Find("bakery_arrow_0");
        bakery_arrow_1 = GameObject.Find("bakery_arrow_1");
        bakery_arrow_2 = GameObject.Find("bakery_arrow_2");
        bakery_arrow_3 = GameObject.Find("bakery_arrow_3");
        bakery_arrow_4 = GameObject.Find("bakery_arrow_4");
        farm_box_colliders = GameObject.Find("farm_map_box_colliders");

        bakery_arrow.SetActive(false);
        bakery_slots_predmets.SetActive(false);
        bakery_slots_panel.SetActive(false);
        farm_box_colliders.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (globals.bakery_move_mode_on)//Если режим перемещения включен
        {
            gameObject.tag = "obj_move_mod";

            if (globals.collision_move_mod_on)
            {
                Debug.Log("Collision_move_mode_on");
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
            bakery_slots_panel.SetActive(false);
            farm_box_colliders.SetActive(false);
            gameObject.GetComponent<Renderer>().material.color = Color.white;
            gameObject.tag = globals.bakery_type_obj;//

        }
        if (count_on)
        {
            count++;

            if (count == 6) { bakery_arrow_0.GetComponent<Renderer>().material.color = Color.yellow; }
            if (count == 12) { bakery_arrow_1.GetComponent<Renderer>().material.color = Color.yellow; }
            if (count == 18) { bakery_arrow_2.GetComponent<Renderer>().material.color = Color.yellow; }
            if (count == 24) { bakery_arrow_3.GetComponent<Renderer>().material.color = Color.yellow; }
            if (count == 30) { bakery_arrow_4.GetComponent<Renderer>().material.color = Color.yellow; }
            if (count > 30)//Активация режима перемещение
            {
                globals.bakery_move_mode_on = true;//Активация режима перемещение
                bakery_arrow.SetActive(false);//Скрытие стрелочки
                farm_box_colliders.SetActive(true);//Включаем коллайдеры
                bakery_slots_panel.SetActive(true);//Включаем панель с кнопкой Flip
                count_on = false;
                //gameObject.GetComponent<Collider2D>().enabled = false;//Отключаем колайдер пекарне
                //gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        otgruzka_predmeta();//Контоль отгрузк предмета
        if (globals.bakery_visible) { gameObject.SetActive(true); }
        else { gameObject.SetActive(false); }
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
            if (GameObject.Find("slot_0_bakery_text"))//Если объект доступен
            {
                GameObject.Find("slot_0_bakery_text").GetComponent<Text>().text = time.Seconds + " c";
                if (time.Seconds <= 0) { GameObject.Find("slot_0_bakery_text").GetComponent<Text>().text = ""; }//Если 0 секунд, убрать текст
            }
            
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
        DateTime time_slot;
        Debug.Log("add: "+predmet);
        int building_time = 20;//Время сборки предмета 10 секунд
        if (predmet == "bread") { building_time = 20; }//Если предмет хлеб, время сборки(building time) составляет 10 секунд
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
        Debug.Log("globals.bakery_array_slots_zagruzki[0, 0]" + globals.bakery_array_slots_zagruzki[0, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[0, 1]" + globals.bakery_array_slots_zagruzki[0, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[0, 2]" + globals.bakery_array_slots_zagruzki[0, 2]);
        Debug.Log("globals.bakery_array_slots_zagruzki[1, 0]" + globals.bakery_array_slots_zagruzki[1, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[1, 1]" + globals.bakery_array_slots_zagruzki[1, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[1, 2]" + globals.bakery_array_slots_zagruzki[1, 2]);
        Debug.Log("globals.bakery_array_slots_zagruzki[2, 0]" + globals.bakery_array_slots_zagruzki[2, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[2, 1]" + globals.bakery_array_slots_zagruzki[2, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[2, 2]" + globals.bakery_array_slots_zagruzki[2, 2]);
        Debug.Log("globals.bakery_array_slots_zagruzki[3, 0]" + globals.bakery_array_slots_zagruzki[3, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[3, 1]" + globals.bakery_array_slots_zagruzki[3, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[3, 2]" + globals.bakery_array_slots_zagruzki[3, 2]);
        Debug.Log("globals.bakery_array_slots_zagruzki[4, 0]" + globals.bakery_array_slots_zagruzki[4, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[4, 0]" + globals.bakery_array_slots_zagruzki[4, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[4, 1]" + globals.bakery_array_slots_zagruzki[4, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[4, 2]" + globals.bakery_array_slots_zagruzki[4, 2]);
        Debug.Log("globals.bakery_array_slots_zagruzki[5, 0]" + globals.bakery_array_slots_zagruzki[5, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[5, 1]" + globals.bakery_array_slots_zagruzki[5, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[5, 2]" + globals.bakery_array_slots_zagruzki[5, 2]);
        Debug.Log("globals.bakery_array_slots_zagruzki[6, 0]" + globals.bakery_array_slots_zagruzki[6, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[6, 1]" + globals.bakery_array_slots_zagruzki[6, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[6, 2]" + globals.bakery_array_slots_zagruzki[6, 2]);
        Debug.Log("globals.bakery_array_slots_zagruzki[7, 0]" + globals.bakery_array_slots_zagruzki[7, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[7, 1]" + globals.bakery_array_slots_zagruzki[7, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[7, 2]" + globals.bakery_array_slots_zagruzki[7, 2]);
        Debug.Log("globals.bakery_array_slots_zagruzki[8, 0]" + globals.bakery_array_slots_zagruzki[8, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[8, 1]" + globals.bakery_array_slots_zagruzki[8, 1]);
        Debug.Log("globals.bakery_array_slots_zagruzki[8, 2]" + globals.bakery_array_slots_zagruzki[8, 2]);
        
        count = 0;
        count_on = false;
        bakery_arrow_0.GetComponent<Renderer>().material.color = Color.white;
        bakery_arrow_1.GetComponent<Renderer>().material.color = Color.white;
        bakery_arrow_2.GetComponent<Renderer>().material.color = Color.white;
        bakery_arrow_3.GetComponent<Renderer>().material.color = Color.white;
        bakery_arrow_4.GetComponent<Renderer>().material.color = Color.white;
        bakery_arrow.SetActive(false);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;//Включаем коллайдер пекарни обратно
        //gameObject.transform.position = GameObject.Find("j1_bakery").transform.position;//Возвращаем коллайдер к пекарне
        if (globals.bakery_move_mode_on)
        {

            if (gameObject.GetComponent<Renderer>().material.color == Color.red)
            {
                gameObject.transform.position = globals.bakery_primary_position;//Возвращаем пекарню на начальную точку
                //globals.bakery_move_mode_on = false;//Отключаем режим редактирования
                gameObject.GetComponent<Renderer>().material.color = Color.white;//Делаем нормального цвета
            }
            if (gameObject.GetComponent<Renderer>().material.color == Color.white)
            {
                gameObject.transform.position = globals.bakery_primary_position;
                GameObject.Find("bakery_collider").transform.position = globals.bakery_primary_position;
                //globals.bakery_move_mode_on = false;//Отключаем режим редактирования
            }

        }
        else//Если globals.bakery_move_mode_on==false
        {

            if (bakery_slots_predmets.activeSelf)
            {
                bakery_slots_predmets.SetActive(false);
            }
            else
            {
                bakery_slots_predmets.SetActive(true);
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
        Debug.Log(globals.bakery_move_mode_on);

        if (globals.bakery_move_mode_on)//Если режим перемещения активирован
        {
            if (gameObject.GetComponent<Renderer>().material.color == Color.white)//Если цвет пекарни обычный
            {
                globals.bakery_primary_position = gameObject.transform.position;//Запоминаем позицию пекарни
                //globals.bakery_new_position = gameObject.transform.position;
            }
        }
        if (globals.bakery_move_mode_on == false)//Если режим перемещения не активирован
        {

            globals.bakery_primary_position = gameObject.transform.position;//Сохраняем первоначальное положение пекарни
            bakery_arrow.SetActive(true);//Активируем стрелку
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
