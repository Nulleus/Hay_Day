using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public string AppointmentButton; //Назначение кнопки
    public GameObject GameObjectOperand;//объект над которым выполняется операция в алгоритме
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
        Debug.Log("OnMouseUp()");
        switch (AppointmentButton)
        {
            case "ObjectFlipX":
                Debug.Log("pressed buy ");
                if (GameObjectOperand.gameObject.GetComponent<SpriteRenderer>().flipX) { GameObjectOperand.gameObject.GetComponent<SpriteRenderer>().flipX = false; }
                if (GameObjectOperand.gameObject.GetComponent<SpriteRenderer>().flipX==false) { GameObjectOperand.gameObject.GetComponent<SpriteRenderer>().flipX = true; }                 
                break;
            case "buy":
                Debug.Log("pressed buy ");

                break;
            case "close":
                GameObjectOperand.SetActive(false);
                Debug.Log("pressed close ");
                break;
                
            case "AcivateDisplay1":
                Display.displays[1].Activate();
                Debug.Log("pressed close ");
                break;
            default:
                Debug.Log("default case");
                break;
        }
    }
    }
