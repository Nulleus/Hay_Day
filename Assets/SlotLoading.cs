using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotLoading : MonoBehaviour
{
    public Animator Anim;//Анимация поля
    public GameObject SubjectParent;
    public int NumberSlot;
    public GameObject Data;
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
        Debug.Log(SubjectParent.GetComponent<ProductionBuilding>().SubjectsChildInTheProcessOfAssembly[NumberSlot]);
        anim.CrossFade(SubjectParent.GetComponent<ProductionBuilding>().SubjectsChildInTheProcessOfAssembly[NumberSlot], 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Получаем имя объекта загруженного в производство



}
