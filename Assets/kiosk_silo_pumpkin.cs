using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiosk_silo_pumpkin : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.CrossFade("pumpkin", 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseUp()//Когда отпускает клавишу мыши
    {
        globals.kiosk_silo_selected_crop = "pumpkin";
        globals.kiosk_silo_coin_max = 32;
        globals.kiosk_silo_coin_quantity = globals.kiosk_silo_coin_max / 3 * globals.kiosk_silo_crop_quantity;
    }
}
