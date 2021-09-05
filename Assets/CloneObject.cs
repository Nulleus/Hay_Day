using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneObject : MonoBehaviour
{
    public GameObject ObjectFromGetWidth;
    // Start is called before the first frame update
    void Start()
    {
        //TestClone();
    }

    // Update is called once per frame
    void TestClone()
    {
        Instantiate(gameObject, new Vector3(gameObject.transform.position.x + ObjectFromGetWidth.GetComponent<RectTransform>().localPosition.x
        , 0, 0), Quaternion.identity);
    }
}
