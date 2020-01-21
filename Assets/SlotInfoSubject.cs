using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInfoSubject : MonoBehaviour
{
    [SerializeField]
    private string SubjectName;//Предмет
    [SerializeField]
    private int SubjectCount;//Необходимое количество

    public string GetSubjectName()
    {
        return SubjectName;
    }
    public void SetSubjectName(string subjectName)
    {
        SubjectName=subjectName;
    }
    public int GetSubjectCount()
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
