using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class globals : MonoBehaviour
{
    
    //public static string [] checksilo { get; set; }
    public static bool zoom { get; set; }
    public static bool drag { get; set; }
    //===============================OBJ:поле_0============================================//
    public static string login_users { get; set; }
    public static string password_users { get; set; }
    public static int id_user { get; set; }//Уникальный идентификатор пользователя
    public static int skil_users { get; set; }//Уровень пользователя(всего очков)

    public static string predmetname { get; set; }//Выбранный предмет для посадки
    public static int amount_wheat { get; set; }
    //====================================Количество культур=============================================//
    public static int quantuty_wheat { get; set; }//Количетво пшеницы в силосной башни
    public static int quantuty_corn { get; set; }
    public static int quantuty_soybean { get; set; }
    public static int quantuty_sugarcane { get; set; }
    public static int quantuty_carrot { get; set; }
    public static int quantuty_pumpkin { get; set; }
    //====================================Вместимость=============================================//
    public static int silo_intcapacity { get; set; }//Вместимость силосной башни
    public static int barn_intcapacity { get; set; }//Вместимость амбара
    //=========================Амбар=============================================//
    public static int bread { get; set; }//Количество хлеба в амбаре
    public static int corn_bread { get; set; }//Количество кукурузного хлеба в амбаре
    public static int cookie { get; set; }//Количество пеенья в амбаре
    public static int cream { get; set; }//Количество крема в амбаре
    public static int butter { get; set; }//Количество масла в амбаре
    public static int cheese { get; set; }//Количество сыра в амбаре
}
