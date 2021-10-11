using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneObject : MonoBehaviour
{
    public GameObject ObjectFromGetWidth;
    public GameObject ParentObject;
    public int offsetX;
    // Start is called before the first frame update
    void Start()
    {
        TestClone();
    }

    // Update is called once per frame
    void TestClone()
    {
        Instantiate(ObjectFromGetWidth, new Vector3((ObjectFromGetWidth.transform.position.x + (ObjectFromGetWidth.GetComponent<RectTransform>().localPosition.x + offsetX))
        , ObjectFromGetWidth.transform.position.y, ObjectFromGetWidth.transform.position.z), Quaternion.identity, ParentObject.transform);
    }
    public void DeleteClones() //Удаление клонов
    {
        //Переписать метод, он не годится, так как при отключении скрипта, работает ли?
        Debug.Log(gameObject.transform.childCount);
        
        for (int i = 0; i <= gameObject.transform.childCount; i++) //
        {
            Debug.Log(gameObject.transform.Find("PanelSlot(Clone)"));
            if (gameObject.transform.Find("PanelSlot(Clone)") == null)
            {
                Debug.Log("Он равен нулю");
            }
            if (gameObject.transform.Find("PanelSlot(Clone)")!=null)
            {
                GameObject clone = gameObject.transform.Find("PanelSlot(Clone)").gameObject;
                Destroy(clone);
            }

        }
        //Удалять, пока поиск не равен null
        //while (gameObject.transform.Find("PanelSlot(Clone)") != null) 
        //{
        //GameObject clone = gameObject.transform.Find("PanelSlot(Clone)").gameObject;
        //if (clone != null)
        //{//
        //Debug.Log(gameObject.transform.Find("PanelSlot(Clone)"));
        //Destroy(clone);
        // }
        //else
        //{
        //break;
        //}

        //}
    }
    void OnDisable()
    {
        DeleteClones();
    }
}