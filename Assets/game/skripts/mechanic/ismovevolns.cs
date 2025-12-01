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
    private bool invertControl = false;
    private bool freezeControl = false;

    [Header("Anomaly Settings")]
    public float anomalyDuration = 1.2f;
    public float anomalyBetweenDelay = 0.5f;

    [Header("Delay Settings")]
    public float characterCheckDelay = 4f; // время до проверки персонажа

    void Start()
    {
        // Запускаем проверку персонажа через 4 секунды
        StartCoroutine(DelayedStart());
    }

    void Update()
    {
        if (activeCharacter != null)
        {
            Vector3 position = activeCharacter.transform.position;

            if (!freezeControl)
            {
                if (Input.touchCount > 0 || Input.GetMouseButton(0))
                {
                    Vector2 inputPosition = Input.touchCount > 0 ? Input.GetTouch(0).position : (Vector2)Input.mousePosition;
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, Camera.main.transform.position.y));
                    worldPosition += calibrationOffset;

                    float clampedX = Mathf.Clamp(worldPosition.x * sensitivity, -xRange, xRange);
                    targetX = invertControl ? -clampedX : clampedX;
                }

                currentX = Mathf.Lerp(currentX, targetX, smoothFactor);
                position.x = currentX;
                activeCharacter.transform.position = position;
            }
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
            float randomTime = Random.Range(25, 65f);
            yield return new WaitForSeconds(randomTime);

            if (activeCharacter == null) yield break;

            textAnimator.Play("anim15 1");
            c.TriggerShake(5, 0.06f);

            bool doReverse = Random.value < 0.5f;

            for (int i = 0; i < 8; i++)
            {
                if (doReverse)
                {
                    invertControl = true;
                    yield return new WaitForSeconds(anomalyDuration);
                    invertControl = false;
                }
                else
                {
                    freezeControl = true;
                    yield return new WaitForSeconds(anomalyDuration);
                    freezeControl = false;
                }

                yield return new WaitForSeconds(anomalyBetweenDelay);
            }

            yield return new WaitForSeconds(0.5f);
            textAnimator.Play("anim15 2");
        }
    }
}
