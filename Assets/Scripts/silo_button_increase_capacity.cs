using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class silo_button_increase_capacity : MonoBehaviour
{
    public GameObject silo_global;
    public GameObject silo_upgrade;
    public GameObject silo_button_increase_capacity_text;

    // Start is called before the first frame update
    void Start()
    {
        silo_global = GameObject.Find("silo_global");
        silo_upgrade = GameObject.Find("silo_upgrade");

        silo_button_increase_capacity_text = GameObject.Find("silo_button_increase_capacity_text");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()
    {
        if (silo_global.activeSelf)
        {
            silo_button_increase_capacity_text.GetComponent<Text>().text = "Назад";
            silo_upgrade.SetActive(true);
            silo_global.SetActive(false);

        }
        else
        {
            silo_button_increase_capacity_text.GetComponent<Text>().text = "Увеличить вместимость";
            silo_global.SetActive(true);
            silo_upgrade.SetActive(false);
        }
    }
}
