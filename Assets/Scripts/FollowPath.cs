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
    //Имя анимации для объекта
    public string SubjectName;

    void Start()
    {
        StartAnimationMove(SubjectName);
    }
    //Запуск анимации движения
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void StartAnimationMove(string subjectName)
    {
        //Работа проверялась в MovementType=End, PathTypes=linear
        MyPath.MovementDirection = 1;
        SetSprite(subjectName);
        MyPath.MoveIngTo = 0;
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
    private void OnEnable()
    {
        StartAnimationMove(SubjectName);
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetSprite(string spriteName)
    {
        gameObject.GetComponent<SpriteController>().SetSprite(spriteName);
    }

    void Update()
    {
        //Если путь не найден
        if (PointInPath == null || PointInPath.Current == null)
        {
            return;
        }
        if (Type == MovementType.End)
        {
            
            transform.position = Vector2.MoveTowards((Vector2)transform.position, (Vector2)PointInPath.Current.position, Time.deltaTime * Speed);
            if (MyPath.MovementDirection == -1)
            {
                //Перемещение объекта на первую точку
                //Получаем позицию начальной точки
                var startedPoint = MyPath.GetStartPathPoint();
                //Перемещаем на начальную точку
                transform.position = (Vector2)startedPoint.position;
                SetSprite("empty");
                gameObject.SetActive(false);
            }
        }
        if (Type == MovementType.Movement)
        {
            //Движение объекта к следующей точке
            transform.position = Vector2.MoveTowards((Vector2)transform.position, (Vector2)PointInPath.Current.position, Time.deltaTime * Speed);
        }
        else if (Type == MovementType.Lerping)
        {
            //Движение объекта к следующей точке
            transform.position = Vector2.Lerp((Vector2)transform.position, (Vector2)PointInPath.Current.position, Time.deltaTime * Speed);
        }
        //Проверка на близость к точке, для дальнейшего движения
        var distanceSqure = ((Vector2)transform.position - (Vector2)PointInPath.Current.position).sqrMagnitude;
        if (distanceSqure < MaxDistance * MaxDistance)
        {
            //Двигаемся к следующей точке
            PointInPath.MoveNext();
        }
    }

}
