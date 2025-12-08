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
    public Animator SliderAnim;
    public float PermanentTaskEnergy;
    public float PermanentTaskEnergySet;
    public bool DeActivateEnergySet;
    public float isDelayEnergySet;



    void Update()
    {
        if(!DeActivateEnergySet && isDelayEnergySet <= 0)
        {
            isDelayEnergySet = 2;
            PermanentTaskEnergySet = PlayerPrefs.GetInt("PermanentTaskEnergy", 0);
            PermanentTaskEnergySet += PermanentTaskEnergy;
            PlayerPrefs.SetInt("PermanentTaskEnergy", Mathf.RoundToInt(PermanentTaskEnergySet));
            PermanentTaskEnergy = 0;
        }

        s.value = energyint;

        energyfloat -= Time.deltaTime;
        isDelayEnergySet -= Time.deltaTime;

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
                energyint += floatt;
                PermanentTaskEnergy += floatt;
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
        floatt = PlayerPrefs.GetFloat("Generators1Energy", 0);
        floatt += PlayerPrefs.GetFloat("Generators2Energy", 0);
        floatt += PlayerPrefs.GetFloat("Generators3Energy", 0);
        floatt += PlayerPrefs.GetFloat("Generators4Energy", 0);
        floatt -= PlayerPrefs.GetFloat("TurbinsEnergy", 0);

        if(PlayerPrefs.GetInt("Boost2", 0) >= 1)
            floatt = floatt * (PlayerPrefs.GetFloat("ProductivityOnEnergy", 1f) + 0.5f);
        else
            floatt = floatt * PlayerPrefs.GetFloat("ProductivityOnEnergy", 1f);

        floatt = floatt / 40;
    }

    public void Bonus()
    {
        energyint += 25;
        SliderAnim.Play("Start");
    }
    public void End()
    {
        PermanentTaskEnergySet = PlayerPrefs.GetInt("PermanentTaskEnergy", 0);
        PermanentTaskEnergySet += PermanentTaskEnergy;
        PlayerPrefs.SetInt("PermanentTaskEnergy", Mathf.RoundToInt(PermanentTaskEnergySet));
        DeActivateEnergySet = true;
    }
}
