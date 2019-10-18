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

        //==========================cow_0=================================//
        globals.cow_0_begin_stage_1 = DateTime.Now;
        globals.cow_0_end_stage_1 = DateTime.Now;
        globals.cow_0_stage = 0;
        //==========================cow_0=================================//
        globals.cow_1_begin_stage_1 = DateTime.Now;
        globals.cow_1_end_stage_1 = DateTime.Now;
        globals.cow_1_stage = 0;
        //======================quantity==============================//
        globals.quantuty_wheat = 11;
        globals.quantuty_corn = 11;
        globals.quantuty_soybean = 11;
        globals.quantuty_sugarcane = 11;
        globals.quantuty_carrot = 11;
        globals.quantuty_pumpkin = 11;
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
    }
}
