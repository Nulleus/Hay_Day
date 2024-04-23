using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class PanelWheelOfFortune : MonoBehaviour
{
    public GameObject ObjectOfRotation;
    //Скорость колеса
    public int SpeedRotation;
    //Вращать по часовой стрелке
    public bool ClockwiseRotation;
    //Стрелка барабана
    public GameObject Arrow;
    //Угол стрелки
    public int ArrowRotation;
    //Выиграшная позиция
    public string WinningPositionSubjectName;
    //Остановка колеса
    public bool StopSpin;
    //Последний предмет, на который указала стрелка
    public string LastSubjectArrowEncountered;
    //Все объекты колеса с призовыми элементами
    public GameObject[] SubjectsSpin;
    //Все имена объектов колеса с призовыми элементами
    public string[] SubjectsSpinName;
    //Анимация сбора приза
    public GameObject LinesSpin;
    //Кнопка получения приза
    public GameObject ButtonPrize;
    // Start is called before the first frame update
    void Start()
    {
        ButtonPrize.SetActive(false);
    }
    //Получаем приз
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetPrizeSpin()
    {
        LinesSpin.SetActive(true);
        LinesSpin.GetComponent<MovementPath>().SubjectName = WinningPositionSubjectName;
        LinesSpin.GetComponent<MovementPath>().StartAnimation();
        ButtonPrize.SetActive(false);
        
    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    //Загрузка призовых объектов в колесо форотуны из списка
    public void LoadSubjectsSpin()
    {
        //Получаем количество объектов
        int countSubjects = SubjectsSpinName.Length;
        for (int i = 0; i <= countSubjects; i++)
        {
            string subjectSpinName = SubjectsSpinName[i];
            SubjectsSpin[i].GetComponent<SubjectSpin>().SubjectName = subjectSpinName;
            SubjectsSpin[i].GetComponent<SpriteController>().SetSprite(subjectSpinName);
        }
    }
    public string GetLastSubjectArrowEncountered()
    {
        return LastSubjectArrowEncountered;
    }
    public void SetLastSubjectArrowEncountered(string lastSubjectArrowEncountered)
    {
        LastSubjectArrowEncountered = lastSubjectArrowEncountered;
    }
    // Update is called once per frame
    void Update()
    {
        if (!StopSpin)
        {
            if ((Arrow.gameObject.transform.rotation.z <= 90) && (Arrow.gameObject.transform.rotation.z >= 0))
            {
                Arrow.gameObject.transform.Rotate(0, 0, -1);
                //ArrowRotation = ArrowRotation - 1;           
            }
            if ((Arrow.gameObject.transform.rotation.z >= -90) && (Arrow.gameObject.transform.rotation.z <= 0))
            {
                Arrow.gameObject.transform.Rotate(0, 0, 1);
                //ArrowRotation = ArrowRotation - 1;           
            }


            if (SpeedRotation > 0)
            {
                if (SpeedRotation < 120)
                {
                    string lastSubjectArrowEncountered = GetLastSubjectArrowEncountered();
                    if (lastSubjectArrowEncountered != WinningPositionSubjectName)
                    {
                        SpeedRotation = SpeedRotation + 50;
                    }
                }

                if (ClockwiseRotation)
                {
                    ObjectOfRotation.gameObject.transform.Rotate(0, 0, SpeedRotation * Time.deltaTime);
                }
                else
                {
                    ObjectOfRotation.gameObject.transform.Rotate(0, 0, -SpeedRotation * Time.deltaTime);
                }

                SpeedRotation = SpeedRotation - 1;
            }
        }


    }
}
