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

    // Add an impulse which produces a change in angular velocity (specified in degrees).
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void AddTorqueImpulse(float angularChangeInDegrees)
    {
        //var body = GetComponent<Rigidbody2D>();
        //var impulse = (angularChangeInDegrees * Mathf.Deg2Rad) * body.inertia;
        //body.MoveRotation(100);
        //body.AddTorque(impulse, ForceMode2D.Impulse);
    }
    private void Start()
    {

    }

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        AddTorqueImpulse(100);
    }

    private void OnEnable()
    {

    }

    // Start is called before the first frame update

}
