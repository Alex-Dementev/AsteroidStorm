using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArmatures : MonoBehaviour
{
    [Header("Арматуры на сцене")]
    public GameObject[] armatures; // все арматуры в сцене

    void Start()
    {
        TryActivate();
    }

    void TryActivate()
    {
        // 1. Проверяем — будет ли вообще спавн (включение)
        if (Random.value > 0.4f) // 40% шанс
        {
            Debug.Log("Спавн отменён)");
            return;
        }

        // 2. Определяем, сколько активировать
        float chance = Random.value;
        int count = 0;

        if (chance < 0.5f) count = 1;            // 50%
        else if (chance < 0.8f) count = 2;       // 30%
        else if (chance < 0.95f) count = 3;      // 15%
        else count = Random.Range(4, 6);         // 5% на 4 или 5

        Debug.Log($"Будет активировано {count} арматур.");

        // 3. Отключаем все сначала
        foreach (GameObject arm in armatures)
            arm.SetActive(false);

        // 4. Включаем случайные
        List<int> usedIndexes = new List<int>();
        for (int i = 0; i < count; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, armatures.Length);
            } while (usedIndexes.Contains(randomIndex));

            usedIndexes.Add(randomIndex);
            armatures[randomIndex].SetActive(true);
        }
    }
}
