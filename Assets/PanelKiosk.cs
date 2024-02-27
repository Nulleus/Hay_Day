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
        Debug.Log("selectedPredmetSubjectSum=" + selectedPredmetSubjectSum);
        //Выведем количество выбранных предметов 
        SelectedPredmet.GetComponent<ShowText>().Show("x"+SelectedPredmetQuantity.ToString());
        if (SelectedPredmetQuantity < 2)
        {
            ButtonMinusQuantity.GetComponent<Image>().color = Color.grey;
            ButtonMinusQuantity.GetComponent<ButtonScript>().SetLock(true);
        }
        else
        {
            ButtonMinusQuantity.GetComponent<Image>().color = Color.white;
            ButtonMinusQuantity.GetComponent<ButtonScript>().SetLock(false);
            if (selectedPredmetSubjectSum <= SelectedPredmetQuantity)
            {
                ButtonPlusQuantity.GetComponent<Image>().color = Color.grey;
                ButtonPlusQuantity.GetComponent<ButtonScript>().SetLock(true);
                Debug.Log("grey");
            }
            if (selectedPredmetSubjectSum >= SelectedPredmetQuantity)
            {
                ButtonPlusQuantity.GetComponent<Image>().color = Color.white;
                ButtonPlusQuantity.GetComponent<ButtonScript>().SetLock(false);
                Debug.Log("white");
            }
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
        decimal maxCoinByQuantity = decimal.Round(priceForOneCoin * selectedPredmetQuantity);
        Debug.Log("maxCoinByQuantity=" + maxCoinByQuantity);


        //Получаем количество выбранных предметов пользователем

        Debug.Log("selectedPredmetQuantity=" + selectedPredmetQuantity);
        //Выведем количество выбранных предметов 
        Coin.GetComponent<ShowText>().Show(coinSelectedQuantity.ToString());
        if (coinSelectedQuantity < 2)
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
        if(coinSelectedQuantity > maxCoinByQuantity)
        {
            Debug.Log("coinSelectedQuantity="+ coinSelectedQuantity);
            Debug.Log("maxCoinByQuantity=" + maxCoinByQuantity);
            Debug.Log("maxCoin=" + maxCoin);
            ButtonPlusCoin.GetComponent<Image>().color = Color.grey;
            ButtonPlusCoin.GetComponent<ButtonScript>().SetLock(true);
            Debug.Log("grey");
        }
        if (coinSelectedQuantity < maxCoinByQuantity)
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
