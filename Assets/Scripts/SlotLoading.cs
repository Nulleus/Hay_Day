using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SlotLoading : MonoBehaviour
{
    //Откуда ожидать ответа(объект, выполняющий запрос на сервер)
    public GameObject ProductionBuildingSendRequest;
    public int NumberSlot;
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
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void DisplayContents()
    {
        string subjectsChildInTheProcessOfAssembly = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().SubjectsChildInTheProcessOfAssembly[NumberSlot];
        if (subjectsChildInTheProcessOfAssembly != "" && subjectsChildInTheProcessOfAssembly != "Error")
        {
            gameObject.GetComponent<SpriteController>().SetSprite(subjectsChildInTheProcessOfAssembly);
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
