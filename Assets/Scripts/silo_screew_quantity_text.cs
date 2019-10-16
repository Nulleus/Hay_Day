using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class silo_screew_quantity_text : MonoBehaviour
{
    public GameObject GO_silo_screew_quantity_text;
    // Start is called before the first frame update
    void Start()
    {
        globals.screew = 100;//Шурупов на складе при загрузке
        GO_silo_screew_quantity_text = GameObject.Find("silo_screew_quantity_text");
    }

    // Update is called once per frame
    void Update()
    {
        GO_silo_screew_quantity_text.GetComponent<Text>().text = globals.screew.ToString()+"/"+(globals.silo_intcapacity/25-1).ToString();//В силосной башни/Необходимо для обновления
    }
}
