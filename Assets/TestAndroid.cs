using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TestAndroid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = Application.persistentDataPath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
