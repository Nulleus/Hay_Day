using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barn_upgrade_info_text : MonoBehaviour
{
    public GameObject GO_barn_upgrade_info_text;
    // Start is called before the first frame update
    void Start()
    {
        GO_barn_upgrade_info_text = GameObject.Find("barn_upgrade_info_text");
    }

    // Update is called once per frame
    void Update()
    {
        GO_barn_upgrade_info_text.GetComponent<Text>().text = "Увеличить вместимость до " + (globals.barn_intcapacity + 25);
    }
}
