using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneObject : MonoBehaviour
{
    public GameObject ObjectFromGetWidth; //Объект, с которого нужно сделать клон
    public Vector3 PositionBeginner; //Первоначальное значние объекта
    public Vector3 PositionCloneEnd; //Расположение последнего клонированного объекта

    public GameObject ParentObject; //Родительский объект
    public int offsetX; //Смещение по Х

    // Start is called before the first frame update
    private void Awake()
    {
        PositionBeginner = ObjectFromGetWidth.transform.position;//Присваиваем первоначальное значение переменной 
        PositionCloneEnd = PositionBeginner;
        Debug.Log("!!!!!!!!!!!!!!!!!!!!!!");
        //Clone("Test", 890);
    }
    void Start()
    {


    }
    private void OnEnable()
    {
        
    }

    // Update is called once per frame
    public void Clone(string subjectName, int subjectCount)
    {
        //PositionCloneEnd = ObjectFromGetWidth.transform.position; //Присваиваем первоначальное значение переменной 
        Debug.Log(PositionCloneEnd);
        Debug.Log("ObjectFromGetWidth.GetComponent<Rect>().width=" + ObjectFromGetWidth.GetComponent<RectTransform>().rect.width);
        GameObject clone = Instantiate(ObjectFromGetWidth, new Vector3((PositionCloneEnd.x + (ObjectFromGetWidth.GetComponent<RectTransform>().rect.width + offsetX))
        , ObjectFromGetWidth.transform.position.y, ObjectFromGetWidth.transform.position.z), Quaternion.identity, ParentObject.transform);
        //Добавим клону свойства 
        clone.SetActive(true);
        clone.GetComponent<PanelSlot>().SubjectName = subjectName;
        clone.GetComponent<PanelSlot>().SetAnimaion(subjectName);
        clone.GetComponent<PanelSlot>().InfoPanel.GetComponent<InfoPanel>().SubjectName = subjectName;
        clone.GetComponent<PanelSlot>().SetQuantity(subjectCount);
        PositionCloneEnd = clone.transform.position;//Расположение созданного клона

    }
    public void DeleteClones() //Удаление клонов
    {
        PositionCloneEnd = PositionBeginner;
        int childCount = gameObject.transform.childCount;
        
        Debug.Log(childCount);
        GameObject clone;
        for (int i = 0; i <= childCount; i++) //
        {
            try
            {
                clone = gameObject.transform.Find("PanelSlot(Clone)").gameObject;
                Debug.Log("cloneID: " + clone.GetInstanceID());
                Debug.Log("clone: " + clone);
                Debug.Log("Удаление");
                DestroyImmediate(clone);
            }
            catch 
            {
                Debug.Log("Нет такого объекта");
            }
        }
    }
    void OnDisable()
    {
        DeleteClones();
    }
}