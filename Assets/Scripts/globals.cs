using System.Collections;
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
    public static int skil_users { get; set; }//Уровень пользователя(всего очков)

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
    public static int cow_feed { get; set; }//Количество коровьего корма в амбаре
    public static int milk_bucket { get; set; }//Количество бидонов коровьего молока в амбаре
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
    public static int max_price_wheat { get; set; }
    //===========================corn==================================================================//
    public static int max_price_corn { get; set; }
    //============================kiosk_silo==================================//
    public static int kiosk_silo_sale_quantity { get; set; }
    public static int kiosk_silo_coin_quantity { get; set; }

}
