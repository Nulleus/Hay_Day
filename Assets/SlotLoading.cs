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
        
        Anim = GetComponent<Animator>();
        string subjectChild = Contents.GetSubjectChildInTheProcessOfAssembly(SubjectParent, NumberSlot, Data.GetComponent<Users>().IDUser);
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
