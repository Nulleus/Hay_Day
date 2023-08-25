using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soybean_quantity_script : MonoBehaviour
{
    public int soybean_quantity;
    public static soybean_quantity_script silo_soybean;
    public Text quantity_silo_soybean_text;
    public Text quantity_field_panel_soybean_text;
    // Start is called before the first frame update
    void Awake()
    {
        if (silo_soybean == null)
        {
            silo_soybean = this;
        }
        else if (silo_soybean != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        soybean_quantity = 12;
    }

    // Update is called once per frame
    void Update()
    {
        soybean_quantity_update();
    }
    public void soybean_quantity_update()
    {
        quantity_silo_soybean_text.text = soybean_quantity.ToString();
        quantity_field_panel_soybean_text.text = soybean_quantity.ToString();
    }
    public void add_quantity_soybean()
    {
        soybean_quantity = soybean_quantity + 2;
    }
    public void reduce_soybean_quantity()
    {
        soybean_quantity = soybean_quantity - 1;
    }

}
