using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_click : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {
        GameObject.Find("silo_panel").GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
    }
}
