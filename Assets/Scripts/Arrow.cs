using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    GameObject[] Arrows;

    // Start is called before the first frame update
    void Start()
    {

    }
    //Изменение цвета объекта
    public void BrushColor(int number, Color color)//Игровой объект, цвет
    {
        Arrows[number].GetComponent<Renderer>().material.color = color;
    }

    public void ClearBrushColorAll()
    {
        for (int i = 0; i < Arrows.Length; i++)
        {
            Arrows[i].GetComponent<Renderer>().material.color = Color.white;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
