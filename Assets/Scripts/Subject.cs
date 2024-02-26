using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
[SerializeField]
public class Subject : MonoBehaviour
{
    [SerializeField]
    private GameObject Data;
    [SerializeField]
    private string Name;
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
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetName()
    {
        return Name;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetName(string name)
    {
        Name = name;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public string GetStorageName()
    {
        Storage = Data.GetComponent<Storage>().GetStorageName(GetName(), "Local");
        return Storage;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetStorageName(string storageName)
    {
        Storage = storageName;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetBuildingTimeSec()
    {
        BuildingTimeSec = Data.GetComponent<BuildingTime>().GetTimeBuilding(GetName(), "Local");
        return BuildingTimeSec;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetBuildingTimeSec(int buildingTimeSec)
    {
        BuildingTimeSec = buildingTimeSec;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetCount()
    {
        Count = Data.GetComponent<SubjectSum>().GetSubjectSumCount(GetName(), "Local");
        return Count;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetCount(int count)
    {
        Count = count;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public int GetExperiencePoint()
    {
        return ExperiencePoint;
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void SetExperiencePoint(int experiencePoint)
    {
        ExperiencePoint =  experiencePoint;
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
