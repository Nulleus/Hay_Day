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
        TestClone();
        TestClone();
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
        
        int childCount = gameObject.transform.childCount;
        Debug.Log(childCount);
        GameObject clone;
        for (int i = 0; i <= childCount; i++) //
        {
            Debug.Log(i);
            clone = null;
            clone = gameObject.transform.Find("PanelSlot(Clone)").gameObject;
            Debug.Log("cloneID: "+clone.GetInstanceID());
            Debug.Log("clone: " + clone);
            if (clone == null)
            {
                Debug.Log("Он равен нулю");
            }
            //if ((clone)!=null)
            else
            {
                Debug.Log("Удаление");
                
                Destroy(clone);
                clone = null;
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