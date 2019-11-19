using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class price_for_diamonds_panel_button_close : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()//Когда отпускаешь кнопку
    {
        GameObject_Enable_Controller.price_for_diamonds_panel.SetActive(false);
    }
}
