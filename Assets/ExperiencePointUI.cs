using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class ExperiencePointUI : MonoBehaviour
{
    public float AmountExperiencePoint;
    public GameObject Data;

    //�������� ���������� �����, ��� ����������� ������������� �������� �� ��� ������� ������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public float GetAmountExperiencePoint()
    {
        //���������� ����� � ������������
        int experiencePointUser = Data.GetComponent<SubjectSum>().GetSubjectSumCount("experiencePoint", "Local");
        //������� ������� ������������
        int levelNumber = Data.GetComponent<ExperienceLevel>().GetLevelByExperiencePoints(experiencePointUser, "Local");
        //������������ ���������� ����� ��� �������� ������
        int maxExperiencePointForLevelNumber = Data.GetComponent<ExperienceLevel>().GetExperiencePointsByLevel(levelNumber, "Local");
        float result = (float)maxExperiencePointForLevelNumber;
        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowFillExperiencePointUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    void ShowFillExperiencePointUI()
    {
        float maxExperiencePointForLevelNumber = GetAmountExperiencePoint();
        AmountExperiencePoint = maxExperiencePointForLevelNumber / 100f;
        gameObject.GetComponent<Image>().fillAmount = AmountExperiencePoint;
    }
}
