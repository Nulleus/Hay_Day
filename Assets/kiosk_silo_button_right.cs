using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiosk_silo_button_right : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        globals.kiosk_silo_coin_quantity = globals.kiosk_silo_coin_max * globals.kiosk_silo_crop_quantity;
    }
}
