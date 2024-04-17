using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WheelOfFortune : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    [SerializeField]
    GameObject BlockObject;
    public GameObject PanelWheelOfFortune;
    //�������� �� Y
    public float OffsetY; 
    //��������� ����� ��� ������� 
    public Vector3 StartScreenPoint;
    //������� ����� �������
    public Vector3 CurrentScreenPoint;
    public GameObject SpinWhellImage;
    //������� ������?
    public bool Pressed=false;
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
        Pressed = false;
        //���� ������ ��� ���������, ������� ������
        if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation > 0)
        {
            return;
        }
        //������ ������, ���� ������������ ��������� ������, +����� ���������� ����������� ��������
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
        //���� ������ ��� ���������, ������� ������
        if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation > 0)
        {
            return;
        }
        
        StartScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        Debug.Log("StartScreenPoint=" + StartScreenPoint);
    }
    public void MouseDrag()
    {
        //���� ������ ��� ���������, ������� ������
        if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation > 0)
        {
            return;
        }
        if (Pressed)
        {
            CurrentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            Debug.Log("CurrentScreenPoint=" + CurrentScreenPoint);
            Debug.Log("StartScreenPoint=" + StartScreenPoint);
            //OffsetY = StartScreenPoint.y - CurrentScreenPoint.y;
            //Debug.Log("OffsetY=" + OffsetY);
            if (StartScreenPoint.y > CurrentScreenPoint.y)
            {
                SpinWhellImage.transform.Rotate(0, 0, -10);
            }
            if (StartScreenPoint.y < CurrentScreenPoint.y)
            {
                SpinWhellImage.transform.Rotate(0, 0, 10);
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
        //������� �������� �� y

    }
}
