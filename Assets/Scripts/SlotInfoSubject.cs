using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInfoSubject : MonoBehaviour
{
    public GameObject Data;
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
        ClearSprite(SlotInfoSubjectImage0);
        ResetText(SlotInfoSubjectQuantity1);
        ClearSprite(SlotInfoSubjectImage1);
        ResetText(SlotInfoSubjectQuantity2);
        ClearSprite(SlotInfoSubjectImage2);
        ResetText(SlotInfoSubjectQuantity3);
        ClearSprite(SlotInfoSubjectImage3);
    }

    public void ResetText(GameObject go)//Очистка текста
    {
        go.GetComponent<Text>().text = "";
    }
    public void ClearSprite(GameObject go)//Очистка спрайта
    {
        if (go.GetComponent<SpriteRenderer>() != null && Data.GetComponent<ImageStorage>() != null)
        {
            go.GetComponent<SpriteRenderer>().sprite = Data.GetComponent<ImageStorage>().GetSprite("empty");
        }
        if (go.GetComponent<Image>() != null && Data.GetComponent<ImageStorage>() != null)
        {
            go.GetComponent<Image>().sprite = Data.GetComponent<ImageStorage>().GetSprite("empty");
        }
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
    public void SetSubjectName(string subjectName)//Присвоение имени предмету и вывод 
    {
        SubjectName =subjectName;   
    }
    //Пустой слот, имя объекта, количество на складе, количество необходимое для производства.
    public void AddValueInSlot(GameObject GO,string subjectName, int storageSubjectCount, int subjectCount )
    {
        SetSubjectName(subjectName);
        SetStorageSubjectCount(storageSubjectCount);
        SetSubjectCount(subjectCount);
        if (GO.name == "SlotInfoSubject0")
        {
            SlotInfoSubjectImage0.GetComponent<Animator>().CrossFade(SubjectName, 0);
            SlotInfoSubjectQuantity0.GetComponent<Text>().text =
                StorageSubjectCount.ToString() + 
                "/"+
                SubjectCount.ToString();
        }
        if (GO.name == "SlotInfoSubject1")
        {
            SlotInfoSubjectImage1.GetComponent<Animator>().CrossFade(SubjectName, 0);
            SlotInfoSubjectQuantity1.GetComponent<Text>().text =
                StorageSubjectCount.ToString() +
                "/" +
                SubjectCount.ToString();
        }
        if (GO.name == "SlotInfoSubject2")
        {
            SlotInfoSubjectImage2.GetComponent<Animator>().CrossFade(SubjectName, 0);
            SlotInfoSubjectQuantity2.GetComponent<Text>().text =
                StorageSubjectCount.ToString() +
                "/" +
                SubjectCount.ToString();
        }
        if (GO.name == "SlotInfoSubject3")
        {
            SlotInfoSubjectImage3.GetComponent<Animator>().CrossFade(SubjectName, 0);
            SlotInfoSubjectQuantity3.GetComponent<Text>().text =
                StorageSubjectCount.ToString() +
                "/" +
                SubjectCount.ToString();
        }


    }
    public int GetSubjectCount()//Получение количества предмета
    {
        return SubjectCount;
    }
    public void SetSubjectCount(int subjectCount)//Присвоение значения, необходимого для производства
    {
        SubjectCount = subjectCount;
    }
    public void SetStorageSubjectCount(int storageSubjectCount)//Присвоение количества предмета на складе
    {
        StorageSubjectCount = storageSubjectCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
