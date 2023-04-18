using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PanelSlot : MonoBehaviour
{
    public GameObject InfoPanel;
    public Animator Anim;
    public string SubjectName;
    public GameObject Quantity;
    [SerializeField]
    //int Quantity;

    public int GetQuantity()
    {
        return Convert.ToInt32(Quantity.GetComponent<Text>().text);
    }


    // Start is called before the first frame update
    private void Awake()
    {
        Anim = GetComponent<Animator>();
        Debug.Log("Anim = GetComponent<Animator>();");
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

    public void SetAnimaion(string subjectName) 
    {
        Anim.CrossFade(subjectName, 0);
    }
    private void OnMouseDown()//Когда нажимаешь кнопку мыши
    {
        InfoPanel.SetActive(true);
    }
    private void OnMouseUp()//Когда отпускашь кнопку мыши
    {
        InfoPanel.SetActive(false);
    }
    void OnClear() //Очистка переменных
    {
        //Тут должен быть массив с объектами, которые необходимо очистить

    }
    void OnDisable()
    {

        OnClear();
    }

}
