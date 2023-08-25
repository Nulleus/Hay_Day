using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refresh_field_0 : MonoBehaviour
{
    public GameObject visible_point_0_on;
    public GameObject visible_point_0_off;
    public GameObject visible_point_1_on;
    public GameObject visible_point_1_off;
    public GameObject visible_point_2_on;
    public GameObject visible_point_2_off;
    public int sostoyanie_points;//Состояние точек
    public GameObject visible_wheat;
    public GameObject visible_corn;
    public GameObject visible_soybean;
    public GameObject visible_sugarcane;
    public GameObject visible_carrot;
    public GameObject visible_pumpkin;

    void Start()
    {
        sostoyanie_points = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        if (gameObject.name == "refresh_field_0")
        {
            if (sostoyanie_points == 0)
            {
                sostoyanie_points = 1;
                visible_point_0_on.SetActive(true);
                visible_point_0_off.SetActive(false);
                visible_point_1_on.SetActive(false);
                visible_point_1_off.SetActive(true);
                visible_point_2_on.SetActive(false);
                visible_point_2_off.SetActive(true);
                //========================================//
                visible_wheat.SetActive(true);
                visible_corn.SetActive(true);
                visible_soybean.SetActive(true);
                visible_sugarcane.SetActive(true);
                visible_carrot.SetActive(true);
                visible_pumpkin.SetActive(false);
                //=========================================//
                return;
            }

            if (sostoyanie_points == 1)
            {
                sostoyanie_points = 2;
                visible_point_0_on.SetActive(false);
                visible_point_0_off.SetActive(true);
                visible_point_1_on.SetActive(true);
                visible_point_1_off.SetActive(false);
                visible_point_2_on.SetActive(false);
                visible_point_2_off.SetActive(true);

                visible_wheat.SetActive(false);
                visible_corn.SetActive(false);
                visible_soybean.SetActive(false);
                visible_sugarcane.SetActive(false);
                visible_carrot.SetActive(false);
                visible_pumpkin.SetActive(true);
                return;
            }
            if (sostoyanie_points == 2)
            {
                sostoyanie_points = 0;
                visible_point_0_on.SetActive(false);
                visible_point_0_off.SetActive(true);
                visible_point_1_on.SetActive(false);
                visible_point_1_off.SetActive(true);
                visible_point_2_on.SetActive(true);
                visible_point_2_off.SetActive(false);
                return;

            }
        }

    }
}
