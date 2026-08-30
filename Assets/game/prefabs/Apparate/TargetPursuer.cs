using UnityEngine;

public class TargetPursuer : MonoBehaviour
{
    [HideInInspector] public Transform target;
    private float attackDuration = 15f;
    private Vector3 initialOffset;
    private float attackProgress = 0f;
    [HideInInspector] public death death;
    private bool started;
    public AudioSource Ad;

    private void Start()
    {
        initialOffset = new Vector3(Random.Range(-50f, 50f), -15f, -60f);

        attackProgress = -0.25f;

        
        float audios = PlayerPrefs.GetFloat("audios", 0.5f);
        Ad.volume = audios / 2.25f;

        if (PlayerPrefs.GetInt("audio") == 0)
            Ad.enabled = true;
        else if (PlayerPrefs.GetInt("audio") == 1)
            Ad.enabled = false;
    }

    private void Update()
    {
        attackProgress += Time.deltaTime / attackDuration;

        if(attackProgress < 0) return;

        if(started == false && attackProgress >= 0.05f)
        {
            started = true;
            transform.position = target.TransformPoint(initialOffset);
            Ad.Play();
        }

        if (attackProgress >= 1f)
        {
            transform.position = target.position;

            death.live += 1;
            death.Bonus(true);

            Destroy(gameObject);
            return;
        }

        // Текущие координаты движущейся цели
        Vector3 targetPos = target.position;
        
        // Начальная точка сдвигается за целью, но ИГНОРИРУЕТ её вращение (без TransformPoint)
        Vector3 startPosWithTarget = targetPos + initialOffset;

        // Движение по X и Z
        float currentX = Mathf.Lerp(startPosWithTarget.x, targetPos.x, attackProgress);
        float currentZ = Mathf.Lerp(startPosWithTarget.z, targetPos.z, attackProgress);

        // Движение по Y с задержкой до 70% пути
        float currentY;
        if (attackProgress < 0.7f)
        {
            currentY = startPosWithTarget.y;
        }
        else
        {
            float tFrom70 = (attackProgress - 0.7f) / 0.3f;
            currentY = Mathf.Lerp(startPosWithTarget.y, targetPos.y, tFrom70);
        }

        transform.position = new Vector3(currentX, currentY, currentZ);
    }
}