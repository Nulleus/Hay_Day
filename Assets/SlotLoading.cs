using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotLoading : MonoBehaviour
{
    public Animator Anim;//Анимация поля
    public string SubjectParent;
    public int NumberSlot;
    public GameObject Data;
    // Start is called before the first frame update
    void Start()
    {
        DisplayContents();//Тест вывода загруженных объектов

    }
    //Отобразить содержимое загруженного содержимого в слотах
    public void DisplayContents()
    {
        Anim = GetComponent<Animator>();
        //Получаем загруженный объект в слоте по номеру слота(NumberSlot), (в порядке очереди) по имени производственного здания(SubjectParent) выбирая по IDUser(id пользователя)
        string subjectChild = Data.GetComponent<Contents>().GetSubjectChildInTheProcessOfAssembly(SubjectParent, NumberSlot/*Data.GetComponent<Users>().IDUser*/);
        if (subjectChild == "")
        {
            subjectChild = "empty";
        }
        Debug.Log(subjectChild);
        //Anim.CrossFade(subjectChild.ToLower(), 0);
        //Закомментировал потому что неправильно выбрано место для функции, пустая анимация.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
