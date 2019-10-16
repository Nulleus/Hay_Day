using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barn_button_close : MonoBehaviour
{
    public GameObject GO_kiosk_barn;
    // Start is called before the first frame update
    void Start()
    {
        GO_kiosk_barn = GameObject.Find("barn_panel");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseUp()
    {
        GO_kiosk_barn.SetActive(false);
    }
}
