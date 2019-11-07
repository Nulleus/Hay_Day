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
            
            if ((gameObject.name == "slot_" + i + "_ready_bakery") && (globals.bakery_array_slots_otgruzki[i, 0] == ""))
            {
                anim.CrossFade("empty", 0);
            }
            if ((gameObject.name == "slot_" + i + "_ready_bakery") && (globals.bakery_array_slots_otgruzki[i, 0] == "bread"))
            {
                anim.CrossFade("bread", 0);
            }
            if ((gameObject.name == "slot_" + i + "_ready_bakery") && (globals.bakery_array_slots_otgruzki[i, 0] == "corn_bread"))
            {
                anim.CrossFade("corn_bread", 0);
            }
            if ((gameObject.name == "slot_" + i + "_ready_bakery") && (globals.bakery_array_slots_otgruzki[i, 0] == "cookie"))
            {
                anim.CrossFade("cookie", 0);
            }
        }
        for (int i = 0; i < 9; i++)
        {
            if ((gameObject.name == "slot_" + i + "_bakery") && (globals.bakery_array_slots_zagruzki[i, 0] == ""))
            {
                anim.CrossFade("empty", 0);
            }
            if ((gameObject.name == "slot_" + i + "_bakery") && (globals.bakery_array_slots_zagruzki[i, 0] == "bread"))
            {
                anim.CrossFade("bread", 0);
            }
            if ((gameObject.name == "slot_" + i + "_bakery") && (globals.bakery_array_slots_zagruzki[i, 0] == "corn_bread"))
            {
                anim.CrossFade("corn_bread", 0);
            }
            if ((gameObject.name == "slot_" + i + "_bakery") && (globals.bakery_array_slots_zagruzki[i, 0] == "cookie"))
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
        /*for (int i = 0; i < globals.bakery_slots_zagruzki_open; i++)
        {
            if (globals.bakery_array_slots_otgruzki[i, 0] == "bread")
            {
                globals.bread++;//Прибавляем количество хлеба на склад
                globals.bakery_array_slots_otgruzki[i, 0] = ""; //Очищаем слот, из которого выгрузили
                Debug.Log("bread = " + globals.bread);
            }
        }*/
      /*  for (int i = 0; i < 9; i++)
        {
            //Пекарня
            if ((gameObject.name == "slot_" + i + "_ready_bakery") && (globals.bakery_array_slots_otgruzki[i, 0] == "bread"))
            {
                globals.bread++;//Прибавляем количество хлеба на склад
                globals.bakery_array_slots_otgruzki[i, 0] = ""; //Очищаем слот, из которого выгрузили
                Debug.Log("bread = "+globals.bread);

            }
            if ((gameObject.name == "slot_" + i + "_ready_bakery") && (globals.bakery_array_slots_otgruzki[i, 0] == "corn_bread"))
            {
                globals.corn_bread++;
                globals.bakery_array_slots_otgruzki[i, 0] = "";
            }
            if ((gameObject.name == "slot_" + i + "_ready_bakery") && (globals.bakery_array_slots_otgruzki[i, 0] == "cookie"))
            {
                globals.cookie++;
                globals.bakery_array_slots_otgruzki[i, 0] = "";
            }
            //Молокозавод
            if ((gameObject.name == "slot_" + i + "_ready_dairy") && (GameObject.Find("dairy").GetComponent<dairy>().array_slots_otgruzki[i, 0] == "cream"))
            {
                globals.cream++;//Прибавляем количество крема на склад
                GameObject.Find("dairy").GetComponent<dairy>().array_slots_otgruzki[i, 0] = ""; //Очищаем слот, из которого выгрузили
                Debug.Log("cream = " + globals.cream);

            }
            if ((gameObject.name == "slot_" + i + "_ready_dairy") && (GameObject.Find("dairy").GetComponent<dairy>().array_slots_otgruzki[i, 0] == "corn_bread"))
            {

                globals.butter++;
                GameObject.Find("dairy").GetComponent<dairy>().array_slots_otgruzki[i, 0] = ""; //Очищаем слот, из которого выгрузили
            }
            if ((gameObject.name == "slot_" + i + "_ready_dairy") && (GameObject.Find("dairy").GetComponent<dairy>().array_slots_otgruzki[i, 0] == "cookie"))
            {
                globals.cheese++;
                GameObject.Find("dairy").GetComponent<dairy>().array_slots_otgruzki[i, 0] = ""; //Очищаем слот, из которого выгрузили
            }
        }*/
    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {

    }
    void OnMouseDrag()//Когда перемещение мыши
    {

    }
}
