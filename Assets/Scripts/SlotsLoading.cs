using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SlotsLoading : MonoBehaviour
{
    GameObject Data;
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
        OpenSlots();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void OpenSlots()
    {
        int openSlotsCpunt = Data.GetComponent<ProgresSlot>().GetOpenSlotsCount(SubjectName, "Local");
        for (int i = 0; i < MaxCountSlots; i++)
        {
            SlotLoadingFrame[i].SetActive(false);
            if (i < openSlotsCpunt)
            {
                SlotLoadingFrame[i].SetActive(true);
            }
        }
    }
}
