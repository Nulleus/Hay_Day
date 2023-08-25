using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiosk_silo_button_close : MonoBehaviour
{
    public GameObject GO_kiosk_silo;
    // Start is called before the first frame update
    void Start()
    {
        GO_kiosk_silo = GameObject.Find("kiosk_silo");
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
