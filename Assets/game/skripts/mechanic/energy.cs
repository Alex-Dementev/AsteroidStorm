using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energy : MonoBehaviour
{
    private float energyfloat;
    public float energyint;
    public Slider s;
    private float floatt;
    public bool isfinal1g;
    public Animator SliderAnim;
    private float PermanentTaskEnergy;
    private float PermanentTaskEnergySet;
    public bool DeActivateEnergySet;
    private float isDelayEnergySet;
    public GameObject EnergyObject;


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
            energyint = PlayerPrefs.GetFloat("energytofinalglav");
            isfinal1g = true;
        }

        if(energyfloat <= 0)
        {
            if(energyint <= 100)
            {
                energyint += floatt;
                if(energyint != 0)
                    energyint -= energyint * 0.0023f;
                PermanentTaskEnergy += floatt;
                energyfloat = 0.025f;
            }
            else
            {
                energyint -= energyint * 0.0023f;
                energyfloat = 0.025f;
            }
        }

        PlayerPrefs.SetFloat("energytofinalglav", energyint);
    }

    void Start()
    {
        energyfloat = 0.1f;
        
        EnergyReset(true);
    }

    public void EnergyReset(bool EnableGenerators)
    {
        if(EnableGenerators)
        {
            floatt = PlayerPrefs.GetFloat("Generators1Energy", 0);
            floatt += PlayerPrefs.GetFloat("Generators2Energy", 0);
            floatt += PlayerPrefs.GetFloat("Generators3Energy", 0);
            floatt += PlayerPrefs.GetFloat("Generators4Energy", 0);

            if(floatt <= 0.002 && floatt >= -0.002)
                EnergyObject.SetActive(false);

            if(floatt != 0)
            {
                if(PlayerPrefs.GetInt("Boost2", 0) >= 1)
                    floatt = floatt * (PlayerPrefs.GetFloat("ProductivityOnEnergy", 1f) + 0.5f);
                else
                    floatt = floatt * PlayerPrefs.GetFloat("ProductivityOnEnergy", 1f);
            }
        }
        else
        {
            floatt = 0;
        }

        floatt -= PlayerPrefs.GetFloat("TurbinsEnergy", 0);

        if(floatt != 0)
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
