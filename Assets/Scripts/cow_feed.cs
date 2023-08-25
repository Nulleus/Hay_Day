using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class cow_feed : MonoBehaviour
{
    public Vector3 screenPoint;
    public Vector3 offset; //Смещение
    public Vector3 primary_position;//Сохранение начального положения объкта
    public int building_time;
    // Start is called before the first frame update
    void Start()
    {
        building_time = 10;//Время сборки молочного бидона
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        var nowtime = DateTime.Now;//Получаем текущее время
        Debug.Log("other:" + other.gameObject.name);//С кем столкнулся
        Debug.Log("gameObject:" + gameObject.name);// Кто столкнулся
        if ((gameObject.name == "cow_feed") && (other.gameObject.name == "cow_0"))//Если корова столкнулась со своим кормом
        {
            if (globals.cow_0_stage == 0)//Если корова голодная, кормим её
            {
                globals.cow_0_begin_stage_1 = nowtime;//Время начала первой стадии
                globals.cow_0_end_stage_1 = nowtime.AddSeconds(building_time);//Время конца первой стадии
                globals.cow_feed = globals.cow_feed - 1;//Вычитаем один коровий корм из амбара
                globals.cow_0_stage = 1;//Теперь корова сытая
            }
            //Тогда корове 0 запускаем анимацию и
        }
        if ((gameObject.name == "cow_feed") && (other.gameObject.name == "cow_1"))//Если корова столкнулась со своим кормом
        {
            if (globals.cow_1_stage == 0)//Если корова голодная, кормим её
            {
                globals.cow_1_begin_stage_1 = nowtime;//Время начала первой стадии
                globals.cow_1_end_stage_1 = nowtime.AddSeconds(building_time);//Время конца первой стадии
                globals.cow_feed = globals.cow_feed - 1;//Вычитаем один коровий корм из амбара
                globals.cow_1_stage = 1;//Теперь корова сытая
            }
            //Тогда корове 0 запускаем анимацию и
        }
        if ((gameObject.name == "cow_feed") && (other.gameObject.name == "cow_2"))//Если корова столкнулась со своим кормом
        {
            if (globals.cow_2_stage == 0)//Если корова голодная, кормим её
            {
                globals.cow_2_begin_stage_1 = nowtime;//Время начала первой стадии
                globals.cow_2_end_stage_1 = nowtime.AddSeconds(building_time);//Время конца первой стадии
                globals.cow_feed = globals.cow_feed - 1;//Вычитаем один коровий корм из амбара
                globals.cow_2_stage = 1;//Теперь корова сытая
            }
            //Тогда корове 0 запускаем анимацию и
        }
        if ((gameObject.name == "cow_feed") && (other.gameObject.name == "cow_3"))//Если корова столкнулась со своим кормом
        {
            if (globals.cow_3_stage == 0)//Если корова голодная, кормим её
            {
                globals.cow_3_begin_stage_1 = nowtime;//Время начала первой стадии
                globals.cow_3_end_stage_1 = nowtime.AddSeconds(building_time);//Время конца первой стадии
                globals.cow_feed = globals.cow_feed - 1;//Вычитаем один коровий корм из амбара
                globals.cow_3_stage = 1;//Теперь корова сытая
            }
            //Тогда корове 0 запускаем анимацию и
        }
        if ((gameObject.name == "cow_feed") && (other.gameObject.name == "cow_4"))//Если корова столкнулась со своим кормом
        {
            if (globals.cow_4_stage == 0)//Если корова голодная, кормим её
            {
                globals.cow_4_begin_stage_1 = nowtime;//Время начала первой стадии
                globals.cow_4_end_stage_1 = nowtime.AddSeconds(building_time);//Время конца первой стадии
                globals.cow_feed = globals.cow_feed - 1;//Вычитаем один коровий корм из амбара
                globals.cow_4_stage = 1;//Теперь корова сытая
            }
            //Тогда корове 0 запускаем анимацию и
        }
        if ((gameObject.name == "cow_feed") && (other.gameObject.name == "cow_5"))//Если корова столкнулась со своим кормом
        {
            if (globals.cow_feed - 1 < 0)
            {

            }
            if (globals.cow_5_stage == 0)//Если корова голодная, кормим её
            {
                globals.cow_5_begin_stage_1 = nowtime;//Время начала первой стадии
                globals.cow_5_end_stage_1 = nowtime.AddSeconds(building_time);//Время конца первой стадии
                globals.cow_feed = globals.cow_feed - 1;//Вычитаем один коровий корм из амбара
                globals.cow_5_stage = 1;//Теперь корова сытая
            }
            //Тогда корове 0 запускаем анимацию и
        }
    }
    private void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        primary_position = gameObject.transform.position; //Запоминием первоначальную позицию объекта
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        //Debug.Log("curScreenPoint" + curScreenPoint);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        //Debug.Log("curPosition" + curPosition);
        transform.position = curPosition;
        globals.zoom = false;
        globals.drag = false;
    }
    private void OnMouseUp()
    {
        gameObject.transform.position = primary_position;//Отправляем объект на первоначальную позицию объекта
    }
}