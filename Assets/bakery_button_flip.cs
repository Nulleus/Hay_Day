using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakery_button_flip : MonoBehaviour
{
    public GameObject ProductionBuilding;
    // Start is called before the first frame update
    void Start()
    {
        ProductionBuilding = GameObject.Find("bakery");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        if (ProductionBuilding.GetComponent<SpriteRenderer>().flipX)
        {
            ProductionBuilding.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            ProductionBuilding.GetComponent<SpriteRenderer>().flipX = true;
        }
            
    }
}
