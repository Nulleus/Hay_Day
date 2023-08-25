using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInfo : MonoBehaviour
{
    private GameObject SlotInfoMainSubjectName;

    private GameObject SlotInfoSubject0;
    private GameObject SlotInfoSubject1;
    private GameObject SlotInfoSubject2;
    private GameObject SlotInfoSubject3;

    private GameObject SlotInfoMainSubjectBuildingTime;
    private GameObject SlotInfoMainSubjectStorageImage;
    private GameObject SlotInfoMainSubjectStorageQuantity;

    /*
    void Start()
    {
        SlotInfoMainSubjectName.transform.Find("SlotInfoMainSubjectName");//Поиск дочернего элемента

        SlotInfoSubject0.transform.Find("SlotInfoSubject0");
        SlotInfoSubject1.transform.Find("SlotInfoSubject1");
        SlotInfoSubject2.transform.Find("SlotInfoSubject2");
        SlotInfoSubject3.transform.Find("SlotInfoSubject3");

        SlotInfoMainSubjectBuildingTime.transform.Find("SlotInfoMainSubjectBuildingTime");
        SlotInfoMainSubjectStorageImage.transform.Find("SlotInfoMainSubjectStorageImage");
        SlotInfoMainSubjectStorageQuantity.transform.Find("SlotInfoMainSubjectStorageQuantity");
    }
    public void AddValuesInSlots()
    {

    }

    public void ResetText(GameObject go)//Очистка текста у игрового объекта
    {
        go.GetComponent<Text>().text = "";
    }
    public void ResetAnimation(GameObject go)//Запуск пустой анимации
    {
        go.GetComponent<Animator>().CrossFade("Empty",0);
    }
    public void ResetAllSlotsInfo()//Очистка слотов информации
    {
        ResetText(SlotInfoMainSubjectName);
        ResetText(SlotInfoMainSubjectBuildingTime);
        ResetText(SlotInfoMainSubjectStorageImage);
        ResetText(SlotInfoMainSubjectStorageQuantity);
        SlotInfoSubject0.GetComponent<SlotInfoSubject>().ResetValues();
        SlotInfoSubject1.GetComponent<SlotInfoSubject>().ResetValues();
        SlotInfoSubject2.GetComponent<SlotInfoSubject>().ResetValues();
        SlotInfoSubject3.GetComponent<SlotInfoSubject>().ResetValues();
    }
    public void AddMissingIngredientAnimator(GameObject go, string value)//Анимация слота с ингредиентом, которого нехватает
    {
        try
        {
            go.GetComponent<Animator>().CrossFade(value, 0);
        }
        catch
        {
            return;
        }
        finally
        {
            Debug.Log("finaly AddMissingIngredientAnimator");
        }
    }
    public void AddMissingIngredientText(GameObject go, string value)//Добавление текста, выбранному объекту и значение текста
    {
        if (go.GetComponent<Text>().text == "")
        {
            go.GetComponent<Text>().text = value;
        }
        else
        {
            return;
        }
        
    }
    public void AddMissingIngredient(GameObject go,string subject, int value)//Какого предмета нехватает, количество
    {
        go.GetComponent<SlotInfoSubject>().SetSubjectName(subject);
        go.GetComponent<SlotInfoSubject>().SetSubjectCount(value);
    }
    public GameObject GetFreeSlot()//Получение свободного слота
    {
        //Сканирование свободности слотов по имени
        if (SlotInfoSubject0.GetComponent<SlotInfoSubject>().GetSubjectName() == ""){return SlotInfoSubject0;}
        if (SlotInfoSubject1.GetComponent<SlotInfoSubject>().GetSubjectName() == "") { return SlotInfoSubject1; }
        if (SlotInfoSubject2.GetComponent<SlotInfoSubject>().GetSubjectName() == "") { return SlotInfoSubject2; }
        if (SlotInfoSubject3.GetComponent<SlotInfoSubject>().GetSubjectName() == "") { return SlotInfoSubject3; }
        return null;
    }
    public void AddIngredientsByNameSubject(string subject)//Добавление информации об ингредиентах в SlotInfo по имени объекта
    {
        var ingredients = GameObject.Find(subject).GetComponent<Ingredients>().GetSubjects();
        //Очищаем все слоты, перед добавлением новой информации
        ResetAllSlotsInfo();
        //Получаем свободный SlotSubjectN
        var freeSlot = GetFreeSlot();
        //Проходимся циклом по ингредиентам и их необходимому количеству
        foreach (KeyValuePair<string, int> kvp in ingredients)
        {
            int storageCount = freeSlot.GetComponent<SlotInfoSubject>().GetStorageSubjectCount();
            freeSlot.GetComponent<SlotInfoSubject>().AddValueInSlot(freeSlot, kvp.Key,storageCount, kvp.Value);
            Debug.Log(kvp.Key);//Имя предмета
            Debug.Log(kvp.Value);//Количество
        }
        //Имя предмета, который можно изготовить
        SlotInfoMainSubjectName.GetComponent<Text>().text = subject;
        //Поиск времени изготовления предмета по имени      
        SlotInfoMainSubjectBuildingTime.GetComponent<Text>().text = GameObject.Find(subject).GetComponent<Subject>().GetBuildingTimeSec().ToString()+" c.";
        //Получение имени хранилища, для данного объекта
        string storageName = GameObject.Find(subject).GetComponent<Subject>().GetStorageName()+"_4";
        //Картинка хранилища для конкретного объекта
        SlotInfoMainSubjectStorageImage.GetComponent<Animator>().CrossFade(storageName, 0);
        //Количество конкретного объекта на складе
        SlotInfoMainSubjectStorageQuantity.GetComponent<Text>().text = GameObject.Find(subject).GetComponent<Subject>().GetCount().ToString();

    }
    
    */
}
