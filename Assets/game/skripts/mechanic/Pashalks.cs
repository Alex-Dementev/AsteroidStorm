using UnityEngine;

public class Pashalks : MonoBehaviour
{
    [Header("Объект, который может включиться с очень маленьким шансом")]
    public GameObject objectToEnable;

    [Header("Шанс появления (0.05 = 0.05%)")]
    [Range(0f, 100f)] public float spawnChance = 0.02f;

    void Start()
    {
        float randomValue = Random.Range(0f, 100f);

        if (randomValue < spawnChance)
        {
            objectToEnable.SetActive(true);
            Debug.Log("Пасхалка активирована!");
        }
        else
        {
            objectToEnable.SetActive(false);
        }
    }
}
