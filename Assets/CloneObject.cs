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
        Instantiate(ObjectFromGetWidth, new Vector3((ObjectFromGetWidth.transform.position.x + (ObjectFromGetWidth.GetComponent<RectTransform>().localPosition.x+offsetX))
        , ObjectFromGetWidth.transform.position.y, ObjectFromGetWidth.transform.position.z), Quaternion.identity, ParentObject.transform);
    }
}
