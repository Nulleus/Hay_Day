using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsLoading : MonoBehaviour
{
    [SerializeField]
    GameObject[] SlotLoadingFrame;
    public int OpenSlots;
    //Максимальное количество слотов
    public int MaxCountSlots;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        GetOpenSlotsCount();
        for (int i = 0; i < MaxCountSlots; i++)
        {
            SlotLoadingFrame[i].SetActive(false);
            if (i < OpenSlots)
            {
                SlotLoadingFrame[i].SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void GetOpenSlotsCount()
    {
        OpenSlots = gameObject.GetComponent<ProgressSlots>().OpenSlots;
    }
}
