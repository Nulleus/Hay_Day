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
    //Стрелка барабана
    public GameObject Arrow;
    public int ArrowRotation; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Arrow.gameObject.transform.rotation.z <= 90) && (Arrow.gameObject.transform.rotation.z >= 0))
        {
            Arrow.gameObject.transform.Rotate(0, 0, -1);
            //ArrowRotation = ArrowRotation - 1;           
        }


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
