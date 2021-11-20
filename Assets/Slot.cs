using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject Data;
    public Vector3 PrimaryPosition;//Сохранение начального положения объкта
    public Vector3 Offset; //Смещение
    public Vector3 ScreenPoint;
    public bool MousedragBlockOn = false;
    public string Predmet;
    public Animator Anim;
    public int NumberSlotPredmet; //Номер слота предмета для интеграцией с таблицей 
    //Загружаем все доступные (открытые по уровню пользователя предметы) по номеру слота
    public void GetOpenSubjectsThisSlot()
    {
        //Получаем уровень пользователя
        int LevelUser = Data.GetComponent<Users>().GetLevelUserNumber();
        //Получаем все открытые пользователю объекты
        List<string> allSubjectsOpenLevel = Data.GetComponent<OpenLevel>().GetAllSubjectNameByOpenLevel();
        //Получить родителя по имени ребенка
        string parentName = Data.GetComponent<ParentsAndChilds>().GetSubjectParentNameBySubjectChildName(Predmet);
        //Получаем всех детей subject_child_name, из таблицы по имени родителя 
        List<string> childsAndParentsGettingSubjectParentName = Data.GetComponent<ParentsAndChilds>().GetAllSubjectChildNameBySubjectParentName(parentName);
        //Сравниваем. Получаем всех детей( по имени родителя), отсеивая по номеру слота, делая запрос
        //Получаем все SubjectName
        //Получаем все child_name полученные из таблицы parent_and_childs
        List<string> openChildsForSlot = new List<string>();
        //Проверяем что открыто у пользователя 
        foreach (var s in allSubjectsOpenLevel)
        {
            //Debug.Log("Level foreach1,s.Key=" + s);
            foreach (var n in childsAndParentsGettingSubjectParentName)
            {
                //Debug.Log("Level foreach2,n.Key=" + s);
                if (s == n) { openChildsForSlot.Add(s); }
            }

            
        }
        //
        Debug.Log("openChildsForSlot[0]=" + openChildsForSlot[0]);
        foreach (var o in openChildsForSlot)
        {
            
            Debug.Log("openChildsForSlot=" + o);
        }
        //Добавляем слоту полученный объект с индексом NumberSlotPredmets
        //Проверяем, не пустой ли он
        if (openChildsForSlot[NumberSlotPredmet] != null)
        {
            //Добавить проверку на добавление повторяющихся объектов
            Predmet = openChildsForSlot[NumberSlotPredmet];
        }


    }
    private void Start()
    {
        GetOpenSubjectsThisSlot();
    }
    /*
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
        //====Попкорница======================================================//
        if (gameObject.name == "slot_0_p_popcorn_pot") { predmet = "popcorn"; }
    }

    // Update is called once per frame
    void Update()
    {
        //====bakery=================================================//
        if (predmet == "bread") { anim.CrossFade("bread", 0); }
        if (predmet == "corn_bread") { anim.CrossFade("corn_bread", 0); }
        if (predmet == "cookie") { anim.CrossFade("cookie", 0); }
        //======================================Dairy==============================//
        if (predmet == "cream") { anim.CrossFade("cream", 0); }
        if (predmet == "butter") { anim.CrossFade("butter", 0); }
        if (predmet == "cheese") { anim.CrossFade("cheese", 0); }
        //=======================popcorn_pot========================================//
        if (predmet == "popcorn") { anim.CrossFade("popcorn", 0); }
    }
    void OnCollisionEnter2D(Collision2D other)//При столкновении
    {
        //Debug.Log("other:" + other.gameObject.name);//Кто столкнулся
        //Debug.Log("gameObject:" + gameObject.name);//С кем столкнулся
        if ((predmet == "bread") && (other.gameObject.name == "bakery_slot_0_zagruzki_frame")) //Загрузка хлеба в slot_backery_0_0
        {
            mousedrag_block_on = true;
            gameObject.transform.position = primary_position; //Тут предмет должен возвратится обратно на начальную позицию
            //bakery.add_in_slot_predmet("bread");
        }
        if ((predmet == "corn_bread") && (other.gameObject.name == "bakery_slot_0_zagruzki_frame")) //Загрузка хлеба в slot_backery_0_0
        {
            mousedrag_block_on = true;
            gameObject.transform.position = primary_position; //Тут предмет должен возвратится обратно на начальную позицию
            //bakery.add_in_slot_predmet("corn_bread");
        }
        if ((predmet == "cookie") && (other.gameObject.name == "bakery_slot_0_zagruzki_frame")) //Загрузка хлеба в slot_backery_0_0
        {
            mousedrag_block_on = true;
            gameObject.transform.position = primary_position; //Тут предмет должен возвратится обратно на начальную позицию
            //bakery.add_in_slot_predmet("cookie");
        }

        if ((predmet == "cream") && (other.gameObject.name == "bakery_slot_0_zagruzki_frame")) //Загрузка хлеба в slot_backery_0_0
        {
            mousedrag_block_on = true;
            gameObject.transform.position = primary_position; //Тут предмет должен возвратится обратно на начальную позицию
            //dairy.
        }
        if ((predmet == "butter") && (other.gameObject.name == "bakery_slot_0_zagruzki_frame")) //Загрузка хлеба в slot_backery_0_0
        {
            mousedrag_block_on = true;
            gameObject.transform.position = primary_position; //Тут предмет должен возвратится обратно на начальную позицию
            GameObject.Find("dairy").GetComponent<dairy>().event_0 = "add_butter";
        }
        if ((predmet == "cheese") && (other.gameObject.name == "slot_0_dairy_frame")) //Загрузка хлеба в slot_backery_0_0
        {
            mousedrag_block_on = true;
            gameObject.transform.position = primary_position; //Тут предмет должен возвратится обратно на начальную позицию
            //GameObject.Find("dairy").GetComponent<dairy>().add_in_slot_predmet("cheese");
            //dairy.add_in_slot_predmet("cheese");
        }

    }
    void OnMouseUp()//Когда отпускаешь кнопку
    {
        gameObject.transform.position = primary_position;//Загружаем первоначальную позицию объекта
        GameObject_Enable_Controller.slot_info.SetActive(false);
    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {
        mousedrag_block_on = false;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        primary_position = gameObject.transform.position;
        GameObject_Enable_Controller.slot_info.SetActive(true);
        GameObject.Find("SlotInfo").GetComponent<SlotInfo>().AddIngredientsByNameSubject(gameObject.name);
        if (gameObject.name == "bread")
        {

        }
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
    */
}
