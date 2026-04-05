using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alltime : MonoBehaviour
{
    private static alltime instance; // Добавляем Singleton-защиту

    private float alltimes;
    private float time;

    void Awake()
    {
        // Защита от дубликатов
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Не уничтожать при смене сцены
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        alltimes = PlayerPrefs.GetFloat("alltimes", 0);
    }

    void Update()
    {
        alltimes += Time.deltaTime;
        PlayerPrefs.SetFloat("alltimes", alltimes);

        if (PlayerPrefs.GetInt("currentTask1", -1) == 1)
        {
            time = PlayerPrefs.GetFloat("taskTime", 0);
            time += Time.deltaTime;
            PlayerPrefs.SetFloat("taskTime", time);
        }
    }
}
