using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotShipment : MonoBehaviour
{
    //������ ������� ������(������, ����������� ������ �� ������)
    public GameObject ProductionBuildingSendRequest;
    public Animator Anim;//�������� ����
    public int NumberSlot;
    public GameObject Data;
    public bool CheckDisplayContents;
    // Start is called before the first frame update
    void Start()
    {
        //DisplayContents();//���� ������ ����������� ��������
    }
    private void OnEnable()
    {
        DisplayContents();
    }
    //���������� ���������� ������������ ����������� � ������
    public void DisplayContents()
    {
        Animator anim;
        anim = GetComponent<Animator>();
        string subjectsChildInTheShipment = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().SubjectsChildInTheShipment[NumberSlot];
        if (subjectsChildInTheShipment != "" && subjectsChildInTheShipment != "Not Found")
        {
            anim.CrossFade(subjectsChildInTheShipment, 0);
        }
        else
        {
            anim.CrossFade("empty", 0);
        }

    }

    // Up
    // is called once per frame
    void Update()
    {
        if (CheckDisplayContents)
        {
            DisplayContents();
        }
    }
    //�������� ��� ������� ������������ � ������������
}
