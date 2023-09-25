using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class ButtonScript : MonoBehaviour, IPointerDownHandler
{
    //Откуда ожидать ответа(объект, выполняющий запрос на сервер)
    public GameObject ProductionBuildingSendRequest;
    public GameObject MainCamera;
    public string AppointmentButton; //Назначение кнопки
    public GameObject GameObjectOperand;//Имя главного родительского объекта
    public GameObject ButtonText; //Текст на кнопке с количеством
    public GameObject ButtonImage; //Картинка на кнопке
    public GameObject ButtonTextInfo; //Текст на кнопке с ее назначением

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
    }
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
    public void OnMouseUp()//Когда отпускаеть мышь
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
                string subjectNameForBuilding = GameObjectOperand.GetComponent<PanelFewResources>().SubjectNameForBuilding;
                string productionBuildingName = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().SubjectName;
                //Покупаем недостающие объекты
                ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().BuySubjectForDiamond(subjectNameForBuilding, "Local");
                ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().BuySubjectForDiamond(subjectNameForBuilding, "Server");
                ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().AddInSlotSubject(subjectNameForBuilding,productionBuildingName,1,"Local");               
                ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().AddInSlotSubject(subjectNameForBuilding, productionBuildingName, 1, "Server");
                Debug.Log("Выбор пользователя: " + AppointmentButton);
                GameObjectOperand.GetComponent<PanelFewResources>().PanelFewResourceBox.SetActive(false);
                break;
            case "close":
                MainCamera.GetComponent<CameraScript>().IsZoomBlocked = false;
                MainCamera.GetComponent<CameraScript>().IsDragBlocked = false;
                MainCamera.GetComponent<Camera>().orthographicSize = MainCamera.GetComponent<CameraScript>().SaveOrthographicSize;
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
            case "PanelQuestionButtonOK":
                //Выбор пользователя был сделан
                subjectNameForBuilding = GameObjectOperand.GetComponent<PanelQuestion>().SubjectNameForBuilding;
                Debug.Log("PanelQuestionButtonOK:subjectNameForBuilding=" + subjectNameForBuilding);
                productionBuildingName = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().SubjectName;
                Debug.Log("PanelQuestionButtonOK:productionBuildingName=" + productionBuildingName);
                ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().AddInSlotSubject(subjectNameForBuilding, productionBuildingName, 1, "Local");
                ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().AddInSlotSubject(subjectNameForBuilding, productionBuildingName, 1, "Server");
                Debug.Log("Выбор пользователя: " + AppointmentButton);
                GameObjectOperand.GetComponent<PanelQuestion>().PanelQuestionBox.SetActive(false);
                Debug.Log("PanelQuestionButtonOK");
                break;
            default:
                Debug.Log("default case");
                break;
        }
    }
    }
