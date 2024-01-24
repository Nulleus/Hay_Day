using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour
{
    public GameObject Camera;
    public GameObject StartPoint;
    public GameObject Target;
    public Vector3 Cam;
    public Vector3 CamRelative;
    public Vector3 CamStartPoint;
    public Vector3 CamRelativeStartPoint;  
    public Vector3 CamTarget;
    public Vector3 CamRelativeTarget;
    public Vector3 screenPosStartPoint;
    public Vector3 screenPosTarget;

    public Vector2 ViewportPos;
    private void Start()
    {

    }
    public void PlaceYourself()
    {
        ViewportPos = Camera.GetComponent<Camera>().WorldToViewportPoint(Target.transform.position);
        //GetComponent<RectTransform>().anchoredPosition = new Vector2(1920 * ViewportPos.x, 1080 * ViewportPos.y);
        //rectTransform.anchoredPosition = position;

    }
    private void Update()
    {
        PlaceYourself();
        Cam = gameObject.transform.position;
        CamRelative = gameObject.transform.localPosition;

        CamTarget = Target.transform.position;
        CamRelativeTarget = Target.transform.localPosition;

        CamStartPoint = StartPoint.transform.position;
        CamRelativeStartPoint = StartPoint.transform.localPosition;

        screenPosStartPoint = Camera.GetComponent<Camera>().WorldToScreenPoint(StartPoint.transform.position);
        screenPosTarget = Camera.GetComponent<Camera>().WorldToScreenPoint(Target.transform.position);
    }

    private void OnEnable()
    {
        //gameObject.transform.localPosition = Target.transform.localPosition;
    }

    // Start is called before the first frame update

}
