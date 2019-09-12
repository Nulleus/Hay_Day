using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Click : MonoBehaviour
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
    void OnMouseUp()//Когда отпускаешь кнопку
    {
        if (gameObject.name == "silo")
        {
            silo_panel.SetActive(true);
        }
    }
}
