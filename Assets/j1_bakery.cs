using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class j1_bakery : MonoBehaviour
{
    public int count = 0;
    public bool count_on = false;
    public GameObject bakery_slots_panel;
    public GameObject bakery_arrow;
    public GameObject bakery_arrow_0;
    public GameObject bakery_arrow_1;
    public GameObject bakery_arrow_2;
    public GameObject bakery_arrow_3;
    public GameObject bakery_arrow_4;
    public GameObject farm_box_colliders;

    public Vector3 offset; //Смещение
    public Vector3 screenPoint;
    // Start is called before the first frame update
    void Start()
    {
        bakery_slots_panel = GameObject.Find("bakery_slots_panel");
        bakery_arrow = GameObject.Find("bakery_arrow");
        bakery_arrow_0 = GameObject.Find("bakery_arrow_0");
        bakery_arrow_1 = GameObject.Find("bakery_arrow_1");
        bakery_arrow_2 = GameObject.Find("bakery_arrow_2");
        bakery_arrow_3 = GameObject.Find("bakery_arrow_3");
        bakery_arrow_4 = GameObject.Find("bakery_arrow_4");
        farm_box_colliders = GameObject.Find("farm_map_box_colliders");

        bakery_arrow.SetActive(false);
        bakery_slots_panel.SetActive(false);
        farm_box_colliders.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (globals.bakery_move_mode_on)//Если режим перемещения включен
        {
            if (globals.collision_move_mod_on)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;//Окрашиваем пекарню в красный цвет
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.white;//Окрашиваем пекарню в белый цвет
            }
            if (gameObject.GetComponent<Renderer>().material.color != Color.red)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
            }
            

        }
        else
        {
            bakery_slots_panel.SetActive(false);
            farm_box_colliders.SetActive(false);
            gameObject.GetComponent<Renderer>().material.color = Color.white;

        }
        if (count_on)
        {
            count++;

            if (count == 6) { bakery_arrow_0.GetComponent<Renderer>().material.color = Color.yellow; }
            if (count == 12) { bakery_arrow_1.GetComponent<Renderer>().material.color = Color.yellow; }
            if (count == 18) { bakery_arrow_2.GetComponent<Renderer>().material.color = Color.yellow; }
            if (count == 24) { bakery_arrow_3.GetComponent<Renderer>().material.color = Color.yellow; }
            if (count == 30) { bakery_arrow_4.GetComponent<Renderer>().material.color = Color.yellow; }
            if (count > 30)//Активация режима перемещение
            {
                globals.bakery_move_mode_on = true;//Активация режима перемещение
                bakery_arrow.SetActive(false);//Скрытие стрелочки
                farm_box_colliders.SetActive(true);//Включаем коллайдеры
                bakery_slots_panel.SetActive(true);//Включаем панель с кнопкой Flip
                count_on = false;
                //gameObject.GetComponent<Collider2D>().enabled = false;//Отключаем колайдер пекарне
                //gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {

        Debug.Log(globals.bakery_move_mode_on);

        if (globals.bakery_move_mode_on)//Если режим перемещения активирован
        {
            if (gameObject.GetComponent<Renderer>().material.color == Color.white)
            {
                globals.bakery_primary_position = gameObject.transform.position;
                //globals.bakery_new_position = gameObject.transform.position;
            }
        }
        if (globals.bakery_move_mode_on == false)//Если режим перемещения не активирован
        {

            globals.bakery_primary_position = gameObject.transform.position;//Сохраняем первоначальное положение пекарни
            //globals.bakery_new_position = gameObject.transform.position;
            bakery_arrow.SetActive(true);//Активируем стрелку
            count = 0;//Обнуляем счетчик
            count_on = true;//Запускаем счетчик 
        }


    }
    void OnMouseUp()//Когда отпускаешь кнопку
    {

        count = 0;
        count_on = false;
        bakery_arrow_0.GetComponent<Renderer>().material.color = Color.white;
        bakery_arrow_1.GetComponent<Renderer>().material.color = Color.white;
        bakery_arrow_2.GetComponent<Renderer>().material.color = Color.white;
        bakery_arrow_3.GetComponent<Renderer>().material.color = Color.white;
        bakery_arrow_4.GetComponent<Renderer>().material.color = Color.white;
        bakery_arrow.SetActive(false);

        //gameObject.transform.position = GameObject.Find("j1_bakery").transform.position;//Возвращаем коллайдер к пекарне
        if (globals.bakery_move_mode_on)
        {

            if (gameObject.GetComponent<Renderer>().material.color == Color.red)
            {
                gameObject.transform.position = globals.bakery_primary_position;//Возвращаем пекарню на начальную точку
                //globals.bakery_move_mode_on = false;//Отключаем режим редактирования
                gameObject.GetComponent<Renderer>().material.color = Color.white;//Делаем нормального цвета
            }
            if (gameObject.GetComponent<Renderer>().material.color == Color.white)
            {
                gameObject.transform.position = globals.bakery_primary_position;
                GameObject.Find("j1_collider").transform.position = globals.bakery_primary_position;
                //globals.bakery_move_mode_on = false;//Отключаем режим редактирования
            }
        }

    }
    void OnMouseDrag()//Когда перемещение мыши
    {
        if (globals.bakery_move_mode_on)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            GameObject.Find("j1_collider").transform.position = curPosition;
            globals.zoom = false;
            globals.drag = false;
        }
    }
}