using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public string AppointmentButton; //Назначение кнопки
    public GameObject GameObjectOperand;//Имя главного родительского объекта
    public GameObject ButtonText; //Текст на кнопке с количеством
    public GameObject ButtonImage; //Картинка на кнопке
    public GameObject ButtonTextInfo; //Текст на кнопке с ее назначением

    public void SetAllPriceSubjectsText(int count)
    {
        ButtonText.GetComponent<Text>().text = count.ToString();
    }
    private void Awake()
    {
        ButtonText = gameObject.transform.Find("ButtonText").gameObject;
        ButtonImage = gameObject.transform.Find("ButtonImage").gameObject;
        ButtonTextInfo = gameObject.transform.Find("ButtonTextInfo").gameObject;
    }
    void Start()
    {
        
    }
    //Передаем кнопке значения
    void SetButtonInfo(string buttonText, string buttonTextInfo)
    {
        ButtonText.GetComponent<Text>().text = buttonText;
        //Заглушка на будущее для изменения картинки, вместо алмаза
        //ButtonImage.GetComponent<Animator>().CrossFade(subjectName,0);
        ButtonTextInfo.GetComponent<Text>().text = buttonTextInfo;

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
                Debug.Log("pressed ObjectFlipX");
                if (GameObjectOperand.GetComponent<SpriteRenderer>().flipX) { GameObjectOperand.GetComponent<SpriteRenderer>().flipX = false; return; }
                if (GameObjectOperand.GetComponent<SpriteRenderer>().flipX==false) { GameObjectOperand.GetComponent<SpriteRenderer>().flipX = true; return; }                 
                break;
            case "MoveOff":
                Debug.Log("pressed MoveOff");
                GameObjectOperand.gameObject.GetComponent<ProductionBuildingUI>().IsMoveModeOn = false;
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
            case "repeatConnection":
                
                Debug.Log("repeatConnection");
                break;
            default:
                Debug.Log("default case");
                break;
        }
    }
    }
