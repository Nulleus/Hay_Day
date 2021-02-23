using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject Arrow0;
    GameObject Arrow1;
    GameObject Arrow2;
    GameObject Arrow3;
    GameObject Arrow4;
    // Start is called before the first frame update
    void Start()
    {
        Arrow0 = gameObject.transform.Find("Arrow0").gameObject;//Find Child gameobject
        Arrow1 = gameObject.transform.Find("Arrow1").gameObject;//Find Child gameobject
        Arrow2 = gameObject.transform.Find("Arrow2").gameObject;//Find Child gameobject
        Arrow3 = gameObject.transform.Find("Arrow3").gameObject;//Find Child gameobject
        Arrow4 = gameObject.transform.Find("Arrow4").gameObject;//Find Child gameobject
    }
    //Изменение цвета объекта
    public void BrushColor(string go, Color color)//Игровой объект, цвет
    {
        if (go == "Arrow0") { Arrow0.GetComponent<Renderer>().material.color = color; }
        if (go == "Arrow1") { Arrow1.GetComponent<Renderer>().material.color = color; }
        if (go == "Arrow2") { Arrow2.GetComponent<Renderer>().material.color = color; }
        if (go == "Arrow3") { Arrow3.GetComponent<Renderer>().material.color = color; }
        if (go == "Arrow4") { Arrow4.GetComponent<Renderer>().material.color = color; }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
