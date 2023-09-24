using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SlotsLoading : MonoBehaviour
{
    public GameObject Data;
    [SerializeField]
    GameObject[] SlotLoadingFrame;
    public string SubjectName;
    //Максимальное количество слотов
    public int MaxCountSlots;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        SetOpenSlots();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetOpenSlots()
    {
        int openSlotsCount = Data.GetComponent<ProgresSlot>().GetOpenSlotsCount(SubjectName, "Local");
        for (int i = 0; i < MaxCountSlots; i++)
        {
            SlotLoadingFrame[i].SetActive(false);
            if (i < openSlotsCount)
            {
                SlotLoadingFrame[i].SetActive(true);
            }
        }
    }
}
