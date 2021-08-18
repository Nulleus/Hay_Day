using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class j1_collider : MonoBehaviour
{
    public GameObject ArrowParent;
    public GameObject SubjectParent;
    public bool MoveMode; //Активация режима перемещения 
    public Vector3 PrimaryPosition; //Первичные координаты объекта
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
        if (MoveMode)//Если режим перемещения включен
        {
            //Проверяем, с каким объектом столкнулись
            if (collision.gameObject.tag == "production_building")
            {
                MoveMode = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)//При столкновении
    {
        
        if (MoveMode)//Если режим перемещения включен
        {
            Debug.Log("MoveMode "+MoveMode);
                if (other.gameObject.tag == "production_building")//Необходимо, если в режиме редактирования произошло столкновение
                {
                    MoveMode = true;
                }
                if ((gameObject.name == "Collider") && //Если этот колайдер столкнулся с
                ((other.gameObject.tag == "map_collider_green") ||//зеленым колайдером
                (other.gameObject.tag == "map_collider_red"))) //красным коллайдером
                {
                //GameObject.Find.GetComponent<ProductionBuilding>
                SubjectParent.transform.position = other.gameObject.transform.position;//Пекарню перемещаем на место колайдера с которым столкнулись в любом случае
                        if (other.gameObject.tag == "map_collider_green") //Если столкнулись с зеленым коллайдером и (не) столкнулись с другим объектом
                        {
                            MoveMode = false;
                            PrimaryPosition = other.transform.position;//Запоминаем место, где можно расположить пекарню
                        }
                
                        if ((other.gameObject.tag == "map_collider_red"))//Если столкнулись с красным колайдером
                        {
                            MoveMode = true;
                        }
                }
        }

    }
}