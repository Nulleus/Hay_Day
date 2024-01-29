using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Data;
    public Vector3 PrimaryPosition;//Сохранение начального положения объкта
    public Vector3 Offset; //Смещение
    public Vector3 ScreenPoint;

    public bool MousedragBlockOn = false;
    public string Predmet;
    public int NumberSlotPredmet; //Номер слота предмета для интеграцией с таблицей 
    public string SubjectParentName; //Родитель данного объекта(например: bakery)
    public GameObject ProductionBuildingParent;
    //Загружаем все доступные (открытые по уровню пользователя предметы) по номеру слота
    public void GetOpenSubjectsBySlotNumber()
    {
        Predmet = ProductionBuildingParent.GetComponent<ParentAndChild>().Childs[NumberSlotPredmet];
        Debug.Log(Predmet);
    }
    void SetSprite()
    {
        gameObject.GetComponent<SpriteController>().SetSprite(Predmet);
    }
    private void Start()
    {
        
    }
    private void OnEnable()
    {
        GetOpenSubjectsBySlotNumber();
        SetSprite();
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

        MainCamera.GetComponent<CameraScript>().IsZoomBlocked = false;
        MainCamera.GetComponent<CameraScript>().IsDragBlocked = false;
    }
    void OnCollisionEnter2D(Collision2D other)//При столкновении
    {
        //Проверяем, чтобы родитель был один и тот же
        //string productionBuilding = other.gameObject.GetComponent<ProductionBuildingUI>().NameSystem;
        if (other != null)
        {
            
            if (other.gameObject.GetComponent<SlotLoadingFrame>() != null)
            {
                Debug.Log("Test " + other.gameObject.GetComponent<SlotLoadingFrame>());
                string parentOther = other.gameObject.GetComponent<SlotLoadingFrame>().ProductionBuildingParent.gameObject.GetComponent<ProductionBuildingUI>().NameSystem;
                string parent = gameObject.GetComponent<Slot>().ProductionBuildingParent.gameObject.GetComponent<ProductionBuildingUI>().NameSystem;
                int ignoreQuestion = 0;
                Debug.Log("parentOther:" + parentOther);//Другой
                Debug.Log("parent:" + parent);//С кем столкнулся
                                              //Тут написать проверку на существование объекта
                                              //(тут надо переписать))
                if (parentOther == parent)
                {
                    Debug.Log("if (parentOther == parent)");
                    MousedragBlockOn = true;
                    gameObject.transform.position = PrimaryPosition; //Тут предмет должен возвратится обратно на начальную позицию

                    //Запускаем производство
                    ProductionBuildingParent.GetComponent<ProductionBuildingUI>().AddInSlotSubject(Predmet, parent, ignoreQuestion);

                }

                //bakery.add_in_slot_predmet("bread");
            }

        }


    }
    private void Awake()
    {
        Debug.Log("Slot.cs" + gameObject.name);
    }

}
