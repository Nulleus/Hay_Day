using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wheat_quantity : MonoBehaviour
{
    //public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
        //anim.CrossFade("wheat", 1);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = globals.quantuty_wheat.ToString();
    }

}
