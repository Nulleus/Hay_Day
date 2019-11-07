using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakery_button_flip : MonoBehaviour
{
    public GameObject bakery;
    // Start is called before the first frame update
    void Start()
    {
        bakery = GameObject.Find("bakery");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        if (bakery.GetComponent<SpriteRenderer>().flipX)
        {
            bakery.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            bakery.GetComponent<SpriteRenderer>().flipX = true;
        }
            
    }
}
