using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiosk_silo_sugarcane : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.CrossFade("sugarcane", 1);
    }

    private void OnMouseUp()//Когда отпускает клавишу мыши
    {
        globals.kiosk_silo_selected_crop = "sugarcane";
        globals.kiosk_silo_coin_max = 14;
        globals.kiosk_silo_coin_quantity = globals.kiosk_silo_coin_max / 3 * globals.kiosk_silo_crop_quantity;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
