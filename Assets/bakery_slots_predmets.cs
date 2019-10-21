using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakery_slots_predmets : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (globals.bakery_slots_predmets_visible) { gameObject.SetActive(true); }
        else { gameObject.SetActive(false); }
    }
}
