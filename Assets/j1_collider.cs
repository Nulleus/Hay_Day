using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class j1_collider : MonoBehaviour
{
    public Vector3 primary_position;//Сохранение начального положения объкта
    public Vector3 offset; //Смещение
    public Vector3 screenPoint;
    public bool mousedrag_block_on = false;//Блокировка события MouseDrag
    public bool mouse_up_block_on = false;//Блокировка события MouseUp
    public bool mouse_down_block_on = false;//Блокировка события MouseDown
    public bool travel_mode_on = false;
    public int time = 4;//4 секунды нужно зажимать объект, чтобы ввести его в режим перемещения
    public GameObject bakery_arrow;
    // Start is called before the first frame update
    void Start()
    {
        bakery_arrow = GameObject.Find("bakery_arrow");
        bakery_arrow.SetActive(false);
        //Debug.Log("collider_0_position" + transform.position); // глобальные
        //Debug.Log("collider_0_localposition" + transform.localPosition); // локальные
    }

    // Update is called once per frame
    void Update()
    {
    if (globals.bakery_move_mode_on)
        {
            GameObject.Find("j1_bakery").GetComponent<Collider2D>().enabled = false;
        }
        if (globals.bakery_move_mode_on==false)
        {
            GameObject.Find("j1_bakery").GetComponent<Collider2D>().enabled = true;            
        }
    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {
        if (globals.bakery_move_mode_on)
        {
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));//Рассчитываем смещение 
            //primary_position = gameObject.transform.position;//Запоминаем первоначальную позицию объекта
            gameObject.transform.position = GameObject.Find("j1_bakery").transform.position;//Колайдеру присваиваем положение пекарни
        }


    }
    void OnMouseUp()//Когда отпускаешь кнопку
    {
        
        gameObject.transform.position = GameObject.Find("j1_bakery").transform.position;//Возвращаем коллайдер к пекарне
        if (globals.bakery_move_mode_on)
        {
           
            if (GameObject.Find("j1_bakery").GetComponent<Renderer>().material.color == Color.red)
            {
                GameObject.Find("j1_bakery").transform.position = globals.bakery_primary_position;//Возвращаем пекарню на начальную точку
                globals.bakery_move_mode_on = false;//Отключаем режим редактирования
                GameObject.Find("j1_bakery").GetComponent<Renderer>().material.color = Color.white;//Делаем нормального цвета
            }
            if (GameObject.Find("j1_bakery").GetComponent<Renderer>().material.color == Color.white)
            {
                GameObject.Find("j1_bakery").transform.position = globals.bakery_new_position;
                GameObject.Find("j1_collider").transform.position = globals.bakery_new_position;
                globals.bakery_move_mode_on = false;//Отключаем режим редактирования
            }
        }
    }

    void OnMouseDrag()//Когда перемещение мыши
    {
        if (globals.bakery_move_mode_on)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
            globals.zoom = false;
            globals.drag = false;
        }

    }
    void OnCollisionEnter2D(Collision2D other)//При столкновении
    {
        if (globals.bakery_move_mode_on)//Если режим перемещения включен
        {
            if ((gameObject.name == "j1_collider") && //Если это колайдер
                ((other.gameObject.tag == "map_collider_green")||//Если это зеленый колайдер
                (other.gameObject.tag == "map_collider_red"))) //Если это красный колайдер
            {
                GameObject.Find("j1_bakery").transform.position = other.gameObject.transform.position;//Пекарню перемещаем на место колайдера с которым столкнулись
                if (other.gameObject.tag == "map_collider_red")//Если столкнулись с красным колайдером
                {
                    GameObject.Find("j1_bakery").GetComponent<Renderer>().material.color = Color.red;//Окрашиваем пекарню в красный цвет
                    globals.bakery_new_position = globals.bakery_primary_position;
                }
                if (other.gameObject.tag == "map_collider_green")//Если столкнулись с зеленым колайдером
                {
                    GameObject.Find("j1_bakery").GetComponent<Renderer>().material.color = Color.white;//Возвращаем пекарне исходный цвет
                    globals.bakery_new_position = other.transform.position;//Запоминаем место, где можно расположить пекарню
                }

            }
        }

    }
}
