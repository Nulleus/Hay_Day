using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;
using System.Data.SqlClient;
using System.Data;

[RequireComponent(typeof(BoxCollider2D))]

public class field_farm : MonoBehaviour
{
    //======================================//
    //Переменные для загрузки предметов с временного склада из БД
    public string predmet;
    public DateTime plane_at;
    public int user_id;
    //=====================================//
    public string slot_0_predmet;//То, какой предмет находится в слоте 0
    public Dictionary<string, DateTime> predmet_planet_an;//1-Вложенный объект, 2-дата его отгрузки

    public string position;//Позиция
    public int stage;//Стадия 
    public int building_time;//Полное время до сбора пшеницы
    public DateTime t_zagruzki;
    public DateTime t_otgruzki;
    public int open_lvl;
    public DateTime time_stage_1;
    public DateTime time_stage_2;
    public DateTime time_stage_3;
    public DateTime time_stage_4;
    public DateTime time_stage_5;
    public DateTime time_stage_5_begin;
    public DateTime time_stage_5_end;
    public Dictionary<string, int> dict;
    //==============================//
    private Vector3 screenPoint;
    private Vector3 offset;
    //================================//
    private Animator field_anim;
    public DateTime nowtime;

    void OnMouseDown()
    {

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        globals.zoom = false;
        globals.drag = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "field")
        {
            //SQL_Data_Field();
            field_anim = GetComponent<Animator>();
            dict = new Dictionary<string, int>(5);
            //При загузке, сюда добавляются данные из базы.
            slot_0_predmet = "wheat";//Посаженная культура
            user_id = globals.id_user;
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
    }

