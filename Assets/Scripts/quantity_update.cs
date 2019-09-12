using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quantity_update : MonoBehaviour
{
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



    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("quantity_field_panel_wheat_text").GetComponent<Text>().text = globals.quantuty_wheat.ToString();
        GameObject.Find("silo_wheat_quantity_text").GetComponent<Text>().text = globals.quantuty_wheat.ToString();
        GameObject.Find("quantity_field_panel_corn_text").GetComponent<Text>().text = globals.quantuty_corn.ToString();
        GameObject.Find("silo_corn_quantity_text").GetComponent<Text>().text = globals.quantuty_corn.ToString();
        GameObject.Find("quantity_field_panel_soybean_text").GetComponent<Text>().text = globals.quantuty_soybean.ToString();
        GameObject.Find("silo_soybean_quantity_text").GetComponent<Text>().text = globals.quantuty_soybean.ToString();
        GameObject.Find("quantity_field_panel_soybean_text").GetComponent<Text>().text = globals.quantuty_soybean.ToString();
        GameObject.Find("silo_soybean_quantity_text").GetComponent<Text>().text = globals.quantuty_soybean.ToString();
        GameObject.Find("quantity_field_panel_sugarcane_text").GetComponent<Text>().text = globals.quantuty_sugarcane.ToString();
        GameObject.Find("silo_sugarcane_quantity_text").GetComponent<Text>().text = globals.quantuty_sugarcane.ToString();
        GameObject.Find("quantity_field_panel_pumpkin_text").GetComponent<Text>().text = globals.quantuty_pumpkin.ToString();
        GameObject.Find("silo_pumpkin_quantity_text").GetComponent<Text>().text = globals.quantuty_pumpkin.ToString();
        GameObject.Find("quantity_field_panel_carrot_text").GetComponent<Text>().text = globals.quantuty_carrot.ToString();
        GameObject.Find("silo_carrot_quantity_text").GetComponent<Text>().text = globals.quantuty_carrot.ToString();


    }

}
