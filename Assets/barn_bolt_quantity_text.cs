using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barn_bolt_quantity_text : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GO_barn_bolt_quantity_text;
    void Start()
    {
        GO_barn_bolt_quantity_text = GameObject.Find("barn_bolt_quantity_text");
    }

    // Update is called once per frame
    void Update()
    {
        GO_barn_bolt_quantity_text.GetComponent<Text>().text = globals.bolt.ToString() + "/" + (globals.barn_intcapacity / 25 - 1).ToString();//В амбаре/Необходимо для обновления
    }
}
