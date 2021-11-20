using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refresh_backery_0 : MonoBehaviour
{
    public int sostoyanie_points;//Состояние точек
    // Start is called before the first frame update
    void Start()
    {
        sostoyanie_points = 1;
        GameObject.Find("point_0_bakery").GetComponent<Animator>().CrossFade("point_on", 0);
        GameObject.Find("point_1_bakery").GetComponent<Animator>().CrossFade("point_off", 0);
        GameObject.Find("point_2_bakery").GetComponent<Animator>().CrossFade("point_off", 0);
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
            //anim.CrossFade("empty", 0);
            GameObject.Find("point_0_bakery").GetComponent<Animator>().CrossFade("point_on", 0);
            GameObject.Find("point_1_bakery").GetComponent<Animator>().CrossFade("point_off", 0);
            GameObject.Find("point_2_bakery").GetComponent<Animator>().CrossFade("point_off", 0);
            /*visible_point_0_on.SetActive(true);
            visible_point_0_off.SetActive(false);
            visible_point_1_on.SetActive(false);
            visible_point_1_off.SetActive(true);
            visible_point_2_on.SetActive(false);
            visible_point_2_off.SetActive(true);*/
            //========================================//
            //GameObject.Find("slot_0_p_bakery").GetComponent<slot_predmet>().predmet = "bread";
            //GameObject.Find("slot_1_p_bakery").GetComponent<slot_predmet>().predmet = "corn_bread";
            //GameObject.Find("slot_2_p_bakery").GetComponent<slot_predmet>().predmet = "cookie";
            //GameObject.Find("slot_3_p_bakery").GetComponent<slot_predmet>().predmet = "bread";
            //GameObject.Find("slot_4_p_bakery").GetComponent<slot_predmet>().predmet = "bread";
            //visible_bread.SetActive(true);
            //visible_corn_bread.SetActive(true);
            //visible_cookie.SetActive(true);
            //=========================================//
            return;
            }

            if (sostoyanie_points == 1)
            {
            sostoyanie_points = 2;
            GameObject.Find("point_0_bakery").GetComponent<Animator>().CrossFade("point_off", 0);
            GameObject.Find("point_1_bakery").GetComponent<Animator>().CrossFade("point_on", 0);
            GameObject.Find("point_2_bakery").GetComponent<Animator>().CrossFade("point_off", 0);

            //GameObject.Find("slot_0_p_bakery").GetComponent<slot_predmet>().predmet = "corn_bread";
            //GameObject.Find("slot_1_p_bakery").GetComponent<slot_predmet>().predmet = "corn_bread";
            //GameObject.Find("slot_2_p_bakery").GetComponent<slot_predmet>().predmet = "corn_bread";
            //GameObject.Find("slot_3_p_bakery").GetComponent<slot_predmet>().predmet = "corn_bread";
            //GameObject.Find("slot_4_p_bakery").GetComponent<slot_predmet>().predmet = "corn_bread";
            //=========================================//
            return;
            }
            if (sostoyanie_points == 2)
            {
                sostoyanie_points = 0;
            GameObject.Find("point_0_bakery").GetComponent<Animator>().CrossFade("point_off", 0);
            GameObject.Find("point_1_bakery").GetComponent<Animator>().CrossFade("point_off", 0);
            GameObject.Find("point_2_bakery").GetComponent<Animator>().CrossFade("point_on", 0);

            //GameObject.Find("slot_0_p_bakery").GetComponent<slot_predmet>().predmet = "cookie";
            //GameObject.Find("slot_1_p_bakery").GetComponent<slot_predmet>().predmet = "cookie";
            //GameObject.Find("slot_2_p_bakery").GetComponent<slot_predmet>().predmet = "cookie";
            //GameObject.Find("slot_3_p_bakery").GetComponent<slot_predmet>().predmet = "cookie";
            //GameObject.Find("slot_4_p_bakery").GetComponent<slot_predmet>().predmet = "cookie";
            //==============================================//
            return;

            }
    }
}
