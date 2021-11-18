using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class ButtonBuySubjects : MonoBehaviour
{
    public GameObject PanelFewResources;
    public GameObject ButtonText;
    //public int AllPriceSubjects;
    // Start is called before the first frame update
    public void SetAllPriceSubjectsText(int count)
    {
        ButtonText.GetComponent<Text>().text = count.ToString();
    }
    //Покупка необходимых компонентов
    public void BuyCompositions()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
