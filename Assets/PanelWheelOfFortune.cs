using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PanelWheelOfFortune : MonoBehaviour
{
    public GameObject ObjectOfRotation;
    public int SpeedRotation;
    //Вращать по часовой стрелке
    public bool ClockwiseRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (SpeedRotation > 0)
        {
            if (ClockwiseRotation)
            {
                ObjectOfRotation.gameObject.transform.Rotate(0, 0, SpeedRotation * Time.deltaTime);
            }
            else
            {
                ObjectOfRotation.gameObject.transform.Rotate(0, 0, -SpeedRotation * Time.deltaTime);
            }
            
            SpeedRotation = SpeedRotation - 1;
        } 
    }
}
