using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energy : MonoBehaviour
{
    public float energyfloat;
    public float energyint;
    public Slider s;
    public float floatt;
    public bool isfinal1g;



    void Update()
    {
        s.value = energyint;

        energyfloat -= Time.deltaTime;

        if(!isfinal1g)
        {
            if (PlayerPrefs.GetInt("isfinal1g", 0) == 1)
            {
                energyint = PlayerPrefs.GetFloat("energytofinalglav");
                isfinal1g = true;
            }
        }

        if(energyfloat <= 0)
        {
            if(energyint <= 100)
            {
                energyint = energyint + floatt;
                energyfloat = 0.025f;
            }
        }

        if (PlayerPrefs.GetInt("GoToFinalGlav", 0) == 1)
        {
            PlayerPrefs.SetFloat("energytofinalglav", energyint);
            PlayerPrefs.SetInt("GoToFinalGlav", 0);
        }
    }

    void Start()
    {
        energyfloat = 0.1f;
        floatt = PlayerPrefs.GetFloat("energy", 0f);
        floatt = floatt / 10;
    }
}
