using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInfoSubject : MonoBehaviour
{
    [SerializeField]
    private string SubjectName;//Предмет
    [SerializeField]
    private int SubjectCount;//Необходимое количество
    [SerializeField]
    private int StorageSubjectCount;//Количество на складе

    private GameObject SlotInfoSubjectQuantity0;
    private GameObject SlotInfoSubjectImage0;
    private GameObject SlotInfoSubjectQuantity1;
    private GameObject SlotInfoSubjectImage1;
    private GameObject SlotInfoSubjectQuantity2;
    private GameObject SlotInfoSubjectImage2;
    private GameObject SlotInfoSubjectQuantity3;
    private GameObject SlotInfoSubjectImage3;

    void Start()
    {
        SlotInfoSubjectQuantity0.transform.Find("SlotInfoSubjectQuantity0");
        SlotInfoSubjectImage0.transform.Find("SlotInfoSubjectImage0");
        SlotInfoSubjectQuantity1.transform.Find("SlotInfoSubjectQuantity1");
        SlotInfoSubjectImage1.transform.Find("SlotInfoSubjectImage1");
        SlotInfoSubjectQuantity2.transform.Find("SlotInfoSubjectQuantity2");
        SlotInfoSubjectImage2.transform.Find("SlotInfoSubjectImage2");
        SlotInfoSubjectQuantity3.transform.Find("SlotInfoSubjectQuantity3");
        SlotInfoSubjectImage3.transform.Find("SlotInfoSubjectImage3");
    }
    public void ResetValues()//Очистка значений 
    {
        ResetText(SlotInfoSubjectQuantity0);
        ResetAnimation(SlotInfoSubjectImage0);
        ResetText(SlotInfoSubjectQuantity1);
        ResetAnimation(SlotInfoSubjectImage1);
        ResetText(SlotInfoSubjectQuantity2);
        ResetAnimation(SlotInfoSubjectImage2);
        ResetText(SlotInfoSubjectQuantity3);
        ResetAnimation(SlotInfoSubjectImage3);
    }

    public void ResetText(GameObject go)//Очистка текста
    {
        go.GetComponent<Text>().text = "";
    }
    public void ResetAnimation(GameObject go)//Очистка анимации
    {
        go.GetComponent<Animator>().CrossFade("Empty", 0);
    }

    public int GetStorageSubjectCount()//Получение количества предмета на складе
    {
        StorageSubjectCount = GameObject.Find(SubjectName).GetComponent<Subject>().GetCount();
        return StorageSubjectCount;
    }

    public string GetSubjectName()//Получение имени предмета
    {
        return SubjectName;
    }
    public void SetSubjectName(string subjectName)//Присвоение имени предмету
    {
        SubjectName=subjectName;
    }
    public int GetSubjectCount()//Получение количества предмета
    {
        return SubjectCount;
    }
    public void SetSubjectCount(int subjectCount)//Присвоение количества предмета
    {
        SubjectCount = subjectCount;
    }
    public void SetStorageSubjectCount(int storageSubjectCount)//Просвоение количества предмета на складе
    {
        StorageSubjectCount = storageSubjectCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
