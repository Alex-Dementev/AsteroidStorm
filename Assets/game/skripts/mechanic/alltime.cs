using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alltime : MonoBehaviour
{
    public float alltimes;
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

    if (istask == 1)
    {
        time = PlayerPrefs.GetFloat("tasktimet", 0);
        time += Time.deltaTime; // Прибавляем дельту
        PlayerPrefs.SetFloat("tasktimet", time); // Сохраняем обновлённое время
    }
}

}
