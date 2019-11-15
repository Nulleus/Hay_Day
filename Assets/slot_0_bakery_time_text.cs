using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class slot_0_bakery_time_text : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(globals.bakery_array_slots_zagruzki[0, 2] != "")
        {
            var nowtime = DateTime.Now;
            TimeSpan time = Convert.ToDateTime(globals.bakery_array_slots_zagruzki[0, 2], System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat) - Convert.ToDateTime(nowtime, System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat);
            gameObject.GetComponent<Text>().text = time.Seconds + " c";//Отображение, сколько секунд
        }
        else
        {
            gameObject.GetComponent<Text>().text = "";//Если  пусто, убраем время
        }

    }
}
