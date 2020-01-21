using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldCreation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var go = new GameObject();//Co3flaeM пустой объект

        go.name = "Bакегу";//Присваиваем ему имя
        go.AddComponent<Rigidbody2D>();
        string typeName = "UnityEngine.Rigidbody2D, UnityEngine.Physics2DModule";//

        Type myClassType = Type.GetType(typeName);//nony4aeM тип Rigidbody2D go.AddComponent(myClassType);//flo6aBnflev компонент Rigidbody2D созданному объекту go.GetComponent(myClassType);

        dynamic someComp = go.GetComponents(myClassType);

        if (someComp != null) someComp.simulated = false;
        Debug.Log("0000");
    }
//^o.GetComponent<Rigidbody2D>().simulated = false;



}
