using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composition : MonoBehaviour
{
    //Скрипт хранит данные о составе (ингредиентах) объектов, то есть из чего они состоят и в каком количестве
    public Dictionary<string, int> Ingredient;
    [SerializeField]
    //private GOArray[] _array;
    // Start is called before the first frame update
    void Start()
    {
        Ingredient.Add("empty", 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
