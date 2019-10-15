using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silo_button_close : MonoBehaviour
{
    public GameObject GO_kiosk_silo;
    // Start is called before the first frame update
    void Start()
    {
        GO_kiosk_silo = GameObject.Find("silo_panel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        GO_kiosk_silo.SetActive(false);
    }
}
