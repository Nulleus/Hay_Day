using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class silo_wood_panel_quantity_text : MonoBehaviour
{
    public GameObject GO_silo_wood_panel_quantity_text;
    // Start is called before the first frame update
    void Start()
    {
        globals.wood_panel = 100;
        GO_silo_wood_panel_quantity_text = GameObject.Find("silo_wood_panel_quantity_text");
    }

    // Update is called once per frame
    void Update()
    {
        GO_silo_wood_panel_quantity_text.GetComponent<Text>().text = globals.wood_panel.ToString() + "/" + (globals.silo_intcapacity / 25 - 1).ToString();//В амбаре/Необходимо для обновления
    }
}
