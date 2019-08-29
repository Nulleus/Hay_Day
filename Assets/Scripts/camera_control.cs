using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_control : MonoBehaviour
{
    private float horBound;//расстояние до границы по горизонтали
    private float vertBound;//расстояние до границы по вертикали
    private Camera m_camera;
    //левая, правая, верхняя, нижняя граница соответственно
    private float leftBound, rightBound, upBound, downBound;
    // Start is called before the first frame update
    void Start()
    {
        m_camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        vertBound = m_camera.orthographicSize;
        horBound = m_camera.orthographicSize / Screen.height * Screen.width;

        leftBound = transform.position.x - horBound;
        rightBound = transform.position.x + horBound;
        upBound = transform.position.y + vertBound;
        downBound = transform.position.y - vertBound;
        Debug.Log("vert: " + vertBound + "hor: " + horBound);
        Debug.Log("left: " + leftBound + "right: " + rightBound);
        Debug.Log("up: " + upBound + "down: " + downBound);
    }
}
