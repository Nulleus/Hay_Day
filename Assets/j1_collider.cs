using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class j1_collider : MonoBehaviour
{
    public GameObject bakery_arrow;
    public string nameObject;
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
            Debug.Log("globals.bakery_move_mode_on");
            Debug.Log("globals.collision_move_mod_on"+globals.collision_move_mod_on);
                if (other.gameObject.tag == "production_building")//Необходимо, если в режиме редактирования произошло столкновение
                {
                    globals.collision_move_mod_on = true;
                }
                if ((gameObject.name == "bakery_collider") && //Если этот колайдер стлкнулся с
                ((other.gameObject.tag == "map_collider_green") ||//зеленым колайдером
                (other.gameObject.tag == "map_collider_red"))) //красным коллайдером
                {
                //GameObject.Find.GetComponent<ProductionBuilding>
                GameObject.Find("bakery").transform.position = other.gameObject.transform.position;//Пекарню перемещаем на место колайдера с которым столкнулись в любом случае
                        if (other.gameObject.tag == "map_collider_green") //Если столкнулись с зеленым коллайдером и (не) столкнулись с другим объектом
                        {
                            globals.collision_move_mod_on = false;
                            globals.bakery_primary_position = other.transform.position;//Запоминаем место, где можно расположить пекарню
                        }
                
                        if ((other.gameObject.tag == "map_collider_red"))//Если столкнулись с красным колайдером
                        {
                            globals.collision_move_mod_on = true;
                        }
                }
        }

    }
}