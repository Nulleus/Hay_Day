using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiosk_silo_button_PutUp : MonoBehaviour
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
        switch (globals.kiosk_box_selected)
        {
            case 0:
                globals.kiosk_box_0_object_name = globals.kiosk_silo_selected_crop;//Присваиваем 0 слоту киоска выбранную культуру
                globals.kiosk_box_0_quantity = globals.kiosk_silo_crop_quantity;//Присваиваем слоту 0 количество продаваемого товара
                globals.kiosk_box_0_price = globals.kiosk_silo_coin_quantity;//Присваиваем слоту 0, цену выбранную
                break;
        }
    }
}
