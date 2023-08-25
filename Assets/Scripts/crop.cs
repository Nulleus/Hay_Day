using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crop : MonoBehaviour
{
    public Dictionary<string, int> silo_dict;
    public string silo_wheat;
    // Start is called before the first frame update
    void Start()
    {
        silo_dict = new Dictionary<string, int>(5);
        //Цикл фор всех культур в БД, таблице склада
        silo_dict[silo_wheat] = 0;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
