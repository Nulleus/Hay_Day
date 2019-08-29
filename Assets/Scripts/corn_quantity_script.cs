using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class corn_quantity_script : MonoBehaviour
{
    public int corn_quantity;
    public static corn_quantity_script silo_corn;
    public Text quantity_corn_silo_text;
    public Text quantity_field_panel_corn_text;
    // Start is called before the first frame update
    void Awake()
    {
        if (silo_corn == null)
        {
            silo_corn = this;
        }
        else if (silo_corn != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        corn_quantity = 10;
    }

    // Update is called once per frame
    void Update()
    {
        corn_quantity_update();
    }
    public void corn_quantity_update()
    {
        quantity_corn_silo_text.text = corn_quantity.ToString();
        quantity_field_panel_corn_text.text = corn_quantity.ToString();
    }
    public void add_quantity_corn()
    {
        corn_quantity = corn_quantity + 2;
    }
    public void reduce_corn_quantity()
    {
        corn_quantity = corn_quantity - 1;
    }
}
