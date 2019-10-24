using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class j1_bakery : MonoBehaviour
{
    public int count=0;
    public bool count_on = false;
    public GameObject bakery_arrow;
    public GameObject bakery_arrow_0;
    public GameObject bakery_arrow_1;
    public GameObject bakery_arrow_2;
    public GameObject bakery_arrow_3;
    public GameObject bakery_arrow_4;
    // Start is called before the first frame update
    void Start()
    {
        bakery_arrow = GameObject.Find("bakery_arrow");
        bakery_arrow_0 = GameObject.Find("bakery_arrow_0");
        bakery_arrow_1 = GameObject.Find("bakery_arrow_1");
        bakery_arrow_2 = GameObject.Find("bakery_arrow_2");
        bakery_arrow_3 = GameObject.Find("bakery_arrow_3");
        bakery_arrow_4 = GameObject.Find("bakery_arrow_4");
    }

    // Update is called once per frame
    void Update()
    {
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
                gameObject.GetComponent<Collider2D>().enabled = false;//Отключаем колайдер пекарне
                //gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {
        
        Debug.Log(globals.bakery_move_mode_on);
        if (globals.bakery_move_mode_on == false)//Если режим перемещения не активирован
        {
            
            globals.bakery_primary_position = gameObject.transform.position;//Сохраняем первоначальное положение пекарни
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

    }
    void OnMouseEnter()
    {
        
    }
}
