using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin_quantity : MonoBehaviour
{
    public GameObject GO_coin_quantity;
        // Start is called before the first frame update
    void Start()
    {
        GO_coin_quantity = GameObject.Find("coin_quantity");
    }

    // Update is called once per frame
    void Update()
    {
        GO_coin_quantity.GetComponent<Text>().text = globals.coin.ToString();
    }
}
