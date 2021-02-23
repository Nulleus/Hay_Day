using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInfoSubjectQuantity : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetQuantity()
    {
        gameObject.GetComponent<Text>().text =
        gameObject.transform.Find("SlotInfoSubject").GetComponent<SlotInfoSubject>().GetSubjectCount().ToString()
        +"/"
        + gameObject.transform.Find("SlotInfoSubject").GetComponent<SlotInfoSubject>().GetStorageSubjectCount().ToString()
        ;
    }
}
