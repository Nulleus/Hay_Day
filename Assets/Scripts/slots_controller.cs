using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slots_controller : MonoBehaviour //Контроллер загрузки слотов
{
    public Animator anim;//Анимация поля
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //==================================Пекарня============================//
        for (int i = 0; i < 9; i++)
        {
            
            if ((gameObject.name == "slot_" + i + "_ready_bakery") && (GameObject.Find("bakery").GetComponent<bakery>().array_slots_otgruzki[i, 0] == ""))
            {
                anim.CrossFade("empty", 0);
            }
            if ((gameObject.name == "slot_" + i + "_ready_bakery") && (GameObject.Find("bakery").GetComponent<bakery>().array_slots_otgruzki[i, 0] == "bread"))
            {
                anim.CrossFade("bread", 0);
            }
            if ((gameObject.name == "slot_" + i + "_ready_bakery") && (GameObject.Find("bakery").GetComponent<bakery>().array_slots_otgruzki[i, 0] == "corn_bread"))
            {
                anim.CrossFade("corn_bread", 0);
            }
            if ((gameObject.name == "slot_" + i + "_ready_bakery") && (GameObject.Find("bakery").GetComponent<bakery>().array_slots_otgruzki[i, 0] == "cookie"))
            {
                anim.CrossFade("cookie", 0);
            }
        }
        for (int i = 0; i < 9; i++)
        {
            if ((gameObject.name == "slot_" + i + "_bakery") && (GameObject.Find("bakery").GetComponent<bakery>().array_slots_zagruzki[i, 0] == ""))
            {
                anim.CrossFade("empty", 0);
            }
            if ((gameObject.name == "slot_" + i + "_bakery") && (GameObject.Find("bakery").GetComponent<bakery>().array_slots_zagruzki[i, 0] == "bread"))
            {
                anim.CrossFade("bread", 0);
            }
            if ((gameObject.name == "slot_" + i + "_bakery") && (GameObject.Find("bakery").GetComponent<bakery>().array_slots_zagruzki[i, 0] == "corn_bread"))
            {
                anim.CrossFade("corn_bread", 0);
            }
            if ((gameObject.name == "slot_" + i + "_bakery") && (GameObject.Find("bakery").GetComponent<bakery>().array_slots_zagruzki[i, 0] == "cookie"))
            {
                anim.CrossFade("cookie", 0);
            }
        }
        //===================================Молочный завод====================//
        for (int i = 0; i < 9; i++)
        {

            if ((gameObject.name == "slot_" + i + "_ready_dairy") && (GameObject.Find("dairy").GetComponent<dairy>().array_slots_otgruzki[i, 0] == ""))
            {
                anim.CrossFade("empty", 0);
            }
            if ((gameObject.name == "slot_" + i + "_ready_dairy") && (GameObject.Find("dairy").GetComponent<dairy>().array_slots_otgruzki[i, 0] == "cream"))
            {
                anim.CrossFade("cream", 0);
            }
            if ((gameObject.name == "slot_" + i + "_ready_dairy") && (GameObject.Find("dairy").GetComponent<dairy>().array_slots_otgruzki[i, 0] == "butter"))
            {
                anim.CrossFade("butter", 0);
            }
            if ((gameObject.name == "slot_" + i + "_ready_dairy") && (GameObject.Find("dairy").GetComponent<dairy>().array_slots_otgruzki[i, 0] == "cheese"))
            {
                anim.CrossFade("cheese", 0);
            }
        }
        //========================================================================//
        for (int i = 0; i < 9; i++)
        {
            if ((gameObject.name == "slot_" + i + "_dairy") && (GameObject.Find("dairy").GetComponent<dairy>().array_slots_zagruzki[i, 0] == ""))
            {
                anim.CrossFade("empty", 0);
            }
            if ((gameObject.name == "slot_" + i + "_dairy") && (GameObject.Find("dairy").GetComponent<dairy>().array_slots_zagruzki[i, 0] == "cream"))
            {
                anim.CrossFade("cream", 0);
            }
            if ((gameObject.name == "slot_" + i + "_dairy") && (GameObject.Find("dairy").GetComponent<dairy>().array_slots_zagruzki[i, 0] == "butter"))
            {
                anim.CrossFade("butter", 0);
            }
            if ((gameObject.name == "slot_" + i + "_dairy") && (GameObject.Find("dairy").GetComponent<dairy>().array_slots_zagruzki[i, 0] == "cheese"))
            {
                anim.CrossFade("cheese", 0);
            }

        }
        }
    void OnMouseUp()//Когда отпускаешь кнопку
    {
        for (int i = 0; i < 9; i++)
        {
            if ((gameObject.name == "slot_" + i + "_ready_bakery") && (GameObject.Find("bakery").GetComponent<bakery>().array_slots_otgruzki[i, 0] == "bread"))
            {
                GameObject.Find("bakery").GetComponent<bakery>().barn_bread++;//Прибавляем количество хлеба на склад
                GameObject.Find("bakery").GetComponent<bakery>().array_slots_otgruzki[i, 0] = ""; //Очищаем слот, из которого выгрузили
                Debug.Log("barn_bread = "+GameObject.Find("bakery").GetComponent<bakery>().barn_bread);

            }
            if ((gameObject.name == "slot_" + i + "_ready_bakery") && (GameObject.Find("bakery").GetComponent<bakery>().array_slots_otgruzki[i, 0] == "corn_bread"))
            {
                GameObject.Find("bakery").GetComponent<bakery>().barn_corn_bread++;
            }
            if ((gameObject.name == "slot_" + i + "_ready_bakery") && (GameObject.Find("bakery").GetComponent<bakery>().array_slots_otgruzki[i, 0] == "cookie"))
            {
                GameObject.Find("bakery").GetComponent<bakery>().barn_cookie++;
            }
        }
    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {

    }
    void OnMouseDrag()//Когда перемещение мыши
    {

    }
}
