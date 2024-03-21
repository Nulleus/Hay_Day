using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CloneObjectLines : MonoBehaviour
{
    public GameObject ObjectFromGetWidth; //Объект, с которого нужно сделать клон
    public Vector3 PositionBeginner; //Первоначальное значние объекта
    public GameObject ParentObject; //Родительский объект
    // Start is called before the first frame update
    private void Awake()
    {
        PositionBeginner = ObjectFromGetWidth.transform.position;//Присваиваем первоначальное значение переменной 
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
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void Clone(string subjectName, int quantity)
    {
        Debug.Log("ObjectFromGetWidth.GetComponent<Rect>().width=" + ObjectFromGetWidth.GetComponent<RectTransform>().rect.width);
        GameObject clone = Instantiate(ObjectFromGetWidth, ParentObject.transform);        
        //Добавим клону свойства 
        clone.SetActive(true);
        clone.GetComponent<MovementPath>().SubjectName = subjectName;
        clone.GetComponent<MovementPath>().SetValueTextPro("+" + quantity);     
        clone.GetComponent<MovementPath>().StartAnimation();
        Debug.Log("subjectName=" + subjectName);

    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void DeleteClones() //Удаление всех клонов
    {
        int childCount = ParentObject.transform.childCount;

        Debug.Log(childCount);
        GameObject clone;
        for (int i = 0; i <= childCount; i++) //
        {
            try
            {
                clone = gameObject.transform.Find("Lines(Clone)").gameObject;
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
