using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotInfo : MonoBehaviour
{
    private GameObject SlotInfoMainSubjectName;
    private GameObject SlotInfoSubject0;
    private GameObject SlotInfoSubjectQuantity0;
    private GameObject SlotInfoSubjectImage0;
    private GameObject SlotInfoSubject1;
    private GameObject SlotInfoSubjectQuantity1;
    private GameObject SlotInfoSubjectImage1;
    private GameObject SlotInfoSubject2;
    private GameObject SlotInfoSubjectQuantity2;
    private GameObject SlotInfoSubjectImage2;
    private GameObject SlotInfoSubject3;
    private GameObject SlotInfoSubjectQuantity3;
    private GameObject SlotInfoSubjectImage3;
    private GameObject SlotInfoMainSubjectBuildingTime;
    private GameObject SlotInfoMainSubjectStorageImage;
    private GameObject SlotInfoMainSubjectStorageQuantity;

    // Start is called before the first frame update
    void Start()
    {
        SlotInfoMainSubjectName.transform.Find("SlotInfoMainSubjectName");
        SlotInfoSubject0.transform.Find("SlotInfoSubject0");
        SlotInfoSubjectQuantity0.transform.Find("SlotInfoSubjectQuantity0");
        SlotInfoSubjectImage0.transform.Find("SlotInfoSubjectImage0");
        SlotInfoSubject1.transform.Find("SlotInfoSubject1");
        SlotInfoSubjectQuantity1.transform.Find("SlotInfoSubjectQuantity1");
        SlotInfoSubjectImage1.transform.Find("SlotInfoSubjectImage1");
        SlotInfoSubject2.transform.Find("SlotInfoSubject2");
        SlotInfoSubjectQuantity2.transform.Find("SlotInfoSubjectQuantity2");
        SlotInfoSubjectImage2.transform.Find("SlotInfoSubjectImage2");
        SlotInfoSubject3.transform.Find("SlotInfoSubject3");
        SlotInfoSubjectQuantity3.transform.Find("SlotInfoSubjectQuantity3");
        SlotInfoSubjectImage3.transform.Find("SlotInfoSubjectImage3");
        SlotInfoMainSubjectBuildingTime.transform.Find("SlotInfoMainSubjectBuildingTime");
        SlotInfoMainSubjectStorageImage.transform.Find("SlotInfoMainSubjectStorageImage");
        SlotInfoMainSubjectStorageQuantity.transform.Find("SlotInfoMainSubjectStorageQuantity");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClearComponentText(GameObject go)
    {
        go.GetComponent<Text>().text = "";
    }
    public void ClearComponentAnimator(GameObject go)
    {
        go.GetComponent<Animator>().CrossFade("Empty",0);
    }
    public void ClearAllSlotsInfo()
    {
        ClearComponentText(SlotInfoMainSubjectName);
        ClearComponentText(SlotInfoSubjectQuantity0);
        ClearComponentAnimator(SlotInfoSubjectImage0);
        ClearComponentText(SlotInfoSubjectQuantity1);
        ClearComponentAnimator(SlotInfoSubjectImage1);
        ClearComponentText(SlotInfoSubjectQuantity2);
        ClearComponentAnimator(SlotInfoSubjectImage2);
        ClearComponentText(SlotInfoSubjectQuantity3);
        ClearComponentAnimator(SlotInfoSubjectImage3);
        ClearComponentText(SlotInfoMainSubjectBuildingTime);
        ClearComponentText(SlotInfoMainSubjectStorageImage);
        ClearComponentText(SlotInfoMainSubjectStorageQuantity);
    }
    public void AddMissingIngredientAnimator(GameObject go, string value)
    {
        try
        {
            go.GetComponent<Animator>().CrossFade(value, 0);
        }
        catch
        {
            return;
        }
        finally
        {
            Debug.Log("finaly AddMissingIngredientAnimator");
        }
    }
    public void AddMissingIngredientText(GameObject go, string value)
    {
        if (go.GetComponent<Text>().text == "")
        {
            go.GetComponent<Text>().text = value;
        }
        else
        {
            return;
        }
        
    }
    public void AddMissingIngredient(GameObject go, string value)//Какого предмета нехватает, количество
    {

    }
    public void GetFreeSlots()
    {

    }

}
