using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class price_for_diamonds_panel_slot_3 : MonoBehaviour
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
        if (globals.price_for_diamonds_panel_slot_3_predmet_name == "empty") { anim.CrossFade("empty", 0); }
        //====predmets=================================================//
        if (globals.price_for_diamonds_panel_slot_3_predmet_name == "egg") { anim.CrossFade("egg", 0); }
        if (globals.price_for_diamonds_panel_slot_3_predmet_name == "bread") { anim.CrossFade("bread", 0); }
        if (globals.price_for_diamonds_panel_slot_3_predmet_name == "chicken_feed") { anim.CrossFade("chicken_feed", 0); }
        if (globals.price_for_diamonds_panel_slot_3_predmet_name == "cow_feed") { anim.CrossFade("cow_feed", 0); }
        if (globals.price_for_diamonds_panel_slot_3_predmet_name == "milk") { anim.CrossFade("milk", 0); }
        if (globals.price_for_diamonds_panel_slot_3_predmet_name == "cream") { anim.CrossFade("cream", 0); }
        if (globals.price_for_diamonds_panel_slot_3_predmet_name == "popcorn") { anim.CrossFade("popcorn", 0); }
        if (globals.price_for_diamonds_panel_slot_3_predmet_name == "butter") { anim.CrossFade("butter", 0); }

        //====crop====================================================//
        if (globals.price_for_diamonds_panel_slot_3_predmet_name == "wheat") { anim.CrossFade("wheat", 0); }
        if (globals.price_for_diamonds_panel_slot_3_predmet_name == "corn") { anim.CrossFade("corn", 0); }
        if (globals.price_for_diamonds_panel_slot_3_predmet_name == "soybean") { anim.CrossFade("soybean", 0); }
        if (globals.price_for_diamonds_panel_slot_3_predmet_name == "sugarcane") { anim.CrossFade("sugarcane", 0); }
        if (globals.price_for_diamonds_panel_slot_3_predmet_name == "carrot") { anim.CrossFade("carrot", 0); }
        if (globals.price_for_diamonds_panel_slot_3_predmet_name == "pumpkin") { anim.CrossFade("pumpkin", 0); }

    }
    private void OnMouseDown()//Когда нажимаешь кнопку мыши
    {
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_3_info.SetActive(true);
    }
    private void OnMouseUp()//Когда отпускашь кнопку мыши
    {
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_3_info.SetActive(false);
    }
}
