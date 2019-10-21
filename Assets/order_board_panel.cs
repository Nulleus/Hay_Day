using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class order_board_panel : MonoBehaviour
{
    public GameObject GO_order_board_panel;
    // Start is called before the first frame update
    void Start()
    {
        GO_order_board_panel = GameObject.Find("order_board_panel");
    }

    // Update is called once per frame
    void Update()
    {
        if (globals.order_board_panel_visible) { GO_order_board_panel.SetActive(true); }
        if (globals.order_board_panel_visible==false) { GO_order_board_panel.SetActive(false); }
    }
}
