using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiosk_box_0_predmet : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.CrossFade("empty", 1);
    }

    // Update is called once per frame
    void Update()
    {
        switch (globals.kiosk_box_0_object_name)
        {
            case "empty":
                anim.CrossFade("empty", 1);
                break;

            case "wheat":
                anim.CrossFade("wheat", 1);
                break;
            case "corn":
                anim.CrossFade("corn", 1);
                break;
            case "soybean":
                anim.CrossFade("soybean", 1);
                break;
            case "sugarcane":
                anim.CrossFade("sugarcane", 1);
                break;
            case "carrot":
                anim.CrossFade("carrot", 1);
                break;
            case "pumpkin":
                anim.CrossFade("pumpkin", 1);
                break;
        }
    }
}
