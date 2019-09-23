using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiosk_selected_predmet : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.CrossFade("enemy", 1);
    }

    // Update is called once per frame
    void Update()
    {
        switch (globals.kiosk_barn_selected_predmet)
        {
            case "empty":
                anim.CrossFade("empty", 1);
                Debug.Log("Anim");
                break;
            case "cow_feed":
                anim.CrossFade("cow_feed", 1);
                break;
            case "nail":
                anim.CrossFade("nail", 1);
                break;
            case "bread":
                anim.CrossFade("bread", 1);
                break;
            case "corn_bread":
                anim.CrossFade("corn_bread", 1);
                break;
            case "cookie":
                anim.CrossFade("cookie", 1);
                break;
            case "butter":
                anim.CrossFade("butter", 1);
                break;
            case "cheese":
                anim.CrossFade("cheese", 1);
                break;
            case "screew":
                anim.CrossFade("screew", 1);
                break;
            case "wood_panel":
                anim.CrossFade("wood_panel", 1);
                break;

        }
    }
}
