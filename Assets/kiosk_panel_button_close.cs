using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiosk_panel_button_close : MonoBehaviour
{
    public GameObject GO_kiosk_panel;
    // Start is called before the first frame update
    void Start()
    {
        GO_kiosk_panel = GameObject.Find("kiosk_panel");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseUp()
    {
        GO_kiosk_panel.SetActive(false);
    }
}
