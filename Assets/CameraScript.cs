using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // (Optional) Prevent non-singleton constructor use.
    protected CameraScript() { }

    // Then add whatever code to the class you need as you normally would.
    public string MyTestString = "Hello world!";
    //=========================================ограничение камеры=====================//
    private float XMargin = 1f; // Distance in the x axis the player can move before the camera follows.
    private float YMargin = 1f; // Distance in the y axis the player can move before the camera follows.
    private float XSmooth = 8f; // How smoothly the camera catches up with it's target movement in the x axis.
    private float YSmooth = 8f; // How smoothly the camera catches up with it's target movement in the y axis.
    private Vector2 MaxXAndY; // The maximum x and y coordinates the camera can have.
    private Vector2 MinXAndY; // The minimum x and y coordinates the camera can have.
    public bool IsZoomBlocked //Blocked Zooming
    { get; set; }
    public bool IsDragBlocked //Blocked Drag
    { get; set; }

    private Transform MPlayer; // Reference to the player's transform.
    //==================================================================================//
    // экранные координаты начальной точки касания
    private Vector3 InitialTouchPosition;
    // мировые координаты камеры при инициировании
    // перемещения/масштабирования
    private Vector3 InitialCameraPosition;

    // экранные координаты начальной точки первого касания
    private Vector3 InitialTouch0Position;
    // экранные координаты начальной точки второго касания
    private Vector3 InitialTouch1Position;
    // средняя точка между начальными координатами касаний
    private Vector3 InitialMidPointScreen;
    // ортогональный размер камеры на момент начала масштабирования
    private float InitialOrthographicSize;
    private Camera Cam;
    //Координаты карты
    private float MapX = -260.5f;
    private float MapY = 29.6f;
    //Переменные
    private float MinX;
    private float MaxX;
    private float MinY;
    private float MaxY;
    private float VertExtent;
    private float HorzExtent;
    private Vector3 V3;
    private float ScreeToWorldPoint1;

    // Use this for initialization
    void Start()
    {

        Cam = GetComponentInChildren<Camera>();
        // двигаем камеру
        IsDragBlocked = true;
        IsZoomBlocked = true;
        // масштабируем
        //=====Ограничение камеры========//
        VertExtent = Cam.orthographicSize;
        HorzExtent = VertExtent * Screen.width / Screen.height;
        // Calculations assume map is position at the origin
        MinX = HorzExtent - MapX / 2.0f;
        MaxX = MapX / 2.0f - HorzExtent;
        MinY = VertExtent - MapY / 2.0f;
        MaxY = MapY / 2.0f - VertExtent;
    }
    //Calculate orthographic camera bounds 
    void CheckBoundCamera()
    {
        float height = 2f * Cam.orthographicSize;
        float width = height * Cam.aspect;
        Vector2 t0 = transform.position;
        float t1 = t0.y + (height / 2);
        float t2 = t0.x - (width / 2);
        float t3 = t0.y - (height / 2);
        float t4 = t0.x + (width / 2);
    }
    // Update is called once per frame

    void Update()
    {
        //
        CheckBoundCamera();

        if (Input.touchCount == 1)
        {
            IsZoomBlocked = true;
            Touch touch0 = Input.GetTouch(0);

            if (IsTouching(touch0))
            {
                if (!IsDragBlocked)
                {
                    InitialTouchPosition = touch0.position;
                    InitialCameraPosition = transform.position;

                    IsDragBlocked = true;
                }
                else
                {
                    Vector2 delta = Cam.ScreenToWorldPoint(touch0.position) -
                                    Cam.ScreenToWorldPoint(InitialTouchPosition);

                    Vector3 newPos = InitialCameraPosition;
                    newPos.x -= delta.x;
                    newPos.y -= delta.y;

                    transform.position = newPos;
                }
            }

            if (!IsTouching(touch0))
            {
                IsZoomBlocked = false;
            }
        }
        else
        {
            IsDragBlocked = false;
        }

        if (Input.touchCount == 2)
        {
            IsDragBlocked = false;

            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (!IsZoomBlocked)
            {
                InitialTouch0Position = touch0.position;
                InitialTouch1Position = touch1.position;
                InitialCameraPosition = transform.position;
                InitialOrthographicSize = Camera.main.orthographicSize;
                InitialMidPointScreen = (touch0.position + touch1.position) / 2;

                IsZoomBlocked = true;
            }
            else
            {
                transform.position = InitialCameraPosition;
                Cam.orthographicSize = InitialOrthographicSize;

                float scaleFactor = GetScaleFactor(touch0.position,
                                                   touch1.position,
                                                   InitialTouch0Position,
                                                   InitialTouch1Position);

                Vector2 currentMidPoint = (touch0.position + touch1.position) / 2;
                Vector3 initialPointWorldBeforeZoom = Cam.ScreenToWorldPoint(InitialMidPointScreen);

                Camera.main.orthographicSize = InitialOrthographicSize / scaleFactor;

                Vector3 initialPointWorldAfterZoom = Cam.ScreenToWorldPoint(InitialMidPointScreen);
                Vector2 initialPointDelta = initialPointWorldBeforeZoom - initialPointWorldAfterZoom;

                Vector2 oldAndNewPointDelta =
                    Cam.ScreenToWorldPoint(currentMidPoint) -
                    Cam.ScreenToWorldPoint(InitialMidPointScreen);

                Vector3 newPos = InitialCameraPosition;
                newPos.x -= oldAndNewPointDelta.x - initialPointDelta.x;
                newPos.y -= oldAndNewPointDelta.y - initialPointDelta.y;

                transform.position = newPos;
            }
        }
        else
        {
            IsZoomBlocked = false;
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
