using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class silo_nail_quantity_text : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GO_silo_nail_quantity_text;
    void Start()
    {
        globals.nail = 100;
        GO_silo_nail_quantity_text = GameObject.Find("silo_nail_quantity_text");
    }

    // Update is called once per frame
    void Update()
    {
        GO_silo_nail_quantity_text.GetComponent<Text>().text = globals.nail.ToString() + "/" + (globals.silo_intcapacity / 25 - 1).ToString();//В амбаре/Необходимо для обновления
    }
}
