using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakery_slots_ready : MonoBehaviour
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
            Debug.Log("OnMouseUp");
        Debug.Log("globals.bakery_array_slots_otgruzki[0, 0]=" + globals.bakery_array_slots_otgruzki[0, 0]);
        Debug.Log("globals.bakery_array_slots_zagruzki[0, 0]="+globals.bakery_array_slots_zagruzki[0, 0]);
            if (globals.bakery_array_slots_otgruzki[0, 0] == "bread")
            {
                globals.bread++;//Прибавляем количество хлеба на склад
                globals.bakery_array_slots_otgruzki[0, 0] = ""; //Очищаем слот, из которого выгрузили
                Debug.Log("bread = " + globals.bread);
                offset_massive();
            }

    }
}
