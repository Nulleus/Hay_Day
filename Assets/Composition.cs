using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Composition : MonoBehaviour
{
    //������ ������ ������ � ������� (������������) ��������, �� ���� �� ���� ��� ������� � � ����� ����������
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
