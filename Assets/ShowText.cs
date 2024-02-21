using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class ShowText : MonoBehaviour
{
    //Объект, на который будет выведена информация
    public GameObject ShowTarget;
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    void SetValueText(string value)
    {
        if (ShowTarget.GetComponent<Text>() != null)
        {
            ShowTarget.GetComponent<Text>().text = value;
        }
    }

    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    void SetValueTextPro(string value)
    {
        if (ShowTarget.GetComponent<TMPro.TextMeshProUGUI>() != null)
        {
            ShowTarget.GetComponent<TMPro.TextMeshProUGUI>().text = value;
        }
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    void Show(string value)
    {
        SetValueTextPro(value);
        SetValueText(value);
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
