using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using System.Data.SqlClient;
using System.Data;


public class farm_objects : MonoBehaviour
{
    public string name_object; //Наименование объекта на русском языке
    public string obj; //Наименование объекта
    public string type_object;//Тип объекта
    public int vmestimost_max;//Текущая максимаьная вместимость
    public string one_st;//Времени до первой звезды (one_star_time)
    public string two_st;//Времени до второй звезды (two_star_time)
    public string three_st;//Времени до третьей звезды (three_star_time)
    public string one_sm;//Мастеринг первой звезды (one_star_mastering)
    public string two_sm;//Мастеринг второй звезды (two_star_mastering)
    public string three_sm;//Мастеринг первой звезды (three_star_mastering)
    public int c_p_max;//Максимальная стоимость объекта
    public int building_time;//Время сборки объекта
    public int ep;//(Experience_point Очков опыта
    public int open_lvl; //С какого уровня открывается
    public int diamond_price; //Стоимость в алмазах
    public int user_id; //Владелец объекта
    //public int quantity; //Количество 
    public string transform_object; // Расположение объекта
    public string type_sklad; //Тип склада, на котором хранится объект
    public DateTime plane_at; // Время, с которого будет доступен объект
    public bool visible;//Доступен ли объект
    //====Анимация объекта==================================================//
    private Animator field_anim;//Анимация поля
    public DateTime time_stage_1;//Время конца 1ой стадии
    public DateTime time_stage_2;//Время конца 2ой стадии
    public DateTime time_stage_3;//Время конца 3ей стадии
    public DateTime time_stage_4;//Время конца 4ой стадии
    public DateTime time_stage_5;//Время конца 5ой стадии
    public DateTime time_stage_5_begin;//Время начала пятой стадии
    public DateTime time_stage_5_end;//Время конца пятой стадии
    public DateTime t_zagruzki;//Время загрузки культуры на поле
    public DateTime t_otgruzki;//Время отгрузки культуры на поле
    public int stage;//Номер стадии 
    public string crop;//То, какой предмет находится в слоте 0
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
    //public string predmet_sklad;
    //public DateTime plane_at_sklad;
    public string[] predmet_sklad = new string[8];
    public DateTime[] plane_at_sklad = new DateTime[8];
    public int i,j;//Используется для цикла 
    public int i_a;//Используетс для цикла анимации
    public Vector3 screenPoint;
    public Vector3 offset; //Смещение
    public Vector3 primary_position;//Сохранение начального положения объкта
    public GameObject visible_slot;
    public GameObject visible_sickle;

    public GameObject scrollview;
    public ScrollRect scrollrect;
   
