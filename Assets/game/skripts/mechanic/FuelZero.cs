using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelZero : MonoBehaviour
{
    public GameObject fuelzero;
    public AudioSource ad;

    public void audioStart()
    {
        ad.Play();
    }

    void Start()
    {
        if(PlayerPrefs.GetInt("yousurwive", 0) == 1)
            fuelzero.SetActive(false);
    }
}
