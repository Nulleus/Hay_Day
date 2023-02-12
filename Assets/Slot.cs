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
        Animator anim;
        anim = GetComponent<Animator>();
        Debug.Log(ProductionBuildingParent.GetComponent<ProductionBuilding>().SubjectsChildInTheProcessOfAssembly[NumberSlotPredmet]);
        anim.CrossFade(ProductionBuildingParent.GetComponent<ProductionBuilding>().SubjectsChildInTheProcessOfAssembly[NumberSlotPredmet], 0);
    }
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        GetOpenSubjectsThisSlot();
    }

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
        string productionBuilding = other.gameObject.GetComponent<ProductionBuildingUI>().NameSystem;
        Debug.Log("other:" + productionBuilding);//Кто столкнулся
        Debug.Log("gameObject:" + gameObject.name);//С кем столкнулся
        //Тут написать проверку на существование объекта
        //(тут надо переписать))
        if (other.gameObject.GetComponent<SlotLoading>().SubjectParent.GetComponent<ProductionBuildingUI>().NameSystem == SubjectParentName) 
        {
            MousedragBlockOn = true;
            gameObject.transform.position = PrimaryPosition; //Тут предмет должен возвратится обратно на начальную позицию
            //Запускаем производство
            ProductionBuildingParent.GetComponent<ProductionBuildingUI>().AddInSlotSubject(Predmet, productionBuilding);
        }

            //bakery.add_in_slot_predmet("bread");
       
    }
    void DisplaySubjects(int numberSlot)
    {

        string s = ProductionBuildingParent.GetComponent<ProductionBuilding>().SubjectsChildInTheProcessOfAssembly[numberSlot];
        Debug.Log(s);
    }
}
