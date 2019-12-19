using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class ProductionBuilding : MonoBehaviour
{
    public bool slots_panel_on;
    public int count = 0;
    public bool count_on = false;
    public Vector3 primary_position;//Сохранение начального положения объкта
    public Vector3 offset; //Смещение
    public Vector3 screenPoint;
    string temp;
    public sql_client SC;
    public bool mousedrag_block_on = false;
    // Start is called before the first frame update
    void Start()
    {
        //Получить текущее имя объекта
        //CreateObject();
         

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateObject()
    {
        //Тут запрос на определение дочерних объектов у gameobject.name(текущего объекта)
        //Если нужно создать объект, создаем его
        GameObject go = new GameObject("bakery_arrow");
        go.transform.SetParent(this.transform);

    }
}
