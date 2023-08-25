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
            //=======================================================slot_0==========================================//
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "wheat"){globals.wheat = globals.wheat + globals.price_for_diamonds_panel_slot_0_quantity;}
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "corn"){globals.corn = globals.corn + globals.price_for_diamonds_panel_slot_0_quantity;}
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "soybean"){globals.soybean = globals.soybean + globals.price_for_diamonds_panel_slot_0_quantity;}
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "sugarcane"){globals.sugarcane = globals.sugarcane + globals.price_for_diamonds_panel_slot_0_quantity;}
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "carrot"){globals.carrot = globals.carrot + globals.price_for_diamonds_panel_slot_0_quantity;}
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "indigo") { globals.indigo = globals.indigo + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "pumpkin"){globals.pumpkin = globals.pumpkin + globals.price_for_diamonds_panel_slot_0_quantity;}
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "apple") { globals.apple = globals.apple + globals.price_for_diamonds_panel_slot_0_quantity; }

            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "egg") { globals.egg = globals.egg + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "bread") { globals.bread = globals.bread + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "chicken_feed") { globals.chicken_feed = globals.chicken_feed + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "cow_feed") { globals.cow_feed = globals.cow_feed + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "milk") { globals.milk = globals.milk + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "cream") { globals.cream = globals.cream + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "corn_bread") { globals.corn_bread = globals.corn_bread + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "brown_sugar") { globals.brown_sugar = globals.brown_sugar + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "popcorn") { globals.popcorn = globals.popcorn + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "butter") { globals.butter = globals.butter + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "pancake") { globals.pancake = globals.pancake + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "pig_feed") { globals.pig_feed = globals.pig_feed + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "bacon") { globals.bacon = globals.bacon + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "cookie") { globals.cookie = globals.cookie + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "bacon_and_aggs") { globals.bacon_and_aggs = globals.bacon_and_aggs + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "cheese") { globals.cheese = globals.cheese + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "white_sugar") { globals.white_sugar = globals.white_sugar + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "carrot_pie") { globals.carrot_pie = globals.carrot_pie + globals.price_for_diamonds_panel_slot_0_quantity; }
            if (globals.price_for_diamonds_panel_slot_0_predmet_name == "pumpkin_pie") { globals.pumpkin_pie = globals.pumpkin_pie + globals.price_for_diamonds_panel_slot_0_quantity; }

            //=======================================================slot_1==========================================//
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "wheat") { globals.wheat = globals.wheat + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "corn") { globals.corn = globals.corn + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "soybean") { globals.soybean = globals.soybean + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "sugarcane") { globals.sugarcane = globals.sugarcane + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "carrot") { globals.carrot = globals.carrot + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "indigo") { globals.indigo = globals.indigo + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "pumpkin") { globals.pumpkin = globals.pumpkin + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "apple") { globals.apple = globals.apple + globals.price_for_diamonds_panel_slot_1_quantity; }

            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "egg") { globals.egg = globals.egg + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "bread") { globals.bread = globals.bread + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "chicken_feed") { globals.chicken_feed = globals.chicken_feed + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "cow_feed") { globals.cow_feed = globals.cow_feed + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "milk") { globals.milk = globals.milk + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "cream") { globals.cream = globals.cream + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "corn_bread") { globals.corn_bread = globals.corn_bread + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "brown_sugar") { globals.brown_sugar = globals.brown_sugar + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "popcorn") { globals.popcorn = globals.popcorn + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "butter") { globals.butter = globals.butter + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "pancake") { globals.pancake = globals.pancake + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "pig_feed") { globals.pig_feed = globals.pig_feed + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "bacon") { globals.bacon = globals.bacon + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "cookie") { globals.cookie = globals.cookie + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "bacon_and_aggs") { globals.bacon_and_aggs = globals.bacon_and_aggs + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "cheese") { globals.cheese = globals.cheese + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "white_sugar") { globals.white_sugar = globals.white_sugar + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "carrot_pie") { globals.carrot_pie = globals.carrot_pie + globals.price_for_diamonds_panel_slot_1_quantity; }
            if (globals.price_for_diamonds_panel_slot_1_predmet_name == "pumpkin_pie") { globals.pumpkin_pie = globals.pumpkin_pie + globals.price_for_diamonds_panel_slot_1_quantity; }
            //=======================================================slot_2==========================================//
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "wheat") { globals.wheat = globals.wheat + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "corn") { globals.corn = globals.corn + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "soybean") { globals.soybean = globals.soybean + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "sugarcane") { globals.sugarcane = globals.sugarcane + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "carrot") { globals.carrot = globals.carrot + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "indigo") { globals.indigo = globals.indigo + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "pumpkin") { globals.pumpkin = globals.pumpkin + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "apple") { globals.apple = globals.apple + globals.price_for_diamonds_panel_slot_2_quantity; }

            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "egg") { globals.egg = globals.egg + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "bread") { globals.bread = globals.bread + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "chicken_feed") { globals.chicken_feed = globals.chicken_feed + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "cow_feed") { globals.cow_feed = globals.cow_feed + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "milk") { globals.milk = globals.milk + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "cream") { globals.cream = globals.cream + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "corn_bread") { globals.corn_bread = globals.corn_bread + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "brown_sugar") { globals.brown_sugar = globals.brown_sugar + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "popcorn") { globals.popcorn = globals.popcorn + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "butter") { globals.butter = globals.butter + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "pancake") { globals.pancake = globals.pancake + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "pig_feed") { globals.pig_feed = globals.pig_feed + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "bacon") { globals.bacon = globals.bacon + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "cookie") { globals.cookie = globals.cookie + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "bacon_and_aggs") { globals.bacon_and_aggs = globals.bacon_and_aggs + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "cheese") { globals.cheese = globals.cheese + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "white_sugar") { globals.white_sugar = globals.white_sugar + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "carrot_pie") { globals.carrot_pie = globals.carrot_pie + globals.price_for_diamonds_panel_slot_2_quantity; }
            if (globals.price_for_diamonds_panel_slot_2_predmet_name == "pumpkin_pie") { globals.pumpkin_pie = globals.pumpkin_pie + globals.price_for_diamonds_panel_slot_2_quantity; }
            //=======================================================slot_3==========================================//
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "wheat") { globals.wheat = globals.wheat + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "corn") { globals.corn = globals.corn + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "soybean") { globals.soybean = globals.soybean + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "sugarcane") { globals.sugarcane = globals.sugarcane + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "carrot") { globals.carrot = globals.carrot + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "indigo") { globals.indigo = globals.indigo + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "pumpkin") { globals.pumpkin = globals.pumpkin + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "apple") { globals.apple = globals.apple + globals.price_for_diamonds_panel_slot_3_quantity; }

            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "egg") { globals.egg = globals.egg + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "bread") { globals.bread = globals.bread + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "chicken_feed") { globals.chicken_feed = globals.chicken_feed + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "cow_feed") { globals.cow_feed = globals.cow_feed + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "milk") { globals.milk = globals.milk + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "cream") { globals.cream = globals.cream + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "corn_bread") { globals.corn_bread = globals.corn_bread + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "brown_sugar") { globals.brown_sugar = globals.brown_sugar + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "popcorn") { globals.popcorn = globals.popcorn + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "butter") { globals.butter = globals.butter + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "pancake") { globals.pancake = globals.pancake + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "pig_feed") { globals.pig_feed = globals.pig_feed + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "bacon") { globals.bacon = globals.bacon + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "cookie") { globals.cookie = globals.cookie + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "bacon_and_aggs") { globals.bacon_and_aggs = globals.bacon_and_aggs + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "cheese") { globals.cheese = globals.cheese + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "white_sugar") { globals.white_sugar = globals.white_sugar + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "carrot_pie") { globals.carrot_pie = globals.carrot_pie + globals.price_for_diamonds_panel_slot_3_quantity; }
            if (globals.price_for_diamonds_panel_slot_3_predmet_name == "pumpkin_pie") { globals.pumpkin_pie = globals.pumpkin_pie + globals.price_for_diamonds_panel_slot_3_quantity; }
        }
        else
        {
            Debug.Log("Недостаточно Алмазов!");
            return;
        }
        //bakery.add_in_slot_predmet(globals.price_for_diamonds_panel_current_item);
        GameObject_Enable_Controller.price_for_diamonds_panel.SetActive(false);
        
        //Списать алмазы
        //Выполнить
    }

}
