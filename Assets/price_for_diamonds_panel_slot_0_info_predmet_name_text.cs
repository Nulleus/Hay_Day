using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class price_for_diamonds_panel_slot_0_info_predmet_name_text : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //=============crops======================================================//
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "wheat"){gameObject.GetComponent<Text>().text = "Пшеница";}
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "corn"){gameObject.GetComponent<Text>().text = "Кукуруза";}
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "soybean"){gameObject.GetComponent<Text>().text = "Соя";}
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "sugarcane"){gameObject.GetComponent<Text>().text = "Тростник";}
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "carrot"){gameObject.GetComponent<Text>().text = "Морковь";}
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "indigo") { gameObject.GetComponent<Text>().text = "Индиго"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "pumpkin"){gameObject.GetComponent<Text>().text = "Тыква";}
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "apple") { gameObject.GetComponent<Text>().text = "Яблоко"; }

        //============predmets======================================================//
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "empty") { gameObject.GetComponent<Text>().text = "Пусто"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "egg") { gameObject.GetComponent<Text>().text = "Яйцо"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "bread") { gameObject.GetComponent<Text>().text = "Хлеб"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "chicken_feed") { gameObject.GetComponent<Text>().text = "Куриный корм"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "cow_feed") { gameObject.GetComponent<Text>().text = "Коровий корм"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "milk") { gameObject.GetComponent<Text>().text = "Молоко"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "cream") { gameObject.GetComponent<Text>().text = "Сливки"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "corn_bread") { gameObject.GetComponent<Text>().text = "Кукурузный хлеб"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "brown_sugar") { gameObject.GetComponent<Text>().text = "Коричневый сахар"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "popcorn") { gameObject.GetComponent<Text>().text = "Попкорн"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "butter") { gameObject.GetComponent<Text>().text = "Масло"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "pancake") { gameObject.GetComponent<Text>().text = "Блин"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "pig_feed") { gameObject.GetComponent<Text>().text = "Свиной корм"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "bacon") { gameObject.GetComponent<Text>().text = "Бекон"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "cookie") { gameObject.GetComponent<Text>().text = "Печенье"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "bacon_and_aggs") { gameObject.GetComponent<Text>().text = "Яичница с беконом"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "cheese") { gameObject.GetComponent<Text>().text = "Сыр"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "white_sugar") { gameObject.GetComponent<Text>().text = "Белый сахар"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "carrot_pie") { gameObject.GetComponent<Text>().text = "Морковный пирог"; }
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "pumpkin_pie") { gameObject.GetComponent<Text>().text = "Тыквенный пирог"; }
    }
}
