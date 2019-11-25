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
        globals.wheat_open_lvl = 1;   //Уровень, с которого открывается 
        globals.wheat_price_max_for_coin = 3;  //Максимальная цена 
        globals.wheat_building_time = 10;  //Время производства в секундах(60)
        globals.wheat_experience_point = 1;   //Очков опыта за 1шт
        globals.wheat_price_for_diamonds = 1;   //Цена 1шт в алмазах    
        globals.wheat = 7;   //Количество в амбаре
        //=============================corn=====================================================================//
        globals.corn_open_lvl = 2; //Уровень, с которого открывается 
        globals.corn_price_max_for_coin = 7;  //Максимальная цена 
        globals.corn_building_time = 10;  //Время производства в секундах(300)
        globals.corn_experience_point = 1;   //Очков опыта за 1шт
        globals.corn_price_for_diamonds = 1;  //Цена 1шт в алмазах    
        globals.corn = 8;  //Количество в амбаре
        //=============================soybean=====================================================================//
        globals.soybean_open_lvl = 5;  //Уровень, с которого открывается 
        globals.soybean_price_max_for_coin = 10;  //Максимальная цена 
        globals.soybean_building_time = 10;  //Время производства в секундах(1200)
        globals.soybean_experience_point = 2;  //Очков опыта за 1шт
        globals.soybean_price_for_diamonds = 2;   //Цена 1шт в алмазах    
        globals.soybean = 9;  //Количество в амбаре
        //=============================sugarcane=====================================================================//
        globals.sugarcane_open_lvl = 7; //Уровень, с которого открывается Тростнико
        globals.sugarcane_price_max_for_coin = 14;  //Максимальная цена Тростникоа
        globals.sugarcane_building_time = 10;   //Время производства Тростникоа в секундах (1800)
        globals.sugarcane_experience_point = 3;  //Очков опыта за один Тростнико 
        globals.sugarcane_price_for_diamonds = 3;  //Цена одного Тростникоа в алмазах    
        globals.sugarcane = 10;   //Количество Тростникоа в амбаре
        //=============================carrot=====================================================================//
        globals.carrot_open_lvl = 9;   //Уровень, с которого открывается 
        globals.carrot_price_max_for_coin = 7;  //Максимальная цена 
        globals.carrot_building_time = 10;   //Время производства в секундах(600)
        globals.carrot_experience_point = 2;  //Очков опыта за 1шт
        globals.carrot_price_for_diamonds = 2;   //Цена 1шт в алмазах    
        globals.carrot = 12;   //Количество в амбаре
        //=============================pumpkin=====================================================================//
        globals.pumpkin_open_lvl = 15; //Уровень, с которого открывается 
        globals.pumpkin_price_max_for_coin = 32; //Максимальная цена 
        globals.pumpkin_building_time = 10; //Время производства в секундах(10800)
        globals.pumpkin_experience_point = 6; //Очков опыта за 1шт
        globals.pumpkin_price_for_diamonds = 6; //Цена 1шт в алмазах    
        globals.pumpkin = 11; //Количество в амбаре
        //=============================indigo=====================================================================//
        globals.indigo_open_lvl = 13; //Уровень, с которого открывается 
        globals.indigo_price_max_for_coin = 25; //Максимальная цена 
        globals.indigo_building_time = 10; //Время производства в секундах(7200)
        globals.indigo_experience_point = 5; //Очков опыта за 1шт
        globals.indigo_price_for_diamonds = 5; //Цена 1шт в алмазах    
        globals.indigo = 11; //Количество в амбаре
        //=============================apple=====================================================================//
        globals.apple_open_lvl = 15; //Уровень, с которого открывается 
        globals.apple_price_max_for_coin = 39; //Максимальная цена 
        globals.apple_building_time = 10; //Время производства в секундах(57600)
        globals.apple_experience_point = 7; //Очков опыта за 1шт
        globals.apple_price_for_diamonds = 7; //Цена 1шт в алмазах    
        globals.apple = 11; //Количество в амбаре

        globals.silo_intcapacity = 50;//
        globals.barn_intcapacity = 50;
        //=============================barn===============================//
        //Upgrade_barn//
        globals.bolt = 20;   //Количество болтов в амбаре
        globals.bolt_price_for_diamonds = 8;   //Цена одного болта в алмазах
        globals.duct_tape = 20; //Количество скотча в амбаре
        globals.duct_tape_price_for_diamonds = 8;  //Цена одного скотча в алмазах
        globals.plank = 20;  //Количество досок в амбаре
        globals.plank_price_for_diamonds = 8;  //Цена одной доски за алмазы
        //=======================cow_feed=====================================================//
        globals.cow_feed = 10;  //Количество коровьего корма в амбаре
        globals.cow_feed_price_for_diamonds = 2;  //Цена одного коровьего корма в алмазах
        globals.cow_open_lvl = 6;   //Уровень, с которого открывается коровий корм
        globals.cow_price_max_for_coin = 14;   //Максимальная цена коровьего корма
        globals.cow_building_time = 10;   //Время производства коровьего корма в секундах(600)
        globals.cow_experience_point = 2;  //Очков опыта за единицу коровьего корма
        //=======================chicken_feed=====================================================//
        globals.chicken_feed = 10; //Количество куриного корма в амбаре
        globals.chicken_feed_price_for_diamonds = 1;  //Цена одного куриного корма в алмазах
        globals.chicken_feed_open_lvl = 3;  //Уровень, с которого открывается куриного корм
        globals.chicken_feed_price_max_for_coin = 7;  //Максимальная цена куриного корма
        globals.chicken_feed_building_time = 10;   //Время производства куриного корма в секундах(300)
        globals.chicken_feed_experience_point = 1;  //Очков опыта за единицу куриного корма
        //=======================pig_feed=====================================================//
        globals.pig_feed = 10;  //Количество свиного корма в амбаре
        globals.pig_feed_price_for_diamonds = 2;  //Цена одного свиного корма в алмазах
        globals.pig_feed_open_lvl = 10;   //Уровень, с которого открывается свиной корм
        globals.pig_feed_price_max_for_coin = 14;  //Максимальная цена свиного корма
        globals.pig_feed_building_time = 10;  //Время производства свиного корма в секундах(1200)
        globals.pig_feed_experience_point = 2;  //Очков опыта за единицу свиного корма
        //=============================milk==============================================================//
        globals.milk = 11;   //Количество молока в амбаре
        globals.milk_price_for_diamonds = 4; //Цена одного молока в алмазах
        globals.milk_open_lvl = 6;  //Уровень, с которого открывается молоко
        globals.milk_price_max_for_coin = 32; //Максимальная цена молока
        globals.milk_building_time = 10;  //Время производства молока в секундах(3600)
        globals.milk_experience_point = 3;   //Очков опыта за единицу молока
        //=============================bread==============================================================//
        globals.bread = 5;  //Количество хлеба в амбаре
        globals.bread_price_for_diamonds = 1;   //Цена одного хлеба в алмазах
        globals.bread_open_lvl = 2;  //Уровень, с которого открывается хлеб
        globals.bread_price_max_for_coin = 21;  //Максимальная цена хлеба
        globals.bread_building_time = 11;   //Время производства хлеба в секундах(300)
        globals.bread_experience_point = 3;   //Очков опыта за единицу хлеба
        //=============================corn_bread==============================================================//
        globals.corn_bread = 4;   //Количество кукурузного хлеба в амбаре
        globals.corn_bread_price_for_diamonds = 3;  //Цена одного кукурузного хлеба в алмазах
        globals.corn_bread_open_lvl = 7;  //Уровень, с которого открывается кукурузный хлеб
        globals.corn_bread_price_max_for_coin = 72;   //Максимальная цена кукурузного хлеба
        globals.corn_bread_building_time = 11;   //Время производства кукурузного хлеба в секундах(1800)
        globals.corn_bread_experience_point = 8;  //Очков опыта за единицу кукурузного хлеба
        //=============================cream=====================================================================//
        globals.cream_open_lvl = 6;   //Уровень, с которого открывается крем
        globals.cream_price_max_for_coin = 60;  //Максимальная цена крема
        globals.cream_building_time = 11;  //Время производства крема в секундах(1200) 
        globals.cream_experience_point = 6;  //Очков опыта за один крем 
        globals.cream_price_for_diamonds = 2;  //Цена одного крема в алмазах    
        globals.cream = 3;   //Количество крема в амбаре
        //=============================butter=====================================================================//
        globals.butter_open_lvl = 9;   //Уровень, с которого открывается масло
        globals.butter_price_max_for_coin = 82;  //Максимальная цена масла
        globals.butter_building_time = 11;   //Время производства масла в секундах (1800)
        globals.butter_experience_point = 10;  //Очков опыта за один масло 
        globals.butter_price_for_diamonds = 3;  //Цена одного масла в алмазах    
        globals.butter = 2;  //Количество масла в амбаре
        //=============================cheese=====================================================================//
        globals.cheese_open_lvl = 12;   //Уровень, с которого открывается сыр
        globals.cheese_price_max_for_coin = 122;  //Максимальная цена сыра
        globals.cheese_building_time = 12;   //Время производства сыра в секундах (3600)
        globals.cheese_experience_point = 15;  //Очков опыта за один сыр 
        globals.cheese_price_for_diamonds = 4;  //Цена одного сыра в алмазах    
        globals.cheese = 2;   //Количество сыра в амбаре
        //=============================egg=====================================================================//
        globals.egg_open_lvl = 1;  //Уровень, с которого открывается яйцо
        globals.egg_price_max_for_coin = 18;  //Максимальная цена яйца
        globals.egg_building_time = 11;  //Время производства яйца в секундах(1200)
        globals.egg_experience_point = 2;  //Очков опыта за один яйцо 
        globals.egg_price_for_diamonds = 2;  //Цена одного яйца в алмазах    
        globals.egg = 8;  //Количество яйца в амбаре
        //=============================popcorn=====================================================================//
        globals.popcorn_open_lvl = 8; //Уровень, с которого открывается попкорн
        globals.popcorn_price_max_for_coin = 32;  //Максимальная цена попкорна
        globals.popcorn_building_time = 11;  //Время производства попкорна в секундах (1800)
        globals.popcorn_experience_point = 4;  //Очков опыта за один попкорн 
        globals.popcorn_price_for_diamonds = 3;   //Цена одного попкорно в алмазах    
        globals.popcorn = 4;   //Количество попкорна в амбаре
        //=============================bacon_and_aggs=====================================================================//
        globals.bacon_and_aggs_open_lvl = 11; //Уровень, с которого открывается
        globals.bacon_and_aggs_price_max_for_coin = 201;  //Максимальная цена               
        globals.bacon_and_aggs_building_time = 11;  //Время производства в секундах (3600)
        globals.bacon_and_aggs_experience_point = 24;  //Очков опыта за 1шт 
        globals.bacon_and_aggs_price_for_diamonds = 4;   //Цена 1шт в алмазах    
        globals.bacon_and_aggs = 4;   //Количество в амбаре
        //=============================white_sugar=====================================================================//
        globals.white_sugar_open_lvl = 13; //Уровень, с которого открывается
        globals.white_sugar_price_max_for_coin = 50;  //Максимальная цена               
        globals.white_sugar_building_time = 11;  //Время производства в секундах (2400)
        globals.white_sugar_experience_point = 6;  //Очков опыта за 1шт 
        globals.white_sugar_price_for_diamonds = 3;   //Цена 1шт в алмазах    
        globals.white_sugar = 4;
        //=============================carrot_pie=====================================================================//
        globals.carrot_pie_open_lvl = 14; //Уровень, с которого открывается
        globals.carrot_pie_price_max_for_coin = 82;  //Максимальная цена               
        globals.carrot_pie_building_time = 11;  //Время производства в секундах (3600)
        globals.carrot_pie_experience_point = 10;  //Очков опыта за 1шт 
        globals.carrot_pie_price_for_diamonds = 4;   //Цена 1шт в алмазах    
        globals.carrot_pie = 4;
        //=============================pumpkin_pie=====================================================================//
        globals.pumpkin_pie_open_lvl = 15; //Уровень, с которого открывается
        globals.pumpkin_pie_price_max_for_coin = 158;  //Максимальная цена               
        globals.pumpkin_pie_building_time = 11;  //Время производства в секундах (7200)
        globals.pumpkin_pie_experience_point = 19;  //Очков опыта за 1шт 
        globals.pumpkin_pie_price_for_diamonds = 5;   //Цена 1шт в алмазах    
        globals.pumpkin_pie = 4;


        //Upgrade_silo//
        //nail//
        globals.nail = 14;   //Количество гвоздей в амбаре
        globals.nail_price_max_for_coin = 270;
        globals.nail_price_for_diamonds = 8;  //Цена одного гвоздя в алмазах
        //screew//
        globals.screew = 14;   //Количество шурупов в амбаре
        globals.screew_price_max_for_coin = 270;
        globals.screew_price_for_diamonds = 8;  //Цена одного шурупа в алмазах
        //wood_panel//
        globals.wood_panel = 14;  //Количество панелей в амбаре
        globals.wood_panel_price_for_diamonds = 270;
        globals.wood_panel_price_for_diamonds = 8;  //Цена одной деревянной панели

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

        //=======================UI===========================================//
        globals.coin = 999999;
        globals.diamond = 8888888;
        //==============================kiosk_barn==================================//
        globals.kiosk_silo_selected_crop = "empty";
        //==============================kiosk_silo===================================//
        globals.kiosk_barn_selected_predmet = "empty";


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
        //=======================price_for_diamonds_panel=================================================================//
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
