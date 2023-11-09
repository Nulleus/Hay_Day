using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class ExperiencePointUI : MonoBehaviour
{
    public float AmountExperiencePoint;
    public GameObject Data;

    //ѕолучаем количество очков, дл€ отображени€ максимального значени€ на его текущем уровне
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public float GetAmountExperiencePoint()
    {
        // оличество очков у пользовател€
        int experiencePointUser = Data.GetComponent<SubjectSum>().GetSubjectSumCount("experiencePoint", "Local");
        //“екущий уровень пользовател€
        int levelNumber = Data.GetComponent<ExperienceLevel>().GetLevelByExperiencePoints(experiencePointUser, "Local");
        //ћаксимальное количество очков дл€ текущего уровн€
        int maxExperiencePointForLevelNumber = Data.GetComponent<ExperienceLevel>().GetExperiencePointsByLevel(levelNumber, "Local");
        float result = (float)maxExperiencePointForLevelNumber;
        return result;
    }
    //ѕолучаем количество очков, дл€ отображени€ максимального значени€ на его на предыдущем уровне
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public float GetAmountExperiencePointPhonetic()
    {
        // оличество очков у пользовател€
        int experiencePointUser = Data.GetComponent<SubjectSum>().GetSubjectSumCount("experiencePoint", "Local");
        //“екущий уровень пользовател€
        int levelNumber = Data.GetComponent<ExperienceLevel>().GetLevelByExperiencePoints(experiencePointUser, "Local");
        //ћаксимальное количество очков дл€ текущего уровн€
        int maxExperiencePointForLevelNumber = Data.GetComponent<ExperienceLevel>().GetExperiencePointsByLevel(levelNumber-1, "Local");
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
    public void ShowFillExperiencePointUI()
    {
        float maxExperiencePointForLevelNumber = GetAmountExperiencePoint();

        float maxExperiencePointForPhoneticLevelNumber = GetAmountExperiencePointPhonetic();
        //AmountExperiencePoint = maxExperiencePointForLevelNumber / 100f;
        int experiencePointUser = Data.GetComponent<SubjectSum>().GetSubjectSumCount("experiencePoint", "Local");
        float difference = maxExperiencePointForLevelNumber - experiencePointUser;
        Debug.Log("maxExperiencePointForLevelNumber=" + maxExperiencePointForLevelNumber);
        Debug.Log("experiencePointUser=" + experiencePointUser);
        Debug.Log("difference=" + difference);
        float endDifference = maxExperiencePointForLevelNumber - difference;
        Debug.Log("endDifference=" + endDifference);
        gameObject.GetComponent<Image>().fillAmount = ((endDifference*100f)/maxExperiencePointForLevelNumber)/100f;
    }
}
