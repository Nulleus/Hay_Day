using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiosk_box_0_predmet : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
        anim.CrossFade("empty", 1);
    }

    // Update is called once per frame
    void Update()
    {
        switch (globals.kiosk_box_0_object_name)
        {
            case "wheat":
                anim.CrossFade("wheat", 1);
                break; 
        }
    }
}
