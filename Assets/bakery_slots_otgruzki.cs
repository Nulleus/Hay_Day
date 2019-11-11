using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakery_slots_otgruzki : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void offset_massive()//Смещение массива на одну позицию  
    {
        //Добавить цикл, для прохода по открытым объектам
        globals.bakery_array_slots_otgruzki[0, 0] = globals.bakery_array_slots_otgruzki[1, 0];
        globals.bakery_array_slots_otgruzki[0, 1] = globals.bakery_array_slots_otgruzki[1, 1];
        globals.bakery_array_slots_otgruzki[0, 2] = globals.bakery_array_slots_otgruzki[1, 2];

        globals.bakery_array_slots_otgruzki[1, 0] = globals.bakery_array_slots_otgruzki[2, 0];
        globals.bakery_array_slots_otgruzki[1, 1] = globals.bakery_array_slots_otgruzki[2, 1];
        globals.bakery_array_slots_otgruzki[1, 2] = globals.bakery_array_slots_otgruzki[2, 2];

        globals.bakery_array_slots_otgruzki[2, 0] = globals.bakery_array_slots_otgruzki[3, 0];
        globals.bakery_array_slots_otgruzki[2, 1] = globals.bakery_array_slots_otgruzki[3, 1];
        globals.bakery_array_slots_otgruzki[2, 2] = globals.bakery_array_slots_otgruzki[3, 2];

        globals.bakery_array_slots_otgruzki[3, 0] = globals.bakery_array_slots_otgruzki[4, 0];
        globals.bakery_array_slots_otgruzki[3, 1] = globals.bakery_array_slots_otgruzki[4, 1];
        globals.bakery_array_slots_otgruzki[3, 2] = globals.bakery_array_slots_otgruzki[4, 2];

        globals.bakery_array_slots_otgruzki[4, 0] = globals.bakery_array_slots_otgruzki[5, 0];
        globals.bakery_array_slots_otgruzki[4, 1] = globals.bakery_array_slots_otgruzki[5, 1];
        globals.bakery_array_slots_otgruzki[4, 2] = globals.bakery_array_slots_otgruzki[5, 2];

        globals.bakery_array_slots_otgruzki[5, 0] = globals.bakery_array_slots_otgruzki[6, 0];
        globals.bakery_array_slots_otgruzki[5, 1] = globals.bakery_array_slots_otgruzki[6, 1];
        globals.bakery_array_slots_otgruzki[5, 2] = globals.bakery_array_slots_otgruzki[6, 2];

        globals.bakery_array_slots_otgruzki[6, 0] = globals.bakery_array_slots_otgruzki[7, 0];
        globals.bakery_array_slots_otgruzki[6, 1] = globals.bakery_array_slots_otgruzki[7, 1];
        globals.bakery_array_slots_otgruzki[6, 2] = globals.bakery_array_slots_otgruzki[7, 2];

        globals.bakery_array_slots_otgruzki[7, 0] = globals.bakery_array_slots_otgruzki[8, 0];
        globals.bakery_array_slots_otgruzki[7, 1] = globals.bakery_array_slots_otgruzki[8, 1];
        globals.bakery_array_slots_otgruzki[7, 2] = globals.bakery_array_slots_otgruzki[8, 2];


    }

    void OnMouseUp()//Когда отпускаешь кнопку
    {
        if (globals.bakery_array_slots_otgruzki[0, 0] == "bread")
        {
            Debug.Log("bread mouseup");
            globals.bread++;//Прибавляем количество хлеба на склад
            globals.bakery_array_slots_otgruzki[0, 0] = ""; //Очищаем слот, из которого выгрузили
            Debug.Log("bread = " + globals.bread);
            offset_massive();
            return;
        }
        if (globals.bakery_array_slots_otgruzki[0, 0] == "corn_bread")
        {
            Debug.Log("corn_bread mouseup");
            globals.corn_bread++;//Прибавляем количество хлеба на склад
            globals.bakery_array_slots_otgruzki[0, 0] = ""; //Очищаем слот, из которого выгрузили
            Debug.Log("corn_bread = " + globals.corn_bread);
            offset_massive();
            return;
        }
        if (globals.bakery_array_slots_otgruzki[0, 0] == "cookie")
        {
            Debug.Log("cookie mouseup");
            globals.cookie++;//Прибавляем количество хлеба на склад
            globals.bakery_array_slots_otgruzki[0, 0] = ""; //Очищаем слот, из которого выгрузили
            Debug.Log("cookie = " + globals.cookie);
            offset_massive();
            return;
        }

    }
}
