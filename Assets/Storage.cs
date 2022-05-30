using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Storage : MonoBehaviour
{
    public int Capacity;//Вместимость хранилища
    public string StorageName; //Имя хранилища
    [ShowInInspector]
    //SubjectName and SumCount in class SubjectSum
    public Dictionary<string, int> ContentStorage = new Dictionary<string, int>();
    //Имя объекта и ссылка на него
    [ShowInInspector]
    public Dictionary<string, GameObject> LinkGameObject = new Dictionary<string, GameObject>();

    private void OnEnable()
    {
        LinkGameObject.Add("wheat", gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int GetCapacity()
    {
        return Capacity;
    }
}
