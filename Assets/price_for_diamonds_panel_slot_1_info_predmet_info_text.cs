﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class price_for_diamonds_panel_slot_1_info_predmet_info_text : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //=============crops======================================================//
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "wheat") { gameObject.GetComponent<Text>().text = "Сбор урожая через 2м."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "corn") { gameObject.GetComponent<Text>().text = "Сбор урожая через 5м."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "soybean") { gameObject.GetComponent<Text>().text = "Сбор урожая через 20м."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "sugarcane") { gameObject.GetComponent<Text>().text = "Сбор урожая через 30м."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "carrot") { gameObject.GetComponent<Text>().text = "Сбор урожая через 10м."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "indigo") { gameObject.GetComponent<Text>().text = "Сбор урожая через 2ч."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "pumpkin") { gameObject.GetComponent<Text>().text = "Сбор урожая через 3ч."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "apple") { gameObject.GetComponent<Text>().text = "Сбор урожая через 16ч."; }
        //============predmets======================================================//
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "empty") { gameObject.GetComponent<Text>().text = "Пусто"; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "egg") { gameObject.GetComponent<Text>().text = "Берется у кур."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "bread") { gameObject.GetComponent<Text>().text = "Производится в пекарне."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "chicken_feed") { gameObject.GetComponent<Text>().text = "Производится на дробилке."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "cow_feed") { gameObject.GetComponent<Text>().text = "Производится на дробилке."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "milk") { gameObject.GetComponent<Text>().text = "Берется у коров."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "cream") { gameObject.GetComponent<Text>().text = "Производятся на молокозаводе."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "corn_bread") { gameObject.GetComponent<Text>().text = "Производится в пекарне."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "brown_sugar") { gameObject.GetComponent<Text>().text = "Производится на сахарном заводе."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "popcorn") { gameObject.GetComponent<Text>().text = "Производится в попкорнице."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "butter") { gameObject.GetComponent<Text>().text = "Производятся на молокозаводе."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "pancake") { gameObject.GetComponent<Text>().text = "Производится на гриле."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "pig_feed") { gameObject.GetComponent<Text>().text = "Производится на дробилке."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "bacon") { gameObject.GetComponent<Text>().text = "Берется у свиней."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "cookie") { gameObject.GetComponent<Text>().text = "Производится в пекарне."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "bacon_and_aggs") { gameObject.GetComponent<Text>().text = "Производится на гриле."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "cheese") { gameObject.GetComponent<Text>().text = "Производятся на молокозаводе."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "white_sugar") { gameObject.GetComponent<Text>().text = "Производится на сахарном заводе."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "carrot_pie") { gameObject.GetComponent<Text>().text = "Производится в печи для пирогов."; }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "pumpkin_pie") { gameObject.GetComponent<Text>().text = "Производится в печи для пирогов."; }
    }
}