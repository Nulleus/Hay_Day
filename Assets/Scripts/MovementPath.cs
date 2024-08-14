using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class MovementPath : MonoBehaviour
{
    //���� ����, �������� � �����������
    public enum PathTypes
    {
        linear,
        loop
    }
    //���������� ��� ����
    public PathTypes PathType;
    //����������� �������� ������ ��� �����
    public int MovementDirection = 1;
    //� ����� ����� ���������
    public int MoveIngTo = 0;
    //������ �� ����� ��������
    public Transform[] PathElements;
    //����������, ���� �������� ��������� ����� (false �� ���������)
    public bool FinishIfTheEnd=false;
    public string SubjectName;
    public GameObject StartObject;
    //����������� ������ ��� ���������� ��������
    public GameObject Quantity;
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetSubjectName()
    {
        return SubjectName;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetValueTextPro(string value)
    {
        if (Quantity.GetComponent<TMPro.TextMeshProUGUI>() != null)
        {
            Quantity.GetComponent<TMPro.TextMeshProUGUI>().text = value;
        }
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void StartAnimation()
    {
        StartObject.SetActive(true);
    }
    //���������� ����� ����� ������� ����
    public void OnDrawGizmos()
    {
        //���������, ���� �� ���� �� 2 �������� ����
        if (PathElements == null || PathElements.Length < 2)
        {
            return;
        }
        //�������� ��� ����� �������
        for (var i = 1; i < PathElements.Length; i++)
        {
            //������ ����� ����� �������
            Gizmos.DrawLine(PathElements[i - 1].position, PathElements[i].position);
        }
        //��� ���� ���������
        if (PathType == PathTypes.loop)
        {
            //������ ����� �� ��������� ����� � ������
            Gizmos.DrawLine(PathElements[0].position, PathElements[PathElements.Length - 1].position);
        }
    }
    //�������� ��������� ��������� �����
    public Transform GetStartPathPoint()
    {
        return PathElements[0];
    }
    public IEnumerator<Transform> GetNextPathPoint()
    {
        //���������, ���� �� �����, ������� ����� ��������� ���������
        if (PathElements == null || PathElements.Length < 1)
        {
            //��������� ����� �� ��������, ���� ����� ��������������
            yield break;
        }
        while (true)
        {
            //���������� ������� ��������� �����
            yield return PathElements[MoveIngTo];
            //���� ����� ����� ����, �����
            if (PathElements.Length == 1)
            {
                continue;
            }
            //���� �������� ��������
            if (PathType == PathTypes.linear)
            {
                //���� ��������� �� �����������
                if (MoveIngTo <= 0)
                {
                    //��������� 1 � ��������
                    MovementDirection = 1;
                }
                //���� ��������� �� ���������
                else if (MoveIngTo >= PathElements.Length - 1)
                {
                    //������� ���� �� ��������
                    MovementDirection = -1;
                }
            }
            //�������� �������� �� 1 �� -1
            MoveIngTo = MoveIngTo + MovementDirection;

            //���� ����� ���������
            if (PathType == PathTypes.loop)
            {
                //���� �� ����� �� ������� �����
                if (MoveIngTo >= PathElements.Length)
                {
                    //�� ����� ���� �� � �������� �������, � � ������ �����
                    MoveIngTo = 0;
                }
                //���� �� ����� �� ������ �����, �������� � �������� �������
                if (MoveIngTo < 0)
                {
                    //�� ����� ������������� � ������� �����
                    MoveIngTo = PathElements.Length - 1;
                }
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
