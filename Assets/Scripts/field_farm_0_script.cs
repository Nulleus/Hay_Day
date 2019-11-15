using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class field_farm_0_script : MonoBehaviour
{
    public string name_object = "Поле"; //Наименование объекта на русском языке
    public string obj = "field_farm_0"; //Наименование объекта
    public string type_object = "field";//Тип объекта
    public int ep = 1;//Experience_point Очков опыта за постройку поля
    public int open_lvl = 1; //С какого уровня открывается поле
    public int diamond_price; //Стоимость в алмазах
    public int user_id; //Владелец объекта
    public string type_sklad = "magazin"; //Тип склада, на котором хранится объект
    public DateTime plane_at; // Время, с которого будет доступен объект
    public bool visible;//Доступен ли объект
    public Animator field_anim;//Анимация поля
    public DateTime time_stage_1;//Время конца 1ой стадии
    public DateTime time_stage_2;//Время конца 2ой стадии
    public DateTime time_stage_3;//Время конца 3ей стадии
    public DateTime time_stage_4;//Время конца 4ой стадии
    public DateTime time_stage_5;//Время конца 5ой стадии
    public DateTime time_stage_5_begin;//Время начала пятой стадии
    public DateTime time_stage_5_end;//Время конца пятой стадии
    public DateTime t_zagruzki;//Время загрузки культуры на поле
    public DateTime t_otgruzki;//Время отгрузки культуры на поле
    public int stage = 0;//Номер стадии анимации
    public string crop;//Предмет, который посадили на поле
    public int i, j;//Используется для цикла анимации
    public int i_a;//Используетс для цикла анимации
    public Vector3 screenPoint;
    public Vector3 offset; //Смещение
    public Vector3 primary_position;//Сохранение начального положения объкта
    public GameObject visible_slot; //Слоты предметов
    public GameObject visible_sickle;//Видимость серпа
    public int building_time;//Время до сборки урожая

    public int wheat_quantity = 0;
    public int corn_quantity = 0;
    public int soybean_quantity = 0;
    public int sugarcane_quantity = 0;
    public int carrot_quantity = 0;
    public int pumpkin_quantity = 0;

    public int bread_quantity = 0;
    public int chicken_feed_quantity = 0;
    public int egg_quantity = 0;
    public int cow_feed_quantity = 0;
    public int milk_quantity = 0;
    public int cream_quantity = 0;
    public int popcorn_quantity = 0;
    public int butter_quantity = 0;
    //================silo===============================//
    public Text wheat_silo_quantity_text;
    public Text corn_silo_quantity_text;
    public Text soybean_silo_quantity_text;
    public Text sugarcane_silo_quantity_text;
    public Text carrot_silo_quantity_text;
    public Text pumpkin_silo_quantity_text;

    public Text wheat_field_panel_quantity_text;
    public Text corn_field_panel_quantity_text;
    public Text soybean_field_panel_quantity_text;
    public Text sugarcane_field_panel_quantity_text;
    public Text carrot_field_panel_quantity_text;
    public Text pumpkin_field_panel_quantity_text;

    //=====================barn================================//
    public Text bread_barn_quantity_text;
    public Text chicken_feed_barn_quantity_text;
    public Text egg_barn_quantity_text;
    public Text cow_feed_barn_quantity_text;
    public Text milk_barn_quantity_text;
    public Text cream_barn_quantity_text;
    public Text popcorn_barn_quantity_text;
    public Text butter_barn_quantity_text;

    public static field_farm_0_script field_farm_0_class;
    // Start is called before the first frame update
    void Start()
    {
        visible_slot = GameObject.Find("slots_predmets_field_farm_0");
        visible_sickle = GameObject.Find("slot_sickle_field_farm");
        

        user_id = 1;
        //SQL_Data_Load_Slots();
        //SQL_Data_Objects();
        //SQL_Data_Field();
        if (gameObject.tag == "field")
        {
            field_anim = GetComponent<Animator>();
        }
        
        
        //dict = new Dictionary<string, int>(5);
        //При загузке, сюда добавляются данные из базы.
        crop = "wheat";//Посаженная культура
        stage = 0;
        t_zagruzki = DateTime.Now;
        t_otgruzki = DateTime.Now;
        building_time = 10;//Время до сборки урожая
        time_stage_1 = DateTime.Now;
        time_stage_2 = DateTime.Now;
        time_stage_3 = DateTime.Now;
        time_stage_4 = DateTime.Now;
        time_stage_5 = DateTime.Now;
        time_stage_5_begin = DateTime.Now;
        time_stage_5_end = DateTime.Now;
    }
    // Update is called once per frame
    void Update()
    {
        Animation_Control();
        //quantity_update();
    }
    public void Animation_Control()
    {
        if (gameObject.tag == "field")
        {
            //Проверка стадии по времени
            var nowtime = DateTime.Now;//Получаем текущее время
            if (nowtime >= time_stage_1 && nowtime <= time_stage_2) { stage = 2; }//Стадия 2
            if (nowtime >= time_stage_2 && nowtime <= time_stage_3) { stage = 3; }//Стадия 3
            if (nowtime >= time_stage_3 && nowtime <= time_stage_4) { stage = 4; }//Стадия 4
            if (nowtime >= time_stage_5_begin && nowtime <= time_stage_5_end) { stage = 5; }//Стадия 5
            if (nowtime >= time_stage_5_end && stage == 5) { stage = 0; }//После сбора, переводим поле в стадию 0 т.е свободно

            //Анимация
            for (int i = 0; i <= 5; i++)
            {
                //Debug.Log(slot_0_predmet + i);
                if (stage == i) { field_anim.CrossFade("field_" + crop + "_stage_" + i, 0); }//Если Состояние этапа=i
                if (stage == 4) { visible_sickle.SetActive(true); visible_slot.SetActive(false); }//Если стадия 4, активируем слот с серпом и диактивируем слот с культурыми
                if (stage == 1) { visible_sickle.SetActive(false); visible_slot.SetActive(true); }//Если стадия 1, диактивируем слот с серпом и активируем слот с культурыми
                //if (stage == 5) { visible_sickle.SetActive(false); }//Если стадия 5, диактивируем слот с серпом
            }
        }

    }
    void OnMouseUp()//Когда отпускаешь кнопку
    {
        if (gameObject.tag == "silo")
        {
            gameObject.transform.position = primary_position;//Отправляем объект на первоначальную позицию объекта
        }
        

            if (stage == 0)
            {
                visible_sickle.SetActive(false);
                if (visible_slot.activeSelf)//Если объект slots_predmets_field_farm_0 активен
                {
                    Debug.Log("Deactivation obj");
                    visible_slot.SetActive(false);
                }
                else //Если объект slots_predmets_field_farm_0 НЕ активен
                {
                    visible_slot.SetActive(true);
                }
            }//Если кликнули по полю 0 и стадия = 0(можно сажать), тогда активируем Слоты с культурами и диактивируем Слот с серпом
            if (stage == 4)
            {
                visible_slot.SetActive(false);
                //Управление слотами с серпом
                if (visible_sickle.activeSelf)
                {
                    Debug.Log("Deactivation obj");
                    visible_sickle.SetActive(false);
                }
                else
                {
                    visible_sickle.SetActive(true);
                }
            }//Если кликнули по полю 0 и стадия = 4(сбор), тогда активируем Серп и диактивируем Слоты с культурами



    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {
        if (gameObject.tag == "silo")
        {
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            primary_position = gameObject.transform.position; //Запоминием первоначальную позицию объекта
        }
        

        
    }
    void OnMouseDrag()//Когда перемещение мыши
    {
        if (gameObject.tag == "silo")
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            //Debug.Log("curScreenPoint" + curScreenPoint);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            //Debug.Log("curPosition" + curPosition);
            transform.position = curPosition;
        }

            globals.zoom = false;
            globals.drag = false;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("other:" + other.gameObject.name);//Кто столкнулся
        Debug.Log("gameObject:" + gameObject.name);//С кем столкнулся
        //if ((gameObject.tag == "silo") && (other.gameObject.tag == "field"))
        if ((gameObject.tag == "field") && (other.gameObject.name == "sickle"))
        {
            if (stage == 4) //Если состояние этапа==4(Готово для сбора) тогда собираем
            {

                if (crop == "wheat"){globals.wheat = globals.wheat + 2; }
                if (crop == "corn"){ globals.corn = globals.corn + 2; }
                if (crop == "soybean"){ globals.soybean = globals.soybean + 2; }
                if (crop == "sugarcane"){ globals.sugarcane = globals.sugarcane + 2; }
                if (crop == "carrot"){globals.carrot= globals.carrot + 2;}
                if (crop == "pumpkin"){globals.pumpkin= globals.pumpkin + 2;}
                var nowtime = DateTime.Now;
                time_stage_5_begin = nowtime;
                time_stage_5_end = nowtime.AddSeconds(2);//Добавляем к текущему времени 5секунд
            }
        }
        if ((gameObject.tag == "field") && (other.gameObject.tag == "silo"))
        {

            if (stage == 0)//Если поле пустое
            {
                //Открывается панель с культурами и выбираем что будем сеять
                crop = other.gameObject.name;//Запоминаем посаженную культуру           
                Debug.Log("crop:" + crop);
                if (crop == "wheat"){ globals.wheat = globals.wheat - 1; ; }
                if (crop == "corn") { globals.corn = globals.corn - 1; }
                if (crop == "soybean") { globals.soybean = globals.soybean - 1; }
                if (crop == "sugarcane") { globals.sugarcane = globals.sugarcane - 1; }
                if (crop == "carrot") { globals.carrot = globals.carrot - 1; }
                if (crop == "pumpkin") { globals.pumpkin = globals.pumpkin - 1; }
                stage = 1;//Запускаем первую стадию

                //Тут необходимо сделать запрос в БД для вычисления количества культуры

                //dict[slot_0_predmet] = 10;
                //Debug.Log(dict[slot_0_predmet]);
                t_zagruzki = DateTime.Now;//Получаем текущую дату клика
                t_otgruzki = t_zagruzki.AddSeconds(building_time + (building_time / 5));//Получаем время отгрузки
                time_stage_1 = t_zagruzki.AddSeconds((building_time / 5) * 1);
                time_stage_2 = t_zagruzki.AddSeconds((building_time / 5) * 2);//Получаем время стадии 1, которая идёт после засева
                time_stage_3 = t_zagruzki.AddSeconds((building_time / 5) * 3);//Подробнее см. Документация №1
                time_stage_4 = t_zagruzki.AddSeconds((building_time / 5) * 4);
            }

        }



    }

}
