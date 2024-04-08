using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WheelOfFortune : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    [SerializeField]
    GameObject BlockObject;
    public GameObject PanelWheelOfFortune;
    //Смещение по Y
    public float OffsetY; 
    //Стартовая точка при касании 
    public Vector3 StartScreenPoint;
    //Текущая точка касания
    public Vector3 CurrentScreenPoint;
    public GameObject SpinWhellImage;
    public bool CheckBlockObject()
    {
        return BlockObject.GetComponent<BlockObject>().GetBlockObjectStatus();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!CheckBlockObject())
        {
            MouseUp();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!CheckBlockObject())
        {
            MouseDown();
        }
    }
    public void OnPointerMove(PointerEventData eventData)
    {
        if (!CheckBlockObject())
        {
            MouseDrag();
        }
    }
    public void MouseUp()
    {

    }
    public void MouseDown()
    {
        StartScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Debug.Log("StartScreenPoint=" + StartScreenPoint);
    }
    public void MouseDrag()
    {
        CurrentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Debug.Log("CurrentScreenPoint=" + CurrentScreenPoint);
        //OffsetY = StartScreenPoint.y - CurrentScreenPoint.y;
        //Debug.Log("OffsetY=" + OffsetY);
        if (StartScreenPoint.y < CurrentScreenPoint.y)
        {
            SpinWhellImage.transform.Rotate(0, 0, -2);
        }
        if (StartScreenPoint.y > CurrentScreenPoint.y)
        {
            SpinWhellImage.transform.Rotate(0, 0, +2);
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
