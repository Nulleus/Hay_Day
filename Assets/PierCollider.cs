using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision.gameObject.name=" + collision.gameObject.name);
        if (collision.gameObject.name == "Steamship")
        {

            collision.gameObject.GetComponent<FollowPath>().CheckStop = true;
        }
    }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
