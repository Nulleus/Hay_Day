using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class price_for_diamonds_panel_button_ok : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()//Когда отпускаеть мышь
    {
        if (globals.diamond - globals.price_for_diamonds_panel_button_ok_diamonds_quantity > 0)
        {
            globals.diamond = globals.diamond - globals.price_for_diamonds_panel_button_ok_diamonds_quantity;
            //Добавляем недостающие предметы и запускаем ещё раз
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "wheat")
            {
                globals.wheat = globals.wheat + globals.price_for_diamonds_panel_slot_0_quantity;
            }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "corn")
            {
                globals.corn = globals.corn + globals.price_for_diamonds_panel_slot_0_quantity;
            }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "soybean")
            {
                globals.soybean = globals.soybean + globals.price_for_diamonds_panel_slot_0_quantity;
            }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "sugarcane")
            {
                globals.sugarcane = globals.sugarcane + globals.price_for_diamonds_panel_slot_0_quantity;
            }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "carrot")
            {
                globals.carrot = globals.carrot + globals.price_for_diamonds_panel_slot_0_quantity;
            }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "pumpkin")
            {
                globals.pumpkin = globals.pumpkin + globals.price_for_diamonds_panel_slot_0_quantity;
            }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "egg") { globals.egg = globals.egg + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "bread") { globals.bread = globals.bread + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "chicken_feed") { globals.chicken_feed = globals.chicken_feed + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "cow_feed") { globals.cow_feed = globals.cow_feed + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "milk") { globals.milk = globals.milk + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "cream") { globals.cream = globals.cream + globals.price_for_diamonds_panel_slot_0_quantity; }
            //if (globals.price_for_diamonds_panel_slot_0_predmet_name == "popcorn") { globals.pop = globals.egg + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "butter") { globals.butter = globals.butter + globals.price_for_diamonds_panel_slot_0_quantity; }


        }
        else
        {
            Debug.Log("Недостаточно Алмазов!");
            return;
        }
        
        
        //Списать алмазы
        //Выполнить
    }

}
