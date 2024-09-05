using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class PanelWheelOfFortune : MonoBehaviour
{
    public GameObject ObjectOfRotation;
    //Скорость колеса
    private int _wheelRotationSpeed;
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
    //Доступность вращения колеса
    private bool _isRotationEnabled;
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
    //Минимальное значение скорости, при котором может добавляться скорость для подкрутки колеса
    public const int WHEEL_CELL_CHANGE_SPEED_MIN = 120;
    //Скорость добавляемая колесу, для подкрутки результата
    public const int HELP_ROTATION_SPEED = 50;
    //Система частиц для салюта
    public GameObject UIParticle;
    //Количество вращений колеса
    public int _countSpins;
    //Приз получен
    public bool _isGettingPrize;
    public bool IsGettingPrize
    {
        get
        {
            return _isGettingPrize;
        }
        set => _isGettingPrize = value;
    }
    [ShowInInspector]
    public int CountSpins
    {
        get
        {
            return _countSpins;
        }
        set => _countSpins = value;
    }
    //Увеличиваем счетчик вращений колеса
    public void IncCountSpins()
    {
        CountSpins++;
    }
    //Последний предмет, на который указала стрелка
    [ShowInInspector]
    public string LastSubjectArrowEncountered
    {
        get
        {
            return _lastSubjectArrowEncountered;
        }
        set => _lastSubjectArrowEncountered = value;
    }
    //Угол стрелки
    [ShowInInspector]
    public int ArrowRotation
    {
        get
        {
            return _arrowRotation;
        }
        set => _arrowRotation = value;
    }
    //Вращать по часовой стрелке
    [ShowInInspector]
    public bool IsClockwiseRotation
    {
        get
        {
            return _isClockwiseRotation;
        }
        set => _isClockwiseRotation = value;
    }
    //Остановка колеса
    [ShowInInspector]
    public bool IsStopSpin
    {
        get
        {
            return _isStopSpin;
        }
        set => _isStopSpin = value;
    }
    //Выиграшная позиция
    [ShowInInspector]
    public string WinningPositionSubjectName
    {
        get
        {
            return _winningPositionSubjectName;
        }
        set => _winningPositionSubjectName = value;
    }
    //Скорость колеса
    [ShowInInspector]
    public int WheelRotationSpeed
    {
        get
        {
            return _wheelRotationSpeed;
        }
        set => _wheelRotationSpeed = value;
    }
    [ShowInInspector]
    public bool IsRotationEnabled
    {
        get
        {
            return _isRotationEnabled;
        }
        set
        {
            _isRotationEnabled = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ButtonPrize.SetActive(false);
        CountSpins = 0;
        IsGettingPrize = true;
    }
    //Действие происходит, когда стрелка останавливается на выигрышной позиции
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void WinningPosition()
    {
        IsGettingPrize = false;
        ButtonPrize.SetActive(true);
        ButtonPrize.GetComponent<SpriteController>().SetSprite(WinningPositionSubjectName);
        IsStopSpin = true;
        WheelRotationSpeed = 0;
        IsRotationEnabled = false;
        if (_winningPositionSubjectName == "starSpin")
        {
            UIParticle.GetComponent<ParticleSystemController>().StartParticle();
        }
    }
    //Получаем приз
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetPrizeSpin()
    {
        if (IsGettingPrize) { return; }       
        LinesSpin.SetActive(true);
        LinesSpin.GetComponent<MovementPath>().SubjectName = WinningPositionSubjectName;
        LinesSpin.GetComponent<MovementPath>().StartAnimation();
        ButtonPrize.SetActive(false);
        IsGettingPrize = true;
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
        if (IsStopSpin)
        {
            return;
        }
        this.RotateArrow();

        if (WheelRotationSpeed <= 0)
        {
            return;
        }

        RotateWheel();
        SlowWheelRotation();
    }
    //Вращение стрелки
    void RotateArrow()
    {
        if (Arrow.transform.rotation.z == 0)
        {
            return;
        }

        int RotationVal = Arrow.transform.rotation.z > 0 ? -1 : 1;
        Arrow.transform.Rotate(0, 0, RotationVal);
    }
    //Вращение колеса
    void RotateWheel()
    {
        if (WheelRotationSpeed < WHEEL_CELL_CHANGE_SPEED_MIN && LastSubjectArrowEncountered != WinningPositionSubjectName)
    {
            WheelRotationSpeed += HELP_ROTATION_SPEED;
        }

        int Direction = IsClockwiseRotation ? 1 : -1;
        float Rotation = Direction * WheelRotationSpeed * Time.deltaTime;
        ObjectOfRotation.transform.Rotate(0, 0, Rotation);
    }
    //Замедление вращения колеса
    void SlowWheelRotation()
    {
        WheelRotationSpeed -= 1;
    }
}
