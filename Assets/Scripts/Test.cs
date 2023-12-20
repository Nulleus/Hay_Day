using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    public Vector3 cam;
    public Vector3 cameraRelative;
    private void Start()
    {

    }

    private void Update()
    {
        cam = gameObject.transform.position;
        cameraRelative = gameObject.transform.localPosition;
        
    }

    private void OnEnable()
    {

    }

    // Start is called before the first frame update

}
