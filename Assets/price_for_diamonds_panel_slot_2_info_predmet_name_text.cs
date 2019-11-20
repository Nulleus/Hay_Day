using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class price_for_diamonds_panel_slot_2_info_predmet_name_text : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //=============crops======================================================//
        if (globals.price_for_diamonds_panel_slot_2_predmet_name == "wheat") { gameObject.GetComponent<Text>().text = "Пшеница"; }
        if (globals.price_for_diamonds_panel_slot_2_predmet_name == "corn") { gameObject.GetComponent<Text>().text = "Кукуруза"; }
        if (globals.price_for_diamonds_panel_slot_2_predmet_name == "soybean") { gameObject.GetComponent<Text>().text = "Соя"; }
        if (globals.price_for_diamonds_panel_slot_2_predmet_name == "sugarcane") { gameObject.GetComponent<Text>().text = "Тростник"; }
        if (globals.price_for_diamonds_panel_slot_2_predmet_name == "carrot") { gameObject.GetComponent<Text>().text = "Морковь"; }
        if (globals.price_for_diamonds_panel_slot_2_predmet_name == "pumpkin") { gameObject.GetComponent<Text>().text = "Тыква"; }
        //============predmets======================================================//
        if (globals.price_for_diamonds_panel_slot_2_predmet_name == "empty") { gameObject.GetComponent<Text>().text = "Пусто"; }
        if (globals.price_for_diamonds_panel_slot_2_predmet_name == "egg") { gameObject.GetComponent<Text>().text = "Яйцо"; }
        if (globals.price_for_diamonds_panel_slot_2_predmet_name == "bread") { gameObject.GetComponent<Text>().text = "Хлеб"; }
        if (globals.price_for_diamonds_panel_slot_2_predmet_name == "chicken_feed") { gameObject.GetComponent<Text>().text = "Куриный корм"; }
        if (globals.price_for_diamonds_panel_slot_2_predmet_name == "cow_feed") { gameObject.GetComponent<Text>().text = "Коровий корм"; }
        if (globals.price_for_diamonds_panel_slot_2_predmet_name == "milk") { gameObject.GetComponent<Text>().text = "Молоко"; }
        if (globals.price_for_diamonds_panel_slot_2_predmet_name == "cream") { gameObject.GetComponent<Text>().text = "Сливки"; }
        if (globals.price_for_diamonds_panel_slot_2_predmet_name == "popcorn") { gameObject.GetComponent<Text>().text = "Попкорн"; }
        if (globals.price_for_diamonds_panel_slot_2_predmet_name == "butter") { gameObject.GetComponent<Text>().text = "Масло"; }
    }
}
