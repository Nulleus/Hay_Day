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
    private void OnCollisionExit2D(Collision2D collision)//Необходимо, если в режиме редактирования произошло столкновение
    {
        if (globals.bakery_move_mode_on)//Если режим перемещения включен
        {
            if (collision.gameObject.tag == "production_building")
            {
                globals.collision_move_mod_on = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)//При столкновении
    {
        
        if (globals.bakery_move_mode_on)//Если режим перемещения включен
        {

                if (other.gameObject.tag == "production_building")//Необходимо, если в режиме редактирования произошло столкновение
                {
                    globals.collision_move_mod_on = true;
                }
                if ((gameObject.name == "j1_collider") && //Если это колайдер
                ((other.gameObject.tag == "map_collider_green") ||//Если это зеленый колайдер
                (other.gameObject.tag == "map_collider_red"))) //Если это красный колайдер
                {
                GameObject.Find("bakery").transform.position = other.gameObject.transform.position;//Пекарню перемещаем на место колайдера с которым столкнулись в любом случае
                if ((other.gameObject.tag == "map_collider_green") && (globals.collision_move_mod_on == false))//Если столкнулись с зеленым коллайдером и (не) столкнулись с другим объектом
                {
                    GameObject.Find("bakery").GetComponent<Renderer>().material.color = Color.white;//Возвращаем пекарне исходный цвет
                    globals.bakery_primary_position = other.transform.position;//Запоминаем место, где можно расположить пекарню
                }
                
                    if ((other.gameObject.tag == "map_collider_red"))//Если столкнулись с красным колайдером
                    {
                        GameObject.Find("bakery").GetComponent<Renderer>().material.color = Color.red;//Окрашиваем пекарню в красный цвет
                        //globals.bakery_new_position = globals.bakery_primary_position;
                    }


            }
        }

    }
}