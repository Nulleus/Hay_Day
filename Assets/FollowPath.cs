using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public enum MovementType
    {
        Movement,
        Lerping
    }

    //��� ��������
    public MovementType Type = MovementType.Movement;
    //������������ ����
    public MovementPath MyPath;
    //�������� ��������
    public float Speed = 1;
    //�� ����� ���������� ������ ��������� ������ � �����, ����� ������ ��� ��� �����
    public float MaxDistance = .1f;
    //�������� �����
    private IEnumerator<Transform> PointInPath;

    void Start()
    {
        //��������, ���������� �� ����
        if (MyPath == null)
        {
            Debug.Log("������ ����");
            return;
        }
        //��������� � �������� GetNextPathPoint
        PointInPath = MyPath.GetNextPathPoint();
        //��������� ��������� ����� ����
        PointInPath.MoveNext();
        //���� �� ��������� ����� � ������� ����� �������������
        if (PointInPath.Current == null)
        {
            Debug.Log("����� �����");
            return;
        }
        //���������� ������ �� ��������� ����� ����
        transform.position = PointInPath.Current.position;
    }
    void Update()
    {
       //���� ���� �� ������
        if (PointInPath == null || PointInPath.Current == null)
        {
            return;
        } 
        
        if (Type == MovementType.Movement)
        {
            //�������� ������� � ��������� �����
            transform.position = Vector3.MoveTowards(transform.position, PointInPath.Current.position, Time.deltaTime * Speed);
        }
        else if (Type == MovementType.Lerping)
        {
            //�������� ������� � ��������� �����
            transform.position = Vector3.Lerp(transform.position, PointInPath.Current.position, Time.deltaTime * Speed);
        }
        //�������� �� �������� � �����, ��� ����������� ��������
        var distanceSqure = (transform.position - PointInPath.Current.position).sqrMagnitude;
        if (distanceSqure < MaxDistance * MaxDistance)
        {
            //��������� � ��������� �����
            PointInPath.MoveNext();
        }
    }
}
