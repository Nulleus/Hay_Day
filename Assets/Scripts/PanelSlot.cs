using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PanelSlot : MonoBehaviour
{
    public GameObject Data;
    public GameObject InfoPanel;
    //public Animator Anim;
    public string SubjectName;
    public GameObject Quantity;
    //������� ������ �� ������ ���������� � ��������
    public bool CheckResponseTranslateRUS;
    [SerializeField]
    //int Quantity;
    //������ ������� ������(������, ����������� ������ �� ������)
    public GameObject ProductionBuildingSendRequest;
    public int GetQuantity()
    {
        return Convert.ToInt32(Quantity.GetComponent<Text>().text);
    }


    // Start is called before the first frame update
    private void Awake()
    {
        //Anim = GetComponent<Animator>();
        //Debug.Log("Anim = GetComponent<Animator>();");
        InfoPanel = gameObject.transform.Find("InfoPanel").gameObject;
        Quantity = gameObject.transform.Find("Quantity").gameObject;
    }
    public void SetQuantity(int number)
    {
        Quantity.GetComponent<Text>().text = number.ToString();
    }
    void Start()
    {

    }
    private void OnEnable()
    {
        CheckResponseTranslateRUS = true;
    }
    void Update()
    {
        if (CheckResponseTranslateRUS)
        {
            //��������� ������� �����
            if (ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().ResponsesTranslateInfoRUS.ContainsKey(SubjectName))
            {
                var name = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().ResponsesTranslateInfoRUS[SubjectName].Name;
                var discription = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().ResponsesTranslateInfoRUS[SubjectName].Discription;
                var timeBuilding = ProductionBuildingSendRequest.GetComponent<ProductionBuilding>().ResponsesTranslateInfoRUS[SubjectName].TimeBuilding;
                //����������� ��������
                InfoPanel.GetComponent<InfoPanel>().SetProperties(name, discription, timeBuilding);
                CheckResponseTranslateRUS = false;
            }
        }
    }

    public void SetSprite(string subjectName) 
    {
        if (subjectName != "")
        {
            if (gameObject.GetComponent<SpriteRenderer>() != null && Data.GetComponent<ImageStorage>() != null)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = Data.GetComponent<ImageStorage>().GetSprite(subjectName);
            }
            if (gameObject.GetComponent<Image>() != null && Data.GetComponent<ImageStorage>() != null)
            {
                gameObject.GetComponent<Image>().sprite = Data.GetComponent<ImageStorage>().GetSprite(subjectName);
            }
        }
        else
        {
            Debug.Log("�����");
        }
    }
    private void OnMouseDown()//����� ��������� ������ ����
    {
        InfoPanel.SetActive(true);
    }
    private void OnMouseUp()//����� ��������� ������ ����
    {
        InfoPanel.SetActive(false);
    }
    void OnClear() //������� ����������
    {
        //��� ������ ���� ������ � ���������, ������� ���������� ��������

    }
    void OnDisable()
    {
        CheckResponseTranslateRUS = false;
        OnClear();
    }

}
