﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slots_predmets_bakery : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (globals.bakery_visible) { gameObject.SetActive(true); }
        else { gameObject.SetActive(false); }
    }
}