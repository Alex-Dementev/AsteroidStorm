using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Characters")]
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;

    private GameObject activeCharacter;

    [Header("UI & Camera")]
    public Animator textAnimator;
    public CameraFollowAndShake c;

    [Header("Control Settings")]
    public float sensitivity = 1f;
    public float xRange = 10f;
    public float smoothFactor = 0.1f;
    public Vector3 calibrationOffset = Vector3.zero;

    private float currentX = 0f;
    private float targetX = 0f;

    private bool freezeControl = false;

    // Смещение аномалии
    private float controlOffset = 0f;
    private float targetOffset = 0f;

    [Header("Anomaly Settings")]
    private float anomalyDuration = 1.5f;      // сколько длится аномалия
    private float anomalyBetweenDelay = 0.85f; // пауза между аномалиями
    private float anomalyOffsetAmount = 15f;    // сила смещения в юнитах
    private float anomalySpeed = 30f;          // скорость смещения в юнитах/сек

    [Header("Delay Settings")]
    public float characterCheckDelay = 4f;

    void Start()
    {
        StartCoroutine(DelayedStart());
    }

    void Update()
    {
        if (activeCharacter == null) return;

        Vector3 position = activeCharacter.transform.position;

        if (!freezeControl)
        {
            // Управление игроком
            if (Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                Vector2 inputPosition =
                    Input.touchCount > 0
                        ? Input.GetTouch(0).position
                        : (Vector2)Input.mousePosition;

                Vector3 worldPosition =
                    Camera.main.ScreenToWorldPoint(
                        new Vector3(
                            inputPosition.x,
                            inputPosition.y,
                            Camera.main.transform.position.y
                        ));

                worldPosition += calibrationOffset;

                float inputX = worldPosition.x * sensitivity;
                targetX = Mathf.Clamp(inputX, -xRange, xRange);
            }

            // Основное движение игрока
            currentX = Mathf.Lerp(currentX, targetX, smoothFactor);

            // Плавное смещение аномалии через MoveTowards
            controlOffset = Mathf.MoveTowards(controlOffset, targetOffset, anomalySpeed * Time.deltaTime);

            // Итоговая позиция с аномалией
            position.x = currentX + controlOffset;

            activeCharacter.transform.position = position;
        }
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(characterCheckDelay);
        DetectActiveCharacter();
        StartCoroutine(GameLoop());
    }

    void DetectActiveCharacter()
    {
        if (s1.activeInHierarchy) activeCharacter = s1;
        else if (s2.activeInHierarchy) activeCharacter = s2;
        else if (s3.activeInHierarchy) activeCharacter = s3;
        else if (s4.activeInHierarchy) activeCharacter = s4;
    }

    IEnumerator GameLoop()
    {
        while (true)
        {
            float randomTime = Random.Range(25f, 65f);
            yield return new WaitForSeconds(randomTime);

            if (activeCharacter == null)
                yield break;

            textAnimator.Play("anim15 1");
            c.TriggerShake(5, 0.06f);

            for (int i = 0; i < 6; i++)
            {
                // случайное смещение ±anomalyOffsetAmount
                targetOffset = Random.value < 0.5f ? -anomalyOffsetAmount : anomalyOffsetAmount;

                // ждём, пока аномалия идёт
                float timer = 0f;
                while (timer < anomalyDuration)
                {
                    timer += Time.deltaTime;
                    yield return null;
                }

                // возвращаемся в центр
                targetOffset = 0f;
                timer = 0f;
                while (timer < anomalyBetweenDelay)
                {
                    timer += Time.deltaTime;
                    yield return null;
                }
            }

            yield return new WaitForSeconds(0.3f);
            textAnimator.Play("anim15 2");
        }
    }
}
