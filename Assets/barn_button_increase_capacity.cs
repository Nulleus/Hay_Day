using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barn_button_increase_capacity : MonoBehaviour
{
    public GameObject barn_global;
    public GameObject barn_upgrade;
    public GameObject barn_button_increase_capacity_text;

    // Start is called before the first frame update
    void Start()
    {
        barn_global = GameObject.Find("barn_global");
        barn_upgrade = GameObject.Find("barn_upgrade");

        barn_button_increase_capacity_text = GameObject.Find("barn_button_increase_capacity_text");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseUp()
    {
        if (barn_global.activeSelf)
        {
            barn_button_increase_capacity_text.GetComponent<Text>().text = "Назад";
            barn_upgrade.SetActive(true);
            barn_global.SetActive(false);

        }
        else
        {
            barn_button_increase_capacity_text.GetComponent<Text>().text = "Увеличить вместимость";
            barn_global.SetActive(true);
            barn_upgrade.SetActive(false);
        }
    }
}
