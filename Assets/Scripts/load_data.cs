using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class load_data : MonoBehaviour
{
    public GameObject GO_kiosk_silo;
    // Start is called before the first frame update
    void Start()
    {
        //==========================farm_map_box_colliders==========================//
        //globals.farm_map_box_colliders_enabled = false;//Доступность коллайдеров

        globals.collision_move_mod_on = false;
        //==========================cow_0=================================//
        globals.cow_0_begin_stage_1 = DateTime.Now;
        globals.cow_0_end_stage_1 = DateTime.Now;
        globals.cow_0_stage = 0;
        //==========================cow_0=================================//
        globals.cow_1_begin_stage_1 = DateTime.Now;
        globals.cow_1_end_stage_1 = DateTime.Now;
        globals.cow_1_stage = 0;
        //======================quantity==============================//
        globals.wheat = 11;
        globals.wheat_price_for_diamonds = 1;
        globals.corn = 10;
        globals.corn_price_for_diamonds = 1;
        globals.soybean = 11;
        globals.soybean_price_for_diamonds = 2;
        globals.sugarcane = 11;
        globals.sugarcane_price_for_diamonds = 3;
        globals.carrot = 11;
        globals.carrot_price_for_diamonds = 2;
        globals.pumpkin = 11;
        globals.pumpkin_price_for_diamonds = 6;
        globals.silo_intcapacity = 50;//
        globals.barn_intcapacity = 50;
        //=============================barn===============================//
        globals.bolt = 100;
        globals.bolt_price_for_diamonds = 8;
        globals.duct_tape = 100;
        globals.duct_tape_price_for_diamonds = 8;
        globals.plank = 100;
        globals.plank_price_for_diamonds = 8;
        globals.cow_feed = 13;//Количество коровьего корма в амбаре
        globals.cow_feed_price_for_diamonds = 2;
        globals.milk = 12;
        globals.milk_price_for_diamonds = 4;
        globals.bread = 13;
        globals.bread_price_for_diamonds = 1;
        globals.corn_bread = 14;
        globals.corn_bread_price_for_diamonds = 3;
        //===============cookie===============//
        globals.cookie = 15;
        globals.cookie_open_lvl = 10;
        globals.cookie_price_max_for_coin = 104;
        globals.cookie_building_time = 3600;
        globals.cookie_experience_point = 13;
        globals.cookie_price_for_diamonds = 4;
        //===============brown_sugar===========//
        globals.brown_sugar = 15;
        globals.brown_sugar_open_lvl = 7;
        globals.brown_sugar_price_max_for_coin = 32;
        globals.brown_sugar_building_time = 1200;
        globals.brown_sugar_experience_point = 4;
        globals.brown_sugar_price_for_diamonds = 2;
        //===============cream=================//
        globals.cream = 12;
        globals.cream_price_for_diamonds = 2;
        globals.butter = 13;
        globals.butter_price_for_diamonds = 3;
        globals.cheese = 14;
        globals.cheese_price_for_diamonds = 4;
        globals.egg_price_for_diamonds = 2;
        globals.egg = 10;

        globals.nail = 10;
        globals.screew = 11;
        globals.wood_panel = 10;
        //=======================UI===========================================//
        globals.coin = 999999;
        globals.diamond = 8888888;
        //==============================kiosk_barn==================================//
        globals.kiosk_silo_selected_crop = "empty";
        //==============================kiosk_silo===================================//
        globals.kiosk_barn_selected_predmet = "empty";
        //====================================wheat======================================//
        globals.max_price_wheat = 3;
        //====================================corn======================================//
        globals.max_price_corn = 7;

        globals.kiosk_silo_crop_quantity = 10;
        globals.kiosk_silo_coin_quantity = 0;
        globals.kiosk_silo_coin_max = 3;
        globals.kiosk_box_0_object_name = "empty";
        globals.kiosk_box_0_quantity = 0;
        globals.kiosk_box_0_price = 0;
        globals.kiosk_box_selected = 0;
        //=======================bakery==================================//
        globals.bakery_type_obj = "production_building";
        globals.bakery_move_mode_on = false;//Включен ли режим редактирования
        globals.bakery_slots_zagruzki_open = 9;
        globals.bakery_array_slots_zagruzki = new string[9, 3] {
            {"", "", "" },
            {"", "", "" },
            {"", "", "" },
            {"", "", "" },
            {"", "", "" },
            {"", "", "" },
            {"", "", "" },
            {"", "", "" },
            {"", "", "" }};//Предмет, дата загрузки, дата отгрузки
        globals.bakery_array_slots_otgruzki = new string[9, 3] {
            {"", "", "" },
            {"", "", "" },
            {"", "", "" },
            {"", "", "" },
            {"", "", "" },
            {"", "", "" },
            {"", "", "" },
            {"", "", "" },
            {"", "", "" }};//Предмет, дата загрузки, дата отгрузки
        //========================popcorn_pot=======================//
        //globals.popcorn_pot_visible = true;
        //===============================price_for_diamonds_panel===============================//
        //globals.price_for_diamonds_panel_visible = false;
        globals.price_for_diamonds_panel_slot_0_predmet_name = "empty";
        globals.price_for_diamonds_panel_slot_0_predmet_info = "predmet_info, Слот0, Пусто";
        globals.price_for_diamonds_panel_slot_0_predmet_building_time = "predmet_building_time, Слот0, Пусто";
        globals.price_for_diamonds_panel_slot_0_quantity = 0;
        globals.price_for_diamonds_panel_button_ok_diamonds_quantity = 0;
        //=============================GameObjectEnabled===========================//
        //=======================Find==============================//
        GameObject_Enable_Controller.price_for_diamonds_panel = GameObject.Find("price_for_diamonds_panel");
        GameObject_Enable_Controller.bakery = GameObject.Find("bakery");
        GameObject_Enable_Controller.bakery_slots_panel = GameObject.Find("bakery_slots_panel");
        GameObject_Enable_Controller.bakery_slots_predmets = GameObject.Find("bakery_slots_predmets");
        GameObject_Enable_Controller.bakery_slots_zagruzki = GameObject.Find("bakery_slots_zagruzki");
        GameObject_Enable_Controller.bakery_arrow = GameObject.Find("bakery_arrow");
        GameObject_Enable_Controller.bakery_arrow_0 = GameObject.Find("bakery_arrow_0");
        GameObject_Enable_Controller.bakery_arrow_1 = GameObject.Find("bakery_arrow_1");
        GameObject_Enable_Controller.bakery_arrow_2 = GameObject.Find("bakery_arrow_2");
        GameObject_Enable_Controller.bakery_arrow_3 = GameObject.Find("bakery_arrow_3");
        GameObject_Enable_Controller.bakery_arrow_4 = GameObject.Find("bakery_arrow_4");
        GameObject_Enable_Controller.farm_box_colliders = GameObject.Find("farm_map_box_colliders");

        GameObject_Enable_Controller.order_board_panel = GameObject.Find("order_board_panel");
        //=======================price_for_diamonds_paanel=================================================================//
        GameObject_Enable_Controller.price_for_diamonds_panel_button_ok_diamonds_quantity = GameObject.Find("price_for_diamonds_panel_button_ok_diamonds_quantity");
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_0 = GameObject.Find("price_for_diamonds_panel_slot_0");
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_0_info = GameObject.Find("price_for_diamonds_panel_slot_0_info");
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_1 = GameObject.Find("price_for_diamonds_panel_slot_1");
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_1_info = GameObject.Find("price_for_diamonds_panel_slot_1_info");
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_2 = GameObject.Find("price_for_diamonds_panel_slot_2");
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_2_info = GameObject.Find("price_for_diamonds_panel_slot_2_info");
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_3 = GameObject.Find("price_for_diamonds_panel_slot_3");
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_3_info = GameObject.Find("price_for_diamonds_panel_slot_3_info");
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_0_quantity_text = GameObject.Find("price_for_diamonds_panel_slot_0_quantity_text");
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_0_quantity_text = GameObject.Find("price_for_diamonds_panel_slot_0_quantity_text");
        //========================Diactivation(Состояние при старте приложения)===========================================//
        GameObject_Enable_Controller.bakery_slots_predmets.SetActive(false);
        GameObject_Enable_Controller.bakery_slots_zagruzki.SetActive(false);
        GameObject_Enable_Controller.bakery_slots_panel.SetActive(false);
        GameObject_Enable_Controller.bakery_arrow.SetActive(false);
        GameObject_Enable_Controller.price_for_diamonds_panel.SetActive(false);
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_0.SetActive(false);
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_0_info.SetActive(false);
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_1.SetActive(false);
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_1_info.SetActive(false);
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_2.SetActive(false);
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_2_info.SetActive(false);
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_3.SetActive(false);
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_3_info.SetActive(false);
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
    }
}
