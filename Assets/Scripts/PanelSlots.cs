using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSlots : MonoBehaviour
{
    //������ ����, ��� ���������� ���������� ����� ������������

    //
    public GameObject[] PanelSlot;
    // Start is called before the first frame update
    public void Clone(string subjectName, int subjectCount)
    {
        gameObject.GetComponent<CloneObject>().Clone(subjectName, subjectCount);
    }
    void Start()
    {
        
    }
    public void Show()
    {
        //��� ����� �����, ������������ ������ ������, ������������ �� ������ �� ������������
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        
    }
    void OnDisable()
    {
        DeleteClones();
    }
    public void DeleteClones()
    {
        gameObject.GetComponent<CloneObject>().DeleteClones();
    }
}
