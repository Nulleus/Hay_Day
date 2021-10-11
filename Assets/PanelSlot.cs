using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSlot : MonoBehaviour
{
    public GameObject InfoPanel;
    public Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    public void SetAnimaion(string subjectName) 
    {
        Anim.CrossFade(subjectName, 0);
    }
    private void OnMouseDown()//����� ��������� ������ ����
    {
        InfoPanel.SetActive(true);
    }
    private void OnMouseUp()//����� ��������� ������ ����
    {
        InfoPanel.SetActive(false);
    }
    void OnClear() //������� ����������
    {
        //��� ������ ���� ������ � ���������, ������� ���������� ��������

    }
    void OnDisable()
    {

        OnClear();
    }

}
