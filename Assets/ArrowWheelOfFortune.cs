using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWheelOfFortune : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject PanelWheelOfFortune;
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation == 0)
        {
            PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation = PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation + 10;
        }
        if ((collision.gameObject.name == "Carnations")&&(PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation!=0))
        {
            Debug.Log("Carnations=" + collision.gameObject.name);
            Arrow.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
