using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public class Composition : SerializedMonoBehaviour
{
    //������ ������ ������ � ������� (������������) ��������, �� ���� �� ���� ��� ������� � � ����� ����������\
    [ShowInInspector]
    string SubjectName; 
    public Dictionary<string, int> Ingredient;


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
