using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WheelOfFortune : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    public GameObject PanelWheelOfFortune;
    //Смещение по Y
    public float OffsetY; 
    //Стартовая точка при касании 
    public Vector3 StartScreenPoint;
    //Текущая точка касания
    public Vector3 CurrentScreenPoint;
    public GameObject SpinWhellImage;
    //Клавиша зажата?
    public bool Pressed=false;
    public void OnPointerUp(PointerEventData eventData)
    {
            MouseUp();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
            MouseDown();
    }
    public void OnPointerMove(PointerEventData eventData)
    {
            MouseDrag();
    }
    public void MouseUp()
    {
        PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().StopSpin = false;
        Pressed = false;
        //Если колесо уже вращается, вращать нельзя
        //Крутим колесо, если пользователь отпускает кнопку, +нужно определить направление вращения
        if (StartScreenPoint.y > CurrentScreenPoint.y)
        {
            PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().ClockwiseRotation = false;
        }
        if (StartScreenPoint.y < CurrentScreenPoint.y)
        {
            PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().ClockwiseRotation = true;
        }
        PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation = (int)Random.Range(500.0f, 600.0f);
        
    }
    public void MouseDown()
    {
        Pressed = true;
        //Если колесо уже вращается, вращать нельзя
        if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation > 0)
        {
            return;
        }
        
        StartScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Debug.Log("StartScreenPoint=" + StartScreenPoint);
    }
    public void MouseDrag()
    {
        if (Pressed)
        {
            PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().StopSpin = false;
            CurrentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            Debug.Log("CurrentScreenPoint=" + CurrentScreenPoint);
            Debug.Log("StartScreenPoint=" + StartScreenPoint);
            //OffsetY = StartScreenPoint.y - CurrentScreenPoint.y;
            //Debug.Log("OffsetY=" + OffsetY);
            if (StartScreenPoint.y > CurrentScreenPoint.y)
            {
                //PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation = -10;
                //PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().ClockwiseRotation = false;
                SpinWhellImage.transform.Rotate(0, 0, -1);
            }
            if (StartScreenPoint.y < CurrentScreenPoint.y)
            {
                SpinWhellImage.transform.Rotate(0, 0, 1);
                //PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation = +10;
                //PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().ClockwiseRotation = true;
            }
        }


    }
    public void OnMouseUp()
    {
        MouseUp();
    }
    public void OnMouseDown()
    {
        MouseDown();
    }
    public void OnMouseDrag()
    {
        MouseDrag();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //считаем смещение по y

    }
}
