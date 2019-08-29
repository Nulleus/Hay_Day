using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slot_predmet : MonoBehaviour
{
    public Vector3 primary_position;//Сохранение начального положения объкта
    public Vector3 offset; //Смещение
    public Vector3 screenPoint;
    public bool mousedrag_block_on = false;
    public string predmet;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //=====Пекарня==================================================//
        if (gameObject.name == "slot_0_p_bakery") { predmet = "bread"; }
        if (gameObject.name == "slot_1_p_bakery") { predmet = "corn_bread"; }
        if (gameObject.name == "slot_2_p_bakery") { predmet = "cookie"; }
        if (gameObject.name == "slot_3_p_bakery") { predmet = "corn_bread"; }
        if (gameObject.name == "slot_4_p_bakery") { predmet = "corn_bread"; }
        //=====Молокозавод==================================================//
        if (gameObject.name == "slot_0_p_dairy") { predmet = "cream"; }
        if (gameObject.name == "slot_1_p_dairy") { predmet = "butter"; }
        if (gameObject.name == "slot_2_p_dairy") { predmet = "cheese"; }
        if (gameObject.name == "slot_3_p_dairy") { predmet = "cheese"; }
        if (gameObject.name == "slot_4_p_dairy") { predmet = "cheese"; }

    }

    // Update is called once per frame
    void Update()
    {
        if (predmet == "bread") { anim.CrossFade("bread", 0); }
        if (predmet == "corn_bread") { anim.CrossFade("corn_bread", 0); }
        if (predmet == "cookie") { anim.CrossFade("cookie", 0); }

        if (predmet == "cream") { anim.CrossFade("cream", 0); }
        if (predmet == "butter") { anim.CrossFade("butter", 0); }
        if (predmet == "cheese") { anim.CrossFade("cheese", 0); }
    }
    void OnCollisionEnter2D(Collision2D other)//При столкновении
    {
        //Debug.Log("other:" + other.gameObject.name);//Кто столкнулся
        //Debug.Log("gameObject:" + gameObject.name);//С кем столкнулся
        if ((predmet == "bread") && (other.gameObject.name == "slot_0_bakery_frame")) //Загрузка хлеба в slot_backery_0_0
        {
            mousedrag_block_on = true;
            gameObject.transform.position = primary_position; //Тут предмет должен возвратится обратно на начальную позицию
            GameObject.Find("bakery").GetComponent<bakery>().event_0 = "add_bread";
        }
        if ((predmet == "corn_bread") && (other.gameObject.name == "slot_0_bakery_frame")) //Загрузка хлеба в slot_backery_0_0
        {
            mousedrag_block_on = true;
            gameObject.transform.position = primary_position; //Тут предмет должен возвратится обратно на начальную позицию
            GameObject.Find("bakery").GetComponent<bakery>().event_0 = "add_corn_bread";
        }
        if ((predmet == "cookie") && (other.gameObject.name == "slot_0_bakery_frame")) //Загрузка хлеба в slot_backery_0_0
        {
            mousedrag_block_on = true;
            gameObject.transform.position = primary_position; //Тут предмет должен возвратится обратно на начальную позицию
            GameObject.Find("bakery").GetComponent<bakery>().event_0 = "add_cookie";
        }

        if ((predmet == "cream") && (other.gameObject.name == "slot_0_dairy_frame")) //Загрузка хлеба в slot_backery_0_0
        {
            mousedrag_block_on = true;
            gameObject.transform.position = primary_position; //Тут предмет должен возвратится обратно на начальную позицию
            GameObject.Find("dairy").GetComponent<dairy>().event_0 = "add_cream";
        }
        if ((predmet == "butter") && (other.gameObject.name == "slot_0_dairy_frame")) //Загрузка хлеба в slot_backery_0_0
        {
            mousedrag_block_on = true;
            gameObject.transform.position = primary_position; //Тут предмет должен возвратится обратно на начальную позицию
            GameObject.Find("dairy").GetComponent<dairy>().event_0 = "add_butter";
        }
        if ((predmet == "cheese") && (other.gameObject.name == "slot_0_dairy_frame")) //Загрузка хлеба в slot_backery_0_0
        {
            mousedrag_block_on = true;
            gameObject.transform.position = primary_position; //Тут предмет должен возвратится обратно на начальную позицию
            GameObject.Find("dairy").GetComponent<dairy>().event_0 = "add_cheese";
        }
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
