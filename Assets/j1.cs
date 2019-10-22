using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class j1 : MonoBehaviour
{
    public Vector3 primary_position;//Сохранение начального положения объкта
    public Vector3 offset; //Смещение
    public Vector3 screenPoint;
    public bool mousedrag_block_on = false;//Блокировка события MouseDrag
    public bool mouse_up_block_on = false;//Блокировка события MouseUp
    public bool mouse_down_block_on = false;//Блокировка события MouseDown
    public bool travel_mode_on = false;
    public int time = 4;//4 секунды нужно зажимать объект, чтобы ввести его в режим перемещения
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("collider_0_position" + transform.position); // глобальные
        Debug.Log("collider_0_localposition" + transform.localPosition); // локальные
    }

    // Update is called once per frame
    void Update()
    {
        //if ()
    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {
        var nowtime = DateTime.Now;//Получаем текущее время
        //TimeSpan time = 
        mousedrag_block_on = false;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));//Рассчитываем смещение 
        primary_position = gameObject.transform.position;//Запоминаем первоначальную позицию объекта
    }
    void OnMouseUp()//Когда отпускаешь кнопку
    {
        gameObject.transform.position = primary_position;//Загружаем первоначальную позицию объекта
    }

    void OnMouseDrag()//Когда перемещение мыши
    {
        if (mousedrag_block_on == false)
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
    void OnCollisionEnter2D(Collision2D other)//При столкновении
    {
        //Debug.Log("other:" + other.gameObject.name);//Кто столкнулся
        //Debug.Log("gameObject:" + gameObject.name);//С кем столкнулся
        if ((gameObject.name == "j1") && (other.gameObject.name == "farm_map_box_collider_0")) //Загрузка хлеба в slot_backery_0_0
        {
            Debug.Log("Stolknulis'");
            mousedrag_block_on = true;

            gameObject.transform.position = other.gameObject.transform.position;
            //
            //gameObject.transform.position = primary_position; //Тут предмет должен возвратится обратно на начальную позицию
            //bakery.add_in_slot_predmet("bread");
        }
    }
    }
