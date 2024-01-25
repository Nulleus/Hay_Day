using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector2 offset;
    private RectTransform rectTransform = null;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        if (!objectToFollow) return;
        rectTransform.position = RectTransformUtility.WorldToScreenPoint(cam, objectToFollow.position) + offset;
    }
}
