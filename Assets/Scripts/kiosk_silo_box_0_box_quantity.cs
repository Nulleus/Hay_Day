using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kiosk_silo_box_0_box_quantity : MonoBehaviour
{
    public GameObject GO_kiosk_silo_box_0_box_quantity;
    // Start is called before the first frame update
    void Start()
    {
        GO_kiosk_silo_box_0_box_quantity = GameObject.Find("kiosk_silo_box_0_box_quantity");
    }

    // Update is called once per frame
    void Update()
    {
        GO_kiosk_silo_box_0_box_quantity.GetComponent<Text>().text = globals.bread.ToString();
    }
}
