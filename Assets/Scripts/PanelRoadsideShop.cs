using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class PanelRoadsideShop: MonoBehaviour
{
    public GameObject Data;
    public string SelectedStorage;
    public List<string> AllSubjects; //��� �������
    public GameObject SelectedPredmet; //��������� �������
    public GameObject ObjectFromGetWidthClone; //������, � �������� ����� ������� ����
    public Transform ParentObjectClone; //������������ ������ �����
    [SerializeField]
    private int PredmetSelectedQuantity;
    [SerializeField]
    private int CoinSelectedQuantity;
    public GameObject ButtonPlusQuantity;
    public GameObject ButtonMinusQuantity;
    public GameObject ButtonPlusCoin;
    public GameObject ButtonMinusCoin;
    public GameObject Coin;
    public GameObject ButtonMaxCoin;
    public GameObject ButtonMinCoin;
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetSelectedPredmetQuantity()
    {
        return PredmetSelectedQuantity;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetSelectedPredmetQuantity(int quantity)
    {
        PredmetSelectedQuantity = quantity;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void ChangeSelectedPredmetQuantity()
    {
        //�������� ���������� ��������� ��������� �� ������
        int selectedPredmetSubjectSum = Data.GetComponent<SubjectSum>().GetSubjectSumCount(GetSelectedPredmet(), "Local");
        int selectedPredmetQuantity = PredmetSelectedQuantity;
        Debug.Log("SelectedPredmetQuantity=" + PredmetSelectedQuantity);
        Debug.Log("selectedPredmetSubjectSum=" + selectedPredmetSubjectSum);
        //������� ���������� ��������� ��������� 
        SelectedPredmet.GetComponent<ShowText>().Show("x"+ selectedPredmetQuantity.ToString());

        switch (selectedPredmetQuantity)
        {
            case 2:
                ButtonPlusQuantity.GetComponent<Image>().color = Color.white;
                ButtonPlusQuantity.GetComponent<ButtonScript>().SetLock(false);
                ButtonMinusQuantity.GetComponent<Image>().color = Color.white;
                ButtonMinusQuantity.GetComponent<ButtonScript>().SetLock(false);
                Debug.Log("case 2");
                break;
            case 3:
                ButtonPlusQuantity.GetComponent<Image>().color = Color.white;
                ButtonPlusQuantity.GetComponent<ButtonScript>().SetLock(false);
                ButtonMinusQuantity.GetComponent<Image>().color = Color.white;
                ButtonMinusQuantity.GetComponent<ButtonScript>().SetLock(false);
                Debug.Log("case 3");
                break;
            case 4:
                ButtonPlusQuantity.GetComponent<Image>().color = Color.white;
                ButtonPlusQuantity.GetComponent<ButtonScript>().SetLock(false);
                ButtonMinusQuantity.GetComponent<Image>().color = Color.white;
                ButtonMinusQuantity.GetComponent<ButtonScript>().SetLock(false);
                Debug.Log("case 4");
                break;
            case 5:
                ButtonPlusQuantity.GetComponent<Image>().color = Color.white;
                ButtonPlusQuantity.GetComponent<ButtonScript>().SetLock(false);
                ButtonMinusQuantity.GetComponent<Image>().color = Color.white;
                ButtonMinusQuantity.GetComponent<ButtonScript>().SetLock(false);
                Debug.Log("case 5");
                break;
            case 6:
                ButtonPlusQuantity.GetComponent<Image>().color = Color.white;
                ButtonPlusQuantity.GetComponent<ButtonScript>().SetLock(false);
                ButtonMinusQuantity.GetComponent<Image>().color = Color.white;
                ButtonMinusQuantity.GetComponent<ButtonScript>().SetLock(false);
                Debug.Log("6");
                break;
            case 7:
                ButtonPlusQuantity.GetComponent<Image>().color = Color.white;
                ButtonPlusQuantity.GetComponent<ButtonScript>().SetLock(false);
                ButtonMinusQuantity.GetComponent<Image>().color = Color.white;
                ButtonMinusQuantity.GetComponent<ButtonScript>().SetLock(false);
                Debug.Log("case 7");
                break;
            case 8:
                ButtonPlusQuantity.GetComponent<Image>().color = Color.white;
                ButtonPlusQuantity.GetComponent<ButtonScript>().SetLock(false);
                ButtonMinusQuantity.GetComponent<Image>().color = Color.white;
                ButtonMinusQuantity.GetComponent<ButtonScript>().SetLock(false);
                Debug.Log("case 8");
                break;
            case 9:
                ButtonPlusQuantity.GetComponent<Image>().color = Color.white;
                ButtonPlusQuantity.GetComponent<ButtonScript>().SetLock(false);
                ButtonMinusQuantity.GetComponent<Image>().color = Color.white;
                ButtonMinusQuantity.GetComponent<ButtonScript>().SetLock(false);
                Debug.Log("case 9");
                break;
            case 1:
                ButtonMinusQuantity.GetComponent<Image>().color = Color.grey;
                ButtonMinusQuantity.GetComponent<ButtonScript>().SetLock(true);
                ButtonPlusQuantity.GetComponent<Image>().color = Color.white;
                ButtonPlusQuantity.GetComponent<ButtonScript>().SetLock(false);
                Debug.Log("case 1");
                break;
            case 10:
                ButtonPlusQuantity.GetComponent<Image>().color = Color.grey;
                ButtonPlusQuantity.GetComponent<ButtonScript>().SetLock(true);
                ButtonMinusQuantity.GetComponent<Image>().color = Color.white;
                ButtonMinusQuantity.GetComponent<ButtonScript>().SetLock(false);
                Debug.Log("case 10");
                break;
            default:
                
                break;
        }
        if (selectedPredmetSubjectSum <= PredmetSelectedQuantity)
        {
            ButtonPlusQuantity.GetComponent<Image>().color = Color.grey;
            ButtonPlusQuantity.GetComponent<ButtonScript>().SetLock(true);
            Debug.Log("grey");
        }
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void ChangeSelected()
    {
        ChangeSelectedPredmetQuantity();
        ChangeSelectedCoinQuantity();
    }
    public void ChangeSelectedCoinQuantity()
    {
        //���������� ��������� ���������
        int coinSelectedQuantity = CoinSelectedQuantity;
        //�������� ���������� ��������� ��������� �� ������
        int selectedPredmetQuantity = PredmetSelectedQuantity;
        decimal priceForOneCoin = Data.GetComponent<PriceSubject>().GetCoinsForOne(GetSelectedPredmet());
        Debug.Log("priceForOneCoin=" + priceForOneCoin);
        //����������� ��������� ���������
        decimal maxCoin = priceForOneCoin * 10;
        Debug.Log("maxCoin=" + maxCoin);       
        //����������� ��������� ��������� �� ����������
        decimal maxCoinByQuantity = decimal.Truncate(priceForOneCoin * selectedPredmetQuantity);
        Debug.Log("maxCoinByQuantity=" + maxCoinByQuantity);


        //�������� ���������� ��������� ��������� �������������

        Debug.Log("selectedPredmetQuantity=" + selectedPredmetQuantity);
        //������� ���������� ��������� ��������� 
        Coin.GetComponent<ShowText>().Show(coinSelectedQuantity.ToString());
        if ((coinSelectedQuantity < 2))
        {
            ButtonMinusCoin.GetComponent<Image>().color = Color.grey;
            ButtonMinusCoin.GetComponent<ButtonScript>().SetLock(true);
            ButtonMinCoin.GetComponent<Image>().color = Color.grey;
            ButtonMinCoin.GetComponent<ButtonScript>().SetLock(true);
        }
        else
        {
            ButtonMinusCoin.GetComponent<Image>().color = Color.white;
            ButtonMinusCoin.GetComponent<ButtonScript>().SetLock(false);
            ButtonMinCoin.GetComponent<Image>().color = Color.white;
            ButtonMinCoin.GetComponent<ButtonScript>().SetLock(false);
        }
        //if (coinSelectedQuantity >= maxCoinByQuantity & coinSelectedQuantity >= maxCoin)
        if ((coinSelectedQuantity >= maxCoinByQuantity))
        {
            Debug.Log("coinSelectedQuantity="+ coinSelectedQuantity);
            Debug.Log("maxCoinByQuantity=" + maxCoinByQuantity);
            Debug.Log("maxCoin=" + maxCoin);
            ButtonPlusCoin.GetComponent<Image>().color = Color.grey;
            ButtonPlusCoin.GetComponent<ButtonScript>().SetLock(true);
            ButtonMaxCoin.GetComponent<Image>().color = Color.grey;
            ButtonMaxCoin.GetComponent<ButtonScript>().SetLock(true);
            Debug.Log("grey");
        }
        if ((coinSelectedQuantity < maxCoinByQuantity))
        {
            Debug.Log("coinSelectedQuantity=" + coinSelectedQuantity);
            Debug.Log("maxCoinByQuantity=" + maxCoinByQuantity);
            Debug.Log("maxCoin=" + maxCoin);
            ButtonPlusCoin.GetComponent<Image>().color = Color.white;
            ButtonPlusCoin.GetComponent<ButtonScript>().SetLock(false);
            ButtonMaxCoin.GetComponent<Image>().color = Color.white;
            ButtonMaxCoin.GetComponent<ButtonScript>().SetLock(false);
            Debug.Log("white");
        }
    }

    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetCoinSelectedQuantity()
    {
        return CoinSelectedQuantity;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetCoinSelectedQuantity(int quantity)
    {
        CoinSelectedQuantity = quantity;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetCoinPlusQuantity(int quantity)
    {
        CoinSelectedQuantity += quantity;
        ChangeSelected();
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetCoinMinusQuantity(int quantity)
    {
        CoinSelectedQuantity -= quantity;
        ChangeSelected();
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetPlusQuantity(int quantity)
    {
        //������� ����� ���������� ��������� �� ������
        PredmetSelectedQuantity += quantity;
        AverageCoinSelectedValueQuantity();
        ChangeSelected();

    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetMinusQuantity(int quantity)
    {
        PredmetSelectedQuantity -= quantity;
        AverageCoinSelectedValueQuantity();
        ChangeSelected();
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetSelectedPredmet()
    {
        return SelectedPredmet.GetComponent<PanelSlot>().GetSubjectName();
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void ClearAllSubjects()
    {
        AllSubjects.Clear();
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetAllSubjects()
    {
        ClearAllSubjects();
        //���������� ����� � ������������
        int experiencePointUser = Data.GetComponent<SubjectSum>().GetSubjectSumCount("experiencePoint", "Local");
        //������� ������� ������������
        int levelNumber = Data.GetComponent<ExperienceLevel>().GetLevelByExperiencePoints(experiencePointUser, "Local");
        string selectedStorages = GetSelectedStorage();
        SetAllSubjects(Data.GetComponent<Storage>().GetAllSubjects(selectedStorages, levelNumber, "Local"));
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetSelectedStorage()
    {
        return SelectedStorage;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetAllSubjects(List<string> allSubjects)
    {
        AllSubjects = allSubjects;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetCountSubjects()
    {
        return AllSubjects.Count;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void CloneSubject()
    {
        
        int countSubjects = GetCountSubjects();
        for (int i = 0; i <countSubjects; i++)
        {
            GameObject clone = Instantiate(ObjectFromGetWidthClone, ParentObjectClone);
            //������� ����� �������� 
            clone.SetActive(true);
            //�������� ��� �������
            clone.GetComponent<Subject>().SetName(AllSubjects[i]);
            //������� �������� �������
            clone.GetComponent<SpriteController>().SetSprite(AllSubjects[i]);
            //������� ���������� �������� �� ������
            //-������� ���������� �������� �� ������
            int countSubjectSum = clone.GetComponent<Subject>().GetCount();
            clone.GetComponent<ShowText>().Show(countSubjectSum.ToString());
            if (countSubjectSum <= 0)
            {
                clone.SetActive(false);
            }
            //clone.
        }
        
    }

    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetMaxCoin()
    {
        //���������� ��������� ���������
        int coinSelectedQuantity = CoinSelectedQuantity;
        //�������� ���������� ��������� ���������
        int selectedPredmetQuantity = PredmetSelectedQuantity;
        //���� �������� �� �������
        decimal priceForOneCoin = Data.GetComponent<PriceSubject>().GetCoinsForOne(GetSelectedPredmet());
        Debug.Log("priceForOneCoin=" + priceForOneCoin);
        //����������� ��������� ���������
        decimal maxCoin = priceForOneCoin * 10;
        Debug.Log("maxCoin=" + maxCoin);
        //����������� ��������� ��������� �� ����������
        decimal maxCoinByQuantity = decimal.Truncate(priceForOneCoin * selectedPredmetQuantity);
        Debug.Log("maxCoinByQuantity=" + maxCoinByQuantity);
        CoinSelectedQuantity = decimal.ToInt32(maxCoinByQuantity);
        ChangeSelected();
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetMinCoin()
    {
        CoinSelectedQuantity = 1;
        ChangeSelected();
    }
    //������� ���������� �����
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void AverageCoinSelectedValueQuantity()
    {
        Debug.Log("AverageCoinSelectedValueQuantity()");
        //��������� �������
        string selectedPredmet = GetSelectedPredmet();
        //�������� ���������� ��������� ��������� �� ������
        int selectedPredmetSubjectSum = Data.GetComponent<SubjectSum>().GetSubjectSumCount(selectedPredmet, "Local");
        Debug.Log("selectedPredmetSubjectSum=" + selectedPredmetSubjectSum);
        //���������� ��������� ���������
        int selectedPredmetQuantity = PredmetSelectedQuantity;
        //���� �������� �� �������
        decimal priceForOneCoin = Data.GetComponent<PriceSubject>().GetCoinsForOne(selectedPredmet);
        Debug.Log("priceForOneCoin=" + priceForOneCoin);

        //�������� ������� �������� ��������� ��������
        //���������� ��������� ���������
        int coinSelectedQuantity = CoinSelectedQuantity;
        Debug.Log("priceForOneCoin=" + priceForOneCoin);
        //����������� ��������� ���������
        decimal maxCoin = priceForOneCoin * 10;
        Debug.Log("maxCoin=" + maxCoin);
        //����������� ��������� ��������� �� ����������
        decimal maxCoinByQuantity = decimal.Truncate(priceForOneCoin * selectedPredmetQuantity);
        Debug.Log("maxCoinByQuantity=" + maxCoinByQuantity);
        decimal averageCoinQuantity = decimal.Truncate(maxCoinByQuantity / 3);
        SetCoinSelectedQuantity(decimal.ToInt32(averageCoinQuantity));
        Debug.Log("averageCoinQuantity=" + averageCoinQuantity);
        ChangeSelected();
    }
    //������� ���������� ���������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void AveragePredmetSelectedValueQuantity()
    {
        Debug.Log("AveragePredmetSelectedValueQuantity()");
        //������� ���������� ���������
        int averageQuantityPredmet;
        //��������� �������
        string selectedPredmet = GetSelectedPredmet();
        //�������� ���������� ��������� ��������� �� ������
        int selectedPredmetSubjectSum = Data.GetComponent<SubjectSum>().GetSubjectSumCount(selectedPredmet, "Local");
        Debug.Log("selectedPredmetSubjectSum=" + selectedPredmetSubjectSum);
        //���������� ��������� ���������
        int selectedPredmetQuantity = PredmetSelectedQuantity;
        if (selectedPredmetSubjectSum >= 10)
        {
            averageQuantityPredmet = 10;
        }
        else
        {
            averageQuantityPredmet = selectedPredmetSubjectSum / 2;
        }
        SetSelectedPredmetQuantity(averageQuantityPredmet);
        Debug.Log("averageQuantityPredmet=" + averageQuantityPredmet);
        ChangeSelected();
    }
    private void OnEnable()
    {
        CoinSelectedQuantity = 1;
        PredmetSelectedQuantity = 1;
        ChangeSelected();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetAllSubjects();
        CloneSubject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
