using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Sirenix.OdinInspector;

public class WheelOfFortune : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    public GameObject PanelWheelOfFortune;
    //Стартовая точка при касании 
    public Vector3 StartScreenPoint;
    //Текущая точка касания
    public Vector3 CurrentScreenPoint;
    //Объект для картинки колеса
    public GameObject SpinWheelImage;
    //Клавиша зажата?
    private bool _isPressed;

    [ShowInInspector]
    public bool IsPressed
    {
        get
        {
            return _isPressed;
        }
        set 
        {
            _isPressed = value; 
        }
    }

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
        if (!PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().IsRotationEnabled)
        {
            return;
        }
        //Получаем приз при новом вращении
        PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().GetPrizeSpin();
        PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().IsStopSpin = false;
        IsPressed = false;
        PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().IncCountSpins();
        //Если колесо уже вращается, вращать нельзя
        //Крутим колесо, если пользователь отпускает кнопку, +нужно определить направление вращения
        if (StartScreenPoint.y > CurrentScreenPoint.y)
        {
            PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().IsClockwiseRotation = false;
        }
        if (StartScreenPoint.y < CurrentScreenPoint.y)
        {
            PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().IsClockwiseRotation = true;
        }
        PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().WheelRotationSpeed = (int)Random.Range(500.0f, 600.0f);
        
    }
    public void MouseDown()
    {
        if (!PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().IsRotationEnabled)
        {
            return;
        }
        IsPressed = true;
        //Если колесо уже вращается, вращать нельзя
        if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().WheelRotationSpeed > 0)
        {
            return;
        }       
        StartScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        //Debug.Log("StartScreenPoint=" + StartScreenPoint);
    }
    public void MouseDrag()
    {
        if (IsPressed)
        {
            PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().IsStopSpin = false;
            CurrentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            //Debug.Log("CurrentScreenPoint=" + CurrentScreenPoint);
            //Debug.Log("StartScreenPoint=" + StartScreenPoint);
            if (StartScreenPoint.y > CurrentScreenPoint.y)
            {
                SpinWheelImage.transform.Rotate(0, 0, -1);
            }
            if (StartScreenPoint.y < CurrentScreenPoint.y)
            {
                SpinWheelImage.transform.Rotate(0, 0, 1);
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
        IsPressed = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
