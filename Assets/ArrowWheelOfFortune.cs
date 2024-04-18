using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWheelOfFortune : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject PanelWheelOfFortune;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.name == "SubjectSpin") && (collision.gameObject.GetComponent<SubjectSpin>().SubjectName != PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().WinningPositionSubjectName))
        {
            PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation = PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation + 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().StopSpin)
        {
            //������ ������� � ����������� �� �������� ������
            if ((collision.gameObject.name == "NailSpin") && (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation != 0))
            {
                Debug.Log("NailSpin=" + collision.gameObject.name);
                if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation > 100)
                {
                    if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().ClockwiseRotation)
                    {
                        Arrow.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
                    }
                    if (!PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().ClockwiseRotation)
                    {
                        Arrow.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                }
                if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation < 100)
                {
                    if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().ClockwiseRotation)
                    {
                        Arrow.gameObject.transform.rotation = Quaternion.Euler(0, 0, -53);
                    }
                    if (!PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().ClockwiseRotation)
                    {
                        Arrow.gameObject.transform.rotation = Quaternion.Euler(0, 0, 53);
                    }
                }


            }
            //if ((PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation == 0)&&(Arrow.gameObject.transform.rotation.z>50))
            //�� ���������� �������, ���� �������� ���������
            //��� ���������� ���������� �������� ��� ��������� ������
            if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation < 120)
            {
                if ((collision.gameObject.name == "SubjectSpin") && (collision.gameObject.GetComponent<SubjectSpin>().SubjectName == PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().WinningPositionSubjectName))
                {
                    Debug.Log("You Win!");
                    Arrow.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().StopSpin = true;
                    //PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation = 0;
                    //PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation = 0;
                    return;
                }

                if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().ClockwiseRotation)
                {
                    //����� �������� �� ���� �������������
                    if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation - 30 > 0)
                    {
                        PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation = PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation - 30;
                    }

                }
                if (!PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().ClockwiseRotation)
                {
                    PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation = PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation + 30;
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
