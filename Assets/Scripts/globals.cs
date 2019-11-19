using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class globals : MonoBehaviour
{
    //==========================farm_map_box_colliders==========================//
    //public static bool farm_map_box_colliders_enabled { get; set; }//Доступность коллайдеров
    public static bool collision_move_mod_on { get; set; }//Столкновение с  другим объектом в режиме редактирования
    //==========================popcorn_pot================================//
    //public static bool popcorn_pot_visible { get; set; }//Состояние видимости попкорницы
    //==========================bakery================================//
    public static string bakery_type_obj { get; set; }//
    public static bool bakery_move_mode_on { get; set; }//Режим редактирования
    public static Vector3 bakery_primary_position { get; set; }//Расположение пекарни до перемещения
    //public static Vector3 bakery_new_position { get; set; }//Новое расположение пекарни
    //public static bool bakery_collider_current_color { get; set; }//На каком колайдере стоит пекарня красный/зеленый
    public static int bakery_open_lvl { get; set; } //Уровень открытия пекарни - 2
    public static int bakery_buy_coin { get; set; } //Стоимость покупки пекарни - 20
    public static int bakery_building { get; set; } //Время постройки пекарни - 10с
    public static bool bakery_buy { get; set; } //Куплена ли пекарня
    public static string[,] bakery_array_slots_zagruzki { get; set; }
    public static string[,] bakery_array_slots_otgruzki { get; set; }
    public static int bakery_slots_zagruzki_open { get; set; }//Количество открытых слотов загрузки
    //public static bool order_board_panel_visible { get; set; }//Видимость панели объекта доска объявления

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
    public static int wheat { get; set; }//Количетво пшеницы в силосной башни
    public static int wheat_price_for_diamonds { get; set; }//Цена пшеницы за алмазы 1шт
    public static int corn { get; set; }//Количетво кукурузы в силосной башни
    public static int corn_price_for_diamonds { get; set; }//Цена кукурузы за алмазы 1шт
    public static int soybean { get; set; }//Количетво сои в силосной башни
    public static int soybean_price_for_diamonds { get; set; }//Цена сои за алмазы 1шт
    public static int sugarcane { get; set; }//Количетво тростника в силосной башни
    public static int sugarcane_price_for_diamonds { get; set; }//Цена тростника за алмазы 1шт
    public static int carrot { get; set; }//Количетво моркови в силосной башни
    public static int carrot_price_for_diamonds { get; set; }//Цена моркови за алмазы 1шт
    public static int pumpkin { get; set; }//Количетво тыквы в силосной башни
    public static int pumpkin_price_for_diamonds { get; set; }//Цена тыквы за алмазы 1шт
    //====================================Вместимость=============================================//
    public static int silo_intcapacity { get; set; }//Вместимость силосной башни
    public static int barn_intcapacity { get; set; }//Вместимость амбара
    //=========================Амбар=============================================//
    //Upgrade//
    public static int bolt { get; set; }//Количество болтов в амбаре
    public static int bolt_price_for_diamonds { get; set; }//Цена одного болта в алмазах
    public static int duct_tape{ get; set; }//Количество скотча в амбаре
    public static int duct_tape_price_for_diamonds { get; set; }//Цена одного скотча в алмазах
    public static int plank { get; set; }//Количество досок в амбаре
    public static int plank_price_for_diamonds { get; set; }//Цена одной доски за алмазы
    public static int cow_feed { get; set; }//Количество коровьего корма в амбаре
    public static int cow_feed_price_for_diamonds { get; set; }//Цена одного коровьего корма 
    public static int milk { get; set; }//Количество коровьего молока в амбаре
    public static int milk_price_for_diamonds { get; set; }//Цена одного коровьего молока в алмазах
    public static int bread { get; set; }//Количество хлеба в амбаре
    public static int bread_price_for_diamonds { get; set; }//Цена одного хлеба в алмазах
    public static int corn_bread { get; set; }//Количество кукурузного хлеба в амбаре
    public static int corn_bread_price_for_diamonds { get; set; }//Цена одного кукурузного хлеба в алмазах
    public static int cookie { get; set; }//Количество печенья в амбаре
    public static int cookie_price_for_diamonds { get; set; }//Цена одного печенья в алмазах
    public static int cream { get; set; }//Количество крема в амбаре
    public static int cream_price_for_diamonds { get; set; }//Цена одних сливок в алмазах
    public static int butter { get; set; }//Количество масла в амбаре
    public static int butter_price_for_diamonds { get; set; }//Цена одного масла в алмазах
    public static int cheese { get; set; }//Количество сыра в амбаре
    public static int cheese_price_for_diamonds { get; set; }//Цена одного сыра в алмазах
    public static int egg { get; set; }//Количество яиц в амбаре
    public static int egg_price_for_diamonds { get; set; }//Цена одного яйца в алмазах
    public static int nail { get; set; }//Количество гвоздей в амбаре
    public static int nail_price_for_diamonds { get; set; }//Цена одного гвоздя в алмазах
    public static int screew { get; set; }//Количество шурупов в амбаре
    public static int screew_price_for_diamonds { get; set; }//Цена одного шурупа в алмазах
    public static int wood_panel { get; set; }//Количество панелей в амбаре
    public static int wood_panel_price_for_diamonds { get; set; }//Цена одной деревянной панели
    //============================cow_0=======================================//
    public static int cow_0_stage { get; set; }//Состояние коровы 0-Голодная, 1-Сытая, 2 - Ожидает дойки
    public static DateTime cow_0_begin_stage_1 { get; set; }//Время начала первой стадии коровы
    public static DateTime cow_0_end_stage_1 { get; set; }//Время конца первой стадии коровы
    //============================cow_1=======================================//
    public static int cow_1_stage { get; set; }//Состояние коровы 0-Голодная, 1-Сытая, 2 - Ожидает дойки
    public static DateTime cow_1_begin_stage_1 { get; set; }//Время начала первой стадии коровы
    public static DateTime cow_1_end_stage_1 { get; set; }//Время конца первой стадии коровы
    //============================cow_2=======================================//
    public static int cow_2_stage { get; set; }//Состояние коровы 0-Голодная, 1-Сытая, 2 - Ожидает дойки
    public static DateTime cow_2_begin_stage_1 { get; set; }//Время начала первой стадии коровы
    public static DateTime cow_2_end_stage_1 { get; set; }//Время конца первой стадии коровы
    //============================cow_3=======================================//
    public static int cow_3_stage { get; set; }//Состояние коровы 0-Голодная, 1-Сытая, 2 - Ожидает дойки
    public static DateTime cow_3_begin_stage_1 { get; set; }//Время начала первой стадии коровы
    public static DateTime cow_3_end_stage_1 { get; set; }//Время конца первой стадии коровы
    //============================cow_4=======================================//
    public static int cow_4_stage { get; set; }//Состояние коровы 0-Голодная, 1-Сытая, 2 - Ожидает дойки
    public static DateTime cow_4_begin_stage_1 { get; set; }//Время начала первой стадии коровы
    public static DateTime cow_4_end_stage_1 { get; set; }//Время конца первой стадии коровы
    //============================cow_5=======================================//
    public static int cow_5_stage { get; set; }//Состояние коровы 0-Голодная, 1-Сытая, 2 - Ожидает дойки
    public static DateTime cow_5_begin_stage_1 { get; set; }//Время начала первой стадии коровы
    public static DateTime cow_5_end_stage_1 { get; set; }//Время конца первой стадии коровы
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
    //===================price_for_diamonds_panel=====================================================================//
    //public static bool price_for_diamonds_panel_visible { get; set; }//Видимость price_for_diamonds_panel(Не работает, так как после скрытия объекта, скрип перестает выполняться) Для исправления, необходимо написать контроллер, который бы постоянно за этим следил и выполнялся
    public static string price_for_diamonds_panel_slot_0_predmet_name{ get; set; }//Наименование предмета, которого нехватает
    public static string price_for_diamonds_panel_slot_0_predmet_info { get; set; }//Информация о предмете, которого нехватает
    public static string price_for_diamonds_panel_slot_0_predmet_building_time{ get; set; }//Время сборки предмета, которого нехватает
    public static int price_for_diamonds_panel_slot_0_quantity { get; set; }//Количество предмета, которого нехватает

    public static string price_for_diamonds_panel_slot_1_predmet_name { get; set; }//Наименование предмета, которого нехватает
    public static string price_for_diamonds_panel_slot_1_predmet_info { get; set; }//Информация о предмете, которого нехватает
    public static string price_for_diamonds_panel_slot_1_predmet_building_time { get; set; }//Время сборки предмета, которого нехватает
    public static int price_for_diamonds_panel_slot_1_quantity { get; set; }//Количество предмета, которого нехватает

    public static string price_for_diamonds_panel_slot_2_predmet_name { get; set; }//Наименование предмета, которого нехватает
    public static string price_for_diamonds_panel_slot_2_predmet_info { get; set; }//Информация о предмете, которого нехватает
    public static string price_for_diamonds_panel_slot_2_predmet_building_time { get; set; }//Время сборки предмета, которого нехватает
    public static int price_for_diamonds_panel_slot_2_quantity { get; set; }//Количество предмета, которого нехватает

    public static string price_for_diamonds_panel_slot_3_predmet_name { get; set; }//Наименование предмета, которого нехватает
    public static string price_for_diamonds_panel_slot_3_predmet_info { get; set; }//Информация о предмете, которого нехватает
    public static string price_for_diamonds_panel_slot_3_predmet_building_time { get; set; }//Время сборки предмета, которого нехватает
    public static int price_for_diamonds_panel_slot_3_quantity { get; set; }//Количество предмета, которого нехватает

    public static int price_for_diamonds_panel_button_ok_diamonds_quantity { get; set; }//Количество алмазов, необходимое для продолжения


}
