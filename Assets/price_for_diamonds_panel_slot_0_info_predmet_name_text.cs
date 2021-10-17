using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class price_for_diamonds_panel_slot_0_info_predmet_name_text : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var go = new GameObject();//Создаем пустой объект
        go.name = "Bакегу";//Присваиваем ему имя
        go.AddComponent<Rigidbody2D>();
        go.AddComponent<WorldCreation>();
        string typeName = "UnityEngine.Rigidbody2D, UnityEngine.Physics2DModule";//

        Type myClassType = Type.GetType(typeName);//nony4aeM тип Rigidbody2D go.AddComponent(myClassType);//flo6aBnflev компонент Rigidbody2D созданному объекту go.GetComponent(myClassType);

        dynamic someComp = go.GetComponents(myClassType);

        if (someComp != null) someComp.simulated = false;
        Debug.Log("0000");
    }

    // Update is called once per frame
    void Update()
    {
        //=============crops======================================================//
        //if (globals.price_for_diamonds_panel_slot_0_predmet_name == "wheat"){gameObject.GetComponent<Text>().text = "Пшеница";}
    }
}
