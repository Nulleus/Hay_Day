using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInfoSubject : MonoBehaviour
{
    [SerializeField]
    private string SubjectName;//Предмет
    [SerializeField]
    private int SubjectCount;//Необходимое количество
    [SerializeField]
    private int StorageSubjectCount;//Количество на складе

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
    public void SetSubjectCount(int subjectCount)
    {
        SubjectCount = subjectCount;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
