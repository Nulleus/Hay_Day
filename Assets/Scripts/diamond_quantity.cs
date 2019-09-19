using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class diamond_quantity : MonoBehaviour
{
    public GameObject GO_diamond_quantity;
    // Start is called before the first frame update
    void Start()
    {
        globals.diamond = 888888;
        GO_diamond_quantity = GameObject.Find("diamond_quantity");
    }

    // Update is called once per frame
    void Update()
    {
        GO_diamond_quantity.GetComponent<Text>().text = globals.diamond.ToString();
    }
}
