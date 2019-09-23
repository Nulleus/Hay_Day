using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kiosk_silo_text_info : MonoBehaviour
{
    public GameObject GO_kiosk_silo_text_info;
    // Start is called before the first frame update
    void Start()
    {
        GO_kiosk_silo_text_info = GameObject.Find("kiosk_silo_text_info");
    }

    // Update is called once per frame
    void Update()
    {
        var busy = globals.quantuty_wheat +
           globals.quantuty_corn +
           globals.quantuty_soybean +
           globals.quantuty_sugarcane +
           globals.quantuty_carrot +
           globals.quantuty_pumpkin;
        GO_kiosk_silo_text_info.GetComponent<Text>().text = "Силосная башня: " + busy.ToString() + "/" + globals.silo_intcapacity.ToString();
    }
}
