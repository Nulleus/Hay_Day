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
        anim.CrossFade(globals.price_for_diamonds_panel_slot_1_predmet_name, 0);
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
