using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakery_button_flip : MonoBehaviour
{
    public GameObject j1_bakery;
    // Start is called before the first frame update
    void Start()
    {
        j1_bakery = GameObject.Find("j1_bakery");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        if (j1_bakery.GetComponent<SpriteRenderer>().flipX)
        {
            j1_bakery.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            j1_bakery.GetComponent<SpriteRenderer>().flipX = true;
        }
            
    }
}
