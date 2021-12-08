using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public string AppointmentButton; //Назначение кнопки
    public GameObject GameObjectOperand;//объект над которым выполняется операция в алгоритме
    public GameObject ButtonText; //Текст кнопки
    
    public void SetAllPriceSubjectsText(int count)
    {
        ButtonText.GetComponent<Text>().text = count.ToString();
    }
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
                Debug.Log("pressed ObjectFlipX ");
                if (GameObjectOperand.gameObject.GetComponent<SpriteRenderer>().flipX) { GameObjectOperand.gameObject.GetComponent<SpriteRenderer>().flipX = false; }
                if (GameObjectOperand.gameObject.GetComponent<SpriteRenderer>().flipX==false) { GameObjectOperand.gameObject.GetComponent<SpriteRenderer>().flipX = true; }                 
                break;
            case "buyForDaemonds":
                Debug.Log("pressed buyForDaemonds");
                    GameObjectOperand.GetComponent<PanelFewResources>().SetUserActionSelection(AppointmentButton);
                    //Выбор пользователя был сделан

                    Debug.Log("Выбор пользователя: " + AppointmentButton);

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
