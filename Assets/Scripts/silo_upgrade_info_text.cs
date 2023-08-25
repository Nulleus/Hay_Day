using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class silo_upgrade_info_text : MonoBehaviour
{
    public GameObject GO_silo_upgrade_info_text;
    // Start is called before the first frame update
    void Start()
    {
        GO_silo_upgrade_info_text = GameObject.Find("silo_upgrade_info_text");
    }

    // Update is called once per frame
    void Update()
    {
        GO_silo_upgrade_info_text.GetComponent<Text>().text = "Увеличить вместимость до " + (globals.silo_intcapacity + 25);
    }
}
