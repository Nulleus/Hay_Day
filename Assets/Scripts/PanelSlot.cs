using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems; // Required when using Event data.
using Sirenix.OdinInspector;

public class PanelSlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    public GameObject Data;
    [SerializeField]
    public GameObject InfoPanel;
    [SerializeField]
    private string SubjectName;
    public GameObject Quantity;
    //Откуда ожидать ответа(объект, выполняющий запрос на сервер)
    public GameObject ProductionBuildingSendRequest;
    public string GetSubjectName()
    {
        return SubjectName;
    }
    public void SetSubjectName(string subjectName)
    {
        SubjectName = subjectName;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        MouseUp();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        MouseDown();
    }
    private void OnMouseUp()
    {
        MouseUp();
    }
    private void OnMouseDown()
    {
        MouseDown();
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetQuantity()
    {
        return Convert.ToInt32(Quantity.GetComponent<Text>().text);
    }


    // Start is called before the first frame update
    private void Awake()
    {
        InfoPanel = gameObject.transform.Find("InfoPanel").gameObject;
        Quantity = gameObject.transform.Find("Quantity").gameObject;
    }
    public void SetQuantity(int number)
    {
        Quantity.GetComponent<Text>().text = number.ToString();
    }
    void Start()
    {

    }
    private void OnEnable()
    {
        
    }
    void Update()
    {

    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetTranslateInfoAll(string subjectName)
    {
        var displayName = Data.GetComponent<Translate>().GetDisplayName(subjectName, "RU", "Local");
        var description = Data.GetComponent<Translate>().GetDescription(subjectName, "RU", "Local");
        var timeBuilding = Data.GetComponent<Translate>().GetTimeBuildingDisplay(subjectName, "RU", "Local");
        InfoPanel.GetComponent<InfoPanel>().SetProperties(displayName, description, timeBuilding);
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetSprite(string subjectName) 
    {
        if (subjectName != "")
        {
            if (gameObject.GetComponent<SpriteRenderer>() != null && Data.GetComponent<ImageStorage>() != null)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Data.GetComponent<ImageStorage>().GetSprite(subjectName);
            }
            if (gameObject.GetComponent<Image>() != null && Data.GetComponent<ImageStorage>() != null)
            {
                gameObject.GetComponent<Image>().sprite = Data.GetComponent<ImageStorage>().GetSprite(subjectName);
            }
        }
        else
        {
            Debug.Log("Пусто");
        }
    }
    private void MouseDown()//Когда нажимаешь кнопку мыши
    {
        SetTranslateInfoAll(SubjectName);
        InfoPanel.SetActive(true);
    }
    private void MouseUp()//Когда отпускашь кнопку мыши
    {
        InfoPanel.SetActive(false);
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    void OnClear() //Очистка переменных
    {
        //Тут должен быть массив с объектами, которые необходимо очистить

    }
    void OnDisable()
    {
        OnClear();
    }

}
