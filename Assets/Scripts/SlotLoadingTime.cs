using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class SlotLoadingTime : MonoBehaviour
{
    public GameObject ProductionBuildingParent;
    public string SecondsToText;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnEnable() 
    {

    }
    // Update is called once per frame
    void Update()
    {
        var seconds = ProductionBuildingParent.GetComponent<ProductionBuilding>().TimeBeforeStartRequest;
        //Debug.Log("seconds="+seconds);
        if (seconds-2 <= 0)
        {
            //Debug.Log("seconds<" + seconds);
            gameObject.GetComponent<Text>().text = "";
        }
        if (seconds-2 > 0)
        {
            //Debug.Log("seconds>" + seconds);
            SecondsToText = Format(seconds - 2);
            gameObject.GetComponent<Text>().text = SecondsToText;
        }

        //�������� ���������� ������

        //��������� �� ������ � �������
    }
    string Format(float seconds)
    {
        TimeSpan t = TimeSpan.FromSeconds(seconds);

        string answer = string.Format("{0:D2}�. {1:D2}�. {2:D2}�.",
                        t.Hours,
                        t.Minutes,
                        t.Seconds
                        );
        if (t.Hours == 0)
        {
            answer = string.Format("{0:D2}�. {1:D2}�.",
                            t.Minutes,
                            t.Seconds
                            );
        }
        if (t.Minutes == 0)
        {
            answer = string.Format("{0:D2}�.",
                            t.Seconds
                            );
        }
        return answer;
        //�������� ���������� ����� ��� ����������

        //�������� ���������� ������
    }
}
