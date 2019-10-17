using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quantity_update : MonoBehaviour
{
    //====================barn=============================//
    public GameObject barn_panel_bolt_quantity_text;
    public GameObject barn_panel_duct_tape_quantity_text;
    public GameObject barn_panel_plank_quantity_text;


    public GameObject barn_panel_cow_feed_quantity_text;
    public GameObject barn_panel_milk_quantity_text;
    public GameObject barn_panel_bread_quantity_text;
    public GameObject barn_panel_corn_bread_quantity_text;
    public GameObject barn_panel_cookie_quantity_text;
    public GameObject barn_panel_cream_quantity_text;
    public GameObject barn_panel_butter_quantity_text;
    public GameObject barn_panel_cheese_quantity_text;

    public GameObject barn_panel_nail_quantity_text;
    public GameObject barn_panel_screew_quantity_text;
    public GameObject barn_panel_wood_panel_quantity_text;
    public GameObject barn_panel_egg_quantity_text;
    public GameObject barn_text_info;
    //====================silo=============================//
    public GameObject quantity_field_panel_wheat_text;
    public GameObject silo_wheat_quantity_text;
    public GameObject quantity_field_panel_corn_text;
    public GameObject silo_corn_quantity_text;
    public GameObject quantity_field_panel_soybean_text;
    public GameObject silo_soybean_quantity_text;
    public GameObject quantity_field_panel_sugarcane_text;
    public GameObject silo_sugarcane_quantity_text;
    public GameObject quantity_field_panel_carrot_text;
    public GameObject silo_carrot_quantity_text;
    public GameObject quantity_field_panel_pumpkin_text;
    public GameObject silo_pumpkin_quantity_text;
    public GameObject silo_text_info;
    

    // Start is called before the first frame update
    void Start()
    {
        //Загружаем первоначальные значения

       
        //===================barn=========================================//
        barn_panel_bolt_quantity_text = GameObject.Find("barn_panel_bolt_quantity_text");
        barn_panel_duct_tape_quantity_text = GameObject.Find("barn_panel_duct_tape_quantity_text");
        barn_panel_plank_quantity_text = GameObject.Find("barn_panel_plank_quantity_text");

        barn_panel_cow_feed_quantity_text = GameObject.Find("barn_panel_cow_feed_quantity_text");
        barn_panel_milk_quantity_text = GameObject.Find("barn_panel_milk_quantity_text");
        barn_panel_bread_quantity_text = GameObject.Find("barn_panel_bread_quantity_text");
        barn_panel_corn_bread_quantity_text = GameObject.Find("barn_panel_corn_bread_quantity_text");
        barn_panel_cookie_quantity_text = GameObject.Find("barn_panel_cookie_quantity_text");
        barn_panel_cream_quantity_text = GameObject.Find("barn_panel_cream_quantity_text");
        barn_panel_butter_quantity_text = GameObject.Find("barn_panel_butter_quantity_text");
        barn_panel_cheese_quantity_text = GameObject.Find("barn_panel_cheese_quantity_text");
        barn_panel_egg_quantity_text = GameObject.Find("barn_panel_egg_quantity_text");

        barn_panel_nail_quantity_text = GameObject.Find("barn_panel_nail_quantity_text");
        barn_panel_screew_quantity_text = GameObject.Find("barn_panel_screew_quantity_text");
        barn_panel_wood_panel_quantity_text = GameObject.Find("barn_panel_wood_panel_quantity_text");

        barn_text_info = GameObject.Find("barn_text_info");
        //===================silo========================================//
        //wheat
        quantity_field_panel_wheat_text = GameObject.Find("quantity_field_panel_wheat_text");
        silo_wheat_quantity_text = GameObject.Find("silo_wheat_quantity_text");
        //corn
        quantity_field_panel_corn_text = GameObject.Find("quantity_field_panel_corn_text");
        silo_corn_quantity_text = GameObject.Find("silo_corn_quantity_text");
        //soybean
        quantity_field_panel_soybean_text = GameObject.Find("quantity_field_panel_soybean_text");
        silo_soybean_quantity_text = GameObject.Find("silo_soybean_quantity_text");
        //sugarcane
        quantity_field_panel_sugarcane_text = GameObject.Find("quantity_field_panel_sugarcane_text");
        silo_sugarcane_quantity_text = GameObject.Find("silo_sugarcane_quantity_text");
        //carrot
        quantity_field_panel_carrot_text = GameObject.Find("quantity_field_panel_carrot_text");
        silo_carrot_quantity_text = GameObject.Find("silo_carrot_quantity_text");
        //pumpkin
        quantity_field_panel_pumpkin_text = GameObject.Find("quantity_field_panel_pumpkin_text");
        silo_pumpkin_quantity_text = GameObject.Find("silo_pumpkin_quantity_text");
        //silo
        silo_text_info = GameObject.Find("silo_text_info");
        //barn
        //GameObject barn_text_info = GameObject.Find("barn_text_info");
    }
    void Update()
    {
        //==================================barn========================================//
        barn_panel_bolt_quantity_text.GetComponent<Text>().text = globals.bolt.ToString();//Количество болтов в амбаре
        barn_panel_duct_tape_quantity_text.GetComponent<Text>().text = globals.duct_tape.ToString();//Количество клейкой ленты в амбаре
        barn_panel_plank_quantity_text.GetComponent<Text>().text = globals.plank.ToString();//Количество досок в амбаре

        barn_panel_cow_feed_quantity_text.GetComponent<Text>().text = globals.cow_feed.ToString();//Количество коровьего корма в амбаре
        barn_panel_milk_quantity_text.GetComponent<Text>().text = globals.milk.ToString();//Количество молока в амбаре
        barn_panel_bread_quantity_text.GetComponent<Text>().text = globals.bread.ToString();//Количество хлеба в амбаре
        barn_panel_corn_bread_quantity_text.GetComponent<Text>().text = globals.corn_bread.ToString();//Количество кукурузного хлеба в амбаре
        barn_panel_cookie_quantity_text.GetComponent<Text>().text = globals.cookie.ToString();//Количество печенья
        barn_panel_cream_quantity_text.GetComponent<Text>().text = globals.cream.ToString();//Количество сливок
        barn_panel_butter_quantity_text.GetComponent<Text>().text = globals.butter.ToString();//Количество масла
        barn_panel_cheese_quantity_text.GetComponent<Text>().text = globals.cheese.ToString();//Количество сыра
        barn_panel_egg_quantity_text.GetComponent<Text>().text = globals.egg.ToString();//Количество яиц

        barn_panel_nail_quantity_text.GetComponent<Text>().text = globals.nail.ToString();//Количество гвоздей
        barn_panel_screew_quantity_text.GetComponent<Text>().text = globals.screew.ToString();//Количество шурупов
        barn_panel_wood_panel_quantity_text.GetComponent<Text>().text = globals.wood_panel.ToString();//Количество деревянных панелей


        //===============================silo=====================================//   
        //wheat
    quantity_field_panel_wheat_text.GetComponent<Text>().text = globals.quantuty_wheat.ToString();//Количество пшеницы в графе объекта поле
    silo_wheat_quantity_text.GetComponent<Text>().text = globals.quantuty_wheat.ToString();//Отображаемое количество в графе силосной башни
                                                                                           //corn
    quantity_field_panel_corn_text.GetComponent<Text>().text = globals.quantuty_corn.ToString();
    silo_corn_quantity_text.GetComponent<Text>().text = globals.quantuty_corn.ToString();
    //soybean
    quantity_field_panel_soybean_text.GetComponent<Text>().text = globals.quantuty_soybean.ToString();
    silo_soybean_quantity_text.GetComponent<Text>().text = globals.quantuty_soybean.ToString();
    //sugarcane
    quantity_field_panel_sugarcane_text.GetComponent<Text>().text = globals.quantuty_sugarcane.ToString();
    silo_sugarcane_quantity_text.GetComponent<Text>().text = globals.quantuty_sugarcane.ToString();
    //carrot
    quantity_field_panel_carrot_text.GetComponent<Text>().text = globals.quantuty_carrot.ToString();
    silo_carrot_quantity_text.GetComponent<Text>().text = globals.quantuty_carrot.ToString();
    //pumpkin
    quantity_field_panel_pumpkin_text.GetComponent<Text>().text = globals.quantuty_pumpkin.ToString();
    silo_pumpkin_quantity_text.GetComponent<Text>().text = globals.quantuty_pumpkin.ToString();



    var busy_silo = globals.quantuty_wheat +
               globals.quantuty_corn +
               globals.quantuty_soybean +
               globals.quantuty_sugarcane +
               globals.quantuty_carrot +
               globals.quantuty_pumpkin;
    silo_text_info.GetComponent<Text>().text = "Силосная башня: " + busy_silo.ToString() + "/" + globals.silo_intcapacity.ToString();

        var busy_barn =
           globals.bolt +
           globals.duct_tape +
           globals.plank +
           globals.cow_feed +
           globals.milk +
           globals.bread +
           globals.corn_bread +
           globals.cookie +
           globals.cream +
           globals.butter +
           globals.cheese +
           globals.nail +
           globals.screew +
           globals.wood_panel;
        barn_text_info.GetComponent<Text>().text = "Амбар: " + busy_barn.ToString() + "/" + globals.barn_intcapacity.ToString();
        //GameObject.Find("barn_text_info").GetComponent<Text>().text = "Амбар: "+globals.barn_intcapacity.ToString();

    }

}
