using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class price_for_diamonds_panel_slot_0_quantity_text : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = globals.price_for_diamonds_panel_slot_0_quantity.ToString();
    }
}
