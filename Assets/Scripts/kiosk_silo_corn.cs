using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiosk_silo_corn : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.CrossFade("corn", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()//Когда отпускает клавишу мыши
    {
        globals.kiosk_silo_selected_crop = "corn";
        globals.kiosk_silo_coin_max = 7;
        globals.kiosk_silo_coin_quantity = globals.kiosk_silo_coin_max / 3 * globals.kiosk_silo_crop_quantity;
    }
}
