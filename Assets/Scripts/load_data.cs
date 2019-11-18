﻿using System.Collections;
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
        globals.farm_map_box_colliders_enabled = false;//Доступность коллайдеров

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
        globals.corn = 11;
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
        globals.duct_tape = 100;
        globals.plank = 100;
        globals.cow_feed = 13;//Количество коровьего корма в амбаре
        globals.milk = 12;
        globals.bread = 13;
        globals.corn_bread = 14;
        globals.cookie = 15;
        globals.cream = 12;
        globals.butter = 13;
        globals.cheese = 14;
        globals.egg = 15;
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
        globals.bakery_visible = true;
        globals.bakery_slots_zagruzki_open = 9;
        globals.bakery_slots_predmets_visible = false;
        globals.bakery_slots_zagruzki_visible = false;
        globals.bakery_slots_panel_visible = false;
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
        globals.popcorn_pot_visible = true;
        //===============================price_for_diamonds_panel===============================//
        globals.price_for_diamonds_panel_visible = false;
        globals.price_for_diamonds_panel_slot_0_predmet_name = "empty";
        globals.price_for_diamonds_panel_slot_0_predmet_info = "predmet_info, Слот0, Пусто";
        globals.price_for_diamonds_panel_slot_0_predmet_building_time = "predmet_building_time, Слот0, Пусто";
        globals.price_for_diamonds_panel_slot_0_quantity = 0;
        globals.price_for_diamonds_panel_button_ok_diamonds_quantity = 0;
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
    }
}
