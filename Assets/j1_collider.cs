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
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("collider_0_position" + transform.position); // глобальные
        //Debug.Log("collider_0_localposition" + transform.localPosition); // локальные
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {
        if (globals.bakery_move_mode_on)
        {
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));//Рассчитываем смещение 
            primary_position = gameObject.transform.position;//Запоминаем первоначальную позицию объекта
            GameObject.Find("j1_bakery").transform.position = gameObject.transform.position;
        }


    }
    void OnMouseUp()//Когда отпускаешь кнопку
    {
        if (globals.bakery_move_mode_on)
        {
           gameObject.transform.position = GameObject.Find("j1_bakery").transform.position;//
            if (GameObject.Find("j1_bakery").GetComponent<Renderer>().material.color == Color.red)
            {
                GameObject.Find("j1_bakery").transform.position = primary_position;
                GameObject.Find("j1_bakery").GetComponent<Renderer>().material.color = Color.white;
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
        if (globals.bakery_move_mode_on)
        {
            if ((gameObject.name == "j1_collider") && 
                ((other.gameObject.tag == "map_collider_green")||
                (other.gameObject.tag == "map_collider_red"))) 
            {
                GameObject.Find("j1_bakery").transform.position = other.gameObject.transform.position;
                if (other.gameObject.tag == "map_collider_red")
                {
                    GameObject.Find("j1_bakery").GetComponent<Renderer>().material.color = Color.red;
                }
                if (other.gameObject.tag == "map_collider_green")
                {
                    GameObject.Find("j1_bakery").GetComponent<Renderer>().material.color = Color.white;
                }

            }
        }

    }
}
