using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachingCamera : MonoBehaviour
{
    //Объект к которому нужно приблизится
    public GameObject Target;
    private Vector2 Velocity = Vector2.zero;
    //Время движения
    public float SmoothTime = 0.3F;
    //
    public bool ApproachingStatus;

    public void ApproachingStart()
    {
        ApproachingStatus = true;
    }
    public void ApproachingStop()
    {
        ApproachingStatus = false;
    }

    void Update()
    {
        ApproachingToTarget();
    }

    //Смещение до цели
    public void ApproachingToTarget()
    {
        if (ApproachingStatus)
        {
            Vector2 targetPosition = Target.transform.position;
            Vector2 thisPosition = transform.position;
            transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref Velocity, SmoothTime);
            //Debug.Log("thisPosition=" + thisPosition + ";" + "targetPosition=" + targetPosition + ";");

            bool xEqual = MyApproximately(thisPosition.x, targetPosition.x, 1f);
            bool yEqual = MyApproximately(thisPosition.y, targetPosition.y, 1f);
            //Debug.Log(xEqual+":"+yEqual);
            if ((xEqual==true)&& (yEqual==true))
            {
                //Debug.Log("OK");
                ApproachingStatus = false;
            }
        }
        
    }
    //Функция сравнения чисел a,b типа float, tolerance - допустимая погрешность 
    private bool MyApproximately(float a, float b, float tolerance)
    {
        return (Mathf.Abs(a - b) < tolerance);
    }



}
