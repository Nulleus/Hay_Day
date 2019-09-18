using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silo_button_close : MonoBehaviour
{
    public GameObject silo_panel;
    // Start is called before the first frame update
    void Start()
    {
        silo_panel = GameObject.Find("silo_panel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        silo_panel.SetActive(false);
    }
}
