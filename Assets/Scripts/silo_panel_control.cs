using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silo_panel_control : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseUp()//Когда отпускаешь кнопку
    {

    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {
        GameObject.Find("silo_panel").GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
    }
    void OnMouseDrag()//Когда перемещение мыши
    {

    }
}
