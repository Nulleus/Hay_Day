using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class j1_bakery : MonoBehaviour
{
    public int count=0;
    public bool count_on = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count_on)
        {
            count++;
            if (count > 25)
            {
                globals.bakery_move_mode_on = true;
                //gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
    void OnMouseDown()
    {
        Debug.Log(globals.bakery_move_mode_on);
        count = 0;
        count_on = true;
    }
    void OnMouseUp()
    {
        count = 0;
        count_on = false;
    }
    void OnMouseEnter()
    {
        
    }
}
