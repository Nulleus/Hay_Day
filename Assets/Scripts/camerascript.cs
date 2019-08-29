using UnityEngine;
using System.Collections;

public class camerascript : MonoBehaviour
{

    //=========================================ограничение камеры=====================//
    public float xMargin = 1f; // Distance in the x axis the player can move before the camera follows.
    public float yMargin = 1f; // Distance in the y axis the player can move before the camera follows.
    public float xSmooth = 8f; // How smoothly the camera catches up with it's target movement in the x axis.
    public float ySmooth = 8f; // How smoothly the camera catches up with it's target movement in the y axis.
    public Vector2 maxXAndY; // The maximum x and y coordinates the camera can have.
    public Vector2 minXAndY; // The minimum x and y coordinates the camera can have.

    private Transform m_Player; // Reference to the player's transform.
    //==================================================================================//
    // экранные координаты начальной точки касания
    private Vector3 initialTouchPosition;
    // мировые координаты камеры при инициировании
    // перемещения/масштабирования
    private Vector3 initialCameraPosition;

    // экранные координаты начальной точки первого касания
    private Vector3 initialTouch0Position;
    // экранные координаты начальной точки второго касания
    private Vector3 initialTouch1Position;
    // средняя точка между начальными координатами касаний
    private Vector3 initialMidPointScreen;
    // ортогональный размер камеры на момент начала масштабирования
    private float initialOrthographicSize;
    private Camera cam;
    //Координаты карты
    private float mapX = -260.5f;
    private float mapY = 29.6f;
    //Переменные
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    private float vertExtent;
    private float horzExtent;
    private Vector3 v3;
    private float ScreeToWorldPoint1;

    // Use this for initialization
    void Start()
    {

        cam = GetComponentInChildren<Camera>();
        // двигаем камеру
        globals.drag = false;
        globals.zoom = false;
        // масштабируем
        //=====Ограничение камеры========//
        vertExtent = cam.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;
        // Calculations assume map is position at the origin
        minX = horzExtent - mapX / 2.0f;
        maxX = mapX / 2.0f - horzExtent;
        minY = vertExtent - mapY / 2.0f;
        maxY = mapY / 2.0f - vertExtent;
        //Debug.Log("vert:" + vertExtent +"horz:"+ horzExtent);
        //Debug.Log("SH:" + Screen.height + ";SW:" + Screen.width);
    }
    //Calculate orthographic camera bounds 
    void CheckBoundCamera()
    {
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        Vector2 t0 = transform.position;
        float t1 = t0.y + (height / 2);
        float t2 = t0.x - (width / 2);
        float t3 = t0.y - (height / 2);
        float t4 = t0.x + (width / 2);
        //Debug.Log(t0);
       // Debug.Log(t1);
        //Debug.Log(t2);
        //Debug.Log(t3);
        //Debug.Log(t4);
       // float size = rectTransform.re
    }
    // Update is called once per frame
    void Update()
    {
        //
        CheckBoundCamera();

        if (Input.touchCount == 1)
        {
            globals.zoom = false;
            Touch touch0 = Input.GetTouch(0);

            if (IsTouching(touch0))
            {
                if (!globals.drag)
                {
                    initialTouchPosition = touch0.position;
                    initialCameraPosition = this.transform.position;

                    globals.drag = true;
                }
                else
                {
                    Vector2 delta = cam.ScreenToWorldPoint(touch0.position) -
                                    cam.ScreenToWorldPoint(initialTouchPosition);

                    Vector3 newPos = initialCameraPosition;
                    newPos.x -= delta.x;
                    newPos.y -= delta.y;

                    this.transform.position = newPos;
                }
            }

            if (!IsTouching(touch0))
            {
                globals.drag = false;
            }
        }
        else
        {
            globals.drag = false;
        }

        if (Input.touchCount == 2)
        {
            globals.drag = false;

            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (!globals.zoom)
            {
                initialTouch0Position = touch0.position;
                initialTouch1Position = touch1.position;
                initialCameraPosition = this.transform.position;
                initialOrthographicSize = Camera.main.orthographicSize;
                initialMidPointScreen = (touch0.position + touch1.position) / 2;

                globals.zoom = true;
            }
            else
            {
                this.transform.position = initialCameraPosition;
                cam.orthographicSize = initialOrthographicSize;

                float scaleFactor = GetScaleFactor(touch0.position,
                                                   touch1.position,
                                                   initialTouch0Position,
                                                   initialTouch1Position);

                Vector2 currentMidPoint = (touch0.position + touch1.position) / 2;
                Vector3 initialPointWorldBeforeZoom = cam.ScreenToWorldPoint(initialMidPointScreen);

                Camera.main.orthographicSize = initialOrthographicSize / scaleFactor;

                Vector3 initialPointWorldAfterZoom = cam.ScreenToWorldPoint(initialMidPointScreen);
                Vector2 initialPointDelta = initialPointWorldBeforeZoom - initialPointWorldAfterZoom;

                Vector2 oldAndNewPointDelta =
                    cam.ScreenToWorldPoint(currentMidPoint) -
                    cam.ScreenToWorldPoint(initialMidPointScreen);

                Vector3 newPos = initialCameraPosition;
                newPos.x -= oldAndNewPointDelta.x - initialPointDelta.x;
                newPos.y -= oldAndNewPointDelta.y - initialPointDelta.y;

                this.transform.position = newPos;
            }
        }
        else
        {
            globals.zoom = false;
        }
    }

    static bool IsTouching(Touch touch)
    {
        return touch.phase == TouchPhase.Began ||
                touch.phase == TouchPhase.Moved ||
                touch.phase == TouchPhase.Stationary;
    }

    public static float GetScaleFactor(Vector2 position1, Vector2 position2, Vector2 oldPosition1, Vector2 oldPosition2)
    {
        float distance = Vector2.Distance(position1, position2);
        float oldDistance = Vector2.Distance(oldPosition1, oldPosition2);

        if (oldDistance == 0 || distance == 0)
        {
            return 1.0f;
        }

        return distance / oldDistance;
    }
}