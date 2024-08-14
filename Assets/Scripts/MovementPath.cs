using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class MovementPath : MonoBehaviour
{
    //Виды пути, линейный и зацикленный
    public enum PathTypes
    {
        linear,
        loop
    }
    //Определяет тип пути
    public PathTypes PathType;
    //Направление движения вперед или назад
    public int MovementDirection = 1;
    //К какой точке двигаться
    public int MoveIngTo = 0;
    //Массив из точек движения
    public Transform[] PathElements;
    //Остановить, если достигли последней точки (false по умолчанию)
    public bool FinishIfTheEnd=false;
    public string SubjectName;
    public GameObject StartObject;
    //Отображение текста для количества объектов
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
    //Отображает линии между точками пути
    public void OnDrawGizmos()
    {
        //Проверяет, есть ли хотя бы 2 элемента пути
        if (PathElements == null || PathElements.Length < 2)
        {
            return;
        }
        //Проходит все точки массива
        for (var i = 1; i < PathElements.Length; i++)
        {
            //Рисует линии между точками
            Gizmos.DrawLine(PathElements[i - 1].position, PathElements[i].position);
        }
        //сли путь замкнутый
        if (PathType == PathTypes.loop)
        {
            //Рисует линии от последней точки к первой
            Gizmos.DrawLine(PathElements[0].position, PathElements[PathElements.Length - 1].position);
        }
    }
    //Получаем положение следующей точки
    public Transform GetStartPathPoint()
    {
        return PathElements[0];
    }
    public IEnumerator<Transform> GetNextPathPoint()
    {
        //Проверяет, есть ли точки, которым нужно проверять положение
        if (PathElements == null || PathElements.Length < 1)
        {
            //Позволяет выйти из корутины, если нашел несоответствие
            yield break;
        }
        while (true)
        {
            //возвращает текущее положение точки
            yield return PathElements[MoveIngTo];
            //Если точка всего одна, выйти
            if (PathElements.Length == 1)
            {
                continue;
            }
            //Если движение линейное
            if (PathType == PathTypes.linear)
            {
                //Если двигаемся по нарастающей
                if (MoveIngTo <= 0)
                {
                    //Добавляем 1 к движению
                    MovementDirection = 1;
                }
                //Если двигаемся по убывающей
                else if (MoveIngTo >= PathElements.Length - 1)
                {
                    //убираем один из движения
                    MovementDirection = -1;
                }
            }
            //Диапазон движения от 1 до -1
            MoveIngTo = MoveIngTo + MovementDirection;

            //Если линия зациклена
            if (PathType == PathTypes.loop)
            {
                //Если мы дошли до крайней точки
                if (MoveIngTo >= PathElements.Length)
                {
                    //То нужно идти не в обратную сторону, а к первой точке
                    MoveIngTo = 0;
                }
                //Если мы дошли до первой точки, двигаясь в обратную сторону
                if (MoveIngTo < 0)
                {
                    //То нужно переместиться к крайней точке
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
