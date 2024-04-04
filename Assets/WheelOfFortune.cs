using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WheelOfFortune : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    [SerializeField]
    GameObject BlockObject;
    public GameObject PanelWheelOfFortune;
    public Vector3 offset; //Смещение
    public Vector3 screenPoint;
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
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Debug.Log("curScreenPoint=" + curScreenPoint);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        //тут нужно определить 
    }
    public void MouseDrag()
    {


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
