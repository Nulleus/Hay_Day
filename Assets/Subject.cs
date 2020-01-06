using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class Subject : MonoBehaviour
{
    [SerializeField]
    private string Storage;
    [SerializeField]
    private int Count;
    [SerializeField]
    private int PriceMaxForCoins;
    [SerializeField]
    private int PriceForDiamonds;
    [SerializeField]
    private int BuildingTimeSec;
    [SerializeField]
    private int ExperiencePoint;
    [SerializeField]
    
   public int GetCount()
    {
        return Count;
    }
    public void SetCount(int count)
    {
        Count = Count + count;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Получение рецепта

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
