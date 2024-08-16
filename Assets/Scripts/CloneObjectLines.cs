using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CloneObjectLines : MonoBehaviour
{
    //Объект, с которого нужно сделать клон
    public GameObject ObjectFromGetWidth; 
    //Первоначальное значние объекта
    public Vector3 PositionBeginner; 
    //Родительский объект, нужно чтобы узнать например в какой родительский объект копировать клон
    public GameObject ParentObject; 
    // Start is called before the first frame update
    private void Awake()
    {
        //Присваиваем первоначальное значение переменной 
        PositionBeginner = ObjectFromGetWidth.transform.position;
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
        //Получаем количество клонов
        int childCount = ParentObject.transform.childCount;

        Debug.Log(childCount);
        GameObject clone;
        for (int i = 0; i <= childCount; i++) //
        {
            try
            {
                clone = ParentObject.transform.Find(gameObject.name+"(Clone)").gameObject;
                Debug.Log("cloneID: " + clone.GetInstanceID());
                Debug.Log("clone: " + clone);
                Debug.Log("Удаление");
                DestroyImmediate(clone);
                return;
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
