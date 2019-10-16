using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barn_duct_tape_quantity_text : MonoBehaviour
{
    public GameObject GO_barn_duct_tape_quantity_text;
    // Start is called before the first frame update
    void Start()
    {
        GO_barn_duct_tape_quantity_text = GameObject.Find("barn_duct_tape_quantity_text");
    }

    // Update is called once per frame
    void Update()
    {
        GO_barn_duct_tape_quantity_text.GetComponent<Text>().text = globals.duct_tape.ToString() + "/" + (globals.barn_intcapacity / 25 - 1).ToString();//В амбаре/Необходимо для обновления
    }
}
