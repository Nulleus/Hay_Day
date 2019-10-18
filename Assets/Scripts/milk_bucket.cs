using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milk_bucket : MonoBehaviour
{
    public Vector3 screenPoint;
    public Vector3 offset; //Смещение
    public Vector3 primary_position;//Сохранение начального положения объкта
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("other:" + other.gameObject.name);//С кем столкнулся
        Debug.Log("gameObject:" + gameObject.name);// Кто столкнулся
        if ((gameObject.name == "milk_bucket") && (other.gameObject.name == "cow_0") &&(globals.cow_0_stage==2))//Если пустой бидон столкнулась с коровой готовой к дойке
        {
            globals.milk = globals.milk + 1;
            globals.cow_0_stage = 0;
        }
        if ((gameObject.name == "milk_bucket") && (other.gameObject.name == "cow_1") && (globals.cow_1_stage == 2))//Если пустой бидон столкнулась с коровой готовой к дойке
        {
            globals.milk = globals.milk + 1;
            globals.cow_1_stage = 0;
        }
        if ((gameObject.name == "milk_bucket") && (other.gameObject.name == "cow_2") && (globals.cow_2_stage == 2))//Если пустой бидон столкнулась с коровой готовой к дойке
        {
            globals.milk = globals.milk + 1;
            globals.cow_2_stage = 0;
        }
        if ((gameObject.name == "milk_bucket") && (other.gameObject.name == "cow_3") && (globals.cow_3_stage == 2))//Если пустой бидон столкнулась с коровой готовой к дойке
        {
            globals.milk = globals.milk + 1;
            globals.cow_3_stage = 0;
        }
        if ((gameObject.name == "milk_bucket") && (other.gameObject.name == "cow_4") && (globals.cow_4_stage == 2))//Если пустой бидон столкнулась с коровой готовой к дойке
        {
            globals.milk = globals.milk + 1;
            globals.cow_4_stage = 0;
        }
        if ((gameObject.name == "milk_bucket") && (other.gameObject.name == "cow_5") && (globals.cow_5_stage == 2))//Если пустой бидон столкнулась с коровой готовой к дойке
        {
            globals.milk = globals.milk + 1;
            globals.cow_5_stage = 0;
        }
    }
    private void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        primary_position = gameObject.transform.position; //Запоминием первоначальную позицию объекта
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        //Debug.Log("curScreenPoint" + curScreenPoint);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        //Debug.Log("curPosition" + curPosition);
        transform.position = curPosition;
        globals.zoom = false;
        globals.drag = false;
    }
    private void OnMouseUp()
    {
        gameObject.transform.position = primary_position;//Отправляем объект на первоначальную позицию объекта
    }
}
