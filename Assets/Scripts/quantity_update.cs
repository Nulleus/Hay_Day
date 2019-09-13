using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quantity_update : MonoBehaviour
{

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
        globals.quantuty_wheat = 11;
        globals.quantuty_corn = 11;
        globals.quantuty_soybean = 11;
        globals.quantuty_sugarcane = 11;
        globals.quantuty_carrot = 11;
        globals.quantuty_pumpkin = 11;
        globals.silo_intcapacity = 101;
        globals.barn_intcapacity = 102;
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

    var busy = globals.quantuty_wheat +
               globals.quantuty_corn +
               globals.quantuty_soybean +
               globals.quantuty_sugarcane +
               globals.quantuty_carrot +
               globals.quantuty_pumpkin;
    silo_text_info.GetComponent<Text>().text = "Силосная башня: " + busy.ToString() + "/" + globals.silo_intcapacity.ToString();
    //GameObject.Find("barn_text_info").GetComponent<Text>().text = "Амбар: "+globals.barn_intcapacity.ToString();

}

}
