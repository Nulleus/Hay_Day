using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWheelOfFortune : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject PanelWheelOfFortune;
    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().StopSpin)
        {
            //градус стрелки в зависимости от скорости колеса
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
            //Ќе откидывать стрелку, если скорость маленька€
            //“ут происходит добавление скорости дл€ подкрутки колеса
            if (PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation < 200)
            {
                if(collision.gameObject.name == "SubjectSpin")
                {
                    //ѕоследний объект столкнувшийс€ со стрелкой
                    PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SetLastSubjectArrowEncountered(collision.gameObject.GetComponent<SubjectSpin>().SubjectName);
                    if (collision.gameObject.GetComponent<SubjectSpin>().SubjectName == PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().WinningPositionSubjectName)
                    {
                        Debug.Log("You Win!");
                        string winningPositionSubjectName = PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().WinningPositionSubjectName;
                        PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().ButtonPrize.SetActive(true);
                        PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().ButtonPrize.GetComponent<SpriteController>().SetSprite(winningPositionSubjectName);
                        //PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().GetPrizeSpin();
                        //PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().LinesSpin.GetComponent<FollowPath>().SubjectName = winningPositionSubjectName;
                        Arrow.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                        PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().StopSpin = true;
                        PanelWheelOfFortune.GetComponent<PanelWheelOfFortune>().SpeedRotation = 0;
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