    // Start is called before the first frame update
    /*void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("other:" + other.gameObject.name);//Кто столкнулся
        Debug.Log("gameObject:" + gameObject.name);//С кем столкнулся
        //if ((gameObject.tag == "silo") && (other.gameObject.tag == "field"))
        if ((gameObject.tag == "field")&&(other.gameObject.name == "sickle"))
        {
            if (stage == 4) //Если состояние этапа==4(Готово для сбора) тогда собираем
            {
                
                if (crop == "wheat")
                {
                    quantity_script.quantity_class.quantity_wheat(2);
                    //wheat_quantity_script.silo_wheat.add_quantity_wheat();
                }
                if (crop == "corn")
                {
                    corn_quantity_script.silo_corn.add_quantity_corn();
                }
                if (crop == "soybean")
                {
                    soybean_quantity_script.silo_soybean.add_quantity_soybean();
                }
                    
                //dict[slot_0_predmet] = dict[slot_0_predmet] + 2;
                //Debug.Log("Количество " + slot_0_predmet + " = " + dict[slot_0_predmet]);
                var nowtime = DateTime.Now;
                time_stage_5_begin = nowtime;
                time_stage_5_end = nowtime.AddSeconds(2);//Добавляем к текущему времени 5секунд
            }
        }
        if ((gameObject.tag == "field")&&(other.gameObject.tag == "silo"))
        {

            if (stage == 0)//Если поле пустое
            {
                //Открывается панель с культурами и выбираем что будем сеять
                crop = other.gameObject.name;//Запоминаем посаженную культуру           
                Debug.Log("crop:" + crop);
                if (crop == "wheat")
                {
                    quantity_script.quantity_class.quantity_wheat(-1);
                }
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
        


    }*/
    void Start()
    {
        if (gameObject.name == "scrollview")
        {
            scrollrect = GetComponent<ScrollRect>();
        }
        
        user_id = 1;
        //SQL_Data_Load_Slots();
        //SQL_Data_Objects();
        //SQL_Data_Field();
        field_anim = GetComponent<Animator>();
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
    }
    public void SQL_Data_Objects()//Загрузка данных об объектах
    {
        //Connection string
        SqlConnection connstr = new SqlConnection();
        string connectionString = "Server = 127.0.0.1; Database = Farm_DB; User ID = farm_test; Password = z173500SS";
        IDbConnection dbcon;
        using (dbcon = new SqlConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                string sql = "select NAME_OBJECT, TYPE_OBJECT, VMESTIMOST_MAX, ONE_ST, TWO_ST, THREE_ST, ONE_SM, TWO_SM, THREE_SM, C_P_MAX, BUILDING_TIME, EP, OPEN_LVL, DIAMOND_PRICE, QUANTITY, TRANSFORM_OBJECT, TYPE_SKLAD, PLANET_AT, VISIBLE from TBL_OBJECTS WHERE USER_ID='" + user_id + "' AND OBJECT='" + gameObject.name + "'";
                Debug.Log(gameObject.name);
                dbcmd.CommandText = sql;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Получаем 
                        obj = gameObject.name;
                        name_object = (string)reader["NAME_OBJECT"];
                        type_object = (string)reader["TYPE_OBJECT"];
                        vmestimost_max = (int)reader["VMESTIMOST_MAX"];
                        if ((string)reader["ONE_ST"] != null) { one_st = (string)reader["ONE_ST"]; }
                        two_st = (string)reader["TWO_ST"];
                        three_st = (string)reader["THREE_ST"];
                        one_sm = (string)reader["ONE_SM"];
                        two_sm = (string)reader["TWO_SM"];
                        three_sm = (string)reader["THREE_SM"];
                        c_p_max = (int)reader["C_P_MAX"];
                        building_time = (int)reader["BUILDING_TIME"];
                        ep = (int)reader["EP"];
                        open_lvl = (int)reader["OPEN_LVL"];
                        diamond_price = (int)reader["DIAMOND_PRICE"];
                        user_id = globals.id_user;
                        //quantity = (int)reader["QUANTITY"];
                        transform_object = (string)reader["TRANSFORM_OBJECT"];
                        type_sklad = (string)reader["TYPE_SKLAD"];
                        plane_at = (DateTime)reader["PLANET_AT"];
                        visible = (bool)reader["VISIBLE"];
                        Debug.Log("obj:" + obj);
                        Debug.Log("name_object:" + name_object);

                        Debug.Log("plane_at:" + plane_at);
                    }


                }
            }
        }
    }
    public void SQL_Data_Load_Slots()//Выборка данных из БД об объектах, находящихся в слотах, Получение очереди
    {
        //Connection string
        SqlConnection connstr = new SqlConnection();
        string connectionString = "Server = 127.0.0.1; Database = Farm_DB; User ID = farm_test; Password = z173500SS";
        IDbConnection dbcon;
        using (dbcon = new SqlConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                string sql = "select PREDMET, PLANE_AT from TBL_O_SKLAD WHERE USER_ID='" + user_id + "' AND OBJECT='" + gameObject.name + "'";
                dbcmd.CommandText = sql;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {
                    i = 0;
                   
                    
                    while (reader.Read())
                    {
                        i++;
                        //Массив из предметов двумерный
                        //Получаем 
                        //Тут должно быть распредел/ение по слотам, а то получается, что 
                        predmet_sklad[i] = (string)reader["PREDMET"];
                        plane_at_sklad[i] = (DateTime)reader["PLANE_AT"];
                        Debug.Log("predmet_sklad:" + predmet_sklad[i]);
                        Debug.Log("plane_at_sklad:" + plane_at_sklad[i]);
                    }


                }
            }
        }
    }
    public void Queue_Distribution() //Распределение очереди
    {
        j = 0;
        var nowtime = DateTime.Now;//Получаем текущее время
        while (j < i)
        {
            j++;
            if (nowtime >= plane_at_sklad[j])//Если текущее время больше или равно времени объекта тогда
            {
                
                //Загружаем картинки в слоты для отгрузки согласно предмету
            }
        }
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

        if ((gameObject.tag) != ("panel_silo"))
        {
            gameObject.transform.position = primary_position;//Запоминаем первоначальную позицию объекта
        }
        if (gameObject.tag == "my_button")
        {
            if (gameObject.name == "Button_Cancel_Authorization") { Debug.Log("Button_Cancel_Authorization"); }
            if (gameObject.name == "Button_OK_Authorization")
            {
                GameObject inputfieldlogin = GameObject.Find("InputField_Login");//Получаем ссылку на объект
                InputField inputfieldCoLogin = inputfieldlogin.GetComponent<InputField>();//Получаем компонент объекта
                globals.login_users = inputfieldCoLogin.text;

                GameObject inputfieldpassword = GameObject.Find("InputField_Password");//Получаем ссылку на объект
                InputField inputfieldCoPassword = inputfieldpassword.GetComponent<InputField>();//Получаем компонент объекта
                globals.password_users = inputfieldCoPassword.text;
                Debug.Log(globals.password_users);
                Debug.Log(globals.login_users);

                GameObject panel_authorization = GameObject.Find("panel_authorization");//Получаем ссылку на объект
                panel_authorization.SetActive(false);//Скрываем панель авторизации

                //sql_client sc = new sql_client();
                //sc.SQL_Data_ID();
                //sc.SQL_Data("select * from TBL_USERS");
                //Debug.Log(sc.SQL_Data("select * from TBL_USERS"));
            }
        }
        if (gameObject.tag == "field")//Если кликнули по полю
        {
                
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



    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {
        if ((gameObject.tag) != ("panel_silo"))
        {
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            primary_position = gameObject.transform.position;
        }
    }
    void OnMouseDrag()//Когда перемещение мыши
    {
        if ((gameObject.tag) != ("panel_silo"))
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            //Debug.Log("curScreenPoint" + curScreenPoint);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            //Debug.Log("curPosition" + curPosition);
            transform.position = curPosition;
            globals.zoom = false;
            globals.drag = false;
        }

    }

}
