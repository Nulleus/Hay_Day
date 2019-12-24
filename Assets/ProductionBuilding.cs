using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class ProductionBuilding : MonoBehaviour
{
    private bool IsSlotsPanelGetOn;
    private int Count = 0;
    private bool IsCountOn = false;
    private Vector3 PrimaryPosition;//Сохранение начального положения объкта
    private Vector3 Offset; //Смещение
    private Vector3 ScreenPoint;
    private string Temp;
    private sql_client SC;
    private bool IsMouseDragBlockOn = false;
    private bool IsMoveModeOn;

    GameObject MainCamera;
    GameObject Collider;
    GameObject Arrow;
    GameObject Arrow0;
    GameObject Arrow1;
    GameObject Arrow2;
    GameObject Arrow3;
    GameObject Arrow4;
    GameObject SlotsPanel;
    GameObject ButtonFlip;
    GameObject ButtonMoveOff;
    GameObject SlotsPredmets;
    GameObject SlotsZagruzki;
    GameObject SlotsOtgruzki;

    private void OnEnable()
    {
        // Debug.Log(CameraScript.Instance.IsZoomBlocked);
    }

    void Start()
    {
      
        SlotsPanel = gameObject.transform.Find("SlotsPanel").gameObject;//Find Child gameobject
        Collider = gameObject.transform.Find("Collider").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        Collider.SetActive(false);
    }

    void CreateObject()
    {
        //Тут запрос на определение дочерних объектов у gameobject.name(текущего объекта)
        //Если нужно создать объект, создаем его
        GameObject go = new GameObject("bakery_arrow");
        go.transform.SetParent(this.transform);

    }
}
