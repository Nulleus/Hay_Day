using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;


public class PanelWheelOfFortune : MonoBehaviour
{
    public GameObject ObjectOfRotation;
    //�������� ������
    private int _speedRotation;
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
    //�������� ����������, ����� ������� ��������������� �� ���������� �������
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void WinningPosition()
    {
        ButtonPrize.SetActive(true);
        ButtonPrize.GetComponent<SpriteController>().SetSprite(WinningPositionSubjectName);
        IsStopSpin = true;
        SpeedRotation = 0;
    }
    //�������� ����
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void GetPrizeSpin()
    {
        LinesSpin.SetActive(true);
        LinesSpin.GetComponent<MovementPath>().SubjectName = WinningPositionSubjectName;
        LinesSpin.GetComponent<MovementPath>().StartAnimation();
        ButtonPrize.SetActive(false);       
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
