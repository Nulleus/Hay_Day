using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class PanelKiosk : MonoBehaviour
{
    public GameObject Data;
    public string SelectedStorage;
    public List<string> AllSubjects; //Все объекты
    public GameObject SelectedPredmet; //Выбранный предмет
    public GameObject ObjectFromGetWidthClone; //Объект, с которого нужно сделать клон
    public Transform ParentObjectClone; //Родительский объект клона
    [SerializeField]
    private int SelectedPredmetQuantity;
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
        return SelectedPredmetQuantity;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetSelectedPredmetQuantity(int quantity)
    {
        SelectedPredmetQuantity = quantity;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void ChangeSelectedPredmetQuantity()
    {
        //Получаем количество выбранных предметов на складе
        int selectedPredmetSubjectSum = Data.GetComponent<SubjectSum>().GetSubjectSumCount(GetSelectedPredmet(), "Local");
        int selectedPredmetQuantity = SelectedPredmetQuantity;
        Debug.Log("SelectedPredmetQuantity=" + SelectedPredmetQuantity);
        Debug.Log("selectedPredmetSubjectSum=" + selectedPredmetSubjectSum);
        //Выведем количество выбранных предметов 
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
        if (selectedPredmetSubjectSum <= SelectedPredmetQuantity)
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
        //Количество выбранной стоимости
        int coinSelectedQuantity = CoinSelectedQuantity;
        //Получаем количество выбранных предметов на складе
        int selectedPredmetQuantity = SelectedPredmetQuantity;
        decimal priceForOneCoin = Data.GetComponent<PriceSubject>().GetCoinsForOne(GetSelectedPredmet());
        Debug.Log("priceForOneCoin=" + priceForOneCoin);
        //Максимальня стоимость предметов
        decimal maxCoin = priceForOneCoin * 10;
        Debug.Log("maxCoin=" + maxCoin);       
        //Максимальня стоимость предметов по количеству
        decimal maxCoinByQuantity = decimal.Truncate(priceForOneCoin * selectedPredmetQuantity);
        Debug.Log("maxCoinByQuantity=" + maxCoinByQuantity);


        //Получаем количество выбранных предметов пользователем

        Debug.Log("selectedPredmetQuantity=" + selectedPredmetQuantity);
        //Выведем количество выбранных предметов 
        Coin.GetComponent<ShowText>().Show(coinSelectedQuantity.ToString());
        if ((coinSelectedQuantity < 2))
        {
            ButtonMinusCoin.GetComponent<Image>().color = Color.grey;
            ButtonMinusCoin.GetComponent<ButtonScript>().SetLock(true);
        }
        else
        {
            ButtonMinusCoin.GetComponent<Image>().color = Color.white;
            ButtonMinusCoin.GetComponent<ButtonScript>().SetLock(false);
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
            Debug.Log("white");
        }
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetCoinQuantity()
    {
        return CoinSelectedQuantity;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetCoinQuantity(int quantity)
    {
        SelectedPredmetQuantity = quantity;
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
        //Получим общее количество предметов на складе
        SelectedPredmetQuantity += quantity;
        ChangeSelected();

    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetMinusQuantity(int quantity)
    {       
        SelectedPredmetQuantity -= quantity;
        ChangeSelected();
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetSelectedPredmet()
    {
        return SelectedPredmet.GetComponent<PanelSlot>().GetSubjectName();
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetAllSubjects()
    {
        //Количество очков у пользователя
        int experiencePointUser = Data.GetComponent<SubjectSum>().GetSubjectSumCount("experiencePoint", "Local");
        //Текущий уровень пользователя
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
            //Добавим клону свойства 
            clone.SetActive(true);
            //Присвоим имя объекту
            clone.GetComponent<Subject>().SetName(AllSubjects[i]);
            //Добавим анимацию спрайту
            clone.GetComponent<SpriteController>().SetSprite(AllSubjects[i]);
            //Добавим количество объектов на складе
            //-Получим количество объектов на складе
            int countSubjectSum = clone.GetComponent<Subject>().GetCount();
            clone.GetComponent<ShowText>().Show(countSubjectSum.ToString());
            //clone.
        }
        
    }

    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetMaxCoin()
    {
        //Количество выбранной стоимости
        int coinSelectedQuantity = CoinSelectedQuantity;
        //Получаем количество выбранных предметов
        int selectedPredmetQuantity = SelectedPredmetQuantity;
        //Цена предмета за единицу
        decimal priceForOneCoin = Data.GetComponent<PriceSubject>().GetCoinsForOne(GetSelectedPredmet());
        Debug.Log("priceForOneCoin=" + priceForOneCoin);
        //Максимальня стоимость предметов
        decimal maxCoin = priceForOneCoin * 10;
        Debug.Log("maxCoin=" + maxCoin);
        //Максимальня стоимость предметов по количеству
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
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void AverageValueQuantity()
    {
        //Среднее количество предметов
        int averageQuantityPredmet;
        //Выбранный предмет
        string selectedPredmet = GetSelectedPredmet();
        //Получаем количество выбранных предметов на складе
        int selectedPredmetSubjectSum = Data.GetComponent<SubjectSum>().GetSubjectSumCount(selectedPredmet, "Local");
        Debug.Log("selectedPredmetSubjectSum=" + selectedPredmetSubjectSum);

        //Количество выбранных предметов
        int selectedPredmetQuantity = SelectedPredmetQuantity;
        //Цена предмета за единицу
        decimal priceForOneCoin = Data.GetComponent<PriceSubject>().GetCoinsForOne(selectedPredmet);
        Debug.Log("priceForOneCoin=" + priceForOneCoin);
        if (selectedPredmetSubjectSum >= 10)
        {
            averageQuantityPredmet = 10;
        }
        else
        {
            averageQuantityPredmet = selectedPredmetSubjectSum / 2;
        }
        SetSelectedPredmetQuantity(averageQuantityPredmet);
        Debug.Log("averageQuantity=" + averageQuantityPredmet);
        
    }
    private void OnEnable()
    {
        CoinSelectedQuantity = 1;
        SelectedPredmetQuantity = 1;
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
