using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refresh_dairy : MonoBehaviour
{
    public int sostoyanie_points;//Состояние точек
    // Start is called before the first frame update
    void Start()
    {
        sostoyanie_points = 1;
        GameObject.Find("point_0_dairy").GetComponent<Animator>().CrossFade("point_on", 0);
        GameObject.Find("point_1_dairy").GetComponent<Animator>().CrossFade("point_off", 0);
        GameObject.Find("point_2_dairy").GetComponent<Animator>().CrossFade("point_off", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseUp()
    {

        if (sostoyanie_points == 0)
        {
            sostoyanie_points = 1;
            GameObject.Find("point_0_dairy").GetComponent<Animator>().CrossFade("point_on", 0);
            GameObject.Find("point_1_dairy").GetComponent<Animator>().CrossFade("point_off", 0);
            GameObject.Find("point_2_dairy").GetComponent<Animator>().CrossFade("point_off", 0);
            //========================================//
            GameObject.Find("slot_0_p_dairy").GetComponent<slot_predmet>().predmet = "cream";
            GameObject.Find("slot_1_p_dairy").GetComponent<slot_predmet>().predmet = "butter";
            GameObject.Find("slot_2_p_dairy").GetComponent<slot_predmet>().predmet = "cheese";
            GameObject.Find("slot_3_p_dairy").GetComponent<slot_predmet>().predmet = "cream";
            GameObject.Find("slot_4_p_dairy").GetComponent<slot_predmet>().predmet = "cream";
            //=========================================//
            return;
        }

        if (sostoyanie_points == 1)
        {
            sostoyanie_points = 2;
            GameObject.Find("point_0_dairy").GetComponent<Animator>().CrossFade("point_off", 0);
            GameObject.Find("point_1_dairy").GetComponent<Animator>().CrossFade("point_on", 0);
            GameObject.Find("point_2_dairy").GetComponent<Animator>().CrossFade("point_off", 0);

            GameObject.Find("slot_0_p_dairy").GetComponent<slot_predmet>().predmet = "butter";
            GameObject.Find("slot_1_p_dairy").GetComponent<slot_predmet>().predmet = "butter";
            GameObject.Find("slot_2_p_dairy").GetComponent<slot_predmet>().predmet = "butter";
            GameObject.Find("slot_3_p_dairy").GetComponent<slot_predmet>().predmet = "butter";
            GameObject.Find("slot_4_p_dairy").GetComponent<slot_predmet>().predmet = "butter";
            //=========================================//
            return;
        }
        if (sostoyanie_points == 2)
        {
            sostoyanie_points = 0;
            GameObject.Find("point_0_dairy").GetComponent<Animator>().CrossFade("point_off", 0);
            GameObject.Find("point_1_dairy").GetComponent<Animator>().CrossFade("point_off", 0);
            GameObject.Find("point_2_dairy").GetComponent<Animator>().CrossFade("point_on", 0);

            GameObject.Find("slot_0_p_dairy").GetComponent<slot_predmet>().predmet = "cheese";
            GameObject.Find("slot_1_p_dairy").GetComponent<slot_predmet>().predmet = "cheese";
            GameObject.Find("slot_2_p_dairy").GetComponent<slot_predmet>().predmet = "cheese";
            GameObject.Find("slot_3_p_dairy").GetComponent<slot_predmet>().predmet = "cheese";
            GameObject.Find("slot_4_p_dairy").GetComponent<slot_predmet>().predmet = "cheese";
            //==============================================//
            return;

        }
    }

}
