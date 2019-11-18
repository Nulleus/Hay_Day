using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class price_for_diamonds_panel_slot_0 : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "empty") { anim.CrossFade("empty", 0); }
        //====predmets=================================================//
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "bread") { anim.CrossFade("bread", 0); }
        //====crop====================================================//
        if (globals.price_for_diamonds_panel_slot_0_predmet_name == "wheat") { anim.CrossFade("wheat", 0); }
    }
}
