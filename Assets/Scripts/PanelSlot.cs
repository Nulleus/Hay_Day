using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems; // Required when using Event data.

public class PanelSlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject Data;
    public GameObject InfoPanel;
    public string SubjectName;
    public GameObject Quantity;
    //Ожидаем ответа на запрос информации о предмете
    public bool CheckResponseTranslateRUS;
    [SerializeField]
    //int Quantity;
    //Откуда ожидать ответа(объект, выполняющий запрос на сервер)
    public GameObject ProductionBuildingSendRequest;
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
        CheckResponseTranslateRUS = true;
    }
    void Update()
    {
        if (CheckResponseTranslateRUS)
        {
            //Проверяем наличие ключа
            if (ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().ResponsesTranslateInfoRUS.ContainsKey(SubjectName))
            {
                var name = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().ResponsesTranslateInfoRUS[SubjectName].Name;
                var discription = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().ResponsesTranslateInfoRUS[SubjectName].Discription;
                var timeBuilding = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().ResponsesTranslateInfoRUS[SubjectName].TimeBuilding;
                //Присваиваем значение
                InfoPanel.GetComponent<InfoPanel>().SetProperties(name, discription, timeBuilding);
                CheckResponseTranslateRUS = false;
            }
        }
    }

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
        InfoPanel.SetActive(true);
    }
    private void MouseUp()//Когда отпускашь кнопку мыши
    {
        InfoPanel.SetActive(false);
    }
    void OnClear() //Очистка переменных
    {
        //Тут должен быть массив с объектами, которые необходимо очистить

    }
    void OnDisable()
    {
        CheckResponseTranslateRUS = false;
        OnClear();
    }

}
