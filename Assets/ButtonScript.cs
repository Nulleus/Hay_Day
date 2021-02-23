using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    string Appointment; //Назначение кнопки
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()//Когда отпускаеть мышь
    {
        switch (Appointment)
        {
            case "buy":
                Debug.Log("pressed buy ");

                break;
            case "close":
                Debug.Log("pressed close ");
                break;
            default:
                Debug.Log("default case");
                break;
        }
    }
    }
