using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneObject : MonoBehaviour
{
    public GameObject ObjectFromGetWidth; //������, � �������� ����� ������� ����
    public Vector3 PositionCloneEnd; //������������ ���������� �������������� �������

    public GameObject ParentObject; //������������ ������
    public int offsetX; //�������� �� �


    // Start is called before the first frame update
    void Start()
    {
        PositionCloneEnd = ObjectFromGetWidth.transform.position;//����������� �������������� �������� ���������� 
        Debug.Log("!!!!!!!!!!!!!!!!!!!!!!");
        TestClone();
        TestClone();
        TestClone();
        TestClone();
    }

    // Update is called once per frame
    void TestClone()
    {
        //PositionCloneEnd = ObjectFromGetWidth.transform.position; //����������� �������������� �������� ���������� 
        Debug.Log(PositionCloneEnd);
        Debug.Log("ObjectFromGetWidth.GetComponent<Rect>().width=" + ObjectFromGetWidth.GetComponent<RectTransform>().rect.width);
        GameObject clone = Instantiate(ObjectFromGetWidth, new Vector3((PositionCloneEnd.x + (ObjectFromGetWidth.GetComponent<RectTransform>().rect.width + offsetX))
        , ObjectFromGetWidth.transform.position.y, ObjectFromGetWidth.transform.position.z), Quaternion.identity, ParentObject.transform);
        //������� ����� �������� 
        PositionCloneEnd = clone.transform.position;//������������ ���������� �����

    }
    public void DeleteClones() //�������� ������
    {
        
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