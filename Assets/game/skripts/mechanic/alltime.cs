using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alltime : MonoBehaviour
{
    private static alltime instance; // Добавляем Singleton-защиту

    public float alltimes;
    public Animator anim;
    public AudioSource ad;
    public float time;
    public int istask;

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
        istask = PlayerPrefs.GetInt("istask", 0);

        if (istask == 1)
        {
            time = PlayerPrefs.GetFloat("tasktimet", 0);
        }
    }

    void Update()
    {
        istask = PlayerPrefs.GetInt("istask", 0);
        alltimes += Time.deltaTime;
        PlayerPrefs.SetFloat("alltimes", alltimes);

        if (istask == 1)
        {
            time = PlayerPrefs.GetFloat("tasktimet", 0);
            time += Time.deltaTime;
            PlayerPrefs.SetFloat("tasktimet", time);

            if (time >= 600 && PlayerPrefs.GetInt("is600") == 0)
            {
                anim.Play("anim31");
                PlayerPrefs.SetInt("is600", 1);
                ad.Play();
            }
        }

        if (PlayerPrefs.GetInt("audio") == 0)
        {
            ad.enabled = true;
        }
        else if (PlayerPrefs.GetInt("audio") == 1)
        {
            ad.enabled = false;
        }
    }
}
