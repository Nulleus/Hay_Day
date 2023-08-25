using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silo_upgrade_button_ok : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        if (
            (globals.nail-(globals.silo_intcapacity / 25)>=0)&&
            (globals.screew - (globals.silo_intcapacity / 25) >= 0) &&
            (globals.wood_panel - (globals.silo_intcapacity / 25) >= 0) 
           )
        {
            globals.nail = globals.nail - (globals.silo_intcapacity / 25);//Исходя из таблицы количество необходимое для обновления(увеличения вместимости)
            globals.screew = globals.screew - (globals.silo_intcapacity / 25);
            globals.wood_panel = globals.wood_panel - (globals.silo_intcapacity / 25);
            globals.silo_intcapacity = globals.silo_intcapacity + 25;//Увеличиваем вместимость силосной башни
        }


        

    }
}
