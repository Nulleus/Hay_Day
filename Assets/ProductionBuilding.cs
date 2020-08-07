using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class ProductionBuilding : MonoBehaviour
{
    //==============Свойства здания=======================//
    [SerializeField]
    string NameSystem;//Системное имя объекта
    [SerializeField]
    string NameView;//Отображаемое имя объекта
    int OpenLevel;// Уровень, на котором открывается объект
    int PriceCoins;//Цена здания в монетах
    int BuildingTimeSec;//Время постройки здания в секундах
    int PriceDiamondsForMaxTimes;//Стоимость ускорения постройки здания в алмазах
    int OpenSlotsDefault;//Открытых слотов по умолчанию
    int OpenSlots; //Открытых слотов


    //=======Дочерние и другие объекты================//
    GameObject Collider;
    GameObject Arrow;


    void Start()
    {
      
        SlotsPanel = gameObject.transform.Find("SlotsPanel").gameObject;//Find Child gameobject
        Collider = gameObject.transform.Find("Collider").gameObject;

    }

    // Update is called once per frame
    void Update()
    {

    }


}
