using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotShipment : MonoBehaviour
{
    //Откуда ожидать ответа(объект, выполняющий запрос на сервер)
    public GameObject ProductionBuildingSendRequest;
    public int NumberSlot;
    public GameObject Data;
    public bool CheckDisplayContents;
    // Start is called before the first frame update
    void Start()
    {
        //DisplayContents();//Тест вывода загруженных объектов
    }
    private void OnEnable()
    {
        DisplayContents();
    }
    //Отобразить содержимое загруженного содержимого в слотах
    public void DisplayContents()
    {
        string subjectsChildInTheShipment = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().SubjectsChildInTheShipment[NumberSlot];
        if (subjectsChildInTheShipment != "" && subjectsChildInTheShipment != "Not Found")
        {
            gameObject.GetComponent<SpriteController>().SetSprite(subjectsChildInTheShipment);
        }
        else
        {
            gameObject.GetComponent<SpriteController>().SetSprite("empty");
        }

    }

    // Up
    // is called once per frame
    void Update()
    {
        if (CheckDisplayContents)
        {
            DisplayContents();
        }
    }
    //Получаем имя объекта загруженного в производство
}
