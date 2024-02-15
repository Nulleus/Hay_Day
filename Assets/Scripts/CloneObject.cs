using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CloneObject : MonoBehaviour
{
    public GameObject ObjectFromGetWidth; //������, � �������� ����� ������� ����
    public Vector3 PositionBeginner; //�������������� ������� �������
    public Vector3 PositionCloneEnd; //������������ ���������� �������������� �������

    public GameObject ParentObject; //������������ ������
    

    // Start is called before the first frame update
    private void Awake()
    {
        //PositionBeginner = ObjectFromGetWidth.transform.position;//����������� �������������� �������� ���������� 
        //PositionCloneEnd = PositionBeginner;
        //Debug.Log("!!!!!!!!!!!!!!!!!!!!!!");
        //Clone("Test", 890);
    }
    void Start()
    {


    }
    private void OnEnable()
    {
        PositionBeginner = ObjectFromGetWidth.transform.position;//����������� �������������� �������� ���������� 
        PositionCloneEnd = PositionBeginner;
    }

    // Update is called once per frame
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void Clone(string subjectName, int subjectCount)
    {
        //PositionCloneEnd = ObjectFromGetWidth.transform.position; //����������� �������������� �������� ���������� 
        Debug.Log(PositionCloneEnd);
        Debug.Log("ObjectFromGetWidth.GetComponent<Rect>().width=" + ObjectFromGetWidth.GetComponent<RectTransform>().rect.width);
        float offsetX = ObjectFromGetWidth.GetComponent<RectTransform>().rect.width;
        GameObject clone = Instantiate(ObjectFromGetWidth, new Vector3((PositionCloneEnd.x + (ObjectFromGetWidth.GetComponent<RectTransform>().rect.width))
        , ObjectFromGetWidth.transform.position.y, ObjectFromGetWidth.transform.position.z), Quaternion.identity, ParentObject.transform);
        //������� ����� �������� 
        clone.SetActive(true);
        clone.GetComponent<PanelSlot>().SubjectName = subjectName;
        Debug.Log("subjectName="+subjectName);
        clone.GetComponent<PanelSlot>().SetSprite(subjectName);
        clone.GetComponent<PanelSlot>().InfoPanel.SetActive(false);
        clone.GetComponent<PanelSlot>().InfoPanel.GetComponent<InfoPanel>().SubjectName = subjectName;
        clone.GetComponent<PanelSlot>().SetQuantity(subjectCount);
        PositionCloneEnd = clone.transform.position;//������������ ���������� �����

    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void DeleteClones() //�������� ������
    {
        PositionCloneEnd = PositionBeginner;
        int childCount = gameObject.transform.childCount;
        
        Debug.Log(childCount);
        GameObject clone;
        for (int i = 0; i <= childCount; i++) //
        {
            try
            {
                clone = gameObject.transform.Find("PanelSlot(Clone)").gameObject;
                Debug.Log("cloneID: " + clone.GetInstanceID());
                Debug.Log("clone: " + clone);
                Debug.Log("��������");
                DestroyImmediate(clone);
            }
            catch 
            {
                Debug.Log("��� ������ �������");
            }
        }
    }
    void OnDisable()
    {
        DeleteClones();
    }
}