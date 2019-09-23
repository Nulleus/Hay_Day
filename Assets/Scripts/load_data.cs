using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class load_data : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //==========================cow=================================//
        globals.cow_0_begin_stage_1 = DateTime.Now;
        globals.cow_0_end_stage_1 = DateTime.Now;
        globals.cow_0_stage = 0;
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
        globals.cow_feed = 100;//Количество коровьего корма в амбаре
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

        globals.kiosk_silo_sale_quantity = 10;
        globals.kiosk_silo_coin_quantity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
    }
}
