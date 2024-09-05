using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class PanelWheelOfFortune : MonoBehaviour
{
    public GameObject ObjectOfRotation;
    //�������� ������
    private int _wheelRotationSpeed;
    //������� �� ������� �������
    private bool _isClockwiseRotation;
    //������� ��������
    public GameObject Arrow;
    //���� �������
    private int _arrowRotation;
    //���������� �������
    public string _winningPositionSubjectName;
    //��������� ������
    private bool _isStopSpin;
    //��������� �������, �� ������� ������� �������
    private string _lastSubjectArrowEncountered;
    //����������� �������� ������
    private bool _isRotationEnabled;
    //��� ������� ������ � ��������� ����������
    public GameObject[] SubjectsSpin;
    //��� ����� �������� ������ � ��������� ����������
    public string[] SubjectsSpinName;
    //�������� ����� �����
    public GameObject LinesSpin;
    //������ ��������� �����
    public GameObject ButtonPrize;
    //���������� ���������� ���������� ��������
    public GameObject LightsController;
    //����������� �������� ��������, ��� ������� ����� ����������� �������� ��� ��������� ������
    public const int WHEEL_CELL_CHANGE_SPEED_MIN = 120;
    //�������� ����������� ������, ��� ��������� ����������
    public const int HELP_ROTATION_SPEED = 50;
    //������� ������ ��� ������
    public GameObject UIParticle;
    //���������� �������� ������
    public int _countSpins;
    //���� �������
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
    //����������� ������� �������� ������
    public void IncCountSpins()
    {
        CountSpins++;
    }
    //��������� �������, �� ������� ������� �������
    [ShowInInspector]
    public string LastSubjectArrowEncountered
    {
        get
        {
            return _lastSubjectArrowEncountered;
        }
        set => _lastSubjectArrowEncountered = value;
    }
    //���� �������
    [ShowInInspector]
    public int ArrowRotation
    {
        get
        {
            return _arrowRotation;
        }
        set => _arrowRotation = value;
    }
    //������� �� ������� �������
    [ShowInInspector]
    public bool IsClockwiseRotation
    {
        get
        {
            return _isClockwiseRotation;
        }
        set => _isClockwiseRotation = value;
    }
    //��������� ������
    [ShowInInspector]
    public bool IsStopSpin
    {
        get
        {
            return _isStopSpin;
        }
        set => _isStopSpin = value;
    }
    //���������� �������
    [ShowInInspector]
    public string WinningPositionSubjectName
    {
        get
        {
            return _winningPositionSubjectName;
        }
        set => _winningPositionSubjectName = value;
    }
    //�������� ������
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
    //�������� ����������, ����� ������� ��������������� �� ���������� �������
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
    //�������� ����
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
    //�������� �������� �������� � ������ �������� �� ������
    public void LoadSubjectsSpin()
    {
        //�������� ���������� ��������
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
    //�������� �������
    void RotateArrow()
    {
        if (Arrow.transform.rotation.z == 0)
        {
            return;
        }

        int RotationVal = Arrow.transform.rotation.z > 0 ? -1 : 1;
        Arrow.transform.Rotate(0, 0, RotationVal);
    }
    //�������� ������
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
    //���������� �������� ������
    void SlowWheelRotation()
    {
        WheelRotationSpeed -= 1;
    }
}
