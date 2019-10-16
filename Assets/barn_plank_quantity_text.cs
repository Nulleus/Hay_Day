using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barn_plank_quantity_text : MonoBehaviour
{
    public GameObject GO_barn_plank_quantity_text;
    // Start is called before the first frame update
    void Start()
    {
        GO_barn_plank_quantity_text = GameObject.Find("barn_plank_quantity_text");
    }

    // Update is called once per frame
    void Update()
    {
        GO_barn_plank_quantity_text.GetComponent<Text>().text = globals.plank.ToString() + "/" + (globals.barn_intcapacity / 25 - 1).ToString();//В амбаре/Необходимо для обновления
    }
}
