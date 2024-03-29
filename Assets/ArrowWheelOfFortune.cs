using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWheelOfFortune : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject PanelWheelOfFortune;
    public bool StopSpin;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!StopSpin)
        {
            //if ((PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation == 0)&&(Arrow.gameObject.transform.rotation.z>50))
            //Не откидывать стрелку, если скорость маленькая
            //Тут происходит добавление скорости для подкрутки колеса
            if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation < 50)
            {
                if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().ClockwiseRotation)
                {
                    PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation = PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation - 30;
                }
                PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation = PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation + 30;
            }
            //градус стрелки в зависимости от скорости колеса
            if ((collision.gameObject.name == "Carnations") && (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation != 0))
            {
                Debug.Log("Carnations=" + collision.gameObject.name);
                if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation > 100)
                {
                    if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().ClockwiseRotation)
                    {
                        Arrow.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
                    }
                    else
                    {
                        Arrow.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                }
                if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation < 100)
                {
                    if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation < 67)
                    {
                        return;
                    }
                    if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().ClockwiseRotation)
                    {
                        Arrow.gameObject.transform.rotation = Quaternion.Euler(0, 0, -53);
                    }
                    else
                    {
                        Arrow.gameObject.transform.rotation = Quaternion.Euler(0, 0, 53);
                    }
                }


            }
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