    // Update is called once per frame
    void Update()
    {

        Animation_Control();



    }
    void OnMouseUp()//Клик мыши по объекту field_farm
    {
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

                sql_client sc = new sql_client();
                //sc.SQL_Data_ID();
                //sc.SQL_Data("select * from TBL_USERS");
                //Debug.Log(sc.SQL_Data("select * from TBL_USERS"));
            }
        }
        if (gameObject.tag == "silo")//Если кликнуи по культуре, тогда это значит что её выбрали и записали в переменную
        {
            Debug.Log("Выбрана: " + gameObject.name);
            globals.predmetname = gameObject.name;
        }
        if (gameObject.tag == "field")//Если кликнули по полю
        {

            if (stage == 0)//Если поле пустое
            {
                //Открывается панель с культурами и выбираем что будем сеять
                stage = 1;//Запускаем первую стадию
                slot_0_predmet = globals.predmetname;//Запоминаем посаженную культуру           //Тут необходимо сделать запрос в БД для вычисления количества культуры
                dict[slot_0_predmet] = 10;
                Debug.Log(dict[slot_0_predmet]);
                t_zagruzki = DateTime.Now;//Получаем текущую дату клика
                t_otgruzki = t_zagruzki.AddSeconds(building_time + (building_time / 5));//Получаем время отгрузки
                time_stage_1 = t_zagruzki.AddSeconds((building_time / 5) * 1);
                time_stage_2 = t_zagruzki.AddSeconds((building_time / 5) * 2);//Получаем время стадии 1, которая идёт после засева
                time_stage_3 = t_zagruzki.AddSeconds((building_time / 5) * 3);//Подробнее см. Документация №1
                time_stage_4 = t_zagruzki.AddSeconds((building_time / 5) * 4);
            }
            if (stage == 4) //Если состояние этапа==4(Готово для сбора) тогда собираем
            {
                dict[slot_0_predmet] = dict[slot_0_predmet] + 2;
                Debug.Log("Количество " + slot_0_predmet + " = " + dict[slot_0_predmet]);
                var nowtime = DateTime.Now;
                time_stage_5_begin = nowtime;
                time_stage_5_end = nowtime.AddSeconds(2);//Добавляем к текущему времени 5секунд
            }
        }


    }
    public void SQL_Data_Field()//Загрузка данных o_sklad Поле и его свойств каких свойств??? У него нет свойств, свойства есть только у культур
    {
        //Connection string
        SqlConnection connstr = new SqlConnection();
        string connectionString = "Server = DESKTOP-56BQNML\\SQL29052019; Database = Farm_DB; User ID = farm_test; Password = z173500SS";
        IDbConnection dbcon;
        using (dbcon = new SqlConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                string sql = "select PREDMET, PLANET_AN from TBL_O_SKLAD WHERE USER_ID='" + globals.id_user + "' AND OBJECT='" + gameObject.name + "'";
                Debug.Log(gameObject.name);
                dbcmd.CommandText = sql;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        predmet = (string)reader["PREDMET"];
                        plane_at = (DateTime)reader["PLANE_AT"];
                        Debug.Log("predmet:" + predmet);
                        Debug.Log("plane_at:" + plane_at);
                    }
                }
            }
        }
    }
    public void SQL_Data_Quantity()
    {
        //Connection string
        SqlConnection connstr = new SqlConnection();
        string connectionString = "Server = DESKTOP-56BQNML\\SQL29052019; Database = Farm_DB; User ID = farm_test; Password = z173500SS";
        IDbConnection dbcon;
        using (dbcon = new SqlConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                string sql = "select PREDMET, PLANET_AN from TBL_O_SKLAD WHERE USER_ID='" + globals.id_user + "' AND OBJECT='" + gameObject.name + "'";
                Debug.Log(gameObject.name);
                dbcmd.CommandText = sql;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        predmet = (string)reader["PREDMET"];
                        plane_at = (DateTime)reader["PLANE_AT"];
                        Debug.Log("predmet:" + predmet);
                        Debug.Log("plane_at:" + plane_at);
                    }
                }
            }
        }
    }
    public void SQL_Data_Add_Sklad()
    {
        //Connection string
        SqlConnection connstr = new SqlConnection();
        string connectionString = "Server = DESKTOP-56BQNML\\SQL29052019; Database = Farm_DB; User ID = farm_test; Password = z173500SS";
        IDbConnection dbcon;
        using (dbcon = new SqlConnection(connectionString))
        {
            dbcon.Open();
            using (IDbCommand dbcmd = dbcon.CreateCommand())
            {
                string sql = "select PREDMET, PLANET_AN from TBL_O_SKLAD WHERE USER_ID='" + globals.id_user + "' AND OBJECT='" + gameObject.name + "'";
                Debug.Log(gameObject.name);
                dbcmd.CommandText = sql;
                using (IDataReader reader = dbcmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        predmet = (string)reader["PREDMET"];
                        plane_at = (DateTime)reader["PLANE_AT"];
                        Debug.Log("predmet:" + predmet);
                        Debug.Log("plane_at:" + plane_at);
                    }
                }
            }
        }
    }
    public void Animation_Control() //Управление анимацией
    {
        if (gameObject.tag == "field")
        {
            //Проверка стадии по времени
            nowtime = DateTime.Now;//Получаем текущее время
            if (nowtime >= time_stage_1 && nowtime <= time_stage_2) { stage = 2; }//Стадия 2
            if (nowtime >= time_stage_2 && nowtime <= time_stage_3) { stage = 3; }//Стадия 3
            if (nowtime >= time_stage_3 && nowtime <= time_stage_4) { stage = 4; }//Стадия 4
            if (nowtime >= time_stage_5_begin && nowtime <= time_stage_5_end) { stage = 5; }//Стадия 5
            if (nowtime >= time_stage_5_end && stage == 5) { stage = 0; }//После сбора, переводим поле в стадию 0 т.е свободно

            //Анимация
            for (int i = 0; i <= 5; i++)
            {
                if (stage == i) { field_anim.CrossFade("field_" + slot_0_predmet + "_stage_" + i, 0); }//Если Состояние этапа=1
            }
        }
    }
}
