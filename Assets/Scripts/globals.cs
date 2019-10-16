﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class globals : MonoBehaviour
{
    public static int coin { get; set; }//Количество монет игрока
    public static int diamond { get; set; }//Количество алмазов
    //public static string [] checksilo { get; set; }
    public static bool zoom { get; set; }
    public static bool drag { get; set; }
    //===============================OBJ:поле_0============================================//
    public static string login_users { get; set; }//Логин пользователя
    public static string password_users { get; set; }//Пароль пользователя
    public static int id_user { get; set; }//Уникальный идентификатор пользователя

    public static int skil_user { get; set; }//Очков у пользователя
    public static int level_user { get; set; }//Уровень пользователя

    public static string predmetname { get; set; }//Выбранный предмет для посадки
    //====================================Количество культур=============================================//
    public static int quantuty_wheat { get; set; }//Количетво пшеницы в силосной башни
    public static int quantuty_corn { get; set; }//Количетво кукурузы в силосной башни
    public static int quantuty_soybean { get; set; }//Количетво сои в силосной башни
    public static int quantuty_sugarcane { get; set; }//Количетво тростника в силосной башни
    public static int quantuty_carrot { get; set; }//Количетво моркови в силосной башни
    public static int quantuty_pumpkin { get; set; }//Количетво тыквы в силосной башни
    //====================================Вместимость=============================================//
    public static int silo_intcapacity { get; set; }//Вместимость силосной башни
    public static int barn_intcapacity { get; set; }//Вместимость амбара
    //=========================Амбар=============================================//
    //Upgrade//
    public static int bolt { get; set; }//Количество болтов в амбаре
    public static int duct_tape{ get; set; }//Количество скотча в амбаре
    public static int plank { get; set; }//Количество досок в амбаре

    public static int cow_feed { get; set; }//Количество коровьего корма в амбаре
    public static int milk { get; set; }//Количество коровьего молока в амбаре
    public static int bread { get; set; }//Количество хлеба в амбаре
    public static int corn_bread { get; set; }//Количество кукурузного хлеба в амбаре
    public static int cookie { get; set; }//Количество печенья в амбаре
    public static int cream { get; set; }//Количество крема в амбаре
    public static int butter { get; set; }//Количество масла в амбаре
    public static int cheese { get; set; }//Количество сыра в амбаре

    public static int nail { get; set; }//Количество гвоздей в амбаре
    public static int screew { get; set; }//Количество шурупов в амбаре
    public static int wood_panel { get; set; }//Количество панелей в амбаре
    //============================cow_0=======================================//
    public static int cow_0_stage { get; set; }//Состояние коровы 0-Голодная, 1-Сытая, 2 - Ожидает дойки
    public static DateTime cow_0_begin_stage_1 { get; set; }//Время начала первой стадии коровы
    public static DateTime cow_0_end_stage_1 { get; set; }//Время конца первой стадии коровы
    //==========================kiosk_barn====================================================================//
    public static string kiosk_barn_selected_predmet { get; set; }//Выбраный предмет в киоске силосной башни
    //==========================kiosk_silo====================================================================//
    public static string kiosk_silo_selected_crop { get; set; }//Выбраный предмет в киоске силосной башни
    //===========================wheat==================================================================//
    public static int max_price_wheat { get; set; }//Максимальная стоимость пшеницы
    //===========================corn==================================================================//
    public static int max_price_corn { get; set; }//Максимальная стоимость кукурузы
    //============================kiosk_silo==================================//

    public static int kiosk_silo_crop_quantity { get; set; }//Количество выбранной пшеницы в киоске с культурами
    public static int kiosk_silo_coin_quantity { get; set; }//Количество выбранной стоимости в киоске с культурами
    public static int kiosk_silo_coin_max { get; set; }//Количество максимальной стоимости в киоске с культурами с выбранными параметрами
    public static string kiosk_box_0_object_name { get; set; }//Объект загруженный в слот киоска
    public static int kiosk_box_0_quantity { get; set; }//Количество, загруженное в слот киоска
    public static int kiosk_box_0_price { get; set; }//Количество, загруженное в слот киоска
    public static int kiosk_box_selected { get; set; }//Выбранный слот киоска
    //============================order_board==================================//
    public static int order_board_slot_selected { get; set; }//Выбранный слот доски объявлений
    public static int order_board_slot_0_coin_quantity { get; set; } //Монет за доставку предметов в стоте 0
    public static int order_board_slot_0_experience_point_quantity { get; set; } //Очков опыта за доставку предметов в слоте 0
    public static string order_board_slot_0_vaucher_color{ get; set; } //Цвет ваучера за доставку предметов в слоте 0
    public static bool order_board_slot_0_help { get; set; } //Установлена ли помощь в слоте 0

    public static string order_board_slot_0_predmet_0_name { get; set; } //1ый необходимый предмет в слоте 0
    public static int order_board_slot_0_predmet_0_quantity { get; set; } //Количество необходимого предмета в слоте 0

    public static string order_board_slot_0_predmet_1_name { get; set; } //2ой необходимый предмет в слоте 0
    public static int order_board_slot_0_predmet_1_quantity { get; set; } //Количество необходимого предмета в слоте 0

    public static string order_board_slot_0_predmet_2_name { get; set; } //3ий необходимый предмет в слоте 0
    public static int order_board_slot_0_predmet_2_quantity { get; set; } //Количество необходимого предмета в слоте 0

    public static string order_board_slot_0_predmet_3_name { get; set; } //4ый необходимый предмет в слоте 0
    public static int order_board_slot_0_predmet_3_quantity { get; set; } //Количество необходимого предмета в слоте 0

    public static string order_board_slot_0_predmet_4_name { get; set; } //5ый необходимый предмет в слоте 0
    public static int order_board_slot_0_predmet_4_quantity { get; set; } //Количество необходимого предмета в слоте 0

    public static string order_board_slot_0_predmet_5_name { get; set; } //6ой необходимый предмет в слоте 0
    public static int order_board_slot_0_predmet_5_quantity { get; set; } //Количество необходимого предмета в слоте 0


}
