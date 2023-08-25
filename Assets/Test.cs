using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    public bool isBlue;
    private void Start()
    {
        
    }

    private void Update()
    {
        // Check if there is a touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Check if finger is over a UI element
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Debug.Log("Touched the UI");
            }
            else
            {
                isBlue = !isBlue;
                if (isBlue)
                {
                    GetComponent<Renderer>().material.color = Color.blue;
                }
                else
                {
                    GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }

        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse was clicked over a UI element
            if (EventSystem.current.IsPointerOverGameObject())
            {
                Debug.Log("Clicked on the UI");
            }
            else
            {
                isBlue = !isBlue;
                if (isBlue)
                {
                    GetComponent<Renderer>().material.color = Color.blue;
                }
                else
                {
                    GetComponent<Renderer>().material.color = Color.white;
                }
            }
        }
    }

    // Start is called before the first frame update

}
