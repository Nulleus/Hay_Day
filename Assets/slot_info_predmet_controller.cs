using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slot_info_predmet_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (globals.slot_info_main_predmet_name == "bread")
        {
            GameObject_Enable_Controller.slot_info_predmet_quantity_0.GetComponent<Text>().text = (globals.wheat + "/3").ToString(); //Сколько есть, скольно необходимо
            GameObject_Enable_Controller.slot_info_predmet_quantity_1.GetComponent<Text>().text = ""; //Сколько есть, скольно необходимо
            GameObject_Enable_Controller.slot_info_predmet_quantity_2.GetComponent<Text>().text = ""; //Сколько есть, скольно необходимо
            GameObject_Enable_Controller.slot_info_predmet_quantity_3.GetComponent<Text>().text = ""; //Сколько есть, скольно необходимо
        }
        if (globals.slot_info_main_predmet_name == "corn_bread")
        {
            gameObject.GetComponent<Text>().text = (globals.corn + "/2"); //Сколько есть, скольно необходимо
        }
        if (globals.slot_info_main_predmet_name == "cookie")
        {
            gameObject.GetComponent<Text>().text = (globals.wheat + "/2"); //Сколько есть, скольно необходимо
        }
    }
}
