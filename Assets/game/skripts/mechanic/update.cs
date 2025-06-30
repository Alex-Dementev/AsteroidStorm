using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updated : MonoBehaviour
{
    public Text text;
    public Text text2;
    public int coins;
    public float el;
    public int all = 200;
    public float energy = 0.25f;
    public int lvl;
    public Animator anim;
    public float isdelay;

    public void isEnergy()
    {
        if(isdelay <= 0)
        {
        if(coins >= all)
        {
            anim.Play("anim 12 1");
            coins -= all;
            all += 5;
            energy = PlayerPrefs.GetFloat("energy", 0f);
            energy = energy + 0.015f;
            PlayerPrefs.SetFloat("energy", energy);
            lvl++;
            PlayerPrefs.SetInt("coins", coins);
        }
        else
        anim.Play("anim 12 0");

        isdelay = 0.5f;

        }
    }
        
    void Start()
    {
        energy = PlayerPrefs.GetFloat("energy", 0);
    }

    void Update()
    {
        isdelay -= Time.deltaTime;
        coins = PlayerPrefs.GetInt("coins", 0);
        text2.text = "" + all;
        text.text = "ур:" + lvl + ". " + energy.ToString("F4") + " в сек";
    }
}