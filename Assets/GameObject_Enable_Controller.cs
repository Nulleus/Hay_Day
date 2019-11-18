using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObject_Enable_Controller : MonoBehaviour
{
    public static GameObject price_for_diamonds_panel;
    public static GameObject bakery_arrow;
    public static GameObject bakery_arrow_0;
    public static GameObject bakery_arrow_1;
    public static GameObject bakery_arrow_2;
    public static GameObject bakery_arrow_3;
    public static GameObject bakery_arrow_4;
    public static GameObject farm_box_colliders;
    public static GameObject bakery_slots_predmets;//Слоты предметов пекарни
    public static GameObject bakery_slots_panel;//Слоты с панелью(закрытие, flip);
    public static GameObject bakery_slots_zagruzki;//Слоты загрузки
    // Start is called before the first frame update
    void Start()
    {
        price_for_diamonds_panel = GameObject.Find("price_for_diamonds_panel");
        bakery_slots_panel = GameObject.Find("bakery_slots_panel");
        bakery_slots_predmets = GameObject.Find("bakery_slots_predmets");
        bakery_slots_zagruzki = GameObject.Find("bakery_slots_zagruzki");
        bakery_arrow = GameObject.Find("bakery_arrow");
        bakery_arrow_0 = GameObject.Find("bakery_arrow_0");
        bakery_arrow_1 = GameObject.Find("bakery_arrow_1");
        bakery_arrow_2 = GameObject.Find("bakery_arrow_2");
        bakery_arrow_3 = GameObject.Find("bakery_arrow_3");
        bakery_arrow_4 = GameObject.Find("bakery_arrow_4");
        farm_box_colliders = GameObject.Find("farm_map_box_colliders");
    }

    // Update is called once per frame
    void Update()
    {
        if (globals.price_for_diamonds_panel_visible) { price_for_diamonds_panel.SetActive(true); } else { price_for_diamonds_panel.SetActive(false); }
        if (globals.bakery_slots_panel_visible) { bakery_slots_panel.SetActive(true); } else { bakery_slots_panel.SetActive(false); }
        if (globals.bakery_slots_predmets_visible) { bakery_slots_predmets.SetActive(true); } else { bakery_slots_predmets.SetActive(false); }
        if (globals.bakery_slots_zagruzki_visible) { bakery_slots_zagruzki.SetActive(true); }else { bakery_slots_zagruzki.SetActive(false); }
        if (globals.bakery_arrow_visible) { bakery_arrow.SetActive(true); } else { bakery_arrow.SetActive(false); }
        if (globals.bakery_arrow_0_visible) { bakery_arrow_0.SetActive(true); } else { bakery_arrow_0.SetActive(false); }
        if (globals.bakery_arrow_1_visible) { bakery_arrow_1.SetActive(true); } else { bakery_arrow_1.SetActive(false); }
        if (globals.bakery_arrow_2_visible) { bakery_arrow_2.SetActive(true); } else { bakery_arrow_2.SetActive(false); }
        if (globals.bakery_arrow_3_visible) { bakery_arrow_3.SetActive(true); } else { bakery_arrow_3.SetActive(false); }
        if (globals.bakery_arrow_4_visible) { bakery_arrow_4.SetActive(true); } else { bakery_arrow_4.SetActive(false); }
        if (globals.farm_map_box_colliders_enabled) { farm_box_colliders.SetActive(true); } else { farm_box_colliders.SetActive(false); }
    }
}
