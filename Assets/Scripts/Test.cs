using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    public GameObject TargetPoint;


    private void Start()
    {

    }

    private void Update()
    {
        gameObject.transform.position = TargetPoint.transform.position;
    }

    private void OnEnable()
    {

    }

    // Start is called before the first frame update

}
