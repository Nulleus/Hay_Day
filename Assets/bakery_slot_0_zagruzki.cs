using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakery_slot_0_zagruzki : MonoBehaviour
{
    public Animator anim;//Анимация поля
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globals.bakery_array_slots_zagruzki[0, 0] == "")
        {
            anim.CrossFade("empty", 0);
        }
        if (globals.bakery_array_slots_zagruzki[0, 0] == "bread")
        {
            anim.CrossFade("bread", 0);
        }
        if (globals.bakery_array_slots_zagruzki[0, 0] == "corn_bread")
        {
            anim.CrossFade("corn_bread", 0);
        }
        if (globals.bakery_array_slots_zagruzki[0, 0] == "cookie")
        {
            anim.CrossFade("cookie", 0);
        }
    }

}
