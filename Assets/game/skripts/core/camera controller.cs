using UnityEngine;
using System.Collections;

public class CameraFollowAndShake : MonoBehaviour
{
    [SerializeField] private Transform target; // Активный скин

    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;

    [SerializeField] private float baseSmoothSpeed = 0.125f;
    [SerializeField] private float speedMultiplier = 0.01f;
    [SerializeField] private Vector3 offset;

    private Vector3 lastTargetPosition;
    private float dynamicSmoothSpeed;
    private Vector3 shakeOffset = Vector3.zero;
    private bool isShaking = false;

    void Start()
    {
        // Выбираем активного игрока (скин)
        UpdateActiveTarget();

        if (target != null)
        {
            lastTargetPosition = target.position;
        }

        TriggerShake(99999999, 0.010f); // постоянная легкая вибрация
    }

    void LateUpdate()
    {
        UpdateActiveTarget();

        if (target != null)
        {
            float targetSpeed = Mathf.Abs(target.position.z - lastTargetPosition.z) / Time.deltaTime;
            dynamicSmoothSpeed = baseSmoothSpeed + targetSpeed * speedMultiplier;

            // Камера теперь не следует за Y
            Vector3 desiredPosition = new Vector3(transform.position.x, offset.y, target.position.z) + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, dynamicSmoothSpeed);

            transform.position = smoothedPosition + shakeOffset;

            lastTargetPosition = target.position;
        }
    }

    private void UpdateActiveTarget()
    {
        if (s1 && s1.activeInHierarchy) target = s1.transform;
        else if (s2 && s2.activeInHierarchy) target = s2.transform;
        else if (s3 && s3.activeInHierarchy) target = s3.transform;
        else if (s4 && s4.activeInHierarchy) target = s4.transform;
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        isShaking = true;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float offsetX = Random.Range(-1f, 1f) * magnitude;
            float offsetY = Random.Range(-1f, 1f) * magnitude;

            shakeOffset = new Vector3(offsetX, offsetY, 0f);
            elapsed += Time.deltaTime;
            yield return null;
        }

        shakeOffset = Vector3.zero;
        isShaking = false;
    }

    public void TriggerShake(float duration, float magnitude)
    {
        if (!isShaking)
        {
            StartCoroutine(Shake(duration, magnitude));
        }
    }
}
