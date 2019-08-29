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
    //====================================поле_1=============================================//

    void Start()
    {
   
    }
    // Update is called once per frame
    void Update()
    {
        
    }
 

}
