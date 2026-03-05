using UnityEngine;

public class RotateRocketA : MonoBehaviour
{
    [Header("Swipe control")]
    public bool swipeControlEnabled = false;

    public float swipeMultiplier = 0.01f;
    public float smoothTime = 0.4f;
    public float holdTime = 0.8f;
    public float returnSmoothTime = 0.8f; // возврат в 2 раза медленнее

    private float extraSpeed = 0f;
    private float extraSpeedVelocity = 0f;
    private float holdTimer = 0f;

    private Vector2 lastPos;
    private float swipeSpeedX = 0f;
    private bool touching = false;

    void Update()
    {
        // базовая скорость (инвертированная)
        float baseSpeed = PlayerPrefs.GetFloat("R Rotate Speed", 0f) * -1f;

        if (swipeControlEnabled)
            ReadSwipe();

        UpdateExtraSpeed();

        float finalSpeed = baseSpeed + extraSpeed;
        transform.Rotate(0f, finalSpeed * Time.deltaTime, 0f);
    }

    // ===== СВАЙП =====
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
            swipeSpeedX = (current.x - lastPos.x) / Time.deltaTime * -1;
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
                swipeSpeedX = t.deltaPosition.x / Time.deltaTime * -1;
                holdTimer = holdTime;
            }
            else if (t.phase == TouchPhase.Ended)
            {
                touching = false;
            }
        }
#endif
    }

    // ===== ИНЕРЦИЯ / ВОЗВРАТ =====
    void UpdateExtraSpeed()
    {
        float targetExtra;

        if (touching)
        {
            targetExtra = swipeSpeedX * swipeMultiplier;
            holdTimer = holdTime;
        }
        else if (holdTimer > 0f)
        {
            holdTimer -= Time.deltaTime;
            targetExtra = extraSpeed;
        }
        else
        {
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
