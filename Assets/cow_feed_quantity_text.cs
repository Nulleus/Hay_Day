using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cow_feed_quantity_text : MonoBehaviour
{
    public GameObject GO_cow_feed_quantity_text;
    // Start is called before the first frame update
    void Start()
    {
        GO_cow_feed_quantity_text = GameObject.Find("cow_feed_quantity_text");
    }

    // Update is called once per frame
    void Update()
    {
        GO_cow_feed_quantity_text.GetComponent<Text>().text = globals.cow_feed.ToString();
    }
}
