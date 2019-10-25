using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class j1_collider : MonoBehaviour
{
    public GameObject bakery_arrow;
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




    void OnCollisionEnter2D(Collision2D other)//При столкновении
    {
        if (globals.bakery_move_mode_on)//Если режим перемещения включен
        {
            if ((gameObject.name == "j1_collider") && //Если это колайдер
                ((other.gameObject.tag == "map_collider_green") ||//Если это зеленый колайдер
                (other.gameObject.tag == "map_collider_red"))) //Если это красный колайдер
            {
                GameObject.Find("j1_bakery").transform.position = other.gameObject.transform.position;//Пекарню перемещаем на место колайдера с которым столкнулись
                if (other.gameObject.tag == "map_collider_red")//Если столкнулись с красным колайдером
                {
                    GameObject.Find("j1_bakery").GetComponent<Renderer>().material.color = Color.red;//Окрашиваем пекарню в красный цвет
                    //globals.bakery_new_position = globals.bakery_primary_position;
                }
                if (other.gameObject.tag == "map_collider_green")//Если столкнулись с зеленым колайдером
                {
                    GameObject.Find("j1_bakery").GetComponent<Renderer>().material.color = Color.white;//Возвращаем пекарне исходный цвет
                    globals.bakery_primary_position = other.transform.position;//Запоминаем место, где можно расположить пекарню
                }

            }
        }

    }
}