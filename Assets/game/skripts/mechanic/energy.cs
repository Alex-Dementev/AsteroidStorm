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



    void Update()
    {
        s.value = energyint;

        energyfloat -= Time.deltaTime;
        if(energyfloat <= 0)
        {
            if(energyint <= 100)
            {
                energyint += floatt;
                energyfloat = 0.25f;
            }
        }
    }

    void Start()
    {
        floatt = PlayerPrefs.GetFloat("energy", 0f);
        Debug.Log(floatt + " в сек");
    }
}
