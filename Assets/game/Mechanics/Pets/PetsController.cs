using UnityEngine;

public class PetSimpleFollow : MonoBehaviour
{
    [Header("Offsets (random)")]
    public Vector2 followDistanceZRange = new Vector2(20f, 30f);
    public Vector2 sideOffsetRange = new Vector2(-6f, 6f);
    public Vector2 verticalOffsetRange = new Vector2(-3f, 3f);

    [Header("Forbidden zones")]
    public Vector2 forbiddenXRange = new Vector2(-3f, 3f);
    public Vector2 forbiddenYRange = new Vector2(-3f, 3f);

    [Header("Timing")]
    public Vector2 changePositionTimeRange = new Vector2(3f, 6f);

    [Header("Movement")]
    public float smoothTime = 0.6f;
    public float spawnFlyTime = 2f;

    [Header("Idle sway (visual only)")]
    public float idleSwayStrength = 0.4f;
    public float idleSwaySpeed = 1.2f;

    [Header("Avoidance")]
    public float avoidRadius = 2f;

    [Header("Animation")]
    public bool useAnimator = true;
    public Animator animator;
    public string moveXParam = "MoveX";
    public string moveYParam = "MoveY";
    public float animationSmooth = 8f;
    public float animationDeadZone = 0.02f;

    private Transform player;
    private Vector3 targetOffset;
    private Vector3 velocity;

    private float spawnTimer;
    private bool reachedStartPos;

    private float changeTimer;
    private float nextChangeTime;

    private Vector3 lastBasePosition; // ❗ позиция БЕЗ sway
    private float animX;
    private float animY;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null)
        {
            Debug.LogError("Player не найден");
            enabled = false;
            return;
        }

        PickNewOffset();
        transform.position = player.position + targetOffset * 2f;

        ResetChangeTimer();
        lastBasePosition = transform.position;
    }

    void Update()
    {
        Vector3 baseTarget = player.position + targetOffset;

        // ==== ПЕРЕМЕЩЕНИЕ ====
        if (!reachedStartPos)
        {
            spawnTimer += Time.deltaTime;
            float t = Mathf.Clamp01(spawnTimer / spawnFlyTime);

            baseTarget = Vector3.SmoothDamp(
                transform.position,
                baseTarget,
                ref velocity,
                smoothTime * (1f - t)
            );

            if (t >= 1f)
                reachedStartPos = true;
        }
        else
        {
            baseTarget = Vector3.SmoothDamp(
                transform.position,
                baseTarget,
                ref velocity,
                smoothTime
            );
        }

        // ==== ПРОВЕРКА НА ОКРУЖЕНИЕ ====
        if (IsPositionBlocked(baseTarget))
        {
            PickNewOffset();
            ResetChangeTimer();
        }

        // ==== АНИМАЦИИ (БЕЗ SWAY) ====
        UpdateAnimation(baseTarget);

        // ==== IDLE SWAY (ТОЛЬКО ВИЗУАЛ) ====
        Vector3 sway = Vector3.zero;
        if (reachedStartPos)
        {
            sway.x = Mathf.Sin(Time.time * idleSwaySpeed) * idleSwayStrength;
            sway.y = Mathf.Cos(Time.time * idleSwaySpeed * 0.8f) * idleSwayStrength;
        }

        transform.position = baseTarget + sway;

        // ==== СМЕНА ПОЗИЦИИ ====
        changeTimer += Time.deltaTime;
        if (changeTimer >= nextChangeTime)
        {
            PickNewOffset();
            ResetChangeTimer();
        }
    }

    void UpdateAnimation(Vector3 basePosition)
    {
        if (!useAnimator || animator == null)
            return;

        Vector3 delta = (basePosition - lastBasePosition) / Time.deltaTime;
        lastBasePosition = basePosition;

        float targetX = Mathf.Abs(delta.x) < animationDeadZone ? 0f : Mathf.Clamp(delta.x * 0.1f, -1f, 1f);
        float targetY = Mathf.Abs(delta.y) < animationDeadZone ? 0f : Mathf.Clamp(delta.y * 0.1f, -1f, 1f);

        animX = Mathf.Lerp(animX, targetX, animationSmooth * Time.deltaTime);
        animY = Mathf.Lerp(animY, targetY, animationSmooth * Time.deltaTime);

        animator.SetFloat(moveXParam, animX);
        animator.SetFloat(moveYParam, animY);
    }

    bool IsPositionBlocked(Vector3 position)
    {
        Collider[] hits = Physics.OverlapSphere(position, avoidRadius);
        foreach (Collider c in hits)
        {
            if (c.CompareTag("obstacle") || c.CompareTag("Pets"))
                return true;
        }
        return false;
    }

    void PickNewOffset()
    {
        float z = Random.Range(followDistanceZRange.x, followDistanceZRange.y);

        float x;
        do { x = Random.Range(sideOffsetRange.x, sideOffsetRange.y); }
        while (x > forbiddenXRange.x && x < forbiddenXRange.y);

        float y;
        do { y = Random.Range(verticalOffsetRange.x, verticalOffsetRange.y); }
        while (y > forbiddenYRange.x && y < forbiddenYRange.y);

        targetOffset = new Vector3(x, y, -z);
    }

    void ResetChangeTimer()
    {
        changeTimer = 0f;
        nextChangeTime = Random.Range(changePositionTimeRange.x, changePositionTimeRange.y);
    }
}
