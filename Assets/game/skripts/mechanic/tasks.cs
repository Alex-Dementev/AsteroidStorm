using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tasks : MonoBehaviour
{
    public Text task;
    public Slider s;
    public float time;
    public int ability;
    public int alltask;
    public int istask;
    public int coins;
    public int allcoins;


    void Start()
    {
        alltask = PlayerPrefs.GetInt("alltask", 0);
        istask = PlayerPrefs.GetInt("istask", 0);

        if (istask == 0)
        {
            ability = PlayerPrefs.GetInt("abilityt", 0);
            task.text = "используй способность 10 раз";
            s.value = ability;
            s.maxValue = 10;

        }
        if (istask == 1)
        {
            task.text = "проведи в игре 10 минут";
            s.maxValue = 900;
        }
    }

    public void click()
{
    if (istask == 0)
    {
        if (ability >= 10)
        {
            alltask++;
            PlayerPrefs.SetInt("alltask", alltask);
            istask = 1;
            PlayerPrefs.SetInt("istask", 1);

            PlayerPrefs.SetInt("abilityt", 0);
            PlayerPrefs.SetFloat("tasktimet", 0);

            s.maxValue = 900;
            coins = PlayerPrefs.GetInt("coins", 0);
            coins += 700;
            PlayerPrefs.SetInt("coins", coins);
            allcoins = PlayerPrefs.GetInt("allcoins", 0);
            allcoins += 700;
            PlayerPrefs.SetInt("allcoins", allcoins);
        }
    }
    else if (istask == 1)
    {
        if (time >= 600)
        {
            alltask++;
            PlayerPrefs.SetInt("alltask", alltask);
            istask = 0;
            PlayerPrefs.SetInt("istask", 0);

            PlayerPrefs.SetFloat("tasktimet", 0);
            PlayerPrefs.SetInt("abilityt", 0);

            s.maxValue = 10;
            coins = PlayerPrefs.GetInt("coins", 0);
            coins += 700;
            PlayerPrefs.SetInt("coins", coins);
        }
    }
}


    void Update()
    {
        ability = PlayerPrefs.GetInt("abilityt", 0);
        time = PlayerPrefs.GetFloat("tasktimet", 0);
        if (istask == 1)
        {
            task.text = "проведи в игре 10 минут";
            s.value = time;
        }
        if (istask == 0)
        {
            task.text = "используй способность 10 раз";
            s.value = ability;
        }
    }
}
