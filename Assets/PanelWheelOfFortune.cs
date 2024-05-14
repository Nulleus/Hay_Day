using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class PanelWheelOfFortune : MonoBehaviour
{
    public GameObject ObjectOfRotation;
    //Скорость колеса
    private int _speedRotation;
    //Вращать по часовой стрелке
    private bool _isClockwiseRotation;
    //Стрелка барабана
    public GameObject Arrow;
    //Угол стрелки
    private int _arrowRotation;
    //Выиграшная позиция
    public string _winningPositionSubjectName;
    //Остановка колеса
    private bool _isStopSpin;
    //Последний предмет, на который указала стрелка
    private string _lastSubjectArrowEncountered;
    //Все объекты колеса с призовыми элементами
    public GameObject[] SubjectsSpin;
    //Все имена объектов колеса с призовыми элементами
    public string[] SubjectsSpinName;
    //Анимация сбора приза
    public GameObject LinesSpin;
    //Кнопка получения приза
    public GameObject ButtonPrize;
    //Контроллер управления освещением лампочек
    public GameObject LightsController;
    [ShowInInspector]
    public string LastSubjectArrowEncountered
    {
        get
        {
            return _lastSubjectArrowEncountered;
        }
        set => _lastSubjectArrowEncountered = value;
    }
    [ShowInInspector]
    public int ArrowRotation
    {
        get
        {
            return _arrowRotation;
        }
        set => _arrowRotation = value;
    }
    [ShowInInspector]
    public bool IsClockwiseRotation
    {
        get
        {
            return _isClockwiseRotation;
        }
        set => _isClockwiseRotation = value;
    }
    [ShowInInspector]
    public bool IsStopSpin
    {
        get
        {
            return _isStopSpin;
        }
        set => _isStopSpin = value;
    }
    [ShowInInspector]
    public string WinningPositionSubjectName
    {
        get
        {
            return _winningPositionSubjectName;
        }
        set => _winningPositionSubjectName = value;
    }
    [ShowInInspector]
    public int SpeedRotation
    {
        get
        {
            return _speedRotation;
        }
        set => _speedRotation = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        ButtonPrize.SetActive(false);
    }
    //Действие происходит, когда стрелка останавливается на выигрышной позиции
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void WinningPosition()
    {
        ButtonPrize.SetActive(true);
        ButtonPrize.GetComponent<SpriteController>().SetSprite(WinningPositionSubjectName);
        IsStopSpin = true;
        SpeedRotation = 0;
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
        for (int i = 0; i < SubjectsSpinName.Length; i++)
        {
            SubjectsSpin[i].GetComponent<SubjectSpin>().SubjectName = SubjectsSpinName[i];
            SubjectsSpin[i].GetComponent<SpriteController>().SetSprite(SubjectsSpinName[i]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!IsStopSpin)
        {
            if (Arrow.transform.rotation.z >0)
            //if ((Arrow.transform.rotation.z <= 90) && (Arrow.transform.rotation.z >= 0))
            {
                Arrow.transform.Rotate(0, 0, -1);         
            }
            if (Arrow.transform.rotation.z <0)
            //if ((Arrow.transform.rotation.z >= -90) && (Arrow.transform.rotation.z <= 0))
            {
                Arrow.transform.Rotate(0, 0, 1);         
            }
            if (SpeedRotation > 0)
            {
                if (SpeedRotation < 120)
                {
                    if (LastSubjectArrowEncountered != WinningPositionSubjectName)
                    {
                        SpeedRotation += 50;
                    }
                }
                ObjectOfRotation.transform.Rotate(0, 0, IsClockwiseRotation ? SpeedRotation * Time.deltaTime : -SpeedRotation * Time.deltaTime);
                SpeedRotation -= 1;
            }
        }
    }
}
