using UnityEngine;

public class RotateRocket : MonoBehaviour
{
    [Header("Swipe control")]
    public bool swipeControlEnabled = false;

    public float swipeMultiplier = 0.01f;   // насколько скорость пальца влияет
    public float smoothTime = 0.4f;         // плавность реакции (всегда мягко)
    public float holdTime = 0.8f;            // сколько "висит" после отпускания
    public float returnSmoothTime = 0.6f;    // плавный возврат к норме

    private float extraSpeed = 50f;
    private float extraSpeedVelocity = 0f;

    private float holdTimer = 0f;

    private Vector2 lastPos;
    private float swipeSpeedX = 0f;
    private bool touching = false;

    void Update()
    {
        float baseSpeed = PlayerPrefs.GetFloat("R Rotate Speed", 0f);

        if (swipeControlEnabled)
            ReadSwipe();

        UpdateExtraSpeed();

        float finalSpeed = baseSpeed + extraSpeed;
        transform.Rotate(0f, 0f, finalSpeed * Time.deltaTime);
    }

    // ===== ЧТЕНИЕ СВАЙПА =====
    void ReadSwipe()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            lastPos = Input.mousePosition;
            touching = true;
        }
        else if (Input.GetMouseButton(0) && touching)
        {
            Vector2 current = Input.mousePosition;
            swipeSpeedX = (current.x - lastPos.x) / Time.deltaTime;
            lastPos = current;
            holdTimer = holdTime;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touching = false;
        }
#else
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                lastPos = t.position;
                touching = true;
            }
            else if (t.phase == TouchPhase.Moved && touching)
            {
                swipeSpeedX = t.deltaPosition.x / Time.deltaTime;
                holdTimer = holdTime;
            }
            else if (t.phase == TouchPhase.Ended)
            {
                touching = false;
            }
        }
#endif
    }

    // ===== ЛОГИКА СКОРОСТИ =====
    void UpdateExtraSpeed()
    {
        float targetExtra = 0f;

        if (touching)
        {
            // палец движется → управляет скоростью
            targetExtra = swipeSpeedX * swipeMultiplier;
            holdTimer = holdTime;
        }
        else if (holdTimer > 0f)
        {
            // "висим" после отпускания
            holdTimer -= Time.deltaTime;
            targetExtra = extraSpeed;
        }
        else
        {
            // плавно возвращаемся к норме
            targetExtra = 0f;
        }

        float usedSmooth = touching ? smoothTime : returnSmoothTime;

        extraSpeed = Mathf.SmoothDamp(
            extraSpeed,
            targetExtra,
            ref extraSpeedVelocity,
            usedSmooth
        );
    }
}
