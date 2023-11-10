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

    //Вид движения
    public MovementType Type = MovementType.Movement;
    //используемый путь
    public MovementPath MyPath;
    //скорость движения
    public float Speed = 1;
    //на какое расстояние должен подъехать объект к точке, чтобы понять что это точка
    public float MaxDistance = .1f;
    //Проверка точек
    private IEnumerator<Transform> PointInPath;

    void Start()
    {
        //Проверка, прикреплен ли путь
        if (MyPath == null)
        {
            Debug.Log("Добавь путь");
            return;
        }
        //обращение к корутине GetNextPathPoint
        PointInPath = MyPath.GetNextPathPoint();
        //Получение следующей точки пути
        PointInPath.MoveNext();
        //Есть ли следующая точка к которой можно передвигаться
        if (PointInPath.Current == null)
        {
            Debug.Log("Нужны точки");
            return;
        }
        //Перемещаем объект на стартовую точку пути
        transform.position = PointInPath.Current.position;
    }
    void Update()
    {
       //Если путь не найден
        if (PointInPath == null || PointInPath.Current == null)
        {
            return;
        } 
        
        if (Type == MovementType.Movement)
        {
            //Движение объекта к следующей точке
            transform.position = Vector3.MoveTowards(transform.position, PointInPath.Current.position, Time.deltaTime * Speed);
        }
        else if (Type == MovementType.Lerping)
        {
            //Движение объекта к следующей точке
            transform.position = Vector3.Lerp(transform.position, PointInPath.Current.position, Time.deltaTime * Speed);
        }
        //Проверка на близость к точке, для дальнейшего движения
        var distanceSqure = (transform.position - PointInPath.Current.position).sqrMagnitude;
        if (distanceSqure < MaxDistance * MaxDistance)
        {
            //Двигаемся к следующей точке
            PointInPath.MoveNext();
        }
    }
}
