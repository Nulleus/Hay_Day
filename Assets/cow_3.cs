using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class cow_3 : MonoBehaviour
{
    public Animator cow_anim;//Анимация коровы

    // Start is called before the first frame update
    void Start()
    {
        cow_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var nowtime = DateTime.Now;//Получаем текущее время
        if (globals.cow_3_stage == 0) { cow_anim.CrossFade("cow_3_stage_0", 0); }
        if (globals.cow_3_stage == 1) { cow_anim.CrossFade("cow_3_stage_1", 0); }
        if (globals.cow_3_stage == 2) { cow_anim.CrossFade("cow_3_stage_2", 0); }
        if ((nowtime > globals.cow_3_end_stage_1) && (globals.cow_3_stage == 1)) { globals.cow_3_stage = 2; }//Тогда ожидает дойки
        //Если корова сытая


    }
}
