using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barn_upgrade_button_ok : MonoBehaviour
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
            (globals.bolt - (globals.barn_intcapacity / 25) >= 0) &&
            (globals.duct_tape - (globals.barn_intcapacity / 25) >= 0) &&
            (globals.plank - (globals.barn_intcapacity / 25) >= 0)
           )
        {
            globals.bolt = globals.bolt - (globals.barn_intcapacity / 25);//Исходя из таблицы количество необходимое для обновления(увеличения вместимости)
            globals.duct_tape = globals.duct_tape - (globals.barn_intcapacity / 25);
            globals.plank = globals.plank - (globals.barn_intcapacity / 25);
            globals.barn_intcapacity = globals.barn_intcapacity + 25;//Увеличиваем вместимость силосной башни
        }




    }
}
