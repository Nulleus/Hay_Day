using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_click : MonoBehaviour
{
    public string Effect;//Действие при нажатии 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {

    }
    void OnMouseUp()
    {
        if (Effect == "Authorization")
        {
            //Процесс авторизации
        }
        //Debug.Log("Нажата кнопка Увеличить вместимость");
        if (gameObject.name == "silo_button_close")
        {
            
        }
        //====================================================================================//
        if (gameObject.name == "silo_button_increase_capacity")//Увеличить вместимость
        {
            Debug.Log("Нажата кнопка Увеличить вместимость");

            

        }

    }
}
