using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class ButtonBuySubjects : MonoBehaviour
{
    public GameObject PanelFewResources;
    public GameObject ButtonText;
    public string ButtonActionSelectionName;
    //public int AllPriceSubjects;
    // Start is called before the first frame update
    public void SetAllPriceSubjectsText(int count)
    {
        ButtonText.GetComponent<Text>().text = count.ToString();
    }

    void Start()
    {
        
    }
    public void OnMouseUp()
    {
        PanelFewResources.GetComponent<PanelFewResources>().SetUserActionSelection(ButtonActionSelectionName);
        //Выбор пользователя был сделан
        Debug.Log("Выбор пользователя: " + ButtonActionSelectionName);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
