using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using Proyecto26;
using UnityEditor;


public class Contents : MonoBehaviour
{
	//Получаем продукт, находящийся в зоне отгрузки для каждого слота по номеру, идентификатору пользователя
	public string GetSubjectChildInTheShipment(string subjectParentName, int numberSlot,int userID, DateTime dateTimeNow)
    {
        string dateTimeNowForQuery = Convert.ToString(dateTimeNow, System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat); //Дата загрузки
        //Convert.ToString(nowtime.AddSeconds(building_time), System.Globalization.CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat); //Дата отгрузки
        return "";
    }
}
