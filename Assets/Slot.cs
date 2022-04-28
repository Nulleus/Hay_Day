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
    public Animator Anim;
    public string Predmet;
    public int NumberSlotPredmet; //Номер слота предмета для интеграцией с таблицей 
    public string SubjectParentName; //Родитель данного объекта(например: bakery)
    public GameObject ProductionBuildingParent;
    //Загружаем все доступные (открытые по уровню пользователя предметы) по номеру слота
    public void GetOpenSubjectsThisSlot()
    {
        //Получаем все открытые пользователю объекты
        List<string> allSubjectsOpenLevel= new List<string>(); /*= Data.GetComponent<OpenLevel>().GetAllSubjectNameByOpenLevel();*/
        //Получаем имя родителя
        SubjectParentName = ProductionBuildingParent.GetComponent<ProductionBuilding>().NameSystem;
        //Получаем всех детей subject_child_name, из таблицы по имени родителя 
        //List<string> childsAndParentsGettingSubjectParentName = Data.GetComponent<ParentsAndChilds>().GetAllSubjectChildNameBySubjectParentName(SubjectParentName);
        List<string> childsAndParentsGettingSubjectParentName = new List<string>();
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
            //Анимируем предмет
            Animator anim ;
            anim = GetComponent<Animator>();
            anim.CrossFade(Predmet, 0);
            //Запоминаем первоначальную позицию объекта
            PrimaryPosition = gameObject.transform.position;
        }


    }
    private void Start()
    {
        GetOpenSubjectsThisSlot();
    }
    /*

    // Update is called once per frame

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
    */
    void OnMouseUp()//Когда отпускаешь кнопку
    {
        gameObject.transform.position = PrimaryPosition;//Загружаем первоначальную позицию объекта
        //GameObject_Enable_Controller.slot_info.SetActive(false);
    }
    void OnMouseDown()//Когда нажимаешь кнопку
    {
        MousedragBlockOn = false;
        Offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPoint.z));
        PrimaryPosition = gameObject.transform.position;
        //GameObject_Enable_Controller.slot_info.SetActive(true);
        //GameObject.Find("SlotInfo").GetComponent<SlotInfo>().AddIngredientsByNameSubject(gameObject.name);
    }
    void OnMouseDrag()//Когда перемещение мыши
    {
        if (MousedragBlockOn == false)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPoint.z);
            //Debug.Log("curScreenPoint" + curScreenPoint);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + Offset;
            //Debug.Log("curPosition" + curPosition);
            transform.position = curPosition;
        }

        globals.zoom = false;
        globals.drag = false;
    }
    void OnCollisionEnter2D(Collision2D other)//При столкновении
    {
        Debug.Log("other:" + other.gameObject.name);//Кто столкнулся
        Debug.Log("gameObject:" + gameObject.name);//С кем столкнулся
        //Тут написать проверку на существование объекта
        if (other.gameObject.GetComponent<SlotLoading>().SubjectParent == SubjectParentName) 
        {
            MousedragBlockOn = true;
            gameObject.transform.position = PrimaryPosition; //Тут предмет должен возвратится обратно на начальную позицию
            //Запускаем производство
            ProductionBuildingParent.GetComponent<ProductionBuilding>().AddInSlotSubject(Predmet);
        }

            //bakery.add_in_slot_predmet("bread");
       
    }
    }
