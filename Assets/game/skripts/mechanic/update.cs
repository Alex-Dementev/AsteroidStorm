using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updated : MonoBehaviour
{
    public Text text;
    public Text text2;
    public Text text3;
    public Text text4;
    public int coins;
    public float el;
    public int allE = 200;
    public int allO = 200;
    public float energy = 0.25f;
    public float otkat = 30f;
    public int lvlE;
    public int lvlO;
    public Animator anim;
    public float isdelay;

    public void isEnergy()
    {
        if(isdelay <= 0)
        {
        if(coins >= allE)
        {
            coins -= allE;
            allE += 5;
            energy = PlayerPrefs.GetFloat("energy", 0f);
            energy = energy + 0.015f;
            PlayerPrefs.SetFloat("energy", energy);
            lvlE++;
            PlayerPrefs.SetInt("coins", coins);
            PlayerPrefs.SetInt("lvlE", lvlE);
            PlayerPrefs.SetInt("allE", allE);
        }

        isdelay = 0.5f;

        }
    }
    public void Otkat()
    {
        if (otkat >= 5)
        {
            if (isdelay <= 0)
            {
                if (coins >= allO)
                {
                    coins -= allO;
                    allO += 5;
                    otkat = PlayerPrefs.GetFloat("isotkat", 30f);
                    otkat = otkat - 0.25f;
                    PlayerPrefs.SetFloat("isotkat", otkat);
                    lvlO++;
                    PlayerPrefs.SetInt("coins", coins);
                    PlayerPrefs.SetInt("lvlO", lvlO);
                    PlayerPrefs.SetInt("allO", allO);
                }

                isdelay = 0.5f;

            }
        }
    }
        
    void Start()
    {
        energy = PlayerPrefs.GetFloat("energy", 0);
        lvlE = PlayerPrefs.GetInt("lvlE", 0);
        allE = PlayerPrefs.GetInt("all", 200);
        otkat = PlayerPrefs.GetFloat("isotkat", 30);
        lvlO = PlayerPrefs.GetInt("lvlO", 0);
        allO = PlayerPrefs.GetInt("allO", 200);
    }

    void Update()
    {
        isdelay -= Time.deltaTime;
        coins = PlayerPrefs.GetInt("coins", 0);
        text2.text = "" + allE;
        text.text = "ур:" + lvlE + ".  " + energy.ToString("F3") + " в сек";
        text4.text = "" + allO;
        text3.text = "ур:" + lvlO + ".  " + otkat.ToString("F2") + " сек";
    }
}