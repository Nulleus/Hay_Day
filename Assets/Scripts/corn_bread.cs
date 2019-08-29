using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corn_bread : MonoBehaviour
{
    public Vector3 primary_position;//Сохранение начального положения объкта
    public Vector3 offset; //Смещение
    public Vector3 screenPoint;
    public bool mousedrag_block_on = false;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other)//При столкновении
    {
        //Debug.Log("other:" + other.gameObject.name);//Кто столкнулся
        //Debug.Log("gameObject:" + gameObject.name);//С кем столкнулся
        if ((gameObject.name == "corn_bread") && (other.gameObject.name == "slot_0_bakery_frame")) //Загрузка хлеба в slot_backery_0_0
        {
            mousedrag_block_on = true;
            gameObject.transform.position = primary_position; //Тут предмет должен возвратится обратно на начальную позицию
            GameObject.Find("bakery").GetComponent<bakery>().event_0 = "add_corn_bread";
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseUp()//Когда отпускаешь кнопку
    {
        gameObject.transform.position = primary_position;//Загружаем первоначальную позицию объекта
    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {
        mousedrag_block_on = false;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        primary_position = gameObject.transform.position;
    }
    void OnMouseDrag()//Когда перемещение мыши
    {
        if (mousedrag_block_on == false)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            //Debug.Log("curScreenPoint" + curScreenPoint);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            //Debug.Log("curPosition" + curPosition);
            transform.position = curPosition;
        }

        globals.zoom = false;
        globals.drag = false;
    }
}
