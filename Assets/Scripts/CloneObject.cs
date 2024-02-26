using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CloneObject : MonoBehaviour
{
    public GameObject ObjectFromGetWidth; //Объект, с которого нужно сделать клон
    public GameObject ParentObject; //Родительский объект
    

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {

    }
    private void OnEnable()
    {

    }

    // Update is called once per frame
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void Clone(string subjectName, int subjectCount)
    {
        GameObject clone = Instantiate(ObjectFromGetWidth, ParentObject.transform);
        //Добавим клону свойства 
        clone.SetActive(true);
        clone.GetComponent<PanelSlot>().SetSubjectName(subjectName);
        Debug.Log("subjectName="+subjectName);
        clone.GetComponent<PanelSlot>().SetSprite(subjectName);
        clone.GetComponent<PanelSlot>().InfoPanel.SetActive(false);
        clone.GetComponent<PanelSlot>().InfoPanel.GetComponent<InfoPanel>().SubjectName = subjectName;
        clone.GetComponent<PanelSlot>().SetQuantity(subjectCount);
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void DeleteClones() //Удаление клонов
    {
        int childCount = ParentObject.transform.childCount;       
        Debug.Log(childCount);
        GameObject clone;
        for (int i = 0; i <= childCount; i++) //
        {
            try
            {
                clone = ParentObject.transform.Find("PanelSlot(Clone)").gameObject;
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