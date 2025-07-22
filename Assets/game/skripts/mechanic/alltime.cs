using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alltime : MonoBehaviour
{
    public float alltimes;
    public Animator anim;
    public AudioSource ad;
    public float time;
    public int istask;
    // Start is called before the first frame update
    void Start()
    {
        alltimes = PlayerPrefs.GetFloat("alltimes", 0);

        istask = PlayerPrefs.GetInt("istask", 0);
        if (istask == 1)
        {
            time = PlayerPrefs.GetFloat("tasktimet", 0);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        istask = PlayerPrefs.GetInt("istask", 0); // Сначала получаем текущую задачу
        alltimes += Time.deltaTime;
        PlayerPrefs.SetFloat("alltimes", alltimes);


        if (istask == 1)
        {
            time = PlayerPrefs.GetFloat("tasktimet", 0);
            time += Time.deltaTime; // Прибавляем дельту
            PlayerPrefs.SetFloat("tasktimet", time); // Сохраняем обновлённое время
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
