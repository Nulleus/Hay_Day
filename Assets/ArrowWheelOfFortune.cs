using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWheelOfFortune : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject PanelWheelOfFortune;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().IsStopSpin)
        {
            //градус стрелки в зависимости от скорости колеса
            if ((collision.name == "NailSpin") && (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().WheelRotationSpeed != 0))
            {
                //Debug.Log("NailSpin=" + collision.gameObject.name);
                if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().WheelRotationSpeed > 100)
                {
                    if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().IsClockwiseRotation)
                    {
                        Arrow.transform.rotation = Quaternion.Euler(0, 0, -90);
                    }
                    if (!PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().IsClockwiseRotation)
                    {
                        Arrow.transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                }
                if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().WheelRotationSpeed < 100)
                {
                    if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().IsClockwiseRotation)
                    {
                        Arrow.transform.rotation = Quaternion.Euler(0, 0, -53);
                    }
                    if (!PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().IsClockwiseRotation)
                    {
                        Arrow.transform.rotation = Quaternion.Euler(0, 0, 53);
                    }
                }
            }
            //Не откидывать стрелку, если скорость маленькая
            //Тут происходит добавление скорости для подкрутки колеса
            if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().WheelRotationSpeed < 200)
            {
                if(collision.name == "SubjectSpin")
                {
                    //Последний объект столкнувшийся со стрелкой
                    PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().LastSubjectArrowEncountered = collision.GetComponent<SubjectSpin>().SubjectName;
                    if (collision.GetComponent<SubjectSpin>().SubjectName == PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().WinningPositionSubjectName)
                    {
                        //Выигрыш
                        Arrow.transform.rotation = Quaternion.Euler(0, 0, 0);
                        PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().WinningPosition();
                        return;
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
