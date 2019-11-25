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
    //=============================wheat=====================================================================//
    public static int wheat_open_lvl { get; set; }//Уровень, с которого открывается 
    public static int wheat_price_max_for_coin { get; set; }//Максимальная цена 
    public static int wheat_building_time { get; set; }//Время производства в секундах
    public static int wheat_experience_point { get; set; }//Очков опыта за 1шт
    public static int wheat_price_for_diamonds { get; set; }//Цена 1шт в алмазах    
    public static int wheat { get; set; }//Количество в амбаре
    //=============================corn=====================================================================//
    public static int corn_open_lvl { get; set; }//Уровень, с которого открывается 
    public static int corn_price_max_for_coin { get; set; }//Максимальная цена 
    public static int corn_building_time { get; set; }//Время производства в секундах
    public static int corn_experience_point { get; set; }//Очков опыта за 1шт
    public static int corn_price_for_diamonds { get; set; }//Цена 1шт в алмазах    
    public static int corn { get; set; }//Количество в амбаре
    //=============================soybean=====================================================================//
    public static int soybean_open_lvl { get; set; }//Уровень, с которого открывается 
    public static int soybean_price_max_for_coin { get; set; }//Максимальная цена 
    public static int soybean_building_time { get; set; }//Время производства в секундах
    public static int soybean_experience_point { get; set; }//Очков опыта за 1шт
    public static int soybean_price_for_diamonds { get; set; }//Цена 1шт в алмазах    
    public static int soybean { get; set; }//Количество в амбаре
    //=============================sugarcane=====================================================================//
    public static int sugarcane_open_lvl { get; set; }//Уровень, с которого открывается Тростнико
    public static int sugarcane_price_max_for_coin { get; set; }//Максимальная цена Тростникоа
    public static int sugarcane_building_time { get; set; }//Время производства Тростникоа в секундах (51 минута)
    public static int sugarcane_experience_point { get; set; }//Очков опыта за один Тростнико 
    public static int sugarcane_price_for_diamonds { get; set; }//Цена одного Тростникоа в алмазах    
    public static int sugarcane { get; set; }//Количество Тростникоа в амбаре
    //=============================carrot=====================================================================//
    public static int carrot_open_lvl { get; set; }//Уровень, с которого открывается 
    public static int carrot_price_max_for_coin { get; set; }//Максимальная цена 
    public static int carrot_building_time { get; set; }//Время производства в секундах
    public static int carrot_experience_point { get; set; }//Очков опыта за 1шт
    public static int carrot_price_for_diamonds { get; set; }//Цена 1шт в алмазах    
    public static int carrot { get; set; }//Количество в амбаре
    //=============================pumpkin=====================================================================//
    public static int pumpkin_open_lvl { get; set; }//Уровень, с которого открывается 
    public static int pumpkin_price_max_for_coin { get; set; }//Максимальная цена 
    public static int pumpkin_building_time { get; set; }//Время производства в секундах
    public static int pumpkin_experience_point { get; set; }//Очков опыта за 1шт
    public static int pumpkin_price_for_diamonds { get; set; }//Цена 1шт в алмазах    
    public static int pumpkin { get; set; }//Количество в амбаре
    //=============================indigo=====================================================================//
    public static int indigo_open_lvl { get; set; }//Уровень, с которого открывается 
    public static int indigo_price_max_for_coin { get; set; }//Максимальная цена 
    public static int indigo_building_time { get; set; }//Время производства в секундах
    public static int indigo_experience_point { get; set; }//Очков опыта за 1шт
    public static int indigo_price_for_diamonds { get; set; }//Цена 1шт в алмазах    
    public static int indigo { get; set; }//Количество в амбаре
    //=============================apple=====================================================================//
    public static int apple_open_lvl { get; set; }//Уровень, с которого открывается 
    public static int apple_price_max_for_coin { get; set; }//Максимальная цена 
    public static int apple_building_time { get; set; }//Время производства в секундах
    public static int apple_experience_point { get; set; }//Очков опыта за 1шт
    public static int apple_price_for_diamonds { get; set; }//Цена 1шт в алмазах    
    public static int apple { get; set; }//Количество в амбаре

    //=============================bacon_and_aggs=====================================================================//
    public static int bacon_and_aggs_open_lvl { get; set; }//Уровень, с которого открывается 
    public static int bacon_and_aggs_price_max_for_coin { get; set; }//Максимальная цена 
    public static int bacon_and_aggs_building_time { get; set; }//Время производства в секундах
    public static int bacon_and_aggs_experience_point { get; set; }//Очков опыта за 1шт
    public static int bacon_and_aggs_price_for_diamonds { get; set; }//Цена 1шт в алмазах    
    public static int bacon_and_aggs { get; set; }//Количество в амбаре
    //=============================white_sugar=====================================================================//
    public static int white_sugar_open_lvl { get; set; }//Уровень, с которого открывается 
    public static int white_sugar_price_max_for_coin { get; set; }//Максимальная цена 
    public static int white_sugar_building_time { get; set; }//Время производства в секундах
    public static int white_sugar_experience_point { get; set; }//Очков опыта за 1шт
    public static int white_sugar_price_for_diamonds { get; set; }//Цена 1шт в алмазах    
    public static int white_sugar { get; set; }//Количество в амбаре//Количество в амбаре
    //=============================carrot_pie=====================================================================//
    public static int carrot_pie_open_lvl { get; set; }//Уровень, с которого открывается 
    public static int carrot_pie_price_max_for_coin { get; set; }//Максимальная цена 
    public static int carrot_pie_building_time { get; set; }//Время производства в секундах
    public static int carrot_pie_experience_point { get; set; }//Очков опыта за 1шт
    public static int carrot_pie_price_for_diamonds { get; set; }//Цена 1шт в алмазах    
    public static int carrot_pie { get; set; }//Количество в амбаре
    //=============================pumpkin_pie=====================================================================//
    public static int pumpkin_pie_open_lvl { get; set; }//Уровень, с которого открывается 
    public static int pumpkin_pie_price_max_for_coin { get; set; }//Максимальная цена 
    public static int pumpkin_pie_building_time { get; set; }//Время производства в секундах
    public static int pumpkin_pie_experience_point { get; set; }//Очков опыта за 1шт
    public static int pumpkin_pie_price_for_diamonds { get; set; }//Цена 1шт в алмазах    
    public static int pumpkin_pie { get; set; }//Количество в амбаре

    //====================================Вместимость=============================================//
    public static int silo_intcapacity { get; set; }//Вместимость силосной башни
    public static int barn_intcapacity { get; set; }//Вместимость амбара
    //=========================Амбар=============================================//
    //Upgrade_barn//
    public static int bolt { get; set; }//Количество болтов в амбаре
    public static int bolt_price_max_for_coin { get; set; }//Максимальная цена за болт
    public static int bolt_price_for_diamonds { get; set; }//Цена одного болта в алмазах

    public static int duct_tape{ get; set; }//Количество скотча в амбаре
    public static int duct_tape_price_max_for_coin { get; set; }//Максимальная цена за скотч
    public static int duct_tape_price_for_diamonds { get; set; }//Цена одного скотча в алмазах

    public static int plank { get; set; }//Количество досок в амбаре
    public static int plank_price_max_for_coin { get; set; }//Максимальная цена за доску
    public static int plank_price_for_diamonds { get; set; }//Цена одной доски за алмазы
    //=======================cow_feed=====================================================//
    public static int cow_feed { get; set; }//Количество коровьего корма в амбаре
    public static int cow_feed_price_for_diamonds { get; set; }//Цена одного коровьего корма в алмазах
    public static int cow_open_lvl { get; set; }//Уровень, с которого открывается коровий корм
    public static int cow_price_max_for_coin { get; set; }//Максимальная цена коровьего корма
    public static int cow_building_time { get; set; }//Время производства коровьего корма в секундах
    public static int cow_experience_point { get; set; }//Очков опыта за единицу коровьего корма
    //=======================chicken_feed=====================================================//
    public static int chicken_feed { get; set; }//Количество куриного корма в амбаре
    public static int chicken_feed_price_for_diamonds { get; set; }//Цена одного куриного корма в алмазах
    public static int chicken_feed_open_lvl { get; set; }//Уровень, с которого открывается куриного корм
    public static int chicken_feed_price_max_for_coin { get; set; }//Максимальная цена куриного корма
    public static int chicken_feed_building_time { get; set; }//Время производства куриного корма в секундах
    public static int chicken_feed_experience_point { get; set; }//Очков опыта за единицу куриного корма
    //=======================pig_feed=====================================================//
    public static int pig_feed { get; set; }//Количество свиного корма в амбаре
    public static int pig_feed_price_for_diamonds { get; set; }//Цена одного свиного корма в алмазах
    public static int pig_feed_open_lvl { get; set; }//Уровень, с которого открывается свиной корм
    public static int pig_feed_price_max_for_coin { get; set; }//Максимальная цена свиного корма
    public static int pig_feed_building_time { get; set; }//Время производства свиного корма в секундах
    public static int pig_feed_experience_point { get; set; }//Очков опыта за единицу свиного корма
    //=============================milk==============================================================//
    public static int milk { get; set; }//Количество молока в амбаре
    public static int milk_price_for_diamonds { get; set; }//Цена одного молока в алмазах
    public static int milk_open_lvl { get; set; }//Уровень, с которого открывается молоко
    public static int milk_price_max_for_coin { get; set; }//Максимальная цена молока
    public static int milk_building_time { get; set; }//Время производства молока в секундах
    public static int milk_experience_point { get; set; }//Очков опыта за единицу молока
    //=============================bread==============================================================//
    public static int bread { get; set; }//Количество хлеба в амбаре
    public static int bread_price_for_diamonds { get; set; }//Цена одного хлеба в алмазах
    public static int bread_open_lvl { get; set; }//Уровень, с которого открывается хлеб
    public static int bread_price_max_for_coin { get; set; }//Максимальная цена хлеба
    public static int bread_building_time { get; set; }//Время производства хлеба в секундах
    public static int bread_experience_point { get; set; }//Очков опыта за единицу хлеба
    //=============================corn_bread==============================================================//
    public static int corn_bread { get; set; }//Количество кукурузного хлеба в амбаре
    public static int corn_bread_price_for_diamonds { get; set; }//Цена одного кукурузного хлеба в алмазах
    public static int corn_bread_open_lvl { get; set; }//Уровень, с которого открывается кукурузный хлеб
    public static int corn_bread_price_max_for_coin { get; set; }//Максимальная цена кукурузного хлеба
    public static int corn_bread_building_time { get; set; }//Время производства кукурузного хлеба в секундах
    public static int corn_bread_experience_point { get; set; }//Очков опыта за единицу кукурузного хлеба
    //=============================cookie=====================================================================//
    public static int cookie_open_lvl { get; set; }//Уровень, с которого открывается печенье
    public static int cookie_price_max_for_coin { get; set; }//Максимальная цена печенья
    public static int cookie_building_time { get; set; }//Время производства печенья в секундах 
    public static int cookie_experience_point { get; set; }//Очков опыта за одно печенье   
    public static int cookie_price_for_diamonds { get; set; }//Цена одного печенья в алмазах    
    public static int cookie { get; set; }//Количество печенья в амбаре
    //=============================brown_sugar=====================================================================//
    public static int brown_sugar { get; set; }//Количество коричневого сахара
    public static int brown_sugar_open_lvl { get; set; }//Уровень, с которого открывается коричневый сахар
    public static int brown_sugar_price_max_for_coin { get; set; }//Максимальная цена одноо коричневого сахара
    public static int brown_sugar_building_time { get; set; }//Время производства коричневого сахара в секундах
    public static int brown_sugar_experience_point { get; set; }//Очков опыта за один коричневый сахар   
    public static int brown_sugar_price_for_diamonds { get; set; }//Цена одного коричневого сахара в алмазах 
    //=============================cream=====================================================================//
    public static int cream_open_lvl { get; set; }//Уровень, с которого открывается крем
    public static int cream_price_max_for_coin { get; set; }//Максимальная цена крема
    public static int cream_building_time { get; set; }//Время производства крема в секундах 
    public static int cream_experience_point { get; set; }//Очков опыта за один крем 
    public static int cream_price_for_diamonds { get; set; }//Цена одного крема в алмазах    
    public static int cream { get; set; }//Количество крема в амбаре
    //=============================butter=====================================================================//
    public static int butter_open_lvl { get; set; }//Уровень, с которого открывается масло
    public static int butter_price_max_for_coin { get; set; }//Максимальная цена масла
    public static int butter_building_time { get; set; }//Время производства масла в секундах 
    public static int butter_experience_point { get; set; }//Очков опыта за один масло 
    public static int butter_price_for_diamonds { get; set; }//Цена одного масла в алмазах    
    public static int butter { get; set; }//Количество масла в амбаре
    //=============================cheese=====================================================================//
    public static int cheese_open_lvl { get; set; }//Уровень, с которого открывается сыр
    public static int cheese_price_max_for_coin { get; set; }//Максимальная цена сыра
    public static int cheese_building_time { get; set; }//Время производства сыра в секундах 
    public static int cheese_experience_point { get; set; }//Очков опыта за один сыр 
    public static int cheese_price_for_diamonds { get; set; }//Цена одного сыра в алмазах    
    public static int cheese { get; set; }//Количество сыра в амбаре
    //=============================egg=====================================================================//
    public static int egg_open_lvl { get; set; }//Уровень, с которого открывается яйцо
    public static int egg_price_max_for_coin { get; set; }//Максимальная цена яйца
    public static int egg_building_time { get; set; }//Время производства яйца в секундах
    public static int egg_experience_point { get; set; }//Очков опыта за один яйцо 
    public static int egg_price_for_diamonds { get; set; }//Цена одного яйца в алмазах    
    public static int egg { get; set; }//Количество яйца в амбаре
    //=============================popcorn=====================================================================//
    public static int popcorn_open_lvl { get; set; }//Уровень, с которого открывается попкорн
    public static int popcorn_price_max_for_coin { get; set; }//Максимальная цена попкорна
    public static int popcorn_building_time { get; set; }//Время производства попкорна в секундах 
    public static int popcorn_experience_point { get; set; }//Очков опыта за один попкорн 
    public static int popcorn_price_for_diamonds { get; set; }//Цена одного попкорно в алмазах    
    public static int popcorn { get; set; }//Количество попкорна в амбаре
    //Upgrade_silo//
    public static int nail { get; set; }//Количество гвоздей в амбаре
    public static int nail_price_max_for_coin { get; set; }//Максимальная цена гвоздя
    public static int nail_price_for_diamonds { get; set; }//Цена одного гвоздя в алмазах

    public static int screew { get; set; }//Количество шурупов в амбаре
    public static int screew_price_max_for_coin { get; set; }//Максимальная цена шурупа
    public static int screew_price_for_diamonds { get; set; }//Цена одного шурупа в алмазах

    public static int wood_panel { get; set; }//Количество панелей в амбаре
    public static int wood_panel_max_for_coin { get; set; }//Максимальная цена деревнной панели
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
    public static string price_for_diamonds_panel_current_item;//Текущий выбранный предмет, у которого нехватает ингредиентов 
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
