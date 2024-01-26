using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class FollowPath : MonoBehaviour
{
    public enum MovementType
    {
        Movement,
        Lerping,
        End
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
    //��� �������� ��� �������
    public string SubjectName;
    public Sprite temp;

    void Start()
    {

    }
    //������ �������� ��������

    public void StartAnimationMove(string subjectName)
    {
        //������ ����������� � MovementType=End, PathTypes=linear
        MyPath.MovementDirection = 1;
        gameObject.GetComponent<Animator>().CrossFade(subjectName, 0);
        

        MyPath.MoveIngTo = 0;
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
    private void OnEnable()
    {
        StartAnimationMove(SubjectName);
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void ChangeSprite()
    {
        //temp = gameObject.GetComponent<SpriteRenderer>().sprite;
        gameObject.GetComponent<Image>().sprite = temp;
    }
    void Update()
    {
        //���� ���� �� ������
        if (PointInPath == null || PointInPath.Current == null)
        {
            return;
        }
        if (Type == MovementType.End)
        {
            
            transform.position = Vector2.MoveTowards((Vector2)transform.position, (Vector2)PointInPath.Current.position, Time.deltaTime * Speed);
            if (MyPath.MovementDirection == -1)
            {
                //����������� ������� �� ������ �����
                //�������� ������� ��������� �����
                var startedPoint = MyPath.GetStartPathPoint();
                //���������� �� ��������� �����
                transform.position = (Vector2)startedPoint.position;
                gameObject.GetComponent<Animator>().CrossFade("empty", 0);

                
                //PointInPath.MoveNext();
            }
            //PointInPath.MoveNext();
        }
        if (Type == MovementType.Movement)
        {
            //�������� ������� � ��������� �����
            transform.position = Vector2.MoveTowards((Vector2)transform.position, (Vector2)PointInPath.Current.position, Time.deltaTime * Speed);
        }
        else if (Type == MovementType.Lerping)
        {
            //�������� ������� � ��������� �����
            transform.position = Vector2.Lerp((Vector2)transform.position, (Vector2)PointInPath.Current.position, Time.deltaTime * Speed);
        }
        //�������� �� �������� � �����, ��� ����������� ��������
        var distanceSqure = ((Vector2)transform.position - (Vector2)PointInPath.Current.position).sqrMagnitude;
        if (distanceSqure < MaxDistance * MaxDistance)
        {
            //��������� � ��������� �����
            PointInPath.MoveNext();
        }
    }

}
