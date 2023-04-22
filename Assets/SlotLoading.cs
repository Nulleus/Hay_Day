using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotLoading : MonoBehaviour
{
    //Откуда ожидать ответа(объект, выполняющий запрос на сервер)
    public GameObject ProductionBuildingSendRequest;
    public Animator Anim;//Анимация поля
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
        Animator anim;
        anim = GetComponent<Animator>();
        //Debug.Log(gameObject.GetComponent<ProductionBuilding>().SubjectsChildInTheProcessOfAssembly[NumberSlot]);
        //anim.CrossFade(SubjectParent.GetComponent<ProductionBuilding>().SubjectsChildInTheProcessOfAssembly[NumberSlot], 0);
        anim.CrossFade(ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().SubjectsChildInTheProcessOfAssembly[NumberSlot], 0);
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
