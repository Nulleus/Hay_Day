using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data;
using MySql.Data.MySqlClient;

public class Ingredients : MonoBehaviour
{
    //Dictionary<string, int> Ingredient;
    //Скрипт загружает данные об составе(ингредиентах) в объекты "Ingredient"
    private void Start()
    {
        //Ingredient.Add("empty", 1);
    }

    public static Dictionary<string,int> Compositions (string SubjectName)
    {
        Dictionary<string, int> openWith = new Dictionary<string, int>();
        return openWith;
    }
}
