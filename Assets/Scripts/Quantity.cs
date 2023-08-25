using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quantity : MonoBehaviour
{
    public GameObject Source;

    // Start is called before the first frame update
    public int GetQuantity()
    {
        return Source.GetComponent<PanelSlot>().GetQuantity();
    }
    void SetQuantityText()
    {
        gameObject.GetComponent<Text>().text = GetQuantity().ToString();
    }
    void Start()
    {
        SetQuantityText();
    }


}
