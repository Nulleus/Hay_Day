using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CloneObjectLines : MonoBehaviour
{
    //������, � �������� ����� ������� ����
    public GameObject ObjectFromGetWidth; 
    //�������������� ������� �������
    public Vector3 PositionBeginner; 
    //������������ ������, ����� ����� ������ �������� � ����� ������������ ������ ���������� ����
    public GameObject ParentObject; 
    // Start is called before the first frame update
    private void Awake()
    {
        //����������� �������������� �������� ���������� 
        PositionBeginner = ObjectFromGetWidth.transform.position;
    }
    void Start()
    {


    }
    private void OnEnable()
    {

    }

    // Update is called once per frame
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void Clone(string subjectName, int quantity)
    {
        Debug.Log("ObjectFromGetWidth.GetComponent<Rect>().width=" + ObjectFromGetWidth.GetComponent<RectTransform>().rect.width);
        GameObject clone = Instantiate(ObjectFromGetWidth, ParentObject.transform);        
        //������� ����� �������� 
        clone.SetActive(true);
        clone.GetComponent<MovementPath>().SubjectName = subjectName;
        clone.GetComponent<MovementPath>().SetValueTextPro("+" + quantity);     
        clone.GetComponent<MovementPath>().StartAnimation();
        Debug.Log("subjectName=" + subjectName);

    }
    [Button(ButtonSizes.Medium, ButtonStyle.FoldoutButton)]
    public void DeleteClones() //�������� ���� ������
    {
        //�������� ���������� ������
        int childCount = ParentObject.transform.childCount;

        Debug.Log(childCount);
        GameObject clone;
        for (int i = 0; i <= childCount; i++) //
        {
            try
            {
                clone = ParentObject.transform.Find(gameObject.name+"(Clone)").gameObject;
                Debug.Log("cloneID: " + clone.GetInstanceID());
                Debug.Log("clone: " + clone);
                Debug.Log("��������");
                DestroyImmediate(clone);
                return;
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
