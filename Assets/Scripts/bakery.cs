using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class bakery : MonoBehaviour
{
    public Vector3 primary_position;//Сохранение начального положения объкта
    public Vector3 offset; //Смещение
    public Vector3 screenPoint;
    string temp;
    
    public bool mousedrag_block_on = false;

    // Start is called before the first frame update
    void Start()
    {
        var nowtime = DateTime.Now;

    }

    // Update is called once per frame
    void Update()
    {
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


    }
    void otgruzka_predmeta()
    {
        //Добавить цикл прохода, только по откытым слотам
        var nowtime = DateTime.Now;
        
        if (globals.bakery_array_slots_zagruzki[0, 0] != "")//Если слот_0  не пустой 
        {
            TimeSpan time = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[0, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat) - Convert.ToDateTime(nowtime, System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            //Разница дат
            if (GameObject.Find("slot_0_bakery_text"))//Если объект доступен
            {
                GameObject.Find("slot_0_bakery_text").GetComponent<Text>().text = time.Seconds + " c";
                if (time.Seconds <= 0) { GameObject.Find("slot_0_bakery_text").GetComponent<Text>().text = ""; }//Если 0 секунд, убрать текст
            }
            
            if (Convert.ToDateTime(globals.bakery_array_slots_zagruzki[0, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat) < Convert.ToDateTime(nowtime, System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat))
            {
                if (globals.bakery_array_slots_zagruzki[0, 0] == "")
                {
                    globals.bakery_array_slots_otgruzki[0, 0] = globals.bakery_array_slots_zagruzki[0, 0];//Имя предмета
                    globals.bakery_array_slots_zagruzki[0, 0] = "";
                    globals.bakery_array_slots_otgruzki[0, 1] = globals.bakery_array_slots_zagruzki[0, 1];//Дата загрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 1] = "";
                    globals.bakery_array_slots_otgruzki[0, 2] = globals.bakery_array_slots_zagruzki[0, 2]; //Дата отгрузки предмета
                    globals.bakery_array_slots_zagruzki[0, 2] = "";
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
        Debug.Log("add");
        int building_time = 10;//Время сборки предмета 10 секунд
        if (predmet == "bread") { building_time = 10; }//Если предмет хлеб, время сборки составляет 300 секунд
        if (globals.bakery_array_slots_zagruzki[0, 0] == "")
        {
            var nowtime = DateTime.Now;
            globals.bakery_array_slots_zagruzki[0, 0] = predmet; //Загружаемый предмет
            globals.bakery_array_slots_zagruzki[0, 1] = Convert.ToString(nowtime, System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat); //Дата загрузки
            globals.bakery_array_slots_zagruzki[0, 2] = Convert.ToString(nowtime.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat); //Дата отгрузки
            //control_slots();
            return;
        }
        if (globals.bakery_array_slots_zagruzki[1, 0] == "")
        {
            globals.bakery_array_slots_zagruzki[1, 0] = predmet;
            globals.bakery_array_slots_zagruzki[1, 1] = globals.bakery_array_slots_zagruzki[0, 2];
            time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[0, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            globals.bakery_array_slots_zagruzki[1, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            //control_slots();
            return;
        }
        if (globals.bakery_array_slots_zagruzki[2, 0] == "")
        {
            globals.bakery_array_slots_zagruzki[2, 0] = predmet;
            globals.bakery_array_slots_zagruzki[2, 1] = globals.bakery_array_slots_zagruzki[1, 2];
            time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[1, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            globals.bakery_array_slots_zagruzki[2, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            //control_slots();
            return;
        }
        if (globals.bakery_array_slots_zagruzki[3, 0] == "")
        {
            globals.bakery_array_slots_zagruzki[3, 0] = predmet;
            globals.bakery_array_slots_zagruzki[3, 1] = globals.bakery_array_slots_zagruzki[2, 2];
            time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[2, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            globals.bakery_array_slots_zagruzki[3, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            //control_slots();
            return;
        }
        if (globals.bakery_array_slots_zagruzki[4, 0] == "")
        {
            globals.bakery_array_slots_zagruzki[4, 0] = predmet;
            globals.bakery_array_slots_zagruzki[4, 1] = globals.bakery_array_slots_zagruzki[3, 2];
            time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[3, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            globals.bakery_array_slots_zagruzki[4, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            //control_slots();
            return;
        }
        if (globals.bakery_array_slots_zagruzki[5, 0] == "")
        {
            globals.bakery_array_slots_zagruzki[5, 0] = predmet;
            globals.bakery_array_slots_zagruzki[5, 1] = globals.bakery_array_slots_zagruzki[4, 2];
            time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[4, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            globals.bakery_array_slots_zagruzki[5, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            //control_slots();
            return;
        }
        if (globals.bakery_array_slots_zagruzki[6, 0] == "")
        {
            globals.bakery_array_slots_zagruzki[6, 0] = predmet;
            globals.bakery_array_slots_zagruzki[6, 1] = globals.bakery_array_slots_zagruzki[5, 2];
            time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[5, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            globals.bakery_array_slots_zagruzki[6, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            //control_slots();
            return;
        }
        if (globals.bakery_array_slots_zagruzki[7, 0] == "")
        {
            globals.bakery_array_slots_zagruzki[7, 0] = predmet;
            globals.bakery_array_slots_zagruzki[7, 1] = globals.bakery_array_slots_zagruzki[6, 2];
            time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[6, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            globals.bakery_array_slots_zagruzki[7, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            //control_slots();
            return;
        }
        if (globals.bakery_array_slots_zagruzki[8, 0] == "")
        {
            globals.bakery_array_slots_zagruzki[8, 0] = predmet;
            globals.bakery_array_slots_zagruzki[8, 1] = globals.bakery_array_slots_zagruzki[7, 2];
            time_slot = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[7, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            globals.bakery_array_slots_zagruzki[8, 2] = Convert.ToString(time_slot.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            //control_slots();
            return;
        }


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

    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {

    }
    void OnMouseDrag()//Когда перемещение мыши
    {
        globals.zoom = false;
        globals.drag = false;
    }
}
