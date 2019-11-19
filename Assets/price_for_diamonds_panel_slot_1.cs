using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class price_for_diamonds_panel_slot_1 : MonoBehaviour
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
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "Пусто") { anim.CrossFade("empty", 0); }
        //====predmets=================================================//
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "Яйцо") { anim.CrossFade("egg", 0); }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "Хлеб") { anim.CrossFade("bread", 0); }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "Куриный корм") { anim.CrossFade("chicken_feed", 0); }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "Коровий корм") { anim.CrossFade("cow_feed", 0); }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "Молоко") { anim.CrossFade("milk", 0); }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "Сливки") { anim.CrossFade("cream", 0); }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "Попкорн") { anim.CrossFade("popcorn", 0); }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "Масло") { anim.CrossFade("butter", 0); }

        //====crop====================================================//
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "Пшеница") { anim.CrossFade("wheat", 0); }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "Кукуруза") { anim.CrossFade("corn", 0); }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "Соя") { anim.CrossFade("soybean", 0); }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "Тростник") { anim.CrossFade("sugarcane", 0); }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "Морковь") { anim.CrossFade("carrot", 0); }
        if (globals.price_for_diamonds_panel_slot_1_predmet_name == "Тыква") { anim.CrossFade("pumpkin", 0); }

    }
    private void OnMouseDown()//Когда нажимаешь кнопку мыши
    {
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_1_info.SetActive(true);
    }
    private void OnMouseUp()//Когда отпускашь кнопку мыши
    {
        GameObject_Enable_Controller.price_for_diamonds_panel_slot_1_info.SetActive(false);
    }
}
